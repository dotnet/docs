all: service.exe
 
service.exe: service.vb snippets.vb
 vbc /t:exe service.vb snippets.vb /r:System.ServiceModel.dll /r:System.Transactions.dll /lib:c:\whidbey\assemblies


