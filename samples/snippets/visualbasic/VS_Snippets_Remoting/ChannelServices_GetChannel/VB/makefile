all: server.exe client.exe

server.exe: ChannelServices_GetChannel_Server.vb ChannelServices_GetChannel_Share.dll
	vbc ChannelServices_GetChannel_Server.vb /r:ChannelServices_GetChannel_Share.dll

client.exe: channelservices_getchannel_client.vb ChannelServices_GetChannel_Share.dll
	vbc ChannelServices_GetChannel_client.vb /r:ChannelServices_GetChannel_Share.dll

ChannelServices_GetChannel_Share.dll: ChannelServices_GetChannel_Share.vb
	vbc /t:library ChannelServices_GetChannel_Share.vb
