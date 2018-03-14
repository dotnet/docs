all : server.exe client.exe client2.exe


server.exe : server.cpp common.dll
	cl /clr:pure server.cpp

client.exe : client.cpp common.dll
	cl /clr:pure client.cpp

client2.exe : client2.cpp common.dll
	cl /clr:pure client2.cpp

common.dll : common.cpp
	cl /clr:pure /LD common.cpp

