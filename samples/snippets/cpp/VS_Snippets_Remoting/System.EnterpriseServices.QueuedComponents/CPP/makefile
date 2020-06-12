all:  queuedcomponent.dll queuedcomponentclientclass.exe
queuedcomponent.dll:   queuedcomponent.cpp
	cl /clr:pure /LD queuedcomponent.cpp

queuedcomponentclientclass.exe: queuedcomponentclientclass.cpp queuedcomponent.dll
	cl /clr:pure queuedcomponentclientclass.cpp
