all: server.exe client.exe RemoteType.dll

server.exe: ISponsor_Server.cs RemoteType.dll
	csc ISponsor_Server.cs /r:RemoteType.dll

client.exe: ISponsor_Client.cs RemoteType.dll
	csc ISponsor_Client.cs /r:RemoteType.dll

RemoteType.dll: RemoteType.cs
	csc /t:library RemoteType.cs