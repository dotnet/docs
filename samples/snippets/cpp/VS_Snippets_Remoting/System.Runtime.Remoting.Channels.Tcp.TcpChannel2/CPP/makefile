all: client.exe server.exe

server.exe: server.cpp common.dll
	cl /clr:pure server.cpp

client.exe: client.cpp common.dll
	cl /clr:pure client.cpp

common.dll: common.cpp
	cl /clr:pure /LD common.cpp
