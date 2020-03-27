all: service.exe

service.exe: service.cs snippets.cs
 csc /t:exe service.cs snippets.cs /r:System.ServiceModel.dll /r:System.ServiceModel.Web.dll /r:System.Runtime.Serialization.dll /lib:c:\whidbey\assemblies

