namespace JumpStatements;

public static class GotoStatement
{
    public static void Examples()
    {
        NestedLoops();
        GotoInSwitchExample.Main();
    }

    private static void NestedLoops()
    {
        // <NestedLoops>
        var matrices = new Dictionary<string, int[][]>
        {
            ["A"] = new[]
            {
                new[] { 1, 2, 3, 4 },
                new[] { 4, 3, 2, 1 }
            },
            ["B"] = new[]
            {
                new[] { 5, 6, 7, 8 },
                new[] { 8, 7, 6, 5 }
            },
        };

        CheckMatrices(matrices, 4);

        void CheckMatrices(Dictionary<string, int[][]> matrixLookup, int target)
        {
            foreach (var (key, matrix) in matrixLookup)
            {
                for (int row = 0; row < matrix.Length; row++)
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        if (matrix[row][col] == target)
                        {
                            goto Found;
                        }
                    }
                }
                Console.WriteLine($"Not found {target} in matrix {key}.");
                continue;

            Found:
                Console.WriteLine($"Found {target} in matrix {key}.");
            }
        }
        // Output:
        // Found 4 in matrix A.
        // Not found 4 in matrix B.
        // </NestedLoops>
    }
}
