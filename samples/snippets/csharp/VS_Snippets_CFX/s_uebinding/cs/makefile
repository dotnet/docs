all: service.exe client.exe
 
service.exe: service.cs 
 csc /t:exe service.cs Snippets.cs /r:System.ServiceModel.dll,System.dll /lib:c:\whidbey\assemblies
 
client.exe: client.cs 
 csc /t:exe client.cs Snippets.cs /r:System.ServiceModel.dll,System.dll /lib:c:\whidbey\assemblies
