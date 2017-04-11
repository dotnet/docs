//<Snippet1>
using System;

namespace ArrayTypeMismatch
{
    class Class1
    {
        static void Main(string[] args) 
        {
            string[] names = {"Dog", "Cat", "Fish"};
            Object[] objs  = (Object[]) names;

            try 
            {
                objs[2] = "Mouse";

                foreach (object animalName in objs) 
                {
                    System.Console.WriteLine(animalName);
                }
            }
            catch (System.ArrayTypeMismatchException) 
            {
                // Not reached; "Mouse" is of the correct type.
                System.Console.WriteLine("Exception Thrown.");
            }

            try 
            {
                Object obj = (Object) 13;
                objs[2] = obj;
            }
            catch (System.ArrayTypeMismatchException) 
            {
                // Always reached, 13 is not a string.
                System.Console.WriteLine(
                    "New element is not of the correct type.");
            }
    
            // Set objs to an array of objects instead of 
            // an array of strings.
            objs  = new Object[3];
            try 
            {
                objs[0] = (Object) "Turtle";
                objs[1] = (Object) 12;
                objs[2] = (Object) 2.341;

                foreach (object element in objs) 
                {
                    System.Console.WriteLine(element);
                }
            }
            catch (System.ArrayTypeMismatchException) 
            {
                // ArrayTypeMismatchException is not thrown this time.
                System.Console.WriteLine("Exception Thrown.");
            }
        }
    }
}
//</Snippet1>
