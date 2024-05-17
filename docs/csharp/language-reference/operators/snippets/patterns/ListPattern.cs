namespace Patterns;

public static class ListPattern
{
    public static void Examples()
    {
        BasicExample();
        MatchAnyElement();
        UseSlice();
        SliceWithPattern();
    }

    private static void BasicExample()
    {
        // <BasicExample>
        int[] numbers = { 1, 2, 3 };

        Console.WriteLine(numbers is [1, 2, 3]);  // True
        Console.WriteLine(numbers is [1, 2, 4]);  // False
        Console.WriteLine(numbers is [1, 2, 3, 4]);  // False
        Console.WriteLine(numbers is [0 or 1, <= 2, >= 3]);  // True
        // </BasicExample>
    }

    private static void MatchAnyElement()
    {
        // <MatchAnyElement>
        List<int> numbers = new() { 1, 2, 3 };

        if (numbers is [var first, _, _])
        {
            Console.WriteLine($"The first element of a three-item list is {first}.");
        }
        // Output:
        // The first element of a three-item list is 1.
        // </MatchAnyElement>
    }

    private static void UseSlice()
    {
        // <UseSlice>
        Console.WriteLine(new[] { 1, 2, 3, 4, 5 } is [> 0, > 0, ..]);  // True
        Console.WriteLine(new[] { 1, 1 } is [_, _, ..]);  // True
        Console.WriteLine(new[] { 0, 1, 2, 3, 4 } is [> 0, > 0, ..]);  // False
        Console.WriteLine(new[] { 1 } is [1, 2, ..]);  // False

        Console.WriteLine(new[] { 1, 2, 3, 4 } is [.., > 0, > 0]);  // True
        Console.WriteLine(new[] { 2, 4 } is [.., > 0, 2, 4]);  // False
        Console.WriteLine(new[] { 2, 4 } is [.., 2, 4]);  // True

        Console.WriteLine(new[] { 1, 2, 3, 4 } is [>= 0, .., 2 or 4]);  // True
        Console.WriteLine(new[] { 1, 0, 0, 1 } is [1, 0, .., 0, 1]);  // True
        Console.WriteLine(new[] { 1, 0, 1 } is [1, 0, .., 0, 1]);  // False
        // </UseSlice>
    }

    private static void SliceWithPattern()
    {
        // <SliceWithPattern>
        void MatchMessage(string message)
        {
            var result = message is ['a' or 'A', .. var s, 'a' or 'A']
                ? $"Message {message} matches; inner part is {s}."
                : $"Message {message} doesn't match.";
            Console.WriteLine(result);
        }

        MatchMessage("aBBA");  // output: Message aBBA matches; inner part is BB.
        MatchMessage("apron");  // output: Message apron doesn't match.

        void Validate(int[] numbers)
        {
            var result = numbers is [< 0, .. { Length: 2 or 4 }, > 0] ? "valid" : "not valid";
            Console.WriteLine(result);
        }

        Validate(new[] { -1, 0, 1 });  // output: not valid
        Validate(new[] { -1, 0, 0, 1 });  // output: valid
        // </SliceWithPattern>
    }
}
