# Parsing Other Strings in .NET Core


In addition to numeric and [DateTime](https://dotnet.github.io/api/System.DateTime.html) strings, you can also parse strings that represent the types [Char](https://dotnet.github.io/api/System.Char.html), [Boolean](https://dotnet.github.io/api/System.Boolean.html), and [Enum](https://dotnet.github.io/api/System.Enum.html) into data types.

## Char

The static parse method associated with the [Char](https://dotnet.github.io/api/System.Char.html) data type is useful for converting a string that contains a single character into its Unicode value. The following code example parses a string into a Unicode character.

```csharp
string MyString1 = "A";
char MyChar = Char.Parse(MyString1);
// MyChar now contains a Unicode "A" character.
```

## Boolean

The [Boolean](https://dotnet.github.io/api/System.Boolean.html) data type contains a [Parse](https://dotnet.github.io/api/System.Boolean.html#System_Boolean_Parse_System_String_) method that you can use to convert a string that represents a `Boolean` value into an actual `Boolean` type. This method is not case-sensitive and can successfully parse a string containing "True" or "False." The `Parse` method associated with the `Boolean` type can also parse strings that are surrounded by white spaces. If any other string is passed, a [FormatException](https://dotnet.github.io/api/System.FormatException.html) is thrown.

The following code example uses the `Parse` method to convert a string into a `Boolean` value.

```csharp
string MyString2 = "True";
bool MyBool = bool.Parse(MyString2);
// MyBool now contains a True Boolean value.
```

## Enumeration

You can use the static [Parse](https://dotnet.github.io/api/System.Enum.html#System_Enum_Parse_System_Type_System_String_) method to initialize an enumeration type to the value of a string. This method accepts the enumeration type you are parsing, the string to parse, and an optional `Boolean` flag indicating whether or not the parse is case-sensitive. The string you are parsing can contain several values separated by commas, which can be preceded or followed by one or more empty spaces (also called white spaces). When the string contains multiple values, the value of the returned object is the value of all specified values combined with a bitwise OR operation.

The following example uses the `Parse` method to convert a string representation into an enumeration value. The [DayOfWeek](https://dotnet.github.io/api/System.DayOfWeek.html) enumeration is initialized to Thursday from a string.

```csharp
string MyString3 = "Thursday";
DayOfWeek MyDays = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), MyString3);
Console.WriteLine(MyDays);
// The result is Thursday.
```

## See Also

[Parsing Strings in .NET Core](../parsingstrings.md)

[Formatting Types in .NET Core](../formattingtypes.md)

[Type Conversion in .NET Core](../typeconversion.md)

