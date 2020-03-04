all : bin\Samples.AspNet.VB.dll 

bin\Samples.AspNet.VB.dll : ..\..\System.Web.UI.WebControls.ObjectDataSource_1\VB\northwindemployee1.vb
       IF NOT EXIST bin md bin
    vbc /target:library /nologo /out:bin\Samples.AspNet.VB.dll  ..\..\System.Web.UI.WebControls.ObjectDataSource_1\VB\northwindemployee1.vb