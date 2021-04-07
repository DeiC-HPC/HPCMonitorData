# Data opsamling bilag til samarbejdsaftalerne i forbindelse med de Danske Nationale HPC anlæg.
Dette notat vil kort beskrive hvilke data som de nationale anlæg skal sende til DeiCs bestyrelse til brug for at følge forbrug af de nationale HPC anlæg. Data er tænkt til at blive brugt af DeiCs bestyrelses, de enkelte universiteter og for HPC sektionen i DeiC.

Dette notat henviser til data formatfiler som kort lister felterne som ønskes opsamlet. Den tekniske beskrivelse findes på https://github.com/DeiC-HPC/HPCMonitorData 

_**Data i form af json filer skal afleveres i en zip fil til HPC-chefen i DeiC.**_ 

Dette notat vil kort beskrive de enkelte felter men der henvises til enhver tid til den tekniske beskrivelse som findes på https://github.com/DeiC-HPC/HPCMonitorData 
Det er bestyrelsen ønske at man kan tilføje flere data felter i takt med at et ønske opstår. Dette gøres i samarbejde. Dette dataset inkludere også at der skal samles data op om brugeren.

DeiC HPC projekt ID er beskrevet på https://www.deic.dk/Supercomputere/Vejledninger-og-guides/Husk-at-referere-til-brug-af-national-HPC.

## Person
Dette data er person centeret Man kan her se hvad personen har haft adgang til og brugt i den periode som er angivet i dataet. Man kan vælge have en antal perioder pr person bare der ikke er overlap mellem person-id, projekt-id og dato perioden. Det vil indeholde følgende felter. Data vil være en liste af disse.
* ORCID ID (fortrækkes hvis forskeren har det) eller WAYF-ID. Et unikt ID.
*	DeiC-HPC Project ID, Dette er et projekt ID. Dette ID skal ses som en gruppe. Det er et unikt ID som f.eks kan deles mellem flere universiteter eller intern i en forsker gruppe.
*	HPC Center ID, hvert national HPC center har et unikt ID.
*	HPC Center Sub ID, Et national center kan have flere afdelinger. For den interne rapport og se fordelingen mellem disse kan man oplyse et under ID.
*	Universitet ID, hvert universitet har et ID.
*	Id Expanded, Hvis man ikke er fra et universitet eller login ikke giver mulighed for at få uni id. Dette felt kan bruges som tekst.
*	Assing Type, Valgmuligheder: Local, national, sandbox, international, andet.
*	Access start date, dato for hvornår denne bruger har fået adgang. I ISO 8601 format.
*	Access end date, dato for hvornår denne bruger ikke har adgang mere. I ISO 8601 format.
*	CPU core time assigned
*	CPU core time used
*	GPU core time assigned
*	GPU core time used
*	Storage assigned
*	Storage used.
*	Node time assigned, bruges f.eks på type 4 hvor man har en hel knude og ikke som sådan CPU/GPU core tid.
*	Node time used.
## Center – last period
Dette bliver brugt til at se den totale tid i perioden. Det er for at kunne match nede tid og der evt. er et mål for dette. Data vil være en liste af disse.
*	HPC Center ID, hvert national HPC center har et unikt ID
*	HPC Center Sub ID, Et national center kan have flere afdelinger. For den interne rapport og se fordelingen mellem disse kan man oplyse et under ID.
*	Start periode, ISO 8601 for hvornår tal gælder fra (inkl.)
*	End periode, ISO 8601 for hvornår tal gælder til (inkl.)
*	Max CPU core time. Hvor mange CPU core timer kan anlægget tilbyde
*	Actual CPU core time, Hvor mange CPU core timer blev tilbudt.
*	Max GPU core time, Hvor mange GPU timer kan anlægget tilbyde
*	Actual CPU core time, Hvor mange GPU timer kunne bruges.
*	Storage usage, hvor meget storage er brugt i perioden. I GB
*	Network usage, hvor meget netværk data er flyttet i perioden. I GB
*	Network trafic, avg network trafik. I Mbps/Gbps.
*	Max Node time, for type 4 vi burger hele knuder.
*	Actual node time, for type 4


## Center Daily
Dette er en log linje pr dag pr center. Man kan følge brugen af et center pr dag. Dette er for at kunne se den daglige brug af centeret hen over hver dag. Data vil være en liste af disse.
*	HPC Center ID, hvert national HPC center har et unikt ID
*	HPC Center Sub ID, Et national center kan have flere afdelinger. For den interne rapport og se fordelingen mellem disse kan man oplyse et under ID. 
*	Date, ISO 8601.
*	Max CPU core time. Hvor mange CPU core timer kan anlægget tilbyde for denne dag
*	Actual used CPU core time, Hvor mange CPU core timer blev brugt.
*	Max GPU core time, Hvor mange GPU timer kan anlægget tilbyde
*	Actual used CPU core time, Hvor mange GPU timer blev brugt.
*	Storage usage, hvor meget storage er brugt. I GB
*	Network usage, hvor meget netværk data er flyttet. I GB
*	Network trafic, avg network trafik. I Mbps/Gbps.
*	Max Node time, for type 4 vi burger hele knuder.
*	Actual used node time, for type 4 blev brugt.
*	Universitet ID, hvert universitet har et ID.
*	Id Expanded, Hvis man ikke er fra et universitet eller login ikke giver mulighed for at få uni id. Dette felt kan bruges som tekst.
*	ORCID ID (fortrækkes hvis forskeren har det) eller WAYF-ID. Et unikt ID.
*	DeiC-HPC Project ID, Dette er et projekt ID. Dette ID skal ses som en gruppe. Det er et unikt ID som f.eks kan deles mellem flere universiteter eller intern i en forsker gruppe.


## Værktøj og kode
Der vil på https://github.com/DeiC-HPC/HPCMonitorData blive udviklet et sæt af tools til at tjekke data filerne før man sender dem. Det er også muligt at dele tools med som tænkes kan bruges mellem flere center. Licens for kode er EUPL. Udvikling af værktøjer til brug ligger i back-office.
## Json format
Datastrukturen skal leveres i json format, Formatet er beskrevet på https://github.com/DeiC-HPC/HPCMonitorData . Strukturen ændres ikke før det i back-office er blevet besluttet og vil til enhver tid først komme til effekt efter enighed i back-office. 

