all: service.dll client.exe contract.dll Enchilada.exe
 
service.dll: service.cs 
 csc /t:library service.cs /r:System.dll,System.ServiceModel.dll /lib:c:\whidbey\assemblies
 
client.exe: client.cs CalculatorService.cs
 csc /t:exe client.cs CalculatorService.cs /r:System.dll,System.ServiceModel.dll /lib:c:\whidbey\assemblies

contract.dll: contract.cs
 csc /t:library contract.cs /r:System.dll,System.ServiceModel.dll /lib:c:\whidbey\assemblies

Enchilada.exe: WholeEnchilada.cs
 csc /t:exe WholeEnchilada.cs /r:System.dll,System.ServiceModel.dll /lib:c:\whidbey\assemblies
