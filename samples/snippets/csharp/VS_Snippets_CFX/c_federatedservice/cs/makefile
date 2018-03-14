all: source.dll
 
source.dll: source.cs 
 csc /t:library *.cs /r:System.ServiceModel.dll,System.Runtime.Serialization.dll,System.IdentityModel.dll /lib:c:\whidbey\assemblies
