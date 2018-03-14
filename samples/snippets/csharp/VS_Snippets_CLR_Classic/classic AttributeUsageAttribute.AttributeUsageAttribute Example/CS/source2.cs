// <Snippet2>
using System;

namespace ExampleA
{
    // <Snippet3>
    public class ObsoleteAttribute{}
    // </Snippet3>
}

namespace ExampleB
{
    // <Snippet4>
    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    public class ObsoleteAttribute: Attribute {}
    // </Snippet4>

    // <Snippet5>
    public class NameAttribute: Attribute
    {
        string userName;
        int age;

        // This is a positional argument.
        public NameAttribute(string userName)
        {
            this.userName = userName;
        }

        public string UserName
        {
            get
            {
                return userName;
            }
        }

        // This is a named argument.
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
            }
        }
    }
    // </Snippet5>

    class Dummy
    {
        public static void Main()
        {
            Console.WriteLine("Dummy.Main()");
        }
    }
}
// </Snippet2>

