all: client.exe server.exe

server.exe: server.cs common.dll
	csc server.cs /r:common.dll

client.exe: client.cs common.dll
	csc client.cs /r:common.dll

common.dll: common.cs
	csc /t:library common.cs
