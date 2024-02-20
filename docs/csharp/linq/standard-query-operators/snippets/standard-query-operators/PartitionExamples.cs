
namespace StandardQueryOperators;
public class PartitionExamples
{
    public static void RunAllSnippets()
    {
        Console.WriteLine("Take");
        TakeExample();
        Console.WriteLine("Skip");
        SkipExample();
        Console.WriteLine("TakeWhile");
        TakeWhileExample();
        Console.WriteLine("SkipWhile");
        SkipWhileExample();
        Console.WriteLine("Chuck");
        ChuckExample();
    }

    private static void TakeExample()
    {
        // <Take>
        foreach (int number in Enumerable.Range(0, 8).Take(3))
        {
            Console.WriteLine(number);
        }
        // This code produces the following output:
        // 0
        // 1
        // 2
        // </Take>
    }

    private static void SkipExample()
    {
        // <Skip>
        foreach (int number in Enumerable.Range(0, 8).Skip(3))
        {
            Console.WriteLine(number);
        }
        // This code produces the following output:
        // 3
        // 4
        // 5
        // 6
        // 7
        // </Skip>
    }


    private static void TakeWhileExample()
    {
        // <TakeWhile>
        foreach (int number in Enumerable.Range(0, 8).TakeWhile(n => n < 5))
        {
            Console.WriteLine(number);
        }
        // This code produces the following output:
        // 0
        // 1
        // 2
        // 3
        // 4
        // </TakeWhile>
    }


    private static void SkipWhileExample()
    {
        // <SkipWhile>
        foreach (int number in Enumerable.Range(0, 8).SkipWhile(n => n < 5))
        {
            Console.WriteLine(number);
        }
        // This code produces the following output:
        // 5
        // 6
        // 7
        // </SkipWhile>
    }

private static void ChuckExample()
    {
        // <Chunk>
        int chunkNumber = 1;
        foreach (int[] chunk in Enumerable.Range(0, 8).Chunk(3))
        {
            Console.WriteLine($"Chunk {chunkNumber++}:");
            foreach (int item in chunk)
            {
                Console.WriteLine($"    {item}");
            }

            Console.WriteLine();
        }
        // This code produces the following output:
        // Chunk 1:
        //    0
        //    1
        //    2
        //
        //Chunk 2:
        //    3
        //    4
        //    5
        //
        //Chunk 3:
        //    6
        //    7
        // </Chunk>
    }
}
