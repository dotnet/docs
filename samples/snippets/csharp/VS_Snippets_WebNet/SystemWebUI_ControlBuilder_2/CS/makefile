all: bin\cs_mycontrolbuilder.dll

bin\cs_mycontrolbuilder.dll:  controlbuilder.cs
	IF NOT EXIST bin md bin
	csc /target:library /nologo /out:bin\cs_mycontrolbuilder.dll controlbuilder.cs