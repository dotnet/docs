all: service.exe client.exe
 
service.exe: service.cs Snippets.cs
 csc /t:exe service.cs Snippets.cs /r:System.ServiceModel.dll /lib:c:\whidbey\assemblies
 
client.exe: client.cs CalculatorService.cs
 csc /t:exe client.cs CalculatorService.cs /r:System.ServiceModel.dll /lib:c:\whidbey\assemblies
