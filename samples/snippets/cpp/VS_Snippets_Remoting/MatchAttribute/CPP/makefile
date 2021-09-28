all : SvcClient_MatchAttribute.exe

SvcClient_MatchAttribute.exe : SvcClient_MatchAttribute.cpp matchattribute.dll
	cl /clr:pure  SvcClient_MatchAttribute.cpp

matchattribute.dll : matchattribute.cpp
	cl /clr:pure /LD matchattribute.cpp
