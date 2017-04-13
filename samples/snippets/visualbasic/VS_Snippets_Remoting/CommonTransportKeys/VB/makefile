all: Commontransportkeys.dll CommonTransportKeys_Server.exe CommonTransportKeys_Client.exe

Commontransportkeys.dll: Commontransportkeys.vb
	vbc /t:library CommonTransportKeys.vb
CommonTransportKeys_Server.exe: CommonTransportKeys_Server.vb CommonTransportKeys_Share.dll Commontransportkeys.dll
	vbc CommonTransportKeys_Server.vb /r:CommonTransportKeys_Share.dll /r:commontransportkeys.dll

CommonTransportKeys_Client.exe: CommonTransportKeys_Client.vb CommonTransportKeys_Share.dll Commontransportkeys.dll
	vbc CommonTransportKeys_Client.vb /r:CommonTransportKeys_Share.dll /r:commontransportkeys.dll

CommonTransportKeys_Share.dll: CommonTransportKeys_Share.vb
	vbc /t:library CommonTransportKeys_Share.vb
