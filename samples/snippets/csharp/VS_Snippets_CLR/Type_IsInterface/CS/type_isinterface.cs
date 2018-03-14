// <Snippet1>
using System;
// Declare an interface.
interface myIFace
{
}
class MyIsInterface 
{
    public static void Main(string []args)
    {
        try
        {
            // Get the IsInterface attribute for myIFace.
            bool myBool1 = typeof(myIFace).IsInterface;    
            //Display the IsInterface attribute for myIFace.
            Console.WriteLine("Is the specified type an interface? {0}.", myBool1);
            // Get the attribute IsInterface for MyIsInterface.
            bool myBool2 = typeof(MyIsInterface).IsInterface;    
            //Display the IsInterface attribute for MyIsInterface.
            Console.WriteLine("Is the specified type an interface? {0}.", myBool2);         
        }
        catch(Exception e)
        {
            Console.WriteLine("\nAn exception occurred: {0}.", e.Message);
        }
    }
}
// </Snippet1>