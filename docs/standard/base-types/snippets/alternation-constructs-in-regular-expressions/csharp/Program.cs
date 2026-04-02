using System.Text.RegularExpressions;

// <EitherOrCharacterClass>
string pattern1 = @"\bgr[ae]y\b";
string pattern2 = @"\bgr(a|e)y\b";

string input = "The gray wolf blended in among the grey rocks.";
foreach (Match match in Regex.Matches(input, pattern1))
    Console.WriteLine($"'{match.Value}' found at position {match.Index}");
Console.WriteLine();
foreach (Match match in Regex.Matches(input, pattern2))
    Console.WriteLine($"'{match.Value}' found at position {match.Index}");

// The example displays the following output:
// 'gray' found at position 4
// 'grey' found at position 35
//
// 'gray' found at position 4
// 'grey' found at position 35
// </EitherOrCharacterClass>

Console.WriteLine();

// <EitherOrPatterns>
string eitherOrPattern = @"\b(\d{2}-\d{7}|\d{3}-\d{2}-\d{4})\b";
string eitherOrInput = "01-9999999 020-333333 777-88-9999";
Console.WriteLine($"Matches for {eitherOrPattern}:");
foreach (Match match in Regex.Matches(eitherOrInput, eitherOrPattern))
    Console.WriteLine($"   {match.Value} at position {match.Index}");

// The example displays the following output:
// Matches for \b(\d{2}-\d{7}|\d{3}-\d{2}-\d{4})\b:
//    01-9999999 at position 0
//    777-88-9999 at position 22
// </EitherOrPatterns>

Console.WriteLine();

// <ConditionalExpression>
string condExprPattern = @"\b(?(\d{2}-)\d{2}-\d{7}|\d{3}-\d{2}-\d{4})\b";
string condExprInput = "01-9999999 020-333333 777-88-9999";
Console.WriteLine($"Matches for {condExprPattern}:");
foreach (Match match in Regex.Matches(condExprInput, condExprPattern))
    Console.WriteLine($"   {match.Value} at position {match.Index}");

// The example displays the following output:
// Matches for \b(?(\d{2}-)\d{2}-\d{7}|\d{3}-\d{2}-\d{4})\b:
//    01-9999999 at position 0
//    777-88-9999 at position 22
// </ConditionalExpression>

Console.WriteLine();

// <ConditionalNamedGroup>
string namedGroupPattern = @"\b(?<n2>\d{2}-)?(?(n2)\d{7}|\d{3}-\d{2}-\d{4})\b";
string namedGroupInput = "01-9999999 020-333333 777-88-9999";
Console.WriteLine($"Matches for {namedGroupPattern}:");
foreach (Match match in Regex.Matches(namedGroupInput, namedGroupPattern))
    Console.WriteLine($"   {match.Value} at position {match.Index}");

// The example displays the following output:
// Matches for \b(?<n2>\d{2}-)?(?(n2)\d{7}|\d{3}-\d{2}-\d{4})\b:
//    01-9999999 at position 0
//    777-88-9999 at position 22
// </ConditionalNamedGroup>

Console.WriteLine();

// <ConditionalNumberedGroup>
string numberedGroupPattern = @"\b(\d{2}-)?(?(1)\d{7}|\d{3}-\d{2}-\d{4})\b";
string numberedGroupInput = "01-9999999 020-333333 777-88-9999";
Console.WriteLine($"Matches for {numberedGroupPattern}:");
foreach (Match match in Regex.Matches(numberedGroupInput, numberedGroupPattern))
    Console.WriteLine($"   {match.Value} at position {match.Index}");
// The example displays the following output:
// Matches for \b(\d{2}-)?(?(1)\d{7}|\d{3}-\d{2}-\d{4})\b:
//    01-9999999 at position 0
//    777-88-9999 at position 22
// </ConditionalNumberedGroup>
