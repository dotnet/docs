all: c_CustomClaim.exe
 
c_CustomClaim.exe: c_CustomClaim.vb 
 vbc /t:exe *.vb /r:System.ServiceModel.dll,System.Runtime.Serialization.dll,System.IdentityModel.dll /libpath:c:\whidbey\assemblies
