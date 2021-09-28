all: service.exe client.exe
 
service.exe: service.vb hostApp.vb
 vbc /t:exe service.vb hostApp.vb /r:System.ServiceModel.dll,System.Runtime.Serialization.dll /lib:c:\whidbey\assemblies

client.exe: client.vb generatedClient.vb
 vbc /t:exe client.vb generatedClient.vb /r:System.ServiceModel.dll,System.Runtime.Serialization.dll /lib:c:\whidbey\assemblies