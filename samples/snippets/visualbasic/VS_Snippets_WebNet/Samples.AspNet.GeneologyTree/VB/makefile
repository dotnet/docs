all: bin\Samples.AspNet.VB.Controls.dll

bin\Samples.AspNet.VB.Controls.dll: geneologytree.vb
    IF NOT EXIST bin md bin
    vbc /target:library /nologo /out:bin\Samples.AspNet.VB.Controls.dll /r:System.dll,System.Web.DLL geneologytree.vb
