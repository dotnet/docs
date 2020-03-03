all: client.exe
 
client.exe: customer.cs httpclient.cs program.cs
 csc /t:exe customer.cs httpclient.cs program.cs /r:System.ServiceModel.dll,System.dll,System.Runtime.Serialization.dll /lib:c:\whidbey\assemblies
