all : bin\Samples.AspNet.CS.dll 

bin\Samples.AspNet.CS.dll : ..\..\System.Web.UI.WebControls.ObjectDataSource_12\CS\northwindemployee12.cs
       IF NOT EXIST bin md bin
    csc /target:library /nologo /out:bin\Samples.AspNet.CS.dll  ..\..\System.Web.UI.WebControls.ObjectDataSource_12\CS\northwindemployee12.cs