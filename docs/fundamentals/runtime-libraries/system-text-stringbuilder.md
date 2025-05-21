---
title: System.Text.StringBuilder class
description: Learn about the System.Text.StringBuilder class.
ms.date: 12/31/2023
dev_langs:
  - CSharp
  - FSharp
  - VB
ms.topic: article
---
# System.Text.StringBuilder class

[!INCLUDE [context](includes/context.md)]

The <xref:System.Text.StringBuilder> class represents a string-like object whose value is a mutable sequence of characters.

## StringBuilder versus String type

Although <xref:System.Text.StringBuilder> and <xref:System.String> both represent sequences of characters, they are implemented differently. <xref:System.String> is an immutable type. That is, each operation that appears to modify a <xref:System.String> object actually creates a new string.

For example, the call to the <xref:System.String.Concat%2A?displayProperty=nameWithType> method in the following C# example appears to change the value of a string variable named `value`. In fact, the <xref:System.String.Concat%2A> method returns a `value` object that has a different value and address from the `value` object that was passed to the method. Note that the example must be compiled using the `/unsafe` compiler option.

:::code language="csharp" source="./snippets/System.Text/StringBuilder/Overview/csharp/immutability2.cs" id="Snippet1":::
:::code language="fsharp" source="./snippets/System.Text/StringBuilder/Overview/fsharp/immutability2.fs" id="Snippet1":::

For routines that perform extensive string manipulation (such as apps that modify a string numerous times in a loop), modifying a string repeatedly can exert a significant performance penalty. The alternative is to use <xref:System.Text.StringBuilder>, which is a mutable string class. Mutability means that once an instance of the class has been created, it can be modified by appending, removing, replacing, or inserting characters.

> [!IMPORTANT]
> Although the <xref:System.Text.StringBuilder> class generally offers better performance than the <xref:System.String> class, you should not automatically replace <xref:System.String> with <xref:System.Text.StringBuilder> whenever you want to manipulate strings. Performance depends on the size of the string, the amount of memory to be allocated for the new string, the system on which your code is executing, and the type of operation. You should be prepared to test your code to determine whether <xref:System.Text.StringBuilder> actually offers a significant performance improvement.

Consider using the <xref:System.String> class under these conditions:

- When the number of changes that your code will make to a string is small. In these cases, <xref:System.Text.StringBuilder> might offer negligible or no performance improvement over <xref:System.String>.
- When you perform a fixed number of concatenation operations, particularly with string literals. In this case, the compiler might combine the concatenation operations into a single operation.
- When you have to perform extensive search operations while you are building your string. The <xref:System.Text.StringBuilder> class lacks search methods such as `IndexOf` or `StartsWith`. You'll have to convert the <xref:System.Text.StringBuilder> object to a <xref:System.String> for these operations, and this can negate the performance benefit from using <xref:System.Text.StringBuilder>. For more information, see the [Search the text in a StringBuilder object](#search-the-text-in-a-stringbuilder-object) section.

Consider using the <xref:System.Text.StringBuilder> class under these conditions:

- When you expect your code to make an unknown number of changes to a string at design time (for example, when you use a loop to concatenate a random number of strings that contain user input).
- When you expect your code to make a significant number of changes to a string.

## How StringBuilder works

The <xref:System.Text.StringBuilder.Length?displayProperty=nameWithType> property indicates the number of characters the <xref:System.Text.StringBuilder> object currently contains. If you add characters to the <xref:System.Text.StringBuilder> object, its length increases until it equals the size of the <xref:System.Text.StringBuilder.Capacity?displayProperty=nameWithType> property, which defines the number of characters that the object can contain. If the number of added characters causes the length of the <xref:System.Text.StringBuilder> object to exceed its current capacity, new memory is allocated, the value of the <xref:System.Text.StringBuilder.Capacity> property is doubled, new characters are added to the <xref:System.Text.StringBuilder> object, and its <xref:System.Text.StringBuilder.Length> property is adjusted. Additional memory for the <xref:System.Text.StringBuilder> object is allocated dynamically until it reaches the value defined by the <xref:System.Text.StringBuilder.MaxCapacity?displayProperty=nameWithType> property. When the maximum capacity is reached, no further memory can be allocated for the <xref:System.Text.StringBuilder> object, and trying to add characters or expand it beyond its maximum capacity throws either an <xref:System.ArgumentOutOfRangeException> or an <xref:System.OutOfMemoryException> exception.

The following example illustrates how a <xref:System.Text.StringBuilder> object allocates new memory and increases its capacity dynamically as the string assigned to the object expands. The code creates a <xref:System.Text.StringBuilder> object by calling its default (parameterless) constructor. The default capacity of this object is 16 characters, and its maximum capacity is more than 2 billion characters. Appending the string "This is a sentence." results in a new memory allocation because the string length (19 characters) exceeds the default capacity of the <xref:System.Text.StringBuilder> object. The capacity of the object doubles to 32 characters, the new string is added, and the length of the object now equals 19 characters. The code then appends the string "This is an additional sentence." to the value of the <xref:System.Text.StringBuilder> object 11 times. Whenever the append operation causes the length of the <xref:System.Text.StringBuilder> object to exceed its capacity, its existing capacity is doubled and the <xref:System.Text.StringBuilder.Append%2A> operation succeeds.

:::code language="csharp" source="./snippets/System.Text/StringBuilder/Overview/csharp/default1.cs" interactive="try-dotnet" id="Snippet3":::
:::code language="fsharp" source="./snippets/System.Text/StringBuilder/Overview/fsharp/default1.fs" id="Snippet3":::
:::code language="vb" source="./snippets/System.Text/StringBuilder/Overview/vb/default1.vb" id="Snippet3":::

## Memory allocation

The default capacity of a <xref:System.Text.StringBuilder> object is 16 characters, and its default maximum capacity is <xref:System.Int32.MaxValue?displayProperty=nameWithType>. These default values are used if you call the <xref:System.Text.StringBuilder.%23ctor> and <xref:System.Text.StringBuilder.%23ctor%28System.String%29> constructors.

You can explicitly define the initial capacity of a <xref:System.Text.StringBuilder> object in the following ways:

- By calling any of the <xref:System.Text.StringBuilder> constructors that includes a `capacity` parameter when you create the object.
- By explicitly assigning a new value to the <xref:System.Text.StringBuilder.Capacity?displayProperty=nameWithType> property to expand an existing <xref:System.Text.StringBuilder> object. (The property throws an exception if the new capacity is less than the existing capacity or greater than the <xref:System.Text.StringBuilder> object's maximum capacity.)
- By calling the <xref:System.Text.StringBuilder.EnsureCapacity%2A?displayProperty=nameWithType> method with the new capacity. The new capacity must not be greater than the <xref:System.Text.StringBuilder> object's maximum capacity. However, unlike an assignment to the <xref:System.Text.StringBuilder.Capacity> property, <xref:System.Text.StringBuilder.EnsureCapacity%2A> does not throw an exception if the desired new capacity is less than the existing capacity. In this case, the method call has no effect.

If the length of the string assigned to the <xref:System.Text.StringBuilder> object in the constructor call exceeds either the default capacity or the specified capacity, the <xref:System.Text.StringBuilder.Capacity> property is set to the length of the string specified with the `value` parameter.

You can explicitly define the maximum capacity of a <xref:System.Text.StringBuilder> object by calling the <xref:System.Text.StringBuilder.%23ctor%28System.Int32%2CSystem.Int32%29> constructor. You can't change the maximum capacity by assigning a new value to the <xref:System.Text.StringBuilder.MaxCapacity> property, because it is read-only.

As the previous section shows, whenever the existing capacity is inadequate, additional memory is allocated and the capacity of a <xref:System.Text.StringBuilder> object doubles up to the value defined by the <xref:System.Text.StringBuilder.MaxCapacity> property.

In general, the default capacity and maximum capacity are adequate for most apps. You might consider setting these values under the following conditions:

- If the eventual size of the <xref:System.Text.StringBuilder> object is likely to grow exceedingly large, typically in excess of several megabytes. In this case, there might be some performance benefit from setting the initial <xref:System.Text.StringBuilder.Capacity> property to a significantly high value to eliminate the need for too many memory reallocations.
- If your code is running on a system with limited memory. In this case, you might consider setting the <xref:System.Text.StringBuilder.MaxCapacity> property to less than <xref:System.Int32.MaxValue?displayProperty=nameWithType> if your code is handling large strings that might cause it to execute in a memory-constrained environment.

## Instantiate a StringBuilder object

You instantiate a <xref:System.Text.StringBuilder> object by calling one of its six overloaded class constructors, which are listed in the following table. Three of the constructors instantiate a <xref:System.Text.StringBuilder> object whose value is an empty string, but set its <xref:System.Text.StringBuilder.Capacity%2A> and <xref:System.Text.StringBuilder.MaxCapacity%2A> values differently. The remaining three constructors define a <xref:System.Text.StringBuilder> object that has a specific string value and capacity. Two of the three constructors use the default maximum capacity of <xref:System.Int32.MaxValue?displayProperty=nameWithType>, whereas the third allows you to set the maximum capacity.

| Constructor | String value | Capacity | Maximum capacity |
|-------------|--------------|----------|------------------|
|<xref:System.Text.StringBuilder.%23ctor>|<xref:System.String.Empty?displayProperty=nameWithType>|16|<xref:System.Int32.MaxValue?displayProperty=nameWithType>|
|<xref:System.Text.StringBuilder.%23ctor%28System.Int32%29>|<xref:System.String.Empty?displayProperty=nameWithType>|Defined by the `capacity` parameter|<xref:System.Int32.MaxValue?displayProperty=nameWithType>|
|<xref:System.Text.StringBuilder.%23ctor%28System.Int32%2CSystem.Int32%29>|<xref:System.String.Empty?displayProperty=nameWithType>|Defined by the `capacity` parameter|Defined by the `maxCapacity` parameter|
|<xref:System.Text.StringBuilder.%23ctor%28System.String%29>|Defined by the `value` parameter|16 or `value`. <xref:System.String.Length%2A>, whichever is greater|<xref:System.Int32.MaxValue?displayProperty=nameWithType>|
|<xref:System.Text.StringBuilder.%23ctor%28System.String%2CSystem.Int32%29>|Defined by the `value` parameter|Defined by the `capacity` parameter or `value`. <xref:System.String.Length%2A>, whichever is greater.|<xref:System.Int32.MaxValue?displayProperty=nameWithType>|
|<xref:System.Text.StringBuilder.%23ctor%28System.String%2CSystem.Int32%2CSystem.Int32%2CSystem.Int32%29>|Defined by `value`. <xref:System.String.Substring%2A>(`startIndex`, `length`)|Defined by the `capacity` parameter or `value`. <xref:System.String.Length%2A>, whichever is greater.|<xref:System.Int32.MaxValue?displayProperty=nameWithType>|

The following example uses three of these constructor overloads to instantiate <xref:System.Text.StringBuilder> objects.

:::code language="csharp" source="./snippets/System.Text/StringBuilder/Overview/csharp/instantiate1.cs" interactive="try-dotnet" id="Snippet6":::
:::code language="fsharp" source="./snippets/System.Text/StringBuilder/Overview/fsharp/instantiate1.fs" id="Snippet6":::
:::code language="vb" source="./snippets/System.Text/StringBuilder/Overview/vb/instantiate1.vb" id="Snippet6":::

## Call StringBuilder methods

Most of the methods that modify the string in a <xref:System.Text.StringBuilder> instance return a reference to that same instance. This enables you to call <xref:System.Text.StringBuilder> methods in two ways:

- You can make individual method calls and ignore the return value, as the following example does.

  :::code language="csharp" source="./snippets/System.Text/StringBuilder/Overview/csharp/call1.cs" interactive="try-dotnet" id="Snippet4":::
  :::code language="fsharp" source="./snippets/System.Text/StringBuilder/Overview/fsharp/call1.fs" id="Snippet4":::
  :::code language="vb" source="./snippets/System.Text/StringBuilder/Overview/vb/call1.vb" id="Snippet4":::

- You can make a series of method calls in a single statement. This can be convenient if you want to write a single statement that chains successive operations. The following example consolidates three method calls from the previous example into a single line of code.

  :::code language="csharp" source="./snippets/System.Text/StringBuilder/Overview/csharp/call2.cs" interactive="try-dotnet" id="Snippet5":::
  :::code language="fsharp" source="./snippets/System.Text/StringBuilder/Overview/fsharp/call2.fs" id="Snippet5":::
  :::code language="vb" source="./snippets/System.Text/StringBuilder/Overview/vb/call2.vb" id="Snippet5":::

## Perform StringBuilder operations

You can use the methods of the <xref:System.Text.StringBuilder> class to iterate, add, delete, or modify characters in a <xref:System.Text.StringBuilder> object.

### Iterate StringBuilder characters

You can access the characters in a <xref:System.Text.StringBuilder> object by using the <xref:System.Text.StringBuilder.Chars%2A?displayProperty=nameWithType> property. In C#, <xref:System.Text.StringBuilder.Chars%2A> is an indexer; in Visual Basic, it is the default property of the <xref:System.Text.StringBuilder> class. This enables you to set or retrieve individual characters by using their index only, without explicitly referencing the <xref:System.Text.StringBuilder.Chars%2A> property. Characters in a <xref:System.Text.StringBuilder> object begin at index 0 (zero) and continue to index <xref:System.Text.StringBuilder.Length%2A> - 1.

The following example illustrates the <xref:System.Text.StringBuilder.Chars%2A> property. It appends ten random numbers to a <xref:System.Text.StringBuilder> object, and then iterates each character. If the character's Unicode category is <xref:System.Globalization.UnicodeCategory.DecimalDigitNumber?displayProperty=nameWithType>, it decreases the number by 1 (or changes the number to 9 if its value is 0). The example displays the contents of the <xref:System.Text.StringBuilder> object both before and after the values of individual characters were changed.

:::code language="csharp" source="./snippets/System.Text/StringBuilder/Overview/csharp/chars1.cs" interactive="try-dotnet" id="Snippet7":::
:::code language="fsharp" source="./snippets/System.Text/StringBuilder/Overview/fsharp/chars1.fs" id="Snippet7":::
:::code language="vb" source="./snippets/System.Text/StringBuilder/Overview/vb/chars1.vb" id="Snippet7":::

[!INCLUDE[stringbuilder-performance-note](./includes/stringbuilder-perf-note.md)]

### Add text to a StringBuilder object

The <xref:System.Text.StringBuilder> class includes the following methods for expanding the contents of a <xref:System.Text.StringBuilder> object:

- The <xref:System.Text.StringBuilder.Append%2A> method appends a string, a substring, a character array, a portion of a character array, a single character repeated multiple times, or the string representation of a primitive data type to a <xref:System.Text.StringBuilder> object.

- The <xref:System.Text.StringBuilder.AppendLine%2A> method appends a line terminator or a string along with a line terminator to a <xref:System.Text.StringBuilder> object.

- The <xref:System.Text.StringBuilder.AppendFormat%2A> method appends a [composite format string](../../standard/base-types/composite-formatting.md) to a <xref:System.Text.StringBuilder> object. The string representations of objects included in the result string can reflect the formatting conventions of the current system culture or a specified culture.

- The <xref:System.Text.StringBuilder.Insert%2A> method inserts a string, a substring, multiple repetitions of a string, a character array, a portion of a character array, or the string representation of a primitive data type at a specified position in the <xref:System.Text.StringBuilder> object. The position is defined by a zero-based index.

The following example uses the <xref:System.Text.StringBuilder.Append%2A>, <xref:System.Text.StringBuilder.AppendLine%2A>, <xref:System.Text.StringBuilder.AppendFormat%2A>, and <xref:System.Text.StringBuilder.Insert%2A> methods to expand the text of a <xref:System.Text.StringBuilder> object.

  :::code language="csharp" source="./snippets/System.Text/StringBuilder/Overview/csharp/expand1.cs" interactive="try-dotnet" id="Snippet9":::
  :::code language="fsharp" source="./snippets/System.Text/StringBuilder/Overview/fsharp/expand1.fs" id="Snippet9":::
  :::code language="vb" source="./snippets/System.Text/StringBuilder/Overview/vb/expand1.vb" id="Snippet9":::

### Delete text from a StringBuilder object

The <xref:System.Text.StringBuilder> class includes methods that can reduce the size of the current <xref:System.Text.StringBuilder> instance. The <xref:System.Text.StringBuilder.Clear%2A> method removes all characters and sets the <xref:System.Text.StringBuilder.Length> property to zero. The <xref:System.Text.StringBuilder.Remove%2A> method deletes a specified number of characters starting at a particular index position. In addition, you can remove characters from the end of a <xref:System.Text.StringBuilder> object by setting its <xref:System.Text.StringBuilder.Length> property to a value that is less than the length of the current instance.

The following example removes some of the text from a <xref:System.Text.StringBuilder> object, displays its resulting capacity, maximum capacity, and length property values, and then calls the <xref:System.Text.StringBuilder.Clear%2A> method to remove all the characters from the <xref:System.Text.StringBuilder> object.

:::code language="csharp" source="./snippets/System.Text/StringBuilder/Overview/csharp/delete1.cs" interactive="try-dotnet" id="Snippet10":::
:::code language="fsharp" source="./snippets/System.Text/StringBuilder/Overview/fsharp/delete1.fs" id="Snippet10":::
:::code language="vb" source="./snippets/System.Text/StringBuilder/Overview/vb/delete1.vb" id="Snippet10":::

### Modify the text in a StringBuilder object

The <xref:System.Text.StringBuilder.Replace%2A?displayProperty=nameWithType> method replaces all occurrences of a character or a string in the entire <xref:System.Text.StringBuilder> object or in a particular character range. The following example uses the <xref:System.Text.StringBuilder.Replace%2A> method to replace all exclamation points (!) with question marks (?) in the <xref:System.Text.StringBuilder> object.

:::code language="csharp" source="./snippets/System.Text/StringBuilder/Overview/csharp/replace1.cs" interactive="try-dotnet" id="Snippet11":::
:::code language="fsharp" source="./snippets/System.Text/StringBuilder/Overview/fsharp/replace1.fs" id="Snippet11":::
:::code language="vb" source="./snippets/System.Text/StringBuilder/Overview/vb/replace1.vb" id="Snippet11":::

## Search the text in a StringBuilder object

The <xref:System.Text.StringBuilder> class does not include methods similar to the <xref:System.String.Contains%2A?displayProperty=nameWithType>, <xref:System.String.IndexOf%2A?displayProperty=nameWithType>, and <xref:System.String.StartsWith%2A?displayProperty=nameWithType> methods provided by the <xref:System.String> class, which allow you to search the object for a particular character or a substring. Determining the presence or starting character position of a substring requires that you search a <xref:System.String> value by using either a string search method or a regular expression method. There are four ways to implement such searches, as the following table shows.

| Technique | Pros | Cons |
|-----------|------|------|
|Search string values before adding them to the <xref:System.Text.StringBuilder> object.|Useful for determining whether a substring exists.|Cannot be used when the index position of a substring is important.|
|Call <xref:System.Text.StringBuilder.ToString%2A> and search the returned <xref:System.String> object.|Easy to use if you assign all the text to a <xref:System.Text.StringBuilder> object, and then begin to modify it.|Cumbersome to repeatedly call <xref:System.Text.StringBuilder.ToString%2A> if you must make modifications before all text is added to the <xref:System.Text.StringBuilder> object.<br /><br />You must remember to work from the end of the <xref:System.Text.StringBuilder> object's text if you're making changes.|
|Use the <xref:System.Text.StringBuilder.Chars%2A> property to sequentially search a range of characters.|Useful if you're concerned with individual characters or a small substring.|Cumbersome if the number of characters to search is large or if the search logic is complex.<br /><br />Results in very poor performance for objects that have grown very large through repeated method calls. |
|Convert the <xref:System.Text.StringBuilder> object to a <xref:System.String> object, and perform modifications on the <xref:System.String> object.|Useful if the number of modifications is small.|Negates the performance benefit of the <xref:System.Text.StringBuilder> class if the number of modifications is large.|

Let's examine these techniques in greater detail.

- If the goal of the search is to determine whether a particular substring exists (that is, if you aren't interested in the position of the substring), you can search strings before storing them in the <xref:System.Text.StringBuilder> object. The following example provides one possible implementation. It defines a `StringBuilderFinder` class whose constructor is passed a reference to a <xref:System.Text.StringBuilder> object and the substring to find in the string. In this case, the example tries to determine whether recorded temperatures are in Fahrenheit or Celsius, and adds the appropriate introductory text to the beginning of the <xref:System.Text.StringBuilder> object. A random number generator is used to select an array that contains data in either degrees Celsius or degrees Fahrenheit.

  :::code language="csharp" source="./snippets/System.Text/StringBuilder/Overview/csharp/pattern1.cs" interactive="try-dotnet" id="Snippet12":::
  :::code language="fsharp" source="./snippets/System.Text/StringBuilder/Overview/fsharp/pattern1.fs" id="Snippet12":::
  :::code language="vb" source="./snippets/System.Text/StringBuilder/Overview/vb/pattern1.vb" id="Snippet12":::

- Call the <xref:System.Text.StringBuilder.ToString%2A?displayProperty=nameWithType> method to convert the <xref:System.Text.StringBuilder> object to a <xref:System.String> object. You can search the string by using methods such as <xref:System.String.LastIndexOf%2A?displayProperty=nameWithType> or <xref:System.String.StartsWith%2A?displayProperty=nameWithType>, or you can use regular expressions and the <xref:System.Text.RegularExpressions.Regex> class to search for patterns. Because both <xref:System.Text.StringBuilder> and <xref:System.String> objects use UTF-16 encoding to store characters, the index positions of characters, substrings, and regular expression matches are the same in both objects. This enables you to use <xref:System.Text.StringBuilder> methods to make changes at the same position at which that text is found in the <xref:System.String> object.

  > [!NOTE]
  > If you adopt this approach, you should work from the end of the <xref:System.Text.StringBuilder> object to its beginning so that you don't have to repeatedly convert the <xref:System.Text.StringBuilder> object to a string.

  The following example illustrates this approach. It stores four occurrences of each letter of the English alphabet in a <xref:System.Text.StringBuilder> object. It then converts the text to a <xref:System.String> object and uses a regular expression to identify the starting position of each four-character sequence. Finally, it adds an underscore before each four-character sequence except for the first sequence, and converts the first character of the sequence to uppercase.

  :::code language="csharp" source="./snippets/System.Text/StringBuilder/Overview/csharp/pattern2.cs" interactive="try-dotnet" id="Snippet13":::
  :::code language="fsharp" source="./snippets/System.Text/StringBuilder/Overview/fsharp/pattern2.fs" id="Snippet13":::
  :::code language="vb" source="./snippets/System.Text/StringBuilder/Overview/vb/pattern2.vb" id="Snippet13":::

- Use the <xref:System.Text.StringBuilder.Chars%2A?displayProperty=nameWithType> property to sequentially search a range of characters in a <xref:System.Text.StringBuilder> object. This approach might not be practical if the number of characters to be searched is large or the search logic is particularly complex. For the performance implications of character-by-character index-based access for very large, chunked <xref:System.Text.StringBuilder> objects, see the documentation for the <xref:System.Text.StringBuilder.Chars%2A?displayProperty=nameWithType> property.

  The following example is identical in functionality to the previous example but differs in implementation. It uses the <xref:System.Text.StringBuilder.Chars%2A> property to detect when a character value has changed, inserts an underscore at that position, and converts the first character in the new sequence to uppercase.

  :::code language="csharp" source="./snippets/System.Text/StringBuilder/Overview/csharp/pattern3.cs" interactive="try-dotnet" id="Snippet14":::
  :::code language="fsharp" source="./snippets/System.Text/StringBuilder/Overview/fsharp/pattern3.fs" id="Snippet14":::
  :::code language="vb" source="./snippets/System.Text/StringBuilder/Overview/vb/pattern3.vb" id="Snippet14":::

- Store all the unmodified text in the <xref:System.Text.StringBuilder> object, call the <xref:System.Text.StringBuilder.ToString%2A?displayProperty=nameWithType> method to convert the <xref:System.Text.StringBuilder> object to a <xref:System.String> object, and perform the modifications on the <xref:System.String> object. You can use this approach if you have only a few modifications; otherwise, the cost of working with immutable strings might negate the performance benefits of using a <xref:System.Text.StringBuilder> object.

  The following example is identical in functionality to the previous two examples but differs in implementation. It creates a <xref:System.Text.StringBuilder> object, converts it to a <xref:System.String> object, and then uses a regular expression to perform all remaining modifications on the string. The <xref:System.Text.RegularExpressions.Regex.Replace%28System.String%2CSystem.String%2CSystem.Text.RegularExpressions.MatchEvaluator%29?displayProperty=nameWithType> method uses a lambda expression to perform the replacement on each match.

  :::code language="csharp" source="./snippets/System.Text/StringBuilder/Overview/csharp/pattern4.cs" interactive="try-dotnet" id="Snippet15":::
  :::code language="fsharp" source="./snippets/System.Text/StringBuilder/Overview/fsharp/pattern4.fs" id="Snippet15":::
  :::code language="vb" source="./snippets/System.Text/StringBuilder/Overview/vb/pattern4.vb" id="Snippet15":::

## Convert the StringBuilder object to a string

You must convert the <xref:System.Text.StringBuilder> object to a <xref:System.String> object before you can pass the string represented by the <xref:System.Text.StringBuilder> object to a method that has a <xref:System.String> parameter or display it in the user interface. You perform this conversion by calling the <xref:System.Text.StringBuilder.ToString%2A?displayProperty=nameWithType> method. For an illustration, see the previous example, which calls the <xref:System.Text.StringBuilder.ToString%2A> method to convert a <xref:System.Text.StringBuilder> object to a string so that it can be passed to a regular expression method.
