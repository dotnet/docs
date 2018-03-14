
all : Control_TemplateSourceDirectory.dll
Control_TemplateSourceDirectory.dll : Control_TemplateSourceDirectory.cs
	csc /t:library /out:Control_TemplateSourceDirectory.dll Control_TemplateSourceDirectory.cs
	IF NOT EXIST bin md bin
	copy Control_TemplateSourceDirectory.dll bin