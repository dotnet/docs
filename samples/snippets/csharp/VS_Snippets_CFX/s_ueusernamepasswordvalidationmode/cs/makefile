all: service.exe
 
service.exe: service.cs 
 csc /t:exe service.cs /r:System.ServiceModel.dll,System.IdentityModel.dll,System.Runtime.Serialization.dll /lib:c:\whidbey\assemblies
