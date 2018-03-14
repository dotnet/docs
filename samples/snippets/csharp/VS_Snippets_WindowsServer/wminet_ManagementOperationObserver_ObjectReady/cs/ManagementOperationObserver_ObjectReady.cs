//<Snippet1>
using System;
using System.Management;

// This example demonstrates how
// to perform an asynchronous instance enumeration.

public class EnumerateInstancesAsync 
{
    public EnumerateInstancesAsync()
    {
        // Enumerate asynchronously using Object Searcher
        // ===============================================

        // Instantiate an object searcher with the query
        ManagementObjectSearcher searcher = 
            new ManagementObjectSearcher(new
            SelectQuery("Win32_Service")); 

        // Create a results watcher object,
        // and handler for results and completion
        ManagementOperationObserver results = new
            ManagementOperationObserver();
        
        // Attach handler to events for results and completion
        results.ObjectReady += new 
            ObjectReadyEventHandler(this.NewObject);
        results.Completed += new 
            CompletedEventHandler(this.Done);

        // Call the asynchronous overload of Get()
        // to start the enumeration
        searcher.Get(results);
          
        // Do something else while results
        // arrive asynchronously
        while (!this.Completed)
        {
            System.Threading.Thread.Sleep (1000);
        }
 
        this.Reset();
        
    }

    private bool isCompleted = false;

    private void NewObject(object sender,
        ObjectReadyEventArgs obj) 
    {
        Console.WriteLine("Service : {0}, State = {1}", 
            obj.NewObject["Name"],
            obj.NewObject["State"]);
    }

    private bool Completed 
    {
        get
        { 
            return isCompleted;
        }
    }
    
    private void Reset()   
    {
        isCompleted = false;
    }

    private void Done(object sender,
        CompletedEventArgs obj) 
    {
        isCompleted = true;
    }

    public static void Main()
    {
        EnumerateInstancesAsync example =
            new EnumerateInstancesAsync();

        return;
    }
    
}
//</Snippet1>