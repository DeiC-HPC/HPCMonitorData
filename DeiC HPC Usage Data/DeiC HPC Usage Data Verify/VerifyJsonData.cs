using DeiC_HPC_Usage_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeiC_HPC_Usage_Data_Verify
{
    internal class VerifyJsonData
    {
        private List<Person> _persons;
        private List<CenterDaily> _centerDailies;

        public VerifyJsonData(List<Person> persons, List<CenterDaily> centerDailies)
        {
            _persons = persons;
            _centerDailies = centerDailies;
        }

        internal Task<bool> Check()
        {
            List<Task<List<ErrorMsg>>> waitable = new List<Task<List<ErrorMsg>>>(){ CheckPerson(), CheckCenter() };
            Task.WaitAll(waitable.ToArray());
            bool haveErrors = false;
            foreach (var t in waitable)
            {
                var errorLst = t.Result;
                if (errorLst.Any())
                {
                    haveErrors = true;
                }
                errorLst.ForEach(x => Console.WriteLine($"{x.DataSet} : {x.Message}"));
            }

            return Task.FromResult<bool>(haveErrors);
        }

        private Task<List<ErrorMsg>> CheckCenter()
        {
            Task<List<ErrorMsg>> t = Task.Run(() =>
            {
                //check only one center ID.
                List<ErrorMsg> errMsg = new List<ErrorMsg>();
                var centerCount = _centerDailies.Select(x => x.HPCCenterId).Distinct().Count();
                if (centerCount != 1)
                {
                    errMsg.Add(new ErrorMsg() { DataSet = "CenterDaily", Message = "Multiple HPC center IDs found - define Sub center IDs if needed." });
                }
                // check any project id in center not in person.
                var prodIdDict = _persons.Select(x => x.DEICProjectId).Distinct().ToHashSet();
                foreach (var pid in _centerDailies.Select(x => x.DEICProjectId).Distinct())
                {
                    if (!prodIdDict.Contains(pid))
                    {
                        errMsg.Add(new ErrorMsg() { DataSet = "CenterDaily", Message = $"Project ID => {pid} <= do not exist in Person data" });
                    }
                }

                // check if any null values for ORCID.
                _centerDailies.ForEach(x =>
                {
                    if (String.IsNullOrEmpty(x.ORCID))
                    {
                        errMsg.Add(new ErrorMsg() { DataSet = "CenterDaily", Message = $"Empty ORDID for data found at {x.Date} project ID {x.DEICProjectId}" });
                    }
                });

                // check any user ID in center not in person
                var personIdDict = _persons.Select(x => x.ORCID).Distinct().ToHashSet();
                foreach (var pid in _centerDailies.Select(x => x.ORCID).Distinct())
                {
                    if (!personIdDict.Contains(pid))
                    {
                        errMsg.Add(new ErrorMsg() { DataSet = "CenterDaily", Message = $"ORCID => {pid} <= do not exist in Person data" });
                    }
                }

                // check access type and university ID is not unknown or not set.
                foreach (var kv in _centerDailies.Select(x => new Tuple<AccessType, UniversityId, DateTime, string>(x.AccessType, x.UniversityId, x.Date, x.DEICProjectId)))
                {
                    if (kv.Item1 == AccessType.UNKNOWN)
                    {
                        errMsg.Add(new ErrorMsg() { DataSet = "CenterDaily", Message = $"Access type is unknown at {kv.Item3} for project id {kv.Item3}" });
                    }
                    if (kv.Item2 == UniversityId.UNKNOWN)
                    {
                        errMsg.Add(new ErrorMsg() { DataSet = "CenterDaily", Message = $"University ID is unknown at {kv.Item3} for project id {kv.Item3}" });
                    }
                }

                return errMsg;
            });
            return t;
        }

        private Task<List<ErrorMsg>> CheckPerson()
        {
            Task<List<ErrorMsg>> t = Task.Run(() =>
            {
                //check only one center ID.
                List<ErrorMsg> errMsg = new List<ErrorMsg>();
                var centerCount = _persons.Select(x => x.HPCCenterId).Distinct().Count();
                if (centerCount != 1)
                {
                    errMsg.Add(new ErrorMsg() { DataSet = "Person", Message = "Multiple HPC center IDs found - define Sub center IDs if needed." });
                }
                // check any project id in person is not in center.
                var centerDict = _centerDailies.Select(x => x.DEICProjectId).Distinct().ToHashSet();
                foreach (var pid in _persons.Select(x => x.DEICProjectId).Distinct())
                {
                    if (!centerDict.Contains(pid))
                    {
                        errMsg.Add(new ErrorMsg() { DataSet = "Person", Message = $"{pid} do not exist in CenterDaily data" });
                    }
                }

                // check if any null values for ORCID.
                _persons.ForEach(x =>
                {
                    if (String.IsNullOrEmpty(x.ORCID))
                    {
                        errMsg.Add(new ErrorMsg() { DataSet = "Person", Message = $"Empty ORDID for data found at {x.AccessStartDate} project ID {x.DEICProjectId}" });
                    }
                });

                // check any user ID in center not in person
                var centerIdDict = _centerDailies.Select(x => x.ORCID).Distinct().ToHashSet();
                foreach (var pid in _persons.Select(x => x.ORCID).Distinct())
                {
                    if (!centerIdDict.Contains(pid))
                    {
                        errMsg.Add(new ErrorMsg() { DataSet = "Person", Message = $"ORCID => {pid} <= do not exist in CenterDaily data" });
                    }
                }

                foreach (var kv in _persons.Select(x => new Tuple<AccessType, UniversityId, DateTime, string>(x.AccessType, x.UniversityId, x.AccessStartDate, x.DEICProjectId)))
                {
                    if (kv.Item1 == AccessType.UNKNOWN)
                    {
                        errMsg.Add(new ErrorMsg() { DataSet = "Person", Message = $"Access type is unknown at {kv.Item3} for project id {kv.Item3}" });
                    }
                    if (kv.Item2 == UniversityId.UNKNOWN)
                    {
                        errMsg.Add(new ErrorMsg() { DataSet = "Person", Message = $"University ID is unknown at {kv.Item3} for project id {kv.Item3}" });
                    }
                }


                return errMsg;
            });
            return t;
        }
    }
}