# Language Independence and Language-Independent Components

The .NET Core platform is language independent. This means that, as a developer, you can develop in one of the many languages that target the .NET Core platform, such as C#, F#, and Visual Basic. You can access the types and members of class libraries developed for the .NET Core platform without having to know the language in which they were originally written and without having to follow any of the original language's conventions. If you are a component developer, your component can be accessed by any .NET Core app regardless of its language.

> **Note**
>
> This first part of this article discusses creating language-independent components - that is, components that can be consumed by apps that are written in any language. You can also create a single component or app from source code written in multiple languages; see [Cross-Language Interoperability](#cross-language-interoperability) in the second part of this article. 

To fully interact with other objects written in any language, objects must expose to callers only those features that are common to all languages. This common set of features is defined by the Common Language Specification (CLS), which is a set of rules that apply to generated assemblies. The Common Language Specification is defined in Partition I, Clauses 7 through 11 of the [ECMA-335 Standard: Common Language Infrastructure](http://www.ecma-international.org/publications/standards/Ecma-335.htm). 

If your component conforms to the Common Language Specification, it is guaranteed to be CLS-compliant and can be accessed from code in assemblies written in any programming language that supports the CLS. You can determine whether your component conforms to the Common Language Specification at compile time by applying the [CLSCompliantAttribute](http://dotnet.github.io/api/System.CLSCompliantAttribute.html) attribute to your source code. For more information, see The [CLSCompliantAttribute attribute](#the-clscompliantattribute-attribute).

In this article:

* [CLS compliance rules](#cls-compliance-rules)

    * [Types and type member signatures](#Types-and-type-member-signatures)

    * [Naming conventions](#naming-conventions)
    
    * [Type conversion](#type-conversion)
    
    * [Arrays](#arrays)
    
    * [Interfaces](#interfaces)
    
    * [Enumerations](#enumerations)
    
    * [Type members in general](#type-members-in-general)
    
    * [Member accessibility](#member-accessibility)
    
    * [Generic types and members](#generic-types-and-members)
    
    * [Constructors](#constructors)
    
    * [Properties](#properties)
    
    * [Events](#events)
    
    * [Overloads](#overloads)
    
    * [Exceptions](#exceptions)
    
    * [Attributes](#attributes)
    
* [CLSCompliantAttribute attribute](#the-clscompliantattribute-attribute)

## CLS compliance rules

This section discusses the rules for creating a CLS-compliant component. For a complete list of rules, see Partition I, Clause 11 of the [ECMA-335 Standard: Common Language Infrastructure](http://www.ecma-international.org/publications/standards/Ecma-335.htm).

> **Note**
>
> The Common Language Specification discusses each rule for CLS compliance as it applies to consumers (developers who are programmatically accessing a component that is CLS-compliant), frameworks (developers who are using a language compiler to create CLS-compliant libraries), and extenders (developers who are creating a tool such as a language compiler or a code parser that creates CLS-compliant components). This article focuses on the rules as they apply to frameworks. Note, though, that some of the rules that apply to extenders may also apply to assemblies that are created using [Reflection.Emit](http://dotnet.github.io/api/System.Reflection.Emit.html). 

To design a component that is language independent, you only need to apply the rules for CLS compliance to your component's public interface. Your private implementation does not have to conform to the specification. 

> **Important**
>
> The rules for CLS compliance apply only to a component's public interface, not to its private implementation. 

For example, unsigned integers other than [Byte](http://dotnet.github.io/api/System.Byte.html) are not CLS-compliant. Because the `Person` class in the following example exposes an `Age` property of type [UInt16](http://dotnet.github.io/api/System.UInt16.html), the following code displays a compiler warning.

```csharp
using System;

[assembly: CLSCompliant(true)]

public class Person
{
   private UInt16 personAge = 0;

   public UInt16 Age 
   { get { return personAge; } }
}
// The attempt to compile the example displays the following compiler warning:
//    Public1.cs(10,18): warning CS3003: Type of 'Person.Age' is not CLS-compliant
```

You can make the Person class CLS-compliant by changing the type of `Age` property from **UInt16** to [Int16](http://dotnet.github.io/api/System.Int16.html), which is a CLS-compliant, 16-bit signed integer. You do not have to change the type of the private `personAge` field. 

```csharp
using System;

[assembly: CLSCompliant(true)]

public class Person
{
   private Int16 personAge = 0;

   public Int16 Age 
   { get { return personAge; } }
}
```

A library's public interface consists of the following:

* Definitions of public classes.

* Definitions of the public members of public classes, and definitions of members accessible to derived classes (that is, protected members). 

* Parameters and return types of public methods of public classes, and parameters and return types of methods accessible to derived classes. 

The rules for CLS compliance are listed in the following table. The text of the rules is taken verbatim from the [ECMA-335 Standard: Common Language Infrastructure](http://www.ecma-international.org/publications/standards/Ecma-335.htm), which is Copyright 2012 by Ecma International. More detailed information about these rules is found in the following sections. 

Category | See | Rule | Rule Number
-------- | --- | ---- | -----------
Accessibility | [Member accessibility](#member-accessibility) | Accessibility shall not be changed when overriding inherited methods, except when overriding a method inherited from a different assembly with accessibility **family-or-assembly**. In this case, the override shall have accessibility **family**. | 10
Accessibility | [Member accessibility](#member-accessibility) | The visibility and accessibility of types and members shall be such that types in the signature of any member shall be visible and accessible whenever the member itself is visible and accessible. For example, a public method that is visible outside its assembly shall not have an argument whose type is visible only within the assembly. The visibility and accessibility of types composing an instantiated generic type used in the signature of any member shall be visible and accessible whenever the member itself is visible and accessible. For example, an instantiated generic type present in the signature of a member that is visible outside its assembly shall not have a generic argument whose type is visible only within the assembly. | 12
Arrays | [Arrays](#arrays) | Arrays shall have elements with a CLS-compliant type, and all dimensions of the array shall have lower bounds of zero. Only the fact that an item is an array and the element type of the array shall be required to distinguish between overloads. When overloading is based on two or more array types the element types shall be named types. | 16
Attributes | [Attributes](#attributes) | Attributes shall be of type [System.Attribute](http://dotnet.github.io/api/System.Attribute.html), or a type inheriting from it. | 41
Attributes | [Attributes](#attributes) | The CLS only allows a subset of the encodings of custom attributes. The only types that shall appear in these encodings are (see Partition IV): [System.Type](http://dotnet.github.io/api/System.Type.html), [System.String](http://dotnet.github.io/api/System.String.html), [System.Char](http://dotnet.github.io/api/System.Char.html), [System.Boolean](http://dotnet.github.io/api/System.Boolean.html), [System.Byte](http://dotnet.github.io/api/System.Byte.html), [System.Int16](http://dotnet.github.io/api/System.Int16.html), [System.Int32](http://dotnet.github.io/api/System.Int32.html), [System.Int64](http://dotnet.github.io/api/System.Int64.html), [System.Single](http://dotnet.github.io/api/System.Single.html), [System.Double](http://dotnet.github.io/api/System.Double.html), and any enumeration type based on a CLS-compliant base integer type. | 34
Attributes | [Attributes](#attributes) | The CLS does not allow publicly visible required modifiers (**modreq**, see Partition II), but does allow optional modifiers (**modopt**, see Partition II) it does not understand. | 35
Constructors | [Constructors](#constructors) | An object constructor shall call some instance constructor of its base class before any access occurs to inherited instance data. (This does not apply to value types, which need not have constructors.)  | 21
Constructors | [Constructors](#constructors) | An object constructor shall not be called except as part of the creation of an object, and an object shall not be initialized twice. | 22
Enumerations | [Enumerations](#enumerations) | The underlying type of an enum shall be a built-in CLS integer type, the name of the field shall be "value__", and that field shall be marked **RTSpecialName**. |  7
Enumerations | [Enumerations](#enumerations) | There are two distinct kinds of enums, indicated by the presence or absence of the [System.FlagsAttribute](http://dotnet.github.io/api/System.FlagsAttribute.html) (see Partition IV Library) custom attribute. One represents named integer values; the other represents named bit flags that can be combined to generate an unnamed value. The value of an **enum** is not limited to the specified values. |  8
Enumerations | [Enumerations](#enumerations) | Literal static fields of an enum shall have the type of the enum itself. |  9
Events | [Events](#events) | The methods that implement an event shall be marked **SpecialName** in themetadata. |29
Events | [Events](#events) | The accessibility of an event and of its accessors shall be identical. |30
Events | [Events](#events) | The **add** and **remove** methods for an event shall both either be present or absent. |31
Events | [Events](#events) | The **add**and **remove** methods for an event shall each take one parameter whose type defines the type of the event and that shall be derived from [System.Delegate](http://dotnet.github.io/api/System.Delegate.html). |32
Events | [Events](#events) |  |33
Exceptions | [Exceptions](#exceptions) | Objects that are thrown shall be of type [System.Exception](http://dotnet.github.io/api/System.Exception.html) or a type inheriting from it. Nonetheless, CLS-compliant methods are not required to block the propagation of other types of exceptions. | 40
General | [CLS compliance rules](#cls-compliance-rules) | CLS rules apply only to those parts of a type that are accessible or visible outsideof the defining assembly. | 1
General | [CLS compliance rules](#cls-compliance-rules) | Members of non-CLS compliant types shall not be marked CLS-compliant. | 2
Generics | [Generic types and members](#generic-types-and-members) | Nested types shall have at least as many generic parameters as the enclosing type. Generic parameters in a nested type correspond by position to the generic parameters in its enclosing type.  | 42
Generics | [Generic types and members](#generic-types-and-members) | The name of a generic type shall encode the number of type parameters declared on the non-nested type, or newly introduced to the type if nested, according to the rules defined above. | 43
Generics | [Generic types and members](#generic-types-and-members) | A generic type shall redeclare sufficient constraints to guarantee that any constraints on the base type, or interfaces would be satisfied by the generic type constraints. | 44
Generics | [Generic types and members](#generic-types-and-members) | Types used as constraints on generic parameters shall themselves be CLS-compliant. | 45
Generics | [Generic types and members](#generic-types-and-members) | The visibility and accessibility of members (including nested types) in an instantiated generic type shall be considered to be scoped to the specific instantiation rather than the generic type declaration as a whole. Assuming this, the visibility and accessibility rules of CLS rule 12 still apply. | 46
Generics | [Generic types and members](#generic-types-and-members) | For each abstract or virtual generic method, there shall be a default concrete (nonabstract) implementation | 47
Interfaces | [Interfaces](#interfaces) | CLS-compliant interfaces shall not require the definition of non-CLS compliantmethods in order to implement them. | 18
Interfaces | [Interfaces](#interfaces) | CLS-compliant interfaces shall not define static methods, nor shall they define fields. | 19
Members | [Type members in general](#type-members-in-general) | Global static fields and methods are not CLS-compliant. | 36
Members | -- | The value of a literal static is specified through the use of field initialization metadata. A CLS-compliant literal must have a value specified in field initialization metadata that is of exactly the same type as the literal (or of the underlying type, if that literal is an **enum**). | 13
Members | [Type members in general](#type-members-in-general) | The vararg constraint is not part of the CLS, and the only calling convention supported by the CLS is the standard managed calling convention. | 15
Naming conventions | [Naming conventions](#naming-conventions) | Assemblies shall follow Annex 7 of Technical Report 15 of the Unicode Standard3.0 governing the set of characters permitted to start and be included in identifiers, available online at [Unicode Normalization Forms](http://www.unicode.org/unicode/reports/tr15/tr15-18.html). Identifiers shall be in the canonical format defined by Unicode Normalization Form C. For CLS purposes, two identifiersare the same if their lowercase mappings (as specified by the Unicode locale-insensitive, one-to-one lowercase mappings) are the same. That is, for two identifiers to be considered different under the CLS they shall differ in more than simply their case. However, in order to override an inherited definition the CLI requires the precise encoding of the original declaration be used. | 4
Overloading | [Naming conventions](#naming-conventions) | All names introduced in a CLS-compliant scope shall be distinct independent of kind, except where the names are identical and resolved via overloading. That is, while the CTS allows a single type to use the same name for a method and a field, the CLS does not. | 5
Overloading | [Naming conventions](#naming-conventions) | Fields and nested types shall be distinct by identifier comparison alone, eventhough the CTS allows distinct signatures to be distinguished. Methods, properties, and events that have the same name (by identifier comparison) shall differ by more than just the return type,except as specified in CLS Rule 39 | 6
Overloading | [Overloads](#overloads) | Only properties and methods can be overloaded. | 37
Overloading | [Overloads](#overloads) |Properties and methods can be overloaded based only on the number and types of their parameters, except the conversion operators named **op_Implicit** and **op_Explicit**, which can also be overloaded based on their return type. | 38
Overloading | -- | If two or more CLS-compliant methods declared in a type have the same nameand, for a specific set of type instantiations, they have the same parameter and return types, then all these methods shall be semantically equivalent at those type instantiations. | 48
Properties | [Properties](#properties) | The methods that implement the getter and setter methods of a property shall be marked **SpecialName** in the metadata. | 24
Properties | [Properties](#properties) | A property’s accessors shall all be static, all be virtual, or all be instance. | 26
Properties | [Properties](#properties) | The type of a property shall be the return type of the getter and the type of the last argument of the setter. The types of the parameters of the property shall be the types of the parameters to the getter and the types of all but the final parameter of the setter. All of these types shall be CLS-compliant, and shall not be managed pointers (i.e., shall not be passed by reference). | 27
Properties | [Properties](#properties) | Properties shall adhere to a specific naming pattern. The **SpecialName** attribute referred to in CLS rule 24 shall be ignored in appropriate name comparisons and shall adhere to identifier rules. A property shall have a getter method, a setter method, or both. | 28
Type conversion | [Type conversion](#type-conversion) | If either op_Implicit or op_Explicit is provided, an alternate means of providing the coercion shall be provided. | 39
Types | [Types and type member signatures](#Types-and-type-member-signatures) | Boxed value types are not CLS-compliant. | 3
Types | [Types and type member signatures](#Types-and-type-member-signatures) | All types appearing in a signature shall be CLS-compliant. All types composing an instantiated generic type shall be CLS-compliant. | 11
Types | [Types and type member signatures](#Types-and-type-member-signatures) | Typed references are not CLS-compliant. | 14
Types | [Types and type member signatures](#Types-and-type-member-signatures) | Unmanaged pointer types are not CLS-compliant. | 17
Types | [Types and type member signatures](#Types-and-type-member-signatures) | CLS-compliant classes, value types, and interfaces shall not require the implementation of non-CLS-compliant members | 20
Types | [Types and type member signatures](#Types-and-type-member-signatures) | [System.Object](http://dotnet.github.io/api/System.Object.html) is CLS-compliant. Any other CLS-compliant class shall inherit from a CLS-compliant class. | 23

### Types and type member signatures

The [System.Object](http://dotnet.github.io/api/System.Object.html) type is CLS-compliant and is the base type of all object types in the .NET Framework type system. Inheritance in the .NET Framework is either implicit (for example, the [String](http://dotnet.github.io/api/System.String.html) class implicitly inherits from the **Object** class) or explicit (for example, the [CultureNotFoundException](http://dotnet.github.io/api/System.Globalization.CultureNotFoundException.html) class explicitly inherits from the [ArgumentException](http://dotnet.github.io/api/System.ArgumentException.html) class, which explicitly inherits from the [Exception](http://dotnet.github.io/api/System.Exception.html) class. For a derived type to be CLS compliant, its base type must also be CLS-compliant. 

The following example shows a derived type whose base type is not CLS-compliant. It defines a base `Counter` class that uses an unsigned 32-bit integer as a counter. Because the class provides counter functionality by wrapping an unsigned integer, the class is marked as non-CLS-compliant. As a result, a derived class, `NonZeroCounter`, is also not CLS-compliant. 

```csharp
using System;

[assembly: CLSCompliant(true)]

[CLSCompliant(false)] 
public class Counter
{
   UInt32 ctr;

   public Counter()
   {
      ctr = 0;
   }

   protected Counter(UInt32 ctr)
   {
      this.ctr = ctr;
   }

   public override string ToString()
   {
      return String.Format("{0}). ", ctr);
   }

   public UInt32 Value
   {
      get { return ctr; }
   }

   public void Increment() 
   {
      ctr += (uint) 1;
   }
}

public class NonZeroCounter : Counter
{
   public NonZeroCounter(int startIndex) : this((uint) startIndex)
   {
   }

   private NonZeroCounter(UInt32 startIndex) : base(startIndex)
   {
   }
}
// Compilation produces a compiler warning like the following:
//    Type3.cs(37,14): warning CS3009: 'NonZeroCounter': base type 'Counter' is not
//            CLS-compliant
//    Type3.cs(7,14): (Location of symbol related to previous warning)
```

All types that appear in member signatures, including a method's return type or a property type, must be CLS-compliant. In addition, for generic types: 

* All types that compose an instantiated generic type must be CLS-compliant.

* All types used as constraints on generic parameters must be CLS-compliant. 

The .NET [common type system](common-type-system.md) includes a number of built-in types that are supported directly by the common language runtime and are specially encoded in an assembly's metadata. Of these intrinsic types, the types listed in the following table are CLS-compliant. 


CLS-compliant type | Description
------------------ | -----------
[Byte](http://dotnet.github.io/api/System.Byte.html) | 8-bit unsigned integer 
[Int16](http://dotnet.github.io/api/System.Int16.html) | 16-bit signed integer 
[Int32](http://dotnet.github.io/api/System.Int32.html) | 32-bit signed integer 
[Int64](http://dotnet.github.io/api/System.Int64.html) | 64-bit signed integer
[Single](http://dotnet.github.io/api/System.Single.html) | Single-precision floating-point value
[Double](http://dotnet.github.io/api/System.Double.html) | Double-precision floating-point value
[Boolean](http://dotnet.github.io/api/System.Boolean.html) | true or false value type 
[Char](http://dotnet.github.io/api/System.Char.html) | UTF-16 encoded code unit
[Decimal](http://dotnet.github.io/api/System.Decimal.html) | Non-floating-point decimal number
[IntPtr](http://dotnet.github.io/api/System.IntPtr.html) | Pointer or handle of a platform-defined size
[String](http://dotnet.github.io/api/System.String.html) | Collection of zero, one, or more Char objects 
 
The intrinsic types listed in the following table are not CLS-Compliant.


Non-compliant type | Description | CLS-compliant alternative
------------------ | ----------- | -------------------------
[SByte](http://dotnet.github.io/api/System.SByte.html) | 8-bit signed integer data type | [Int16](http://dotnet.github.io/api/System.Int16.html)
**TypedReference** | Pointer to an object and its runtime type | None
[UInt16](http://dotnet.github.io/api/System.UInt16.html) | 16-bit unsigned integer | [Int32](http://dotnet.github.io/api/System.Int32.html)
[UInt32](http://dotnet.github.io/api/System.UInt32.html) | 32-bit unsigned integer | [Int64](http://dotnet.github.io/api/System.Int64.html)
[UInt64](http://dotnet.github.io/api/System.UInt64.html) | 64-bit unsigned integer | [Int64](http://dotnet.github.io/api/System.Int64.html) (may overflow), [BigInteger](http://dotnet.github.io/api/System.Numerics.BigInteger.html), or [Double](http://dotnet.github.io/api/System.Double.html)
[UIntPtr](http://dotnet.github.io/api/System.UIntPtr.html) | Unsigned pointer or handle | [IntPtr](http://dotnet.github.io/api/System.IntPtr.html)
 
 The .NET Framework Class Library or any other class library may include other types that aren't CLS-compliant; for example: 
 
 * Boxed value types. The following C# example creates a class that has a public property of type **int*** named `Value`. Because an **int*** is a boxed value type, the compiler flags it as non-CLS-compliant.

```csharp
using System;

[assembly:CLSCompliant(true)]

public unsafe class TestClass
{
   private int* val;

   public TestClass(int number)
   {
      val = (int*) number;
   }

   public int* Value {
      get { return val; }        
   }
}
// The compiler generates the following output when compiling this example:
//        warning CS3003: Type of 'TestClass.Value' is not CLS-compliant
```
* Typed references, which are special constructs that contain a reference to an object and a reference to a type.

If a type is not CLS-compliant, you should apply the [CLSCompliantAttribute](http://dotnet.github.io/api/System.CLSCompliantAttribute.html) attribute with an *isCompliant* parameter with a value of **false** to it. For more information, see the [CLSCompliantAttribute attribute](#the-clscompliantattribute-attribute) section.  

The following example illustrates the problem of CLS compliance in a method signature and in generic type instantiation. It defines an `InvoiceItem` class with a property of type [UInt32](http://dotnet.github.io/api/System.UInt32.html), a property of type [Nullable(Of UInt32)](http://dotnet.github.io/api/System.Nullable%601.html), and a constructor with parameters of type **UInt32** and **Nullable(Of UInt32)**. You get four compiler warnings when you try to compile this example.

```csharp
using System;

[assembly: CLSCompliant(true)]

public class InvoiceItem
{
   private uint invId = 0;
   private uint itemId = 0;
   private Nullable<uint> qty;

   public InvoiceItem(uint sku, Nullable<uint> quantity)
   {
      itemId = sku;
      qty = quantity;
   }

   public Nullable<uint> Quantity
   {
      get { return qty; }
      set { qty = value; }
   }

   public uint InvoiceId
   {
      get { return invId; }
      set { invId = value; }
   }
}
// The attempt to compile the example displays the following output:
//    Type1.cs(13,23): warning CS3001: Argument type 'uint' is not CLS-compliant
//    Type1.cs(13,33): warning CS3001: Argument type 'uint?' is not CLS-compliant
//    Type1.cs(19,26): warning CS3003: Type of 'InvoiceItem.Quantity' is not CLS-compliant
//    Type1.cs(25,16): warning CS3003: Type of 'InvoiceItem.InvoiceId' is not CLS-compliant
```

To eliminate the compiler warnings, replace the non-CLS-compliant types in the `InvoiceItem` public interface with compliant types:

```csharp
using System;

[assembly: CLSCompliant(true)]

public class InvoiceItem
{
   private uint invId = 0;
   private uint itemId = 0;
   private Nullable<int> qty;

   public InvoiceItem(int sku, Nullable<int> quantity)
   {
      if (sku <= 0)
         throw new ArgumentOutOfRangeException("The item number is zero or negative.");
      itemId = (uint) sku;

      qty = quantity;
   }

   public Nullable<int> Quantity
   {
      get { return qty; }
      set { qty = value; }
   }

   public int InvoiceId
   {
      get { return (int) invId; }
      set { 
         if (value <= 0)
            throw new ArgumentOutOfRangeException("The invoice number is zero or negative.");
         invId = (uint) value; }
   }
}
```

In addition to the specific types listed, some categories of types are not CLS compliant. These include unmanaged pointer types and function pointer types. The following example generates a compiler warning because it uses a pointer to an integer to create an array of integers. 

```csharp
using System;

[assembly: CLSCompliant(true)]

public class ArrayHelper
{
   unsafe public static Array CreateInstance(Type type, int* ptr, int items)
   {
      Array arr = Array.CreateInstance(type, items);
      int* addr = ptr;
      for (int ctr = 0; ctr < items; ctr++) {
          int value = *addr;
          arr.SetValue(value, ctr);
          addr++;
      }
      return arr;
   }
}   
// The attempt to compile this example displays the following output:
//    UnmanagedPtr1.cs(8,57): warning CS3001: Argument type 'int*' is not CLS-compliant
```

For CLS-compliant abstract classes (that is, classes marked as **abstract** in C#), all members of the class must also be CLS-compliant. 

### Naming conventions

Because some programming languages are case-insensitive, identifiers (such as the names of namespaces, types, and members) must differ by more than case. Two identifiers are considered equivalent if their lowercase mappings are the same. The following C# example defines two public classes, `Person` and `person`. Because they differ only by case, the C# compiler flags them as not CLS-compliant. 

```csharp
using System;

[assembly: CLSCompliant(true)]

public class Person : person
{

}

public class person
{

}
// Compilation produces a compiler warning like the following:
//    Naming1.cs(11,14): warning CS3005: Identifier 'person' differing 
//                       only in case is not CLS-compliant
//    Naming1.cs(6,14): (Location of symbol related to previous warning)
```

Programming language identifiers, such as the names of namespaces, types, and members, must conform to the [Unicode Standard 3.0, Technical Report 15, Annex 7](http://www.unicode.org/reports/tr15/tr15-18.html). This means that:

* The first character of an identifier can be any Unicode uppercase letter, lowercase letter, title case letter, modifier letter, other letter, or letter number. For information on Unicode character categories, see the [System.Globalization.UnicodeCategory](http://dotnet.github.io/api/System.Globalization.UnicodeCategory.html) enumeration. 

* Subsequent characters can be from any of the categories as the first character, and can also include non-spacing marks, spacing combining marks, decimal numbers, connector punctuations, and formatting codes. 

Before you compare identifiers, you should filter out formatting codes and convert the identifiers to Unicode Normalization Form C, because a single character can be represented by multiple UTF-16-encoded code units. Character sequences that produce the same code units in Unicode Normalization Form C are not CLS-compliant. The following example defines a property named **Å**, which consists of the character ANGSTROM SIGN (U+212B), and a second property named **Å** which consists of the character LATIN CAPITAL LETTER A WITH RING ABOVE (U+00C5). The C# compiler flags the source code as non-CLS-compliant.

```csharp
public class Size
{
   private double a1;
   private double a2;

   public double Å
   {
       get { return a1; }
       set { a1 = value; }
   }         

   public double Å
   {
       get { return a2; }
       set { a2 = value; }
   }
}
// Compilation produces a compiler warning like the following:
//    Naming2a.cs(16,18): warning CS3005: Identifier 'Size.Å' differing only in case is not
//            CLS-compliant
//    Naming2a.cs(10,18): (Location of symbol related to previous warning)
//    Naming2a.cs(18,8): warning CS3005: Identifier 'Size.Å.get' differing only in case is not
//            CLS-compliant
//    Naming2a.cs(12,8): (Location of symbol related to previous warning)
//    Naming2a.cs(19,8): warning CS3005: Identifier 'Size.Å.set' differing only in case is not
//            CLS-compliant
//    Naming2a.cs(13,8): (Location of symbol related to previous warning)
```

Member names within a particular scope (such as the namespaces within an assembly, the types within a namespace, or the members within a type) must be unique except for names that are resolved through overloading. This requirement is more stringent than that of the common type system, which allows multiple members within a scope to have identical names as long as they are different kinds of members (for example, one is a method and one is a field). In particular, for type members: 

* Fields and nested types are distinguished by name alone. 

* Methods, properties, and events that have the same name must differ by more than just return type. 

The following example illustrates the requirement that member names must be unique within their scope. It defines a class named `Converter` that includes four members named `Conversion`. Three are methods, and one is a property. The method that includes an **Int64** parameter is uniquely named, but the two methods with an **Int32** parameter are not, because return value is not considered a part of a member's signature. The `Conversion` property also violates this requirement, because properties cannot have the same name as overloaded methods. 

```csharp
using System;

[assembly: CLSCompliant(true)]

public class Converter
{
   public double Conversion(int number)
   {
      return (double) number;
   }

   public float Conversion(int number)
   {
      return (float) number;
   }

   public double Conversion(long number)
   {
      return (double) number;
   }

   public bool Conversion
   {
      get { return true; }
   }     
}  
// Compilation produces a compiler error like the following:
//    Naming3.cs(13,17): error CS0111: Type 'Converter' already defines a member called
//            'Conversion' with the same parameter types
//    Naming3.cs(8,18): (Location of symbol related to previous error)
//    Naming3.cs(23,16): error CS0102: The type 'Converter' already contains a definition for
//            'Conversion'
//    Naming3.cs(8,18): (Location of symbol related to previous error)
```

Individual languages include unique keywords, so languages that target the common language runtime must also provide some mechanism for referencing identifiers (such as type names) that coincide with keywords. For example, case is a keyword in C#. The following C# example is able to instantiate the `case` class by using the **@** symbol to disambiguate the identifier from the language keyword. Without it, the C# compiler would display two error messages, "Type expected" and "Invalid expression term 'case'." 

```csharp
using System;

public class Example
{
   public static void Main()
   {
      @case c = new @case("John");
      Console.WriteLine(c.ClientName);
   }
}
```

### Type conversion

The Common Language Specification defines two conversion operators:

* **op_Implicit**, which is used for widening conversions that do not result in loss of data or precision. For example, the [Decimal](http://dotnet.github.io/api/System.Decimal.html) structure includes an overloaded **op_Implicit** operator to convert values of integral types and [Char](http://dotnet.github.io/api/System.Char.html) values to **Decimal** values. 

* **op_Explicit**, which is used for narrowing conversions that can result in loss of magnitude (a value is converted to a value that has a smaller range) or precision. For example, the **Decimal** structure includes an overloaded **op_Explicit** operator to convert [Double](http://dotnet.github.io/api/System.Double.html) and [Single](http://dotnet.github.io/api/System.Single.html) values to **Decimal** and to convert **Decimal** values to integral values, **Double**, **Single**, and **Char**. 

However, not all languages support operator overloading or the definition of custom operators. If you choose to implement these conversion operators, you should also provide an alternate way to perform the conversion. We recommend that you provide **From**Xxx and **To**Xxx methods. 

The following example defines CLS-compliant implicit and explicit conversions. It creates a `UDouble`class that represents an signed double-precision, floating-point number. It provides for implicit conversions from `UDouble` to **Double** and for explicit conversions from `UDouble` to **Single**, **Double** to `UDouble`, and **Single** to `UDouble`. It also defines a `ToDouble` method as an alternative to the implicit conversion operator and the `ToSingle`, `FromDouble`, and `FromSingle` methods as alternatives to the explicit conversion operators. 

```csharp
using System;

public struct UDouble
{
   private double number;

   public UDouble(double value)
   {
      if (value < 0)
         throw new InvalidCastException("A negative value cannot be converted to a UDouble.");

      number = value;
   }

   public UDouble(float value)
   {
      if (value < 0)
         throw new InvalidCastException("A negative value cannot be converted to a UDouble.");

      number = value;
   }

   public static readonly UDouble MinValue = (UDouble) 0.0;
   public static readonly UDouble MaxValue = (UDouble) Double.MaxValue;

   public static explicit operator Double(UDouble value)
   {
      return value.number;
   }

   public static implicit operator Single(UDouble value)
   {
      if (value.number > (double) Single.MaxValue) 
         throw new InvalidCastException("A UDouble value is out of range of the Single type.");

      return (float) value.number;         
   }

   public static explicit operator UDouble(double value)
   {
      if (value < 0)
         throw new InvalidCastException("A negative value cannot be converted to a UDouble.");

      return new UDouble(value);
   } 

   public static implicit operator UDouble(float value)
   {
      if (value < 0)
         throw new InvalidCastException("A negative value cannot be converted to a UDouble.");

      return new UDouble(value);
   } 

   public static Double ToDouble(UDouble value)
   {
      return (Double) value;
   }   

   public static float ToSingle(UDouble value)
   {
      return (float) value;
   }   

   public static UDouble FromDouble(double value)
   {
      return new UDouble(value);
   }

   public static UDouble FromSingle(float value)
   {
      return new UDouble(value);
   }   
}
```

### Arrays

CLS-compliant arrays conform to the following rules: 

* All dimensions of an array must have a lower bound of zero. The following example creates a non-CLS-compliant array with a lower bound of one. Note that, despite the presence of the [CLSCompliantAttribute](http://dotnet.github.io/api/System.CLSCompliantAttribute.html) attribute, the compiler does not detect that the array returned by the `Numbers.GetTenPrimes` method is not CLS-compliant. 

    ```csharp
    [assembly: CLSCompliant(true)]

    public class Numbers
    {
    public static Array GetTenPrimes()
    {
        Array arr = Array.CreateInstance(typeof(Int32), new int[] {10}, new int[] {1});
        arr.SetValue(1, 1);
        arr.SetValue(2, 2);
        arr.SetValue(3, 3);
        arr.SetValue(5, 4);
        arr.SetValue(7, 5);
        arr.SetValue(11, 6);
        arr.SetValue(13, 7);
        arr.SetValue(17, 8);
        arr.SetValue(19, 9);
        arr.SetValue(23, 10);

        return arr; 
    }
    }
    ```

* All array elements must consist of CLS-compliant types. The following example defines two methods that return non-CLS-compliant arrays. The first returns an array of [UInt32](http://dotnet.github.io/api/System.UInt32.html) values. The second returns an [Object](http://dotnet.github.io/api/System.Object.html) array that includes [Int32](http://dotnet.github.io/api/System.Int32.html) and **UInt32** values. Although the compiler identifies the first array as non-compliant because of its **UInt32** type, it fails to recognize that the second array includes non-CLS-compliant elements. 

    ```csharp
    using System;

    [assembly: CLSCompliant(true)]

    public class Numbers
    {
    public static UInt32[] GetTenPrimes()
    {
        uint[] arr = { 1u, 2u, 3u, 5u, 7u, 11u, 13u, 17u, 19u };
        return arr;
    }

    public static Object[] GetFivePrimes()
    {
        Object[] arr = { 1, 2, 3, 5u, 7u };
        return arr;
    }
    }
    // Compilation produces a compiler warning like the following:
    //    Array2.cs(8,27): warning CS3002: Return type of 'Numbers.GetTenPrimes()' is not
    //            CLS-compliant
    ```

* Overload resolution for methods that have array parameters is based on the fact that they are arrays and on their element type. For this reason, the following definition of an overloaded `GetSquares` method is CLS-compliant. 

    ```csharp
    using System;
    using System.Numerics;

    [assembly: CLSCompliant(true)]

    public class Numbers
    {
    public static byte[] GetSquares(byte[] numbers)
    {
        byte[] numbersOut = new byte[numbers.Length];
        for (int ctr = 0; ctr < numbers.Length; ctr++) {
            int square = ((int) numbers[ctr]) * ((int) numbers[ctr]); 
            if (square <= Byte.MaxValue)
                numbersOut[ctr] = (byte) square;
            // If there's an overflow, assign MaxValue to the corresponding 
            // element.
            else
                numbersOut[ctr] = Byte.MaxValue;

        }
        return numbersOut;
    }

    public static BigInteger[] GetSquares(BigInteger[] numbers)
    {
        BigInteger[] numbersOut = new BigInteger[numbers.Length];
        for (int ctr = 0; ctr < numbers.Length; ctr++)
            numbersOut[ctr] = numbers[ctr] * numbers[ctr]; 

        return numbersOut;
    }
    }
    ```

### Interfaces

CLS-compliant interfaces can define properties, events, and virtual methods (methods with no implementation). A CLS-compliant interface cannot have any of the following: 

* Static methods or static fields. The C# compiler generatse compiler errors if you define a static member in an interface. 

* Fields. The C# acompiler generates compiler errors if you define a field in an interface.

* Methods that are not CLS-compliant. For example, the following interface definition includes a method, `INumber.GetUnsigned`, that is marked as non-CLS-compliant. This example generates a compiler warning. 

    ```csharp
    using System;

    [assembly:CLSCompliant(true)]

    public interface INumber
    {
        int Length();
        [CLSCompliant(false)] ulong GetUnsigned();
    }
    // Attempting to compile the example displays output like the following:
    //    Interface2.cs(8,32): warning CS3010: 'INumber.GetUnsigned()': CLS-compliant interfaces
    //            must have only CLS-compliant members
    ```

    Because of this rule, CLS-compliant types are not required to implement non-CLS-compliant members. If a CLS-compliant framework does expose a class that implements a non-CLS compliant interface, it should also provide concrete implementations of all non-CLS-compliant members. 

CLS-compliant language compilers must also allow a class to provide separate implementations of members that have the same name and signature in multiple interfaces. C# supports explicit interface implementations to provide different implementations of identically named methods. The following example illustrates this scenario by defining a `Temperature` class that implements the `ICelsius` and `IFahrenheit` interfaces as explicit interface implementations. 

```csharp
using System;

[assembly: CLSCompliant(true)]

public interface IFahrenheit
{
   decimal GetTemperature();
}

public interface ICelsius
{
   decimal GetTemperature();
}

public class Temperature : ICelsius, IFahrenheit
{
   private decimal _value;

   public Temperature(decimal value)
   {
      // We assume that this is the Celsius value.
      _value = value;
   } 

   decimal IFahrenheit.GetTemperature()
   {
      return _value * 9 / 5 + 32;
   }

   decimal ICelsius.GetTemperature()
   {
      return _value;
   } 
}
public class Example
{
   public static void Main()
   {
      Temperature temp = new Temperature(100.0m);
      ICelsius cTemp = temp;
      IFahrenheit fTemp = temp;
      Console.WriteLine("Temperature in Celsius: {0} degrees", 
                        cTemp.GetTemperature());
      Console.WriteLine("Temperature in Fahrenheit: {0} degrees", 
                        fTemp.GetTemperature());
   }
}
// The example displays the following output:
//       Temperature in Celsius: 100.0 degrees
//       Temperature in Fahrenheit: 212.0 degrees
```

### Enumerations

CLS-compliant enumerations must follow these rules: 

* The underlying type of the enumeration must be an intrinsic CLS-compliant integer ([Byte](http://dotnet.github.io/api/System.Byte.html), [Int16](http://dotnet.github.io/api/System.Int16.html), [Int32](http://dotnet.github.io/api/System.Int32.html), or [Int64](http://dotnet.github.io/api/System.Int64.html)). For example, the following code tries to define an enumeration whose underlying type is [UInt32](http://dotnet.github.io/api/System.UInt32.html) and generates a compiler warning. 

    ```csharp
    using System;

    [assembly: CLSCompliant(true)]

    public enum Size : uint { 
        Unspecified = 0, 
        XSmall = 1, 
        Small = 2, 
        Medium = 3, 
        Large = 4, 
        XLarge = 5 
    };

    public class Clothing
    {
        public string Name; 
        public string Type;
        public string Size;
    }
    // The attempt to compile the example displays a compiler warning like the following:
    //    Enum3.cs(6,13): warning CS3009: 'Size': base type 'uint' is not CLS-compliant
    ```

* An enumeration type must have a single instance field named **Value__** that is marked with the **FieldAttributes.RTSpecialName** attribute. This enables you to reference the field value implicitly. 

* An enumeration includes literal static fields whose types match the type of the enumeration itself. For example, if you define a `State` enumeration with values of `State.On` and `State.Off`, `State.On` and `State.Off` are both literal static fields whose type is `State`. 

* There are two kinds of enumerations: 
    
    * An enumeration that represents a set of mutually exclusive, named integer values. This type of enumeration is indicated by the absence of the [System.FlagsAttribute](http://dotnet.github.io/api/System.FlagsAttribute.html) custom attribute.
    
    * An enumeration that represents a set of bit flags that can combine to generate an unnamed value. This type of enumeration is indicated by the presence of the [System.FlagsAttribute](http://dotnet.github.io/api/System.FlagsAttribute.html) custom attribute.
    
 For more information, see the documentation for the [Enum](http://dotnet.github.io/api/System.Enum.html) structure. 

* The value of an enumeration is not limited to the range of its specified values. In other words, the range of values in an enumeration is the range of its underlying value. You can use the **Enum.IsDefined** method to determine whether a specified value is a member of an enumeration. 

### Type members in general

The Common Language Specification requires all fields and methods to be accessed as members of a particular class. Therefore, global static fields and methods (that is, static fields or methods that are defined apart from a type) are not CLS-compliant. If you try to include a global field or method in your source code, the C# compiler generates a compiler error. 

The Common Language Specification supports only the standard managed calling convention. It doesn't support unmanaged calling conventions and methods with variable argument lists marked with the **varargs** keyword. For variable argument lists that are compatible with the standard managed calling convention, use the [ParamArrayAttribute](http://dotnet.github.io/api/System.ParamArrayAttribute.html) attribute or the individual language's implementation, such as the **params** keyword in C#. 

### Member accessibility

Overriding an inherited member cannot change the accessibility of that member. For example, a public method in a base class cannot be overridden by a private method in a derived class. There is one exception: a **protected internal** member in one assembly that is overridden by a type in a different assembly. In that case, the accessibility of the override is **Protected**. 

The following example illustrates the error that is generated when the [CLSCompliantAttribute](http://dotnet.github.io/api/System.CLSCompliantAttribute.html) attribute is set to **true**, and `Person`, which is a class derived from `Animal`, tries to change the accessibility of the `Species` property from public to private. The example compiles successfully if its accessibility is changed to public. 

```csharp
using System;

[assembly: CLSCompliant(true)]

public class Animal
{
   private string _species;

   public Animal(string species)
   {
      _species = species;
   }

   public virtual string Species 
   {    
      get { return _species; }
   }

   public override string ToString()
   {
      return _species;   
   } 
}

public class Human : Animal
{
   private string _name;

   public Human(string name) : base("Homo Sapiens")
   {
      _name = name;
   }

   public string Name
   {
      get { return _name; }
   }

   private override string Species 
   {
      get { return base.Species; }
   }

   public override string ToString() 
   {
      return _name;
   }
}

public class Example
{
   public static void Main()
   {
      Human p = new Human("John");
      Console.WriteLine(p.Species);
      Console.WriteLine(p.ToString());
   }
}
// The example displays the following output:
//    error CS0621: 'Human.Species': virtual or abstract members cannot be private
```

Types in the signature of a member must be accessible whenever that member is accessible. For example, this means that a public member cannot include a parameter whose type is private, protected, or internal. The following example illustrates the compiler error that results when a `StringWrapper` class constructor exposes an internal `StringOperationType` enumeration value that determines how a string value should be wrapped. 

```csharp
using System;
using System.Text;

public class StringWrapper
{
   string internalString;
   StringBuilder internalSB = null;
   bool useSB = false;

   public StringWrapper(StringOperationType type)
   {   
      if (type == StringOperationType.Normal) {
         useSB = false;
      }   
      else {
         useSB = true;
         internalSB = new StringBuilder();
      }    
   }

   // The remaining source code...
}

internal enum StringOperationType { Normal, Dynamic }
// The attempt to compile the example displays the following output:
//    error CS0051: Inconsistent accessibility: parameter type
//            'StringOperationType' is less accessible than method
//            'StringWrapper.StringWrapper(StringOperationType)'
```

### Generic types and members

Nested types always have at least as many generic parameters as their enclosing type. These correspond by position to the generic parameters in the enclosing type. The generic type can also include new generic parameters. 

The relationship between the generic type parameters of a containing type and its nested types may be hidden by the syntax of individual languages. In the following example, a generic type `Outer<T>` contains two nested classes, `Inner1A` and `Inner1B<U>`. The calls to the **ToString** method, which each class inherits from **Object.ToString**, show that each nested class includes the type parameters of its containing class. 

```csharp
using System;

[assembly:CLSCompliant(true)]

public class Outer<T>
{
   T value;

   public Outer(T value)
   {
      this.value = value;
   }

   public class Inner1A : Outer<T>
   {
      public Inner1A(T value) : base(value)
      {  }
   }

   public class Inner1B<U> : Outer<T>
   {
      U value2;

      public Inner1B(T value1, U value2) : base(value1)
      {
         this.value2 = value2;
      }
   }
}

public class Example
{
   public static void Main()
   {
      var inst1 = new Outer<String>("This");
      Console.WriteLine(inst1);

      var inst2 = new Outer<String>.Inner1A("Another");
      Console.WriteLine(inst2);

      var inst3 = new Outer<String>.Inner1B<int>("That", 2);
      Console.WriteLine(inst3);
   }
}
// The example displays the following output:
//       Outer`1[System.String]
//       Outer`1+Inner1A[System.String]
//       Outer`1+Inner1B`1[System.String,System.Int32]
```

Generic type names are encoded in the form *name`n*, where *name* is the type name, *`* is a character literal, and *n* is the number of parameters declared on the type, or, for nested generic types, the number of newly introduced type parameters. This encoding of generic type names is primarily of interest to developers who use reflection to access CLS-complaint generic types in a library. 

If constraints are applied to a generic type, any types used as constraints must also be CLS-compliant. The following example defines a class named `BaseClass` that is not CLS-compliant and a generic class named `BaseCollection` whose type parameter must derive from `BaseClass`. But because `BaseClass`is not CLS-compliant, the compiler emits a warning. 

```csharp
using System;

[assembly:CLSCompliant(true)]

[CLSCompliant(false)] public class BaseClass
{}


public class BaseCollection<T> where T : BaseClass
{}
// Attempting to compile the example displays the following output:
//    warning CS3024: Constraint type 'BaseClass' is not CLS-compliant
```

If a generic type is derived from a generic base type, it must redeclare any constraints so that it can guarantee that constraints on the base type are also satisfied. The following example defines a `Number<T>` that can represent any numeric type. It also defines a `FloatingPoint<T>` class that represents a floating point value. However, the source code fails to compile, because it does not apply the constraint on `Number<T>` (that T must be a value type) to `FloatingPoint<T>`.

```csharp
using System;

[assembly:CLSCompliant(true)]

public class Number<T> where T : struct
{
   // use Double as the underlying type, since its range is a superset of
   // the ranges of all numeric types except BigInteger.
   protected double number;

   public Number(T value)
   {
      try {
         this.number = Convert.ToDouble(value);
      }  
      catch (OverflowException e) {
         throw new ArgumentException("value is too large.", e);
      }
      catch (InvalidCastException e) {
         throw new ArgumentException("The value parameter is not numeric.", e);
      }
   }

   public T Add(T value)
   {
      return (T) Convert.ChangeType(number + Convert.ToDouble(value), typeof(T));
   }

   public T Subtract(T value)
   {
      return (T) Convert.ChangeType(number - Convert.ToDouble(value), typeof(T));
   }
}

public class FloatingPoint<T> : Number<T> 
{
   public FloatingPoint(T number) : base(number) 
   {
      if (typeof(float) == number.GetType() ||
          typeof(double) == number.GetType() || 
          typeof(decimal) == number.GetType())
         this.number = Convert.ToDouble(number);
      else   
         throw new ArgumentException("The number parameter is not a floating-point number.");
   }       
}           
// The attempt to comple the example displays the following output:
//       error CS0453: The type 'T' must be a non-nullable value type in
//               order to use it as parameter 'T' in the generic type or method 'Number<T>'
```

The example compiles successfully if the constraint is added to the `FloatingPoint<T>` class.

```csharp
using System;

[assembly:CLSCompliant(true)]


public class Number<T> where T : struct
{
   // use Double as the underlying type, since its range is a superset of
   // the ranges of all numeric types except BigInteger.
   protected double number;

   public Number(T value)
   {
      try {
         this.number = Convert.ToDouble(value);
      }  
      catch (OverflowException e) {
         throw new ArgumentException("value is too large.", e);
      }
      catch (InvalidCastException e) {
         throw new ArgumentException("The value parameter is not numeric.", e);
      }
   }

   public T Add(T value)
   {
      return (T) Convert.ChangeType(number + Convert.ToDouble(value), typeof(T));
   }

   public T Subtract(T value)
   {
      return (T) Convert.ChangeType(number - Convert.ToDouble(value), typeof(T));
   }
}

public class FloatingPoint<T> : Number<T> where T : struct 
{
   public FloatingPoint(T number) : base(number) 
   {
      if (typeof(float) == number.GetType() ||
          typeof(double) == number.GetType() || 
          typeof(decimal) == number.GetType())
         this.number = Convert.ToDouble(number);
      else   
         throw new ArgumentException("The number parameter is not a floating-point number.");
   }       
}      
```

The Common Language Specification imposes a conservative per-instantiation model for nested types and protected members. Open generic types cannot expose fields or members with signatures that contain a specific instantiation of a nested, protected generic type. Non-generic types that extend a specific instantiation of a generic base class or interface cannot expose fields or members with signatures that contain a different instantiation of a nested, protected generic type.

The following example defines a generic type, `C1<T>`, and a protected class, `C1<T>.N`. `C1<T>` has two methods, `M1` and `M2`. However, `M1` is not CLS-compliant because it tries to return a `C1<int>.N` object from `C1<T>`. A second class, `C2`, is derived from `C1<long>`. It has two methods, `M3` and `M4`. `M3` is not CLS-compliant because it tries to return a `C1<int>.N` object from a subclass of `C1<long>`.

```csharp
using System;

[assembly:CLSCompliant(true)]

public class C1<T> 
{
   protected class N { }

   protected void M1(C1<int>.N n) { } // Not CLS-compliant - C1<int>.N not
                                      // accessible from within C1<T> in all
                                      // languages
   protected void M2(C1<T>.N n) { }   // CLS-compliant – C1<T>.N accessible
                                      // inside C1<T>
}

public class C2 : C1<long> 
{
   protected void M3(C1<int>.N n) { }  // Not CLS-compliant – C1<int>.N is not
                                       // accessible in C2 (extends C1<long>)

   protected void M4(C1<long>.N n) { } // CLS-compliant, C1<long>.N is
                                       // accessible in C2 (extends C1<long>)
}
// Attempting to compile the example displays output like the following:
//       Generics4.cs(9,22): warning CS3001: Argument type 'C1<int>.N' is not CLS-compliant
//       Generics4.cs(18,22): warning CS3001: Argument type 'C1<int>.N' is not CLS-compliant
```

### Constructors

Constructors in CLS-compliant classes and structures must follow these rules: 

* A constructor of a derived class must call the instance constructor of its base class before it accesses inherited instance data. This requirement is due to the fact that base class constructors are not inherited by their derived classes. This rule does not apply to structures, which do not support direct inheritance. 

Typically, compilers enforce this rule independently of CLS compliance, as the following example shows. It creates a `Doctor` class that is derived from a `Person` class, but the `Doctor`class fails to call the `Person` class constructor to initialize inherited instance fields. 

    ```csharp
    using System;

    [assembly: CLSCompliant(true)]

    public class Person
    {
    private string fName, lName, _id;

    public Person(string firstName, string lastName, string id)
    {
        if (String.IsNullOrEmpty(firstName + lastName))
            throw new ArgumentNullException("Either a first name or a last name must be provided.");    

        fName = firstName;
        lName = lastName;
        _id = id;
    }

    public string FirstName 
    {
        get { return fName; }
    }

    public string LastName 
    {
        get { return lName; }
    }

    public string Id 
    {
        get { return _id; }
    }

    public override string ToString()
    {
        return String.Format("{0}{1}{2}", fName, 
                            String.IsNullOrEmpty(fName) ?  "" : " ",
                            lName);
    }
    }

    public class Doctor : Person
    {
    public Doctor(string firstName, string lastName, string id)
    {
    }

    public override string ToString()
    {
        return "Dr. " + base.ToString();
    }
    }
    // Attempting to compile the example displays output like the following:
    //    ctor1.cs(45,11): error CS1729: 'Person' does not contain a constructor that takes 0
    //            arguments
    //    ctor1.cs(10,11): (Location of symbol related to previous error)
    ```
    
* An object constructor cannot be called except to create an object. In addition, an object cannot be initialized twice. For example, this means that **Object.MemberwiseClone** must not call constructors.  

### Properties

Properties in CLS-compliant types must follow these rules:

* A property must have a setter, a getter, or both. In an assembly, these are implemented as special methods, which means that they will appear as separate methods (the getter is named **get**_*propertyname* and the setter is **set**_*propertyname*) marked as `SpecialName` in the assembly's metadata. The C# compiler enforces this rule automatically without the need to apply the [CLSCompliantAttribute](http://dotnet.github.io/api/System.CLSCompliantAttribute.html) attribute. 

* A property's type is the return type of the property getter and the last argument of the setter. These types must be CLS compliant, and arguments cannot be assigned to the property by reference (that is, they cannot be managed pointers). 

* If a property has both a getter and a setter, they must both be virtual, both static, or both instance. The C# compiler automatically enforces this rule through property definition syntax. 

### Events

An event is defined by its name and its type. The event type is a delegate that is used to indicate the event. For example, the **DbConnection.StateChange** event is of type **StateChangeEventHandler**. In addition to the event itself, three methods with names based on the event name provide the event's implementation and are marked as `SpecialName` in the assembly's metadata: 

* A method for adding an event handler, named **add**_*EventName*. For example, the event subscription method for the **DbConnection.StateChange** event is named **add_StateChange**. 

* A method for removing an event handler, named **remove**_*EventName*. For example, the removal method for the **DbConnection.StateChange** event is named **remove_StateChange**.

* A method for indicating that the event has occurred, named **raise**_*EventName*. 

> **Note**
>
> Most of the Common Language Specification's rules regarding events are implemented by language compilers and are transparent to component developers. 

The methods for adding, removing, and raising the event must have the same accessibility. They must also all be static, instance, or virtual. The methods for adding and removing an event have one parameter whose type is the event delegate type. The add and remove methods must both be present or both be absent. 

The following example defines a CLS-compliant class named `Temperature` that raises a `TemperatureChanged` event if the change in temperature between two readings equals or exceeds a threshold value. The `Temperature` class explicitly defines a `raise_TemperatureChanged` method so that it can selectively execute event handlers.

```csharp
using System;
using System.Collections;
using System.Collections.Generic;

[assembly: CLSCompliant(true)]

public class TemperatureChangedEventArgs : EventArgs
{
   private Decimal originalTemp;
   private Decimal newTemp; 
   private DateTimeOffset when;

   public TemperatureChangedEventArgs(Decimal original, Decimal @new, DateTimeOffset time)
   {
      originalTemp = original;
      newTemp = @new;
      when = time;
   }   

   public Decimal OldTemperature
   {
      get { return originalTemp; }
   } 

   public Decimal CurrentTemperature
   {
      get { return newTemp; }
   } 

   public DateTimeOffset Time
   {
      get { return when; }
   }
}

public delegate void TemperatureChanged(Object sender, TemperatureChangedEventArgs e);

public class Temperature
{
   private struct TemperatureInfo
   {
      public Decimal Temperature;
      public DateTimeOffset Recorded;
   }

   public event TemperatureChanged TemperatureChanged;

   private Decimal previous;
   private Decimal current;
   private Decimal tolerance;
   private List<TemperatureInfo> tis = new List<TemperatureInfo>();

   public Temperature(Decimal temperature, Decimal tolerance)
   {
      current = temperature;
      TemperatureInfo ti = new TemperatureInfo();
      ti.Temperature = temperature;
      tis.Add(ti);
      ti.Recorded = DateTimeOffset.UtcNow;
      this.tolerance = tolerance;
   }

   public Decimal CurrentTemperature
   {
      get { return current; }
      set {
         TemperatureInfo ti = new TemperatureInfo();
         ti.Temperature = value;
         ti.Recorded = DateTimeOffset.UtcNow;
         previous = current;
         current = value;
         if (Math.Abs(current - previous) >= tolerance) 
            raise_TemperatureChanged(new TemperatureChangedEventArgs(previous, current, ti.Recorded));
      }
   }

   public void raise_TemperatureChanged(TemperatureChangedEventArgs eventArgs)
   {
      if (TemperatureChanged == null)
         return; 

      foreach (TemperatureChanged d in TemperatureChanged.GetInvocationList()) {
         if (d.Method.Name.Contains("Duplicate"))
            Console.WriteLine("Duplicate event handler; event handler not executed.");
         else
            d.Invoke(this, eventArgs);
      }
   }
}

public class Example
{
   public Temperature temp;

   public static void Main()
   {
      Example ex = new Example();
   }

   public Example()
   {
      temp = new Temperature(65, 3);
      temp.TemperatureChanged += this.TemperatureNotification;
      RecordTemperatures();
      Example ex = new Example(temp);
      ex.RecordTemperatures();
   }

   public Example(Temperature t)
   {
      temp = t;
      RecordTemperatures();
   }

   public void RecordTemperatures()
   {
      temp.TemperatureChanged += this.DuplicateTemperatureNotification;
      temp.CurrentTemperature = 66;
      temp.CurrentTemperature = 63;
   }

   internal void TemperatureNotification(Object sender, TemperatureChangedEventArgs e) 
   {
      Console.WriteLine("Notification 1: The temperature changed from {0} to {1}", e.OldTemperature, e.CurrentTemperature);   
   }

   public void DuplicateTemperatureNotification(Object sender, TemperatureChangedEventArgs e)
   { 
      Console.WriteLine("Notification 2: The temperature changed from {0} to {1}", e.OldTemperature, e.CurrentTemperature);   
   }
}
```

### Overloads

The Common Language Specification imposes the following requirements on overloaded members: 

* Members can be overloaded based on the number of parameters and the type of any parameter. Calling convention, return type, custom modifiers applied to the method or its parameter, and whether parameters are passed by value or by reference are not considered when differentiating between overloads. For an example, see the code for the requirement that names must be unique within a scope in the [Naming conventions](#naming-conventions) section. 

* Only properties and methods can be overloaded. Fields and events cannot be overloaded. 

* Generic methods can be overloaded based on the number of their generic parameters. 

>**Note**
>
>The **op_Explicit** and **op_Implicit** operators are exceptions to the rule that return value is not considered part of a method signature for overload resolution. These two operators can be overloaded based on both their parameters and their return value. 

### Exceptions

Exception objects must derive from [System.Exception](http://dotnet.github.io/api/System.Exception.html) or from another type derived from **System.Exception**. The following example illustrates the compiler error that results when a custom class named `ErrorClass` is used for exception handling.

```csharp
using System;

[assembly: CLSCompliant(true)]

public class ErrorClass
{ 
   string msg;

   public ErrorClass(string errorMessage)
   {
      msg = errorMessage;
   }

   public string Message
   {
      get { return msg; }
   }
}

public static class StringUtilities
{
   public static string[] SplitString(this string value, int index)
   {
      if (index < 0 | index > value.Length) {
         ErrorClass badIndex = new ErrorClass("The index is not within the string.");
         throw badIndex;
      }
      string[] retVal = { value.Substring(0, index - 1), 
                          value.Substring(index) };
      return retVal;
   }
}
// Compilation produces a compiler error like the following:
//    Exceptions1.cs(26,16): error CS0155: The type caught or thrown must be derived from
//            System.Exception
```

To correct this error, the `ErrorClass` class must inherit from **System.Exception**. In addition, the Message property must be overridden. The following example corrects these errors to define an `ErrorClass` class that is CLS-compliant.  

```csharp
using System;

[assembly: CLSCompliant(true)]

public class ErrorClass : Exception
{ 
   string msg;

   public ErrorClass(string errorMessage)
   {
      msg = errorMessage;
   }

   public override string Message
   {
      get { return msg; }
   }
}

public static class StringUtilities
{
   public static string[] SplitString(this string value, int index)
   {
      if (index < 0 | index > value.Length) {
         ErrorClass badIndex = new ErrorClass("The index is not within the string.");
         throw badIndex;
      }
      string[] retVal = { value.Substring(0, index - 1), 
                          value.Substring(index) };
      return retVal;
   }
}
```

### Attributes

In.NET Framework assemblies, custom attributes provide an extensible mechanism for storing custom attributes and retrieving metadata about programming objects, such as assemblies, types, members, and method parameters. Custom attributes must derive from [System.Attribute](http://dotnet.github.io/api/System.Attribute.html) or from a type derived from **System.Attribute**.

The following example violates this rule. It defines a `NumericAttribute` class that does not derive from **System.Attribute**. Note that a compiler error results only when the non-CLS-compliant attribute is applied, not when the class is defined. 

```csharp
using System;

[assembly: CLSCompliant(true)]

[AttributeUsageAttribute(AttributeTargets.Class | AttributeTargets.Struct)] 
public class NumericAttribute
{
   private bool _isNumeric;

   public NumericAttribute(bool isNumeric)
   {
      _isNumeric = isNumeric;
   }

   public bool IsNumeric 
   {
      get { return _isNumeric; }
   }
}

[Numeric(true)] public struct UDouble
{
   double Value;
}
// Compilation produces a compiler error like the following:
//    Attribute1.cs(22,2): error CS0616: 'NumericAttribute' is not an attribute class
//    Attribute1.cs(7,14): (Location of symbol related to previous error)
```

The constructor or the properties of a CLS-compliant attribute can expose only the following types:

* [Boolean](http://dotnet.github.io/api/System.Boolean.html)

* [Byte](http://dotnet.github.io/api/System.Byte.html)

* [Char](http://dotnet.github.io/api/System.Char.html)

* [Double](http://dotnet.github.io/api/System.Double.html)

* [Int16](http://dotnet.github.io/api/System.Int16.html)

* [Int32](http://dotnet.github.io/api/System.Int32.html)

* [Int64](http://dotnet.github.io/api/System.Int64.html)

* [Single](http://dotnet.github.io/api/System.Single.html)

* [String](http://dotnet.github.io/api/System.String.html)

* [Type](http://dotnet.github.io/api/System.Type.html)

* Any enumeration type whose underlying type is **Byte**, **Int16**, **Int32**, or **Int64**. 

The following example defines a `DescriptionAttribute` class that derives from [Attribute](http://dotnet.github.io/api/System.Attribute.html). The class constructor has a parameter of type `Descriptor`, so the class is not CLS-compliant. Note that the C# compiler emits a warning but compiles successfully. 

```csharp
using System;

[assembly:CLSCompliantAttribute(true)]

public enum DescriptorType { type, member };

public class Descriptor
{
   public DescriptorType Type;
   public String Description; 
}

[AttributeUsage(AttributeTargets.All)]
public class DescriptionAttribute : Attribute
{
   private Descriptor desc;

   public DescriptionAttribute(Descriptor d)
   {
      desc = d; 
   }

   public Descriptor Descriptor
   { get { return desc; } } 
}
// Attempting to compile the example displays output like the following:
//       warning CS3015: 'DescriptionAttribute' has no accessible
//               constructors which use only CLS-compliant types
```

## The CLSCompliantAttribute attribute

The [CLSCompliantAttribute](http://dotnet.github.io/api/System.CLSCompliantAttribute.html) attribute is used to indicate whether a program element complies with the Common Language Specification. The **CLSCompliantAttribute.CLSCompliantAttribute(Boolean)** constructor includes a single required parameter, *isCompliant*, that indicates whether the program element is CLS-compliant. 

At compile time, the compiler detects non-compliant elements that are presumed to be CLS-compliant and emits a warning. The compiler does not emit warnings for types or members that are explicitly declared to be non-compliant. 

Component developers can use the **CLSCompliantAttribute** attribute in two ways: 

* To define the parts of the public interface exposed by a component that are CLS-compliant and the parts that are not CLS-compliant. When the attribute is used to mark particular program elements as CLS-compliant, its use guarantees that those elements are accessible from all languages and tools that target the .NET Framework. 

* To ensure that the component library's public interface exposes only program elements that are CLS-compliant. If elements are not CLS-compliant, compilers will generally issue a warning.

> **Warning**
>
> In some cases, language compilers enforce CLS-compliant rules regardless of whether the **CLSCompliantAttribute** attribute is used. For example, defining a **static** member in an interface violates a CLS rule. However, if you define a **static** member in an interface, the C# compiler displays an error message and fails to compile the app.

The **CLSCompliantAttribute** attribute is marked with an [AttributeUsageAttribute](http://dotnet.github.io/api/System.AttributeUsageAttribute.html) attribute that has a value of **AttributeTargets.All**. This value allows you to apply the **CLSCompliantAttribute** attribute to any program element, including assemblies, modules, types (classes, structures, enumerations, interfaces, and delegates), type members (constructors, methods, properties, fields, and events), parameters, generic parameters, and return values. However, in practice, you should apply the attribute only to assemblies, types, and type members. Otherwise, compilers ignore the attribute and continue to generate compiler warnings whenever they encounter a non-compliant parameter, generic parameter, or return value in your library's public interface.  

The value of the **CLSCompliantAttribute** attribute is inherited by contained program elements. For example, if an assembly is marked as CLS-compliant, its types are also CLS-compliant. If a type is marked as CLS-compliant, its nested types and members are also CLS-compliant. 

You can explicitly override the inherited compliance by applying the **CLSCompliantAttribute** attribute to a contained program element. For example, you can use the **CLSCompliantAttribute** attribute with an *isCompliant* value of **false** to define a non-compliant type in a compliant assembly, and you can use the attribute with an *isComplian* value of **true** to define a compliant type in a non-compliant assembly. You can also define non-compliant members in a compliant type. However, a non-compliant type cannot have compliant members, so you cannot use the attribute with an *isCompliant* value of **true** to override inheritance from a non-compliant type. 

When you are developing components, you should always use the **CLSCompliantAttribute** attribute to indicate whether your assembly, its types, and its members are CLS-compliant. 

To create CLS-compliant components: 

1. Use the **CLSCompliantAttribute** to mark you assembly as CLS-compliant.

2. Mark any publicly exposed types in the assembly that are not CLS-compliant as non-compliant. 

3. Mark any publicly exposed members in CLS-compliant types as non-compliant. 

4. Provide a CLS-compliant alternative for non-CLS-compliant members. 

If you've successfully marked all your non-compliant types and members, your compiler should not emit any non-compliance warnings. However, you should indicate which members are not CLS-compliant and list their CLS-compliant alternatives in your product documentation. 

The following example uses the **CLSCompliantAttribute** attribute to define a CLS-compliant assembly and a type, `CharacterUtilities`, that has two non-CLS-compliant members. Because both members are tagged with the **CLSCompliant(false)** attribute, the compiler produces no warnings. The class also provides a CLS-compliant alternative for both methods. Ordinarily, we would just add two overloads to the `ToUTF16` method to provide CLS-compliant alternatives. However, because methods cannot be overloaded based on return value, the names of the CLS-compliant methods are different from the names of the non-compliant methods.  

```csharp
using System;
using System.Text;

[assembly:CLSCompliant(true)]

public class CharacterUtilities
{
   [CLSCompliant(false)] public static ushort ToUTF16(String s)
   {
      s = s.Normalize(NormalizationForm.FormC);
      return Convert.ToUInt16(s[0]);
   }

   [CLSCompliant(false)] public static ushort ToUTF16(Char ch)
   {
      return Convert.ToUInt16(ch); 
   }

   // CLS-compliant alternative for ToUTF16(String).
   public static int ToUTF16CodeUnit(String s)
   {
      s = s.Normalize(NormalizationForm.FormC);
      return (int) Convert.ToUInt16(s[0]);
   }

   // CLS-compliant alternative for ToUTF16(Char).
   public static int ToUTF16CodeUnit(Char ch)
   {
      return Convert.ToInt32(ch);
   }

   public bool HasMultipleRepresentations(String s)
   {
      String s1 = s.Normalize(NormalizationForm.FormC);
      return s.Equals(s1);   
   }

   public int GetUnicodeCodePoint(Char ch)
   {
      if (Char.IsSurrogate(ch))
         throw new ArgumentException("ch cannot be a high or low surrogate.");

      return Char.ConvertToUtf32(ch.ToString(), 0);   
   }

   public int GetUnicodeCodePoint(Char[] chars)
   {
      if (chars.Length > 2)
         throw new ArgumentException("The array has too many characters.");

      if (chars.Length == 2) {
         if (! Char.IsSurrogatePair(chars[0], chars[1]))
            throw new ArgumentException("The array must contain a low and a high surrogate.");
         else
            return Char.ConvertToUtf32(chars[0], chars[1]);
      }
      else {
         return Char.ConvertToUtf32(chars.ToString(), 0);
      } 
   }
}
```

If you are developing an app rather than a library (that is, if you aren't exposing types or members that can be consumed by other app developers), the CLS compliance of the program elements that your app consumes are of interest only if your language does not support them. In that case, your language compiler will generate an error when you try to use a non-CLS-compliant element. 
