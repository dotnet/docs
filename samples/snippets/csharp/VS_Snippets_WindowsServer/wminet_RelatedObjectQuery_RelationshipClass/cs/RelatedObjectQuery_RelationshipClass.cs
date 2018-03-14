//<Snippet1>
using System; 
using System.Management;
 
class Sample 
{ 
    public static void Main(string[] args) 
    { 
        RelatedObjectQuery q = 
            new RelatedObjectQuery("Win32_Service='TCP/IP'");
        q.RelationshipClass = "Win32_DependentService";
    }
}
//</Snippet1>