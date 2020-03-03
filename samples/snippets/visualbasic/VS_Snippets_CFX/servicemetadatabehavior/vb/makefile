all: vb.dll
 
vb.dll: HostApplication.vb services.vb
 vbc /t:library HostApplication.vb Services.vb /r:system.ServiceModel.dll,System.Runtime.Serialization.dll /libpath:c:\whidbey\assemblies
