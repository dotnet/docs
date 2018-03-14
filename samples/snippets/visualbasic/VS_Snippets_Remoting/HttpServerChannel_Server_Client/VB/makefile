
all: HttpServerChannel_Client.exe HttpServerChannel_Server.exe

HttpServerChannel_Client.exe: HttpClientChannel_6_Client.vb HttpServerChannel_Share.dll
	vbc /out:HttpServerChannel_Client.exe /r:HttpServerChannel_Share.dll HttpClientChannel_6_Client.vb

HttpServerChannel_Server.exe: HttpServerChannel_9_Server.vb HttpServerChannel_Share.dll
	vbc /out:HttpServerChannel_Server.exe /r:HttpServerChannel_Share.dll HttpServerChannel_9_Server.vb

HttpServerChannel_Share.dll: HttpServerChannel_Clientl_14_Share.vb
	vbc /t:library /out:HttpServerChannel_Share.dll HttpServerChannel_Clientl_14_Share.vb
