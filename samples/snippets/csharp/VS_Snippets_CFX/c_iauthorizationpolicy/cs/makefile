all: service.exe
 
service.exe: service.cs 
 csc /t:exe *.cs /r:System.ServiceModel.dll,System.Runtime.Serialization.dll,System.IdentityModel.dll /lib:c:\whidbey\assemblies
