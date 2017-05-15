// <Snippet1>
using System;
using System.Reflection;

namespace Ambiguity
{
    class Myambiguous
    {
        //The first overload is typed to an Int32
        public static void Mymethod(Int32 number)
        {
           Console.WriteLine("I am from 'Int32' method");
        }

        //The second overload is typed to a string
        public static void Mymethod(string alpha)
        {
            Console.WriteLine("I am from 'string' method.");
        }

        public static void Main()
        {
            try
            {
                //The following does not cause as exception
                Mymethod(2);    // goes to Mymethod(Int32)
                Mymethod("3");  // goes to Mymethod(string)

                Type Mytype = Type.GetType("Ambiguity.Myambiguous");

                MethodInfo Mymethodinfo32 = Mytype.GetMethod("Mymethod", new Type[]{typeof(Int32)});
                MethodInfo Mymethodinfostr = Mytype.GetMethod("Mymethod", new Type[]{typeof(System.String)});

                //Invoke a method, utilizing a Int32 integer
                Mymethodinfo32.Invoke(null, new Object[]{2});

                //Invoke the method utilizing a string
                Mymethodinfostr.Invoke(null, new Object[]{"1"});

                //The following line causes an ambiguious exception
                MethodInfo Mymethodinfo = Mytype.GetMethod("Mymethod");
            }   // end of try block
            catch (AmbiguousMatchException ex)
            {
                Console.WriteLine("\n{0}\n{1}", ex.GetType().FullName, ex.Message);
            }
            catch
            {
                Console.WriteLine("\nSome other exception.");
            }
            return;
        }
    }
}

//This code produces the following output:
//
// I am from 'Int32' method
// I am from 'string' method.
// I am from 'Int32' method
// I am from 'string' method.

// System.Reflection.AmbiguousMatchException
// Ambiguous match found.
// </Snippet1>

