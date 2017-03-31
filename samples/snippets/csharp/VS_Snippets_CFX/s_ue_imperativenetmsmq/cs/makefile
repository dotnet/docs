all: service.exe

 
service.exe: service.cs Snippets.cs
 csc /t:exe service.cs Snippets.cs /r:System.ServiceModel.dll /lib:c:\whidbey\assemblies
