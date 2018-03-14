all: source.exe
 
source.exe: source.vb 
 vbc /t:exe source.vb /r:System.ServiceModel.dll,System.Runtime.Serialization.dll,System.IdentityModel.dll /libpath:c:\whidbey\assemblies
