all: Samples.AspNet.Controls.CS.dll
Samples.AspNet.Controls.CS.dll :responsefilter.cs
	csc /t:library /out:Samples.AspNet.Controls.CS.dll responsefilter.cs
	IF NOT EXIST bin md bin
	copy Samples.AspNet.Controls.CS.dll bin