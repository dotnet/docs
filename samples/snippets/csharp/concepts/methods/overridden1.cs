namespace PersonEquals
{
    // <Snippet105>
    using System;

    public class Person
    {
        public String FirstName;

        public override bool Equals(object obj)
        {
            var p2 = obj as Person;
            if (p2 == null)
                return false;
            else
                return FirstName.Equals(p2.FirstName);
        }

        public override int GetHashCode()
        {
            return FirstName.GetHashCode();
        }
    }

    public class Example
    {
        public static void Main()
        {
            var p1 = new Person();
            p1.FirstName = "John";
            var p2 = new Person();
            p2.FirstName = "John";
            Console.WriteLine("p1 = p2: {0}", p1.Equals(p2));
        }
    }
    // The example displays the following output:
    //      p1 = p2: True
    // </Snippet105>
}
