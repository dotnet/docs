---
title: "Language Independence and Language-Independent Components"
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
  - "language interoperability"
  - "Common Language Specification"
  - "cross-language interoperability"
  - "CLS"
  - "runtime, language interoperability"
  - "common language runtime, language interoperability"
ms.assetid: 4f0b77d0-4844-464f-af73-6e06bedeafc6
caps.latest.revision: 35
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Language Independence and Language-Independent Components
The .NET Framework is language independent. This means that, as a developer, you can develop in one of the many languages that target the .NET Framework, such as C#, C++/CLI, Eiffel, F#, IronPython, IronRuby, PowerBuilder, Visual Basic, Visual COBOL, and Windows PowerShell. You can access the types and members of class libraries developed for the .NET Framework without having to know the language in which they were originally written and without having to follow any of the original language's conventions. If you are a component developer, your component can be accessed by any .NET Framework app regardless of its language.  
  
> [!NOTE]
>  This first part of this article discusses creating language-independent components—that is, components that can be consumed by apps that are written in any language. You can also create a single component or app from source code written in multiple languages; see [Cross-Language Interoperability](#CrossLang) in the second part of this article.  
  
 To fully interact with other objects written in any language, objects must expose to callers only those features that are common to all languages. This common set of features is defined by the Common Language Specification (CLS), which is a set of rules that apply to generated assemblies. The Common Language Specification is defined in Partition I, Clauses 7 through 11 of the [ECMA-335 Standard: Common Language Infrastructure](http://go.microsoft.com/fwlink/?LinkID=116487).  
  
 If your component conforms to the Common Language Specification, it is guaranteed to be CLS-compliant and can be accessed from code in assemblies written in any programming language that supports the CLS. You can determine whether your component conforms to the Common Language Specification at compile time by applying the <xref:System.CLSCompliantAttribute> attribute to your source code. For more information, see [The CLSCompliantAttribute attribute](#CLSAttribute).  
  
 In this article:  
  
-   [CLS compliance  rules](#Rules)  
  
    -   [Types and type member signatures](#Types)  
  
    -   [Naming conventions](#naming)  
  
    -   [Type conversion](#conversion)  
  
    -   [Arrays](#arrays)  
  
    -   [Interfaces](#Interfaces)  
  
    -   [Enumerations](#enums)  
  
    -   [Type members in general](#members)  
  
    -   [Member accessibility](#MemberAccess)  
  
    -   [Generic types and members](#Generics)  
  
    -   [Constructors](#ctors)  
  
    -   [Properties](#properties)  
  
    -   [Events](#events)  
  
    -   [Overloads](#overloads)  
  
    -   [Exceptions](#exceptions)  
  
    -   [Attributes](#attributes)  
  
-   [The CLSCompliantAttribute attribute](#CLSAttribute)  
  
-   [Cross-Language Interoperability](#CrossLang)  
  
<a name="Rules"></a>   
## CLS compliance rules  
 This section discusses the rules for creating a CLS-compliant component. For a complete list of rules, see Partition I, Clause 11 of the [ECMA-335 Standard: Common Language Infrastructure](http://go.microsoft.com/fwlink/?LinkID=116487).  
  
> [!NOTE]
>  The Common Language Specification discusses each rule for CLS compliance as it applies to consumers (developers who are programmatically accessing a component that is CLS-compliant), frameworks (developers who are using a language compiler to create CLS-compliant libraries), and extenders (developers who are creating a tool such as a language compiler or a code parser that creates CLS-compliant components). This article focuses on the rules as they apply to frameworks. Note, though, that some of the rules that apply to extenders may also apply to assemblies that are created using Reflection.Emit.  
  
 To design a component that is language independent, you only need to apply the rules for CLS compliance to your component's public interface. Your private implementation does not have to conform to the specification.  
  
> [!IMPORTANT]
>  The rules for CLS compliance apply only to a component's public interface, not to its private implementation.  
  
 For example, unsigned integers other than <xref:System.Byte> are not CLS-compliant. Because the `Person` class in the following example exposes an `Age` property of type <xref:System.UInt16>, the following code displays a compiler warning.  
  
 [!code-csharp[Conceptual.CLSCompliant#1](../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.clscompliant/cs/public1.cs#1)]
 [!code-vb[Conceptual.CLSCompliant#1](../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.clscompliant/vb/public1.vb#1)]  
  
 You can make the `Person` class CLS-compliant by changing the type of `Age` property from <xref:System.UInt16> to <xref:System.Int16>, which is a CLS-compliant, 16-bit signed integer. You do not have to change the type of the private `personAge` field.  
  
 [!code-csharp[Conceptual.CLSCompliant#2](../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.clscompliant/cs/public2.cs#2)]
 [!code-vb[Conceptual.CLSCompliant#2](../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.clscompliant/vb/public2.vb#2)]  
  
 A library's public interface consists of the following:  
  
-   Definitions of public classes.  
  
-   Definitions of the public members of public classes, and definitions of members accessible to derived classes (that is, protected members).  
  
-   Parameters and return types of public methods of public classes, and parameters and return types of methods accessible to derived classes.  
  
 The rules for CLS compliance are listed in the following table. The text of the rules is taken verbatim from the [ECMA-335 Standard: Common Language Infrastructure](http://go.microsoft.com/fwlink/?LinkID=116487), which is Copyright 2012 by Ecma International. More detailed information about these rules is found in the following sections.  
  
|Category|See|Rule|Rule number|  
|--------------|---------|----------|-----------------|  
|Accessibility|[Member accessibility](#MemberAccess)|Accessibility shall not be changed when overriding inherited methods, except when overriding a method inherited from a different assembly with accessibility `family-or-assembly`. In this case, the override shall have accessibility `family`.|10|  
|Accessibility|[Member accessibility](#MemberAccess)|The visibility and accessibility of types and members shall be such that types in the signature of any member shall be visible and accessible whenever the member itself is visible and accessible. For example, a public method that is visible outside its assembly shall not have an argument whose type is visible only within the assembly. The visibility and accessibility of types composing an instantiated generic type used in the signature of any member shall be visible and accessible whenever the member itself is visible and accessible. For example, an instantiated generic type present in the signature of a member that is visible outside its assembly shall not have a generic argument whose type is visible only within the assembly.|12|  
|Arrays|[Arrays](#arrays)|Arrays shall have elements with a CLS-compliant type, and all dimensions of the array shall have lower bounds of zero. Only the fact that an item is an array and the element type of the array shall be required to distinguish between overloads. When overloading is based on two or more array types the element types shall be named types.|16|  
|Attributes|[Attributes](#attributes)|Attributes shall be of type <xref:System.Attribute?displayProperty=nameWithType>, or a type inheriting from it.|41|  
|Attributes|[Attributes](#attributes)|The CLS only allows a subset of the encodings of custom attributes. The only types that shall appear in these encodings are (see Partition IV): <xref:System.Type?displayProperty=nameWithType>, <xref:System.String?displayProperty=nameWithType>, <xref:System.Char?displayProperty=nameWithType>, <xref:System.Boolean?displayProperty=nameWithType>, <xref:System.Byte?displayProperty=nameWithType>, <xref:System.Int16?displayProperty=nameWithType>, <xref:System.Int32?displayProperty=nameWithType>, <xref:System.Int64?displayProperty=nameWithType>, <xref:System.Single?displayProperty=nameWithType>, <xref:System.Double?displayProperty=nameWithType>, and any enumeration type based on a CLS-compliant base integer type.|34|  
|Attributes|[Attributes](#attributes)|The CLS does not allow publicly visible required modifiers (`modreq`, see Partition II), but does allow optional modifiers (`modopt`, see Partition II) it does not understand.|35|  
|Constructors|[Constructors](#ctors)|An object constructor shall call some instance constructor of its base class before any access occurs to inherited instance data. (This does not apply to value types, which need not have constructors.)|21|  
|Constructors|[Constructors](#ctors)|An object constructor shall not be called except as part of the creation of an object, and an object shall not be initialized twice.|22|  
|Enumerations|[Enumerations](#enums)|The underlying type of an enum shall be a built-in CLS integer type, the name of the field shall be "value__", and that field shall be marked `RTSpecialName`.|7|  
|Enumerations|[Enumerations](#enums)|There are two distinct kinds of enums, indicated by the presence or absence of the <xref:System.FlagsAttribute?displayProperty=nameWithType> (see Partition IV Library) custom attribute. One represents named integer values; the other represents named bit flags that can be combined to generate an unnamed value. The value of an `enum` is not limited to the specified values.|8|  
|Enumerations|[Enumerations](#enums)|Literal static fields of an enum shall have the type of the enum itself.|9|  
|Events|[Events](#events)|The methods that implement an event shall be marked `SpecialName` in themetadata.|29|  
|Events|[Events](#events)|The accessibility of an event and of its accessors shall be identical.|30|  
|Events|[Events](#events)|The `add` and `remove` methods for an event shall both either be present or absent.|31|  
|Events|[Events](#events)|The `add` and `remove` methods for an event shall each take one parameter whose type defines the type of the event and that shall be derived from <xref:System.Delegate?displayProperty=nameWithType>.|32|  
|Events|[Events](#events)|Events shall adhere to a specific naming pattern. The `SpecialName` attribute referred to in CLS rule 29 shall be ignored in appropriate name comparisons and shall adhere to identifier rules.|33|  
|Exceptions|[Exceptions](#exceptions)|Objects that are thrown shall be of type <xref:System.Exception?displayProperty=nameWithType> or a type inheriting from it. Nonetheless, CLS-compliant methods are not required to block the propagation of other types of exceptions.|40|  
|General|[CLS compliance: the Rules](#Rules)|CLS rules apply only to those parts of a type that are accessible or visible outsideof the defining assembly.|1|  
|General|[CLS compliance: the Rules](#Rules)|Members of non-CLS compliant types shall not be marked CLS-compliant.|2|  
|Generics|[Generic types and members](#Generics)|Nested types shall have at least as many generic parameters as the enclosing type. Generic parameters in a nested type correspond by position to the generic parameters in its enclosing type.|42|  
|Generics|[Generic types and members](#Generics)|The name of a generic type shall encode the number of type parameters declared on the non-nested type, or newly introduced to the type if nested, according to the rules defined above.|43|  
|Generics|[Generic types and members](#Generics)|A generic type shall redeclare sufficient constraints to guarantee that any constraints on the base type, or interfaces would be satisfied by the generic type constraints.|4444|  
|Generics|[Generic types and members](#Generics)|Types used as constraints on generic parameters shall themselves be CLS-compliant.|45|  
|Generics|[Generic types and members](#Generics)|The visibility and accessibility of members (including nested types) in an instantiated generic type shall be considered to be scoped to the specific instantiation rather than the generic type declaration as a whole. Assuming this, the visibility and accessibility rules of CLS rule 12 still apply.|46|  
|Generics|[Generic types and members](#Generics)|For each abstract or virtual generic method, there shall be a default concrete (nonabstract) implementation.|47|  
|Interfaces|[Interfaces](#Interfaces)|CLS-compliant interfaces shall not require the definition of non-CLS compliantmethods in order to implement them.|18|  
|Interfaces|[Interfaces](#Interfaces)|CLS-compliant interfaces shall not define static methods, nor shall they define fields.|19|  
|Members|[Type members in general](#members)|Global static fields and methods are not CLS-compliant.|36|  
|Members|--|The value of a literal static is specified through the use of field initialization metadata. A CLS-compliant literal must have a value specified in field initialization metadata that is of exactly the same type as the literal (or of the underlying type, if that literal is an `enum`).|13|  
|Members|[Type members in general](#members)|The vararg constraint is not part of the CLS, and the only calling convention supported by the CLS is the standard managed calling convention.|15|  
|Naming conventions|[Naming conventions](#naming)|Assemblies shall follow Annex 7 of Technical Report 15 of the Unicode Standard3.0 governing the set of characters permitted to start and be included in identifiers, available onlineat http://www.unicode.org/unicode/reports/tr15/tr15-18.html. Identifiers shall be in thecanonical format defined by Unicode Normalization Form C. For CLS purposes, two identifiersare the same if their lowercase mappings (as specified by the Unicode locale-insensitive, one-toonelowercase mappings) are the same. That is, for two identifiers to be considered differentunder the CLS they shall differ in more than simply their case. However, in order to override aninherited definition the CLI requires the precise encoding of the original declaration be used.|4|  
|Overloading|[Naming conventions](#naming)|All names introduced in a CLS-compliant scope shall be distinct independent ofkind, except where the names are identical and resolved via overloading. That is, while the CTSallows a single type to use the same name for a method and a field, the CLS does not.|5|  
|Overloading|[Naming conventions](#naming)|Fields and nested types shall be distinct by identifier comparison alone, eventhough the CTS allows distinct signatures to be distinguished. Methods, properties, and eventsthat have the same name (by identifier comparison) shall differ by more than just the return type,except as specified in CLS Rule 39.|6|  
|Overloading|[Overloads](#overloads)|Only properties and methods can be overloaded.|37|  
|Overloading|[Overloads](#overloads)|Properties and methods can be overloaded based only on the number and types of their parameters, except the conversion operators named `op_Implicit` and `op_Explicit`, which can also be overloaded based on their return type.|38|  
|Overloading|--|If two or more CLS-compliant methods declared in a type have the same nameand, for a specific set of type instantiations, they have the same parameter and return types, thenall these methods shall be semantically equivalent at those type instantiations.|48|  
|Types|[Type and type member signatures](#Types)|<xref:System.Object?displayProperty=nameWithType> is CLS-compliant. Any other CLS-compliant class shall inherit from a CLS-compliant class.|23|  
|Properties|[Properties](#properties)|The methods that implement the getter and setter methods of a property shallbe marked `SpecialName` in the metadata.|24|  
|Properties|[Properties](#properties)|A property’s accessors shall all be static, all be virtual, or all be instance.|26|  
|Properties|[Properties](#properties)|The type of a property shall be the return type of the getter and the type of the last argument of the setter. The types of the parameters of the property shall be the types of the parameters to the getter and the types of all but the final parameter of the setter. All of these types shall be CLS-compliant, and shall not be managed pointers (i.e., shall not be passed by reference).|27|  
|Properties|[Properties](#properties)|Properties shall adhere to a specific naming pattern. The `SpecialName` attribute referred to in CLS rule 24 shall be ignored in appropriate name comparisons and shall adhere to identifier rules. A property shall have a getter method, a setter method, or both.|28|  
|Type conversion|[Type conversion](#conversion)|If either `op_Implicit` or `op_Explicit` is provided, an alternate means of providing the coercion shall be provided.|39|  
|Types|[Type and type member signatures](#Types)|Boxed value types are not CLS-compliant.|3|  
|Types|[Type and type member signatures](#Types)|All types appearing in a signature shall be CLS-compliant. All types composing an instantiated generic type shall be CLS-compliant.|11|  
|Types|[Type and type member signatures](#Types)|Typed references are not CLS-compliant.|14|  
|Types|[Type and type member signatures](#Types)|Unmanaged pointer types are not CLS-compliant.|17|  
|Types|[Type and type member signatures](#Types)|CLS-compliant classes, value types, and interfaces shall not require the implementation of non-CLS-compliant members.|20|  
  
<a name="Types"></a>   
### Types and type member signatures  
 The <xref:System.Object?displayProperty=nameWithType> type is CLS-compliant and is the base type of all object types in the .NET Framework type system. Inheritance in the .NET Framework is either implicit (for example, the <xref:System.String> class implicitly inherits from the <xref:System.Object> class) or explicit (for example, the <xref:System.Globalization.CultureNotFoundException> class explicitly inherits from the <xref:System.ArgumentException> class, which explicitly inherits from the <xref:System.SystemException> class, which explicitly inherits from the <xref:System.Exception> class). For a derived type to be CLS compliant, its base type must also be CLS-compliant.  
  
 The following example shows a derived type whose base type is not CLS-compliant. It defines a base `Counter` class that uses an unsigned 32-bit integer as a counter. Because the class provides counter functionality by wrapping an unsigned integer, the class is marked as non-CLS-compliant. As a result, a derived class, `NonZeroCounter`, is also not CLS-compliant.  
  
 [!code-csharp[Conceptual.CLSCompliant#12](../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.clscompliant/cs/type3.cs#12)]
 [!code-vb[Conceptual.CLSCompliant#12](../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.clscompliant/vb/type3.vb#12)]  
  
 All types that appear in member signatures, including a method's return type or a property type, must be CLS-compliant. In addition, for generic types:  
  
-   All types that compose an instantiated generic type must be CLS-compliant.  
  
-   All types used as constraints on generic parameters must be CLS-compliant.  
  
 The .NET Framework [common type system](../../docs/standard/base-types/common-type-system.md) includes a number of built-in types that are supported directly by the common language runtime and are specially encoded in an assembly's metadata. Of these intrinsic types, the types listed in the following table are CLS-compliant.  
  
|CLS-compliant type|Description|  
|-------------------------|-----------------|  
|<xref:System.Byte>|8-bit unsigned integer|  
|<xref:System.Int16>|16-bit signed integer|  
|<xref:System.Int32>|32-bit signed integer|  
|<xref:System.Int64>|64-bit signed integer|  
|<xref:System.Single>|Single-precision floating-point value|  
|<xref:System.Double>|Double-precision floating-point value|  
|<xref:System.Boolean>|`true` or `false` value type|  
|<xref:System.Char>|UTF-16 encoded code unit|  
|<xref:System.Decimal>|Non-floating-point decimal number|  
|<xref:System.IntPtr>|Pointer or handle of a platform-defined size|  
|<xref:System.String>|Collection of zero, one, or more <xref:System.Char> objects|  
  
 The intrinsic types listed in the following table are not CLS-Compliant.  
  
|Non-compliant type|Description|CLS-compliant alternative|  
|-------------------------|-----------------|--------------------------------|  
|<xref:System.SByte>|8-bit signed integer data type|<xref:System.Int16>|  
|<xref:System.TypedReference>|Pointer to an object and its runtime type|None|  
|<xref:System.UInt16>|16-bit unsigned integer|<xref:System.Int32>|  
|<xref:System.UInt32>|32-bit unsigned integer|<xref:System.Int64>|  
|<xref:System.UInt64>|64-bit unsigned integer|<xref:System.Int64> (may overflow), <xref:System.Numerics.BigInteger>, or <xref:System.Double>|  
|<xref:System.UIntPtr>|Unsigned pointer or handle|<xref:System.IntPtr>|  
  
 The .NET Framework Class Library or any other class library may include other types that aren't CLS-compliant; for example:  
  
-   Boxed value types. The following C# example creates a class that has a public property of type `int*` named `Value`. Because an `int*` is a boxed value type, the compiler flags it as non-CLS-compliant.  
  
     [!code-csharp[Conceptual.CLSCompliant#26](../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.clscompliant/cs/box2.cs#26)]  
  
-   Typed references, which are special constructs that contain a reference to an object and a reference to a type. Typed references are represented in the .NET Framework by the <xref:System.TypedReference> class.  
  
 If a type is not CLS-compliant, you should apply the <xref:System.CLSCompliantAttribute> attribute with an `isCompliant` value of `false` to it. For more information, see [The CLSCompliantAttribute attribute](#CLSAttribute) section.  
  
 The following example illustrates the problem of CLS compliance in a method signature and in generic type instantiation. It defines an `InvoiceItem` class with a property of type <xref:System.UInt32>, a property of type `Nullable(Of UInt32)`, and a constructor with parameters of type <xref:System.UInt32> and `Nullable(Of UInt32)`. You get four compiler warnings when you try to compile this example.  
  
 [!code-csharp[Conceptual.CLSCompliant#3](../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.clscompliant/cs/type1.cs#3)]
 [!code-vb[Conceptual.CLSCompliant#3](../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.clscompliant/vb/type1.vb#3)]  
  
 To eliminate the compiler warnings, replace the non-CLS-compliant types in the `InvoiceItem` public interface with compliant types:  
  
 [!code-csharp[Conceptual.CLSCompliant#4](../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.clscompliant/cs/type2.cs#4)]
 [!code-vb[Conceptual.CLSCompliant#4](../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.clscompliant/vb/type2.vb#4)]  
  
 In addition to the specific types listed, some categories of types are not CLS compliant. These include unmanaged pointer types and function pointer types. The following example generates a compiler warning because it uses a pointer to an integer to create an array of integers.  
  
 [!code-csharp[Conceptual.CLSCompliant#5](../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.clscompliant/cs/unmanagedptr1.cs#5)]  
  
 For CLS-compliant abstract classes (that is, classes marked as `abstract` in C# or as `MustInherit` in Visual Basic), all members of the class must also be CLS-compliant.  
  
<a name="naming"></a>   
### Naming conventions  
 Because some programming languages are case-insensitive, identifiers (such as the names of namespaces, types, and members) must differ by more than case. Two identifiers are considered equivalent if their lowercase mappings are the same. The following C# example defines two public classes, `Person` and `person`. Because they differ only by case, the C# compiler flags them as not CLS-compliant.  
  
 [!code-csharp[Conceptual.CLSCompliant#16](../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.clscompliant/cs/naming1.cs#16)]  
  
 Programming language identifiers, such as the names of namespaces, types, and members, must conform to the [Unicode Standard 3.0, Technical Report 15, Annex 7](https://www.unicode.org/reports/tr15/tr15-18.html). This means that:  
  
-   The first character of an identifier can be any Unicode uppercase letter, lowercase letter, title case letter, modifier letter, other letter, or letter number. For information on Unicode character categories, see the <xref:System.Globalization.UnicodeCategory?displayProperty=nameWithType> enumeration.  
  
-   Subsequent characters can be from any of the categories as the first character, and can also include non-spacing marks, spacing combining marks, decimal numbers, connector punctuations, and formatting codes.  
  
 Before you compare identifiers, you should filter out formatting codes and convert the identifiers to Unicode Normalization Form C, because a single character can be represented by multiple UTF-16-encoded code units. Character sequences that produce the same code units in Unicode Normalization Form C are not CLS-compliant. The following example defines a property named `Å`, which consists of the character ANGSTROM SIGN (U+212B), and a second property named `Å`, which consists of the character LATIN CAPITAL LETTER A WITH RING ABOVE (U+00C5). Both the C# and Visual Basic compilers flag the source code as non-CLS-compliant.  
  
 [!code-csharp[Conceptual.CLSCompliant#17](../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.clscompliant/cs/naming1.cs#17)]
 [!code-vb[Conceptual.CLSCompliant#17](../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.clscompliant/vb/naming1.vb#17)]  
  
 Member names within a particular scope (such as the namespaces within an assembly, the types within a namespace, or the members within a type) must be unique except for names that are resolved through overloading. This requirement is more stringent than that of the common type system, which allows multiple members within a scope to have identical names as long as they are different kinds of members (for example, one is a method and one is a field). In particular, for type members:  
  
-   Fields and nested types are distinguished by name alone.  
  
-   Methods, properties, and events that have the same name must differ by more than just return type.  
  
 The following example illustrates the requirement that member names must be unique within their scope. It defines a class named `Converter` that includes four members named `Conversion`. Three are methods, and one is a property. The method that includes an <xref:System.Int64> parameter is uniquely named, but the two methods with an <xref:System.Int32> parameter are not, because return value is not considered a part of a member's signature. The `Conversion` property also violates this requirement, because properties cannot have the same name as overloaded methods.  
  
 [!code-csharp[Conceptual.CLSCompliant#19](../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.clscompliant/cs/naming3.cs#19)]
 [!code-vb[Conceptual.CLSCompliant#19](../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.clscompliant/vb/naming3.vb#19)]  
  
 Individual languages include unique keywords, so languages that target the common language runtime must also provide some mechanism for referencing identifiers (such as type names) that coincide with keywords. For example, `case` is a keyword in both C# and Visual Basic. However, the following Visual Basic example is able to disambiguate a class named `case` from the `case` keyword by using opening and closing braces. Otherwise, the example would produce the error message, "Keyword is not valid as an identifier," and fail to compile.  
  
 [!code-vb[Conceptual.CLSCompliant#22](../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.clscompliant/vb/keyword1.vb#22)]  
  
 The following C# example is able to instantiate the `case` class by using the `@` symbol to disambiguate the identifier from the language keyword. Without it, the C# compiler would display two error messages, "Type expected" and "Invalid expression term 'case'."  
  
 [!code-csharp[Conceptual.CLSCompliant#23](../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.clscompliant/cs/keyword2.cs#23)]  
  
<a name="conversion"></a>   
### Type conversion  
 The Common Language Specification defines two conversion operators:  
  
-   `op_Implicit`, which is used for widening conversions that do not result in loss of data or precision. For example, the <xref:System.Decimal> structure includes an overloaded `op_Implicit` operator to convert values of integral types and <xref:System.Char> values to <xref:System.Decimal> values.  
  
-   `op_Explicit`, which is used for narrowing conversions that can result in loss of magnitude (a value is converted to a value that has a smaller range) or precision. For example, the <xref:System.Decimal> structure includes an overloaded `op_Explicit` operator to convert <xref:System.Double> and <xref:System.Single> values to <xref:System.Decimal> and to convert <xref:System.Decimal> values to integral values, <xref:System.Double>, <xref:System.Single>, and <xref:System.Char>.  
  
 However, not all languages support operator overloading or the definition of custom operators. If you choose to implement these conversion operators, you should also provide an alternate way to perform the conversion. We recommend that you provide `From`*Xxx* and `To`*Xxx* methods.  
  
 The following example defines CLS-compliant implicit and explicit conversions. It creates a `UDouble` class that represents an signed double-precision, floating-point number. It provides for implicit conversions from `UDouble` to <xref:System.Double> and for explicit conversions from `UDouble` to <xref:System.Single>, <xref:System.Double> to `UDouble`, and <xref:System.Single> to `UDouble`. It also defines a `ToDouble` method as an alternative to the implicit conversion operator and the `ToSingle`, `FromDouble`, and `FromSingle` methods as alternatives to the explicit conversion operators.  
  
 [!code-csharp[Conceptual.CLSCompliant#15](../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.clscompliant/cs/convert1.cs#15)]
 [!code-vb[Conceptual.CLSCompliant#15](../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.clscompliant/vb/convert1.vb#15)]  
  
<a name="arrays"></a>   
### Arrays  
 CLS-compliant arrays conform to the following rules:  
  
-   All dimensions of an array must have a lower bound of zero. The following example creates a non-CLS-compliant array with a lower bound of one. Note that, despite the presence of the <xref:System.CLSCompliantAttribute> attribute, the compiler does not detect that the array returned by the `Numbers.GetTenPrimes` method is not CLS-compliant.  
  
     [!code-csharp[Conceptual.CLSCompliant#8](../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.clscompliant/cs/array1.cs#8)]
     [!code-vb[Conceptual.CLSCompliant#8](../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.clscompliant/vb/array1.vb#8)]  
  
-   All array elements must consist of CLS-compliant types. The following example defines two methods that return non-CLS-compliant arrays. The first returns an array of <xref:System.UInt32> values. The second returns an <xref:System.Object> array that includes <xref:System.Int32> and <xref:System.UInt32> values. Although the compiler identifies the first array as non-compliant because of its <xref:System.UInt32> type, it fails to recognize that the second array includes non-CLS-compliant elements.  
  
     [!code-csharp[Conceptual.CLSCompliant#9](../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.clscompliant/cs/array2.cs#9)]
     [!code-vb[Conceptual.CLSCompliant#9](../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.clscompliant/vb/array2.vb#9)]  
  
-   Overload resolution for methods that have array parameters is based on the fact that they are arrays and on their element type. For this reason, the following definition of an overloaded `GetSquares` method is CLS-compliant.  
  
     [!code-csharp[Conceptual.CLSCompliant#10](../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.clscompliant/cs/array3.cs#10)]
     [!code-vb[Conceptual.CLSCompliant#10](../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.clscompliant/vb/array3.vb#10)]  
  
<a name="Interfaces"></a>   
### Interfaces  
 CLS-compliant interfaces can define properties, events, and virtual methods (methods with no implementation). A CLS-compliant interface cannot have any of the following:  
  
-   Static methods or static fields. Both the C# and Visual Basic compilers generate compiler errors if you define a static member in an interface.  
  
-   Fields. Both the C# and Visual Basic compilers generate compiler errors if you define a field in an interface.  
  
-   Methods that are not CLS-compliant. For example, the following interface definition includes a method, `INumber.GetUnsigned`, that is marked as non-CLS-compliant. This example generates a compiler warning.  
  
     [!code-csharp[Conceptual.CLSCompliant#6](../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.clscompliant/cs/interface2.cs#6)]
     [!code-vb[Conceptual.CLSCompliant#6](../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.clscompliant/vb/interface2.vb#6)]  
  
     Because of this rule, CLS-compliant types are not required to implement non-CLS-compliant members. If a CLS-compliant framework does expose a class that implements a non-CLS compliant interface, it should also provide concrete implementations of all non-CLS-compliant members.  
  
 CLS-compliant language compilers must also allow a class to provide separate implementations of members that have the same name and signature in multiple interfaces.  Both C# and Visual Basic support [explicit interface implementations](~/docs/csharp/programming-guide/interfaces/explicit-interface-implementation.md) to provide different implementations of identically named methods. Visual Basic also supports the `Implements` keyword, which enables you to explicitly designate which interface and member a particular member implements. The following example illustrates this scenario by defining a `Temperature` class that implements the `ICelsius` and `IFahrenheit` interfaces as explicit interface implementations.  
  
 [!code-csharp[Conceptual.CLSCompliant#24](../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.clscompliant/cs/eii1.cs#24)]
 [!code-vb[Conceptual.CLSCompliant#24](../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.clscompliant/vb/eii1.vb#24)]  
  
<a name="enums"></a>   
### Enumerations  
 CLS-compliant enumerations must follow these rules:  
  
-   The underlying type of the enumeration must be an intrinsic CLS-compliant integer (<xref:System.Byte>, <xref:System.Int16>, <xref:System.Int32>, or <xref:System.Int64>). For example, the following code tries to define an enumeration whose underlying type is <xref:System.UInt32> and generates a compiler warning.  
  
     [!code-csharp[Conceptual.CLSCompliant#7](../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.clscompliant/cs/enum3.cs#7)]
     [!code-vb[Conceptual.CLSCompliant#7](../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.clscompliant/vb/enum3.vb#7)]  
  
-   An enumeration type must have a single instance field named `Value__` that is marked with the <xref:System.Reflection.FieldAttributes.RTSpecialName?displayProperty=nameWithType> attribute. This enables you to reference the field value implicitly.  
  
-   An enumeration includes literal static fields whose types match the type of the enumeration itself. For example, if you define a `State` enumeration with values of `State.On` and `State.Off`, `State.On` and `State.Off` are both literal static fields whose type is `State`.  
  
-   There are two kinds of enumerations:  
  
    -   An enumeration that represents a set of mutually exclusive, named integer values. This type of enumeration is indicated by the absence of the <xref:System.FlagsAttribute?displayProperty=nameWithType> custom attribute.  
  
    -   An enumeration that represents a set of bit flags that can combine to generate an unnamed value. This type of enumeration is indicated by the presence of the <xref:System.FlagsAttribute?displayProperty=nameWithType> custom attribute.  
  
     For more information, see the documentation for the <xref:System.Enum> structure.  
  
-   The value of an enumeration is not limited to the range of its specified values. In other words, the range of values in an enumeration is the range of its underlying value. You can use the <xref:System.Enum.IsDefined%2A?displayProperty=nameWithType> method to determine whether a specified value is a member of an enumeration.  
  
<a name="members"></a>   
### Type members in general  
 The Common Language Specification requires all fields and methods to be accessed as members of a particular class. Therefore, global static fields and methods (that is, static fields or methods that are defined apart from a type) are not CLS-compliant. If you try to include a global field or method in your source code, both the C# and Visual Basic compilers generate a compiler error.  
  
 The Common Language Specification supports only the standard managed calling convention. It doesn't support unmanaged calling conventions and methods with variable argument lists marked with the `varargs` keyword. For variable argument lists that are compatible with the standard managed calling convention, use the <xref:System.ParamArrayAttribute> attribute or the individual language's implementation, such as the `params` keyword in C# and the `ParamArray` keyword in Visual Basic.  
  
<a name="MemberAccess"></a>   
### Member accessibility  
 Overriding an inherited member cannot change the accessibility of that member. For example, a public method in a base class cannot be overridden by a private method in a derived class. There is one exception: a `protected internal` (in C#) or `Protected Friend` (in Visual Basic) member in one assembly that is overridden by a type in a different assembly. In that case, the accessibility of the override is `Protected`.  
  
 The following example illustrates the error that is generated when the <xref:System.CLSCompliantAttribute> attribute is set to `true`, and `Person`, which is a class derived from `Animal`, tries to change the accessibility of the `Species` property from public to private. The example compiles successfully if its accessibility is changed to public.  
  
 [!code-csharp[Conceptual.CLSCompliant#28](../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.clscompliant/cs/accessibility1.cs#28)]
 [!code-vb[Conceptual.CLSCompliant#28](../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.clscompliant/vb/accessibility1.vb#28)]  
  
 Types in the signature of a member must be accessible whenever that member is accessible. For example, this means  that a public member cannot include a parameter whose type is private, protected, or internal. The following example illustrates the compiler error that results when a `StringWrapper` class constructor exposes an internal `StringOperationType` enumeration value that determines how a string value should be wrapped.  
  
 [!code-csharp[Conceptual.CLSCompliant#27](../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.clscompliant/cs/accessibility3.cs#27)]
 [!code-vb[Conceptual.CLSCompliant#27](../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.clscompliant/vb/accessibility3.vb#27)]  
  
<a name="Generics"></a>   
### Generic types and members  
 Nested types always have at least as many generic parameters as their enclosing type. These correspond by position to the generic parameters in the enclosing type. The generic type can also include new generic parameters.  
  
 The relationship between the generic type parameters of a containing type and its nested types may be hidden by the syntax of individual languages. In the following example, a generic type `Outer<T>` contains two nested classes, `Inner1A` and `Inner1B<U>`. The calls to the `ToString` method, which each class inherits from <xref:System.Object.ToString%2A?displayProperty=nameWithType>,  show that each nested class includes the type parameters of its containing class.  
  
 [!code-csharp[Conceptual.CLSCompliant#29](../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.clscompliant/cs/nestedgenerics2.cs#29)]
 [!code-vb[Conceptual.CLSCompliant#29](../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.clscompliant/vb/nestedgenerics2.vb#29)]  
  
 Generic type names are encoded in the form *name\`n*, where *name* is the type name, \` is a character literal, and *n* is the number of parameters declared on the type, or, for nested generic types, the number of newly introduced type parameters. This encoding of generic type names is primarily of interest to developers who use reflection to access CLS-complaint generic types in a library.  
  
 If constraints are applied to a generic type, any types used as constraints must also be CLS-compliant. The following example defines a class named `BaseClass` that is not CLS-compliant and a generic class named `BaseCollection` whose type parameter must derive from `BaseClass`. But because `BaseClass` is not CLS-compliant, the compiler emits a warning.  
  
 [!code-csharp[Conceptual.CLSCompliant#34](../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.clscompliant/cs/generics5.cs#34)]
 [!code-vb[Conceptual.CLSCompliant#34](../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.clscompliant/vb/generics5.vb#34)]  
  
 If a generic type is derived from a generic base type, it must redeclare any constraints so that it can guarantee that constraints on the base type are also satisfied. The following example defines a `Number<T>` that can represent any numeric type. It also defines a `FloatingPoint<T>` class that represents a floating point value. However, the source code fails to compile, because it does not apply the constraint on `Number<T>` (that T must be a value type) to `FloatingPoint<T>`.  
  
 [!code-csharp[Conceptual.CLSCompliant#30](../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.clscompliant/cs/generics2a.cs#30)]
 [!code-vb[Conceptual.CLSCompliant#30](../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.clscompliant/vb/generics2a.vb#30)]  
  
 The example compiles successfully if the constraint is added to the `FloatingPoint<T>` class.  
  
 [!code-csharp[Conceptual.CLSCompliant#31](../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.clscompliant/cs/generics2.cs#31)]
 [!code-vb[Conceptual.CLSCompliant#31](../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.clscompliant/vb/generics2.vb#31)]  
  
 The Common Language Specification imposes a conservative per-instantiation model for nested types and protected members. Open generic types cannot expose fields or members with signatures that contain a specific instantiation of a nested, protected generic type. Non-generic types that extend a specific instantiation of a generic base class or interface cannot expose fields or members with signatures that contain a different instantiation of a nested, protected generic type.  
  
 The following example defines a generic type, `C1<T>` (or `C1(Of T)` in Visual Basic), and a protected class, `C1<T>.N` (or `C1(Of T).N` in Visual Basic). `C1<T>` has two methods, `M1` and `M2`. However, `M1` is not CLS-compliant because it tries to return a `C1<int>.N` (or `C1(Of Integer).N`) object from C1\<T> (or `C1(Of T)`). A second class, `C2`, is derived from `C1<long>` (or `C1(Of Long)`). It has two methods, `M3` and `M4`. `M3` is not CLS-compliant because it tries to return a `C1<int>.N` (or `C1(Of Integer).N`) object from a subclass of `C1<long>`. Note that language compilers can be even more restrictive. In this example, Visual Basic displays an error when it tries to compile `M4`.  
  
 [!code-csharp[Conceptual.CLSCompliant#32](../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.clscompliant/cs/generics4.cs#32)]
 [!code-vb[Conceptual.CLSCompliant#32](../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.clscompliant/vb/generics4.vb#32)]  
  
<a name="ctors"></a>   
### Constructors  
 Constructors in CLS-compliant classes and structures must follow these rules:  
  
-   A constructor of a derived class must call the instance constructor of its base class before it accesses inherited instance data. This requirement is due to the fact that base class constructors are not inherited by their derived classes. This rule does not apply to structures, which do not support direct inheritance.  
  
     Typically, compilers enforce this rule independently of CLS compliance, as the following example shows. It creates a `Doctor` class that is derived from a `Person` class, but the `Doctor` class fails to call the `Person` class constructor to initialize inherited instance fields.  
  
     [!code-csharp[Conceptual.CLSCompliant#11](../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.clscompliant/cs/ctor1.cs#11)]
     [!code-vb[Conceptual.CLSCompliant#11](../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.clscompliant/vb/ctor1.vb#11)]  
  
-   An object constructor cannot be called except to create an object. In addition, an object cannot be initialized twice. For example, this means that <xref:System.Object.MemberwiseClone%2A?displayProperty=nameWithType> and deserialization methods such as <xref:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter.Deserialize%2A?displayProperty=nameWithType> must not call constructors.  
  
<a name="properties"></a>   
### Properties  
 Properties in CLS-compliant types must follow these rules:  
  
-   A property must have a setter, a getter, or both. In an assembly, these are implemented as special methods, which means that they will appear as separate methods (the getter is named `get_`*propertyname* and the setter is `set_`*propertyname*) marked as `SpecialName` in the assembly's metadata. The C# and Visual Basic compilers enforce this rule automatically without the need to apply the <xref:System.CLSCompliantAttribute> attribute.  
  
-   A property's type is the return type of the property getter and the last argument of the setter. These types must be CLS compliant, and arguments cannot be assigned to the property by reference (that is, they cannot be managed pointers).  
  
-   If a property has both a getter and a setter, they must both be virtual, both static, or both instance. The C# and Visual Basic compilers automatically enforce this rule through their property definition syntax.  
  
<a name="events"></a>   
### Events  
 An event is defined by its name and its type. The event type is a delegate that is used to indicate the event. For example, the <xref:System.AppDomain.AssemblyResolve?displayProperty=nameWithType> event is of type <xref:System.ResolveEventHandler>. In addition to the event itself, three methods with names based on the event name provide the event's implementation and are marked as `SpecialName` in the assembly's metadata:  
  
-   A method for adding an event handler, named `add_`*EventName*. For example, the event subscription method for the <xref:System.AppDomain.AssemblyResolve?displayProperty=nameWithType> event is named `add_AssemblyResolve`.  
  
-   A method for removing an event handler, named `remove_`*EventName*. For example, the removal method for the <xref:System.AppDomain.AssemblyResolve?displayProperty=nameWithType> event is named `remove_AssemblyResolve`.  
  
-   A method for indicating that the event has occurred, named `raise_`*EventName*.  
  
> [!NOTE]
>  Most of the Common Language Specification's rules regarding events are implemented by language compilers and are transparent to component developers.  
  
 The methods for adding, removing, and raising the event must have the same accessibility. They must also all be static, instance, or virtual. The methods for adding and removing an event have one parameter whose type is the event delegate type. The add and remove methods must both be present or both be absent.  
  
 The following example defines a CLS-compliant class named `Temperature` that raises a `TemperatureChanged` event if the change in temperature between two readings equals or exceeds a threshold value. The `Temperature` class explicitly defines a `raise_TemperatureChanged` method so that it can selectively execute event handlers.  
  
 [!code-csharp[Conceptual.CLSCompliant#20](../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.clscompliant/cs/event1.cs#20)]
 [!code-vb[Conceptual.CLSCompliant#20](../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.clscompliant/vb/event1.vb#20)]  
  
<a name="overloads"></a>   
### Overloads  
 The Common Language Specification imposes the following requirements on overloaded members:  
  
-   Members can be overloaded based on the number of parameters and the type of any parameter. Calling convention, return type, custom modifiers applied to the method or its parameter, and whether parameters are passed by value or by reference are not considered when differentiating between overloads. For an example, see the code for the requirement that names must be unique within a scope in the [Naming conventions](#naming) section.  
  
-   Only properties and methods can be overloaded. Fields and events cannot be overloaded.  
  
-   Generic methods can be overloaded based on the number of their generic parameters.  
  
> [!NOTE]
>  The `op_Explicit` and `op_Implicit` operators are exceptions to the rule that return value is not considered part of a method signature for overload resolution. These two operators can be overloaded based on both their parameters and their return value.  
  
<a name="exceptions"></a>   
### Exceptions  
 Exception objects must derive from <xref:System.Exception?displayProperty=nameWithType> or from another type derived from <xref:System.Exception?displayProperty=nameWithType>. The following example illustrates the compiler error that results when a custom class named `ErrorClass` is used for exception handling.  
  
 [!code-csharp[Conceptual.CLSCompliant#13](../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.clscompliant/cs/exceptions1.cs#13)]
 [!code-vb[Conceptual.CLSCompliant#13](../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.clscompliant/vb/exceptions1.vb#13)]  
  
 To correct this error, the `ErrorClass` class must inherit from <xref:System.Exception?displayProperty=nameWithType>. In addition, the `Message` property must be overridden. The following example corrects these errors to define an `ErrorClass` class that is CLS-compliant.  
  
 [!code-csharp[Conceptual.CLSCompliant#14](../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.clscompliant/cs/exceptions2.cs#14)]
 [!code-vb[Conceptual.CLSCompliant#14](../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.clscompliant/vb/exceptions2.vb#14)]  
  
<a name="attributes"></a>   
### Attributes  
 In.NET Framework assemblies, custom attributes provide an extensible mechanism for storing custom attributes and retrieving metadata about programming objects, such as assemblies, types, members, and method parameters. Custom attributes must derive from <xref:System.Attribute?displayProperty=nameWithType> or from a type derived from <xref:System.Attribute?displayProperty=nameWithType>.  
  
 The following example violates this rule. It defines a `NumericAttribute` class that does not derive from <xref:System.Attribute?displayProperty=nameWithType>. Note that a compiler error results only when the non-CLS-compliant attribute is applied, not when the class is defined.  
  
 [!code-csharp[Conceptual.CLSCompliant#18](../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.clscompliant/cs/attribute1.cs#18)]
 [!code-vb[Conceptual.CLSCompliant#18](../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.clscompliant/vb/attribute1.vb#18)]  
  
 The constructor or the properties of a CLS-compliant attribute can expose only the following types:  
  
-   <xref:System.Boolean>  
  
-   <xref:System.Byte>  
  
-   <xref:System.Char>  
  
-   <xref:System.Double>  
  
-   <xref:System.Int16>  
  
-   <xref:System.Int32>  
  
-   <xref:System.Int64>  
  
-   <xref:System.Single>  
  
-   <xref:System.String>  
  
-   <xref:System.Type>  
  
-   Any enumeration type whose underlying type is <xref:System.Byte>, <xref:System.Int16>, <xref:System.Int32>, or <xref:System.Int64>.  
  
 The following example defines a `DescriptionAttribute` class that derives from <xref:System.Attribute>. The class constructor has a parameter of type `Descriptor`, so the class is not CLS-compliant. Note that the C# compiler emits a warning but compiles successfully, whereas the Visual Basic compiler emits neither a warning nor an error.  
  
 [!code-csharp[Conceptual.CLSCompliant#33](../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.clscompliant/cs/attribute2.cs#33)]
 [!code-vb[Conceptual.CLSCompliant#33](../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.clscompliant/vb/attribute2.vb#33)]  
  
<a name="CLSAttribute"></a>   
## The CLSCompliantAttribute attribute  
 The <xref:System.CLSCompliantAttribute> attribute is used to indicate whether a program element complies with the Common Language Specification. The <xref:System.CLSCompliantAttribute.%23ctor%28System.Boolean%29?displayProperty=nameWithType> constructor includes a single required parameter, `isCompliant`, that indicates whether the program element is CLS-compliant.  
  
 At compile time, the compiler detects non-compliant elements that are presumed to be CLS-compliant and emits a warning. The compiler does not emit warnings for types or members that are explicitly declared to be non-compliant.  
  
 Component developers can use the <xref:System.CLSCompliantAttribute> attribute in two ways:  
  
-   To define the parts of the public interface exposed by a component that are CLS-compliant and the parts that are not CLS-compliant. When the attribute is used to mark particular program elements as CLS-compliant, its use guarantees that those elements are accessible from all languages and tools that target the .NET Framework.  
  
-   To ensure that the component library's public interface exposes only program elements that are CLS-compliant. If elements are not CLS-compliant, compilers will generally issue a warning.  
  
> [!WARNING]
>  In some cases, language compilers enforce CLS-compliant rules regardless of whether the <xref:System.CLSCompliantAttribute> attribute is used. For example, defining a static member in an interface violates a CLS rule. In this regard, if you define a `static` (in C#) or `Shared` (in Visual Basic) member in an interface, both the C# and Visual Basic compilers display an error message and fail to compile the app.  
  
 The <xref:System.CLSCompliantAttribute> attribute is marked with an <xref:System.AttributeUsageAttribute> attribute that has a value of <xref:System.AttributeTargets.All?displayProperty=nameWithType>. This value allows you to apply the <xref:System.CLSCompliantAttribute> attribute to any program element, including assemblies, modules, types (classes, structures, enumerations, interfaces, and delegates), type members (constructors, methods, properties, fields, and events), parameters, generic parameters, and return values. However, in practice, you should apply the attribute only to assemblies, types, and type members. Otherwise, compilers ignore the attribute and continue to generate compiler warnings whenever they encounter a non-compliant parameter, generic parameter, or return value in your library's public interface.  
  
 The value of the <xref:System.CLSCompliantAttribute> attribute is inherited by contained program elements. For example, if an assembly is marked as CLS-compliant, its types are also CLS-compliant. If a type is marked as CLS-compliant, its nested types and members are also CLS-compliant.  
  
 You can explicitly override the inherited compliance by applying the <xref:System.CLSCompliantAttribute> attribute to a contained program element. For example, you can use the <xref:System.CLSCompliantAttribute> attribute with an `isCompliant` value of `false` to define a non-compliant type in a compliant assembly, and you can use the attribute with an `isCompliant` value of `true` to define a compliant type in a non-compliant assembly. You can also define non-compliant members in a compliant type. However, a non-compliant type cannot have compliant members, so you cannot use the attribute with an `isCompliant` value of `true` to override inheritance from a non-compliant type.  
  
 When you are developing components, you should always use the <xref:System.CLSCompliantAttribute> attribute to indicate whether your assembly, its types, and its members are CLS-compliant.  
  
 To create CLS-compliant components:  
  
1.  Use the <xref:System.CLSCompliantAttribute> to mark you assembly as CLS-compliant.  
  
2.  Mark any publicly exposed types in the assembly that are not CLS-compliant as non-compliant.  
  
3.  Mark any publicly exposed members in CLS-compliant types as non-compliant.  
  
4.  Provide a CLS-compliant alternative for non-CLS-compliant members.  
  
 If you've successfully marked all your non-compliant types and members, your compiler should not emit any non-compliance warnings. However, you should indicate which members are not CLS-compliant and list their CLS-compliant alternatives in your product documentation.  
  
 The following example uses the <xref:System.CLSCompliantAttribute> attribute to define a CLS-compliant assembly and a type, `CharacterUtilities`, that has two non-CLS-compliant members. Because both members are tagged with the `CLSCompliant(false)` attribute, the compiler produces no warnings. The class also provides a CLS-compliant alternative for both methods. Ordinarily, we would just add two overloads to the `ToUTF16` method to provide CLS-compliant alternatives. However, because methods cannot be overloaded based on return value, the names of the CLS-compliant methods are different from the names of the non-compliant methods.  
  
 [!code-csharp[Conceptual.CLSCompliant#35](../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.clscompliant/cs/indicator3.cs#35)]
 [!code-vb[Conceptual.CLSCompliant#35](../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.clscompliant/vb/indicator3.vb#35)]  
  
 If you are developing an app rather than a library (that is, if you aren't exposing types or members that can be consumed by other app developers), the CLS compliance of the program elements that your app consumes are of interest only if your language does not support them. In that case, your language compiler will generate an error when you try to use a non-CLS-compliant element.  
  
<a name="CrossLang"></a>   
## Cross-Language Interoperability  
 Language independence has a number of possible meanings. One meaning, which is discussed in the article [Language Independence and Language-Independent Components](../../docs/standard/language-independence-and-language-independent-components.md), involves seamlessly consuming types written in one language from an app written in another language. A second meaning, which is the focus of this article, involves combining code written in multiple languages into a single .NET Framework assembly.  
  
 The following example illustrates cross-language interoperability by creating a class library named Utilities.dll that includes two classes, `NumericLib` and `StringLib`. The `NumericLib` class is written in C#, and the `StringLib` class is written in Visual Basic. Here's the source code for StringUtil.vb, which includes a single member, `ToTitleCase`, in its `StringLib` class.  
  
 [!code-vb[Conceptual.CrossLanguage#1](../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.crosslanguage/vb/stringutil.vb#1)]  
  
 Here's the source code for NumberUtil.cs, which defines a `NumericLib` class that has two members, `IsEven` and `NearZero`.  
  
 [!code-csharp[Conceptual.CrossLanguage#2](../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.crosslanguage/cs/numberutil.cs#2)]  
  
 To package the two classes in a single assembly, you must compile them into modules. To compile the Visual Basic source code file into a module, use this command:  
  
```  
vbc /t:module StringUtil.vb   
```  
  
 For more information about the command-line syntax of the Visual Basic compiler, see [Building from the Command Line](~/docs/visual-basic/reference/command-line-compiler/building-from-the-command-line.md).  
  
 To compile the C# source code file into a module, use this command:  
  
```  
csc /t:module NumberUtil.cs  
```  
  
 For more information about the command-line syntax of the C# compiler, see [Command-line Building With csc.exe](~/docs/csharp/language-reference/compiler-options/command-line-building-with-csc-exe.md).  
  
 You then use the [Link tool (Link.exe)](https://msdn.microsoft.com/library/c1d51b8a-bd23-416d-81e4-900e02b2c129) to compile the two modules into an assembly:  
  
```  
link numberutil.netmodule stringutil.netmodule /out:UtilityLib.dll /dll   
```  
  
 The following example then calls the `NumericLib.NearZero` and `StringLib.ToTitleCase` methods. Note that both the Visual Basic code and the C# code are able to access the methods in both classes.  
  
 [!code-csharp[Conceptual.CrossLanguage#3](../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.crosslanguage/cs/useutilities1.cs#3)]
 [!code-vb[Conceptual.CrossLanguage#3](../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.crosslanguage/vb/useutilities1.vb#3)]  
  
 To compile the Visual Basic code, use this command:  
  
```  
vbc example.vb /r:UtilityLib.dll  
```  
  
 To compile with C#, change the name of the compiler from **vbc** to **csc**, and change the file extension from .vb to .cs:  
  
```  
csc example.cs /r:UtilityLib.dll  
```  
  
## See Also  
 <xref:System.CLSCompliantAttribute>
