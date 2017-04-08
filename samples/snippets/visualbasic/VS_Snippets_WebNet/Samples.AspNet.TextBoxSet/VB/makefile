all: bin\Samples.AspNet.Controls.VB.dll

bin\Samples.AspNet.Controls.VB.dll: textboxset.vb
    IF NOT EXIST bin md bin
    vbc /target:library /nologo /out:bin\Samples.AspNet.Controls.VB.dll /r:System.dll,System.Web.DLL textboxset.vb
