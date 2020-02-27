all: server.exe client.exe ITransportHeaders_3_Share.dll

server.exe: ITransportHeaders_3_Server.vb ITransportHeaders_3_Share.dll
	vbc ITransportHeaders_3_Server.vb /r:ITransportHeaders_3_Share.dll

client.exe: ITransportHeaders_3_Client.vb ITransportHeaders_3_Share.dll
	vbc ITransportHeaders_3_Client.vb /r:ITransportHeaders_3_Share.dll

ITransportHeaders_3_Share.dll: ITransportHeaders_3_Share.vb
	vbc /t:library ITransportHeaders_3_Share.vb