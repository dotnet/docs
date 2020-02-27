all : service.dll server.exe client.exe

server.exe : server.vb service.dll
	vbc /debug+ /nologo /r:service.dll server.vb


client.exe : client.vb service.dll
	vbc /debug+ /nologo /r:service.dll client.vb


service.dll : service.vb
	vbc /debug+ /t:library /nologo service.vb
