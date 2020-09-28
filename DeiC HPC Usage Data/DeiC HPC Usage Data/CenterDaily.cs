using System;

namespace DeiC_HPC_Usage_Data
{
    public class CenterDaily
    {
        /*
         * Each HPC center has a unique ID. This is defined as a GUID
         */
        public Guid HPCCenterId { get; set; }
        /*
         * In case of sub centers they can use a sub id. This is defined as a GUID
         */
        public Guid SubHPCCenterId { get; set; }
        /*
         * Date for the entry in ISO 8601 format.
         */
        public DateTime Date { get; set; }
        /*
         * User must have a ORCID. This needs to be collected when loging in.
         */
        public string ORCID { get; set; }
        /*
         * Each project that are assigned usage time have a generated project id. The format of the ID is GUID.
         */
        public Guid DEICProjectId { get; set; }
        /*
         * Each university is defined as a constant. New will be added if needed.
         */
        public UniversityId UniversityId { get; set; }
        /*
         * Each access type is defined as a constand.
         */
        public AccessType AccessType { get; set; }
        /*
         * Max CPU core time in hours
         */
        public ulong MaxCPUCoreTime { get; set; }
        /*
         * Used CPU core time in hours
         */
        public ulong UsedCPUCoretime { get; set; }
        /*
         * Max GPU core time in hours
         */
        public ulong MaxGPUCoreTime { get; set; }
        /*
         * Used GPU core time in hours
         */
        public ulong UsedGPUCoretime { get; set; }
        /*
         * Storage space in MB
         */
        public ulong StorageUsedInMB { get; set; }
        /*
        * Network usage in MB
        */
        public ulong NetworkUsageInMB { get; set; }
        /*
         * Network avg in Mbps
         */
        public double NetworkAvgUsage { get; set; }
        /*
         * Max node time. For Type 4 only as they do not have CPU/GPU core times.
         */
        public ulong MaxNodeTime { get; set; }
        /*
         * Used node time. For Type 4 only as they do not have CPU/GPU core times.
         */
        public ulong UsedNoteTime { get; set; }
    }

}
