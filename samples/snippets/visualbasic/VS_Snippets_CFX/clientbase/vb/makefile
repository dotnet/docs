all: ClientBase.dll
 
ClientBase.dll: ClientBase.vb
 vbc /t:library ClientBase.vb /r:System.ServiceModel.dll,System.Runtime.Serialization.dll,System.IdentityModel.dll /lib:c:\whidbey\assemblies
