all: Share.dll server.exe client.exe

Share.dll: IChannelReceiver_ChannelData_Share.cpp
	cl /clr:pure /LD IChannelReceiver_ChannelData_Share.cpp

server.exe: IChannelReceiver_ChannelData_Server.cpp IChannelReceiver_ChannelData_Share.dll
	cl /clr:pure IChannelReceiver_ChannelData_Server.cpp

client.exe: IChannelReceiver_ChannelData_client.cpp IChannelReceiver_ChannelData_Share.dll
	cl /clr:pure IChannelReceiver_ChannelData_client.cpp