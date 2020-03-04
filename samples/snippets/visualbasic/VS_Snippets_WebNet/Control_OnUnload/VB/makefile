
all : control_onunload.dll
control_onunload.dll : control_onunload.vb
	vbc /t:library /out:control_onunload.dll control_onunload.vb
	IF NOT EXIST bin md bin
	copy control_onunload.dll bin