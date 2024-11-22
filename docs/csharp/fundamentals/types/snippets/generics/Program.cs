namespace generics
{
    //---------------------------------------------------------------------------
    //<Snippet1>
    // Declare the generic class.
    public class GenericList<T>
    {
        public void Add(T item) { }
    }

    public class ExampleClass { }

    class TestGenericList
    {
        static void Main()
        {
            // Create a list of type int.
            GenericList<int> list1 = new();
            list1.Add(1);

            // Create a list of type string.
            GenericList<string> list2 = new();
            list2.Add("");

            // Create a list of type ExampleClass.
            GenericList<ExampleClass> list3 = new();
            list3.Add(new ExampleClass());
        }
    }
    //</Snippet1>
    namespace SecondExample
    {
        //<Snippet2>
        // Type parameter T in angle brackets.
        public class GenericList<T>
        {
            // The nested class is also generic, and
            // holds a data item of type T.
            private class Node(T t)
            {
                // T as property type.
                public T Data { get; set; } = t;

                public Node? Next { get; set; }
            }

            // First item in the linked list
            private Node? head;

            // T as parameter type.
            public void AddHead(T t)
            {
                Node n = new(t);
                n.Next = head;
                head = n;
            }

            // T in method return type.
            public IEnumerator<T> GetEnumerator()
            {
                Node? current = head;

                while (current is not null)
                {
                    yield return current.Data;
                    current = current.Next;
                }
            }
        }
        //</Snippet2>
    }
    namespace ThirdExample
    {
        using SecondExample;
        class TestGenericList
        {
            static void Main()
            {
                //<Snippet3>
                // A generic list of int.
                GenericList<int> list = new();

                // Add ten int values.
                for (int x = 0; x < 10; x++)
                {
                    list.AddHead(x);
                }

                // Write them to the console.
                foreach (int i in list)
                {
                    Console.WriteLine(i);
                }

                Console.WriteLine("Done");
                //</Snippet3>
            }
        }
    }
}
