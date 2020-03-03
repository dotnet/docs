all: service.dll server.exe server2.exe client.exe client2.exe

service.dll: service.cs
	csc /t:library service.cs

server.exe: server.cs service.dll
	csc server.cs /r:service.dll

server2.exe: server2.cs service.dll
	csc server2.cs /r:service.dll

client.exe: client.cs service.dll
	csc client.cs /r:service.dll

client2.exe: client2.cs service.dll
	csc client2.cs /r:service.dll