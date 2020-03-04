all: service.exe client.exe
 
service.exe: service.cs HostApp.cs
 csc /t:exe service.cs HostApp.cs /r:System.ServiceModel.dll,System.Runtime.Serialization.dll /lib:c:\whidbey\assemblies

client.exe: client.cs CalculatorService.cs
 csc /t:exe client.cs CalculatorService.cs /r:System.ServiceModel.dll,System.Runtime.Serialization.dll /lib:c:\whidbey\assemblies