//<Snippet1>
using System;
using System.Management;

public class Sample 
{    
    public static void Main() 
    {

        ManagementClass envClass = 
            new ManagementClass("Win32_Environment");
        ManagementObject newInstance = 
            envClass.CreateInstance();
        newInstance["Name"] = "testEnvironmentVariable";
        newInstance["VariableValue"] = "testValue";
        newInstance["UserName"] = "<SYSTEM>";
        newInstance.Put(); //to commit the new instance.


    }
}
//</Snippet1>