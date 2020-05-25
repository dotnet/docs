all: service.dll client.exe
 
service.dll: service.cs 
 csc /t:library service.cs  /r:System.ServiceModel.dll /lib:c:\whidbey\assemblies
 
client.exe: client.cs generatedProxy.cs
 csc /t:exe client.cs generatedProxy.cs /r:System.ServiceModel.dll /lib:c:\whidbey\assemblies
