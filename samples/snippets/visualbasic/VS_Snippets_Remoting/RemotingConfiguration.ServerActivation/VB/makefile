all : server.exe client.exe

server.exe : server.vb
	vbc /debug+ /nologo server.vb


client.exe : client.vb server.exe
	vbc /debug+ /nologo /r:server.exe client.vb
