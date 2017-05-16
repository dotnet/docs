all: service.dll
 
service.dll: service.cs 
 csc /t:library Service.cs /r:System.ServiceModel.dll,System.Runtime.Serialization.dll,System.IdentityModel.dll /lib:c:\whidbey\assemblies

