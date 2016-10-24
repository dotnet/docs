        class Program
        {
            static void Main()
            {
                int[] arr = { 0, 1, 2, 3, 4 };
                List<int> list = new List<int>();

                for (int x = 5; x < 10; x++)
                {
                    list.Add(x);
                }

                ProcessItems<int>(arr);
                ProcessItems<int>(list);
            }

            static void ProcessItems<T>(IList<T> coll)
            {
                // IsReadOnly returns True for the array and False for the List.
                System.Console.WriteLine
                    ("IsReadOnly returns {0} for this collection.",
                    coll.IsReadOnly);

                // The following statement causes a run-time exception for the 
                // array, but not for the List.
                //coll.RemoveAt(4);

                foreach (T item in coll)
                {
                    System.Console.Write(item.ToString() + " ");
                }
                System.Console.WriteLine();
            }
        }