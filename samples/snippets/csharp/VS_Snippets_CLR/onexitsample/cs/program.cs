//<Snippet1>
using System;
using System.Diagnostics;

class MyProcess : Process
{
    public void Stop()
    {
        this.CloseMainWindow();
        this.Close();
        OnExited();
    } 
}
class StartNotePad
{

    public static void Main(string[] args)
    {
        MyProcess p = new MyProcess();
        p.StartInfo.FileName = "notepad.exe";
        p.EnableRaisingEvents = true;
        p.Exited += new EventHandler(myProcess_HasExited);
        p.Start();
        p.WaitForInputIdle();
        p.Stop();
    }
    private static void myProcess_HasExited(object sender, System.EventArgs e)
    {
        Console.WriteLine("Process has exited.");
    }
}
//</Snippet1>