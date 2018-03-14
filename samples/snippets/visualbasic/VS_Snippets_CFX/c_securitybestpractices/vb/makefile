all: source.dll
 
source.dll: source.vb 
 vbc /t:library source.vb /r:System.ServiceModel.dll,System.Runtime.Serialization.dll /lib:c:\whidbey\assemblies
