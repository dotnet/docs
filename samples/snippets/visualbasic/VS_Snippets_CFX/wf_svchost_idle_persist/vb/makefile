all: source.exe

source.exe: source.vb 
 vbc /t:exe /r:System.ServiceModel.dll,System.Runtime.Serialization.dll,System.IdentityModel.dll,System.Activities.dll,System.Activities.DurableInstancing.dll,System.ServiceModel.Activities.dll,System.Runtime.DurableInstancing.dll /libpath:c:\whidbey\assemblies *.vb 

