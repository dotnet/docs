
all : controlclass_samples.dll
controlclass_samples.dll : controlclass_samples.cs
	csc /t:library /out:controlclass_samples.dll controlclass_samples.cs
	IF NOT EXIST bin md bin
	copy controlclass_samples.dll bin