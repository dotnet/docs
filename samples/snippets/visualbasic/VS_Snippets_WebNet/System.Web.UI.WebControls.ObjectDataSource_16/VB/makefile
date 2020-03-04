all : bin\Samples.AspNet.VB.dll 

bin\Samples.AspNet.VB.dll : northwindemployee16.vb
       IF NOT EXIST bin md bin
    vbc /target:library /out:bin\Samples.AspNet.VB.dll northwindemployee16.vb