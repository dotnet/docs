using System.Diagnostics;

namespace AttributeExamples;

public class Conditionals
{
    // <SnippetConditional>
    [Conditional("DEBUG")]
    static void DebugMethod()
    {
    }
    // </SnippetConditional>

    // <SnippetMultipleConditions>
    [Conditional("A"), Conditional("B")]
    static void DoIfAorB()
    {
        // ...
    }
    // </SnippetMultipleConditions>
}

// <SnippetConditionalConditionalAttribute>
[Conditional("DEBUG")]
public class DocumentationAttribute : System.Attribute
{
    string text;

    public DocumentationAttribute(string text)
    {
        this.text = text;
    }
}

class SampleClass
{
    // This attribute will only be included if DEBUG is defined.
    [Documentation("This method displays an integer.")]
    static void DoWork(int i)
    {
        System.Console.WriteLine(i.ToString());
    }
}
// </SnippetConditionalConditionalAttribute>
