all: service.dll server.exe server2.exe client.exe client2.exe

service.dll: service.vb
	vbc /t:library service.vb

server.exe: server.vb service.dll
	vbc server.vb /r:service.dll

server2.exe: server2.vb service.dll
	vbc server2.vb /r:service.dll

client.exe: client.vb service.dll
	vbc client.vb /r:service.dll

client2.exe: client2.vb service.dll
	vbc client2.vb /r:service.dll