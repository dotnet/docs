all: service.exe
 
service.exe: service.vb 
 vbc /t:exe service.vb /r:System.ServiceModel.dll,System.Runtime.Serialization.dll,System.IdentityModel.dll,System.Configuration.Install.dll,System.ServiceProcess.dll /lib:c:\whidbey\assemblies