---
title: "Enum Design"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "type design guidelines, enumerations"
  - "simple enumerations"
  - "enumerations [.NET Framework], design guidelines"
  - "class library design guidelines [.NET Framework], enumerations"
  - "flags enumerations"
ms.assetid: dd53c952-9d9a-4736-86ff-9540e815d545
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Enum Design
Enums are a special kind of value type. There are two kinds of enums: simple enums and flag enums.  
  
 Simple enums represent small closed sets of choices. A common example of the simple enum is a set of colors.  
  
 Flag enums are designed to support bitwise operations on the enum values. A common example of the flags enum is a list of options.  
  
 **✓ DO** use an enum to strongly type parameters, properties, and return values that represent sets of values.  
  
 **✓ DO** favor using an enum instead of static constants.  
  
 **X DO NOT** use an enum for open sets (such as the operating system version, names of your friends, etc.).  
  
 **X DO NOT** provide reserved enum values that are intended for future use.  
  
 You can always simply add values to the existing enum at a later stage. See [Adding Values to Enums](#add_value) for more details on adding values to enums. Reserved values just pollute the set of real values and tend to lead to user errors.  
  
 **X AVOID** publicly exposing enums with only one value.  
  
 A common practice for ensuring future extensibility of C APIs is to add reserved parameters to method signatures. Such reserved parameters can be expressed as enums with a single default value. This should not be done in managed APIs. Method overloading allows adding parameters in future releases.  
  
 **X DO NOT** include sentinel values in enums.  
  
 Although they are sometimes helpful to framework developers, sentinel values are confusing to users of the framework. They are used to track the state of the enum rather than being one of the values from the set represented by the enum.  
  
 **✓ DO** provide a value of zero on simple enums.  
  
 Consider calling the value something like "None." If such a value is not appropriate for this particular enum, the most common default value for the enum should be assigned the underlying value of zero.  
  
 **✓ CONSIDER** using <xref:System.Int32> (the default in most programming languages) as the underlying type of an enum unless any of the following is true:  
  
-   The enum is a flags enum and you have more than 32 flags, or expect to have more in the future.  
  
-   The underlying type needs to be different than <xref:System.Int32> for easier interoperability with unmanaged code expecting different-size enums.  
  
-   A smaller underlying type would result in substantial savings in space. If you expect the enum to be used mainly as an argument for flow of control, the size makes little difference. The size savings might be significant if:  
  
    -   You expect the enum to be used as a field in a very frequently instantiated structure or class.  
  
    -   You expect users to create large arrays or collections of the enum instances.  
  
    -   You expect a large number of instances of the enum to be serialized.  
  
 For in-memory usage, be aware that managed objects are always `DWORD`-aligned, so you effectively need multiple enums or other small structures in an instance to pack a smaller enum with in order to make a difference, because the total instance size is always going to be rounded up to a `DWORD`.  
  
 **✓ DO** name flag enums with plural nouns or noun phrases and simple enums with singular nouns or noun phrases.  
  
 **X DO NOT** extend <xref:System.Enum?displayProperty=nameWithType> directly.  
  
 <xref:System.Enum?displayProperty=nameWithType> is a special type used by the CLR to create user-defined enumerations. Most programming languages provide a programming element that gives you access to this functionality. For example, in C# the `enum` keyword is used to define an enumeration.  
  
<a name="design"></a>   
### Designing Flag Enums  
 **✓ DO** apply the <xref:System.FlagsAttribute?displayProperty=nameWithType> to flag enums. Do not apply this attribute to simple enums.  
  
 **✓ DO** use powers of two for the flag enum values so they can be freely combined using the bitwise OR operation.  
  
 **✓ CONSIDER** providing special enum values for commonly used combinations of flags.  
  
 Bitwise operations are an advanced concept and should not be required for simple tasks. <xref:System.IO.FileAccess.ReadWrite> is an example of such a special value.  
  
 **X AVOID** creating flag enums where certain combinations of values are invalid.  
  
 **X AVOID** using flag enum values of zero unless the value represents "all flags are cleared" and is named appropriately, as prescribed by the next guideline.  
  
 **✓ DO** name the zero value of flag enums `None`. For a flag enum, the value must always mean "all flags are cleared."  
  
<a name="add_value"></a>   
### Adding Value to Enums  
 It is very common to discover that you need to add values to an enum after you have already shipped it. There is a potential application compatibility problem when the newly added value is returned from an existing API, because poorly written applications might not handle the new value correctly.  
  
 **✓ CONSIDER** adding values to enums, despite a small compatibility risk.  
  
 If you have real data about application incompatibilities caused by additions to an enum, consider adding a new API that returns the new and old values, and deprecate the old API, which should continue returning just the old values. This will ensure that your existing applications remain compatible.  
  
 *Portions © 2005, 2009 Microsoft Corporation. All rights reserved.*  
  
 *Reprinted by permission of Pearson Education, Inc. from [Framework Design Guidelines: Conventions, Idioms, and Patterns for Reusable .NET Libraries, 2nd Edition](https://www.informit.com/store/framework-design-guidelines-conventions-idioms-and-9780321545619) by Krzysztof Cwalina and Brad Abrams, published Oct 22, 2008 by Addison-Wesley Professional as part of the Microsoft Windows Development Series.*  
  
## See Also  
 [Type Design Guidelines](../../../docs/standard/design-guidelines/type.md)  
 [Framework Design Guidelines](../../../docs/standard/design-guidelines/index.md)
