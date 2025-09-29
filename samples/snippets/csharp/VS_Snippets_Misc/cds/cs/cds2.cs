using System.Threading;

class Lazy
{
    private static void Test5()
    {
        // <snippet13>
        // Initialize a value per thread, per instance.
        ThreadLocal<int[][]> _scratchArrays =
            new(InitializeArrays);

        static int[][] InitializeArrays() => [new int[10], new int[10]];

        // Use the thread-local data.
        int i = 8;
        int[] tempArr = _scratchArrays.Value[i];
        //</snippet13>
    }
}
