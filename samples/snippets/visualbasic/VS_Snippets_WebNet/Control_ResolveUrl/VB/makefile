
all : control_resolveurl.dll
control_resolveurl.dll : control_resolveurl.vb
	vbc /t:library /out:control_resolveurl.dll control_resolveurl.vb
	IF NOT EXIST bin md bin
	copy control_resolveurl.dll bin