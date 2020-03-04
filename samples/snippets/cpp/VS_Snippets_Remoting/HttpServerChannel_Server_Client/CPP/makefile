
all: HttpServerChannel_Client.exe HttpServerChannel_Server.exe

HttpServerChannel_Client.exe: HttpClientChannel_6_Client.cpp HttpServerChannel_Share.dll
	cl /clr:pure HttpClientChannel_6_Client.cpp

HttpServerChannel_Server.exe: HttpServerChannel_9_Server.cpp HttpServerChannel_Share.dll
	cl /clr:pure HttpServerChannel_9_Server.cpp

HttpServerChannel_Share.dll: HttpServerChannel_Clientl_14_Share.cpp
	cl /clr:pure /LD HttpServerChannel_Clientl_14_Share.cpp
