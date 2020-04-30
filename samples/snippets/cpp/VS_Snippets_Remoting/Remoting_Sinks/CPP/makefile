# Comment here
all: Server.exe Client.exe
Remotable.dll: Remotable.cpp
	cl /clr:pure /LD Remotable.cpp
ServerSink.dll: ServerSink.cpp
	cl /clr:pure /LD ServerSink.cpp
Server.exe: Server.cpp Remotable.dll ServerSink.dll
	cl /clr:pure Server.cpp
ClientSink.dll: ClientSink.cpp
	cl /clr:pure /LD ClientSink.cpp
Client.exe: Client.cpp ClientSink.dll Remotable.dll
	cl /clr:pure Client.cpp
