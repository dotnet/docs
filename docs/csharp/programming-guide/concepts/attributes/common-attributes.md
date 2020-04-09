---
title: "Common Attributes (C#)"
ms.date: 07/20/2015
ms.assetid: 785a0526-6c0e-4599-8c61-ccdc88dd9965
---
# Common Attributes (C#)
This topic describes the attributes that are most commonly used in C# programs.  
  
- [Global Attributes](#Global)  
  
- [Obsolete Attribute](#Obsolete)  
  
- [Conditional Attribute](#Conditional)  
  
- [Caller Info Attributes](#CallerInfo)  
  
## <a name="Obsolete"></a> Obsolete Attribute  
 The `Obsolete` attribute marks a program entity as one that is no longer recommended for use. Each use of an entity marked obsolete will subsequently generate a warning or an error, depending on how the attribute is configured. For example:  
  
```csharp  
[System.Obsolete("use class B")]  
class A  
{  
    public void Method() { }  
}  
class B  
{  
    [System.Obsolete("use NewMethod", true)]  
    public void OldMethod() { }  
    public void NewMethod() { }  
}  
```  
  
 In this example the `Obsolete` attribute is applied to class `A` and to method `B.OldMethod`. Because the second argument of the attribute constructor applied to `B.OldMethod` is set to `true`, this method will cause a compiler error, whereas using class `A` will just produce a warning. Calling `B.NewMethod`, however, produces no warning or error.  
  
 The string provided as the first argument to attribute constructor will be displayed as part of the warning or error. For example, when you use it with the previous definitions, the following code generates two warnings and one error:  
  
```csharp  
// Generates 2 warnings:  
// A a = new A();  
  
// Generate no errors or warnings:  
B b = new B();  
b.NewMethod();  
  
// Generates an error, terminating compilation:  
// b.OldMethod();  
```  
  
 Two warnings for class `A` are generated: one for the declaration of the class reference, and one for the class constructor.  
  
 The `Obsolete` attribute can be used without arguments, but including an explanation of why the item is obsolete and what to use instead is recommended.  
  
 The `Obsolete` attribute is a single-use attribute and can be applied to any entity that allows attributes. `Obsolete` is an alias for <xref:System.ObsoleteAttribute>.  
  
## <a name="Conditional"></a> Conditional Attribute  
 The `Conditional` attribute makes the execution of a method dependent on a preprocessing identifier. The `Conditional` attribute is an alias for <xref:System.Diagnostics.ConditionalAttribute>, and can be applied to a method or an attribute class.  
  
 In this example, `Conditional` is applied to a method to enable or disable the display of program-specific diagnostic information:  
  
```csharp  
#define TRACE_ON  
using System;  
using System.Diagnostics;  
  
public class Trace  
{  
    [Conditional("TRACE_ON")]  
    public static void Msg(string msg)  
    {  
        Console.WriteLine(msg);  
    }  
}  
  
public class ProgramClass  
{  
    static void Main()  
    {  
        Trace.Msg("Now in Main...");  
        Console.WriteLine("Done.");  
    }  
}  
```  
  
 If the `TRACE_ON` identifier is not defined, no trace output will be displayed.  
  
 The `Conditional` attribute is often used with the `DEBUG` identifier to enable trace and logging features for debug builds but not in release builds, like this:  
  
```csharp  
[Conditional("DEBUG")]  
static void DebugMethod()  
{  
}  
```  
  
 When a method marked as conditional is called, the presence or absence of the specified preprocessing symbol determines whether the call is included or omitted. If the symbol is defined, the call is included; otherwise, the call is omitted. Using `Conditional` is a cleaner, more elegant, and less error-prone alternative to enclosing methods inside `#if…#endif` blocks, like this:  
  
```csharp  
#if DEBUG  
    void ConditionalMethod()  
    {  
    }  
#endif  
```  
  
 A conditional method must be a method in a class or struct declaration and must not have a return value.  
  
### Using Multiple Identifiers  
 If a method has multiple `Conditional` attributes, a call to the method is included if at least one of the conditional symbols is defined (in other words, the symbols are logically linked together by using the OR operator). In this example, the presence of either `A` or `B` will result in a method call:  
  
```csharp  
[Conditional("A"), Conditional("B")]  
static void DoIfAorB()  
{  
    // ...  
}  
```  
  
 To achieve the effect of logically linking symbols by using the AND operator, you can define serial conditional methods. For example, the second method below will execute only if both `A` and `B` are defined:  
  
```csharp
[Conditional("A")]  
static void DoIfA()  
{  
    DoIfAandB();  
}  
  
[Conditional("B")]  
static void DoIfAandB()  
{  
    // Code to execute when both A and B are defined...  
}  
```  
  
### Using Conditional with Attribute Classes  
 The `Conditional` attribute can also be applied to an attribute class definition. In this example, the custom attribute `Documentation` will only add information to the metadata if DEBUG is defined.  
  
```csharp  
[Conditional("DEBUG")]  
public class Documentation : System.Attribute  
{  
    string text;  
  
    public Documentation(string text)  
    {  
        this.text = text;  
    }  
}  
  
class SampleClass  
{  
    // This attribute will only be included if DEBUG is defined.  
    [Documentation("This method displays an integer.")]  
    static void DoWork(int i)  
    {  
        System.Console.WriteLine(i.ToString());  
    }  
}  
```  
  
## <a name="CallerInfo"></a> Caller Info Attributes  
 By using Caller Info attributes, you can obtain information about the caller to a method. You can obtain the file path of the source code, the line number in the source code, and the member name of the caller.  
  
 To obtain member caller information, you use attributes that are applied to optional parameters. Each optional parameter specifies a default value. The following table lists the Caller Info attributes that are defined in the <xref:System.Runtime.CompilerServices?displayProperty=nameWithType> namespace:  
  
|Attribute|Description|Type|  
|---|---|---|  
|<xref:System.Runtime.CompilerServices.CallerFilePathAttribute>|Full path of the source file that contains the caller. This is the path at compile time.|`String`|  
|<xref:System.Runtime.CompilerServices.CallerLineNumberAttribute>|Line number in the source file from which the method is called.|`Integer`|  
|<xref:System.Runtime.CompilerServices.CallerMemberNameAttribute>|Method name or property name of the caller. For more information, see [Caller Information (C#)](../caller-information.md).|`String`|  
  
 For more information about the Caller Info attributes, see [Caller Information (C#)](../caller-information.md).  
  
## See also

- <xref:System.Reflection>
- <xref:System.Attribute>
- [C# Programming Guide](../../index.md)
- [Attributes](../../../../standard/attributes/index.md)
- [Reflection (C#)](../reflection.md)
- [Accessing Attributes by Using Reflection (C#)](./accessing-attributes-by-using-reflection.md)
