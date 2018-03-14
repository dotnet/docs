using System;
using System.Diagnostics;

public class Snippet
{
    static void Main() 
    {     
        //<Snippet1>         
        // Run "csc.exe /r:System.dll /out:sample.exe stdstr.cs". UseShellExecute is false because we're specifying
        // an executable directly and in this case depending on it being in a PATH folder. By setting
        // RedirectStandardOutput to true, the output of csc.exe is directed to the Process.StandardOutput stream
        // which is then displayed in this console window directly.    
        Process compiler = new Process();
        compiler.StartInfo.FileName = "csc.exe";
        compiler.StartInfo.Arguments = "/r:System.dll /out:sample.exe stdstr.cs";
        compiler.StartInfo.UseShellExecute = false;
        compiler.StartInfo.RedirectStandardOutput = true;
        compiler.Start();    
        
        Console.WriteLine(compiler.StandardOutput.ReadToEnd());

        compiler.WaitForExit();
        //</Snippet1>
    }
}

