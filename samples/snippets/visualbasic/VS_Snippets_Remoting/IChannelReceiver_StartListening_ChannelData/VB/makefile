all: Share.dll server.exe client.exe

Share.dll: IChannelReceiver_ChannelData_Share.vb
	vbc /t:library IChannelReceiver_ChannelData_Share.vb

server.exe: IChannelReceiver_ChannelData_Server.vb IChannelReceiver_ChannelData_Share.dll
	vbc IChannelReceiver_ChannelData_Server.vb /r:IChannelReceiver_ChannelData_Share.dll

client.exe: IChannelReceiver_ChannelData_client.vb IChannelReceiver_ChannelData_Share.dll
	vbc IChannelReceiver_ChannelData_client.vb /r:IChannelReceiver_ChannelData_Share.dll