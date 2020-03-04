
all : control_disposemethod.dll
control_disposemethod.dll : control_disposemethod.vb
	vbc /t:library /out:control_disposemethod.dll control_disposemethod.vb
	IF NOT EXIST bin md bin
	copy control_disposemethod.dll bin

