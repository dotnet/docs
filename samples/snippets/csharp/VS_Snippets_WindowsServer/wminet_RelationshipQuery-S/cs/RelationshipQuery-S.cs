//<Snippet1>
using System; 
using System.Management;
 
class Sample 
{ 
    public static void Main(string[] args) 
    { 
        // Full query string is specified
        // to the constructor
        RelationshipQuery q = 
            new RelationshipQuery(
            "references of {Win32_ComputerSystem.Name='mymachine'}");
   
        // Only the object of interest is 
        // specified to the constructor
        RelationshipQuery query = 
            new RelationshipQuery("Win32_Service.Name='Alerter'");
    }
}
//</Snippet1>