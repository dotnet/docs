all: ServiceProgram.exe ClientProgram.exe
 
ServiceProgram.exe: serviceprogram.vb 
 vbc /t:exe serviceprogram.vb /r:System.ServiceModel.dll,System.Runtime.Serialization.dll,System.IdentityModel.dll /lib:c:\whidbey\assemblies

ClientProgram.exe: clientprogram.vb 
 vbc /t:exe clientprogram.vb /r:System.ServiceModel.dll,System.Runtime.Serialization.dll,System.IdentityModel.dll /lib:c:\whidbey\assemblies