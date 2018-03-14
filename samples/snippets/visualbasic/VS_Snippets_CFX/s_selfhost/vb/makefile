all: service.dll client.exe contract.dll Enchilada.exe
 
service.dll: service.vb 
 vbc /t:library service.vb /r:System.ServiceModel.dll /libpath:"c:\Whidbey\Assemblies"
 
client.exe: client.vb CalculatorService.vb
 vbc /t:exe client.vb CalculatorService.vb /r:System.ServiceModel.dll /libpath:"c:\Whidbey\Assemblies"

contract.dll: contract.vb
 vbc /t:library contract.vb /r:System.ServiceModel.dll /libpath:"c:\Whidbey\Assemblies"

Enchilada.exe: WholeEnchilada.vb
 vbc /t:exe WholeEnchilada.vb /r:System.ServiceModel.dll /libpath:"c:\Whidbey\Assemblies"