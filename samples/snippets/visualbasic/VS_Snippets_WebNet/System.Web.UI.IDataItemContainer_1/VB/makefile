all: bin\Samples.AspNet.VB.dll

bin\Samples.AspNet.VB.dll: idataitemcontainersample.vb
    IF NOT EXIST bin md bin
    vbc /target:library /nologo /import:Microsoft.VisualBasic,System,System.Drawing,System.Windows.Forms /out:bin\Samples.AspNet.VB.dll /r:System.dll,System.Web.DLL idataitemcontainersample.vb
