    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Test with a non-empty list of integers.
                GenericList<int> gll = new GenericList<int>();
                gll.AddNode(5);
                gll.AddNode(4);
                gll.AddNode(3);
                int intVal = gll.GetLast();
                // The following line displays 5.
                System.Console.WriteLine(intVal);

                // Test with an empty list of integers.
                GenericList<int> gll2 = new GenericList<int>();
                intVal = gll2.GetLast();
                // The following line displays 0.
                System.Console.WriteLine(intVal);

                // Test with a non-empty list of strings.
                GenericList<string> gll3 = new GenericList<string>();
                gll3.AddNode("five");
                gll3.AddNode("four");
                string sVal = gll3.GetLast();
                // The following line displays five.
                System.Console.WriteLine(sVal);

                // Test with an empty list of strings.
                GenericList<string> gll4 = new GenericList<string>();
                sVal = gll4.GetLast();
                // The following line displays a blank line.
                System.Console.WriteLine(sVal);
            }
        }

        // T is the type of data stored in a particular instance of GenericList.
        public class GenericList<T>
        {
            private class Node
            {
                // Each node has a reference to the next node in the list.
                public Node Next;
                // Each node holds a value of type T.
                public T Data;
            }

            // The list is initially empty.
            private Node head = null;

            // Add a node at the beginning of the list with t as its data value.
            public void AddNode(T t)
            {
                Node newNode = new Node();
                newNode.Next = head;
                newNode.Data = t;
                head = newNode;
            }

            // The following method returns the data value stored in the last node in
            // the list. If the list is empty, the default value for type T is
            // returned.
            public T GetLast()
            {
                // The value of temp is returned as the value of the method. 
                // The following declaration initializes temp to the appropriate 
                // default value for type T. The default value is returned if the 
                // list is empty.
                T temp = default(T);

                Node current = head;
                while (current != null)
                {
                    temp = current.Data;
                    current = current.Next;
                }
                return temp;
            }
        }
    }