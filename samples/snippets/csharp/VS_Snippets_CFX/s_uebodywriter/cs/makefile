all: program.exe
 
program.exe: program.cs Snippets.cs
 csc /t:exe program.cs snippets.cs /r:System.ServiceModel.dll,System.Runtime.Serialization.dll,System.Xml.dll /lib:c:\whidbey\assemblies
 