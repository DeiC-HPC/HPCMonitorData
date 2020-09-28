using System;

namespace DeiC_HPC_Usage_Data
{
    public class CenterForcast
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
         * Forcast period start date in ISO 8601 format.
         */
        public DateTime StartPeriode { get; set; }
        /*
         * Forcast period end date in ISO 8601 format.
         */
        public DateTime EndPeriode { get; set; }
        /*
         * Max CPU core time in hours
         */
        public ulong MaxCPUCoreTime { get; set; }
        /*
         * Max GPU core time in hours
         */
        public ulong MaxGPUCoreTime { get; set; }
        /*
         * Max storage space in MB
         */
        public ulong MaxStorageUsedInMB { get; set; }
        /*
         * Max network usage in MB
         */
        public ulong NetworkUsageInMB { get; set; }
        /*
         * Max node time. For Type 4 only as they do not have CPU/GPU core times.
         */
        public ulong MaxNodeTime { get; set; }
    }
}
