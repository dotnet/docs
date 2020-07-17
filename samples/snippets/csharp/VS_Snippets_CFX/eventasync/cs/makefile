all: ClientEventAsync.exe

ClientEventAsync.exe: client.cs generatedClient.cs asyncresult.cs
	csc /t:exe /r:system.servicemodel.dll,system.runtime.serialization.dll /lib:c:\whidbey\assemblies generatedClient.cs client.cs asyncresult.cs
