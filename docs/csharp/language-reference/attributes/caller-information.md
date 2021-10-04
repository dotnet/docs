---
title: "C# Reserved attributes: Tracking caller information"
ms.date: 04/09/2020
description: These attributes instruct the compiler to generate information about the code that calls a member. You use the CallerFilePath, CallerLineNumber, and CallerMemberName to provide detailed trace information
---

# Reserved attributes: Determine caller information

Using info attributes, you obtain information about the caller to a method. You obtain the file path of the source code, the line number in the source code, and the member name of the caller. To obtain member caller information, you use attributes that are applied to optional parameters. Each optional parameter specifies a default value. The following table lists the Caller Info attributes that are defined in the <xref:System.Runtime.CompilerServices?displayProperty=nameWithType> namespace:

|Attribute|Description|Type|
|---|---|---|
|<xref:System.Runtime.CompilerServices.CallerFilePathAttribute>|Full path of the source file that contains the caller. The full path is the path at compile time.|`String`|
|<xref:System.Runtime.CompilerServices.CallerLineNumberAttribute>|Line number in the source file from which the method is called.|`Integer`|
|<xref:System.Runtime.CompilerServices.CallerMemberNameAttribute>|Method name or property name of the caller.|`String`|

This information helps you write tracing, debugging, and create diagnostic tools. The following example shows how to use caller info attributes. On each call to the `TraceMessage` method, the caller information is substituted as arguments to the optional parameters.

```csharp
public void DoProcessing()
{
    TraceMessage("Something happened.");
}

public void TraceMessage(string message,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string sourceFilePath = "",
        [CallerLineNumber] int sourceLineNumber = 0)
{
    Trace.WriteLine("message: " + message);
    Trace.WriteLine("member name: " + memberName);
    Trace.WriteLine("source file path: " + sourceFilePath);
    Trace.WriteLine("source line number: " + sourceLineNumber);
}

// Sample Output:
//  message: Something happened.
//  member name: DoProcessing
//  source file path: c:\Visual Studio Projects\CallerInfoCS\CallerInfoCS\Form1.cs
//  source line number: 31
```

You specify an explicit default value for each optional parameter. You can't apply caller info attributes to parameters that aren't specified as optional. The caller info attributes don't make a parameter optional. Instead, they affect the default value that's passed in when the argument is omitted. Caller info values are emitted as literals into the Intermediate Language (IL) at compile time. Unlike the results of the <xref:System.Exception.StackTrace%2A> property for exceptions, the results aren't affected by obfuscation. You can explicitly supply the optional arguments to control the caller information or to hide caller information.

### Member names

You can use the `CallerMemberName` attribute to avoid specifying the member name as a `String` argument to the called method. By using this technique, you avoid the problem that **Rename Refactoring** doesn't change the `String` values. This benefit is especially useful for the following tasks:

- Using tracing and diagnostic routines.
- Implementing the <xref:System.ComponentModel.INotifyPropertyChanged> interface when binding data. This interface allows the property of an object to notify a bound control that the property has changed, so that the control can display the updated information. Without the `CallerMemberName` attribute, you must specify the property name as a literal.

The following chart shows the member names that are returned when you use the `CallerMemberName` attribute.

|Calls occur within|Member name result|
|-|-|
|Method, property, or event|The name of the method, property, or event from which the call originated.|
|Constructor|The string ".ctor"|
|Static constructor|The string ".cctor"|
|Finalizer|The string "Finalize"|
|User-defined operators or conversions|The generated name for the member, for example, "op_Addition".|
|Attribute constructor|The name of the method or property to which the attribute is applied. If the attribute is any element within a member (such as a parameter, a return value, or a generic type parameter), this result is the name of the member that's associated with that element.|
|No containing member (for example, assembly-level or attributes that are applied to types)|The default value of the optional parameter.|

## See also

- [Named and Optional Arguments](../../programming-guide/classes-and-structs/named-and-optional-arguments.md)
- <xref:System.Reflection>
- <xref:System.Attribute>
- [Attributes](../../../standard/attributes/index.md)
