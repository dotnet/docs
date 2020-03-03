all: customliteralcontrol.dll
customliteralcontrol.dll : customliteralcontrol.cs
	csc /t:library customliteralcontrol.cs
	IF NOT EXIST bin md bin
	copy customliteralcontrol.dll bin