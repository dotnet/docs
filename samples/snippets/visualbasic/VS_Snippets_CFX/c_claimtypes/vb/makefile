all: service.dll
 
service.dll: service.vb 
 vbc /t:library *.vb /r:System.ServiceModel.dll,System.Runtime.Serialization.dll,System.IdentityModel.dll /libpath:c:\whidbey\assemblies
