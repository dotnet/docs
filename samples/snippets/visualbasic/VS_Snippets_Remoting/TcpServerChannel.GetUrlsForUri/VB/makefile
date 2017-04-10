all: class1.exe

class1.exe: class1.vb service.dll
	vbc class1.vb /r:service.dll

service.dll: service.vb
	vbc /t:library service.vb
