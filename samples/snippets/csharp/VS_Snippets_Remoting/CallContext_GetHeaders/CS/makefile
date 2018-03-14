all: callcontext_Server.exe callcontext_Client.exe

callcontext_Server.exe: callcontext_Server.cs callcontext_Share.dll
	csc callcontext_Server.cs /r:callcontext_Share.dll

callcontext_Client.exe: callcontext_Client.cs callcontext_Share.dll
	csc callcontext_Client.cs /r:callcontext_Share.dll

callcontext_Share.dll: callcontext_Share.cs
	csc /t:library callcontext_Share.cs
