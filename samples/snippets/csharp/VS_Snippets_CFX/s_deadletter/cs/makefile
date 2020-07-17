all: service.exe client.exe dlservice.exe
 
service.exe: service.cs 
 csc /t:exe service.cs  /r:System.dll,System.ServiceModel.dll,System.Runtime.Serialization.dll,System.Configuration.dll,System.Messaging.dll /lib:c:\whidbey\assemblies
 
client.exe: client.cs generatedProxy.cs
 csc /t:exe client.cs generatedProxy.cs /r:System.dll,System.ServiceModel.dll,System.Runtime.Serialization.dll,System.Configuration.dll /lib:c:\whidbey\assemblies

dlservice.exe: dlservice.cs generatedProxy.cs
 csc /t:exe dlservice.cs generatedProxy.cs /r:System.dll,System.ServiceModel.dll,System.Runtime.Serialization.dll /lib:c:\whidbey\assemblies