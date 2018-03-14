all: program.exe

program.exe: program.vb snippets.vb
 vbc /t:exe  program.vb snippets.vb /r:System.ServiceModel.Web.dll /libpath:c:\whidbey\assemblies