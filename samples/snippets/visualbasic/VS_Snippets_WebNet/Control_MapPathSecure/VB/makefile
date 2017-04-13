
all : Control_TemplateSourceDirectory.dll
Control_TemplateSourceDirectory.dll : Control_TemplateSourceDirectory.vb
	vbc /t:library /out:Control_TemplateSourceDirectory.dll Control_TemplateSourceDirectory.vb
	IF NOT EXIST bin md bin
	copy Control_TemplateSourceDirectory.dll bin