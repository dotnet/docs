// <NumericTypes>
int population = 67_000_000;
long distance = 384_400_000L;
short temperature = -40;
byte red = 255;

double pi = 3.141592653589793;
float gravity = 9.81f;
decimal price = 19.99m;
// </NumericTypes>

// <UnsignedTypes>
uint fileSize = 4_294_967_295;
ulong totalBytes = 18_446_744_073_709_551_615;
ushort port = 443;
// </UnsignedTypes>

// <NativeSizedIntegers>
nint bufferSize = 1024;
nuint elementCount = 256;
// </NativeSizedIntegers>

// <BoolCharString>
bool isValid = true;
char grade = 'A';
string greeting = "Hello, world!";
// </BoolCharString>

// <IntegerLiterals>
int dec = 42;
int hex = 0x2A;
int bin = 0b_0010_1010;
long big = 1_000_000_000L;
// </IntegerLiterals>

// <FloatingPointLiterals>
double d = 3.14;
float f = 3.14f;
decimal m = 3.14m;
double scientific = 1.5e6; // 1,500,000
// </FloatingPointLiterals>

// <CharAndStringLiterals>
char newline = '\n';
char unicode = '\u0041'; // 'A'

string message = $"Found {dec} items";            // interpolated string
string path = @"C:\Users\docs\file.txt";        // verbatim string
string json = """
    { "name": "Alice", "age": 30 }
    """;                                           // raw string literal
string raw = $"""
    Found {dec} items in "{greeting}"
    """;                                           // raw + interpolated
// </CharAndStringLiterals>

// <DefaultExpressions>
int defaultInt = default;          // 0
bool defaultBool = default;        // false
string? defaultString = default;   // null

// Use default in a conditional:
var limit = (args.Length > 0) ? int.Parse(args[0]) : default(int);
// </DefaultExpressions>

// <VarKeyword>
var count = 10;              // compiler infers int
var name = "C#";             // compiler infers string
var items = new List<int>(); // compiler infers List<int>

// var requires an initializer — the compiler needs a value to infer the type.
// The following line wouldn't compile:
// var unknown;
// </VarKeyword>

// <TargetTypedNew>
List<string> names = new() { "Alice", "Bob", "Charlie" };
Dictionary<string, int> scores = new()
{
    ["Alice"] = 95,
    ["Bob"] = 87
};
// </TargetTypedNew>

// <DynamicType>
dynamic value = 42;
Console.WriteLine(value.GetType()); // System.Int32

value = "Now I'm a string";
Console.WriteLine(value.GetType()); // System.String

// The compiler doesn't check operations on dynamic at compile time.
// Errors surface at run time instead.
// </DynamicType>

Console.WriteLine($"population: {population}");
Console.WriteLine($"distance: {distance}");
Console.WriteLine($"temperature: {temperature}");
Console.WriteLine($"red: {red}");
Console.WriteLine($"pi: {pi}");
Console.WriteLine($"gravity: {gravity}");
Console.WriteLine($"price: {price}");
Console.WriteLine($"fileSize: {fileSize}");
Console.WriteLine($"totalBytes: {totalBytes}");
Console.WriteLine($"port: {port}");
Console.WriteLine($"bufferSize: {bufferSize}");
Console.WriteLine($"elementCount: {elementCount}");
Console.WriteLine($"isValid: {isValid}");
Console.WriteLine($"grade: {grade}");
Console.WriteLine($"greeting: {greeting}");
Console.WriteLine($"dec: {dec}, hex: {hex}, bin: {bin}, big: {big}");
Console.WriteLine($"d: {d}, f: {f}, m: {m}, scientific: {scientific}");
Console.WriteLine($"newline char: [{newline}], unicode: {unicode}");
Console.WriteLine($"path: {path}");
Console.WriteLine($"message: {message}");
Console.WriteLine($"json: {json}");
Console.WriteLine($"raw: {raw}");
Console.WriteLine($"defaultInt: {defaultInt}, defaultBool: {defaultBool}, defaultString: {defaultString}");
Console.WriteLine($"limit: {limit}");
Console.WriteLine($"count: {count}, name: {name}, items: {items.Count}");
Console.WriteLine($"names: {string.Join(", ", names)}");
Console.WriteLine($"scores: {string.Join(", ", scores.Select(kv => $"{kv.Key}={kv.Value}"))}");
