all: secureClient.exe
 
secureClient.exe: secureClient.vb 
 vbc /t:exe *.vb /r:System.ServiceModel.dll,System.Runtime.Serialization.dll /libpath:c:\whidbey\assemblies
