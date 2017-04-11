all: source.dll

source.dll: proxycode.vb client.vb
 vbc /t:library /r:System.ServiceModel.dll,System.Runtime.Serialization.dll,System.IdentityModel.dll /libpath:c:\whidbey\assemblies *.vb 

