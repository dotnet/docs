---
title: "Attributes (C#)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
ms.assetid: f148f13f-a0d5-4f22-9c87-4b73d5dde270
caps.latest.revision: 3
author: "BillWagner"
ms.author: "wiwagn"
---
# Attributes (C#)
Attributes provide a powerful method of associating metadata, or declarative information, with code (assemblies, types, methods, properties, and so forth). After an attribute is associated with a program entity, the attribute can be queried at run time by using a technique called *reflection*. For more information, see [Reflection (C#)](../../../../csharp/programming-guide/concepts/reflection.md).  
  
 Attributes have the following properties:  
  
-   Attributes add metadata to your program. *Metadata* is information about the types defined in a program. All .NET assemblies contain a specified set of metadata that describes the types and type members defined in the assembly. You can add custom attributes to specify any additional information that is required. For more information, see, [Creating Custom Attributes (C#)](../../../../csharp/programming-guide/concepts/attributes/creating-custom-attributes.md).  
  
-   You can apply one or more attributes to entire assemblies, modules, or smaller program elements such as classes and properties.  
  
-   Attributes can accept arguments in the same way as methods and properties.  
  
-   Your program can examine its own metadata or the metadata in other programs by using reflection. For more information, see [Accessing Attributes by Using Reflection (C#)](../../../../csharp/programming-guide/concepts/attributes/accessing-attributes-by-using-reflection.md).  
  
## Using Attributes  
 Attributes can be placed on most any declaration, though a specific attribute might restrict the types of declarations on which it is valid. In C#, you specify an attribute by placing the name of the attribute, enclosed in square brackets ([]), above the declaration of the entity to which it applies.  
  
 In this example, the <xref:System.SerializableAttribute> attribute is used to apply a specific characteristic to a class:  
  
```csharp  
[System.Serializable]  
public class SampleClass  
{  
    // Objects of this type can be serialized.  
}  
```  
  
 A method with the attribute <xref:System.Runtime.InteropServices.DllImportAttribute> is declared like this:  
  
```csharp  
using System.Runtime.InteropServices;  
```  
  
```csharp  
[System.Runtime.InteropServices.DllImport("user32.dll")]  
extern static void SampleMethod();  
```  
  
 More than one attribute can be placed on a declaration:  
  
```csharp  
using System.Runtime.InteropServices;  
```  
  
```csharp  
void MethodA([In][Out] ref double x) { }  
void MethodB([Out][In] ref double x) { }  
void MethodC([In, Out] ref double x) { }  
```  
  
 Some attributes can be specified more than once for a given entity. An example of such a multiuse attribute is <xref:System.Diagnostics.ConditionalAttribute>:  
  
```csharp  
[Conditional("DEBUG"), Conditional("TEST1")]  
void TraceMethod()  
{  
    // ...  
}  
```  
  
> [!NOTE]
>  By convention, all attribute names end with the word "Attribute" to distinguish them from other items in the .NET Framework. However, you do not need to specify the attribute suffix when using attributes in code. For example, `[DllImport]` is equivalent to `[DllImportAttribute]`, but `DllImportAttribute` is the attribute's actual name in the .NET Framework.  
  
### Attribute Parameters  
 Many attributes have parameters, which can be positional, unnamed, or named. Any positional parameters must be specified in a certain order and cannot be omitted; named parameters are optional and can be specified in any order. Positional parameters are specified first. For example, these three attributes are equivalent:  
  
```csharp  
[DllImport("user32.dll")]  
[DllImport("user32.dll", SetLastError=false, ExactSpelling=false)]  
[DllImport("user32.dll", ExactSpelling=false, SetLastError=false)]  
```  
  
 The first parameter, the DLL name, is positional and always comes first; the others are named. In this case, both named parameters default to false, so they can be omitted. Refer to the individual attribute's documentation for information on default parameter values.  
  
### Attribute Targets  
 The *target* of an attribute is the entity to which the attribute applies. For example, an attribute may apply to a class, a particular method, or an entire assembly. By default, an attribute applies to the element that it precedes. But you can also explicitly identify, for example, whether an attribute is applied to a method, or to its parameter, or to its return value.  
  
 To explicitly identify an attribute target, use the following syntax:  
  
```csharp  
[target : attribute-list]  
```  
  
 The list of possible `target` values is shown in the following table.  
  
|Target value|Applies to|  
|------------------|----------------|  
|`assembly`|Entire assembly|  
|`module`|Current assembly module|  
|`field`|Field in a class or a struct|  
|`event`|Event|  
|`method`|Method or `get` and `set` property accessors|  
|`param`|Method parameters or `set` property accessor parameters|  
|`property`|Property|  
|`return`|Return value of a method, property indexer, or `get` property accessor|  
|`type`|Struct, class, interface, enum, or delegate|  
  
 The following example shows how to apply attributes to assemblies and modules. For more information, see [Common Attributes (C#)](../../../../csharp/programming-guide/concepts/attributes/common-attributes.md).  
  
```csharp  
using System;  
using System.Reflection;  
[assembly: AssemblyTitleAttribute("Production assembly 4")]  
[module: CLSCompliant(true)]  
```  
  
 The following example shows how to apply attributes to methods, method parameters, and method return values in C#.  
  
```csharp  
// default: applies to method  
[SomeAttr]  
int Method1() { return 0; }  
  
// applies to method  
[method: SomeAttr]  
int Method2() { return 0; }  
  
// applies to return value  
[return: SomeAttr]  
int Method3() { return 0; }  
```  
  
> [!NOTE]
>  Regardless of the targets on which `SomeAttr` is defined to be valid, the `return` target has to be specified, even if `SomeAttr` were defined to apply only to return values. In other words, the compiler will not use `AttributeUsage` information to resolve ambiguous attribute targets. For more information, see [AttributeUsage (C#)](../../../../csharp/programming-guide/concepts/attributes/attributeusage.md).  
  
## Common Uses for Attributes  
 The following list includes a few of the common uses of attributes in code:  
  
-   Marking methods using the `WebMethod` attribute in Web services to indicate that the method should be callable over the SOAP protocol. For more information, see <xref:System.Web.Services.WebMethodAttribute>.  
  
-   Describing how to marshal method parameters when interoperating with native code. For more information, see <xref:System.Runtime.InteropServices.MarshalAsAttribute>.  
  
-   Describing the COM properties for classes, methods, and interfaces.  
  
-   Calling unmanaged code using the <xref:System.Runtime.InteropServices.DllImportAttribute> class.  
  
-   Describing your assembly in terms of title, version, description, or trademark.  
  
-   Describing which members of a class to serialize for persistence.  
  
-   Describing how to map between class members and XML nodes for XML serialization.  
  
-   Describing the security requirements for methods.  
  
-   Specifying characteristics used to enforce security.  
  
-   Controlling optimizations by the just-in-time (JIT) compiler so the code remains easy to debug.  
  
-   Obtaining information about the caller to a method.  
  
## Related Sections  
 For more information, see:  
  
-   [Creating Custom Attributes (C#)](../../../../csharp/programming-guide/concepts/attributes/creating-custom-attributes.md)  
  
-   [Accessing Attributes by Using Reflection (C#)](../../../../csharp/programming-guide/concepts/attributes/accessing-attributes-by-using-reflection.md)  
  
-   [How to: Create a C/C++ Union by Using Attributes (C#)](../../../../csharp/programming-guide/concepts/attributes/how-to-create-a-c-cpp-union-by-using-attributes.md)  
  
-   [Common Attributes (C#)](../../../../csharp/programming-guide/concepts/attributes/common-attributes.md)  
  
-   [Caller Information (C#)](../../../../csharp/programming-guide/concepts/caller-information.md)  
  
## See Also  
 [C# Programming Guide](../../../../csharp/programming-guide/index.md)  
 [Reflection (C#)](../../../../csharp/programming-guide/concepts/reflection.md)  
 [Attributes](../../../../../docs/standard/attributes/index.md)
