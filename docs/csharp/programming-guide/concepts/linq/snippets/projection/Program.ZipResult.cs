public static partial class Program
{
    internal static void ZipResultExample(
        IEnumerable<int> numbers,
        IEnumerable<char> letters)
    {
        Console.WriteLine("Zip (TFirst, TSecond, Func<TFirst, TSecond, TResult>):");

        // <ZipResultSelector>
        foreach (string result in
            numbers.Zip(letters, (number, letter) => $"{number} = {letter} ({(int)letter})"))
        {
            Console.WriteLine(result);
        }
        // This code produces the following output:
        //     1 = A (65)
        //     2 = B (66)
        //     3 = C (67)
        //     4 = D (68)
        //     5 = E (69)
        //     6 = F (70)
        // </ZipResultSelector>

        Console.WriteLine();
    }
}
