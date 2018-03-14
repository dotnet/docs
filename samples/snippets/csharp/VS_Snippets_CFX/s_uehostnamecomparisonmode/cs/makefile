all: service.exe client.exe
 
service.exe: service.cs host.cs
 csc /t:exe service.cs host.cs /r:System.ServiceModel.dll /lib:c:\whidbey\assemblies
 
client.exe: client.cs Snippets.cs HelloService.cs
 csc /t:exe client.cs Snippets.cs HelloService.cs /r:System.ServiceModel.dll /lib:c:\whidbey\assemblies
