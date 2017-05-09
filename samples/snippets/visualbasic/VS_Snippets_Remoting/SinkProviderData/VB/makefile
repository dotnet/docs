all: SinkProviderData_Client.dll sinkproviderdata_ipfiltersink.dll SinkProviderData_Server.dll SinkProviderData_Share.dll

SinkProviderData_Share.dll: SinkProviderData_Share.vb
	vbc /t:library SinkProviderData_Share.vb
SinkProviderData_Client.dll: SinkProviderData_Client.vb SinkProviderData_Share.dll
	vbc /t:library SinkProviderData_Client.vb /r:SinkProviderData_Share.dll
sinkproviderdata_ipfiltersink.dll: sinkproviderdata_ipfiltersink.vb SinkProviderData_Share.dll
	vbc /t:library sinkproviderdata_ipfiltersink.vb /r:SinkProviderData_Share.dll
SinkProviderData_Server.dll: SinkProviderData_Server.vb SinkProviderData_Share.dll
	vbc /t:library SinkProviderData_Server.vb /r:SinkProviderData_Share.dll /r:sinkproviderdata_ipfiltersink.dll
