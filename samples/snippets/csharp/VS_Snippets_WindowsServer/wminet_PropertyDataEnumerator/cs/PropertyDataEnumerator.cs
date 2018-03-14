//<Snippet1>
using System; 
using System.Management; 

// This sample demonstrates how to
// enumerate all properties in a 
// ManagementObject using the
// PropertyDataEnumerator object.
class Sample_PropertyDataEnumerator 
{
    public static int Main(string[] args) 
    { 
        ManagementObject disk = new 
            ManagementObject("Win32_LogicalDisk.DeviceID='C:'");
        PropertyDataCollection.PropertyDataEnumerator
            propertyEnumerator = disk.Properties.GetEnumerator();
        while(propertyEnumerator.MoveNext()) 
        {
            PropertyData p = 
                (PropertyData)propertyEnumerator.Current;
            Console.WriteLine("Property found: " + p.Name);
        }
        return 0;
    }
}
//</Snippet1>