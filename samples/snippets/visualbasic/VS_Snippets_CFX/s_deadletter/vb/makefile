all: service.exe client.exe dlservice.exe
 
service.exe: service.vb 
 vbc /t:exe service.vb  /r:System.dll,System.ServiceModel.dll,System.Runtime.Serialization.dll,System.Configuration.dll,System.Messaging.dll /lib:c:\whidbey\assemblies
 
client.exe: client.vb generatedProxy.vb
 vbc /t:exe client.vb generatedProxy.vb /r:System.dll,System.ServiceModel.dll,System.Runtime.Serialization.dll,System.Configuration.dll /lib:c:\whidbey\assemblies

dlservice.exe: dlservice.vb generatedProxy.vb
 vbc /t:exe dlservice.vb generatedProxy.vb /r:System.dll,System.ServiceModel.dll,System.Runtime.Serialization.dll /lib:c:\whidbey\assemblies