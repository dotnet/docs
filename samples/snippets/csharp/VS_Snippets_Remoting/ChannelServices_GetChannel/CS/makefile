all: server.exe client.exe

server.exe: ChannelServices_GetChannel_Server.cs ChannelServices_GetChannel_Share.dll
	csc ChannelServices_GetChannel_Server.cs /r:ChannelServices_GetChannel_Share.dll

client.exe: channelservices_getchannel_client.cs ChannelServices_GetChannel_Share.dll
	csc ChannelServices_GetChannel_client.cs /r:ChannelServices_GetChannel_Share.dll

ChannelServices_GetChannel_Share.dll: ChannelServices_GetChannel_Share.cs
	csc /t:library ChannelServices_GetChannel_Share.cs
