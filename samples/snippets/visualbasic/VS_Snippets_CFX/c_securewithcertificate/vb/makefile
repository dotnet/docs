all: source.exe
 
source.exe: source.vb 
 vbc /t:exe *.vb /r:System.ServiceModel.dll,System.Runtime.Serialization.dll,System.IdentityModel.dll /lib:c:\whidbey\assemblies
