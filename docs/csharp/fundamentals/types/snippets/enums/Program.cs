// <SwitchEnum>
static string DescribeSeason(Season season) => season switch
{
    Season.Spring => "Flowers bloom and temperatures rise.",
    Season.Summer => "Long days and warm weather.",
    Season.Autumn => "Leaves change color and fall.",
    Season.Winter => "Short days and cold temperatures.",
    _ => throw new ArgumentOutOfRangeException(nameof(season))
};
// </SwitchEnum>

// <UsingFlags>
var permissions = FileAccess.Read | FileAccess.Write;

Console.WriteLine(permissions);                          // ReadWrite
Console.WriteLine(permissions.HasFlag(FileAccess.Read)); // True
Console.WriteLine(permissions.HasFlag(FileAccess.Execute)); // False
// </UsingFlags>

// <Conversions>
var status = HttpStatus.NotFound;
ushort code = (ushort)status;
Console.WriteLine($"Status: {status} ({code})"); // Status: NotFound (404)

var fromCode = (HttpStatus)200;
Console.WriteLine(fromCode); // OK
// </Conversions>

// <ParseAndIterate>
// Parse a string to an enum value:
var parsed = Enum.Parse<Season>("Winter");
Console.WriteLine(parsed); // Winter

// Try to parse safely. It returns false only when the input can't be parsed. Call Enum.IsDefined to validate named members:
if (Enum.TryParse<Season>("Monsoon", out var unknown))
{
    Console.WriteLine(unknown);
}
else
{
    Console.WriteLine("'Monsoon' is not a valid Season"); // 'Monsoon' is not a valid Season
}

// Iterate over all values in an enum:
foreach (var season in Enum.GetValues<Season>())
{
    Console.WriteLine($"{season} = {(int)season}");
}
// Spring = 0
// Summer = 1
// Autumn = 2
// Winter = 3
// </ParseAndIterate>

// <UsingSeason>
var today = Season.Autumn;
Console.WriteLine(DescribeSeason(today));
// </UsingSeason>

// <BasicEnum>
enum Season
{
    Spring,
    Summer,
    Autumn,
    Winter
}
// </BasicEnum>

// <UnderlyingType>
enum HttpStatus : ushort
{
    OK = 200,
    NotFound = 404,
    InternalServerError = 500
}
// </UnderlyingType>

// <FlagsEnum>
[Flags]
enum FileAccess
{
    None = 0,
    Read = 1,
    Write = 2,
    Execute = 4,
    ReadWrite = Read | Write,
    All = Read | Write | Execute
}
// </FlagsEnum>
