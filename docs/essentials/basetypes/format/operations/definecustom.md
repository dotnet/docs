# How to: Define and Use Custom Numeric Format Providers

.NET Core gives you extensive control over the string representation of numeric values. It supports the following features for customizing the format of numeric values:

* Standard numeric format strings, which provide a predefined set of formats for converting numbers to their string representation. You can use them with any numeric formatting method, such as [Decimal.ToString(String](http://dotnet.github.io/api/System.Decimal.html#System_Decimal_ToString_System_String_), that has a format parameter. For details, see [Standard Numeric Format Strings](../standardnumeric.md).

* Custom numeric format strings, which provide a set of symbols that can be combined to define custom numeric format specifiers. They can also be used with any numeric formatting method, such as [Decimal.ToString(String](http://dotnet.github.io/api/System.Decimal.html#System_Decimal_ToString_System_String_), that has a format parameter. For details, see [Custom Numeric Format Strings](../customnumeric.md).

* Custom [CultureInfo](http://dotnet.github.io/api/System.Globalization.CultureInfo.html) or [NumberFormatInfo](http://dotnet.github.io/api/System.Globalization.NumberFormatInfo.html) objects, which define the symbols and format patterns used in displaying the string representations of numeric values. You can use them with any numeric formatting method, such as [ToString](http://dotnet.github.io/api/System.Int32.html#System_Int32_ToString_System_IFormatProvider_), that has a *provider* parameter. Typically, the *provider* parameter is used to specify culture-specific formatting.

In some cases (such as when an application must display a formatted account number, an identification number, or a postal code) these three techniques are inappropriate. .NET Core also enables you to define a formatting object that is neither a [CultureInfo](http://dotnet.github.io/api/System.Globalization.CultureInfo.html) nor a [NumberFormatInfo](http://dotnet.github.io/api/System.Globalization.NumberFormatInfo.html) object to determine how a numeric value is formatted. This topic provides the step-by-step instructions for implementing such an object, and provides an example that formats telephone numbers.

## To define a custom format provider

1. Define a class that implements the [IFormatProvider](http://dotnet.github.io/api/System.IFormatProvider.html) and [ICustomFormatter](http://dotnet.github.io/api/System.ICustomFormatter.html) interfaces. 

2. Implement the [IFormatProvider.GetFormat](http://dotnet.github.io/api/System.IFormatProvider.html#System_IFormatProvider_GetFormat_System_Type_) method. [GetFormat](http://dotnet.github.io/api/System.IFormatProvider.html#System_IFormatProvider_GetFormat_System_Type_) is a callback method that the formatting method (such as the [String.Format(IFormatProvider, String, Object[])](http://dotnet.github.io/api/System.String.html#System_String_Format_System_IFormatProvider_System_String_System_Object_) method) invokes to retrieve the object that is actually responsible for performing custom formatting. A typical implementation of [GetFormat](http://dotnet.github.io/api/System.IFormatProvider.html#System_IFormatProvider_GetFormat_System_Type_) does the following:

    a. Determines whether the [Type](http://dotnet.github.io/api/System.Type.html) object passed as a method parameter represents an [ICustomFormatter](http://dotnet.github.io/api/System.ICustomFormatter.html) interface.
    
    b. If the parameter does represent the [ICustomFormatter](http://dotnet.github.io/api/System.ICustomFormatter.html) interface, [GetFormat](http://dotnet.github.io/api/System.IFormatProvider.html#System_IFormatProvider_GetFormat_System_Type_) returns an object that implements the [ICustomFormatter](http://dotnet.github.io/api/System.ICustomFormatter.html) interface that is responsible for providing custom formatting. Typically, the custom formatting object returns itself. 
    
    c. If the parameter does not represent the [ICustomFormatter](http://dotnet.github.io/api/System.ICustomFormatter.html) interface, [GetFormat](http://dotnet.github.io/api/System.IFormatProvider.html#System_IFormatProvider_GetFormat_System_Type_) returns `null`.
    
3. Implement the [ICustomFormatter.Format](http://dotnet.github.io/api/System.ICustomFormatter.html#System_ICustomFormatter_Format_System_String_System_Object_System_IFormatProvider_) method. This method is called by the [String.Format(IFormatProvider, String, Object[])](http://dotnet.github.io/api/System.String.html#System_String_Format_System_IFormatProvider_System_String_System_Object_) method and is responsible for returning the string representation of a number. Implementing the method typically involves the following:

    a. Optionally, make sure that the method is legitimately intended to provide formatting services by examining the *provider* parameter. For formatting objects that implement both [IFormatProvider](http://dotnet.github.io/api/System.IFormatProvider.html) and [ICustomFormatter](http://dotnet.github.io/api/System.ICustomFormatter.html), this involves testing the *provider* parameter for equality with the current formatting object.
    
    b. Determine whether the formatting object should support custom format specifiers. (For example, an "N" format specifier might indicate that a U.S. telephone number should be output in NANP format, and an "I" might indicate output in ITU-T Recommendation E.123 format.) If format specifiers are used, the method should handle the specific format specifier. It is passed to the method in the format parameter. If no specifier is present, the value of the *format* parameter is [String.Empty](http://dotnet.github.io/api/System.String.html#System_String_Empty).
    
    c. Retrieve the numeric value passed to the method as the *arg* parameter. Perform whatever manipulations are required to convert it to its string representation.
    
    d. Return the string representation of the *arg* parameter.
    
## To use a custom numeric formatting object

1. Create a new instance of the custom formatting class.

2. Call the [String.Format(IFormatProvider, String, Object[])](http://dotnet.github.io/api/System.String.html#System_String_Format_System_IFormatProvider_System_String_System_Object_) formatting method, passing it the custom formatting object, the formatting specifier (or [String.Empty](http://dotnet.github.io/api/System.String.html#System_String_Empty), if one is not used), and the numeric value to be formatted. 

## Example

The following example defines a custom numeric format provider named `TelephoneFormatter` that converts a number that represents a U.S. telephone number to its NANP or E.123 format. The method handles two format specifiers, "N" (which outputs the NANP format) and "I" (which outputs the international E.123 format).

```csharp
using System;
using System.Globalization;

public class TelephoneFormatter : IFormatProvider, ICustomFormatter
{
   public object GetFormat(Type formatType)
   {
      if (formatType == typeof(ICustomFormatter))
         return this;
      else
         return null;
   }               

   public string Format(string format, object arg, IFormatProvider formatProvider)
   {
      // Check whether this is an appropriate callback             
      if (! this.Equals(formatProvider))
         return null; 

      // Set default format specifier             
      if (string.IsNullOrEmpty(format)) 
         format = "N";

      string numericString = arg.ToString();

      if (format == "N")
      {
         if (numericString.Length <= 4)
            return numericString;
         else if (numericString.Length == 7)
            return numericString.Substring(0, 3) + "-" + numericString.Substring(3, 4); 
         else if (numericString.Length == 10)
               return "(" + numericString.Substring(0, 3) + ") " +
                      numericString.Substring(3, 3) + "-" + numericString.Substring(6);   
         else
            throw new FormatException( 
                      string.Format("'{0}' cannot be used to format {1}.", 
                                    format, arg.ToString()));
      }
      else if (format == "I")
      {
         if (numericString.Length < 10)
            throw new FormatException(string.Format("{0} does not have 10 digits.", arg.ToString()));
         else
            numericString = "+1 " + numericString.Substring(0, 3) + " " + numericString.Substring(3, 3) + " " + numericString.Substring(6);
      }
      else
      {
         throw new FormatException(string.Format("The {0} format specifier is invalid.", format));
      } 
      return numericString;  
   }
}

public class TestTelephoneFormatter
{
   public static void Main()
   {
      Console.WriteLine(String.Format(new TelephoneFormatter(), "{0}", 0));
      Console.WriteLine(String.Format(new TelephoneFormatter(), "{0}", 911));
      Console.WriteLine(String.Format(new TelephoneFormatter(), "{0}", 8490216));
      Console.WriteLine(String.Format(new TelephoneFormatter(), "{0}", 4257884748));

      Console.WriteLine(String.Format(new TelephoneFormatter(), "{0:N}", 0));
      Console.WriteLine(String.Format(new TelephoneFormatter(), "{0:N}", 911));
      Console.WriteLine(String.Format(new TelephoneFormatter(), "{0:N}", 8490216));
      Console.WriteLine(String.Format(new TelephoneFormatter(), "{0:N}", 4257884748));

      Console.WriteLine(String.Format(new TelephoneFormatter(), "{0:I}", 4257884748));
   }
}
```

The custom numeric format provider can be used only with the [String.Format(IFormatProvider, String, Object[])](http://dotnet.github.io/api/System.String.html#System_String_Format_System_IFormatProvider_System_String_System_Object_) method. The other overloads of numeric formatting methods (such as `ToString`) that have a parameter of type [IFormatProvider](http://dotnet.github.io/api/System.IFormatProvider.html) all pass the [IFormatProvider.GetFormat](http://dotnet.github.io/api/System.IFormatProvider.html#System_IFormatProvider_GetFormat_System_Type_) implementation a [Type](http://dotnet.github.io/api/System.Type.html) object that represents the [NumberFormatInfo](http://dotnet.github.io/api/System.Globalization.NumberFormatInfo.html) type. In return, they expect the method to return a [NumberFormatInfo](http://dotnet.github.io/api/System.Globalization.NumberFormatInfo.html) object. If it does not, the custom numeric format provider is ignored, and the [NumberFormatInfo](http://dotnet.github.io/api/System.Globalization.NumberFormatInfo.html) object for the current culture is used in its place. In the example, the `TelephoneFormatter.GetFormat` method handles the possibility that it may be inappropriately passed to a numeric formatting method by examining the method parameter and returning *null* if it represents a type other than [ICustomFormatter](http://dotnet.github.io/api/System.ICustomFormatter.html).

If a custom numeric format provider supports a set of format specifiers, make sure you provide a default behavior if no format specifier is supplied in the format item used in the S[String.Format(IFormatProvider, String, Object[])](http://dotnet.github.io/api/System.String.html#System_String_Format_System_IFormatProvider_System_String_System_Object_) method call. In the example, "N" is the default format specifier. This allows for a number to be converted to a formatted telephone number by providing an explicit format specifier. The following example illustrates such a method call.

```csharp
Console.WriteLine(String.Format(new TelephoneFormatter(), "{0:N}", 4257884748));
```

But it also allows the conversion to occur if no format specifier is present. The following example illustrates such a method call.

```csharp
Console.WriteLine(String.Format(new TelephoneFormatter(), "{0}", 4257884748));
```

If no default format specifier is defined, your implementation of the [ICustomFormatter.Format](http://dotnet.github.io/api/System.ICustomFormatter.html#System_ICustomFormatter_Format_System_String_System_Object_System_IFormatProvider_) method should include code such as the following so that .NET Core can provide formatting that your code does not support.

```csharp
if (arg is IFormattable) 
   s = ((IFormattable)arg).ToString(format, formatProvider);
else if (arg != null)    
   s = arg.ToString();
```

In the case of this example, the method that implements [ICustomFormatter.Format](http://dotnet.github.io/api/System.ICustomFormatter.html#System_ICustomFormatter_Format_System_String_System_Object_System_IFormatProvider_) is intended to serve as a callback method for the [String.Format(IFormatProvider, String, Object[])](http://dotnet.github.io/api/System.String.html#System_String_Format_System_IFormatProvider_System_String_System_Object_) method. Therefore, it examines the *formatProvider* parameter to determine whether it contains a reference to the current `TelephoneFormatter` object. However, the method can also be called directly from code. In that case, you can use the *formatProvider *parameter to provide a [CultureInfo](http://dotnet.github.io/api/System.Globalization.CultureInfo.html) or [NumberFormatInfo](http://dotnet.github.io/api/System.Globalization.NumberFormatInfo.html) object that supplies culture-specific formatting information.

## See Also

[Performing Formatting Operations](../performingformattingoperations.md)






