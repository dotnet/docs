all: Service.exe
 
Service.exe: Service.cs 
 csc /t:exe *.cs /r:System.ServiceModel.dll,System.Runtime.Serialization.dll,System.IdentityModel.dll /lib:c:\whidbey\assemblies
