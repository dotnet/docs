all: server.exe client.exe serverprocessing_loggingsinks.dll serverprocessing_share.dll

server.exe: serverprocessing_Server.cs serverprocessing_Share.dll serverprocessing_loggingsinks.dll
	csc serverprocessing_Server.cs /r:serverprocessing_Share.dll /r:serverprocessing_loggingsinks.dll

client.exe: serverprocessing_Client.cs serverprocessing_Share.dll serverprocessing_loggingsinks.dll
	csc serverprocessing_Client.cs /r:serverprocessing_Share.dll /r:serverprocessing_loggingsinks.dll

serverprocessing_loggingsinks.dll: serverprocessing_loggingsinks.cs
	csc /t:library serverprocessing_loggingsinks.cs

serverprocessing_share.dll: serverprocessing_share.cs
	csc /t:library serverprocessing_share.cs
