all: service.exe client.exe
 
service.exe: service.vb serviceSnippets.vb
 vbc /t:exe service.vb serviceSnippets.vb /r:System.ServiceModel.dll /lib:c:\whidbey\assemblies
client.exe: client.vb 
 vbc /t:exe client.vb /r:System.ServiceModel.dll /lib:c:\whidbey\assemblies