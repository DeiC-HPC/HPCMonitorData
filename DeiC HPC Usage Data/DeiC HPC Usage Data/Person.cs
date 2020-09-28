using System;

namespace DeiC_HPC_Usage_Data
{
    public class Person
    {
        /*
         * User must have a ORCID. This needs to be collected when loging in.
         */
        public string ORCID { get; set; }
        /*
         * Each project that are assigned usage time have a generated project id. The format of the ID is GUID.
         */
        public Guid DEICProjectId { get; set; }
        /*
         * Each HPC center has a unique ID. This is defined as a GUID
         */
        public Guid HPCCenterId { get; set; }
        /*
         * In case of sub centers they can use a sub id. This is defined as a GUID
         */
        public Guid SubHPCCenterId { get; set; }
        /*
         * Each university is defined as a constant. New will be added if needed.
         */
        public UniversityId UniversityId { get; set; }
        /*
         * Each access type is defined as a constand.
         */
        public AccessType AccessType { get; set; }
        /*
         * Access start time in ISO 8601 format.
         */
        public DateTime AccessStartDate { get; set; }
        /*
         * Access end time in ISO 8601 format.
         */ 
        public DateTime AccessEndDate { get; set; }
        /*
         * Assigned CPU core time in hours
         */
        public ulong CPUCoreTimeAssigned { get; set; }
        /*
         * Used CPU core time in hours
         */
        public ulong CPUCoreTimeUsed { get; set; }
        /*
         * Assigned GPU core time in hours
         */
        public ulong GPUCoreTimeAssigned { get; set; }
        /*
         * Used GPU core time in hours
         */
        public ulong GPUCoreTimeUsed { get; set; }
        /*
         * Assigned storage space in MB
         */
        public ulong StorageAssignedInMB { get; set; }
        /*
         * Used storage space in MB
         */
        public ulong StorageUsedInMB { get; set; }
        /*
         * Assigned node time. For Type 4 only as they do not have CPU/GPU core times.
         */
        public ulong NodeTimeAssigned { get; set; }
        /*
         * Used node time. For Type 4 only as they do not have CPU/GPU core times.
         */
        public ulong NodeTimeUsed { get; set; }
    }
}
