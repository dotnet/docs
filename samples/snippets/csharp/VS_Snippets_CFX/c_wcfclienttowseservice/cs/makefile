all: client.exe
 
client.exe: client.cs generatedClient.cs WSEHttpBinding.dll 
 csc /t:exe *.cs /r:System.ServiceModel.dll,System.Runtime.Serialization.dll,System.IdentityModel.dll /lib:c:\whidbey\assemblies

WSEHttpBinding.dll: WSEHttpBinding.cs wseSecurityAssertion.cs
 csc /t:library /out:WseHttpBinding.dll wse*.cs  /r:System.ServiceModel.dll,System.Runtime.Serialization.dll,system.IdentityModel.dll /lib:c:\whidbey\assemblies
