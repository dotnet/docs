all: service.exe
 
service.exe: service.cs snippets.cs
 csc /t:exe service.cs snippets.cs /r:System.ServiceModel.dll /r:System.Transactions.dll /lib:c:\whidbey\assemblies


