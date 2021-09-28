all: service.exe
 
service.exe: service.cs 
 csc /t:exe service.cs /r:System.ServiceModel.dll,System.Runtime.Serialization.dll,System.IdentityModel.dll,System.Configuration.Install.dll,System.ServiceProcess.dll /lib:c:\whidbey\assemblies