# Trimming and Removing Characters from Strings

If you are parsing a sentence into individual words, you might end up with words that have blank spaces (also called white spaces) on either end of the word. In this situation, you can use one of the trim methods in the [System.String](http://dotnet.github.io/api/System.String.html) class to remove any number of spaces or other characters from a specified position in the string. The following table describes the available trim methods.

Method name | Use
----------- | ---
[String.Trim](http://dotnet.github.io/api/System.String.html#System_String_Trim) | Removes white spaces or characters specified in an array of characters from the beginning and end of a string.
[String.TrimEnd](http://dotnet.github.io/api/System.String.html#System_String_TrimEnd_System_Char___) | Removes characters specified in an array of characters from the end of a string.
[String.TrimStart](http://dotnet.github.io/api/System.String.html#System_String_TrimStart_System_Char___) | Removes characters specified in an array of characters from the beginning of a string.
[String.Remove](http://dotnet.github.io/api/System.String.html#System_String_Remove_System_Int32_) | Removes a specified number of characters from a specified index position in a string.


## Trim

You can easily remove white spaces from both ends of a string by using the [String.Trim](http://dotnet.github.io/api/System.String.html#System_String_Trim) method, as shown in the following example.

```csharp
string MyString = " Big   ";
Console.WriteLine("Hello{0}World!", MyString);
string TrimString = MyString.Trim();
Console.WriteLine("Hello{0}World!", TrimString);
//       The example displays the following output:
//             Hello Big   World!
//             HelloBigWorld!
```

You can also remove characters that you specify in a character array from the beginning and end of a string. The following example removes white-space characters, periods, and asterisks.

```csharp
using System;

public class Example
{
   public static void Main()
   {
      String header = "* A Short String. *";
      Console.WriteLine(header);
      Console.WriteLine(header.Trim( new Char[] { ' ', '*', '.' } ));
   }
}
// The example displays the following output:
//       * A Short String. *
//       A Short String
```

## TrimEnd

The [String.TrimEnd](http://dotnet.github.io/api/System.String.html#System_String_TrimEnd_System_Char___) method removes characters from the end of a string, creating a new string object. An array of characters is passed to this method to specify the characters to be removed. The order of the elements in the character array does not affect the trim operation. The trim stops when a character not specified in the array is found.

The following example removes the last letters of a string using the TrimEnd method. In this example, the position of the `'r'` character and the `'W'` character are reversed to illustrate that the order of characters in the array does not matter. Notice that this code removes the last word of `MyString` plus part of the first.

```csharp
string MyString = "Hello World!";
char[] MyChar = {'r','o','W','l','d','!',' '};
string NewString = MyString.TrimEnd(MyChar);
Console.WriteLine(NewString);
```

This code displays `He` to the console.

The following example removes the last word of a string using the [TrimEnd](http://dotnet.github.io/api/System.String.html#System_String_TrimEnd_System_Char___) method. In this code, a comma follows the word `Hello` and, because the comma is not specified in the array of characters to trim, the trim ends at the comma.

```csharp
string MyString = "Hello, World!";
char[] MyChar = {'r','o','W','l','d','!',' '};
string NewString = MyString.TrimEnd(MyChar);
Console.WriteLine(NewString);
```

This code displays `Hello,` to the console.

## TrimStart

The [String.TrimStart](http://dotnet.github.io/api/System.String.html#System_String_TrimStart_System_Char___) method is similar to the [String.TrimEnd](http://dotnet.github.io/api/System.String.html#System_String_TrimEnd_System_Char___) method except that it creates a new string by removing characters from the beginning of an existing string object. An array of characters is passed to the [TrimStart](http://dotnet.github.io/api/System.String.html#System_String_TrimStart_System_Char___) method to specify the characters to be removed. As with the [TrimEnd](http://dotnet.github.io/api/System.String.html#System_String_TrimEnd_System_Char___) method, the order of the elements in the character array does not affect the trim operation. The trim stops when a character not specified in the array is found.

The following example removes the first word of a string. In this example, the position of the `'l'` character and the `'H'` character are reversed to illustrate that the order of characters in the array does not matter.

```csharp
string MyString = "Hello World!";
char[] MyChar = {'e', 'H','l','o',' ' };
string NewString = MyString.TrimStart(MyChar);
Console.WriteLine(NewString);
```

This code displays `World!` to the console.

## Remove

The [String.Remove](http://dotnet.github.io/api/System.String.html#System_String_Remove_System_Int32_) method removes a specified number of characters that begin at a specified position in an existing string. This method assumes a zero-based index.

The following example removes ten characters from a string beginning at position five of a zero-based index of the string.

```csharp
string MyString = "Hello Beautiful World!";
Console.WriteLine(MyString.Remove(5,10));
// The example displays the following output:
//         Hello World!  
```

You can also remove a specified character or substring from a string by calling the [String.Replace(String, String)](http://dotnet.github.io/api/System.String.html#System_String_Replace_System_String_System_String_) method and specifying an empty string ([String.Empty](http://dotnet.github.io/api/System.String.html#System_String_Empty)) as the replacement. The following example removes all commas from a string.

```csharp
using System;

public class Example
{
   public static void Main()
   {
      String phrase = "a cold, dark night";
      Console.WriteLine("Before: {0}", phrase);
      phrase = phrase.Replace(",", "");
      Console.WriteLine("After: {0}", phrase);
   }
}
// The example displays the following output:
//       Before: a cold, dark night
//       After: a cold dark night
```

## See Also

[Basic String Operations](../basicstringoperations.md)







