//<Snippet1>
using System;
using System.Management;

public class InvokeMethodAsync 
{
    private bool isComplete = false;
    private ManagementBaseObject returnObject;

    public InvokeMethodAsync()
    {
        // Get the object on which the method 
        // will be invoked
        ManagementClass processClass = 
            new ManagementClass("Win32_Process");

        // Create a results and completion handler
        ManagementOperationObserver handler = 
            new ManagementOperationObserver();
        handler.Completed += 
            new CompletedEventHandler(this.Completed);

        // Invoke method asynchronously
        ManagementBaseObject inParams =
            processClass.GetMethodParameters("Create");
        inParams["CommandLine"] = "calc.exe";
        processClass.InvokeMethod(
            handler, "Create", inParams, null);
      
        // Do something while method is executing
        while(!this.IsComplete) 
        {
            System.Threading.Thread.Sleep(1000);
        }

    }

    // Property allows accessing the result
    // object in the main function
    private ManagementBaseObject ReturnObject 
    {
        get 
        {
            return returnObject;
        }
    }

    // Delegate called when the method completes
    // and results are available
    private void NewObject(object sender,
        ObjectReadyEventArgs e) 
    {
        Console.WriteLine("New Object arrived!");
        returnObject = e.NewObject;
    }

    // Used to determine whether the method
    // execution has completed
    private bool IsComplete 
    {
        get 
        {
            return isComplete;
        }
    }

    private void Completed(object sender,
        CompletedEventArgs e)
    {
        isComplete = true;
        Console.WriteLine("Method invoked.");
    }

    public static void Main()
    {
        InvokeMethodAsync invokeMethod = new InvokeMethodAsync();

        return;

    }
}
//</Snippet1>