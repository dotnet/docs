all: program.exe

program.exe: program.vb Snippets.vb ExtensionTypes.vb
 vbc /t:exe  program.vb Snippets.vb ExtensionTypes.vb /r:System.ServiceModel.dll /r:System.ServiceModel.Web.dll