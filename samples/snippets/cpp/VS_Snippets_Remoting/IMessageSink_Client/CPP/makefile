all: IMessageSink_Share.dll imessagesink_client.exe

IMessageSink_Share.dll: IMessageSink_Share.cs
	csc /t:library IMessageSink_Share.cs

imessagesink_client.exe: imessagesink_client.cpp IMessageSink_Share.dll
	cl /clr imessagesink_client.cpp