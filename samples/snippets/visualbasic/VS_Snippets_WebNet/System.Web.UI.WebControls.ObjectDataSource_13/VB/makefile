all : bin\Samples.AspNet.VB.dll 

bin\Samples.AspNet.VB.dll : ..\..\System.Web.UI.WebControls.ObjectDataSource_12\VB\northwindemployee12.vb
       IF NOT EXIST bin md bin
    vbc /target:library /out:bin\Samples.AspNet.VB.dll  ..\..\System.Web.UI.WebControls.ObjectDataSource_12\VB\northwindemployee12.vb