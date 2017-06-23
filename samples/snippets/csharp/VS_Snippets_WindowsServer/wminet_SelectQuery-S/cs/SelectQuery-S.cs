//<Snippet1>
using System; 
using System.Management;
 
class Sample 
{ 
    public static void Main(string[] args) 
    { 
        SelectQuery sQuery = 
            new SelectQuery(
            "SELECT * FROM Win32_Service WHERE State='Stopped'"); 

        // or 

        // This is equivalent to "SELECT * FROM Win32_Service"
        SelectQuery query = new SelectQuery("Win32_Service");
    }
}
//</Snippet1>