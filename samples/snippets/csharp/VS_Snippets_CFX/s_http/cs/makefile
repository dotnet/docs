all: service.exe client.exe
 
service.exe: service.cs 
 csc /t:library service.cs /r:System.ServiceModel.dll,System.dll /lib:c:\whidbey\assemblies
 
client.exe: client.cs CalculatorService.cs
 csc /t:exe client.cs CalculatorService.cs /r:System.ServiceModel.dll,System.dll /lib:c:\whidbey\assemblies
