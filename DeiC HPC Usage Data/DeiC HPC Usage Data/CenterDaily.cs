using System;

namespace DeiC_HPC_Usage_Data
{
    public class CenterDaily
    {
        /*
         * Each HPC center has a unique ID. This is defined as a GUID/UUID
         */
        public Guid HPCCenterId { get; set; }
        /*
         * In case of sub centers they can use a sub id. This is defined as a GUID/UUID
         */
        public Guid SubHPCCenterId { get; set; }
        /*
         * Date for the entry in ISO 8601 format.
         * Please ensure to a correct ISO8601-1:2019 date format.
         * Access time https://en.wikipedia.org/wiki/ISO_8601
         * As this pr day. Time format should just be 00:00:01 etc or just anotner time of the day.
         */
        public DateTime Date { get; set; }
        /*
         * User must have a ORCID. This needs to be collected when loging in.
         * Please use: https://support.orcid.org/hc/en-us/articles/360006897674-Structure-of-the-ORCID-Identifier
         * It is based on https://www.iso.org/standard/44292.html
         */
        public string ORCID { get; set; }

        /*
         * A local id for the user. This must be the same for alle logins from that user.
         * Whe national AAI is ready use the national id. This is the identity provided om the AAI.
         */
        public string LocalId { get; set; }

        /*
         * Each project that are assigned usage time have a generated project id. The format of the ID is string.
         * Change: From GUID to follow the DeiC project format: https://www.deic.dk/en/Supercomputing/Instructions-and-Guides/Remember-to-acknowledge-the-use-of-national-hpc
         */
        public string DEICProjectId { get; set; }
        /*
         * Each university is defined as a constant. New will be added if needed.
         */
        public UniversityId UniversityId { get; set; }
        /*
         * In case of unknown, industry or other is used please specify in the IdExpanded field.
         */
        public string IdExpanded { get; set; }
        /*
         * Each access type is defined as a constand.
         * The access type can be read from the project id also. It is part of basic data type to enable better filtering
         * See AccessType datatype.
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
        public ulong? NetworkUsageInMB { get; set; }
        /*
         * Network avg in Mbps
         */
        public double? NetworkAvgUsage { get; set; }
        /*
         * Max node time. For Type 4 only as they do not have CPU/GPU core times.
         */
        public ulong? MaxNodeTime { get; set; }
        /*
         * Used node time. For Type 4 only as they do not have CPU/GPU core times.
         */
        public ulong? UsedNoteTime { get; set; }
    }

}
