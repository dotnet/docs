---
title: "Covariance and Contravariance (C#)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
ms.assetid: 066d9a3c-aab7-4ea6-826d-0b1a85399c74
caps.latest.revision: 3
author: "BillWagner"
ms.author: "wiwagn"
---
# Covariance and Contravariance (C#)
In C#, covariance and contravariance enable implicit reference conversion for array types, delegate types, and generic type arguments. Covariance preserves assignment compatibility and contravariance reverses it.  
  
 The following code demonstrates the difference between assignment compatibility, covariance, and contravariance.  
  
```csharp  
// Assignment compatibility.   
string str = "test";  
// An object of a more derived type is assigned to an object of a less derived type.   
object obj = str;  
  
// Covariance.   
IEnumerable<string> strings = new List<string>();  
// An object that is instantiated with a more derived type argument   
// is assigned to an object instantiated with a less derived type argument.   
// Assignment compatibility is preserved.   
IEnumerable<object> objects = strings;  
  
// Contravariance.             
// Assume that the following method is in the class:   
// static void SetObject(object o) { }   
Action<object> actObject = SetObject;  
// An object that is instantiated with a less derived type argument   
// is assigned to an object instantiated with a more derived type argument.   
// Assignment compatibility is reversed.   
Action<string> actString = actObject;  
```  
  
 Covariance for arrays enables implicit conversion of an array of a more derived type to an array of a less derived type. But this operation is not type safe, as shown in the following code example.  
  
```csharp  
object[] array = new String[10];  
// The following statement produces a run-time exception.  
// array[0] = 10;  
```  
  
 Covariance and contravariance support for method groups allows for matching method signatures with delegate types. This enables you to assign to delegates not only methods that have matching signatures, but also methods that return more derived types (covariance) or that accept parameters that have less derived types (contravariance) than that specified by the delegate type. For more information, see [Variance in Delegates (C#)](../../../../csharp/programming-guide/concepts/covariance-contravariance/variance-in-delegates.md) and [Using Variance in Delegates (C#)](../../../../csharp/programming-guide/concepts/covariance-contravariance/using-variance-in-delegates.md).  
  
 The following code example shows covariance and contravariance support for method groups.  
  
```csharp  
static object GetObject() { return null; }  
static void SetObject(object obj) { }  
  
static string GetString() { return ""; }  
static void SetString(string str) { }  
  
static void Test()  
{  
    // Covariance. A delegate specifies a return type as object,  
    // but you can assign a method that returns a string.  
    Func<object> del = GetString;  
  
    // Contravariance. A delegate specifies a parameter type as string,  
    // but you can assign a method that takes an object.  
    Action<string> del2 = SetObject;  
}  
```  
  
 In .NET Framework 4 or newer C# supports covariance and contravariance in generic interfaces and delegates and allows for implicit conversion of generic type parameters. For more information, see [Variance in Generic Interfaces (C#)](../../../../csharp/programming-guide/concepts/covariance-contravariance/variance-in-generic-interfaces.md) and [Variance in Delegates (C#)](../../../../csharp/programming-guide/concepts/covariance-contravariance/variance-in-delegates.md).  
  
 The following code example shows implicit reference conversion for generic interfaces.  
  
```csharp  
IEnumerable<String> strings = new List<String>();  
IEnumerable<Object> objects = strings;  
```  
  
 A generic interface or delegate is called *variant* if its generic parameters are declared covariant or contravariant. C# enables you to create your own variant interfaces and delegates. For more information, see [Creating Variant Generic Interfaces (C#)](../../../../csharp/programming-guide/concepts/covariance-contravariance/creating-variant-generic-interfaces.md) and [Variance in Delegates (C#)](../../../../csharp/programming-guide/concepts/covariance-contravariance/variance-in-delegates.md).  
  
## Related Topics  
  
|Title|Description|  
|-----------|-----------------|  
|[Variance in Generic Interfaces (C#)](../../../../csharp/programming-guide/concepts/covariance-contravariance/variance-in-generic-interfaces.md)|Discusses covariance and contravariance in generic interfaces and provides a list of variant generic interfaces in the .NET Framework.|  
|[Creating Variant Generic Interfaces (C#)](../../../../csharp/programming-guide/concepts/covariance-contravariance/creating-variant-generic-interfaces.md)|Shows how to create custom variant interfaces.|  
|[Using Variance in Interfaces for Generic Collections (C#)](../../../../csharp/programming-guide/concepts/covariance-contravariance/using-variance-in-interfaces-for-generic-collections.md)|Shows how covariance and contravariance support in the <xref:System.Collections.Generic.IEnumerable%601> and <xref:System.IComparable%601> interfaces can help you reuse code.|  
|[Variance in Delegates (C#)](../../../../csharp/programming-guide/concepts/covariance-contravariance/variance-in-delegates.md)|Discusses covariance and contravariance in generic and non-generic delegates and provides a list of variant generic delegates in the .NET Framework.|  
|[Using Variance in Delegates (C#)](../../../../csharp/programming-guide/concepts/covariance-contravariance/using-variance-in-delegates.md)|Shows how to use covariance and contravariance support in non-generic delegates to match method signatures with delegate types.|  
|[Using Variance for Func and Action Generic Delegates (C#)](../../../../csharp/programming-guide/concepts/covariance-contravariance/using-variance-for-func-and-action-generic-delegates.md)|Shows how covariance and contravariance support in the `Func` and `Action` delegates can help you reuse code.|
