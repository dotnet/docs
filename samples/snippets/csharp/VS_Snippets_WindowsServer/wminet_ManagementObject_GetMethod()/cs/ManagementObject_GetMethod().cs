//<Snippet1>
using System;
using System.Management;
   
class Sample
{
    public static int Main(string[] args) 
    {
        ManagementObject o = 
            new ManagementObject("MyClass.Name='abc'");

        //this causes an implicit Get().
        string s = o["Name"].ToString();

        Console.WriteLine(s);

        //or :

        ManagementObject mObj = 
            new ManagementObject("MyClass.Name= 'abc'");
        mObj.Get(); //explicitly 
        // Now it is faster because the object
        // has already been retrieved.
        string property = mObj["Name"].ToString();

        Console.WriteLine(property);

        return 0;
    }
}
//</Snippet1>