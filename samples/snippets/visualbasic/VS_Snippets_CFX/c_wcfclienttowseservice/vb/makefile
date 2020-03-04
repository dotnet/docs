all:client.exe
 
client.exe: client.vb generatedClient.vb WSEHttpBinding.dll
 vbc /t:exe *.vb /r:System.ServiceModel.dll,System.Runtime.Serialization.dll,system.IdentityModel.dll /libpath:c:\whidbey\assemblies

WSEHttpBinding.dll: WSEHttpBinding.vb wseSecurityAssertion.vb
 vbc /t:library /out:WseHttpBinding.dll wse*.vb /r:System.ServiceModel.dll,System.Runtime.Serialization.dll,system.IdentityModel.dll /libpath:c:\whidbey\assemblies
