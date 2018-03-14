all: Commontransportkeys.dll CommonTransportKeys_Server.exe CommonTransportKeys_Client.exe

Commontransportkeys.dll: Commontransportkeys.cs
	csc /t:library CommonTransportKeys.cs
CommonTransportKeys_Server.exe: CommonTransportKeys_Server.cs CommonTransportKeys_Share.dll Commontransportkeys.dll
	csc CommonTransportKeys_Server.cs /r:CommonTransportKeys_Share.dll /r:commontransportkeys.dll

CommonTransportKeys_Client.exe: CommonTransportKeys_Client.cs CommonTransportKeys_Share.dll Commontransportkeys.dll
	csc CommonTransportKeys_Client.cs /r:CommonTransportKeys_Share.dll /r:commontransportkeys.dll

CommonTransportKeys_Share.dll: CommonTransportKeys_Share.cs
	csc /t:library CommonTransportKeys_Share.cs
