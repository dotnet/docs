   
    class Program
    {
        class MyClass
        {
            public void MyMethod() { }
        }

        static void Main(string[] args)
        {
            // Set a breakpoint here to see that mc = null.
            // However, the compiler considers it "unassigned."
            // and generates a compiler error if you try to
            // use the variable.
            MyClass mc;

            // Now the variable can be used, but...
            mc = null;

            // ... a method call on a null object raises 
            // a run-time NullReferenceException.
            // Uncomment the following line to see for yourself.
            // mc.MyMethod();

            // Now mc has a value.
            mc = new MyClass();

            // You can call its method.
            mc.MyMethod();

            // Set mc to null again. The object it referenced
            // is no longer accessible and can now be garbage-collected.
            mc = null;

            // A null string is not the same as an empty string.
            string s = null;
            string t = String.Empty; // Logically the same as ""
            
            // Equals applied to any null object returns false.
            bool b = (t.Equals(s));
            Console.WriteLine(b);

            // Equality operator also returns false when one
            // operand is null.
            Console.WriteLine("Empty string {0} null string", s == t ? "equals": "does not equal");

            // Returns true.
            Console.WriteLine("null == null is {0}", null == null);


            // A value type cannot be null
            // int i = null; // Compiler error!

            // Use a nullable value type instead:
            int? i = null;

            // Keep the console window open in debug mode.
            System.Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();

        }
    }