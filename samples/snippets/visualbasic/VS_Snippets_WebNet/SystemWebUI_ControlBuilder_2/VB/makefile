all: bin\vb_mycontrolbuilder.dll

bin\vb_mycontrolbuilder.dll:  controlbuilder.vb
	IF NOT EXIST bin md bin
	vbc /target:library /nologo /out:bin\vb_mycontrolbuilder.dll /r:System.dll,System.Web.DLL controlbuilder.vb

