all: service.exe client.exe
 
service.exe: service.vb serviceSnippets.vb
 vbc /t:exe service.vb serviceSnippets.vb /r:System.ServiceModel.dll /libpath:c:\whidbey\assemblies
 
client.exe: client.vb clientSnippets.vb
 vbc /t:exe client.vb clientSnippets.vb /r:System.ServiceModel.dll  /libpath:c:\whidbey\assemblies
