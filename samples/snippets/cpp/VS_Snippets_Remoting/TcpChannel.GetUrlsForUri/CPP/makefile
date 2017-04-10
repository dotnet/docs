all : class1.exe


class1.exe : class1.cpp Service.dll
	cl /clr:pure /Zi /nologo class1.cpp

Service.dll : Service.cpp
	cl /clr:pure /Zi /nologo /LD Service.cpp
