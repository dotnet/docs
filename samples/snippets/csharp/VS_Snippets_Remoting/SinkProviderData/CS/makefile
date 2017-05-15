all: SinkProviderData_Client.dll sinkproviderdata_ipfiltersink.dll SinkProviderData_Server.dll SinkProviderData_Share.dll

SinkProviderData_Share.dll: SinkProviderData_Share.cs
	csc /t:library SinkProviderData_Share.cs
SinkProviderData_Client.dll: SinkProviderData_Client.cs SinkProviderData_Share.dll
	csc /t:library SinkProviderData_Client.cs /r:SinkProviderData_Share.dll
sinkproviderdata_ipfiltersink.dll: sinkproviderdata_ipfiltersink.cs SinkProviderData_Share.dll
	csc /t:library sinkproviderdata_ipfiltersink.cs /r:SinkProviderData_Share.dll
SinkProviderData_Server.dll: SinkProviderData_Server.cs SinkProviderData_Share.dll
	csc /t:library SinkProviderData_Server.cs /r:SinkProviderData_Share.dll /r:sinkproviderdata_ipfiltersink.dll
