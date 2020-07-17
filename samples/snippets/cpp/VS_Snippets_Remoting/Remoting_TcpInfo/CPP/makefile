all: Remotable.dll Server.exe Client.exe
Remotable.dll: Remotable.cpp
	cl /clr:pure /LD Remotable.cpp
Server.exe: Server.cpp Remotable.dll
	cl /clr:pure Server.cpp
Client.exe: Client.cpp Remotable.dll
	cl /clr:pure Client.cpp
