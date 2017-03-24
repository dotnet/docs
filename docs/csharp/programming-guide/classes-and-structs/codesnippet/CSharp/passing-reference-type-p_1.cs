        class PassingRefByVal 
        {
            static void Change(int[] pArray)
            {
                pArray[0] = 888;  // This change affects the original element.
                pArray = new int[5] {-3, -1, -2, -3, -4};   // This change is local.
                System.Console.WriteLine("Inside the method, the first element is: {0}", pArray[0]);
            }

            static void Main() 
            {
                int[] arr = {1, 4, 5};
                System.Console.WriteLine("Inside Main, before calling the method, the first element is: {0}", arr [0]);

                Change(arr);
                System.Console.WriteLine("Inside Main, after calling the method, the first element is: {0}", arr [0]);
            }
        }
        /* Output:
            Inside Main, before calling the method, the first element is: 1
            Inside the method, the first element is: -3
            Inside Main, after calling the method, the first element is: 888
        */