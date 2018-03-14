all: MyAuthorizationPolicy.exe
 
MyAuthorizationPolicy.exe: MyAuthorizationPolicy.vb 
 vbc /t:library *.vb /r:System.ServiceModel.dll,System.Runtime.Serialization.dll,system.IdentityModel.dll /libpath:c:\whidbey\assemblies
