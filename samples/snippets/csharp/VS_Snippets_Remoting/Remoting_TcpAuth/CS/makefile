all: Remotable.dll Server.exe Client.exe
Remotable.dll: Remotable.cs
	csc /t:library Remotable.cs
Server.exe: Server.cs Remotable.dll
	csc Server.cs /r:Remotable.dll
Client.exe: Client.cs Remotable.dll
	csc Client.cs /r:Remotable.dll
