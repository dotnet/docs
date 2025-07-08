// <Snippet107>

public static class RefSwapExample
{
    static void Main()
    {
        int i = 2, j = 3;
        Console.WriteLine($"i = {i}  j = {j}");

        Swap(ref i, ref j);

        Console.WriteLine($"i = {i}  j = {j}");
    }

    static void Swap(ref int x, ref int y) =>
        (y, x) = (x, y);
}
// The example displays the following output:
//      i = 2  j = 3
//      i = 3  j = 2
// </Snippet107>
