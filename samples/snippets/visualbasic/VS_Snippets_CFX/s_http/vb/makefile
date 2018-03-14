all: service.exe client.exe
 
service.exe: service.vb 
 vbc /t:library service.vb /r:System.ServiceModel.dll,System.dll /lib:c:\whidbey\assemblies
 
client.exe: client.vb CalculatorService.vb
 vbc /t:exe client.vb CalculatorService.vb /r:System.ServiceModel.dll,System.dll /lib:c:\whidbey\assemblies
