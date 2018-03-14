
all: basicserver.exe basicclient.exe manualserver.exe manualclient.exe

basicserver.exe: basicserver.cpp service.dll
	cl /clr:pure basicserver.cpp

basicclient.exe: basicclient.cpp service.dll
	cl /clr:pure basicclient.cpp

manualserver.exe: manualserver.cpp service.dll
	cl /clr:pure manualserver.cpp

manualclient.exe: manualclient.cpp service.dll
	cl /clr:pure manualclient.cpp

service.dll: service.cpp
	cl /clr:pure /LD service.cpp
