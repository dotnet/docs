all: ClientSponsor_Server.exe ClientSponsor_Client.exe

ClientSponsor_Server.exe: ClientSponsor_Server.vb ClientSponsor_Share.dll
	vbc ClientSponsor_Server.vb /r:ClientSponsor_Share.dll

ClientSponsor_Client.exe: ClientSponsor_Client.vb ClientSponsor_Share.dll
	vbc ClientSponsor_Client.vb /r:ClientSponsor_Share.dll

ClientSponsor_Share.dll: ClientSponsor_Share.vb
	vbc /t:library ClientSponsor_Share.vb
