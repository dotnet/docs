all: source.exe
 
source.exe: source.cs
 csc /t:exe *.cs /r:System.ServiceModel.dll,System.Runtime.Serialization.dll,System.IdentityModel.dll,System.Activities.dll,System.Activities.DurableInstancing.dll,System.ServiceModel.Activities.dll,System.Runtime.DurableInstancing.dll /lib:c:\whidbey\assemblies
