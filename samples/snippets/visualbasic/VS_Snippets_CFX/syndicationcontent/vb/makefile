all: program.exe

program.exe: module1.vb Snippets.vb
 vbc /t:exe  module1.vb Snippets.vb /r:System.ServiceModel.dll /r:System.ServiceModel.Web.dll /libpath:c:\whidbey\assemblies