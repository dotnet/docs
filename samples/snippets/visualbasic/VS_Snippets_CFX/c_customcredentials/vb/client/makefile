all: client.exe 
 
client.exe: client.vb 
 vbc /t:exe /r:System.ServiceModel.dll,System.Runtime.Serialization.dll,System.IdentityModel.dll /libpath:c:\orcas\assemblies *.vb 