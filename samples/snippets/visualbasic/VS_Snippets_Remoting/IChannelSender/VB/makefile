all: Share.dll server.exe client.exe

Share.dll: IChannelSender_Share.vb
	vbc /t:library IChannelSender_Share.vb

server.exe: IChannelSender_Server.vb IChannelSender_Share.dll
	vbc IChannelSender_Server.vb /r:IChannelSender_Share.dll

client.exe: IChannelSender_2_client.vb IChannelSender_Share.dll
	vbc IChannelSender_2_client.vb /r:IChannelSender_Share.dll