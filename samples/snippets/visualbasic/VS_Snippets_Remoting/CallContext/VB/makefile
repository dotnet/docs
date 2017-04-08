CC=vbc

makefile : Service.dll Client.exe

Service.dll : Service.vb
	$(CC) /debug+ /nologo /t:library Service.vb

Client.exe : Client.vb Service.dll
	$(CC) /nologo /r:Service.dll Client.vb
