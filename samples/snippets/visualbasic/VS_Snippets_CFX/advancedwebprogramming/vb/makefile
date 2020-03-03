all: program.exe

program.exe: customer.vb ICustomerCollection.vb program.vb service.vb Snippets.vb 
 vbc /t:exe  customer.vb ICustomerCollection.vb program.vb service.vb Snippets.vb  /r:System.ServiceModel.dll /r:System.ServiceModel.Web.dll /r:System.Runtime.Serialization.dll /libpath:c:/whidbey/assemblies