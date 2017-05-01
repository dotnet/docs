
all: basicserver.exe basicclient.exe manualserver.exe manualclient.exe

basicserver.exe: basicserver.vb service.dll
	vbc basicserver.vb /r:service.dll

basicclient.exe: basicclient.vb service.dll
	vbc basicclient.vb /r:service.dll

manualserver.exe: manualserver.vb service.dll
	vbc manualserver.vb /r:service.dll

manualclient.exe: manualclient.vb service.dll
	vbc manualclient.vb /r:service.dll

service.dll: service.vb
	vbc /t:library service.vb
