all: service.exe 
 
service.exe: service.vb 
 vbc /t:exe service.vb /r:System.ServiceModel.dll /libpath:"c:\whidbey\assemblies"
 
