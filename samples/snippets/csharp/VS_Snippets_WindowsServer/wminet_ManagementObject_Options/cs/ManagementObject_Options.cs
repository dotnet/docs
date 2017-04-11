//<Snippet1>
using System;
using System.Management;
public class Sample 
{
    public static void Main() 
    {
        ///Contains default options
        ManagementObject o = 
            new ManagementObject("Win32_Process.Name='notepad.exe'"); 

        // Replace default options, 
        // in this case requesting retrieval of
        // amended qualifiers along with the WMI object.
        o.Options = new ObjectGetOptions(
            null, System.TimeSpan.MaxValue, true);
    }
}
//</Snippet1>