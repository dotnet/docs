all: client.exe server.exe

server.exe: server.cpp service.dll
	cl /clr:pure server.cpp

client.exe: client.cpp service.dll
	cl /clr:pure client.cpp

service.dll: service.cpp
	cl /clr:pure /LD service.cpp
