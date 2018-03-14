all: server.exe client.exe RemoteType.dll

server.exe: ISponsor_Server.vb RemoteType.dll
	vbc ISponsor_Server.vb /r:RemoteType.dll

client.exe: ISponsor_Client.vb RemoteType.dll
	vbc ISponsor_Client.vb /r:RemoteType.dll

RemoteType.dll: RemoteType.vb
	vbc /t:library RemoteType.vb