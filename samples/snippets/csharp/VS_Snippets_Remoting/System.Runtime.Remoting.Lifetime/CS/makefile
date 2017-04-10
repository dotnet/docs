all : server.exe client.exe service.dll

service.dll : service.cs
	csc /t:library service.cs

server.exe : server.cs service.dll
	csc /r:service.dll server.cs

client.exe : client.cs service.dll
	csc /r:service.dll client.cs

