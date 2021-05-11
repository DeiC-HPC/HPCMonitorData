# HPCMonitorData
Danish national HPC monitor data structure. Needed to collect usage across different HPC machines

The sample code is done in C# as a .Netstandard 2.1 lib. The needed json files is also present.
Net core is run on all systems.

Download net core from [here](https://dotnet.microsoft.com/download)

To build the tools and lib use
```cmd
netcore build "DeiC HPC Usage Data"
```

Link for json files: [look here](https://github.com/DeiC-HPC/HPCMonitorData/tree/master/DeiC%20HPC%20Usage%20Data)

[Notat on the fields can be found here](notat.md)

Missing
 - alligned check of data between centerdauky and person
 - GDPR safe way to get unique user ids



