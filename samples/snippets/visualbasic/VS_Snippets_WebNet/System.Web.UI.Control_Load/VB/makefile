all: Samples.AspNet.VB.dll
Samples.AspNet.VB.dll : control_load.vb
    vbc /t:library /out:Samples.AspNet.VB.dll control_load.vb
    IF NOT EXIST bin md bin
    copy Samples.AspNet.VB.dll bin