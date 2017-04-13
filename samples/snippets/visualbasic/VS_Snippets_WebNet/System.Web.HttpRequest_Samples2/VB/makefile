all: Samples.AspNet.Controls.VB.dll
Samples.AspNet.Controls.VB.dll :responsefilter.vb
	vbc /t:library /out:Samples.AspNet.Controls.VB.dll responsefilter.vb
	IF NOT EXIST bin md bin
	copy Samples.AspNet.Controls.VB.dll bin