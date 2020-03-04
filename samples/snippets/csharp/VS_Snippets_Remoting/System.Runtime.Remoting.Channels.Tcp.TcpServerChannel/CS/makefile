all : server.exe client.exe common.dll

common.dll : common.cs
	csc /t:library common.cs

server.exe : server.cs common.dll
	csc /r:common.dll server.cs

client.exe : client.cs common.dll
	csc /r:common.dll client.cs

