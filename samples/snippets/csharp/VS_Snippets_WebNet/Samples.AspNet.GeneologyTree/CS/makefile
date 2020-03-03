all: bin\Samples.AspNet.CS.Controls.dll

bin\Samples.AspNet.CS.Controls.dll: geneologytree.cs
    IF NOT EXIST bin md bin
    csc /target:library /nologo /out:bin\Samples.AspNet.CS.Controls.dll geneologytree.cs
