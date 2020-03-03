all: client.exe
 
client.exe: customer.vb httpclient.vb Module1.vb
 vbc /t:exe customer.vb httpclient.vb Module1.vb /r:System.ServiceModel.dll,System.dll,System.Runtime.Serialization.dll /lib:c:\whidbey\assemblies
