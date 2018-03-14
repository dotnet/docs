
all : control_sample.dll
control_sample.dll : control_sample.vb
	vbc /t:library /out:control_sample.dll control_sample.vb
	IF NOT EXIST bin md bin
	copy control_sample.dll bin