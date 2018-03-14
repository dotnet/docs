all: Service.dll client.dll
 
Service.dll: service.cs
 csc /t:library service.cs /r:System.ServiceModel.dll /lib:c:\whidbey\assemblies
client.dll: client.cs
 csc /t:library client.cs generatedClient.cs /r:System.ServiceModel.dll /lib:c:\whidbey\assemblies
