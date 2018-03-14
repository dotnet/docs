all : server.exe client.exe serviceclass.dll

serviceclass.dll : serviceclass.cs
	csc /debug+ /nologo /t:library serviceclass.cs

server.exe : server.cs serviceclass.dll
	csc /debug+ /nologo /r:serviceclass.dll server.cs

client.exe : client.cs serviceclass.dll
	csc /debug+ /nologo /r:serviceclass.dll client.cs

