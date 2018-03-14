all: program.dll
 
program.dll: program.vb 
 vbc /t:library program.vb /r:System.ServiceModel.dll,System.Runtime.Serialization.dll /lib:c:\whidbey\assemblies
