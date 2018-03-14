all: service.dll client.exe
 
service.dll: service.vb 
 vbc /t:library service.vb /r:System.ServiceModel.dll /libpath:"c:\Whidbey\assemblies"
 
client.exe: client.vb CalculatorService.vb
 vbc /t:exe client.vb CalculatorService.vb /r:System.ServiceModel.dll /libpath:"c:\Whidbey\assemblies"
