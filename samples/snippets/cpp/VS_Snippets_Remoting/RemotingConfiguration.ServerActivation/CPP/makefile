all : server.dll client.exe

server.dll : server.cpp
	cl /LD /clr:pure server.cpp

client.exe : client.cpp server.dll
	cl /clr:pure client.cpp