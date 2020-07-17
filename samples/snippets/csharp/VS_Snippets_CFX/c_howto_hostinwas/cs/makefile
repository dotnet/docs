all: service.exe client.exe
 
service.exe: service.cs 
 csc /t:exe service.cs /r:System.ServiceModel.dll,System.Runtime.Serialization.dll,System.IdentityModel.dll /lib:c:\whidbey\assemblies

client.exe: client.cs 
 csc /t:exe client.cs /r:System.ServiceModel.dll,System.Runtime.Serialization.dll,System.IdentityModel.dll /lib:c:\whidbey\assemblies