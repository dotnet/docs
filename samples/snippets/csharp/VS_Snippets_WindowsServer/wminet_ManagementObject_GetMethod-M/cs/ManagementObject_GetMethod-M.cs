//<Snippet1>
using System;
using System.Management;
   
public class AsyncGetExample
{
    public AsyncGetExample() 
    {
        ManagementObject o = 
            new ManagementObject(
            "Win32_Process.Name='notepad.exe'");

        // Set up handlers for asynchronous get
        ManagementOperationObserver ob = 
            new ManagementOperationObserver();
        ob.Completed += new
            CompletedEventHandler(this.Done);

        // Get the object asynchronously
        o.Get(ob);

        // Wait until operation is completed
        while (!this.Completed)
            System.Threading.Thread.Sleep (1000);

        // Here you can use the object

    }

    private bool completed = false;

    private void Done(object sender,
        CompletedEventArgs e)
    {
        Console.WriteLine("async Get completed !");
        completed = true;
    }
    
    private bool Completed
    { 
        get 
        {
            return completed;
        }
    }

    public static void Main()
    {
        AsyncGetExample example =
            new AsyncGetExample();

    }
}
//</Snippet1>