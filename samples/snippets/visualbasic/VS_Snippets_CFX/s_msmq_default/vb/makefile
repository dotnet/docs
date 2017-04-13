all: service.exe client.exe
 
service.exe: service.vb HostApp.vb
 vbc /t:exe service.vb HostApp.vb /r:System.ServiceModel.dll,System.Runtime.Serialization.dll /lib:c:\whidbey\assemblies

client.exe: client.vb CalculatorService.vb
 vbc /t:exe client.vb CalculatorService.vb /r:System.ServiceModel.dll,System.Runtime.Serialization.dll /lib:c:\whidbey\assemblies