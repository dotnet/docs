---
title: "AttributeUsage (C#)"
ms.date: 04/25/2018
---
# AttributeUsage (C#)

Determines how a custom attribute class can be used. <xref:System.AttributeUsageAttribute> is an attribute you apply to custom attribute definitions. The `AttributeUsage` attribute enables you to control:

- Which program elements attribute may be applied to. Unless you restrict its usage, an attribute may be applied to any of the following program elements:
  - assembly
  - module
  - field
  - event
  - method
  - param
  - property
  - return
  - type
- Whether an attribute can be applied to a single program element multiple times.
- Whether attributes are inherited by derived classes.

The default settings look like the following example when applied explicitly:

[!code-csharp[Define a new attribute](../../../../../samples/snippets/csharp/attributes/NewAttribute.cs#1)]

In this example, the `NewAttribute` class can be applied to any supported program element. But it can be applied only once to each entity. The attribute is inherited by derived classes when applied to a base class.

The <xref:System.AttributeUsageAttribute.AllowMultiple> and <xref:System.AttributeUsageAttribute.Inherited> arguments are optional, so the following code has the same effect:

[!code-csharp[Omit optional attributes](../../../../../samples/snippets/csharp/attributes/NewAttribute.cs#2)]

The first <xref:System.AttributeUsageAttribute> argument must be one or more elements of the <xref:System.AttributeTargets> enumeration. Multiple target types can be linked together with the OR operator, like the following example shows:

[!code-csharp[Create an attribute for fields or properties](../../../../../samples/snippets/csharp/attributes/NewPropertyOrFieldAttribute.cs#1)]

Beginning in C# 7.3, attributes can be applied to either the property or the backing field for an auto-implemented property. The attribute applies to the property, unless you specify the `field` specifier on the attribute. Both are shown in the following example:

[!code-csharp[Create an attribute for fields or properties](../../../../../samples/snippets/csharp/attributes/NewPropertyOrFieldAttribute.cs#2)]

If the <xref:System.AttributeUsageAttribute.AllowMultiple> argument is `true`, then the resulting attribute can be applied more than once to a single entity, as shown in the following example:

[!code-csharp[Create and use an attribute that can be applied multiple times](../../../../../samples/snippets/csharp/attributes/MultiUseAttribute.cs#1)]

In this case, `MultiUseAttribute` can be applied repeatedly because `AllowMultiple` is set to `true`. Both formats shown for applying multiple attributes are valid.

If <xref:System.AttributeUsageAttribute.Inherited> is `false`, then the attribute isn't inherited by classes derived from an attributed class. For example:

[!code-csharp[Create and use an attribute that can be applied multiple times](../../../../../samples/snippets/csharp/attributes/NonInheritedAttribute.cs#1)]

In this case `NonInheritedAttribute` isn't applied to `DClass` via inheritance.

## Remarks

The `AttributeUsage` attribute is a single-use attribute--it can't be applied more than once to the same class. `AttributeUsage` is an alias for <xref:System.AttributeUsageAttribute>.

For more information, see [Accessing Attributes by Using Reflection (C#)](accessing-attributes-by-using-reflection.md).

## Example

The following example demonstrates the effect of the <xref:System.AttributeUsageAttribute.Inherited> and <xref:System.AttributeUsageAttribute.AllowMultiple> arguments to the <xref:System.AttributeUsageAttribute> attribute, and how the custom attributes applied to a class can be enumerated.

[!code-csharp[Applying and querying attributes](../../../../../samples/snippets/csharp/attributes/Program.cs#1)]

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

## See also

- <xref:System.Attribute>  
- <xref:System.Reflection>  
- [C# Programming Guide](../..//index.md)  
- [Attributes](../../../..//standard/attributes/index.md)  
- [Reflection (C#)](../reflection.md)  
- [Attributes](index.md)  
- [Creating Custom Attributes (C#)](creating-custom-attributes.md)  
- [Accessing Attributes by Using Reflection (C#)](accessing-attributes-by-using-reflection.md)
