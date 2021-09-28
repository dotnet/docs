all : activatedclienttypeentry_server.exe activatedclienttypeentry_client.exe


activatedclienttypeentry_server.exe : activatedclienttypeentry_server.cpp activatedclienttypeentry_share.dll
	cl /clr:pure activatedclienttypeentry_server.cpp

activatedclienttypeentry_client.exe : activatedclienttypeentry_client.cpp activatedclienttypeentry_share.dll
	cl /clr:pure activatedclienttypeentry_client.cpp

activatedclienttypeentry_share.dll : activatedclienttypeentry_share.cpp
	cl /LD /clr:pure activatedclienttypeentry_share.cpp


