all : bin\Samples.AspNet.CS.dll 

bin\Samples.AspNet.CS.dll : northwindemployee15.cs
       IF NOT EXIST bin md bin
    csc /target:library /nologo /out:bin\Samples.AspNet.CS.dll northwindemployee15.cs