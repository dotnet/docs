//<Snippet75>
static class ParamsExample
{
    static void Main()
    {
        var fromArray = GetVowels(["apple", "banana", "pear"]);
        Console.WriteLine($"Vowels from array: '{fromArray}'");

        var fromMultipleArguments = GetVowels("apple", "banana", "pear");
        Console.WriteLine($"Vowels from multiple arguments: '{fromMultipleArguments}'");

        var fromNull = GetVowels(null);
        Console.WriteLine($"Vowels from null: '{fromNull}'");

        var fromNoValue = GetVowels();
        Console.WriteLine($"Vowels from no value: '{fromNoValue}'");
    }

    static string GetVowels(params string[]? input)
    {
        if (input == null || input.Length == 0)
        {
            return string.Empty;
        }

        char[] vowels = ['A', 'E', 'I', 'O', 'U'];
        return string.Concat(
            input.SelectMany(
                word => word.Where(letter => vowels.Contains(char.ToUpper(letter)))));
    }
}

// The example displays the following output:
//     Vowels from array: 'aeaaaea'
//     Vowels from multiple arguments: 'aeaaaea'
//     Vowels from null: ''
//     Vowels from no value: ''

//</Snippet75>
