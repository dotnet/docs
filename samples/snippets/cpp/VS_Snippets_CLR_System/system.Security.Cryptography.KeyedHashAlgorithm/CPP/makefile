all: contosokeyedhash.dll encodewithcontoso.exe

contosokeyedhash.dll: contosokeyedhash.cpp
	cl /LD /clr:pure contosokeyedhash.cpp

encodewithcontoso.exe: contosokeyedhash.dll encodewithcontoso.cpp
	cl /clr:pure encodewithcontoso.cpp