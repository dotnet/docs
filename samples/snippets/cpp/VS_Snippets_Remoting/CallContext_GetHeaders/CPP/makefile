all: callcontext_Server.exe callcontext_Client.exe

callcontext_Server.exe: callcontext_Server.cpp callcontext_Share.dll
	cl /clr:pure callcontext_Server.cpp

callcontext_Client.exe: callcontext_Client.cpp callcontext_Share.dll
	cl /clr:pure callcontext_Client.cpp

callcontext_Share.dll: callcontext_Share.cpp
	cl /LD /clr:pure callcontext_Share.cpp
