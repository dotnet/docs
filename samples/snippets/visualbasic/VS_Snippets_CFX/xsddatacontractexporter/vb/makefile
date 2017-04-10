all: overview.exe

overview.exe: overview.vb 
 vbc /t:exe /r:System.ServiceModel.dll,System.Runtime.Serialization.dll /libpath:c:\whidbey\assemblies *.vb 