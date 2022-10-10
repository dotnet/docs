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
