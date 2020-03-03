all : server.exe client.exe

server.exe : server.cs
	csc /debug+ /nologo server.cs


client.exe : client.cs server.exe
	csc /debug+ /nologo /r:server.exe client.cs

