all: service.exe
 
service.exe: service.vb 
 vbc /t:exe *.vb /r:System.ServiceModel.dll,System.Runtime.Serialization.dll,system.IdentityModel.dll /libpath:c:\whidbey\assemblies
