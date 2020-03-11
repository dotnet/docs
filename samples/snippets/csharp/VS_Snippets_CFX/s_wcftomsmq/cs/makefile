all: service.exe client.exe order.dll
 
order.dll: order.cs
 csc /t:library order.cs /r:System.ServiceModel.dll /lib:c:\whidbey\assemblies

service.exe: service.cs order.dll
 csc /t:exe service.cs /r:System.Messaging.dll,System.configuration.dll,order.dll,System.dll,System.Transactions.dll /lib:c:\whidbey\assemblies

client.exe: client.cs  order.dll
 csc /t:exe client.cs Snippets.cs Proxy.cs /r:System.ServiceModel.dll,order.dll,System.dll,System.Transactions.dll /lib:c:\whidbey\assemblies