
all : control_onunload.dll
control_onunload.dll : control_onunload.cs
	csc /t:library /out:control_onunload.dll control_onunload.cs
	IF NOT EXIST bin md bin
	copy control_onunload.dll bin