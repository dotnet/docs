all: service.dll
 
service.dll: service.vb 
 vbc /t:library Service.vb /r:System.ServiceModel.dll,System.Runtime.Serialization.dll,System.IdentityModel.dll /lib:c:\whidbey\assemblies

