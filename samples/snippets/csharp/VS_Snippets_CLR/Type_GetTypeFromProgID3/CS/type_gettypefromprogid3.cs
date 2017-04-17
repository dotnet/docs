// <Snippet1>
using System;
class MainApp 
{
    public static void Main()
    {
        try
        {
            // Use the ProgID localhost\HKEY_CLASSES_ROOT\DirControl.DirList.1.
            string theProgramID ="DirControl.DirList.1"; 
            // Use the server name localhost.
            string theServer="localhost";
            // Make a call to the method to get the type information for the given ProgID.
            Type myType =Type.GetTypeFromProgID(theProgramID,theServer);
            if(myType==null)
            {
                throw new Exception("Invalid ProgID or Server.");
            }
            Console.WriteLine("GUID for ProgID DirControl.DirList.1 is {0}.", myType.GUID);
        }
        catch(Exception e)
        {
            Console.WriteLine("An exception occurred.");
            Console.WriteLine("Source: {0}" , e.Source);
            Console.WriteLine("Message: {0}" , e.Message);
        }		
    }
}
// </Snippet1>
