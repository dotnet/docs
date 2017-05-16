all: ILease_Server.exe ILease_Client.exe

ILease_Server.exe: ILease_Server.cpp ILease_Share.dll
	cl /clr:pure ILease_Server.cpp

ILease_Client.exe: ILease_Client.cpp ILease_Share.dll
	cl /clr:pure ILease_Client.cpp

ILease_Share.dll: ILease_Share.cpp
	cl /clr:pure /LD ILease_Share.cpp
