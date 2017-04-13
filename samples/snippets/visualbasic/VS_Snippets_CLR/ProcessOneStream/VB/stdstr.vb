Imports System
Imports System.Diagnostics

Class Snippet
    
    Shared Sub Main()
        '<Snippet1>     
        ' Run "vbc.exe /reference:Microsoft.VisualBasic.dll /out:sample.exe stdstr.vb". UseShellExecute is False 
        ' because we're specifying an executable directly and in this case depending on it being in a PATH folder. 
        ' By setting RedirectStandardOutput to True, the output of csc.exe is directed to the Process.StandardOutput 
        ' stream which is then displayed in this console window directly.    
        Dim compiler As New Process()
        compiler.StartInfo.FileName = "vbc.exe"
        compiler.StartInfo.Arguments = "/reference:Microsoft.VisualBasic.dll /out:sample.exe stdstr.vb"
        compiler.StartInfo.UseShellExecute = False
        compiler.StartInfo.RedirectStandardOutput = True
        compiler.Start()
        
        Console.WriteLine(compiler.StandardOutput.ReadToEnd())
        
        compiler.WaitForExit()
        '</Snippet1>
    End Sub 'Main
End Class 'Snippet
