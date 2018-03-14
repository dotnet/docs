all: program.exe
 
program.exe: program.cs
 csc /t:exe Program.cs ProxyCode.cs /r:System.ServiceModel.dll,System.Xml.dll,System.dll,System.IdentityModel.dll,System.IdentityModel.Selectors.dll /lib:c:\whidbey\assemblies 

 
