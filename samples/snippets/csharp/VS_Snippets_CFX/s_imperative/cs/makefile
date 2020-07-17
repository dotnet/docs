all: service.exe client.exe
 
service.exe: service.cs serviceSnippets.cs
 csc /t:exe service.cs serviceSnippets.cs /r:System.ServiceModel.dll /lib:c:\whidbey\assemblies
client.exe: client.cs 
 csc /t:exe client.cs /r:System.ServiceModel.dll /lib:c:\whidbey\assemblies