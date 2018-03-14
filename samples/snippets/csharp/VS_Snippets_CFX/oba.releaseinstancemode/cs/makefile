all: HostApplication.dll Client.dll
 
HostApplication.dll: HostApplication.cs services.cs 
 csc /t:library HostApplication.cs Services.cs /r:System.ServiceModel.dll,System.Runtime.Serialization.dll,System.IdentityModel.dll /lib:c:\whidbey\assemblies

Client.dll: Client.cs ProxyCode.cs 
 csc /t:library client.cs ProxyCode.cs /r:System.ServiceModel.dll,System.Runtime.Serialization.dll,System.IdentityModel.dll /lib:c:\whidbey\assemblies
