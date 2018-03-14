all: timerserver.exe timerclient.exe

timerserver.exe: timerserver.cs timerservice.dll
	csc timerserver.cs /r:timerservice.dll

timerclient.exe: timerclient.cs timerservice.dll
	csc timerclient.cs /r:timerservice.dll

timerservice.dll: timerservice.cs
	csc /t:library timerservice.cs
