all: service.exe client.exe
 
service.exe: service.cs 
 csc /t:exe service.cs snippets.cs /r:System.ServiceModel.dll,System.dll,System.Xml.dll /lib:c:\whidbey\assemblies
 
client.exe: client.cs 
 csc /t:exe client.cs /r:System.dll,System.Xml.dll,System.ServiceModel.dll,System.Configuration.dll,System.Runtime.Serialization.dll,System.Messaging.dll,System.Transactions.dll /lib:c:\whidbey\assemblies
