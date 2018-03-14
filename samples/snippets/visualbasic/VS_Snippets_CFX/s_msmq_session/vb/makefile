all: service.exe client.exe
 
service.exe: service.vb 
 vbc /t:exe service.vb /r:System.ServiceModel.dll /lib:c:\whidbey\assemblies

client.exe: client.vb OrderTakerService.vb
 vbc /t:exe client.vb OrderTakerService.vb /r:System.ServiceModel.dll /lib:c:\whidbey\assemblies