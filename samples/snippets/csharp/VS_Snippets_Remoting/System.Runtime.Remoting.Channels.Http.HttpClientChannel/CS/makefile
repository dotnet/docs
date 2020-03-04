all: client.exe server.exe client2.exe

server.exe: server.cs common.dll
	csc server.cs /r:common.dll

client.exe: client.cs common.dll
	csc client.cs /r:common.dll

client2.exe: client2.cs common.dll
	csc client2.cs /r:common.dll

common.dll: common.cs
	csc /t:library common.cs
