# Comment here
all: Server.exe Client.exe
Remotable.dll: Remotable.cs
	csc /nologo /t:library Remotable.cs
ServerSink.dll: ServerSink.cs
	csc /nologo /t:library ServerSink.cs
Server.exe: Server.cs Remotable.dll ServerSink.dll
	csc /nologo Server.cs /r:Remotable.dll /r:ServerSink.dll
ClientSink.dll: ClientSink.cs
	csc /nologo /t:library ClientSink.cs
Client.exe: Client.cs ClientSink.dll Remotable.dll
	csc /nologo Client.cs /r:Remotable.dll
