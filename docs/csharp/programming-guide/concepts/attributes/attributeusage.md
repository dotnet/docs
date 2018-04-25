---
title: "AttributeUsage (C#)"
ms.date: 04/25/2018
---
# AttributeUsage (C#)

Determines how a custom attribute class can be used. `AttributeUsage` is an attribute that can be applied to custom attribute definitions to control how the new attribute can be applied. The default settings look like this when applied explicitly:

[!code-csharp[Define a new attribute](../../../../../samples/snippets/csharp/properties/NewAttribute.cs#1)]

In this example, the `NewAttribute` class can be applied to any attribute-able code entity, but can be applied only once to each entity. It is inherited by derived classes when applied to a base class.

The `AllowMultiple` and `Inherited` arguments are optional, so this code has the same effect:

[!code-csharp[Omit optional attributes](../../../../../samples/snippets/csharp/properties/NewAttribute.cs#2)]

The first `AttributeUsage` argument must be one or more elements of the <xref:System.AttributeTargets> enumeration. Multiple target types can be linked together with the OR operator, like this:

[!code-csharp[Create an attribute for fields or properties](../../../../../samples/snippets/csharp/properties/NewPropertyOrFieldAttribute.cs#1)]

If the `AllowMultiple` argument is set to `true`, then the resulting attribute can be applied more than once to a single entity, like this:

[!code-csharp[Create and use an attribute that can be applied multiple times](../../../../../samples/snippets/csharp/properties/MultiUseAttribute.cs#1)]

In this case `MultiUseAttribute` can be applied repeatedly because `AllowMultiple` is set to `true`. Both formats shown for applying multiple attributes are valid.

If `Inherited` is set to `false`, then the attribute is not inherited by classes that are derived from a class that is attributed. For example:

[!code-csharp[Create and use an attribute that can be applied multiple times](../../../../../samples/snippets/csharp/properties/NonInheritedAttribute.cs#1)]

In this case `NonInheritedAttribute` is not applied to `DClass` via inheritance.

## Remarks

The `AttributeUsage` attribute is a single-use attribute--it cannot be applied more than once to the same class. `AttributeUsage` is an alias for <xref:System.AttributeUsageAttribute>.

For more information, see [Accessing Attributes by Using Reflection (C#)](accessing-attributes-by-using-reflection.md).

## Example

The following example demonstrates the effect of the `Inherited` and `AllowMultiple` arguments to the `AttributeUsage` attribute, and how the custom attributes applied to a class can be enumerated.

[!code-csharp[applying and querying attributes](../../../../../samples/snippets/csharp/properties/Program.cs#1)]

## Sample Output

```text
Attributes on Base Class:
FirstAttribute
SecondAttribute
Attributes on Derived Class:
ThirdAttribute
ThirdAttribute
SecondAttribute
```

## See Also
 <xref:System.Attribute>  
 <xref:System.Reflection>  
 [C# Programming Guide](../..//index.md)  
 [Attributes](../../../..//standard/attributes/index.md)  
 [Reflection (C#)](../reflection.md)  
 [Attributes](index.md)  
 [Creating Custom Attributes (C#)](creating-custom-attributes.md)  
 [Accessing Attributes by Using Reflection (C#)](accessing-attributes-by-using-reflection.md)
