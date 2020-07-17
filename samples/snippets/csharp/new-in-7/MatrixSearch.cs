using System;

namespace new_in_7
{
    static class MatrixSearch
    {
        public static void EverythingByValue()
        {
            // <SnippetEverythingByValue>
            (int i, int j) Find(int[,] matrix, Func<int, bool> predicate)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                    for (int j = 0; j < matrix.GetLength(1); j++)
                        if (predicate(matrix[i, j]))
                            return (i, j);
                return (-1, -1); // Not found
            }
            // </SnippetEverythingByValue>

            // <SnippetTestByValue>
            int[,] sourceMatrix = new int[10, 10];
            for (int x = 0; x < 10; x++)
                for (int y = 0; y < 10; y++)
                    sourceMatrix[x, y] = x * 10 + y;

            var indices = Find(sourceMatrix, (val) => val == 42);
            Console.WriteLine(indices);
            sourceMatrix[indices.i, indices.j] = 24;
            // </SnippetTestByValue>
        }

        public static void EverythingByRef()
        {
            // <SnippetEverythingByRef>
            ref int Find(int[,] matrix, Func<int, bool> predicate)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                    for (int j = 0; j < matrix.GetLength(1); j++)
                        if (predicate(matrix[i, j]))
                            return ref matrix[i, j];
                throw new InvalidOperationException("Not found");
            }
            // </SnippetEverythingByRef>

            // <SnippetTestByRef>
            int[,] sourceMatrix = new int[10, 10];
            for (int x = 0; x < 10; x++)
                for (int y = 0; y < 10; y++)
                    sourceMatrix[x, y] = x * 10 + y;

            ref var item = ref Find(sourceMatrix, (val) => val == 42);
            Console.WriteLine(item);
            item = 24;
            Console.WriteLine(sourceMatrix[4, 2]);
            // </SnippetTestByRef>
        }

        // <SnippetFindReturningRef>
        public static ref int Find(int[,] matrix, Func<int, bool> predicate)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if (predicate(matrix[i, j]))
                        return ref matrix[i, j];
            throw new InvalidOperationException("Not found");
        }
        // </SnippetFindReturningRef>
    }
}
