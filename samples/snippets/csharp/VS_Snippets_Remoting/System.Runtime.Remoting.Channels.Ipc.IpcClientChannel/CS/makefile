all: common.dll client.dll client2.dll server.dll

common.dll: common.cs
	csc /t:library common.cs

server.dll: server.cs common.dll
	CS>csc /t:library server.cs /r:common.dll

client.dll: client.cs common.dll 
	csc /t:library server.cs /r:common.dll
client2.dll: client2.cs common.dll 
	csc /t:library client2.cs /r:common.dll