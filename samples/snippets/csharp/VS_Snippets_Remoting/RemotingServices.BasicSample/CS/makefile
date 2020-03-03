
all: basicserver.exe basicclient.exe manualserver.exe manualclient.exe

basicserver.exe: basicserver.cs service.dll
	csc basicserver.cs /r:service.dll

basicclient.exe: basicclient.cs service.dll
	csc basicclient.cs /r:service.dll

manualserver.exe: manualserver.cs service.dll
	csc manualserver.cs /r:service.dll

manualclient.exe: manualclient.cs service.dll
	csc manualclient.cs /r:service.dll

service.dll: service.cs
	csc /t:library service.cs
