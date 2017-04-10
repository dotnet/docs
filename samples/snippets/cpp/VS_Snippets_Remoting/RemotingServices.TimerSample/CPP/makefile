all: timerserver.exe timerclient.exe

timerserver.exe: timerserver.cpp timerservice.dll
	cl /clr:pure timerserver.cpp

timerclient.exe: timerclient.cpp timerservice.dll
	cl /clr:pure timerclient.cpp

timerservice.dll: timerservice.cpp
	cl /clr:pure /LD timerservice.cpp
