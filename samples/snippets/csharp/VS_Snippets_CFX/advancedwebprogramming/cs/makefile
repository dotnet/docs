all: program.exe

program.exe: customer.cs ICustomerCollection.cs program.cs service.cs snippets.cs 
 csc /t:exe customer.cs ICustomerCollection.cs program.cs service.cs snippets.cs /r:System.ServiceModel.dll /r:System.ServiceModel.Web.dll /r:System.Runtime.Serialization.dll /lib:c:\whidbey\assemblies 

