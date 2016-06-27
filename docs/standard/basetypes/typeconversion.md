
---
title: Type Conversion
description: Type Conversion
keywords: .NET, .NET Core
author: shoag
manager: wpickett
ms.date: 06/20/2016
ms.topic: article
ms.prod: .net-core
ms.technology: .net-core-technologies
ms.devlang: dotnet
ms.assetid: e113269f-b753-4dc3-a4d1-dea161e994df
---

# Type Conversion

Every value has an associated type, which defines attributes such as the amount of space allocated to the value, the range of possible values it can have, and the members that it makes available. Many values can be expressed as more than one type. For example, the value `4` can be expressed as an integer or a floating-point value. Type conversion creates a value in a new type that is equivalent to the value of an old type, but does not necessarily preserve the identity (or exact value) of the original object.

.NET Core automatically supports the following conversions:

* Conversion from a derived class to a base class. This means, for example, that an instance of any class or structure can be converted to an [Object](https://docs.microsoft.com/dotnet/core/api/System.Object) instance. This conversion does not require a casting operator.

* Conversion from a base class back to the original derived class. In C#, this conversion requires a casting operator.

* Conversion from a type that implements an interface to an interface object that represents that interface. This conversion does not require a casting operator.

* Conversion from an interface object back to the original type that implements that interface. In C#, this conversion requires a casting operator.

In addition to these automatic conversions, .NET Core provides several features that support custom type conversion. These include the following: 

* The `Implicit` operator, which defines the available widening conversions between types. For more information, see the [Implicit Conversion with the Implicit Operator](#Implicit-Conversion-with-the-Implicit-Operator) section.

* The `Explicit` operator, which defines the available narrowing conversions between types. For more information, see the [Explicit Conversion with the Explicit Operator](#Explicit-Conversion-with-the-Explicit-Operator) section.

* The [IConvertible](https://docs.microsoft.com/dotnet/core/api/System.IConvertible) interface, which defines conversions to each of the base .NET Core data types. For more information, see the [The IConvertible Interface](#The-IConvertible-Interface) section.

* The [Convert](https://docs.microsoft.com/dotnet/core/api/System.Convert) class, which provides a set of methods that implement the methods in the `IConvertible` interface. For more information, see the [The Convert Class](#The-Convert-Class) section.

* The [TypeConverter](https://docs.microsoft.com/dotnet/core/api/System.ComponentModel.TypeConverter) class, which is a base class that can be extended to support the conversion of a specified type to any other type. For more information, see the [The TypeConverter Class](#The-TypeConverter-Class) section.

## Implicit Conversion with the Implicit Operator

Widening conversions involve the creation of a new value from the value of an existing type that has either a more restrictive range or a more restricted member list than the target type. Widening conversions cannot result in data loss (although they may result in a loss of precision). Because data cannot be lost, compilers can handle the conversion implicitly or transparently, without requiring the use of an explicit conversion method or a casting operator.

> **Note**
>
> Although code that performs an implicit conversion can call a conversion method or use a casting operator, their use is not required by compilers that support implicit conversions.

For example, the [Decimal](https://docs.microsoft.com/dotnet/core/api/System.Decimal) type supports implicit conversions from [Byte](https://docs.microsoft.com/dotnet/core/api/System.Byte), [Char](https://docs.microsoft.com/dotnet/core/api/System.Char), [Int16](https://docs.microsoft.com/dotnet/core/api/System.Int16), [Int32](https://docs.microsoft.com/dotnet/core/api/System.Int32), [Int64](https://docs.microsoft.com/dotnet/core/api/System.Int64), [SByte](https://docs.microsoft.com/dotnet/core/api/System.SByte), [UInt16](https://docs.microsoft.com/dotnet/core/api/System.UInt16), [UInt32](https://docs.microsoft.com/dotnet/core/api/System.UInt362), and [UInt64](https://docs.microsoft.com/dotnet/core/api/System.UInt64) values. The following example illustrates some of these implicit conversions in assigning values to a `Decimal` variable.

```csharp
byte byteValue = 16;
short shortValue = -1024;
int intValue = -1034000;
long longValue = 1152921504606846976;
ulong ulongValue = UInt64.MaxValue;

decimal decimalValue;

decimalValue = byteValue;
Console.WriteLine("After assigning a {0} value, the Decimal value is {1}.", 
                  byteValue.GetType().Name, decimalValue); 

decimalValue = shortValue;
Console.WriteLine("After assigning a {0} value, the Decimal value is {1}.", 
                  shortValue.GetType().Name, decimalValue); 

decimalValue = intValue;
Console.WriteLine("After assigning a {0} value, the Decimal value is {1}.", 
                  intValue.GetType().Name, decimalValue); 

decimalValue = longValue;
Console.WriteLine("After assigning a {0} value, the Decimal value is {1}.", 
                  longValue.GetType().Name, decimalValue); 

decimalValue = ulongValue;
Console.WriteLine("After assigning a {0} value, the Decimal value is {1}.", 
                  longValue.GetType().Name, decimalValue); 
// The example displays the following output:
//    After assigning a Byte value, the Decimal value is 16.
//    After assigning a Int16 value, the Decimal value is -1024.
//    After assigning a Int32 value, the Decimal value is -1034000.
//    After assigning a Int64 value, the Decimal value is 1152921504606846976.
//    After assigning a Int64 value, the Decimal value is 18446744073709551615.
```

If a particular language compiler supports custom operators, you can also define implicit conversions in your own custom types. The following example provides a partial implementation of a signed byte data type named `ByteWithSign` that uses sign-and-magnitude representation. It supports implicit conversion of [Byte](https://docs.microsoft.com/dotnet/core/api/System.Byte) and [SByte](https://docs.microsoft.com/dotnet/core/api/System.SByte) values to `ByteWithSign` values.

```csharp
public struct ByteWithSign
{
   private SByte signValue; 
   private Byte value;

   public static implicit operator ByteWithSign(SByte value) 
   {
      ByteWithSign newValue;
      newValue.signValue = (SByte) Math.Sign(value);
      newValue.value = (byte) Math.Abs(value);
      return newValue;
   }  

   public static implicit operator ByteWithSign(Byte value)
   {
      ByteWithSign  newValue;
      newValue.signValue = 1;
      newValue.value = value;
      return newValue;
   }

   public override string ToString()
   { 
      return (signValue * value).ToString();
   }
}
```

Client code can then declare a `ByteWithSign` variable and assign it [Byte](https://docs.microsoft.com/dotnet/core/api/System.Byte) and [SByte](https://docs.microsoft.com/dotnet/core/api/System.SByte) values without performing any explicit conversions or using any casting operators, as the following example shows.

```csharp
SByte sbyteValue = -120;
ByteWithSign value = sbyteValue;
Console.WriteLine(value);
value = Byte.MaxValue;
Console.WriteLine(value);
// The example displays the following output:
//       -120
//       255
```

## Explicit Conversion with the Explicit Operator

Narrowing conversions involve the creation of a new value from the value of an existing type that has either a greater range or a larger member list than the target type. Because a narrowing conversion can result in a loss of data, compilers often require that the conversion be made explicit through a call to a conversion method or a casting operator. That is, the conversion must be handled explicitly in developer code. 

> **Note**
>
> The major purpose of requiring a conversion method or casting operator for narrowing conversions is to make the developer aware of the possibility of data loss or an [OverflowException](https://docs.microsoft.com/dotnet/core/api/System.OverflowException) so that it can be handled in code. However, some compilers can relax this requirement.

For example, the [UInt32](https://docs.microsoft.com/dotnet/core/api/System.UInt32), [Int64](https://docs.microsoft.com/dotnet/core/api/System.Int64), and [UInt64](https://docs.microsoft.com/dotnet/core/api/System.UInt64) data types have ranges that exceed that the [Int32](https://docs.microsoft.com/dotnet/core/api/System.Int32) data type, as the following table shows.

Type | Comparison with range of Int32
---- | ------------------------------
[Int64](https://docs.microsoft.com/dotnet/core/api/System.Int64) | [Int64.MaxValue](https://docs.microsoft.com/dotnet/core/api/System.Int64#System_Int64_MaxValue) is greater than [Int32.MaxValue](https://docs.microsoft.com/dotnet/core/api/System.Int32#System_Int32_MaxValue), and [Int64.MinValue](https://docs.microsoft.com/dotnet/core/api/System.Int64#System_Int64_MinValue) is less than (has a greater negative range than) [Int32.MinValue](https://docs.microsoft.com/dotnet/core/api/System.Int32#System_Int32_MinValue).
[UInt32](https://docs.microsoft.com/dotnet/core/api/System.UInt32) | [UInt32.MaxValue](https://docs.microsoft.com/dotnet/core/api/System.UInt32#System_UInt32_MaxValue) is greater than [Int32.MaxValue](https://docs.microsoft.com/dotnet/core/api/System.Int32#System_Int32_MaxValue).
[UInt64](https://docs.microsoft.com/dotnet/core/api/System.UInt64) | [UInt64.MaxValue](https://docs.microsoft.com/dotnet/core/api/System.UInt64#System_UInt64_MaxValue) is greater than [Int32.MaxValue](https://docs.microsoft.com/dotnet/core/api/System.Int32#System_Int32_MaxValue).

To handle such narrowing conversions, .NET Core allows types to define an `Explicit` operator. Individual language compilers can then implement this operator using their own syntax, or a member of the [Convert](https://docs.microsoft.com/dotnet/core/api/System.Convert) class can be called to perform the conversion. (For more information about the `Convert` class, see [The Convert Class](#The-Convert-Class) later in this topic.) The following example illustrates the use of language features to handle the explicit conversion of these potentially out-of-range integer values to [Int32](https://docs.microsoft.com/dotnet/core/api/System.Int32) values. 

```csharp
long number1 = int.MaxValue + 20L;
uint number2 = int.MaxValue - 1000;
ulong number3 = int.MaxValue;

int intNumber;

try {
   intNumber = checked((int) number1);
   Console.WriteLine("After assigning a {0} value, the Integer value is {1}.", 
                     number1.GetType().Name, intNumber); 
}
catch (OverflowException) {
   if (number1 > int.MaxValue)
      Console.WriteLine("Conversion failed: {0} exceeds {1}.", 
                        number1, int.MaxValue);
   else
      Console.WriteLine("Conversion failed: {0} is less than {1}.", 
                        number1, int.MinValue);
}

try {
   intNumber = checked((int) number2);
   Console.WriteLine("After assigning a {0} value, the Integer value is {1}.", 
                     number2.GetType().Name, intNumber); 
}
catch (OverflowException) {
   Console.WriteLine("Conversion failed: {0} exceeds {1}.", 
                     number2, int.MaxValue);
}

try {
   intNumber = checked((int) number3);
   Console.WriteLine("After assigning a {0} value, the Integer value is {1}.", 
                     number3.GetType().Name, intNumber); 
}
catch (OverflowException) {
   Console.WriteLine("Conversion failed: {0} exceeds {1}.", 
                     number1, int.MaxValue);
}

// The example displays the following output:
//    Conversion failed: 2147483667 exceeds 2147483647.
//    After assigning a UInt32 value, the Integer value is 2147482647.
//    After assigning a UInt64 value, the Integer value is 2147483647.
```

Explicit conversions can produce different results in different languages, and these results can differ from the value returned by the corresponding [Convert](https://docs.microsoft.com/dotnet/core/api/System.Convert) method. For example, if the [Double](https://docs.microsoft.com/dotnet/core/api/System.Double) value **12.63251** is converted to an [Int32](https://docs.microsoft.com/dotnet/core/api/System.Int32), bthe .NET Core [Convert.ToInt32(Double)](https://docs.microsoft.com/dotnet/core/api/System.Convert#System_Convert_ToInt32_System_Double_) method rounds the [Double](https://docs.microsoft.com/dotnet/core/api/System.Double) to return a value of **13**, but the C# `(int)` operator truncates the [Double](https://docs.microsoft.com/dotnet/core/api/System.Double) to return a value of **12**. Similarly, the C# `(int)` operator does not support Boolean-to-integer conversion, but the .NET Core [Convert.ToInt32(Boolean)](https://docs.microsoft.com/dotnet/core/api/System.Convert#System_Convert_ToInt32_System_Boolean_) method converts a value of `true` to **1**.

Most compilers allow explicit conversions to be performed in a checked or unchecked manner. When a checked conversion is performed, an [OverflowException](https://docs.microsoft.com/dotnet/core/api/System.OverflowException) is thrown when the value of the type to be converted is outside the range of the target type. When an unchecked conversion is performed under the same conditions, the conversion might not throw an exception, but the exact behavior becomes undefined and an incorrect value might result.

> **Note**
>
> In C#, checked conversions can be performed by using the `checked` keyword together with a casting operator, or by specifying the `/checked+` compiler option. Conversely, unchecked conversions can be performed by using the `unchecked` keyword together with the casting operator, or by specifying the `/checked-` compiler option. By default, explicit conversions are unchecked.

The following C# example uses the `checked` and `unchecked` keywords to illustrate the difference in behavior when a value outside the range of a [Byte](https://docs.microsoft.com/dotnet/core/api/System.Byte) is converted to a `Byte`. The checked conversion throws an exception, but the unchecked conversion assigns [Byte.MaxValue](https://docs.microsoft.com/dotnet/core/api/System.Byte#System_Byte_MaxValue) to the `Byte` variable.

```csharp
int largeValue = Int32.MaxValue;
byte newValue;

try {
   newValue = unchecked((byte) largeValue);
   Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.", 
                     largeValue.GetType().Name, largeValue,
                     newValue.GetType().Name, newValue);
}
catch (OverflowException) {
   Console.WriteLine("{0} is outside the range of the Byte data type.", 
                     largeValue);
}

try {
   newValue = checked((byte) largeValue);
   Console.WriteLine("Converted the {0} value {1} to the {2} value {3}.", 
                     largeValue.GetType().Name, largeValue,
                     newValue.GetType().Name, newValue);
}
catch (OverflowException) {
   Console.WriteLine("{0} is outside the range of the Byte data type.", 
                     largeValue);
}
// The example displays the following output:
//    Converted the Int32 value 2147483647 to the Byte value 255.
//    2147483647 is outside the range of the Byte data type.
```

If a particular language compiler supports custom overloaded operators, you can also define explicit conversions in your own custom types. The following example provides a partial implementation of a signed byte data type named `ByteWithSign` that uses sign-and-magnitude representation. It supports explicit conversion of [Int32](https://docs.microsoft.com/dotnet/core/api/System.Int32) and [UInt32](https://docs.microsoft.com/dotnet/core/api/System.UInt32) values to `ByteWithSign` values.

```csharp
public struct ByteWithSign
{
   private SByte signValue; 
   private Byte value;

   private const byte MaxValue = byte.MaxValue;
   private const int MinValue = -1 * byte.MaxValue;

   public static explicit operator ByteWithSign(int value) 
   {
      // Check for overflow.
      if (value > ByteWithSign.MaxValue || value < ByteWithSign.MinValue)
         throw new OverflowException(String.Format("'{0}' is out of range of the ByteWithSign data type.", 
                                                   value));

      ByteWithSign newValue;
      newValue.signValue = (SByte) Math.Sign(value);
      newValue.value = (byte) Math.Abs(value);
      return newValue;
   }  

   public static explicit operator ByteWithSign(uint value)
   {
      if (value > ByteWithSign.MaxValue) 
         throw new OverflowException(String.Format("'{0}' is out of range of the ByteWithSign data type.", 
                                                   value));

      ByteWithSign newValue;
      newValue.signValue = 1;
      newValue.value = (byte) value;
      return newValue;
   }

   public override string ToString()
   { 
      return (signValue * value).ToString();
   }
}
```

Client code can then declare a `ByteWithSign` variable and assign it [Int32](https://docs.microsoft.com/dotnet/core/api/System.Int32) and [UInt32](https://docs.microsoft.com/dotnet/core/api/System.UInt32) values if the assignments include a casting operator, as the following example shows.

```csharp
ByteWithSign value;

try {
   int intValue = -120;
   value = (ByteWithSign) intValue;
   Console.WriteLine(value);
}
catch (OverflowException e) {
   Console.WriteLine(e.Message);
}

try {
   uint uintValue = 1024;
   value = (ByteWithSign) uintValue;
   Console.WriteLine(value);
}
catch (OverflowException e) {
    Console.WriteLine(e.Message);
}
// The example displays the following output:
//       -120
//       '1024' is out of range of the ByteWithSign data type.
```

## The IConvertible Interface

To support the conversion of any type to a common language runtime base type, .NET Core provides the [IConvertible](https://docs.microsoft.com/dotnet/core/api/System.IConvertible) interface. The implementing type is required to provide the following:

* A method that returns the [TypeCode](https://docs.microsoft.com/dotnet/core/api/System.TypeCode) of the implementing type.

* Methods to convert the implementing type to each common language runtime base type ([Boolean](https://docs.microsoft.com/dotnet/core/api/System.Boolean), [Byte](https://docs.microsoft.com/dotnet/core/api/System.Byte), [DateTime](https://docs.microsoft.com/dotnet/core/api/System.DateTime), [Decimal](https://docs.microsoft.com/dotnet/core/api/System.Decimal), [Double](https://docs.microsoft.com/dotnet/core/api/System.Double), and so on).

* A generalized conversion method to convert an instance of the implementing type to another specified type. Conversions that are not supported should throw an [InvalidCastException](https://docs.microsoft.com/dotnet/core/api/System.InvalidCastException).

Each common language runtime base type (that is, the [Boolean](https://docs.microsoft.com/dotnet/core/api/System.Boolean), [Byte](https://docs.microsoft.com/dotnet/core/api/System.Byte), [Char](https://docs.microsoft.com/dotnet/core/api/System.Char), [DateTime](https://docs.microsoft.com/dotnet/core/api/System.DateTime), [Decimal](https://docs.microsoft.com/dotnet/core/api/System.Decimal), [Double](https://docs.microsoft.com/dotnet/core/api/System.Double), [Int16](https://docs.microsoft.com/dotnet/core/api/System.Int16), [Int32](https://docs.microsoft.com/dotnet/core/api/System.Int32), [Int64](https://docs.microsoft.com/dotnet/core/api/System.Int64), [SByte](https://docs.microsoft.com/dotnet/core/api/System.SByte), [Single](https://docs.microsoft.com/dotnet/core/api/System.Single), [String](https://docs.microsoft.com/dotnet/core/api/System.String), [UInt16](https://docs.microsoft.com/dotnet/core/api/System.UInt16), [UInt32](https://docs.microsoft.com/dotnet/core/api/System.UInt32), and [UInt64](https://docs.microsoft.com/dotnet/core/api/System.UInt64), as well as the [DBNull](https://docs.microsoft.com/dotnet/core/api/System.DBNull) and [Enum](https://docs.microsoft.com/dotnet/core/api/System.Enum) types, implement the [IConvertible](https://docs.microsoft.com/dotnet/core/api/System.IConvertible) interface. However, these are explicit interface implementations; the conversion method can be called only through an [IConvertible](https://docs.microsoft.com/dotnet/core/api/System.IConvertible) interface variable, as the following example shows. This example converts an [Int32](https://docs.microsoft.com/dotnet/core/api/System.Int32) value to its equivalent [Char](https://docs.microsoft.com/dotnet/core/api/System.Char) value.

```csharp
int codePoint = 1067;
IConvertible iConv = codePoint;
char ch = iConv.ToChar(null);
Console.WriteLine("Converted {0} to {1}.", codePoint, ch);
```

The requirement to call the conversion method on its interface rather than on the implementing type makes explicit interface implementations relatively expensive. Instead, we recommend that you call the appropriate member of the [Convert](https://docs.microsoft.com/dotnet/core/api/System.Convert) class to convert between common language runtime base types. For more information, see the next section, [The Convert Class](#The-Convert-Class). 

> **Note**
>
> In addition to the [IConvertible](https://docs.microsoft.com/dotnet/core/api/System.IConvertible) interface and the [Convert](https://docs.microsoft.com/dotnet/core/api/System.Convert) class provided by .NET Core, individual languages may also provide ways to perform conversions. For example, C# uses casting operators.

For the most part, the [IConvertible](https://docs.microsoft.com/dotnet/core/api/System.IConvertible) interface is designed to support conversion between the base types in .NET Core. However, the interface can also be implemented by a custom type to support conversion of that type to other custom types. For more information, see the section [Custom Conversions with the ChangeType Method](#Custom-Conversions-with-the-ChangeType-Method) later in this topic.

## The Convert Class

Although each base type's [IConvertible](https://docs.microsoft.com/dotnet/core/api/System.IConvertible) interface implementation can be called to perform a type conversion, calling the methods of the [System.Convert](https://docs.microsoft.com/dotnet/core/api/System.Convert) class is the recommended language-neutral way to convert from one base type to another. In addition, the [Convert.ChangeType(Object, Type, IFormatProvider)](https://docs.microsoft.com/dotnet/core/api/System.Convert#System_Convert_ChangeType_System_Object_System_TypeCode_System_IFormatProvider_) method can be used to convert from a specified custom type to another type. 

### Conversions Between Base Types

The [Convert](https://docs.microsoft.com/dotnet/core/api/System.Convert) class provides a language-neutral way to perform conversions between base types and is available to all languages that target the common language runtime. It provides a complete set of methods for both widening and narrowing conversions, and throws an [InvalidCastException](https://docs.microsoft.com/dotnet/core/api/System.InvalidCastException) for conversions that are not supported (such as the conversion of a [DateTime](https://docs.microsoft.com/dotnet/core/api/System.DateTime) value to an integer value). Narrowing conversions are performed in a checked context, and an [OverflowException](https://docs.microsoft.com/dotnet/core/api/System.OverflowException) is thrown if the conversion fails.

> **Important**
>
> Because the [Convert](https://docs.microsoft.com/dotnet/core/api/System.Convert) class includes methods to convert to and from each base type, it eliminates the need to call each base type's [IConvertible](https://docs.microsoft.com/dotnet/core/api/System.IConvertible) explicit interface implementation.

The following example illustrates the use of the [System.Convert](https://docs.microsoft.com/dotnet/core/api/System.Convert) class to perform several widening and narrowing conversions between .NET Core base types.

```csharp
// Convert an Int32 value to a Decimal (a widening conversion).
int integralValue = 12534;
decimal decimalValue = Convert.ToDecimal(integralValue);
Console.WriteLine("Converted the {0} value {1} to " +  
                                  "the {2} value {3:N2}.", 
                                  integralValue.GetType().Name, 
                                  integralValue, 
                                  decimalValue.GetType().Name, 
                                  decimalValue);
// Convert a Byte value to an Int32 value (a widening conversion).
byte byteValue = Byte.MaxValue;
int integralValue2 = Convert.ToInt32(byteValue);                                  
Console.WriteLine("Converted the {0} value {1} to " +  
                                  "the {2} value {3:G}.", 
                                  byteValue.GetType().Name, 
                                  byteValue, 
                                  integralValue2.GetType().Name, 
                                  integralValue2);

// Convert a Double value to an Int32 value (a narrowing conversion).
double doubleValue = 16.32513e12;
try {
   long longValue = Convert.ToInt64(doubleValue);
   Console.WriteLine("Converted the {0} value {1:E} to " +  
                                     "the {2} value {3:N0}.", 
                                     doubleValue.GetType().Name, 
                                     doubleValue, 
                                     longValue.GetType().Name, 
                                     longValue);
}
catch (OverflowException) {
   Console.WriteLine("Unable to convert the {0:E} value {1}.", 
                                     doubleValue.GetType().Name, doubleValue);
}

// Convert a signed byte to a byte (a narrowing conversion).     
sbyte sbyteValue = -16;
try {
   byte byteValue2 = Convert.ToByte(sbyteValue);
   Console.WriteLine("Converted the {0} value {1} to " +  
                                     "the {2} value {3:G}.", 
                                     sbyteValue.GetType().Name, 
                                     sbyteValue, 
                                     byteValue2.GetType().Name, 
                                     byteValue2);
}
catch (OverflowException) {
   Console.WriteLine("Unable to convert the {0} value {1}.", 
                                     sbyteValue.GetType().Name, sbyteValue);
}                                         
// The example displays the following output:
//       Converted the Int32 value 12534 to the Decimal value 12,534.00.
//       Converted the Byte value 255 to the Int32 value 255.
//       Converted the Double value 1.632513E+013 to the Int64 value 16,325,130,000,000.
//       Unable to convert the SByte value -16.
```

In some cases, particularly when converting to and from floating-point values, a conversion may involve a loss of precision, even though it does not throw an [OverflowException](https://docs.microsoft.com/dotnet/core/api/System.OverflowException). The following example illustrates this loss of precision. In the first case, a [Decimal](https://docs.microsoft.com/dotnet/core/api/System.Decimal) value has less precision (fewer significant digits) when it is converted to a [Double](https://docs.microsoft.com/dotnet/core/api/System.Double). In the second case, a [Double](https://docs.microsoft.com/dotnet/core/api/System.Double) value is rounded from **42.72** to **43** in order to complete the conversion.

```csharp
double doubleValue; 

// Convert a Double to a Decimal.
decimal decimalValue = 13956810.96702888123451471211m;
doubleValue = Convert.ToDouble(decimalValue);
Console.WriteLine("{0} converted to {1}.", decimalValue, doubleValue);

doubleValue = 42.72;
try {
   int integerValue = Convert.ToInt32(doubleValue);
   Console.WriteLine("{0} converted to {1}.", 
                                     doubleValue, integerValue);
}
catch (OverflowException) {      
   Console.WriteLine("Unable to convert {0} to an integer.", 
                                     doubleValue);
}   
// The example displays the following output:
//       13956810.96702888123451471211 converted to 13956810.9670289.
//       42.72 converted to 43.
```

For a table that lists both the widening and narrowing conversions supported by the [Convert](https://docs.microsoft.com/dotnet/core/api/System.Convert) class, see [Type Conversion Tables](conversio/conversiontables.md).

### Custom Conversions with the ChangeType Method

In addition to supporting conversions to each of the base types, the [Convert](https://docs.microsoft.com/dotnet/core/api/System.Convert) class can be used to convert a custom type to one or more predefined types. This conversion is performed by the [Convert.ChangeType(Object, Type, IFormatProvider)](https://docs.microsoft.com/dotnet/core/api/System.Convert#System_Convert_ChangeType_System_Object_System_Type_System_IFormatProvider_) method, which in turn wraps a call to the [IConvertible.ToType](https://docs.microsoft.com/dotnet/core/api/System.IConvertible#System_IConvertible_ToType_System_Type_System_IFormatProvider_) method of the value parameter. This means that the object represented by the value parameter must provide an implementation of the [IConvertible](https://docs.microsoft.com/dotnet/core/api/System.IConvertible) interface.

> **Note**
>
> Because the [Convert.ChangeType(Object, Type)](https://docs.microsoft.com/dotnet/core/api/System.Convert#System_Convert_ChangeType_System_Object_System_Type_) and [Convert.ChangeType(Object, Type, IFormatProvider)](https://docs.microsoft.com/dotnet/core/api/System.Convert#System_Convert_ChangeType_System_Object_System_Type_System_IFormatProvider_) methods use a [Type](https://docs.microsoft.com/dotnet/core/api/System.Type) object to specify the target type to which value is converted, they can be used to perform a dynamic conversion to an object whose type is not known at compile time. However, note that the [IConvertible](https://docs.microsoft.com/dotnet/core/api/System.IConvertible) implementation of value must still support this conversion. 

The following example illustrates a possible implementation of the [IConvertible](https://docs.microsoft.com/dotnet/core/api/System.IConvertible) interface that allows a `TemperatureCelsius` object to be converted to a `TemperatureFahrenheit` object and vice versa. The example defines a base class, `Temperature`, that implements the [IConvertible](https://docs.microsoft.com/dotnet/core/api/System.IConvertible) interface and overrides the [Object.ToString](https://docs.microsoft.com/dotnet/core/api/System.Object#System_Object_ToString) method. The derived `TemperatureCelsius` and `TemperatureFahrenheit` classes each override the `ToType` and the `ToString` methods of the base class. 

```csharp
using System;

public abstract class Temperature : IConvertible
{
   protected decimal temp;

   public Temperature(decimal temperature)
   {
      this.temp = temperature;
   }

   public decimal Value
   { 
      get { return this.temp; } 
      set { this.temp = Value; }        
   }

   public override string ToString()
   {
      return temp.ToString(null as IFormatProvider) + "º";
   }

   // IConvertible implementations.
   public TypeCode GetTypeCode() { 
      return TypeCode.Object;
   }   

   public bool ToBoolean(IFormatProvider provider) {
      throw new InvalidCastException(String.Format("Temperature-to-Boolean conversion is not supported."));
   }

   public byte ToByte(IFormatProvider provider) {
      if (temp < Byte.MinValue || temp > Byte.MaxValue)
         throw new OverflowException(String.Format("{0} is out of range of the Byte data type.", temp));
      else
         return (byte) temp;
   }

   public char ToChar(IFormatProvider provider) {
      throw new InvalidCastException("Temperature-to-Char conversion is not supported.");
   }

   public DateTime ToDateTime(IFormatProvider provider) {
      throw new InvalidCastException("Temperature-to-DateTime conversion is not supported.");
   }

   public decimal ToDecimal(IFormatProvider provider) {
      return temp;
   }

   public double ToDouble(IFormatProvider provider) {
      return (double) temp;
   }

   public short ToInt16(IFormatProvider provider) {
      if (temp < Int16.MinValue || temp > Int16.MaxValue)
         throw new OverflowException(String.Format("{0} is out of range of the Int16 data type.", temp));
      else
         return (short) Math.Round(temp);
   }

   public int ToInt32(IFormatProvider provider) {
      if (temp < Int32.MinValue || temp > Int32.MaxValue)
         throw new OverflowException(String.Format("{0} is out of range of the Int32 data type.", temp));
      else
         return (int) Math.Round(temp);
   }

   public long ToInt64(IFormatProvider provider) {
      if (temp < Int64.MinValue || temp > Int64.MaxValue)
         throw new OverflowException(String.Format("{0} is out of range of the Int64 data type.", temp));
      else
         return (long) Math.Round(temp);
   }

   public sbyte ToSByte(IFormatProvider provider) {
      if (temp < SByte.MinValue || temp > SByte.MaxValue)
         throw new OverflowException(String.Format("{0} is out of range of the SByte data type.", temp));
      else
         return (sbyte) temp;
   }

   public float ToSingle(IFormatProvider provider) {
      return (float) temp;
   }

   public virtual string ToString(IFormatProvider provider) {
      return temp.ToString(provider) + "°";
   }

   // If conversionType is implemented by another IConvertible method, call it.
   public virtual object ToType(Type conversionType, IFormatProvider provider) {
      switch (Type.GetTypeCode(conversionType))
      {
         case TypeCode.Boolean:
            return this.ToBoolean(provider);
         case TypeCode.Byte:
            return this.ToByte(provider);
         case TypeCode.Char:
            return this.ToChar(provider);
         case TypeCode.DateTime:
            return this.ToDateTime(provider);
         case TypeCode.Decimal:
            return this.ToDecimal(provider);
         case TypeCode.Double:
            return this.ToDouble(provider);
         case TypeCode.Empty:
            throw new NullReferenceException("The target type is null.");
         case TypeCode.Int16:
            return this.ToInt16(provider);
         case TypeCode.Int32:
            return this.ToInt32(provider);
         case TypeCode.Int64:
            return this.ToInt64(provider);
         case TypeCode.Object:
            // Leave conversion of non-base types to derived classes.
            throw new InvalidCastException(String.Format("Cannot convert from Temperature to {0}.", 
                                           conversionType.Name));
         case TypeCode.SByte:
            return this.ToSByte(provider);
         case TypeCode.Single:
            return this.ToSingle(provider);
         case TypeCode.String:
            IConvertible iconv = this;
            return iconv.ToString(provider);
         case TypeCode.UInt16:
            return this.ToUInt16(provider);
         case TypeCode.UInt32:
            return this.ToUInt32(provider);
         case TypeCode.UInt64:
            return this.ToUInt64(provider);
         default:
            throw new InvalidCastException("Conversion not supported.");
      }
   }

   public ushort ToUInt16(IFormatProvider provider) {
      if (temp < UInt16.MinValue || temp > UInt16.MaxValue)
         throw new OverflowException(String.Format("{0} is out of range of the UInt16 data type.", temp));
      else
         return (ushort) Math.Round(temp);
   }

   public uint ToUInt32(IFormatProvider provider) {
      if (temp < UInt32.MinValue || temp > UInt32.MaxValue)
         throw new OverflowException(String.Format("{0} is out of range of the UInt32 data type.", temp));
      else
         return (uint) Math.Round(temp);
   }

   public ulong ToUInt64(IFormatProvider provider) {
      if (temp < UInt64.MinValue || temp > UInt64.MaxValue)
         throw new OverflowException(String.Format("{0} is out of range of the UInt64 data type.", temp));
      else
         return (ulong) Math.Round(temp);
   }
}

public class TemperatureCelsius : Temperature, IConvertible
{
   public TemperatureCelsius(decimal value) : base(value)
   {
   }

   // Override ToString methods.
   public override string ToString()
   {
      return this.ToString(null);
   }

   public override string ToString(IFormatProvider provider)
   {
      return temp.ToString(provider) + "°C"; 
   }

   // If conversionType is a implemented by another IConvertible method, call it.
   public override object ToType(Type conversionType, IFormatProvider provider) {
      // For non-objects, call base method.
      if (Type.GetTypeCode(conversionType) != TypeCode.Object) {
         return base.ToType(conversionType, provider);
      }   
      else
      {   
         if (conversionType.Equals(typeof(TemperatureCelsius)))
            return this;
         else if (conversionType.Equals(typeof(TemperatureFahrenheit)))
            return new TemperatureFahrenheit((decimal) this.temp * 9 / 5 + 32);
         else
            throw new InvalidCastException(String.Format("Cannot convert from Temperature to {0}.", 
                                           conversionType.Name));
      }
   }
}

public class TemperatureFahrenheit : Temperature, IConvertible 
{
   public TemperatureFahrenheit(decimal value) : base(value)
   {
   }

   // Override ToString methods.
   public override string ToString()
   {
      return this.ToString(null);
   }

   public override string ToString(IFormatProvider provider)
   {
      return temp.ToString(provider) + "°F"; 
   }

   public override object ToType(Type conversionType, IFormatProvider provider)
   { 
      // For non-objects, call base methood.
      if (Type.GetTypeCode(conversionType) != TypeCode.Object) {
         return base.ToType(conversionType, provider);
      }   
      else
      {   
         // Handle conversion between derived classes.
         if (conversionType.Equals(typeof(TemperatureFahrenheit))) 
            return this;
         else if (conversionType.Equals(typeof(TemperatureCelsius)))
            return new TemperatureCelsius((decimal) (this.temp - 32) * 5 / 9);
         // Unspecified object type: throw an InvalidCastException.
         else
            throw new InvalidCastException(String.Format("Cannot convert from Temperature to {0}.", 
                                           conversionType.Name));
      }                                 
   }
}
```

The following example illustrates several calls to these [IConvertible](https://docs.microsoft.com/dotnet/core/api/System.IConvertible) implementations to convert `TemperatureCelsius` objects to `TemperatureFahrenheit` objects and vice versa.

```csharp
TemperatureCelsius tempC1 = new TemperatureCelsius(0);
TemperatureFahrenheit tempF1 = (TemperatureFahrenheit) Convert.ChangeType(tempC1, typeof(TemperatureFahrenheit), null);
Console.WriteLine("{0} equals {1}.", tempC1, tempF1);
TemperatureCelsius tempC2 = (TemperatureCelsius) Convert.ChangeType(tempC1, typeof(TemperatureCelsius), null);
Console.WriteLine("{0} equals {1}.", tempC1, tempC2);
TemperatureFahrenheit tempF2 = new TemperatureFahrenheit(212);
TemperatureCelsius tempC3 = (TemperatureCelsius) Convert.ChangeType(tempF2, typeof(TemperatureCelsius), null);
Console.WriteLine("{0} equals {1}.", tempF2, tempC3);
TemperatureFahrenheit tempF3 = (TemperatureFahrenheit) Convert.ChangeType(tempF2, typeof(TemperatureFahrenheit), null);
Console.WriteLine("{0} equals {1}.", tempF2, tempF3);
// The example displays the following output:
//       0°C equals 32°F.
//       0°C equals 0°C.
//       212°F equals 100°C.
//       212°F equals 212°F.
```

## The TypeConverter Class

.NET Core also allows you to define a type converter for a custom type by extending the [System.ComponentModel.TypeConverter](https://docs.microsoft.com/dotnet/core/api/System.ComponentModel.TypeConverter) class and associating the type converter with the type through a [System.ComponentModel.TypeConverterAttribute](https://docs.microsoft.com/dotnet/core/api/System.ComponentModel.TypeConverterAttribute) attribute. The following table highlights the differences between this approach and implementing the [IConvertible](https://docs.microsoft.com/dotnet/core/api/System.IConvertible) interface for a custom type.

> **Note**
>
> Design-time support can be provided for a custom type only if it has a type converter defined for it.

Conversion using TypeConverter | Conversion using IConvertible
------------------------------ | -----------------------------
Is implemented for a custom type by deriving a separate class from [TypeConverter](https://docs.microsoft.com/dotnet/core/api/System.ComponentModel.TypeConverter). This derived class is associated with the custom type by applying a [TypeConverterAttribute](https://docs.microsoft.com/dotnet/core/api/System.ComponentModel.TypeConverterAttribute) attribute. | Is implemented by a custom type to perform conversion. A user of the type invokes an [IConvertible](https://docs.microsoft.com/dotnet/core/api/System.IConvertible) conversion method on the type.
Can be used both at design time and at run time. | Can be used only at run time.
Uses reflection; therefore, is slower than conversion enabled by [IConvertible](https://docs.microsoft.com/dotnet/core/api/System.IConvertible). | Does not use reflection.
Allows two-way type conversions from the custom type to other data types, and from other data types to the custom type. For example, a [TypeConverter](https://docs.microsoft.com/dotnet/core/api/System.ComponentModel.TypeConverter) defined for `MyType` allows conversions from `MyType` to [String](https://docs.microsoft.com/dotnet/core/api/System.String), and from [String](https://docs.microsoft.com/dotnet/core/api/System.String) to `MyType`. | Allows conversion from a custom type to other data types, but not from other data types to the custom type.

For more information about using type converters to perform conversions, see [System.ComponentModel.TypeConverter](https://docs.microsoft.com/dotnet/core/api/System.ComponentModel.TypeConverter).

## See Also

[System.Convert](https://docs.microsoft.com/dotnet/core/api/System.Convert)

[IConvertible](https://docs.microsoft.com/dotnet/core/api/System.IConvertible)

[Type Conversion Tables](conversio/conversiontables.md)












