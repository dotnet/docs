all: Order.dll service.exe

Order.dll: order.cs
 csc /t:library order.cs /r:System.ServiceModel.dll /lib:c:\whidbey\assemblies

 
service.exe: service.cs Snippets.cs
 csc /t:exe service.cs Snippets.cs /r:System.ServiceModel.dll /r:Order.dll /lib:c:\whidbey\assemblies
