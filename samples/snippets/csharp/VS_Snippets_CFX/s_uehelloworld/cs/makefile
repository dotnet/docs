all: service.exe client.exe
 
service.exe: service.cs snippet.cs
 csc /t:exe service.cs snippet.cs /r:System.ServiceModel.dll,System.Runtime.Serialization.dll /lib:c:\whidbey\assemblies
 
client.exe: client.cs HelloService.cs
 csc /t:exe client.cs HelloService.cs /r:System.ServiceModel.dll,System.Runtime.Serialization.dll /lib:c:\whidbey\assemblies
