all: client.exe server.exe server2.exe

server.exe: server.cs common.dll
	csc server.cs /r:common.dll

server2.exe: server2.cs common.dll
	csc server2.cs /r:common.dll

client.exe: client.cs common.dll
	csc client.cs /r:common.dll

common.dll: common.cs
	csc /t:library common.cs
