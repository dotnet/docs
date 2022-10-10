using System.Text.RegularExpressions;

static partial class Program
{ 
    private static readonly Regex s_abcOrDefGeneratedRegex = AbcOrDefGeneratedRegex();

    [GeneratedRegex("abc|def", RegexOptions.IgnoreCase | RegexOptions.Compiled, "en-US")]
    private static partial Regex AbcOrDefGeneratedRegex();

    private static void EvaluateText(string text)
    {
        if (s_abcOrDefGeneratedRegex.IsMatch(text))
        {
        }
    }

    private static void Main()
    {
        EvaluateText("deftones");
    }
}

static partial class Program
{
    [GeneratedRegex(@"(a|bc)d")]
    private static partial Regex Example();

    [GeneratedRegex("[ab]*[bc]")]
    private static partial Regex AnotherExample();

    [GeneratedRegex("Monday|Tuesday|Wednesday|Thursday|Friday|Saturday|Sunday")]
    private static partial Regex DaysOfWeek();
}
