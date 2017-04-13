all: service.exe client.exe
 
service.exe: service.cs hostApp.cs
 csc /t:exe service.cs hostApp.cs /r:System.ServiceModel.dll,System.Runtime.Serialization.dll /lib:c:\whidbey\assemblies

client.exe: client.cs generatedClient.cs
 csc /t:exe client.cs generatedClient.cs /r:System.ServiceModel.dll,System.Runtime.Serialization.dll /lib:c:\whidbey\assemblies