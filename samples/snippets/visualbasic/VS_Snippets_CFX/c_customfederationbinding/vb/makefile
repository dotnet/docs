all: c_CustomFederationBinding.exe
 
c_CustomFederationBinding.exe: c_CustomFederationBinding.vb 
 vbc /t:exe *.vb /r:System.ServiceModel.dll,System.Runtime.Serialization.dll,System.IdentityModel.dll /libpath:c:\whidbey\assemblies
