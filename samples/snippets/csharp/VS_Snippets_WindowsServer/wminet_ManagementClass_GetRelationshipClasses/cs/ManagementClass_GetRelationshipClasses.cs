//<Snippet1>
using System;
using System.Management;

public class Sample
{
    public static void Main() 
    {
        ManagementClass c =
            new ManagementClass("CIM_LogicalDisk");

        foreach (ManagementClass r in c.GetSubclasses())
        {
            Console.WriteLine(
                "Instances of {0} are sub-classes",
                r["__CLASS"]);
        }
        
        foreach (ManagementClass r in c.GetRelationshipClasses())
        {
            Console.WriteLine(
                "{0} is a relationship class to " +
                c.ClassPath.ClassName,
                r["__CLASS"]);

            foreach (ManagementClass related in c.GetRelatedClasses(
                null, r.ClassPath.ClassName,
                "Association", null, null, null, null))
            {
                Console.WriteLine(
                    "{0} is related to " + c.ClassPath.ClassName,
                    related.ClassPath.ClassName);
            }
        } 

        return;
    }
}
//</Snippet1>