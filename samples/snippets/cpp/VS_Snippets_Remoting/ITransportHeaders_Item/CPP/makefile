all: ITransportHeaders_3_Share.dll itransportheaders_3_server.exe

ITransportHeaders_3_Share.dll: ITransportHeaders_3_Share.cs
	csc /t:library ITransportHeaders_3_Share.cs

ITransportHeaders_3_server.exe: itransportheaders_3_server.cpp ITransportHeaders_3_Share.dll
	cl /clr itransportheaders_3_server.cpp
	