all: customliteralcontrol.dll
customliteralcontrol.dll : customliteralcontrol.vb
	vbc /t:library customliteralcontrol.vb
	IF NOT EXIST bin md bin
	copy customliteralcontrol.dll bin