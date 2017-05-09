// <Snippet1>
using System;
using System.IO;

class Test 
{
    public static void Main() 
    {
        // Specify the directories you want to manipulate.
        DirectoryInfo di1 = new DirectoryInfo(@"c:\MyDir");

        try 
        {
            // Create the directories.
            di1.Create();
            di1.CreateSubdirectory("temp");

            //This operation will not be allowed because there are subdirectories.
            Console.WriteLine("I am about to attempt to delete {0}", di1.Name);
            di1.Delete();
            Console.WriteLine("The Delete operation was successful, which was unexpected.");
        } 
        catch (Exception) 
        {
            Console.WriteLine("The Delete operation failed as expected.");
        } 
        finally {}
    }
}
// </Snippet1>
