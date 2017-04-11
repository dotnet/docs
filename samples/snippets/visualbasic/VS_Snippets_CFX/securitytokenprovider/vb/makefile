all: SamlSecurityTokenProvider.exe
 
SamlSecurityTokenProvider.exe: SamlSecurityTokenProvider.vb 
 vbc /t:library *.vb /r:System.ServiceModel.dll,System.Runtime.Serialization.dll,System.IdentityModel.dll,System.Xml.dll /libpath:c:\whidbey\assemblies
