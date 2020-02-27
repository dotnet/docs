all: snippet1.dll snippet2.dll
 
snippet1.dll: snippet1.vb
 vbc /t:library snippet1.vb /r:System.ServiceModel.dll /libpath:"c:\whidbey\assemblies"
 
snippet2.dll: snippet2.vb
 vbc /t:library snippet2.vb /r:System.ServiceModel.dll /libpath:"c:\whidbey\assemblies"
