
all : control_templatesourcedirectory.dll
control_templatesourcedirectory.dll : control_templatesourcedirectory.cs
	csc /t:library /out:control_templatesourcedirectory.dll control_templatesourcedirectory.cs
	IF NOT EXIST bin md bin
	copy control_templatesourcedirectory.dll bin