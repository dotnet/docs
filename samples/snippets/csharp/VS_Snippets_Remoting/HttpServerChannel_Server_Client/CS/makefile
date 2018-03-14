
all: HttpServerChannel_Client.exe HttpServerChannel_Server.exe

HttpServerChannel_Client.exe: HttpClientChannel_6_Client.cs HttpServerChannel_Share.dll
	csc /out:HttpServerChannel_Client.exe /r:HttpServerChannel_Share.dll HttpClientChannel_6_Client.cs

HttpServerChannel_Server.exe: HttpServerChannel_9_Server.cs HttpServerChannel_Share.dll
	csc /out:HttpServerChannel_Server.exe /r:HttpServerChannel_Share.dll HttpServerChannel_9_Server.cs

HttpServerChannel_Share.dll: HttpServerChannel_Clientl_14_Share.cs
	csc /t:library /out:HttpServerChannel_Share.dll HttpServerChannel_Clientl_14_Share.cs
