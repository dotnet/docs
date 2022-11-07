namespace interfaces
{
    // <SnippetDefineIndexer>
    public interface ISomeInterface
    {
        //...

        // Indexer declaration:
        string this[int index]
        {
            get;
            set;
        }
    }
    //</SnippetDefineIndexer>

    //<SnippetImplementInterface>
    // Indexer on an interface:
    public interface IIndexInterface
    {
        // Indexer declaration:
        int this[int index]
        {
            get;
            set;
        }
    }

    // Implementing the interface.
    class IndexerClass : IIndexInterface
    {
        private int[] arr = new int[100];
        public int this[int index]   // indexer declaration
        {
            // The arr object will throw IndexOutOfRange exception.
            get => arr[index];
            set => arr[index] = value;
        }
    }
    //</SnippetImplementInterface>

    public class Indexers
    {
        public static void Examples()
        {
            // <SnippetExampleCode>
            IndexerClass test = new IndexerClass();
            System.Random rand = System.Random.Shared;
            // Call the indexer to initialize its elements.
            for (int i = 0; i < 10; i++)
            {
                test[i] = rand.Next();
            }
            for (int i = 0; i < 10; i++)
            {
                System.Console.WriteLine($"Element #{i} = {test[i]}");
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
            // </SnippetExampleCode>
        }
    }
}