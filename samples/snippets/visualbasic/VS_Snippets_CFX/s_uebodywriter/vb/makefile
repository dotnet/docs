all: Module1.exe
 
Module1.exe: Module1.vb Snippets.vb
 vbc /t:exe Module1.vb snippets.vb /r:System.ServiceModel.dll,System.Runtime.Serialization.dll,System.Xml.dll /lib:c:\whidbey\assemblies
 