all : control_addparsedsubobject.dll
control_addparsedsubobject.dll : control_addparsedsubobject.vb
	vbc /t:library /out:control_addparsedsubobject.dll control_addparsedsubobject.vb
	IF NOT EXIST bin md bin
	copy control_addparsedsubobject.dll bin