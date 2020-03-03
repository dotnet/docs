
all : control_resolveurl.dll
control_resolveurl.dll : control_resolveurl.cs
	csc /t:library /out:control_resolveurl.dll control_resolveurl.cs
	IF NOT EXIST bin md bin
	copy control_resolveurl.dll bin