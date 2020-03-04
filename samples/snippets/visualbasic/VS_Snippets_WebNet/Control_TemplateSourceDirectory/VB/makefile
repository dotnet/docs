
all : control_templatesourcedirectory.dll
control_templatesourcedirectory.dll : control_templatesourcedirectory.vb
	vbc /t:library /out:control_templatesourcedirectory.dll control_templatesourcedirectory.vb
	IF NOT EXIST bin md bin
	copy control_templatesourcedirectory.dll bin