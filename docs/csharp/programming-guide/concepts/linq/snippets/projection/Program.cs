// See https://aka.ms/new-console-template for more information

Console.OutputEncoding = System.Text.Encoding.UTF8;

// <NumbersAndLetters>
// An int array with 7 elements.
IEnumerable<int> numbers =
[
    1, 2, 3, 4, 5, 6, 7
];
// A char array with 6 elements.
IEnumerable<char> letters =
[
    'A', 'B', 'C', 'D', 'E', 'F'
];
// </NumbersAndLetters>
// <Emoji>
// A string array with 8 elements.
IEnumerable<string> emoji = 
[
    "🤓", "🔥", "🎉", "👀", "⭐", "💜", "✔", "💯"
];
// </Emoji>

Program.ZipTupleExample(numbers, letters);
Program.ZipTripleExample(numbers, letters, emoji);
Program.ZipResultExample(numbers, letters);
