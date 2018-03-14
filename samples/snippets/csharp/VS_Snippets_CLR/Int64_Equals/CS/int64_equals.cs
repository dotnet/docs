// System.Int64.Equals(Object)

/* 
   The following program demonstrates the 'Equals(Object)' method
   of struct 'Int64'. This compares an instance of 'Int64' with the
   passed in object and returns true if they are equal.
*/

using System;
class MyInt64_Equals
{
     public static void Main()
     {
         try
         {
// <Snippet1>            
            Int64 myVariable1 = 80;
            Int64 myVariable2 = 80;

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

