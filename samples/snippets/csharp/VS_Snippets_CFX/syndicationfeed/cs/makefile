all: program.exe

program.exe: program.cs mysyndicationfeed.cs
 csc /t:exe program.cs mysyndicationfeed.cs /r:System.ServiceModel.dll /r:System.ServiceModel.Web.dll /r:System.Runtime.Serialization.dll /lib:c:\whidbey\assemblies

