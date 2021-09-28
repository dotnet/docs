all: Service.dll client.dll
 
Service.dll: service.vb
 vbc /t:library service.vb /r:System.ServiceModel.dll /lib:c:\whidbey\assemblies
client.dll: client.vb generatedClient.vb
 vbc /t:library client.vb generatedClient.vb /r:System.ServiceModel.dll /lib:c:\whidbey\assemblies
