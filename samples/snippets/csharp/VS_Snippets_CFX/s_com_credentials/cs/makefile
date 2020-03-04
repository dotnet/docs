all: service.dll client.exe
 
service.dll: service.cs 
 csc /t:exe service.cs /r:System.ServiceModel.dll /lib:c:\whidbey\assemblies
 
client.exe: client.cs generatedClient.cs
 csc /t:exe client.cs generatedClient.cs /r:System.ServiceModel.dll /lib:c:\whidbey\assemblies
