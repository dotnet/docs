all : server.exe client.exe server2.exe


server.exe : server.cpp common.dll
	cl /clr:pure server.cpp

client.exe : client.cpp common.dll
	cl /clr:pure client.cpp

server2.exe : server2.cpp common.dll
	cl /clr:pure server2.cpp

common.dll : common.cpp
	cl /clr:pure /LD common.cpp

