// <Snippet1>
using System;
using System.Reflection;
using System.Security;

class EventsSample
{
    public static void Main()
    { 
        try
        {
            // Creates a bitmask based on BindingFlags.
            BindingFlags myBindingFlags = BindingFlags.Instance | BindingFlags.Public;  
            Type myTypeEvent = typeof(System.Windows.Forms.Button);
            EventInfo[] myEventsBindingFlags = myTypeEvent.GetEvents(myBindingFlags);
            Console.WriteLine("\nThe events on the Button class with the specified BindingFlags are : ");
            for (int index = 0; index < myEventsBindingFlags.Length; index++)
            {
                Console.WriteLine(myEventsBindingFlags[index].ToString());
            }
        }
        catch(SecurityException e)
        {
            Console.WriteLine("SecurityException :" + e.Message);
        }
        catch(ArgumentNullException e)
        {
            Console.WriteLine("ArgumentNullException : " + e.Message);
        }
        catch(Exception e)
        {
            Console.WriteLine("Exception : " + e.Message);
        }
    }
}
// </Snippet1>