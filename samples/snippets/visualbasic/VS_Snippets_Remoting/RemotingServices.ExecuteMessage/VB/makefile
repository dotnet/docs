all : server.exe client.exe serviceclass.dll

serviceclass.dll : serviceclass.vb
	vbc /debug+ /nologo /t:library serviceclass.vb

server.exe : server.vb serviceclass.dll
	vbc /debug+ /nologo /r:serviceclass.dll server.vb

client.exe : client.vb serviceclass.dll
	vbc /debug+ /nologo /r:serviceclass.dll client.vb
