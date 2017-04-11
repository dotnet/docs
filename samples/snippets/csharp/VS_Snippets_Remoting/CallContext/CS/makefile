CC=csc

makefile : Service.dll Client.exe

Service.dll : Service.cs
	$(CC) /debug+ /nologo /t:library Service.cs

Client.exe : Client.cs Service.dll
	$(CC) /nologo /r:Service.dll Client.cs
