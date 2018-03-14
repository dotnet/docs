//<Snippet1>
using System;
using System.Management;

// This sample demonstrates how to
// enumerate all methods in
// Win32_LogicalDisk class using the
// MethodDataEnumerator object.
class Sample_MethodDataEnumerator 
{
    public static int Main(string[] args) 
    {
        ManagementClass diskClass = 
            new ManagementClass("win32_logicaldisk");
        MethodDataCollection.MethodDataEnumerator diskEnumerator = 
            diskClass.Methods.GetEnumerator();
        while(diskEnumerator.MoveNext()) 
        {
            MethodData method = diskEnumerator.Current;
            Console.WriteLine("Method = " + method.Name);
        }   
        return 0;
    }
}
//</Snippet1>