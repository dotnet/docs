using System.Text.RegularExpressions;

// Call all the example methods
PositiveCharacterGroup();
Console.WriteLine();

CharacterRange();
Console.WriteLine();

NegativeCharacterGroup();
Console.WriteLine();

AnyCharacterSingleline();
Console.WriteLine();

AnyCharacterMultiline();
Console.WriteLine();

UnicodeCategory();
Console.WriteLine();

NegativeUnicodeCategory();
Console.WriteLine();

WordCharacter();
Console.WriteLine();

NonWordCharacter();
Console.WriteLine();

WhitespaceCharacter();
Console.WriteLine();

NonWhitespaceCharacter();
Console.WriteLine();

DigitCharacter();
Console.WriteLine();

NonDigitCharacter();
Console.WriteLine();

GetUnicodeCategory();
Console.WriteLine();

CharacterClassSubtraction();

// <PositiveCharacterGroup>
static void PositiveCharacterGroup()
{
    string pattern = @"gr[ae]y\s\S+?[\s\p{P}]";
    string input = "The gray wolf jumped over the grey wall.";
    MatchCollection matches = Regex.Matches(input, pattern);
    foreach (Match match in matches)
        Console.WriteLine($"'{match.Value}'");
}
// The example displays the following output:
//       'gray wolf '
//       'grey wall.'
// </PositiveCharacterGroup>

// <CharacterRange>
static void CharacterRange()
{
    string pattern = @"\b[A-Z]\w*\b";
    string input = "A city Albany Zulu maritime Marseilles";
    foreach (Match match in Regex.Matches(input, pattern))
        Console.WriteLine(match.Value);
}
// The example displays the following output:
//       A
//       Albany
//       Zulu
//       Marseilles
// </CharacterRange>

// <NegativeCharacterGroup>
static void NegativeCharacterGroup()
{
    string pattern = @"\bth[^o]\w+\b";
    string input = "thought thing though them through thus thorough this";
    foreach (Match match in Regex.Matches(input, pattern))
        Console.WriteLine(match.Value);
}
// The example displays the following output:
//       thing
//       them
//       through
//       thus
//       this
// </NegativeCharacterGroup>

// <AnyCharacterSingleline>
static void AnyCharacterSingleline()
{
    string pattern = @"\b.*[.?!;:](\s|\z)";
    string input = "this. what: is? go, thing.";
    foreach (Match match in Regex.Matches(input, pattern))
        Console.WriteLine(match.Value);
}
// The example displays the following output:
//       this. what: is? go, thing.
// </AnyCharacterSingleline>

// <AnyCharacterMultiline>
static void AnyCharacterMultiline()
{
    string pattern = "^.+";
    string input = "This is one line and" + Environment.NewLine + "this is the second.";
    foreach (Match match in Regex.Matches(input, pattern))
        Console.WriteLine(Regex.Escape(match.Value));

    Console.WriteLine();
    foreach (Match match in Regex.Matches(input, pattern, RegexOptions.Singleline))
        Console.WriteLine(Regex.Escape(match.Value));
}
// The example displays the following output:
//       This\ is\ one\ line\ and\r
//
//       This\ is\ one\ line\ and\r\nthis\ is\ the\ second\.
// </AnyCharacterMultiline>

// <UnicodeCategory>
static void UnicodeCategory()
{
    string pattern = @"\b(\p{IsGreek}+(\s)?)+\p{Pd}\s(\p{IsBasicLatin}+(\s)?)+";
    string input = "Κατα Μαθθαίον - The Gospel of Matthew";

    Console.WriteLine(Regex.IsMatch(input, pattern));        // Displays True.
}
// </UnicodeCategory>

// <NegativeUnicodeCategory>
static void NegativeUnicodeCategory()
{
    string pattern = @"(\P{Sc})+";

    string[] values = { "$164,091.78", "£1,073,142.68", "73¢", "€120" };
    foreach (string value in values)
        Console.WriteLine(Regex.Match(value, pattern).Value);
}
// The example displays the following output:
//       164,091.78
//       1,073,142.68
//       73
//       120
// </NegativeUnicodeCategory>

// <WordCharacter>
static void WordCharacter()
{
    string pattern = @"(\w)\1";
    string[] words = { "trellis", "seer", "latter", "summer",
                       "hoarse", "lesser", "aardvark", "stunned" };
    foreach (string word in words)
    {
        Match match = Regex.Match(word, pattern);
        if (match.Success)
            Console.WriteLine($"'{match.Value}' found in '{word}' at position {match.Index}.");
        else
            Console.WriteLine($"No double characters in '{word}'.");
    }
}
// The example displays the following output:
//       'll' found in 'trellis' at position 3.
//       'ee' found in 'seer' at position 1.
//       'tt' found in 'latter' at position 2.
//       'mm' found in 'summer' at position 2.
//       No double characters in 'hoarse'.
//       'ss' found in 'lesser' at position 2.
//       'aa' found in 'aardvark' at position 0.
//       'nn' found in 'stunned' at position 3.
// </WordCharacter>

// <NonWordCharacter>
static void NonWordCharacter()
{
    string pattern = @"\b(\w+)(\W){1,2}";
    string input = "The old, grey mare slowly walked across the narrow, green pasture.";
    foreach (Match match in Regex.Matches(input, pattern))
    {
        Console.WriteLine(match.Value);
        Console.Write("   Non-word character(s):");
        CaptureCollection captures = match.Groups[2].Captures;
        for (int ctr = 0; ctr < captures.Count; ctr++)
            Console.Write(@"'{0}' (\u{1}){2}", captures[ctr].Value,
                          Convert.ToUInt16(captures[ctr].Value[0]).ToString("X4"),
                          ctr < captures.Count - 1 ? ", " : "");
        Console.WriteLine();
    }
}
// The example displays the following output:
//       The
//          Non-word character(s):' ' (\u0020)
//       old,
//          Non-word character(s):',' (\u002C), ' ' (\u0020)
//       grey
//          Non-word character(s):' ' (\u0020)
//       mare
//          Non-word character(s):' ' (\u0020)
//       slowly
//          Non-word character(s):' ' (\u0020)
//       walked
//          Non-word character(s):' ' (\u0020)
//       across
//          Non-word character(s):' ' (\u0020)
//       the
//          Non-word character(s):' ' (\u0020)
//       narrow,
//          Non-word character(s):',' (\u002C), ' ' (\u0020)
//       green
//          Non-word character(s):' ' (\u0020)
//       pasture.
//          Non-word character(s):'.' (\u002E)
// </NonWordCharacter>

// <WhitespaceCharacter>
static void WhitespaceCharacter()
{
    string pattern = @"\b\w+(e)?s(\s|$)";
    string input = "matches stores stops leave leaves";
    foreach (Match match in Regex.Matches(input, pattern))
        Console.WriteLine(match.Value);
}
// The example displays the following output:
//       matches
//       stores
//       stops
//       leaves
// </WhitespaceCharacter>

// <NonWhitespaceCharacter>
static void NonWhitespaceCharacter()
{
    string pattern = @"\b(\S+)\s?";
    string input = "This is the first sentence of the first paragraph. " +
                          "This is the second sentence.\n" +
                          "This is the only sentence of the second paragraph.";
    foreach (Match match in Regex.Matches(input, pattern))
        Console.WriteLine(match.Groups[1]);
}
// The example displays the following output:
//    This
//    is
//    the
//    first
//    sentence
//    of
//    the
//    first
//    paragraph.
//    This
//    is
//    the
//    second
//    sentence.
//    This
//    is
//    the
//    only
//    sentence
//    of
//    the
//    second
//    paragraph.
// </NonWhitespaceCharacter>

// <DigitCharacter>
static void DigitCharacter()
{
    string pattern = @"^(\(?\d{3}\)?[\s-])?\d{3}-\d{4}$";
    string[] inputs = { "111 111-1111", "222-2222", "222 333-444",
                        "(212) 111-1111", "111-AB1-1111",
                        "212-111-1111", "01 999-9999" };

    foreach (string input in inputs)
    {
        if (Regex.IsMatch(input, pattern))
            Console.WriteLine(input + ": matched");
        else
            Console.WriteLine(input + ": match failed");
    }
}
// The example displays the following output:
//       111 111-1111: matched
//       222-2222: matched
//       222 333-444: match failed
//       (212) 111-1111: matched
//       111-AB1-1111: match failed
//       212-111-1111: matched
//       01 999-9999: match failed
// </DigitCharacter>

// <NonDigitCharacter>
static void NonDigitCharacter()
{
    string pattern = @"^\D\d{1,5}\D*$";
    string[] inputs = { "A1039C", "AA0001", "C18A", "Y938518" };

    foreach (string input in inputs)
    {
        if (Regex.IsMatch(input, pattern))
            Console.WriteLine(input + ": matched");
        else
            Console.WriteLine(input + ": match failed");
    }
}
// The example displays the following output:
//       A1039C: matched
//       AA0001: match failed
//       C18A: matched
//       Y938518: match failed
// </NonDigitCharacter>

// <GetUnicodeCategory>
static void GetUnicodeCategory()
{
    char[] chars = { 'a', 'X', '8', ',', ' ', '\u0009', '!' };

    foreach (char ch in chars)
        Console.WriteLine($"'{Regex.Escape(ch.ToString())}': {Char.GetUnicodeCategory(ch)}");
}
// The example displays the following output:
//       'a': LowercaseLetter
//       'X': UppercaseLetter
//       '8': DecimalDigitNumber
//       ',': OtherPunctuation
//       '\ ': SpaceSeparator
//       '\t': Control
//       '!': OtherPunctuation
// </GetUnicodeCategory>

// <CharacterClassSubtraction>
static void CharacterClassSubtraction()
{
    string[] inputs = { "123", "13579753", "3557798", "335599901" };
    string pattern = @"^[0-9-[2468]]+$";

    foreach (string input in inputs)
    {
        Match match = Regex.Match(input, pattern);
        if (match.Success)
            Console.WriteLine(match.Value);
    }
}
// The example displays the following output:
//       13579753
//       335599901
// </CharacterClassSubtraction>
