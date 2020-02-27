all: Samples.AspNet.VB.dll
Samples.AspNet.VB.dll : datahelper.vb
	vbc /t:library /out:Samples.AspNet.VB.dll datahelper.vb
	IF NOT EXIST bin md bin
	copy  Samples.AspNet.VB.dll bin