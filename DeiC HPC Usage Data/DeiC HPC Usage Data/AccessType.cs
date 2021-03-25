namespace DeiC_HPC_Usage_Data
{
    public enum AccessType
    {
        /* Soruce of resource is unknown */
        UNKNOWN = 0,
        /* Source of resouce comes from university part */
        LOCAL = 1,
        /* Source of resource comes from national resource allocation body */
        NATIONAL = 2,
        /* Source of resource comes from national sanbox pool (DeiC controlled) */
        SANDBOX = 3,
        /* Not uses for now: Source of resource comes from the national body international pool.
         * It is a place holder if we want to share DKs HPC resouce into EuroHPC. */
        INTERNATIONAL = 4,
    }
}