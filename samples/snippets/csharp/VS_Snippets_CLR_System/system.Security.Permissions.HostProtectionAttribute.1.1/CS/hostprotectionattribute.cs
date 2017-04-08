//<Snippet1>
using System;
using System.IO;
using System.Threading;
using System.Security;
using System.Security.Policy;
using System.Security.Principal;
using System.Security.Permissions;
using System.Diagnostics;
using System.ComponentModel;
using System.Windows.Forms;

// If this application is run on a server that implements host protection, the 
// HostProtectionAttribute attribute is applied. If the application is run on   
// a server that is not host-protected, the attribute evaporates; it is not  
// detected and therefore not applied. Host protection can be configured with  
// members of the HostProtectionResource enumeration to customize the  
// protection offered.
// The primary intent of this sample is to show situations in which the 
// HostProtectionAttribute attribute might be meaningfully used. The  
// environment required to demonstrate a particular behavior is
// too complex to invoke within the scope of this sample.

class HostProtectionExample
{
    public static int Success = 100;
    
    //<Snippet2>
    // Use the enumeration flags to indicate that this method exposes 
    // shared state and self-affecting process management.
    // Either of the following attribute statements can be used to set the
    // resource flags.
    [HostProtectionAttribute(SharedState = true, 
        SelfAffectingProcessMgmt = true)]
    [HostProtectionAttribute(Resources = HostProtectionResource.SharedState |
         HostProtectionResource.SelfAffectingProcessMgmt)]
    private static void Exit(string Message, int Code)
    {
        // Exit the sample when an exception is thrown.
        Console.WriteLine("\nFAILED: " + Message + " " + Code.ToString());
        Environment.ExitCode = Code;
        Environment.Exit(Code);
    }
    //</Snippet2>

    //<Snippet3>
    // Use the enumeration flags to indicate that this method exposes shared 
    // state, self-affecting process management, and self-affecting threading.
    [HostProtectionAttribute(SharedState=true, SelfAffectingProcessMgmt=true,
         SelfAffectingThreading=true, UI=true)]
    // This method allows the user to quit the sample.
    private static void ExecuteBreak()
    {
        Console.WriteLine("Executing Debugger.Break.");
        Debugger.Break();
        Debugger.Log(1,"info","test message");
    }
    //</Snippet3>
    
    //<Snippet4>
    // Use the enumeration flags to indicate that this method exposes shared 
    // state, self-affecting threading, and the security infrastructure.
    [HostProtectionAttribute(SharedState=true, SelfAffectingThreading=true,
         SecurityInfrastructure=true)]
    // ApplyIdentity sets the current identity.
    private static int ApplyIdentity()
    {
        string[] roles = {"User"};
        try
        {
            AppDomain mAD = AppDomain.CurrentDomain;
            GenericPrincipal mGenPr = 
                new GenericPrincipal(WindowsIdentity.GetCurrent(), roles);
            mAD.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
            mAD.SetThreadPrincipal(mGenPr);
            return Success;
        }
        catch (Exception e)
        {
            Exit(e.ToString(), 5);
        }
        return 0;
    }
    //</Snippet4>

    // The following method is started on a separate thread.
    public static void WatchFileEvents()
    {
        try
        {
            Console.WriteLine("In the child thread.");
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = "C:\\Temp";
            
            // Watch for changes in LastAccess and LastWrite times, and
            // name changes to files or directories.
            watcher.NotifyFilter = NotifyFilters.LastAccess 
                | NotifyFilters.LastWrite
                | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            
            // Watch only text files.
            watcher.Filter = "*.txt";

            // Add event handlers.
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnChanged);
            watcher.Deleted += new FileSystemEventHandler(OnChanged);
            
            // Begin watching.
            watcher.EnableRaisingEvents = true;

            // Wait for the user to quit the program.
            Console.WriteLine("Event handlers have been enabled.");
            while(Console.Read()!='q');
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    //<Snippet6>
    // Use the enumeration flags to indicate that this method exposes 
    // synchronization and external threading.
    [HostProtectionAttribute(Synchronization=true, ExternalThreading=true)]
    private static void StartThread()
    {
        Thread t = new Thread(new ThreadStart(WatchFileEvents));
        
        // Start the new thread. On a uniprocessor, the thread is not given
        // any processor time until the main thread yields the processor.
        t.Start();
        
        // Give the new thread a chance to execute.
        Thread.Sleep(1000);
    }
    //</Snippet6>

    // Call methods that show the use of the HostProtectionResource enumeration.
    [HostProtectionAttribute(Resources=HostProtectionResource.All)]
    static int Main(string [] args)
    {
        try
        {
            // Show use of the HostProtectionResource.SharedState,
            // HostProtectionResource.SelfAffectingThreading, and
            // HostProtectionResource.Security enumeration values.
            ApplyIdentity();
            Directory.CreateDirectory("C:\\Temp");
            
            // Show use of the HostProtectionResource.Synchronization and
            // HostProtectionResource.ExternalThreading enumeration values.
            StartThread();
            Console.WriteLine("In the main thread.");
            Console.WriteLine("Deleting and creating 'MyTestFile.txt'.");
            if (File.Exists("C:\\Temp\\MyTestFile.txt"))
            {
                File.Delete("C:\\Temp\\MyTestFile.txt");
            }

            StreamWriter sr = File.CreateText("C:\\Temp\\MyTestFile.txt");
            sr.WriteLine ("This is my file.");
            sr.Close();
            Thread.Sleep(1000);
            
            // Show use of the HostProtectionResource.SharedState,
            // HostProtectionResource.SelfProcessMgmt,
            // HostProtectionResource.SelfAffectingThreading, and
            // HostProtectionResource.UI enumeration values.
            ExecuteBreak();
            
            // Show the use of the 
            // HostProtectionResource.ExternalProcessManagement 
            // enumeration value.
            MyControl myControl = new MyControl ();
            Console.WriteLine ("Enter 'q' to quit the sample.");
            return 100;
        }
        catch (Exception e)
        {
            Exit(e.ToString(), 0);
            return 0;
        }
    }

    // Define the event handlers.
    private static void OnChanged(object source, FileSystemEventArgs e)
    {
        // Specify whether a file is changed, created, or deleted.
        Console.WriteLine("In the OnChanged event handler.");
        Console.WriteLine("File: " + e.FullPath + " " + e.ChangeType);
    }
}

//<Snippet5>
// The following class is an example of code that exposes 
// external process management.
// Add the LicenseProviderAttribute to the control.
[LicenseProvider (typeof(LicFileLicenseProvider))]
public class MyControl : System.Windows.Forms.Control
{
    // Create a new, null license.
    private License license = null;

    [HostProtection (ExternalProcessMgmt = true)]
    public MyControl ()
    {
        // Determine if a valid license can be granted.
        bool isValid = LicenseManager.IsValid (typeof(MyControl));
        Console.WriteLine ("The result of the IsValid method call is " + 
            isValid.ToString ());
    }

    protected override void Dispose (bool disposing)
    {
        if (disposing)
        {
            if (license != null)
            {
                license.Dispose ();
                license = null;
            }
        }
    }
}
//</Snippet5>
//</Snippet1>
