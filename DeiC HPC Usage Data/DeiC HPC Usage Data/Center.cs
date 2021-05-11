using System;

namespace DeiC_HPC_Usage_Data
{
    public class Center
    {
        /*
         * Each HPC center has a unique ID. This is defined as a GUID/uuid
         */
        public Guid HPCCenterId { get; set; }
        /*
         * In case of sub centers they can use a sub id. This is defined as a GUID/uuid
         */
        public Guid SubHPCCenterId { get; set; }
        /*
        * Start time report periode in ISO 8601 format.
        * Please ensure to a correct ISO8601-1:2019 date format.
         * Access time https://en.wikipedia.org/wiki/ISO_8601
        */
        public DateTime StartPeriode { get; set; }
        /*
        * End time report periode in ISO 8601 format.
        * Please ensure to a correct ISO8601-1:2019 date format.
         * Access time https://en.wikipedia.org/wiki/ISO_8601
        */
        public DateTime EndPeriode { get; set; }
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
         * Storage space in MB for the period
         */
        public ulong StorageUsedInMB { get; set; }
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
