// System.Int16.Equals(Object)

/* 
   The following program demonstrates the 'Equals(Object)' method
   of struct 'Int16'. This compares an instance of 'Int16' with the
   passed in object and returns true if they are equal.
*/

using System;
class MyInt16_Equals 
{
     public static void Main()
     {
         try
         {
// <Snippet1>            
            Int16 myVariable1 = 20;
            Int16 myVariable2 = 20;

            // Get and display the declaring type.
            Console.WriteLine("\nType of 'myVariable1' is '{0}' and"+
                 " value is :{1}",myVariable1.GetType(), myVariable1); 
            Console.WriteLine("Type of 'myVariable2' is '{0}' and"+
                 " value is :{1}",myVariable2.GetType(), myVariable2);

            // Compare 'myVariable1' instance with 'myVariable2' Object.
            if( myVariable1.Equals( myVariable2 ) )
               Console.WriteLine( "\nStructures 'myVariable1' and "+
                     "'myVariable2' are equal");
            else
               Console.WriteLine( "\nStructures 'myVariable1' and "+
                     "'myVariable2' are not equal");
            
// </Snippet1>            
         }
         catch(Exception e)
         {
            Console.WriteLine("Exception :{0}", e.Message);
         }
     }
}

