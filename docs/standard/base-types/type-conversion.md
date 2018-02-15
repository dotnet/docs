---
title: "Type Conversion in the .NET Framework"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "widening conversions"
  - "explicit conversions"
  - "narrowing conversions"
  - "type conversion, about type conversion"
  - "type conversion"
  - "converting types"
  - "narrowing coercion"
  - "Explicit operator"
  - "IConvertible interface"
  - "base types, converting"
  - "op_Implicit method"
  - "widening coercion"
  - "op_Explicit method"
  - "Convert class"
  - "implicit conversions"
  - "Implicit operator"
  - "data types [.NET Framework], converting"
ms.assetid: ba36154f-064c-47d3-9f05-72f93a7ca96d
caps.latest.revision: 22
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Type Conversion in the .NET Framework
<a name="top"></a> Every value has an associated type, which defines attributes such as the amount of space allocated to the value, the range of possible values it can have, and the members that it makes available. Many values can be expressed as more than one type. For example, the value 4 can be expressed as an integer or a floating-point value. Type conversion creates a value in a new type that is equivalent to the value of an old type, but does not necessarily preserve the identity (or exact value) of the original object.  
  
 The .NET Framework automatically supports the following conversions:  
  
-   Conversion from a derived class to a base class. This means, for example, that an instance of any class or structure can be converted to an <xref:System.Object> instance.  This conversion does not require a casting or conversion operator.  
  
-   Conversion from a base class back to the original derived class. In C#, this conversion requires a casting operator. In Visual Basic, it requires the `CType` operator if `Option Strict` is on.  
  
-   Conversion from a type that implements an interface to an interface object that represents that interface. This conversion does not require a casting or conversion operator.  
  
-   Conversion from an interface object back to the original type that implements that interface.  In C#, this conversion requires a casting operator. In Visual Basic, it requires the `CType` operator if `Option Strict` is on.  
  
 In addition to these automatic conversions, the [!INCLUDE[dnprdnshort](../../../includes/dnprdnshort-md.md)] provides several features that support custom type conversion. These include the following:  
  
-   The `Implicit` operator, which defines the available widening conversions between types. For more information, see the [Implicit Conversion with the Implicit Operator](#implicit_conversion_with_the_implicit_operator) section.  
  
-   The `Explicit` operator, which defines the available narrowing conversions between types. For more information, see the [Explicit Conversion with the Explicit Operator](#explicit_conversion_with_the_explicit_operator) section.  
  
-   The <xref:System.IConvertible> interface, which defines conversions to each of the base .NET Framework data types. For more information, see [The IConvertible Interface](#the_iconvertible_interface) section.  
  
-   The <xref:System.Convert> class, which provides a set of methods that implement the methods in the <xref:System.IConvertible> interface. For more information, see [The Convert Class](#Convert) section.  
  
-   The <xref:System.ComponentModel.TypeConverter> class, which is a base class that can be extended to support the conversion of a specified type to any other type. For more information, see [The TypeConverter Class](#the_typeconverter_class) section.  
  
<a name="implicit_conversion_with_the_implicit_operator"></a>   
## Implicit Conversion with the Implicit Operator  
 Widening conversions involve the creation of a new value from the value of an existing type that has either a more restrictive range or a more restricted member list than the target type. Widening conversions cannot result in data loss (although they may result in a loss of precision). Because data cannot be lost, compilers can handle the conversion implicitly or transparently, without requiring the use of an explicit conversion method or a casting operator.  
  
> [!NOTE]
>  Although code that performs an implicit conversion can call a conversion method or use a casting operator, their use is not required by compilers that support implicit conversions.  
  
 For example, the <xref:System.Decimal> type supports implicit conversions from <xref:System.Byte>, <xref:System.Char>, <xref:System.Int16>, <xref:System.Int32>, <xref:System.Int64>, <xref:System.SByte>, <xref:System.UInt16>, <xref:System.UInt32>, and <xref:System.UInt64> values. The following example illustrates some of these implicit conversions in assigning values to a <xref:System.Decimal> variable.  
  
 [!code-csharp[Conceptual.Conversion#1](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.conversion/cs/implicit1.cs#1)]
 [!code-vb[Conceptual.Conversion#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.conversion/vb/implicit1.vb#1)]  
  
 If a particular language compiler supports custom operators, you can also define implicit conversions in your own custom types. The following example provides a partial implementation of a signed byte data type named `ByteWithSign` that uses sign-and-magnitude representation. It supports implicit conversion of <xref:System.Byte> and <xref:System.SByte> values to `ByteWithSign` values.  
  
 [!code-csharp[Conceptual.Conversion#2](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.conversion/cs/implicit1.cs#2)]
 [!code-vb[Conceptual.Conversion#2](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.conversion/vb/implicit1.vb#2)]  
  
 Client code can then declare a `ByteWithSign` variable and assign it <xref:System.Byte> and <xref:System.SByte> values without performing any explicit conversions or using any casting operators, as the following example shows.  
  
 [!code-csharp[Conceptual.Conversion#3](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.conversion/cs/implicit1.cs#3)]
 [!code-vb[Conceptual.Conversion#3](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.conversion/vb/implicit1.vb#3)]  
  
 [Back to top](#top)  
  
<a name="explicit_conversion_with_the_explicit_operator"></a>   
## Explicit Conversion with the Explicit Operator  
 Narrowing conversions involve the creation of a new value from the value of an existing type that has either a greater range or a larger member list than the target type. Because a narrowing conversion can result in a loss of data, compilers often require that the conversion be made explicit through a call to a conversion method or a casting operator. That is, the conversion must be handled explicitly in developer code.  
  
> [!NOTE]
>  The major purpose of requiring a conversion method or casting operator for narrowing conversions is to make the developer aware of the possibility of data loss or an <xref:System.OverflowException> so that it can be handled in code. However, some compilers can relax this requirement. For example, in Visual Basic, if `Option Strict` is off (its default setting), the Visual Basic compiler tries to perform narrowing conversions implicitly.  
  
 For example, the <xref:System.UInt32>, <xref:System.Int64>, and <xref:System.UInt64> data types have ranges that exceed that the <xref:System.Int32> data type, as the following table shows.  
  
|Type|Comparison with range of Int32|  
|----------|------------------------------------|  
|<xref:System.Int64>|<xref:System.Int64.MaxValue?displayProperty=nameWithType> is greater than <xref:System.Int32.MaxValue?displayProperty=nameWithType>, and <xref:System.Int64.MinValue?displayProperty=nameWithType> is less than (has a greater negative range than) <xref:System.Int32.MinValue?displayProperty=nameWithType>.|  
|<xref:System.UInt32>|<xref:System.UInt32.MaxValue?displayProperty=nameWithType> is greater than <xref:System.Int32.MaxValue?displayProperty=nameWithType>.|  
|<xref:System.UInt64>|<xref:System.UInt64.MaxValue?displayProperty=nameWithType> is greater than <xref:System.Int32.MaxValue?displayProperty=nameWithType>.|  
  
 To handle such narrowing conversions, the [!INCLUDE[dnprdnshort](../../../includes/dnprdnshort-md.md)] allows types to define an `Explicit` operator. Individual language compilers can then implement this operator using their own syntax, or a member of the <xref:System.Convert> class can be called to perform the conversion. (For more information about the <xref:System.Convert> class, see [The Convert Class](#Convert) later in this topic.) The following example illustrates the use of language features to handle the explicit conversion of these potentially out-of-range integer values to <xref:System.Int32> values.  
  
 [!code-csharp[Conceptual.Conversion#4](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.conversion/cs/explicit1.cs#4)]
 [!code-vb[Conceptual.Conversion#4](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.conversion/vb/explicit1.vb#4)]  
  
 Explicit conversions can produce different results in different languages, and these results can differ from the value returned by the corresponding <xref:System.Convert> method. For example, if the <xref:System.Double> value 12.63251 is converted to an <xref:System.Int32>, both the Visual Basic `CInt` method and the .NET Framework <xref:System.Convert.ToInt32%28System.Double%29?displayProperty=nameWithType> method round the <xref:System.Double> to return a value of 13, but the C# `(int)` operator truncates the <xref:System.Double> to return a value of 12. Similarly, the C# `(int)` operator does not support Boolean-to-integer conversion, but the Visual Basic `CInt` method converts a value of `true` to -1. On the other hand, the <xref:System.Convert.ToInt32%28System.Boolean%29?displayProperty=nameWithType> method converts a value of `true` to 1.  
  
 Most compilers allow explicit conversions to be performed in a checked or unchecked manner. When a checked conversion is performed, an <xref:System.OverflowException> is thrown when the value of the type to be converted is outside the range of the target type. When an unchecked conversion is performed under the same conditions, the conversion might not throw an exception, but the exact behavior becomes undefined and an incorrect value might result.  
  
> [!NOTE]
>  In C#, checked conversions can be performed by using the `checked` keyword together with a casting operator, or by specifying the `/checked+` compiler option. Conversely, unchecked conversions can be performed by using the `unchecked` keyword together with the casting operator, or by specifying the `/checked-` compiler option. By default, explicit conversions are unchecked. In Visual Basic, checked conversions can be performed by clearing the **Remove integer overflow checks** check box in the project's **Advanced Compiler Settings** dialog box, or by specifying the `/removeintchecks-` compiler option. Conversely, unchecked conversions can be performed by selecting the **Remove integer overflow checks** check box in the project's **Advanced Compiler Settings** dialog box or by specifying the `/removeintchecks+` compiler option. By default, explicit conversions are checked.  
  
 The following C# example uses the `checked` and `unchecked` keywords to illustrate the difference in behavior when a value outside the range of a <xref:System.Byte> is converted to a <xref:System.Byte>. The checked conversion throws an exception, but the unchecked conversion assigns <xref:System.Byte.MaxValue?displayProperty=nameWithType> to the <xref:System.Byte> variable.  
  
 [!code-csharp[Conceptual.Conversion#12](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.conversion/cs/explicit1.cs#12)]  
  
 If a particular language compiler supports custom overloaded operators, you can also define explicit conversions in your own custom types. The following example provides a partial implementation of a signed byte data type named `ByteWithSign` that uses sign-and-magnitude representation. It supports explicit conversion of <xref:System.Int32> and <xref:System.UInt32> values to `ByteWithSign` values.  
  
 [!code-csharp[Conceptual.Conversion#5](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.conversion/cs/explicit1.cs#5)]
 [!code-vb[Conceptual.Conversion#5](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.conversion/vb/explicit1.vb#5)]  
  
 Client code can then declare a `ByteWithSign` variable and assign it <xref:System.Int32> and <xref:System.UInt32> values if the assignments include a casting operator or a conversion method, as the following example shows.  
  
 [!code-csharp[Conceptual.Conversion#6](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.conversion/cs/explicit1.cs#6)]
 [!code-vb[Conceptual.Conversion#6](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.conversion/vb/explicit1.vb#6)]  
  
 [Back to top](#top)  
  
<a name="the_iconvertible_interface"></a>   
## The IConvertible Interface  
 To support the conversion of any type to a common language runtime base type, the [!INCLUDE[dnprdnshort](../../../includes/dnprdnshort-md.md)] provides the <xref:System.IConvertible> interface. The implementing type is required to provide the following:  
  
-   A method that returns the <xref:System.TypeCode> of the implementing type.  
  
-   Methods to convert the implementing type to each common language runtime base type (<xref:System.Boolean>, <xref:System.Byte>, <xref:System.DateTime>, <xref:System.Decimal>, <xref:System.Double>, and so on).  
  
-   A generalized conversion method to convert an instance of the implementing type to another specified type. Conversions that are not supported should throw an <xref:System.InvalidCastException>.  
  
 Each common language runtime base type (that is, the <xref:System.Boolean>, <xref:System.Byte>, <xref:System.Char>, <xref:System.DateTime>, <xref:System.Decimal>, <xref:System.Double>, <xref:System.Int16>, <xref:System.Int32>, <xref:System.Int64>, <xref:System.SByte>, <xref:System.Single>, <xref:System.String>, <xref:System.UInt16>, <xref:System.UInt32>, and <xref:System.UInt64>), as well as the <xref:System.DBNull> and <xref:System.Enum> types, implement the <xref:System.IConvertible> interface. However, these are explicit interface implementations; the conversion method can be called only through an <xref:System.IConvertible> interface variable, as the following example shows. This example converts an <xref:System.Int32> value to its equivalent <xref:System.Char> value.  
  
 [!code-csharp[Conceptual.Conversion#7](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.conversion/cs/iconvertible1.cs#7)]
 [!code-vb[Conceptual.Conversion#7](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.conversion/vb/iconvertible1.vb#7)]  
  
 The requirement to call the conversion method on its interface rather than on the implementing type makes explicit interface implementations relatively expensive. Instead, we recommend that you call the appropriate member of the <xref:System.Convert> class to convert between common language runtime base types. For more information, see the next section, [The Convert Class](#Convert).  
  
> [!NOTE]
>  In addition to the <xref:System.IConvertible> interface and the <xref:System.Convert> class provided by the [!INCLUDE[dnprdnshort](../../../includes/dnprdnshort-md.md)], individual languages may also provide ways to perform conversions. For example, C# uses casting operators; Visual Basic uses compiler-implemented conversion functions such as `CType`, `CInt`, and `DirectCast`.  
  
 For the most part, the <xref:System.IConvertible> interface is designed to support conversion between the base types in the [!INCLUDE[dnprdnshort](../../../includes/dnprdnshort-md.md)]. However, the interface can also be implemented by a custom type to support conversion of that type to other custom types. For more information, see the section [Custom Conversions with the ChangeType Method](#ChangeType) later in this topic.  
  
 [Back to top](#top)  
  
<a name="Convert"></a>   
## The Convert Class  
 Although each base type's <xref:System.IConvertible> interface implementation can be called to perform a type conversion, calling the methods of the <xref:System.Convert?displayProperty=nameWithType> class is the recommended language-neutral way to convert from one base type to another. In addition, the <xref:System.Convert.ChangeType%28System.Object%2CSystem.Type%2CSystem.IFormatProvider%29?displayProperty=nameWithType> method can be used to convert from a specified custom type to another type.  
  
### Conversions Between Base Types  
 The <xref:System.Convert> class provides a language-neutral way to perform conversions between base types and is available to all languages that target the common language runtime. It provides a complete set of methods for both widening and narrowing conversions, and throws an <xref:System.InvalidCastException> for conversions that are not supported (such as the conversion of a <xref:System.DateTime> value to an integer value). Narrowing conversions are performed in a checked context, and an <xref:System.OverflowException> is thrown if the conversion fails.  
  
> [!IMPORTANT]
>  Because the <xref:System.Convert> class includes methods to convert to and from each base type, it eliminates the need to call each base type's <xref:System.IConvertible> explicit interface implementation.  
  
 The following example illustrates the use of the <xref:System.Convert?displayProperty=nameWithType> class to perform several widening and narrowing conversions between .NET Framework base types.  
  
 [!code-csharp[Conceptual.Conversion#8](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.conversion/cs/convert1.cs#8)]
 [!code-vb[Conceptual.Conversion#8](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.conversion/vb/convert1.vb#8)]  
  
 In some cases, particularly when converting to and from floating-point values, a conversion may involve a loss of precision, even though it does not throw an <xref:System.OverflowException>. The following example illustrates this loss of precision. In the first case, a <xref:System.Decimal> value has less precision (fewer significant digits) when it is converted to a <xref:System.Double>. In the second case, a <xref:System.Double> value is rounded from 42.72 to 43 in order to complete the conversion.  
  
 [!code-csharp[Conceptual.Conversion#9](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.conversion/cs/convert1.cs#9)]
 [!code-vb[Conceptual.Conversion#9](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.conversion/vb/convert1.vb#9)]  
  
 For a table that lists both the widening and narrowing conversions supported by the <xref:System.Convert> class, see [Type Conversion Tables](../../../docs/standard/base-types/conversion-tables.md).  
  
<a name="ChangeType"></a>   
### Custom Conversions with the ChangeType Method  
 In addition to supporting conversions to each of the base types, the <xref:System.Convert> class can be used to convert a custom type to one or more predefined types. This conversion is performed by the <xref:System.Convert.ChangeType%28System.Object%2CSystem.Type%2CSystem.IFormatProvider%29?displayProperty=nameWithType> method, which in turn wraps a call to the <xref:System.IConvertible.ToType%2A?displayProperty=nameWithType> method of the `value` parameter. This means that the object represented by the `value` parameter must provide an implementation of the <xref:System.IConvertible> interface.  
  
> [!NOTE]
>  Because the <xref:System.Convert.ChangeType%28System.Object%2CSystem.Type%29?displayProperty=nameWithType> and <xref:System.Convert.ChangeType%28System.Object%2CSystem.Type%2CSystem.IFormatProvider%29?displayProperty=nameWithType> methods use a <xref:System.Type> object to specify the target type to which `value` is converted, they can be used to perform a dynamic conversion to an object whose type is not known at compile time. However, note that the <xref:System.IConvertible> implementation of `value` must still support this conversion.  
  
 The following example illustrates a possible implementation of the <xref:System.IConvertible> interface that allows a `TemperatureCelsius` object to be converted to a `TemperatureFahrenheit` object and vice versa. The example defines a base class, `Temperature`, that implements the <xref:System.IConvertible> interface and overrides the <xref:System.Object.ToString%2A?displayProperty=nameWithType> method. The derived `TemperatureCelsius` and `TemperatureFahrenheit` classes each override the `ToType` and the `ToString` methods of the base class.  
  
 [!code-csharp[Conceptual.Conversion#10](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.conversion/cs/iconvertible2.cs#10)]
 [!code-vb[Conceptual.Conversion#10](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.conversion/vb/iconvertible2.vb#10)]  
  
 The following example illustrates several calls to these <xref:System.IConvertible> implementations to convert `TemperatureCelsius` objects to `TemperatureFahrenheit` objects and vice versa.  
  
 [!code-csharp[Conceptual.Conversion#11](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.conversion/cs/iconvertible2.cs#11)]
 [!code-vb[Conceptual.Conversion#11](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.conversion/vb/iconvertible2.vb#11)]  
  
 [Back to top](#top)  
  
<a name="the_typeconverter_class"></a>   
## The TypeConverter Class  
 The .NET Framework also allows you to define a type converter for a custom type by extending the <xref:System.ComponentModel.TypeConverter?displayProperty=nameWithType> class and associating the type converter with the type through a <xref:System.ComponentModel.TypeConverterAttribute?displayProperty=nameWithType> attribute. The following table highlights the differences between this approach and implementing the <xref:System.IConvertible> interface for a custom type.  
  
> [!NOTE]
>  Design-time support can be provided for a custom type only if it has a type converter defined for it.  
  
|Conversion using TypeConverter|Conversion using IConvertible|  
|------------------------------------|-----------------------------------|  
|Is implemented for a custom type by deriving a separate class from <xref:System.ComponentModel.TypeConverter>. This derived class is associated with the custom type by applying a <xref:System.ComponentModel.TypeConverterAttribute> attribute.|Is implemented by a custom type to perform conversion. A user of the type invokes an <xref:System.IConvertible> conversion method on the type.|  
|Can be used both at design time and at run time.|Can be used only at run time.|  
|Uses reflection; therefore, is slower than conversion enabled by <xref:System.IConvertible>.|Does not use reflection.|  
|Allows two-way type conversions from the custom type to other data types, and from other data types to the custom type. For example, a <xref:System.ComponentModel.TypeConverter> defined for `MyType` allows conversions from `MyType` to <xref:System.String>, and from <xref:System.String> to `MyType`.|Allows conversion from a custom type to other data types, but not from other data types to the custom type.|  
  
 For more information about using type converters to perform conversions, see <xref:System.ComponentModel.TypeConverter?displayProperty=nameWithType>.  
  
## See Also  
 <xref:System.Convert?displayProperty=nameWithType>  
 <xref:System.IConvertible>  
 [Type Conversion Tables](../../../docs/standard/base-types/conversion-tables.md)
