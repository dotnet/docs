all: program.exe

program.exe: program.cs snippets.cs ExtensionTypes.cs
 csc /t:exe program.cs snippets.cs ExtensionTypes.cs /r:System.ServiceModel.dll /r:System.ServiceModel.Web.dll /lib:c:\whidbey\assemblies

