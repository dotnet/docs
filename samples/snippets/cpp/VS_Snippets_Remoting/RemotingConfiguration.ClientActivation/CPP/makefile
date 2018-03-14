all: Service.dll Client.exe Server.exe

Server.exe: Server.cpp
	cl /clr:pure Server.cpp

Client.exe: Client.cpp
	cl /clr:pure Client.cpp

Service.dll: service.cpp
	cl /clr:pure /LD service.cpp
