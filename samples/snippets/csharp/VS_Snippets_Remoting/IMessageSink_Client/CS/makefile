all: Share.dll server.exe client.exe

Share.dll: IMessageSink_Share.cs
	csc /t:library IMessageSink_Share.cs

server.exe: IMessageSink_Service.cs IMessageSink_Share.dll
	csc IMessageSink_Service.cs /r:IMessageSink_Share.dll

client.exe: IMessageSink_client.cs IMessageSink_Share.dll
	csc IMessageSink_client.cs /r:IMessageSink_Share.dll