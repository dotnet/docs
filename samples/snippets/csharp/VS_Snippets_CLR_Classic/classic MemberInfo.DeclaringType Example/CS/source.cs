// <Snippet1>
using System;
using System.Reflection;

interface i 
{
   int GetValuue() ;
};
    // DeclaringType for MyVar is i.
 
    class A : i 
    {
        public int MyVar() { return 0; }
    };
    // DeclaringType for MyVar is A.
 
    class B : A 
    {
        new int MyVar() { return 0; }
    };
    // DeclaringType for MyVar is B.
 
    class C : A 
    {
    };
    // DeclaringType for MyVar is A.

}

namespace MyNamespace2 
{
    class Mymemberinfo 
    { 
 
        public static void Main(string[] args) 
        { 
 
            Console.WriteLine ("\nReflection.MemberInfo");
 
            //Get the Type and MemberInfo. 
            Type MyType =Type.GetType("System.IO.BufferedStream");
            MemberInfo[] Mymemberinfoarray = MyType.GetMembers();
 
            //Get and display the DeclaringType method. 
            Console.WriteLine("\nThere are {0} members in {1}.", Mymemberinfoarray.Length, MyType.FullName); 
 
            foreach (MemberInfo Mymemberinfo in Mymemberinfoarray) 
            {  
                Console.WriteLine("Declaring type of {0} is {1}.", Mymemberinfo.Name, Mymemberinfo.DeclaringType); 
            }
        }
    }
}

namespace MyNamespace3 
{
    class A 
    {
        virtual public void M () {}
    }
    class B: A 
    {
        override public void M () {}
    }
}
// </Snippet1>