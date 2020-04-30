all : Client.exe


Client.exe : Client.cpp Service.dll
	cl /clr:pure Client.cpp

Service.dll : Service.cpp
	cl /clr:pure /LD Service.cpp
