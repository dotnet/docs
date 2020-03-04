all: service.exe client.exe
 
service.exe: service.vb 
 vbc /t:exe service.vb /r:System.ServiceModel.dll /libpath:"c:\whidbey\assemblies"
 
client.exe: client.vb CalculatorService.vb
 vbc /t:exe client.vb CalculatorService.vb /r:System.ServiceModel.dll /libpath:"c:\whidbey\assemblies"
