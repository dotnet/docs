---
title: "How to: Catch a non-CLS Exception"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "exceptions [C#], non-CLS"
ms.assetid: db4630b3-5240-471a-b3a7-c7ff6ab31e8d
caps.latest.revision: 8
author: "BillWagner"
ms.author: "wiwagn"
---
# How to: Catch a non-CLS Exception
Some .NET languages, including C++/CLI, allow objects to throw exceptions that do not derive from <xref:System.Exception>. Such exceptions are called *non-CLS exceptions* or *non-Exceptions*. In [!INCLUDE[csprcs](~/includes/csprcs-md.md)] you cannot throw non-CLS exceptions, but you can catch them in two ways:  
  
-   Within a `catch (Exception e)` block as a <xref:System.Runtime.CompilerServices.RuntimeWrappedException>.  
  
     By default, a [!INCLUDE[csprcs](~/includes/csprcs-md.md)] assembly catches non-CLS exceptions as wrapped exceptions. Use this method if you need access to the original exception, which can be accessed through the <xref:System.Runtime.CompilerServices.RuntimeWrappedException.WrappedException%2A> property. The procedure later in this topic explains how to catch exceptions in this manner.  
  
-   Within a general catch block (a catch block without an exception type specified) that is put after a `catch (Exception)` or `catch (Exception e)` block.  
  
     Use this method when you want to perform some action (such as writing to a log file) in response to non-CLS exceptions, and you do not need access to the exception information. By default the common language runtime wraps all exceptions. To disable this behavior, add this assembly-level attribute to your code, typically in the AssemblyInfo.cs file: `[assembly: RuntimeCompatibilityAttribute(WrapNonExceptionThrows = false)]`.  
  
### To catch a non-CLS exception  
  
1.  Within a `catch(Exception e) block`, use the `as` keyword to test whether `e` can be cast to a <xref:System.Runtime.CompilerServices.RuntimeWrappedException>.  
  
2.  Access the original exception through the <xref:System.Runtime.CompilerServices.RuntimeWrappedException.WrappedException%2A> property.  
  
## Example  
 The following example shows how to catch a non-CLS exception that was thrown from a class library written in C++/CLR. Note that in this example, the [!INCLUDE[csprcs](~/includes/csprcs-md.md)] client code knows in advance that the exception type being thrown is a <xref:System.String?displayProperty=nameWithType>. You can cast the <xref:System.Runtime.CompilerServices.RuntimeWrappedException.WrappedException%2A> property back its original type as long as that type is accessible from your code.  
  
```  
// Class library written in C++/CLR.  
   ThrowNonCLS.Class1 myClass = new ThrowNonCLS.Class1();  
  
   try  
   {  
    // throws gcnew System::String(  
    // "I do not derive from System.Exception!");  
    myClass.TestThrow();   
   }  
  
   catch (Exception e)  
   {  
    RuntimeWrappedException rwe = e as RuntimeWrappedException;  
    if (rwe != null)      
    {  
      String s = rwe.WrappedException as String;  
      if (s != null)  
      {  
        Console.WriteLine(s);  
      }  
    }  
    else  
    {  
       // Handle other System.Exception types.  
    }  
   }             
```  
  
## See Also  
 <xref:System.Runtime.CompilerServices.RuntimeWrappedException>  
 [Exceptions and Exception Handling](../../../csharp/programming-guide/exceptions/index.md)
