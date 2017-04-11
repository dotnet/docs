all: SamlSecurityTokenProvider.dll
 
SamlSecurityTokenProvider.dll: MyTokenAuthenticator.cs 
 csc /t:library *.cs /r:System.ServiceModel.dll,System.Runtime.Serialization.dll,System.IdentityModel.dll,System.Xml.dll /lib:c:\whidbey\assemblies
