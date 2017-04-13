all: Share.dll server.exe client.exe

Share.dll: IChannelSender_Share.cs
	csc /t:library IChannelSender_Share.cs

server.exe: IChannelSender_Server.cs IChannelSender_Share.dll
	csc IChannelSender_Server.cs /r:IChannelSender_Share.dll

client.exe: IChannelSender_2_client.cs IChannelSender_Share.dll
	csc IChannelSender_2_client.cs /r:IChannelSender_Share.dll