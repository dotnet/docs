all: service.exe 
 
service.exe: service.cs 
 csc /t:library service.cs /r:System.ServiceModel.dll,System.dll,System.Runtime.Serialization.dll /lib:c:\whidbey\assemblies
 
