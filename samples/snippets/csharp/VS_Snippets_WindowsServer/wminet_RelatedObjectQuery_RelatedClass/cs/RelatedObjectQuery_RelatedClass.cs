//<Snippet1>
using System; 
using System.Management;
 
class Sample 
{ 
    public static void Main(string[] args) 
    { 
        RelatedObjectQuery q = 
            new RelatedObjectQuery("Win32_ComputerSystem='MySystem'");
        q.RelatedClass = "Win32_Service";
    }
}
//</Snippet1>