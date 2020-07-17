all: ServiceProgram.exe ClientProgram.exe
 
ServiceProgram.exe: serviceprogram.cs 
 csc /t:exe serviceprogram.cs /r:System.ServiceModel.dll,System.Runtime.Serialization.dll,System.IdentityModel.dll /lib:c:\whidbey\assemblies

ClientProgram.exe: clientprogram.cs 
 csc /t:exe clientprogram.cs /r:System.ServiceModel.dll,System.Runtime.Serialization.dll,System.IdentityModel.dll /lib:c:\whidbey\assemblies