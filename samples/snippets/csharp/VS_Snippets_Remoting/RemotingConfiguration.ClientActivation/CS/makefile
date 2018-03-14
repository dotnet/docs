all : service.dll server.exe client.exe

server.exe : server.cs service.dll
	csc /debug+ /nologo /r:service.dll server.cs


client.exe : client.cs service.dll
	csc /debug+ /nologo /r:service.dll client.cs


service.dll : service.cs
	csc /debug+ /t:library /nologo service.cs
