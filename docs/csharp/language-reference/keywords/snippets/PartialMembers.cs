
using System.Text.RegularExpressions;

namespace PartialClassesAndMembers;

//<DeclaringPart>
partial class A
{
    int num = 0;
    void MethodA() { }
    partial void MethodC();
}
//</DeclaringPart>

//<ImplementingPart>
partial class A
{
    void MethodB() { }
    partial void MethodC() { }
}
//</ImplementingPart>

//<OptionalPartialMethod>
partial class MyPartialClass
{
    // Declaring definition
    partial void OnSomethingHappened(string s);
}

// This part can be in a separate file.
partial class MyPartialClass
{
    // Comment out this method and the program
    // will still compile.
    partial void OnSomethingHappened(string s) =>
        Console.WriteLine($"Something happened: {s}");
}
//</OptionalPartialMethod>

// <SourceGeneratorPartial>
public partial class RegExSourceGenerator
{
    [GeneratedRegex("cat|dog", RegexOptions.IgnoreCase, "en-US")]
    private static partial Regex CatOrDogGeneratedRegex();

    private static void EvaluateText(string text)
    {
        if (CatOrDogGeneratedRegex().IsMatch(text))
        {
            // Take action with matching text
        }
    }
}
// </SourceGeneratorPartial>

// <PartialMembersAll>
// Declaring declaration
public partial class PartialExamples
{
    /// <summary>
    /// Gets or sets the number of elements that the List can contain.
    /// </summary>
    public partial int Capacity { get; set; }

    /// <summary>
    /// Gets or sets the element at the specified index.
    /// </summary>
    /// <param name="index">The index</param>
    /// <returns>The string stored at that index</returns>
    public partial string this[int index] { get; set; }

    public partial string? TryGetAt(int index);
}

public partial class PartialExamples
{
    private List<string> _items = [
        "one",
        "two",
        "three",
        "four",
        "five"
        ];

    // Implementing declaration

    /// <summary>
    /// Gets or sets the number of elements that the List can contain.
    /// </summary>
    /// <remarks>
    /// If the value is less than the current capacity, the list will shrink to the
    /// new value. If the value is negative, the list isn't modified.
    /// </remarks>
    public partial int Capacity
    {
        get => _items.Count;
        set
        {
            if ((value != _items.Count) && (value >= 0))
            {
                _items.Capacity = value;
            }
        }
    }

    public partial string this[int index]
    {
        get => _items[index];
        set => _items[index] = value;
    }

    /// <summary>
    /// Gets the element at the specified index.
    /// </summary>
    /// <param name="index">The index</param>
    /// <returns>The string stored at that index, or null if out of bounds</returns>
    public partial string? TryGetAt(int index)
    {
        if (index < _items.Count)
        {
            return _items[index];
        }
        return null;
    }
}
// </PartialMembersAll>
