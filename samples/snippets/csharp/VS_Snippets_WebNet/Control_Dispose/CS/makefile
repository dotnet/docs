
all : control_disposemethod.dll
control_disposemethod.dll : control_disposemethod.cs
	csc /t:library /out:control_disposemethod.dll control_disposemethod.cs
	IF NOT EXIST bin md bin
	copy control_disposemethod.dll bin

