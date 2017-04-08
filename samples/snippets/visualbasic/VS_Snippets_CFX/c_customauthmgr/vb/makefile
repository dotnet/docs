all: c_CustomAuthMgr.exe
 
c_CustomAuthMgr.exe: c_CustomAuthMgr.vb 
 vbc /t:exe *.vb /r:System.ServiceModel.dll,System.Runtime.Serialization.dll,System.IdentityModel.dll /libpath:c:\whidbey\assemblies
