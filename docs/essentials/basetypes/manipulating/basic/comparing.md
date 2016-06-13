# Comparing Strings

.NET Core provides several methods to compare the values of strings. The following table lists and describes the value-comparison methods.

Method name | Use
----------- | ---
[String.Compare](http://dotnet.github.io/api/System.String.html#System_String_Compare_System_String_System_Int32_System_String_System_Int32_System_Int32_) | Compares the values of two strings. Returns an integer value.
[String.CompareOrdinal](http://dotnet.github.io/api/System.String.html#System_String_CompareOrdinal_System_String_System_Int32_System_String_System_Int32_System_Int32_) | Compares two strings without regard to local culture. Returns an integer value.
[String.CompareTo](http://dotnet.github.io/api/System.String.html#System_String_CompareTo_System_String_) | Compares the current string object to another string. Returns an integer value.
[String.StartsWith](http://dotnet.github.io/api/System.String.html#System_String_StartsWith_System_String_) | Determines whether a string begins with the string passed. Returns a Boolean value.
[String.EndsWith](http://dotnet.github.io/api/System.String.html#System_String_CompareTo_System_String_) | Determines whether a string ends with the string passed. Returns a Boolean value.
[String.Equals](http://dotnet.github.io/api/System.String.html#System_String_CompareTo_System_String_) | Determines whether two strings are the same. Returns a Boolean value.
[String.IndexOf](http://dotnet.github.io/api/System.String.html#System_String_IndexOf_System_Char_) | Returns the index position of a character or string, starting from the beginning of the string you are examining. Returns an integer value.
[String.LastIndexOf](http://dotnet.github.io/api/System.String.html#System_String_LastIndexOf_System_Char_) | Returns the index position of a character or string, starting from the end of the string you are examining. Returns an integer value.

## Compare

The static [String.Compare](http://dotnet.github.io/api/System.String.html#System_String_Compare_System_String_System_Int32_System_String_System_Int32_System_Int32_) method provides a thorough way of comparing two strings. This method is culturally aware. You can use this function to compare two strings or substrings of two strings. Additionally, overloads are provided that regard or disregard case and cultural variance. The following table shows the three integer values that this method might return. 

Return value | Condition
------------ | ---------
A negative integer | The first string precedes the second string in the sort order, or the first string is `null`.
0 | The first string and the second string are equal, or both strings are `null`.
A positive integer, or 1 | The first string follows the second string in the sort order, or the second string is null.
 
> **Important**
>
> The [String.Compare](http://dotnet.github.io/api/System.String.html#System_String_Compare_System_String_System_Int32_System_String_System_Int32_System_Int32_) method is primarily intended for use when ordering or sorting strings. You should not use the [String.Compare](http://dotnet.github.io/api/System.String.html#System_String_Compare_System_String_System_Int32_System_String_System_Int32_System_Int32_) method to test for equality (that is, to explicitly look for a return value of 0 with no regard for whether one string is less than or greater than the other). Instead, to determine whether two strings are equal, use the [String.Equals(String, String, StringComparison)](http://dotnet.github.io/api/System.String.html#System_String_Equals_System_String_System_String_System_StringComparison_) method.

The following example uses the [String.Compare](http://dotnet.github.io/api/System.String.html#System_String_Compare_System_String_System_Int32_System_String_System_Int32_System_Int32_) method to determine the relative values of two strings.

```csharp
string string1 = "Hello World!";
Console.WriteLine(String.Compare(string1, "Hello World?"));
```

This example displays `-1` to the console.

## CompareOrdinal

The [String.CompareOrdinal](http://dotnet.github.io/api/System.String.html#System_String_CompareOrdinal_System_String_System_Int32_System_String_System_Int32_System_Int32_) method compares two string objects without considering the local culture. The return values of this method are identical to the values returned by the `Compare` method in the previous table.

> **Important**
>
> The [String.CompareOrdinal](http://dotnet.github.io/api/System.String.html#System_String_CompareOrdinal_System_String_System_Int32_System_String_System_Int32_System_Int32_) method is primarily intended for use when ordering or sorting strings. You should not use the [String.CompareOrdinal](http://dotnet.github.io/api/System.String.html#System_String_CompareOrdinal_System_String_System_Int32_System_String_System_Int32_System_Int32_) method to test for equality (that is, to explicitly look for a return value of 0 with no regard for whether one string is less than or greater than the other). Instead, to determine whether two strings are equal, use the [String.Equals(String, String, StringComparison)](http://dotnet.github.io/api/System.String.html#System_String_Equals_System_String_System_String_System_StringComparison_) method.

The following example uses the `CompareOrdinal` method to compare the values of two strings.

```csharp
string string1 = "Hello World!";
Console.WriteLine(String.CompareOrdinal(string1, "hello world!"));
```

This example displays `-32` to the console.

## CompareTo

The [String.CompareTo](http://dotnet.github.io/api/System.String.html#System_String_CompareTo_System_String_) method compares the string that the current string object encapsulates to another string or object. The return values of this method are identical to the values returned by the `String.Compare` method in the previous table.

> **Important**
>
> The [String.CompareTo](http://dotnet.github.io/api/System.String.html#System_String_CompareTo_System_String_) method is primarily intended for use when ordering or sorting strings. You should not use the [String.CompareTo](http://dotnet.github.io/api/System.String.html#System_String_CompareTo_System_String_) method to test for equality (that is, to explicitly look for a return value of 0 with no regard for whether one string is less than or greater than the other). Instead, to determine whether two strings are equal, use the [String.Equals(String, String, StringComparison)](http://dotnet.github.io/api/System.String.html#System_String_Equals_System_String_System_String_System_StringComparison_) method.

The following example uses the `String.CompareTo` method to compare the `string1` object to the `string2` object.

```csharp
string string1 = "Hello World";
string string2 = "Hello World!";
int MyInt = string1.CompareTo(string2);
Console.WriteLine( MyInt );
```

This example displays `-1` to the console.

## Equals

The [String.Equals](http://dotnet.github.io/api/System.String.html#System_String_CompareTo_System_String_) method can easily determine if two strings are the same. This case-sensitive method returns a `true` or `false` Boolean value. It can be used from an existing class, as illustrated in the next example. The following example uses the `Equals` method to determine whether a string object contains the phrase "Hello World".

```csharp
string string1 = "Hello World";
Console.WriteLine(string1.Equals("Hello World"));
```

This example displays `true` to the console.

This method can also be used as a static method. The following example compares two string objects using a static method.

```csharp
string string1 = "Hello World";
string string2 = "Hello World";
Console.WriteLine(String.Equals(string1, string2));
```

This example displays `true` to the console.

## StartsWith and EndsWith

You can use the [String.StartsWith](http://dotnet.github.io/api/System.String.html#System_String_StartsWith_System_String_) method to determine whether a string object begins with the same characters that encompass another string. This case-sensitive method returns `true` if the current string object begins with the passed string and `false` if it does not. The following example uses this method to determine if a string object begins with "Hello".

```csharp
string string1 = "Hello World";
Console.WriteLine(string1.StartsWith("Hello"));
```

This example displays `true` to the console.

The [String.EndsWith](http://dotnet.github.io/api/System.String.html#System_String_CompareTo_System_String_) method compares a passed string to the characters that exist at the end of the current string object. It also returns a Boolean value. The following example checks the end of a string using the `EndsWith` method.

```csharp
string string1 = "Hello World";
Console.WriteLine(string1.EndsWith("Hello"));
```

This example displays `false` to the console.

## IndexOf and LastIndexOf

You can use the [String.IndexOf](http://dotnet.github.io/api/System.String.html#System_String_IndexOf_System_Char_) method to determine the position of the first occurrence of a particular character within a string. This case-sensitive method starts counting from the beginning of a string and returns the position of a passed character using a zero-based index. If the character cannot be found, a value of –1 is returned.

The following example uses the `IndexOf` method to search for the first occurrence of the '`l`' character in a string.

```csharp
string string1 = "Hello World";
Console.WriteLine(string1.IndexOf('l'));
```

This example displays `2` to the console.

The [String.LastIndexOf](http://dotnet.github.io/api/System.String.html#System_String_LastIndexOf_System_Char_) method is similar to the `String.IndexOf` method except that it returns the position of the last occurrence of a particular character within a string. It is case-sensitive and uses a zero-based index. 

The following example uses the `LastIndexOf` method to search for the last occurrence of the '`l`' character in a string.

```csharp
string string1 = "Hello World";
Console.WriteLine(string1.LastIndexOf('l'));
```

This example displays `9` to the console.

Both methods are useful when used in conjunction with the [String.Remove](http://dotnet.github.io/api/System.String.html#System_String_Remove_System_Int32_) method. You can use either the `IndexOf` or `LastIndexOf` methods to retrieve the position of a character, and then supply that position to the `Remove method` in order to remove a character or a word that begins with that character.

## See Also

[Basic String Operations](../basicstringoperations.md)












