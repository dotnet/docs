---
title: "How to catch a non-CLS exception"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "exceptions [C#], non-CLS"
ms.assetid: db4630b3-5240-471a-b3a7-c7ff6ab31e8d
---
# How to catch a non-CLS exception
Some .NET languages, including C++/CLI, allow objects to throw exceptions that do not derive from <xref:System.Exception>. Such exceptions are called *non-CLS exceptions* or *non-Exceptions*. In C# you cannot throw non-CLS exceptions, but you can catch them in two ways:  
  
- Within a `catch (RuntimeWrappedException e)` block.
  
     By default, a Visual C# assembly catches non-CLS exceptions as wrapped exceptions. Use this method if you need access to the original exception, which can be accessed through the <xref:System.Runtime.CompilerServices.RuntimeWrappedException.WrappedException%2A?displayProperty=nameWithType> property. The procedure later in this topic explains how to catch exceptions in this manner.  
  
- Within a general catch block (a catch block without an exception type specified) that is put after all other `catch` blocks.
  
     Use this method when you want to perform some action (such as writing to a log file) in response to non-CLS exceptions, and you do not need access to the exception information. By default the common language runtime wraps all exceptions. To disable this behavior, add this assembly-level attribute to your code, typically in the AssemblyInfo.cs file: `[assembly: RuntimeCompatibilityAttribute(WrapNonExceptionThrows = false)]`.  
  
### To catch a non-CLS exception  
  
Within a `catch(RuntimeWrappedException e)` block, access the original exception through the <xref:System.Runtime.CompilerServices.RuntimeWrappedException.WrappedException%2A?displayProperty=nameWithType> property.  
  
## Example  
 The following example shows how to catch a non-CLS exception that was thrown from a class library written in C++/CLI. Note that in this example, the C# client code knows in advance that the exception type being thrown is a <xref:System.String?displayProperty=nameWithType>. You can cast the <xref:System.Runtime.CompilerServices.RuntimeWrappedException.WrappedException%2A?displayProperty=nameWithType> property back its original type as long as that type is accessible from your code.  
  
```csharp
// Class library written in C++/CLI.
var myClass = new ThrowNonCLS.Class1();

try
{
    // throws gcnew System::String(  
    // "I do not derive from System.Exception!");  
    myClass.TestThrow();
}
catch (RuntimeWrappedException e)
{
    String s = e.WrappedException as String;
    if (s != null)
    {
        Console.WriteLine(s);
    }
}
```  
  
## See also

- <xref:System.Runtime.CompilerServices.RuntimeWrappedException>
- [Exceptions and Exception Handling](./index.md)
