all: service.dll
 
service.dll: service.vb 
 vbc /t:library service.vb  /r:System.ServiceModel.dll /libpath:c:\whidbey\assemblies
 
