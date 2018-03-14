//<Snippet1>
using System; 
using System.Management;
 
class Sample 
{ 
    public static void Main(string[] args) 
    { 
        SelectQuery s = 
            new SelectQuery("SELECT * FROM Win32_LogicalDisk");

        //output is : SELECT * FROM Win32_LogicalDisk
        Console.WriteLine(s.QueryString);

        s.ClassName = "Win32_Process";

        //output is : SELECT * FROM Win32_Process
        Console.WriteLine(s.QueryString);
    }
}
//</Snippet1>