all: service.dll client.exe
 
service.dll: service.vb 
 vbc /t:exe service.vb /r:System.ServiceModel.dll /lib:c:\whidbey\assemblies
 
client.exe: client.vb generatedClient.vb
 vbc /t:exe client.vb generatedClient.vb /r:System.ServiceModel.dll /lib:c:\whidbey\assemblies
