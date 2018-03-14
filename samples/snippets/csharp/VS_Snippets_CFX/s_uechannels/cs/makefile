all: service.exe client.exe
 
service.exe: service.cs serviceSnippets.cs
 csc /t:exe service.cs serviceSnippets.cs /r:System.dll,System.ServiceModel.dll,System.Runtime.Serialization.dll /lib:c:\whidbey\assemblies
 
client.exe: client.cs clientSnippets.cs
 csc /t:exe client.cs clientSnippets.cs /r:System.dll,System.ServiceModel.dll,System.Runtime.Serialization.dll /lib:c:\whidbey\assemblies
