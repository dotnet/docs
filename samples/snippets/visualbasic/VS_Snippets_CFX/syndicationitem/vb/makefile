all: program.exe

program.exe: program.vb MySyndicationItem.vb Snippets.vb
 vbc /t:exe  program.vb MySyndicationItem.vb Snippets.vb /r:System.ServiceModel.dll /r:System.ServiceModel.Web.dll /r:System.Runtime.Serialization.dll /libpath:c:\whidbey\assemblies