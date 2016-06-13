# Parsing Strings in .NET Core

A parsing operation converts a string that represents a .NET Core base type into that base type. For example, a parsing operation is used to convert a string to a floating-point number or to a date and time value. The method most commonly used to perform a parsing operation is the `Parse` method. Because parsing is the reverse operation of formatting (which involves converting a base type into its string representation), many of the same rules and conventions apply. Just as formatting uses an object that implements the [IFormatProvider](https://dotnet.github.io/api/System.IFormatProvider.html) interface to provide culture-sensitive formatting information, parsing also uses an object that implements the [IFormatProvider](https://dotnet.github.io/api/System.IFormatProvider.html) interface to determine how to interpret a string representation. For more information, see [Formatting Types in .NET Core](../formattingtypes.md).

## In This Section

[Parsing Numeric Strings in .NET Core](../parsingnumeric.md) - Describes how to convert strings into .NET Core numeric types.

[Parsing Date and Time Strings in .NET Core](../parsingdatetime.md) - Describes how to convert strings into .NET Core `DateTime` types.

[Parsing Other Strings in .NET Core](.//parsingother.md) - Describes how to convert strings into `Char`, `Boolean`, and `Enum` types.

## Related Sections

[Formatting Types in .NET Core](../formattingtypes.md) - Describes basic formatting concepts like format specifiers and format providers.

[Type Conversion in .NET Core](../conversio.md) - Describes how to convert types.

[Working with Base Types in .NET Core](../basetypes.md) - Describes common operations that you can perform on .NET Core base types.

