all : server.exe client.exe service.dll

service.dll : service.cs
	csc /debug+ /nologo /t:library service.cs

server.exe : server.cs service.dll
	csc /debug+ /nologo /r:service.dll server.cs

client.exe : client.cs service.dll
	csc /debug+ /nologo /r:service.dll client.cs

