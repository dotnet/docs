all: service.dll
 
service.dll: service.cs 
 csc /t:library service.cs /r:System.ServiceModel.dll,System.Runtime.Serialization.dll,System.IdentityModel.dll /lib:c:\whidbey\assemblies