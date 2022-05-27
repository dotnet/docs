public static partial class Program
{
    internal static void ZipTupleExample(
        IEnumerable<int> numbers,
        IEnumerable<char> letters)
    {
        Console.WriteLine("Zip (TFirst, TSecond):");

        // <ZipTuple>
        foreach ((int number, char letter) in numbers.Zip(letters))
        {
            Console.WriteLine($"Number: {number} zipped with letter: '{letter}'");
        }
        // This code produces the following output:
        //     Number: 1 zipped with letter: 'A'
        //     Number: 2 zipped with letter: 'B'
        //     Number: 3 zipped with letter: 'C'
        //     Number: 4 zipped with letter: 'D'
        //     Number: 5 zipped with letter: 'E'
        //     Number: 6 zipped with letter: 'F'
        // </ZipTuple>

        Console.WriteLine();
    }
}
