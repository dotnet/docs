all: IChannelSender_Share.dll ichannelsender_2_client.exe

IChannelSender_Share.dll: IChannelSender_Share.cs
	csc /t:library IChannelSender_Share.cs

ichannelsender_2_client.exe: ichannelsender_2_client.cpp IChannelSender_Share.dll
	cl /clr ichannelsender_2_client.cpp