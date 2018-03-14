all:  queuedcomponent.dll queuedcomponentclientclass.exe
queuedcomponent.dll:   queuedcomponent.cs
	csc /t:library  queuedcomponent.cs

queuedcomponentclientclass.exe: queuedcomponentclientclass.cs queuedcomponent.dll
	csc queuedcomponentclientclass.cs
