all : server.exe client.exe


Server.exe : Server.cpp remoteobject.dll
	cl /clr:pure Server.cpp

client.exe : client.cpp remoteobject.dll
	cl /clr:pure client.cpp

remoteobject.dll : remoteobject.cpp
	cl /LD /clr:pure remoteobject.cpp


