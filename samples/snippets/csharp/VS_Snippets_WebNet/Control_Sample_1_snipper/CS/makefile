
all : control_sample.dll
control_sample.dll : control_sample_1.cs
	csc /t:library /out:control_sample.dll control_sample_1.cs
	IF NOT EXIST bin md bin
	copy control_sample.dll bin