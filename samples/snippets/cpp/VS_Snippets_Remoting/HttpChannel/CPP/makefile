all : client.exe client2.exe server.exe server2.exe


client.exe : client.cpp service.dll
	cl /clr:pure client.cpp

client2.exe : client2.cpp service.dll
	cl /clr:pure client.cpp

server.exe : server.cpp service.dll
	cl /clr:pure server.cpp

server2.exe : server2.cpp service.dll
	cl /clr:pure server2.cpp

service.dll : service.cpp
	cl /LD /clr:pure service.cpp


