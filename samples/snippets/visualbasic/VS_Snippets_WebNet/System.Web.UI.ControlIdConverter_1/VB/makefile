all: bin\Samples.AspNet.VB.dll

bin\Samples.AspNet.VB.dll: debuginfocontrol.vb
    IF NOT EXIST bin md bin
    vbc /target:library /nologo /out:bin\Samples.AspNet.VB.dll debuginfocontrol.vb
