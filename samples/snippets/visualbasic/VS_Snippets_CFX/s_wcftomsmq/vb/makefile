all: Order.dll service.exe client.exe

order.dll: order.vb
 vbc /t:library  order.vb /r:System.ServiceModel.dll /libpath:c:\whidbey\assemblies

service.exe: service.vb order.dll
 vbc /t:exe service.vb  /r:System.ServiceModel.dll,System.Runtime.Serialization.dll,System.Messaging.dll,System.configuration.dll,System.dll,order.dll /libpath:c:\whidbey\assemblies

client.exe: client.vb proxy.vb snippets.vb order.dll
 vbc /t:exe client.vb proxy.vb snippets.vb /r:System.ServiceModel.dll,order.dll,System.Messaging.dll,System.Transactions.dll,System.dll,System.Configuration.dll /libpath:c:\whidbey\assemblies