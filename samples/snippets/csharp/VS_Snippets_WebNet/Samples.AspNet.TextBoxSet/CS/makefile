all: bin\Samples.AspNet.Controls.CS.dll

bin\Samples.AspNet.Controls.CS.dll: textboxset.cs
    IF NOT EXIST bin md bin
    csc /target:library /nologo /out:bin\Samples.AspNet.Controls.CS.dll textboxset.cs
