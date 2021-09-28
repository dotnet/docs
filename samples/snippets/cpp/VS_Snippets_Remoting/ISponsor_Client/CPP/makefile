all: isponsor_client.exe isponsor_server.exe

isponsor_client.exe: isponsor_client.cpp remotetype.dll
	cl /clr:pure isponsor_client.cpp

isponsor_server.exe: isponsor_server.cpp remotetype.dll
	cl /clr:pure isponsor_server.cpp

remotetype.dll: remotetype.cpp
	cl /clr:pure /LD remotetype.cpp
