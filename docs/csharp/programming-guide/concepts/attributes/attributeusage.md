---
title: "AttributeUsage (C#)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
ms.assetid: 22c45568-9a6a-4c2f-8480-f38c1caa0a99
caps.latest.revision: 3
author: "BillWagner"
ms.author: "wiwagn"
---
# AttributeUsage (C#)
Determines how a custom attribute class can be used. `AttributeUsage` is an attribute that can be applied to custom attribute definitions to control how the new attribute can be applied. The default settings look like this when applied explicitly:  
  
```csharp  
[System.AttributeUsage(System.AttributeTargets.All,  
                   AllowMultiple = false,  
                   Inherited = true)]  
class NewAttribute : System.Attribute { }  
```  
  
 In this example, the `NewAttribute` class can be applied to any attribute-able code entity, but can be applied only once to each entity. It is inherited by derived classes when applied to a base class.  
  
 The `AllowMultiple` and `Inherited` arguments are optional, so this code has the same effect:  
  
```csharp  
[System.AttributeUsage(System.AttributeTargets.All)]  
class NewAttribute : System.Attribute { }  
```  
  
 The first `AttributeUsage` argument must be one or more elements of the <xref:System.AttributeTargets> enumeration. Multiple target types can be linked together with the OR operator, like this:  
  
```csharp  
using System;  

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]  
class NewPropertyOrFieldAttribute : Attribute { }  
```  
  
 If the `AllowMultiple` argument is set to `true`, then the resulting attribute can be applied more than once to a single entity, like this:  
  
```csharp  
using System;  

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]  
class MultiUseAttr : Attribute { }  
  
[MultiUseAttr]  
[MultiUseAttr]  
class Class1 { }  
  
[MultiUseAttr, MultiUseAttr]  
class Class2 { }  
```  
  
 In this case `MultiUseAttr` can be applied repeatedly because `AllowMultiple` is set to `true`. Both formats shown for applying multiple attributes are valid.  
  
 If `Inherited` is set to `false`, then the attribute is not inherited by classes that are derived from a class that is attributed. For example:  
  
```csharp  
using System;  

[AttributeUsage(AttributeTargets.Class, Inherited = false)]  
class Attr1 : Attribute { }  
  
[Attr1]  
class BClass { }  
  
class DClass : BClass { }  
```  
  
 In this case `Attr1` is not applied to `DClass` via inheritance.  
  
## Remarks  
 The `AttributeUsage` attribute is a single-use attribute--it cannot be applied more than once to the same class. `AttributeUsage` is an alias for <xref:System.AttributeUsageAttribute>.  
  
 For more information, see [Accessing Attributes by Using Reflection (C#)](../../../../csharp/programming-guide/concepts/attributes/accessing-attributes-by-using-reflection.md).  
  
## Example  
 The following example demonstrates the effect of the `Inherited` and `AllowMultiple` arguments to the `AttributeUsage` attribute, and how the custom attributes applied to a class can be enumerated.  
  
```csharp  
using System;  

// Create some custom attributes:  
[AttributeUsage(System.AttributeTargets.Class, Inherited = false)]  
class A1 : System.Attribute { }  
  
[AttributeUsage(System.AttributeTargets.Class)]  
class A2 : System.Attribute { }  
  
[AttributeUsage(System.AttributeTargets.Class, AllowMultiple = true)]  
class A3 : System.Attribute { }  
  
// Apply custom attributes to classes:  
[A1, A2]  
class BaseClass { }  
  
[A3, A3]  
class DerivedClass : BaseClass { }  
  
public class TestAttributeUsage  
{  
    static void Main()  
    {  
        BaseClass b = new BaseClass();  
        DerivedClass d = new DerivedClass();  
  
        // Display custom attributes for each class.  
        Console.WriteLine("Attributes on Base Class:");  
        object[] attrs = b.GetType().GetCustomAttributes(true);  
        foreach (Attribute attr in attrs)  
        {  
            Console.WriteLine(attr);  
        }  
  
        Console.WriteLine("Attributes on Derived Class:");  
        attrs = d.GetType().GetCustomAttributes(true);  
        foreach (Attribute attr in attrs)  
        {  
            Console.WriteLine(attr);  
        }  
    }  
}  
```  
  
## Sample Output  
  
```  
Attributes on Base Class:  
A1  
A2  
Attributes on Derived Class:  
A3  
A3  
A2  
```  
  
## See Also  
 <xref:System.Attribute>  
 <xref:System.Reflection>  
 [C# Programming Guide](../../../../csharp/programming-guide/index.md)  
 [Attributes](../../../../../docs/standard/attributes/index.md)  
 [Reflection (C#)](../../../../csharp/programming-guide/concepts/reflection.md)  
 [Attributes](../../../../csharp/programming-guide/concepts/attributes/index.md)  
 [Creating Custom Attributes (C#)](../../../../csharp/programming-guide/concepts/attributes/creating-custom-attributes.md)  
 [Accessing Attributes by Using Reflection (C#)](../../../../csharp/programming-guide/concepts/attributes/accessing-attributes-by-using-reflection.md)
