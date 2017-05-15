all : server.exe client.exe service.dll

service.dll : service.vb
	vbc /debug+ /nologo /t:library service.vb

server.exe : server.vb service.dll
	vbc /debug+ /nologo /r:service.dll server.vb

client.exe : client.vb service.dll
	vbc /debug+ /nologo /r:service.dll client.vb
