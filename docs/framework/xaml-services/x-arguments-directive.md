---
title: "x:Arguments Directive"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-wpf"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "x:Arguments directive [XAML Services]"
  - "Arguments directive in XAML [XAML Services]"
  - "XAML [XAML Services], x:Arguments directive"
ms.assetid: 87cc10b0-b610-4025-b6b0-ab27ca27c92e
caps.latest.revision: 12
author: "wadepickett"
ms.author: "wpickett"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# x:Arguments Directive
Packages construction arguments for a non-default constructor object element declaration in XAML, or for a factory method object declaration.  
  
## XAML Element Usage (Nondefault constructor)  
  
```  
<object ...>  
  <x:Arguments>  
    oneOrMoreObjectElements  
  </x:Arguments>  
</object>  
```  
  
## XAML Element Usage (factory method)  
  
```  
<object x:FactoryMethod="methodName"...>  
  <x:Arguments>  
    oneOrMoreObjectElements  
  </x:Arguments>  
</object>  
```  
  
## XAML Values  
  
|||  
|-|-|  
|`oneOrMoreObjectElements`|One or more object elements that specify arguments to be passed to the backing non-default constructor or factory method.<br /><br /> Typical usage is to use initialization text within the object elements to specify the actual argument values. See Examples section.<br /><br /> The order of the elements is significant. The XAML types in order must match the types and type order of the backing constructor or factory method overload.|  
|`methodName`|The name of the factory method that should process any `x:Arguments` arguments.|  
  
## Dependencies  
 `x:FactoryMethod` can modify the scope and behavior where `x:Arguments` applies.  
  
 If no `x:FactoryMethod` is specified, `x:Arguments` applies to alternate (non-default) signatures of the backing constructors.  
  
 If `x:FactoryMethod` is specified, `x:Arguments` applies to an overload of the named method.  
  
## Remarks  
 XAML 2006 can support non-default initialization through initialization text. However, the practical application of an initialization text construction technique is limited. Initialization text is treated as a single text string; therefore, it only adds capability for a single parameter initialization unless a type converter is defined for the construction behavior that can parse custom information items and custom delimiters from the string. Also, the text string to object logic is potentially a given XAML parser's native default type converter for handling primitives other than a true string.  
  
 The `x:Arguments` XAML usage is not property element usage in the typical sense, because the directive markup does not reference the containing object element's type. It is more akin to other directives such as `x:Code` where the element demarks a range in which the markup should be interpreted as other than the default for child contents. In this case, the XAML type of each object element communicates information about the argument types, which is used by XAML parsers to determine which specific constructor factory method signature an `x:Arguments` usage is attempting to reference.  
  
 `x:Arguments` for an object element being constructed must precede any other property elements, content, inner text, or initialization strings of the object element. The object elements within `x:Arguments` can include attributes and initialization strings, as permitted by that XAML type and its backing constructor or factory method. For either the object or the arguments, you can specify custom XAML types or XAML types that are otherwise outside the default XAML namespace by referencing established prefix mappings.  
  
 XAML processors use the following guidelines to determine how the arguments specified in `x:Arguments` should be used to construct an object. If `x:FactoryMethod` is specified, information is compared to the specified `x:FactoryMethod` (note that the value of `x:FactoryMethod` is the method name, and the named method can have overloads. If `x:FactoryMethod` is not specified, information is compared to the set of all public constructor overloads of the object. XAML processing logic then compares the number of parameters and selects the overload with matching arity. If there is more than one match, the XAML processor should compare the types of the parameters based on the XAML types of the provided object elements. If there is still more than one match, the XAML processor behavior is undefined. If a `x:FactoryMethod` is specified but the method cannot be resolved, a XAML processor should throw an exception.  
  
 A XAML attribute usage `<x:Arguments>string</x:Arguments>` is technically possible. However, this provides no capabilities beyond what could be done otherwise through initialization text and type converters, and using this syntax is not the design intention of the XAML 2009 factory method features.  
  
## Examples  
 The following example shows a non-default constructor signature, then the XAML usage of `x:Arguments` that accesses that signature.  
  
```csharp  
public class Food {  
    private string _name;  
    private Int32 _calories;  
    public Food(string name, Int32 calories) {  
        _name=name;  
        _calories=calories;  
    }  
}  
```  
  
```xaml  
<my:Food>  
    <x:Arguments>  
        <x:String>Apple</x:String>  
        <x:Int32>150</x:Int32>  
    </x:Arguments>  
</my:Food>  
```  
  
 The following example shows a target factory method signature, then the XAML usage of `x:Arguments` that accesses that signature.  
  
```csharp  
public Food TryLookupFood(string name)  
{  
  switch (name) {  
    case "Apple": return new Food("Apple",150);  
    case "Chocolate": return new Food("Chocolate",200);  
    case "Cheese": return new Food("Cheese", 450);  
    default: {return new Food(name,0);  
  }  
}  
```  
  
```xaml  
<my:Food x:FactoryMethod="TryLookupFood">  
    <x:Arguments>  
        <x:String>Apple</x:String>  
    </x:Arguments>  
</my:Food>  
```  
  
## See Also  
 [Defining Custom Types for Use with .NET Framework XAML Services](../../../docs/framework/xaml-services/defining-custom-types-for-use-with-net-framework-xaml-services.md)  
 [XAML Overview (WPF)](../../../docs/framework/wpf/advanced/xaml-overview-wpf.md)
