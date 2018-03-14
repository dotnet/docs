//<Snippet1>
using System;
using System.Management;

public class AsyncGetExample
{
    public AsyncGetExample() 
    {
        ManagementClass c = 
            new ManagementClass("Win32_Process");
        ManagementOperationObserver ob =
            new ManagementOperationObserver();
        ob.ObjectReady += new ObjectReadyEventHandler(NewObject);
        ob.Completed += new CompletedEventHandler(Done);

        c.GetInstances(ob);

        while (!Completed)
            System.Threading.Thread.Sleep (1000);

        // Here you can use the object
        
    }

    private bool completed = false;

    private void NewObject(object sender,
        ObjectReadyEventArgs e) 
    {
        Console.WriteLine("New result arrived: {0}",
            ((ManagementObject)(e.NewObject))["Name"]);
    }

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
        AsyncGetExample asyncGet = new
            AsyncGetExample();

        return;
    }
}
//</Snippet1>