all : server.exe client.exe

server.exe : server.cpp service.dll
	cl /clr:pure server.cpp

client.exe : client.cpp service.dll
	cl /clr:pure client.cpp

service.dll : service.cpp
	cl /LD /clr:pure service.cpp
