all: snippets.dll
 
snippets.dll: snippets.cs 
 csc /t:library *.cs /r:System.WorkflowServices.dll,System.ServiceModel.dll,System.dll,system.workflow.componentmodel.dll /lib:c:\whidbey\assemblies
