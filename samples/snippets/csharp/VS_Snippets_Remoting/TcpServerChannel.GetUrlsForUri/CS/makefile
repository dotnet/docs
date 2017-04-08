all: class1.exe

class1.exe: class1.cs service.dll
	csc class1.cs /r:service.dll

service.dll: service.cs
	csc /t:library service.cs
