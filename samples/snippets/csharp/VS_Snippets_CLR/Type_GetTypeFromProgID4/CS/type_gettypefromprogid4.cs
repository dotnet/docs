// <Snippet1>

using System;
class MainApp 
{
    public static void Main()
    {
        try
        {
            // Use server localhost.
            string theServer="localhost";
            // Use  ProgID HKEY_CLASSES_ROOT\DirControl.DirList.1.
            string myString1 ="DirControl.DirList.1"; 
            // Use a wrong ProgID WrongProgID.
            string myString2 ="WrongProgID"; 
            // Make a call to the method to get the type information for the given ProgID.
            Type myType1 =Type.GetTypeFromProgID(myString1,theServer,true);
            Console.WriteLine("GUID for ProgID DirControl.DirList.1 is {0}.", myType1.GUID);
            // Throw an exception because the ProgID is invalid and the throwOnError 
            // parameter is set to True.
            Type myType2 =Type.GetTypeFromProgID(myString2, theServer, true);
        }
        catch(Exception e)
        {
            Console.WriteLine("An exception occurred. The ProgID is wrong.");
            Console.WriteLine("Source: {0}" , e.Source);
            Console.WriteLine("Message: {0}" , e.Message);
        }
    }
}
// </Snippet1>
