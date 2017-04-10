all: class1.exe

class1.exe: class1.cpp service.dll
	cl /clr:pure class1.cpp

service.dll: service.cpp
	cl /clr:pure /LD service.cpp
