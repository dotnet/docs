all: Samples.AspNet.CS.dll
Samples.AspNet.CS.dll : datahelper.cs
	csc /t:library /out:Samples.AspNet.CS.dll datahelper.cs
	IF NOT EXIST bin md bin
	copy Samples.AspNet.CS.dll bin