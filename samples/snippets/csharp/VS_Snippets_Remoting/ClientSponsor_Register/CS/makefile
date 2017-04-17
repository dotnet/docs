all: ClientSponsor_Server.exe ClientSponsor_Client.exe

ClientSponsor_Server.exe: ClientSponsor_Server.cs ClientSponsor_Share.dll
	csc ClientSponsor_Server.cs /r:ClientSponsor_Share.dll

ClientSponsor_Client.exe: ClientSponsor_Client.cs ClientSponsor_Share.dll
	csc ClientSponsor_Client.cs /r:ClientSponsor_Share.dll

ClientSponsor_Share.dll: ClientSponsor_Share.cs
	csc /t:library ClientSponsor_Share.cs
