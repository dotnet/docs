all: service.exe 
 
service.exe: MessageBasedCustomerService.vb Customer.vb IUniversalContract.vb 
 vbc /t:library MessageBasedCustomerService.vb Customer.vb IUniversalContract.vb /r:System.ServiceModel.dll,System.dll,System.Runtime.Serialization.dll /lib:c:\whidbey\assemblies
 
