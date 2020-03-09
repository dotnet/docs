all: ClientSponsor_Server.exe ClientSponsor_Client.exe

ClientSponsor_Server.exe: ClientSponsor_Server.cpp ClientSponsor_Share.dll
	cl /clr:pure ClientSponsor_Server.cpp

ClientSponsor_Client.exe: ClientSponsor_Client.cpp ClientSponsor_Share.dll
	cl /clr:pure ClientSponsor_Client.cpp

ClientSponsor_Share.dll: ClientSponsor_Share.cpp
	cl /LD /clr:pure ClientSponsor_Share.cpp
