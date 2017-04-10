all: snippet1.dll snippet2.dll
 
snippet1.dll: snippet1.cs 
 csc /t:library snippet1.cs /r:System.ServiceModel.dll /lib:c:\whidbey\assemblies
 
snippet2.dll: snippet2.cs
 csc /t:library snippet2.cs /r:System.ServiceModel.dll /lib:c:\whidbey\assemblies
