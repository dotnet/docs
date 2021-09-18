public static partial class Program
{
    internal static void ZipTripleExample(
        IEnumerable<int> numbers,
        IEnumerable<char> letters,
        IEnumerable<string> emoji)
    {
        Console.WriteLine("Zip (TFirst, TSecond, TThird):");

        // <ZipTriple>
        foreach ((int number, char letter, string em) in numbers.Zip(letters, emoji))
        {
            Console.WriteLine(
                $"Number: {number} is zipped with letter: '{letter}' and emoji: {em}");
        }
        // This code produces the following output:
        //     Number: 1 is zipped with letter: 'A' and emoji: 🤓
        //     Number: 2 is zipped with letter: 'B' and emoji: 🔥
        //     Number: 3 is zipped with letter: 'C' and emoji: 🎉
        //     Number: 4 is zipped with letter: 'D' and emoji: 👀
        //     Number: 5 is zipped with letter: 'E' and emoji: ⭐
        //     Number: 6 is zipped with letter: 'F' and emoji: 💜
        // </ZipTriple>

        Console.WriteLine();
    }
}
