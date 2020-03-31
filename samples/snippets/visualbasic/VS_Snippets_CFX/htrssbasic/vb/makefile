all: program.exe

program.exe: program.vb Snippets.vb
 vbc /t:exe  program.vb Snippets.vb /r:System.ServiceModel.dll /r:System.ServiceModel.Web.dll /libpath:c:\whidbey\assemblies