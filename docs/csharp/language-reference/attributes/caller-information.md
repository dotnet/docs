---
title: "Attributes interpreted by the C# compiler: Tracking caller information"
ms.date: 11/02/2021
description: These attributes instruct the compiler to generate information about the code that calls a member. You use the CallerFilePath, CallerLineNumber, CallerMemberName, and CallerArgumentExpression to provide detailed trace information
---

# Determine caller information using attributes interpreted by the C# compiler

Using info attributes, you obtain information about the caller to a method. You obtain the file path of the source code, the line number in the source code, and the member name of the caller. To obtain member caller information, you use attributes that are applied to optional parameters. Each optional parameter specifies a default value. The following table lists the Caller Info attributes that are defined in the <xref:System.Runtime.CompilerServices?displayProperty=nameWithType> namespace:

|Attribute|Description|Type|
|---|---|---|
|<xref:System.Runtime.CompilerServices.CallerFilePathAttribute>|Full path of the source file that contains the caller. The full path is the path at compile time.|`String`|
|<xref:System.Runtime.CompilerServices.CallerLineNumberAttribute>|Line number in the source file from which the method is called.|`Integer`|
|<xref:System.Runtime.CompilerServices.CallerMemberNameAttribute>|Method name or property name of the caller.|`String`|
| <xref:System.Runtime.CompilerServices.CallerArgumentExpressionAttribute>|String representation of the argument expression.|`String`|

This information helps you with tracing and debugging, and helps you to create diagnostic tools. The following example shows how to use caller info attributes. On each call to the `TraceMessage` method, the caller information is inserted for the arguments to the optional parameters.

:::code language="csharp" source="./snippets/CallerInformation.cs" id="CallerFileMemberLine":::

You specify an explicit default value for each optional parameter. You can't apply caller info attributes to parameters that aren't specified as optional. The caller info attributes don't make a parameter optional. Instead, they affect the default value that's passed in when the argument is omitted. Caller info values are emitted as literals into the Intermediate Language (IL) at compile time. Unlike the results of the <xref:System.Exception.StackTrace%2A> property for exceptions, the results aren't affected by obfuscation. You can explicitly supply the optional arguments to control the caller information or to hide caller information.

## Member names

You can use the `CallerMemberName` attribute to avoid specifying the member name as a `String` argument to the called method. By using this technique, you avoid the problem that **Rename Refactoring** doesn't change the `String` values. This benefit is especially useful for the following tasks:

- Using tracing and diagnostic routines.
- Implementing the <xref:System.ComponentModel.INotifyPropertyChanged> interface when binding data. This interface allows the property of an object to notify a bound control that the property has changed. The control can display the updated information. Without the `CallerMemberName` attribute, you must specify the property name as a literal.

The following chart shows the member names that are returned when you use the `CallerMemberName` attribute.

| Calls occur within | Member name result |
|-|-|
| Method, property, or event | The name of the method, property, or event from which the call originated.|
| Constructor | The string ".ctor" |
| Static constructor | The string ".cctor" |
| Finalizer | The string "Finalize" |
| User-defined operators or conversions | The generated name for the member, for example, "op_Addition". |
| Attribute constructor | The name of the method or property to which the attribute is applied. If the attribute is any element within a member (such as a parameter, a return value, or a generic type parameter), this result is the name of the member that's associated with that element. |
| No containing member (for example, assembly-level or attributes that are applied to types) | The default value of the optional parameter. |

## Argument expressions

You use the <xref:System.Runtime.CompilerServices.CallerArgumentExpressionAttribute?displayProperty=nameWithType> when you want the expression passed as an argument. Diagnostic libraries may want to provide more details about the *expressions* passed to arguments. By providing the expression that triggered the diagnostic, in addition to the parameter name, developers have more details about the condition that triggered the diagnostic. That extra information makes it easier to fix.

The following example shows how you can provide detailed information about the argument when it's invalid:

:::code language="csharp" source="./snippets/CallerInformation.cs" id="TestCondition":::

You would invoke it as shown in the following example:

:::code language="csharp" source="./snippets/CallerInformation.cs" id="InvokeTestCondition":::

The expression used for `condition` is injected by the compiler into the `message` argument. When a developer calls `Operation` with a `null` argument, the following message is stored in the `ArgumentException`:

```dotnetcli
Argument failed validation: <func is not null>
```

This attribute enables you to write diagnostic utilities that provide more details. Developers can more quickly understand what changes are needed. You can also use the <xref:System.Runtime.CompilerServices.CallerArgumentExpressionAttribute> to determine what expression was used as the receiver for extension methods. The following method samples a sequence at regular intervals. If the sequence has fewer elements than the frequency, it reports an error:

:::code language="csharp" source="./snippets/CallerInformation.cs" id="ExtensionMethod":::

You could call this method as follows:

:::code language="csharp" source="./snippets/Program.cs" id="ShortSequence":::

The preceding example would throw an <xref:System.ArgumentException> whose message is the following text:

```dotnetcli
Expression doesn't have enough elements: Enumerable.Range(0, 10) (Parameter 'sequence')
```

## See also

- [Named and Optional Arguments](../../programming-guide/classes-and-structs/named-and-optional-arguments.md)
- <xref:System.Reflection>
- <xref:System.Attribute>
- [Attributes](../../../standard/attributes/index.md)
