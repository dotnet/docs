all: ClientEventAsync.exe

ClientEventAsync.exe: client.vb generatedClient.vb asyncresult.vb
	vbc /t:exe /r:system.servicemodel.dll,system.runtime.serialization.dll /libpath:c:\whidbey\assemblies generatedClient.vb client.vb asyncresult.vb
