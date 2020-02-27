all: service.exe 
 
service.exe: MessageBasedCustomerService.cs Customer.cs IUniversalContract.cs 
 csc /t:library MessageBasedCustomerService.cs Customer.cs IUniversalContract.cs /r:System.ServiceModel.dll,System.dll,System.Runtime.Serialization.dll /lib:c:\whidbey\assemblies
 
