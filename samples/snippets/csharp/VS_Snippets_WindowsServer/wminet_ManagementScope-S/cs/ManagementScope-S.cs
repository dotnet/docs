//<Snippet1>
using System;
using System.Management;
public class RemoteConnect 
{
    public static void Main() 
    {
        /*// Build an options object for the remote connection
        //   if you plan to connect to the remote
        //   computer with a different user name
        //   and password than the one you are currently using
          
             ConnectionOptions options = 
                 new ConnectionOptions();
                 
             // and then set the options.Username and 
             // options.Password properties to the correct values
             // and also set 
             // options.Authority = "ntlmdomain:DOMAIN";
             // and replace DOMAIN with the remote computer's
             // domain.  You can also use Kerberos instead
             // of ntlmdomain.
        */

        // Make a connection to a remote computer.
        // Replace the "FullComputerName" section of the
        // string "\\\\FullComputerName\\root\\cimv2" with
        // the full computer name or IP address of the
        // remote computer.
        ManagementScope scope = 
            new ManagementScope(
            "\\\\FullComputerName\\root\\cimv2");
        scope.Connect();

        // Use this code if you are connecting with a 
        // different user name and password:
        //
        // ManagementScope scope = 
        //    new ManagementScope(
        //        "\\\\FullComputerName\\root\\cimv2", options);
        // scope.Connect();

        //Query system for Operating System information
        ObjectQuery query = new ObjectQuery(
            "SELECT * FROM Win32_OperatingSystem");
        ManagementObjectSearcher searcher = 
            new ManagementObjectSearcher(scope,query);

        ManagementObjectCollection queryCollection = searcher.Get();
        foreach ( ManagementObject m in queryCollection)
        {
            // Display the remote computer information
            Console.WriteLine("Computer Name : {0}", 
                m["csname"]);
            Console.WriteLine("Windows Directory : {0}", 
                m["WindowsDirectory"]);
            Console.WriteLine("Operating System: {0}",  
                m["Caption"]);
            Console.WriteLine("Version: {0}", m["Version"]);
            Console.WriteLine("Manufacturer : {0}", 
                m["Manufacturer"]);
        }
    }
}
//</Snippet1>