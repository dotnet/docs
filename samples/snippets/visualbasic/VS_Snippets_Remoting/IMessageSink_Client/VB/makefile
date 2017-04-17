all: Share.dll server.exe client.exe

Share.dll: IMessageSink_Share.vb
	vbc /t:library IMessageSink_Share.vb

server.exe: IMessageSink_Service.vb IMessageSink_Share.dll
	vbc IMessageSink_Service.vb /r:IMessageSink_Share.dll

client.exe: IMessageSink_client.vb IMessageSink_Share.dll
	vbc IMessageSink_client.vb /r:IMessageSink_Share.dll