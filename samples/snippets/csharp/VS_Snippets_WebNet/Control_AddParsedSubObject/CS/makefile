all : control_addparsedsubobject.dll
control_addparsedsubobject.dll : control_addparsedsubobject.cs
	csc /t:library /out:control_addparsedsubobject.dll control_addparsedsubobject.cs
	IF NOT EXIST bin md bin
	copy control_addparsedsubobject.dll bin