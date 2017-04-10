all: service.exe client.exe pmservice.exe
 
pmservice.exe: pmservice.cs
 csc /t:exe pmservice.cs /r:System.ServiceModel.dll,System.Runtime.Serialization.dll /lib:c:\whidbey\assemblies

service.exe: service.cs PoisonBehaviorAttribute.cs PoisonErrorHandler.cs HostApp.cs
 csc /t:exe service.cs PoisonBehaviorAttribute.cs PoisonErrorHandler.cs HostApp.cs /r:System.ServiceModel.dll,System.Runtime.Serialization.dll /lib:c:\whidbey\assemblies

client.exe: client.cs generatedProxy.cs 
 csc /t:exe client.cs generatedProxy.cs /r:System.ServiceModel.dll,System.Runtime.Serialization.dll /lib:c:\whidbey\assemblies