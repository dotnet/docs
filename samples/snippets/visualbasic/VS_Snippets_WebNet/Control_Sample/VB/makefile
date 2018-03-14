
all : controlclass_samples.dll
controlclass_samples.dll : controlclass_samples.vb
	vbc /t:library /out:controlclass_samples.dll controlclass_samples.vb
	IF NOT EXIST bin md bin
	copy controlclass_samples.dll bin