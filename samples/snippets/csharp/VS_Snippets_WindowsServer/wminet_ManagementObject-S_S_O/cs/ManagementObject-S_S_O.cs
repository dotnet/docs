//<Snippet1>
using System;
using System.Management;
   
class Sample
{
    public static int Main(string[] args) 
    {
        ObjectGetOptions opt = 
            new ObjectGetOptions(null, System.TimeSpan.MaxValue, true);
        ManagementObject o = 
            new ManagementObject(
            "root\\MyNamespace", "MyClass", opt);

        return 0;
    }
}
//</Snippet1>