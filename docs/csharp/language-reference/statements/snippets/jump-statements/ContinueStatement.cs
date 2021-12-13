namespace JumpStatements;

public static class ContinueStatement
{
    public static void Examples()
    {
        BasicExample();
    }

    private static void BasicExample()
    {
        // <BasicExample>
        for (int i = 0; i < 5; i++)
        {
            Console.Write($"Iteration {i}: ");
            
            if (i < 3)
            {
                Console.WriteLine("skip");
                continue;
            }
            
            Console.WriteLine("done");
        }
        // Output:
        // Iteration 0: skip
        // Iteration 1: skip
        // Iteration 2: skip
        // Iteration 3: done
        // Iteration 4: done
        // </BasicExample>
    }
}
