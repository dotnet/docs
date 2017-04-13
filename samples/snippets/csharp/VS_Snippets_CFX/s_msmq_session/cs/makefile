all: service.exe client.exe
 
service.exe: service.cs 
 csc /t:exe service.cs /r:System.ServiceModel.dll /lib:c:\whidbey\assemblies

client.exe: client.cs OrderTakerService.cs
 csc /t:exe client.cs OrderTakerService.cs /r:System.ServiceModel.dll /lib:c:\whidbey\assemblies