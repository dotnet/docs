all : server.exe client.exe service.dll

service.dll : service.vb
	vbc /t:library service.vb

server.exe : server.vb service.dll
	vbc /r:service.dll server.vb

client.exe : client.vb service.dll
	vbc /r:service.dll client.vb
