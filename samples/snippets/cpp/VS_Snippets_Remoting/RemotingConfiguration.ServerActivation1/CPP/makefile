all: service.dll Client.exe Server.exe

service.dll: service.cpp
	cl /clr:pure /LD service.cpp

Server.exe: Server.cpp
	cl /clr:pure Server.cpp

Client.exe: Client.cpp
	cl /clr:pure Client.cpp
