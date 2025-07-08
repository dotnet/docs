---
title: System.String constructor
description: Learn about the System.String constructor.
ms.date: 01/24/2024
dev_langs:
  - CSharp
  - FSharp
---
# System.String constructor

[!INCLUDE [context](includes/context.md)]

## Overloaded constructor syntax

[String constructors](xref:System.String.%23ctor%2A) fall into two categories: those without pointer parameters, and those with pointer parameters. The constructors that use pointers are not CLS-compliant. In addition, Visual Basic does not support the use of pointers, and C# requires code that uses pointers to run in an unsafe context. For more information, see [unsafe](../../csharp/language-reference/keywords/unsafe.md).

For additional guidance on choosing an overload, see [Which method do I call?](#which-method-do-i-call).

`String(Char[] value)`\
Initializes the new instance to the value indicated by an array of Unicode characters. This constructor copies Unicode characters([Example 2: Use a character array](#example-2-use-a-character-array)).

`String(Char[] value, Int32 startIndex, Int32 length)`\
Initializes the new instance to the value indicated by an array of Unicode characters, a starting character position within that array, and a length ([Example 3: Use a portion of a character array and repeating a single character](#example-3-use-a-portion-of-a-character-array-and-repeating-a-single-character)).

`String(Char c, Int32 count)`\
Initializes the new instance to the value indicated by a specified Unicode character repeated a specified number of times ([Example 3: Use a portion of a character array and repeating a single character](#example-3-use-a-portion-of-a-character-array-and-repeating-a-single-character)).

`String(char* value)`\
**(Not CLS-compliant)** Initializes the new instance to the value indicated by a pointer to an array of Unicode characters that is terminated by a null character (U+0000 or '\0'). ([Example 4: Use a pointer to a character array](#example-4-use-a-pointer-to-a-character-array)).

Permission: <xref:System.Security.SecurityCriticalAttribute>, requires full trust for the immediate caller. This member cannot be used by partially trusted or transparent code.

`String(char* value, Int32 startIndex, Int32 length)`\
**(Not CLS-compliant)** Initializes the new instance to the value indicated by a pointer to an array of Unicode characters, a starting character position within that array, and a length. The constructor copies the Unicode characters from `value` starting at index `startIndex` and ending at index `startIndex` + `length` - 1 ([Example 5: Instantiate a string from a pointer and a range of an array](#example-5-instantiate-a-string-from-a-pointer-and-a-range-of-an-array)).

Permission: <xref:System.Security.SecurityCriticalAttribute>, requires full trust for the immediate caller. This member cannot be used by partially trusted or transparent code.

`String(SByte* value)`\
**(Not CLS-compliant)** Initializes the new instance to the value indicated by a pointer to an array of 8-bit signed integers. The array is assumed to represent a string encoded using the current system code page (that is, the encoding specified by <xref:System.Text.Encoding.Default%2A?displayProperty=nameWithType>). The constructor processes characters from `value` starting from the location specified by the pointer until a null character (0x00) is reached ([Example 6: Instantiate a string from a pointer to a signed byte array](#example-6-instantiate-a-string-from-a-pointer-to-a-signed-byte-array)).

Permission: <xref:System.Security.SecurityCriticalAttribute>, requires full trust for the immediate caller. This member cannot be used by partially trusted or transparent code.

`String(SByte* value, Int32 startIndex, Int32 length)`\
**(Not CLS-compliant)** Initializes the new instance to the value indicated by a pointer to an array of 8-bit signed integers, a starting position within that array, and a length. The array is assumed to represent a string encoded using the current system code page (that is, the encoding specified by <xref:System.Text.Encoding.Default%2A?displayProperty=nameWithType>). The constructor processes characters from value starting at `startIndex` and ending at `startIndex` + `length` - 1 ([Example 6: Instantiate a string from a pointer to a signed byte array](#example-6-instantiate-a-string-from-a-pointer-to-a-signed-byte-array)).

Permission: <xref:System.Security.SecurityCriticalAttribute>, requires full trust for the immediate caller. This member cannot be used by partially trusted or transparent code.

`String(SByte* value, Int32 startIndex, Int32 length, Encoding enc)`\
**(Not CLS-compliant)** Initializes the new instance to the value indicated by a pointer to an array of 8-bit signed integers, a starting position within that array, a length, and an <xref:System.Text.Encoding> object.

Permission: <xref:System.Security.SecurityCriticalAttribute>, requires full trust for the immediate caller. This member cannot be used by partially trusted or transparent code.

## Parameters

Here is a complete list of parameters used by <xref:System.String> constructors that don't include a pointer parameter. For the parameters used by each overload, see the overload syntax above.

| Parameter | Type                 | Description                     |
|-----------|----------------------|---------------------------------|
| `value`   | <xref:System.Char>[] | An array of Unicode characters. |
| `c`       | <xref:System.Char>   | A Unicode character.            |
| `startIndex` | <xref:System.Int32> |The starting position in `value` of the first character in the new string.<br /><br /> Default value: 0|
| `length` | <xref:System.Int32> |The number of characters in `value` to include in the new string.<br /><br /> Default value: <xref:System.Array.Length%2A?displayProperty=nameWithType>|
| `count` | <xref:System.Int32> |The number of times the character `c` is repeated in the new string. If `count` is zero, the value of the new object is <xref:System.String.Empty?displayProperty=nameWithType>.|

Here is a complete list of parameters used by <xref:System.String> constructors that include a pointer parameter. For the parameters used by each overload, see the overload syntax above.

| Parameter | Type | Description |
|-----------|------|-------------|
|`value`|<xref:System.Char>*<br /><br /> -or-<br /><br /> <xref:System.SByte>\*|A pointer to a null-terminated array of Unicode characters or an array of 8-bit signed integers. If `value` is `null` or an empty array, the value of the new string is <xref:System.String.Empty?displayProperty=nameWithType>.|
|`startIndex`|<xref:System.Int32>|The index of the array element that defines the first character in the new string.<br /><br /> Default value: 0|
|`length`|<xref:System.Int32>|The number of array elements to use to create the new string. If length is zero, the constructor creates a string whose value is <xref:System.String.Empty?displayProperty=nameWithType>.<br /><br /> Default value: <xref:System.Array.Length%2A?displayProperty=nameWithType>|
|`enc`|<xref:System.Text.Encoding>|An object that specifies how the `value` array is encoded.<br /><br /> Default value: <xref:System.Text.Encoding.Default%2A?displayProperty=nameWithType>, or the system's current ANSI code page|

## Exceptions

Here's a list of exceptions thrown by constructors that don't include pointer parameters.

| Exception | Condition | Thrown by |
|-----------|-----------|-----------|
|<xref:System.ArgumentNullException>|`value` is `null`.|<xref:System.String.%23ctor(System.Char%5B%5D,System.Int32,System.Int32)>|
|<xref:System.ArgumentOutOfRangeException>|`startIndex`, `length`, or `count` is less than zero.<br /><br /> -or-<br /><br /> The sum of `startIndex` and `length` is greater than the number of elements in `value`.<br /><br /> -or-<br /><br /> `count` is less than zero.|<xref:System.String.%23ctor(System.Char,System.Int32)><br /><br /> <xref:System.String.%23ctor(System.Char%5B%5D,System.Int32,System.Int32)>|

Here's a list of exceptions thrown by constructors that include pointer parameters.

| Exception | Condition | Thrown by |
|-----------|-----------|-----------|
|<xref:System.ArgumentException>|`value` specifies an array that contains an invalid Unicode character.<br /><br /> -or-<br /><br /> `value` or `value` + `startIndex` specifies an address that is less than 64K.<br /><br /> -or-<br /><br /> A new <xref:System.String> instance could not be initialized from the `value` byte array because `value` does not use the default code page encoding.|All constructors with pointers.|
|<xref:System.ArgumentNullException>|`value` is null.|<xref:System.String.%23ctor(System.SByte%2A)><br /><br /> <xref:System.String.%23ctor(System.SByte%2A,System.Int32,System.Int32)><br /><br /> <xref:System.String.%23ctor(System.SByte%2A,System.Int32,System.Int32,System.Text.Encoding)>|
|<xref:System.ArgumentOutOfRangeException>|The current process does not have read access to all the addressed characters.<br /><br /> -or-<br /><br /> `startIndex` or `length` is less than zero, `value` + `startIndex` cause a pointer overflow, or the current process does not have read access to all the addressed characters.<br /><br /> -or-<br /><br /> The length of the new string is too large to allocate.|All constructors with pointers.|
|<xref:System.AccessViolationException>|`value`, or `value` + `startIndex` + `length` - 1, specifies an invalid address.|<xref:System.String.%23ctor(System.SByte%2A)><br /><br /> <xref:System.String.%23ctor(System.SByte%2A,System.Int32,System.Int32)><br /><br /> <xref:System.String.%23ctor(System.SByte%2A,System.Int32,System.Int32,System.Text.Encoding)>|

## Which method do I call?

| To | Call or use |
|----|-------------|
|Create a string.|Assignment from a string literal or an existing string ([Example 1: Use string assignment](#example-1-use-string-assignment))|
|Create a string from an entire character array.|<xref:System.String.%23ctor(System.Char%5B%5D)> ([Example 2: Use a character array](#example-2-use-a-character-array))|
|Create a string from a portion of a character array.|<xref:System.String.%23ctor(System.Char%5B%5D,System.Int32,System.Int32)> ([Example 3: Use a portion of a character array and repeating a single character](#example-3-use-a-portion-of-a-character-array-and-repeating-a-single-character))|
|Create a string that repeats the same character multiple times.|<xref:System.String.%23ctor(System.Char,System.Int32)> ([Example 3: Use a portion of a character array and repeating a single character](#example-3-use-a-portion-of-a-character-array-and-repeating-a-single-character))|
|Create a string from a pointer to a Unicode or wide character array.|<xref:System.String.%23ctor(System.Char%2A)>|
|Create a string from a portion of a Unicode or wide character array by using its pointer.|<xref:System.String.%23ctor(System.Char%2A,System.Int32,System.Int32)>|
|Create a string from a C++ `char` array.|<xref:System.String.%23ctor(System.SByte%2A)>, <xref:System.String.%23ctor(System.SByte%2A,System.Int32,System.Int32)><br /><br />-or-<br /><br /> <xref:System.String.%23ctor(System.SByte%2A,System.Int32,System.Int32,System.Text.Encoding)>|
|Create a string from ASCII characters.|<xref:System.Text.ASCIIEncoding.GetString%2A?displayProperty=nameWithType>|

## Create strings

The most commonly used technique for creating strings programmatically is simple assignment, as illustrated in [Example 1](#example-1-use-string-assignment). The <xref:System.String> class also includes four types of constructor overloads that let you create strings from the following values:

- From a character array (an array of UTF-16-encoded characters). You can create a new <xref:System.String> object from the characters in the entire array or a portion of it. The <xref:System.String.%23ctor(System.Char%5B%5D)> constructor copies all the characters in the array to the new string. The <xref:System.String.%23ctor(System.Char%5B%5D,System.Int32,System.Int32)> constructor copies the characters from index `startIndex` to index `startIndex` + `length` - 1 to the new string. If `length` is zero, the value of the new string is <xref:System.String.Empty?displayProperty=nameWithType>.

  If your code repeatedly instantiates strings that have the same value, you can improve application performance by using an alternate means of creating strings. For more information, see [Handle repetitive strings](#handle-repetitive-strings).

- From a single character that is duplicated zero, one, or more times, by using the <xref:System.String.%23ctor(System.Char,System.Int32)> constructor. If `count` is zero, the value of the new string is <xref:System.String.Empty?displayProperty=nameWithType>.

- From a pointer to a null-terminated character array, by using the <xref:System.String.%23ctor(System.Char%2A)> or <xref:System.String.%23ctor(System.Char%2A,System.Int32,System.Int32)> constructor. Either the entire array or a specified range can be used to initialize the string. The constructor copies a sequence of Unicode characters starting from the specified pointer or from the specified pointer plus `startIndex` and continuing to the end of the array or for `length` characters. If `value` is a null pointer or `length` is zero, the constructor creates a string whose value is <xref:System.String.Empty?displayProperty=nameWithType>. If the copy operation proceeds to the end of the array and the array is not null-terminated, the constructor behavior is system-dependent. Such a condition might cause an access violation.

  If the array contains any embedded null characters (U+0000 or '\0') and the <xref:System.String.%23ctor(System.Char%2A,System.Int32,System.Int32)> overload is called, the string instance contains `length` characters including any embedded nulls. The following example shows what happens when a pointer to an array of 10 elements that includes two null characters is passed to the <xref:System.String.%23ctor(System.Char%2A,System.Int32,System.Int32)> method. Because the address is the beginning of the array and all elements in the array are to be added to the string, the constructor instantiates a string with ten characters, including two embedded nulls. On the other hand, if the same array is passed to the <xref:System.String.%23ctor(System.Char%2A)> constructor, the result is a four-character string that does not include the first null character.

  :::code language="csharp" source="./snippets/System/String/.ctor/csharp/chptrctor_null.cs" id="Snippet5":::
  :::code language="fsharp" source="./snippets/System/String/.ctor/fsharp/chptrctor_null.fs" id="Snippet5":::

  The array must contain Unicode characters. In C++, this means that the character array must be defined either as the managed <xref:System.Char>[] type or the unmanaged`wchar_t`[] type.

  If the <xref:System.String.%23ctor(System.Char%2A)> overload is called and the array is not null-terminated, or if the <xref:System.String.%23ctor(System.Char%2A,System.Int32,System.Int32)> overload is called and `startIndex` + `length`-1 includes a range that is outside the memory allocated for the sequence of characters, the behavior of the constructor is system-dependent, and an access violation may occur.

- From a pointer to a signed byte array. Either the entire array or a specified range can be used to initialize the string. The sequence of bytes can be interpreted by using the default code page encoding, or an encoding can be specified in the constructor call. If the constructor tries to instantiate a string from an entire array that is not null-terminated, or if the range of the array from `value` + `startIndex` to `value` + `startIndex` + `length` -1 is outside of the memory allocated for the array, the behavior of this constructor is system-dependent, and an access violation may occur.

  The three constructors that include a signed byte array as a parameter are designed primarily to convert a C++ `char` array to a string, as shown in this example:

  :::code language="cpp" source="./snippets/System/String/.ctor/cpp/sbyte_ctor1.cpp" id="Snippet4":::

  If the array contains any null characters ('\0') or bytes whose value is 0 and the <xref:System.String.%23ctor(System.SByte%2A,System.Int32,System.Int32)> overload is called, the string instance contains `length` characters including any embedded nulls. The following example shows what happens when a pointer to an array of 10 elements that includes two null characters is passed to the <xref:System.String.%23ctor(System.SByte%2A,System.Int32,System.Int32)> method. Because the address is the beginning of the array and all elements in the array are to be added to the string, the constructor instantiates a string with ten characters, including two embedded nulls. On the other hand, if the same array is passed to the <xref:System.String.%23ctor(System.SByte%2A)> constructor, the result is a four-character string that does not include the first null character.

  :::code language="csharp" source="./snippets/System/String/.ctor/csharp/ptrctor_null.cs" id="Snippet6":::
  :::code language="fsharp" source="./snippets/System/String/.ctor/fsharp/ptrctor_null.fs" id="Snippet6":::

  Because the <xref:System.String.%23ctor(System.SByte%2A)> and <xref:System.String.%23ctor(System.SByte%2A,System.Int32,System.Int32)> constructors interpret `value` by using the default ANSI code page, calling these constructors with identical byte arrays may create strings that have different values on different systems.

## Handle repetitive strings

Apps that parse or decode streams of text often use the <xref:System.String.%23ctor(System.Char%5B%5D,System.Int32,System.Int32)> constructor or the <xref:System.Text.StringBuilder.Append(System.Char%5B%5D,System.Int32,System.Int32)?displayProperty=nameWithType> method to convert sequences of characters into a string. Repeatedly creating new strings with the same value instead of creating and reusing one string wastes memory. If you are likely to create the same string value repeatedly by calling the <xref:System.String.%23ctor(System.Char%5B%5D,System.Int32,System.Int32)> constructor, even if you don't know in advance what those identical string values may be, you can use a lookup table instead.

For example, suppose you read and parse a stream of characters from a file that contains XML tags and attributes. When you parse the stream, you repeatedly encounter certain tokens (that is, sequences of characters that have a symbolic meaning). Tokens equivalent to the strings "0", "1", "true", and "false" are likely to occur frequently in an XML stream.

Instead of converting each token into a new string, you can create a <xref:System.Xml.NameTable?displayProperty=nameWithType> object to hold commonly occurring strings. The <xref:System.Xml.NameTable> object improves performance, because it retrieves stored strings without allocating temporary memory. When you encounter a token, use the <xref:System.Xml.NameTable.Get(System.Char%5B%5D,System.Int32,System.Int32)?displayProperty=nameWithType> method to retrieve the token from the table. If the token exists, the method returns the corresponding string. If the token does not exist, use the <xref:System.Xml.NameTable.Add(System.Char%5B%5D,System.Int32,System.Int32)?displayProperty=nameWithType> method to insert the token into the table and to get the corresponding string.

## Example 1: Use string assignment

The following example creates a new string by assigning it a string literal. It creates a second string by assigning the value of the first string to it. These are the two most common ways to instantiate a new <xref:System.String> object.

:::code language="csharp" source="./snippets/System/String/.ctor/csharp/ctor1.cs" interactive="try-dotnet" id="Snippet1":::
:::code language="fsharp" source="./snippets/System/String/.ctor/fsharp/ctor1.fs" id="Snippet1":::
:::code language="vb" source="./snippets/System/String/.ctor/vb/ctor1.vb" id="Snippet1":::

## Example 2: Use a character array

The following example demonstrates how to create a new <xref:System.String> object from a character array.

:::code language="csharp" source="./snippets/System/String/.ctor/csharp/source.cs" interactive="try-dotnet-method" id="Snippet1":::
:::code language="fsharp" source="./snippets/System/String/.ctor/fsharp/source.fs" id="Snippet1":::
:::code language="vb" source="./snippets/System/String/.ctor/vb/source.vb" id="Snippet1":::

## Example 3: Use a portion of a character array and repeating a single character

The following example demonstrates how to create a new <xref:System.String> object from a portion of a character array, and how to create a new <xref:System.String> object that contains multiple occurrences of a single character.

:::code language="csharp" source="./snippets/System/String/.ctor/csharp/source.cs" interactive="try-dotnet-method" id="Snippet3":::
:::code language="fsharp" source="./snippets/System/String/.ctor/fsharp/source.fs" id="Snippet3":::
:::code language="vb" source="./snippets/System/String/.ctor/vb/source.vb" id="Snippet3":::

## Example 4: Use a pointer to a character array

The following example demonstrates how to create a new <xref:System.String> object from a pointer to an array of characters. The C# example must be compiled by using the `/unsafe` compiler switch.

:::code language="csharp" source="./snippets/System/String/.ctor/csharp/ctor2.cs" id="Snippet2":::
:::code language="fsharp" source="./snippets/System/String/.ctor/fsharp/ctor2.fs" id="Snippet2":::

## Example 5: Instantiate a string from a pointer and a range of an array

The following example examines the elements of a character array for either a period or an exclamation point. If one is found, it instantiates a string from the characters in the array that precede the punctuation symbol. If not, it instantiates a string with the entire contents of the array. The C# example must be compiled using the `/unsafe` compiler switch.

:::code language="csharp" source="./snippets/System/String/.ctor/csharp/char2_ctor.cs" id="Snippet3":::
:::code language="fsharp" source="./snippets/System/String/.ctor/fsharp/char2_ctor.fs" id="Snippet3":::

## Example 6: Instantiate a string from a pointer to a signed byte array

The following example demonstrates how you can create an instance of the <xref:System.String> class with the <xref:System.String.%23ctor(System.SByte%2A)> constructor.

:::code language="csharp" source="./snippets/System/String/.ctor/csharp/source.cs" id="Snippet2":::
:::code language="fsharp" source="./snippets/System/String/.ctor/fsharp/source.fs" id="Snippet2":::
