all: server.exe client.exe ITransportHeaders_3_Share.dll

server.exe: ITransportHeaders_3_Server.cs ITransportHeaders_3_Share.dll
	csc ITransportHeaders_3_Server.cs /r:ITransportHeaders_3_Share.dll

client.exe: ITransportHeaders_3_Client.cs ITransportHeaders_3_Share.dll
	csc ITransportHeaders_3_Client.cs /r:ITransportHeaders_3_Share.dll

ITransportHeaders_3_Share.dll: ITransportHeaders_3_Share.cs
	csc /t:library ITransportHeaders_3_Share.cs