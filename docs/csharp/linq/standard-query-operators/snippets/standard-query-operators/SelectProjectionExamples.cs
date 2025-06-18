using System.Text;

namespace StandardQueryOperators;
internal class SelectProjectionExamples
{
    public static void RunAllSnippets()
    {
        SelectSimpleQuerySyntax();
        SelectSimpleMethodSyntax();
        SelectManyQuerySyntax();
        SelectManyMethodSyntax();
        NumbersAndLetters();
        SelectVsSelectMany();
    }

    private static void SelectSimpleQuerySyntax()
    {
        // <SelectSimpleQuery>
        List<string> words = ["an", "apple", "a", "day"];

        var query = from word in words
                    select word.Substring(0, 1);

        foreach (string s in query)
        {
            Console.WriteLine(s);
        }

        /* This code produces the following output:

            a
            a
            a
            d
        */
        // </SelectSimpleQuery>
    }

    private static void SelectSimpleMethodSyntax()
    {
        // <SelectSimpleMethod>
        List<string> words = ["an", "apple", "a", "day"];

        var query = words.Select(word => word.Substring(0, 1));

        foreach (string s in query)
        {
            Console.WriteLine(s);
        }

        /* This code produces the following output:

            a
            a
            a
            d
        */
        // </SelectSimpleMethod>
    }
    private static void SelectManyQuerySyntax()
    {
        // <SelectManyQuery>
        List<string> phrases = ["an apple a day", "the quick brown fox"];

        var query = from phrase in phrases
                    from word in phrase.Split(' ')
                    select word;

        foreach (string s in query)
        {
            Console.WriteLine(s);
        }

        /* This code produces the following output:

            an
            apple
            a
            day
            the
            quick
            brown
            fox
        */
        // </SelectManyQuery>
    }

    private static void SelectManyMethodSyntax()
    {
        // <SelectManyMethod>
        List<string> phrases = ["an apple a day", "the quick brown fox"];

        var query = phrases.SelectMany(phrase => phrase.Split(' '));

        foreach (string s in query)
        {
            Console.WriteLine(s);
        }

        /* This code produces the following output:

            an
            apple
            a
            day
            the
            quick
            brown
            fox
        */
        // </SelectManyMethod>
    }
    private static void NumbersAndLetters()
    {
        Console.OutputEncoding = Encoding.UTF8;

        // <NumbersAndLetters>
        // An int array with 7 elements.
        IEnumerable<int> numbers = [1, 2, 3, 4, 5, 6, 7];
        // A char array with 6 elements.
        IEnumerable<char> letters = ['A', 'B', 'C', 'D', 'E', 'F'];
        // </NumbersAndLetters>

        // <Emoji>
        // A string array with 8 elements.
        IEnumerable<string> emoji = [ "🤓", "🔥", "🎉", "👀", "⭐", "💜", "✔", "💯"];
        // </Emoji>

        // <SelectManyQuery2>
        var query = from number in numbers
                    from letter in letters
                    select (number, letter);

        foreach (var item in query)
        {
            Console.WriteLine(item);
        }
        // </SelectManyQuery2>

        // <SelectManyMethod2>
        var method = numbers
            .SelectMany(number => letters,
            (number, letter) => (number, letter));

        foreach (var item in method)
        {
            Console.WriteLine(item);
        }
        // </SelectManyMethod2>

        ZipTupleExample(numbers, letters);
        ZipTripleExample(numbers, letters, emoji);
        ZipResultExample(numbers, letters);
    }

    private static void ZipTupleExample(
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

    private static void ZipResultExample(
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

    private static void ZipTripleExample(
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

    // <SelectVsSelectMany>
    class Bouquet
    {
        public required List<string> Flowers { get; init; }
    }

    static void SelectVsSelectMany()
    {
        List<Bouquet> bouquets =
        [
            new Bouquet { Flowers = ["sunflower", "daisy", "daffodil", "larkspur"] },
            new Bouquet { Flowers = ["tulip", "rose", "orchid"] },
            new Bouquet { Flowers = ["gladiolis", "lily", "snapdragon", "aster", "protea"] },
            new Bouquet { Flowers = ["larkspur", "lilac", "iris", "dahlia"] }
        ];

        IEnumerable<List<string>> query1 = bouquets.Select(bq => bq.Flowers);

        IEnumerable<string> query2 = bouquets.SelectMany(bq => bq.Flowers);

        Console.WriteLine("Results by using Select():");
        // Note the extra foreach loop here.
        foreach (IEnumerable<string> collection in query1)
        {
            foreach (string item in collection)
            {
                Console.WriteLine(item);
            }
        }

        Console.WriteLine("\nResults by using SelectMany():");
        foreach (string item in query2)
        {
            Console.WriteLine(item);
        }
    }
    // </SelectVsSelectMany>
}
