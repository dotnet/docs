all: Samples.AspNet.CS.dll
Samples.AspNet.CS.dll : control_load.cs
    csc /t:library /out:Samples.AspNet.CS.dll control_load.cs
    IF NOT EXIST bin md bin
    copy Samples.AspNet.CS.dll bin