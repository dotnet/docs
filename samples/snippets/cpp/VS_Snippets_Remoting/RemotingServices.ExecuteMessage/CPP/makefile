all : server.exe client.exe


server.exe : server.cpp serviceclass.dll
	cl /clr:pure server.cpp

client.exe : client.cpp serviceclass.dll
	cl /clr:pure client.cpp

serviceclass.dll : serviceclass.cpp
	cl /clr:pure /LD serviceclass.cpp

