all: Counter.dll Client.exe Server.exe

Counter.dll: Counter.cs
	csc /t:library Counter.cs

Server.exe: Server.cs Counter.dll
	csc Server.cs /r:Counter.dll

Client.exe: Client.cs Counter.dll
	csc Client.cs /r:Counter.dll
