# Using the StringBuilder Class

The [String](http://dotnet.github.io/api/System.String.html) object is immutable. Every time you use one of the methods in the [System.String](http://dotnet.github.io/api/System.String.html) class, you create a new string object in memory, which requires a new allocation of space for that new object. In situations where you need to perform repeated modifications to a string, the overhead associated with creating a new [String](http://dotnet.github.io/api/System.String.html) object can be costly. The [System.Text.StringBuilder](http://dotnet.github.io/api/System.Text.StringBuilder.html) class can be used when you want to modify a string without creating a new object. For example, using the [StringBuilder](http://dotnet.github.io/api/System.Text.StringBuilder.html) class can boost performance when concatenating many strings together in a loop.

## Importing the System.Text Namespace

The [StringBuilder](http://dotnet.github.io/api/System.Text.StringBuilder.html) class is found in the [System.Text](http://dotnet.github.io/api/System.Text.html) namespace. To avoid having to provide a fully qualified type name in your code, you can import the [System.Text](http://dotnet.github.io/api/System.Text.html) namespace: 

```csharp
using System;
using System.Text;
```

## Instantiating a StringBuilder Object

You can create a new instance of the [StringBuilder](http://dotnet.github.io/api/System.Text.StringBuilder.html) class by initializing your variable with one of the overloaded constructor methods, as illustrated in the following example.

```csharp
StringBuilder MyStringBuilder = new StringBuilder("Hello World!");
```

## Setting the Capacity and Length

Although the [StringBuilder](http://dotnet.github.io/api/System.Text.StringBuilder.html) is a dynamic object that allows you to expand the number of characters in the string that it encapsulates, you can specify a value for the maximum number of characters that it can hold. This value is called the capacity of the object and should not be confused with the length of the string that the current [StringBuilder](http://dotnet.github.io/api/System.Text.StringBuilder.html) holds. For example, you might create a new instance of the [StringBuilder](http://dotnet.github.io/api/System.Text.StringBuilder.html) class with the string "Hello", which has a length of 5, and you might specify that the object has a maximum capacity of 25. When you modify the [StringBuilder](http://dotnet.github.io/api/System.Text.StringBuilder.html), it does not reallocate size for itself until the capacity is reached. When this occurs, the new space is allocated automatically and the capacity is doubled. You can specify the capacity of the [StringBuilder](http://dotnet.github.io/api/System.Text.StringBuilder.html) class using one of the overloaded constructors. The following example specifies that the `MyStringBuilder` object can be expanded to a maximum of 25 spaces.

```csharp
StringBuilder MyStringBuilder = new StringBuilder("Hello World!", 25);
```

Additionally, you can use the read/write [Capacity](http://dotnet.github.io/api/System.Text.StringBuilder.html#System_Text_StringBuilder_Capacity) property to set the maximum length of your object. The following example uses the [Capacity](http://dotnet.github.io/api/System.Text.StringBuilder.html#System_Text_StringBuilder_Capacity) property to define the maximum object length.

```csharp
MyStringBuilder.Capacity = 25;
```

The [EnsureCapacity](http://dotnet.github.io/api/System.Text.StringBuilder.html#System_Text_StringBuilder_EnsureCapacity_System_Int32_) method can be used to check the capacity of the current [StringBuilder](http://dotnet.github.io/api/System.Text.StringBuilder.html). If the capacity is greater than the passed value, no change is made; however, if the capacity is smaller than the passed value, the current capacity is changed to match the passed value.

The [Length](http://dotnet.github.io/api/System.Text.StringBuilder.html#System_Text_StringBuilder_Length) property can also be viewed or set. If you set the [Length](http://dotnet.github.io/api/System.Text.StringBuilder.html#System_Text_StringBuilder_Length) property to a value that is greater than the [Capacity](http://dotnet.github.io/api/System.Text.StringBuilder.html#System_Text_StringBuilder_Capacity) property, the [Capacity](http://dotnet.github.io/api/System.Text.StringBuilder.html#System_Text_StringBuilder_Capacity) property is automatically changed to the same value as the [Length](http://dotnet.github.io/api/System.Text.StringBuilder.html#System_Text_StringBuilder_Length) property. Setting the [Length](http://dotnet.github.io/api/System.Text.StringBuilder.html#System_Text_StringBuilder_Length) property to a value that is less than the length of the string within the current [StringBuilder](http://dotnet.github.io/api/System.Text.StringBuilder.html) shortens the string.

## Modifying the StringBuilder String

The following table lists the methods you can use to modify the contents of a [StringBuilder](http://dotnet.github.io/api/System.Text.StringBuilder.html).

Method name | Use
----------- | ---
[StringBuilder.Append](http://dotnet.github.io/api/System.Text.StringBuilder.html#System_Text_StringBuilder_Append_System_Char_) | Appends information to the end of the current [StringBuilder](http://dotnet.github.io/api/System.Text.StringBuilder.html).
[StringBuilder.AppendFormat](http://dotnet.github.io/api/System.Text.StringBuilder.html#System_Text_StringBuilder_AppendFormat_System_IFormatProvider_System_String_System_Object_) | Replaces a format specifier passed in a string with formatted text.
[StringBuilder.Insert](http://dotnet.github.io/api/System.Text.StringBuilder.html#System_Text_StringBuilder_Insert_System_Int32_System_Char_) | Inserts a string or object into the specified index of the current [StringBuilder](http://dotnet.github.io/api/System.Text.StringBuilder.html).
[StringBuilder.Remove](http://dotnet.github.io/api/System.Text.StringBuilder.html#System_Text_StringBuilder_Remove_System_Int32_System_Int32_) | Removes a specified number of characters from the current [StringBuilder](http://dotnet.github.io/api/System.Text.StringBuilder.html).
[StringBuilder.Replace](http://dotnet.github.io/api/System.Text.StringBuilder.html#System_Text_StringBuilder_Replace_System_Char_System_Char_) | Replaces a specified character at a specified index.

### Append

The [StringBuilder.Append](http://dotnet.github.io/api/System.Text.StringBuilder.html#System_Text_StringBuilder_Append_System_Char_) method can be used to add text or a string representation of an object to the end of a string represented by the current [StringBuilder](http://dotnet.github.io/api/System.Text.StringBuilder.html). The following example initializes a [StringBuilder](http://dotnet.github.io/api/System.Text.StringBuilder.html) to "Hello World" and then appends some text to the end of the object. Space is allocated automatically as needed.

```csharp
StringBuilder MyStringBuilder = new StringBuilder("Hello World!");
MyStringBuilder.Append(" What a beautiful day.");
Console.WriteLine(MyStringBuilder);
// The example displays the following output:
//       Hello World! What a beautiful day.
```

### AppendFormat

The [StringBuilder.AppendFormat](http://dotnet.github.io/api/System.Text.StringBuilder.html#System_Text_StringBuilder_AppendFormat_System_IFormatProvider_System_String_System_Object_) method adds text to the end of the [StringBuilder](http://dotnet.github.io/api/System.Text.StringBuilder.html) object. It supports the composite formatting feature (for more information, see [Composite Formatting](../compositeformat.md)) by calling the [IFormattable](http://dotnet.github.io/api/System.IFormattable.html) implementation of the object or objects to be formatted. Therefore, it accepts the standard format strings for numeric, date and time, and enumeration values, the custom format strings for numeric and date and time values, and the format strings defined for custom types. (For information about formatting, see [Formatting Types](../formattingtypes.md).) You can use this method to customize the format of variables and append those values to a [StringBuilder](http://dotnet.github.io/api/System.Text.StringBuilder.html). The following example uses the AppendFormat method to place an integer value formatted as a currency value at the end of a [StringBuilder](http://dotnet.github.io/api/System.Text.StringBuilder.html) object.

```csharp
int MyInt = 25; 
StringBuilder MyStringBuilder = new StringBuilder("Your total is ");
MyStringBuilder.AppendFormat("{0:C} ", MyInt);
Console.WriteLine(MyStringBuilder);
// The example displays the following output:
//       Your total is $25.00
```

### Insert

The [StringBuilder.Insert](http://dotnet.github.io/api/System.Text.StringBuilder.html#System_Text_StringBuilder_Insert_System_Int32_System_Char_) method adds a string or object to a specified position in the current [StringBuilder](http://dotnet.github.io/api/System.Text.StringBuilder.html) object. The following example uses this method to insert a word into the sixth position of a [StringBuilder](http://dotnet.github.io/api/System.Text.StringBuilder.html) object.

```csharp
StringBuilder MyStringBuilder = new StringBuilder("Hello World!");
MyStringBuilder.Insert(6,"Beautiful ");
Console.WriteLine(MyStringBuilder);
// The example displays the following output:
//       Hello Beautiful World!
```

### Remove

You can use the [StringBuilder.Remove](http://dotnet.github.io/api/System.Text.StringBuilder.html#System_Text_StringBuilder_Remove_System_Int32_System_Int32_) method to remove a specified number of characters from the current [StringBuilder](http://dotnet.github.io/api/System.Text.StringBuilder.html) object, beginning at a specified zero-based index. The following example uses the [Remove](http://dotnet.github.io/api/System.Text.StringBuilder.html#System_Text_StringBuilder_Remove_System_Int32_System_Int32_) method to shorten a [StringBuilder](http://dotnet.github.io/api/System.Text.StringBuilder.html) object.

```csharp
StringBuilder MyStringBuilder = new StringBuilder("Hello World!");
MyStringBuilder.Remove(5,7);
Console.WriteLine(MyStringBuilder);
// The example displays the following output:
//       Hello
```

### Replace

The [StringBuilder.Replace](http://dotnet.github.io/api/System.Text.StringBuilder.html#System_Text_StringBuilder_Replace_System_Char_System_Char_) | Replaces a specified character at a specified index.
 method can be used to replace characters within the [StringBuilder](http://dotnet.github.io/api/System.Text.StringBuilder.html) object with another specified character. The following example uses the [Replace](http://dotnet.github.io/api/System.Text.StringBuilder.html#System_Text_StringBuilder_Replace_System_Char_System_Char_) | Replaces a specified character at a specified index.
 method to search a [StringBuilder](http://dotnet.github.io/api/System.Text.StringBuilder.html) object for all instances of the exclamation point character (!) and replace them with the question mark character (?).
 
 ```csharp
 StringBuilder MyStringBuilder = new StringBuilder("Hello World!");
MyStringBuilder.Replace('!', '?');
Console.WriteLine(MyStringBuilder);
// The example displays the following output:
//       Hello World?
```

## Converting a StringBuilder Object to a String

You must convert the [StringBuilder](http://dotnet.github.io/api/System.Text.StringBuilder.html) object to a String object before you can pass the string represented by the [StringBuilder](http://dotnet.github.io/api/System.Text.StringBuilder.html) object to a method that has a [String](http://dotnet.github.io/api/System.String.html) parameter or display it in the user interface. You do this conversion by calling the [StringBuilder.ToString](http://dotnet.github.io/api/System.Text.StringBuilder.html#System_Text_StringBuilder_ToString) method. The following example calls a number of [StringBuilder](http://dotnet.github.io/api/System.Text.StringBuilder.html) methods and then calls the [StringBuilder.ToString](http://dotnet.github.io/api/System.Text.StringBuilder.html#System_Text_StringBuilder_ToString) method to display the string.

```csharp
using System;
using System.Text;

public class Example
{
   public static void Main()
   {
      StringBuilder sb = new StringBuilder();
      bool flag = true;
      string[] spellings = { "recieve", "receeve", "receive" };
      sb.AppendFormat("Which of the following spellings is {0}:", flag);
      sb.AppendLine();
      for (int ctr = 0; ctr <= spellings.GetUpperBound(0); ctr++) {
         sb.AppendFormat("   {0}. {1}", ctr, spellings[ctr]);
         sb.AppendLine();
      }
      sb.AppendLine();
      Console.WriteLine(sb.ToString());
   }
}
// The example displays the following output:
//       Which of the following spellings is True:
//          0. recieve
//          1. receeve
//          2. receive
```

## See Also

[System.Text.StringBuilder](http://dotnet.github.io/api/System.Text.StringBuilder.html)

[Basic String Operations](../basicstringoperations.md)

[Formatting Types](../formattingtypes.md)
