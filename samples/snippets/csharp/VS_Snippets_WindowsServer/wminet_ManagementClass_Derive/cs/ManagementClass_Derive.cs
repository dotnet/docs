//<Snippet1>
using System;
using System.Management;

public class Sample 
{    
    public static void Main() 
    {
        ManagementClass existingClass = 
            new ManagementClass("CIM_Service");
        ManagementClass newClass = existingClass.Derive("My_Service");
        newClass.Put(); //to commit the new class to the WMI repository.

    }
}
//</Snippet1>