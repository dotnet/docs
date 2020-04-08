all: program.exe

program.exe: service.vb snippets.vb
 vbc /t:exe  service.vb snippets.vb /r:System.ServiceModel.dll /r:System.ServiceModel.Web.dll /libpath:c:\whidbey\assemblies