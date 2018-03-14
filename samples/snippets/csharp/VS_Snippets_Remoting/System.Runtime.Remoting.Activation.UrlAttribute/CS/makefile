all: client.exe server.exe 

server.exe: server.cs remoteobject.dll
	csc server.cs /r:remoteobject.dll

client.exe: client.cs remoteobject.dll
	csc client.cs /r:remoteobject.dll

remoteobject.dll: remoteobject.cs
	csc /t:library remoteobject.cs