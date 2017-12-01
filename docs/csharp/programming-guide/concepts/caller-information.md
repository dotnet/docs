---
title: "Caller Information (C#)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
ms.assetid: ffad3d24-2fb7-4641-9124-53b5bc91d339
caps.latest.revision: 3
author: "BillWagner"
ms.author: "wiwagn"
---
# Caller Information (C#)
By using Caller Info attributes, you can obtain information about the caller to a method. You can obtain file path of the source code, the line number in the source code, and the member name of the caller. This information is helpful for tracing, debugging, and creating diagnostic tools.  
  
 To obtain this information, you use attributes that are applied to optional parameters, each of which has a default value. The following table lists the Caller Info attributes that are defined in the <xref:System.Runtime.CompilerServices?displayProperty=nameWithType> namespace:  
  
|Attribute|Description|Type|  
|---|---|---|  
|<xref:System.Runtime.CompilerServices.CallerFilePathAttribute>|Full path of the source file that contains the caller. This is the file path at compile time.|`String`|  
|<xref:System.Runtime.CompilerServices.CallerLineNumberAttribute>|Line number in the source file at which the method is called.|`Integer`|  
|<xref:System.Runtime.CompilerServices.CallerMemberNameAttribute>|Method or property name of the caller. See [Member Names](#MEMBERNAMES) later in this topic.|`String`|  
  
## Example  
 The following example shows how to use Caller Info attributes. On each call to the `TraceMessage` method, the caller information is substituted as arguments to the optional parameters.  
  
```csharp  
public void DoProcessing()  
{  
    TraceMessage("Something happened.");  
}  
  
public void TraceMessage(string message,  
        [System.Runtime.CompilerServices.CallerMemberName] string memberName = "",  
        [System.Runtime.CompilerServices.CallerFilePath] string sourceFilePath = "",  
        [System.Runtime.CompilerServices.CallerLineNumber] int sourceLineNumber = 0)  
{  
    System.Diagnostics.Trace.WriteLine("message: " + message);  
    System.Diagnostics.Trace.WriteLine("member name: " + memberName);  
    System.Diagnostics.Trace.WriteLine("source file path: " + sourceFilePath);  
    System.Diagnostics.Trace.WriteLine("source line number: " + sourceLineNumber);  
}  
  
// Sample Output:  
//  message: Something happened.  
//  member name: DoProcessing  
//  source file path: c:\Users\username\Documents\Visual Studio 2012\Projects\CallerInfoCS\CallerInfoCS\Form1.cs  
//  source line number: 31  
```  
  
## Remarks  
 You must specify an explicit default value for each optional parameter. You can't apply Caller Info attributes to parameters that aren't specified as optional.  
  
 The Caller Info attributes don't make a parameter optional. Instead, they affect the default value that's passed in when the argument is omitted.  
  
 Caller Info values are emitted as literals into the Intermediate Language (IL) at compile time. Unlike the results of the <xref:System.Exception.StackTrace%2A> property for exceptions, the results aren't affected by obfuscation.  
  
 You can explicitly supply the optional arguments to control the caller information or to hide caller information.  
  
###  <a name="MEMBERNAMES"></a> Member Names  
 You can use the `CallerMemberName` attribute to avoid specifying the member name as a `String` argument to the called method. By using this technique, you avoid the problem that **Rename Refactoring** doesn't change the `String` values. This benefit is especially useful for the following tasks:  
  
-   Using tracing and diagnostic routines.  
  
-   Implementing the <xref:System.ComponentModel.INotifyPropertyChanged> interface when binding data. This interface allows the property of an object to notify a bound control that the property has changed, so that the control can display the updated information. Without the `CallerMemberName` attribute, you must specify the property name as a literal.  
  
 The following chart shows the member names that are returned when you use the `CallerMemberName` attribute.  
  
|Calls occurs within|Member name result|  
|-------------------------|------------------------|  
|Method, property, or event|The name of the method, property, or event from which the call originated.|  
|Constructor|The string ".ctor"|  
|Static constructor|The string ".cctor"|  
|Destructor|The string "Finalize"|  
|User-defined operators or conversions|The generated name for the member, for example, "op_Addition".|  
|Attribute constructor|The name of the member to which the attribute is applied. If the attribute is any element within a member (such as a parameter, a return value, or a generic type parameter), this result is the name of the member that's associated with that element.|  
|No containing member (for example, assembly-level or attributes that are applied to types)|The default value of the optional parameter.|  
  
## See Also  
 [Attributes (C#)](../../../csharp/programming-guide/concepts/attributes/index.md)  
 [Common Attributes (C#)](../../../csharp/programming-guide/concepts/attributes/common-attributes.md)  
 [Named and Optional Arguments](../../../csharp/programming-guide/classes-and-structs/named-and-optional-arguments.md)  
 [Programming Concepts (C#)](../../../csharp/programming-guide/concepts/index.md)
