all: service.exe 
 
service.exe: service.vb 
 vbc /t:library service.vb /r:System.ServiceModel.dll,System.dll,System.Runtime.Serialization.dll /lib:c:\whidbey\assemblies
 
