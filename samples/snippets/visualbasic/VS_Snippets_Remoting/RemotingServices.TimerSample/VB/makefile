all: timerserver.exe timerclient.exe

timerserver.exe: timerserver.vb timerservice.dll
	vbc timerserver.vb /r:timerservice.dll

timerclient.exe: timerclient.vb timerservice.dll
	vbc timerclient.vb /r:timerservice.dll

timerservice.dll: timerservice.vb
	vbc /t:library timerservice.vb
