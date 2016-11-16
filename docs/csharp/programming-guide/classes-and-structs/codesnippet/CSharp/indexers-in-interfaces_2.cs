    // Indexer on an interface:
    public interface ISomeInterface
    {
        // Indexer declaration:
        int this[int index]
        {
            get;
            set;
        }
    }

    // Implementing the interface.
    class IndexerClass : ISomeInterface
    {
        private int[] arr = new int[100];
        public int this[int index]   // indexer declaration
        {
            get
            {
                // The arr object will throw IndexOutOfRange exception.
                return arr[index];
            }
            set
            {
                arr[index] = value;
            }
        }
    }

    class MainClass
    {
        static void Main()
        {
            IndexerClass test = new IndexerClass();
            System.Random rand = new System.Random();
            // Call the indexer to initialize its elements.
            for (int i = 0; i < 10; i++)
            {
                test[i] = rand.Next();
            }
            for (int i = 0; i < 10; i++)
            {
                System.Console.WriteLine("Element #{0} = {1}", i, test[i]);
            }

            // Keep the console window open in debug mode.
            System.Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }
    }
    /* Sample output:
        Element #0 = 360877544
        Element #1 = 327058047
        Element #2 = 1913480832
        Element #3 = 1519039937
        Element #4 = 601472233
        Element #5 = 323352310
        Element #6 = 1422639981
        Element #7 = 1797892494
        Element #8 = 875761049
        Element #9 = 393083859
     */

