all: Share.dll server.exe client.exe

Share.dll: IChannelReceiver_ChannelData_Share.cs
	csc /t:library IChannelReceiver_ChannelData_Share.cs

server.exe: IChannelReceiver_ChannelData_Server.cs IChannelReceiver_ChannelData_Share.dll
	csc IChannelReceiver_ChannelData_Server.cs /r:IChannelReceiver_ChannelData_Share.dll

client.exe: IChannelReceiver_ChannelData_client.cs IChannelReceiver_ChannelData_Share.dll
	csc IChannelReceiver_ChannelData_client.cs /r:IChannelReceiver_ChannelData_Share.dll