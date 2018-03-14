
all : control_sample_1.dll
control_sample_1.dll : control_sample_1.vb
	vbc /t:library /out:control_sample_1.dll control_sample_1.vb
	IF NOT EXIST bin md bin
	copy control_sample_1.dll bin