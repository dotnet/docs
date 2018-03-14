all: service.exe client.exe order.dll
 
order.dll: order.cs
 csc /t:library order.cs /r:System.ServiceModel.dll /lib:c:\whidbey\assemblies

service.exe: service.cs order.dll
 csc /t:library service.cs  /r:System.ServiceModel.dll,System.Runtime.Serialization.dll,System.Messaging.dll,System.configuration.dll,System.dll,order.dll /lib:c:\whidbey\assemblies

client.exe: client.cs order.dll
 csc /t:exe client.cs /r:System.ServiceModel.dll,order.dll,System.Messaging.dll,System.Transactions.dll,System.dll,System.Configuration.dll /lib:c:\whidbey\assemblies