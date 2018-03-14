all: source.dll
 
source.dll: source.vb 
 vbc /t:library *.vb /r:System.ServiceModel.dll,System.Runtime.Serialization.dll,System.IdentityModel.dll /lib:c:\whidbey\assemblies
