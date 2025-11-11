---
title: Resolve errors and warnings that involve attribute declaration and applying attributes in your code.
description: These compiler errors and warnings indicate errors in attribute declarations, or applying attributes in your code.
f1_keywords:
  - "CS0243"
  - "CS0404"
  - "CS0415"
  - "CS0416"
  - "CS0447"
  - "CS0577"
  - "CS0578"
  - "CS0582"
  - "CS0609"
  - "CS0625"
  - "CS0629"
  - "CS0636"
  - "CS0637"
  - "CS0641"
  - "CS0646"
  - "CS0653"
  - "CS0657"
  - "CS0658"
  - "CS0685"
  - "CS7014"
  - "CS7046"
  - "CS7047"
  - "CS7067"
  - "CS9331"
helpviewer_keywords:
  - "CS0243"
  - "CS0404"
  - "CS0415"
  - "CS0416"
  - "CS0447"
  - "CS0577"
  - "CS0578"
  - "CS0582"
  - "CS0609"
  - "CS0625"
  - "CS0629"
  - "CS0636"
  - "CS0637"
  - "CS0641"
  - "CS0646"
  - "CS0653"
  - "CS0657"
  - "CS0658"
  - "CS0685"
  - "CS7014"
  - "CS7046"
  - "CS7047"
  - "CS7067"
  - "CS9331"
ms.date: 11/11/2025
ai-usage: ai-assisted
---
# Resolve errors and warnings related to attribute declarations or applying attributes in your code

This article covers the following compiler errors:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->
- [**CS0243**](#conditional-attribute-on-override): *The Conditional attribute is not valid on 'method' because it is an override method*
- [**CS0404**](#generic-attributes): *'<' unexpected : attributes cannot be generic*
- [**CS0415**](#indexername-attribute): *The 'IndexerName' attribute is valid only on an indexer that is not an explicit interface member declaration*
- [**CS0416**](#attribute-argument-type-parameters): *'type parameter': an attribute argument cannot use type parameters*
- [**CS0447**](#attributes-on-type-arguments): *Attributes cannot be used on type arguments, only on type parameters*
- [**CS0577**](#conditional-attribute-restrictions): *The Conditional attribute is not valid on 'function' because it is a constructor, destructor, operator, or explicit interface implementation*
- [**CS0578**](#conditional-attribute-return-type): *The Conditional attribute is not valid on 'function' because its return type is not void*
- [**CS0582**](#conditional-on-interface-members): *The Conditional not valid on interface members*
- [**CS0609**](#indexername-on-override): *Cannot set the IndexerName attribute on an indexer marked override*
- [**CS0625**](#fieldoffset-attribute-required): *'field': instance field types marked with StructLayout(LayoutKind.Explicit) must have a FieldOffset attribute.*
- [**CS0629**](#conditional-on-interface-implementation): *Conditional member 'member' cannot implement interface member 'base class member' in type 'Type Name'*
- [**CS0636**](#structlayout-required): *The FieldOffset attribute can only be placed on members of types marked with the StructLayout(LayoutKind.Explicit)*
- [**CS0637**](#fieldoffset-on-static-const): *The FieldOffset attribute is not allowed on static or const fields.*
- [**CS0641**](#attributeusage-attribute): *'attribute' : attribute is only valid on classes derived from System.Attribute*
- [**CS0646**](#defaultmember-attribute): *Cannot specify the DefaultMember attribute on a type containing an indexer*
- [**CS0653**](#abstract-attribute-class): *Cannot apply attribute class 'class' because it is abstract*
- [**CS0657**](#invalid-attribute-location): *'attribute modifier' is not a valid attribute location for this declaration. Valid attribute locations for this declaration are 'locations'. All attributes in this block will be ignored.*
- [**CS0658**](#unrecognized-attribute-location): *'attribute modifier' is not a recognized attribute location. All attributes in this block will be ignored.*
- [**CS0685**](#conditional-with-out-parameter): *Conditional member 'member' cannot have an out parameter*
- [**CS7014**](#attributes-not-allowed): *Attributes are not valid in this context.*
- [**CS7046**](#attribute-parameter-required): *Attribute parameter '{0}' must be specified.*
- [**CS7047**](#attribute-parameters-required): *Attribute parameter '{0}' or '{1}' must be specified.*
- [**CS7067**](#attribute-parameter-default-argument): *Attribute constructor parameter '{0}' is optional, but no default parameter value was specified.*
- [**CS9331**](#reserved-attributes): *Attribute cannot be applied manually.*

## Conditional attribute on override

- **CS0243**: *The Conditional attribute is not valid on 'method' because it is an override method*

The <xref:System.Diagnostics.ConditionalAttribute> attribute is not allowed on a method that is marked with the [override](../keywords/override.md) keyword. For more information, see [Knowing When to Use Override and New Keywords](../../programming-guide/classes-and-structs/knowing-when-to-use-override-and-new-keywords.md).

The compiler never binds to override methods. It only binds to the base method, and the common language runtime calls the override, as appropriate.

The following code generates CS0243:

```csharp
// CS0243.cs
// compile with: /target:library
public class MyClass
{
   public virtual void M() {}
}

public class MyClass2 : MyClass
{
   [System.Diagnostics.ConditionalAttribute("MySymbol")]   // CS0243
   // remove Conditional attribute or remove override keyword
   public override void M() {}
}
```

## Generic attributes

- **CS0404**: *'<' unexpected : attributes cannot be generic*

Generic type parameters are not allowed in attributes. Remove the type parameter and angled brackets.

The following sample generates CS0404:

```csharp
// CS0404.cs
[MyAttrib<int>]  // CS0404
class C
{
   public static void Main()
   {

   }
}
```

## IndexerName attribute

- **CS0415**: *The 'IndexerName' attribute is valid only on an indexer that is not an explicit interface member declaration*

This error occurs if you use an IndexerName attribute on an indexer that was an explicit implementation of an interface. This error may be avoided by removing the interface name from the declaration of the indexer, if possible. For more information, see the [IndexerNameAttribute Class](xref:System.Runtime.CompilerServices.IndexerNameAttribute).

The following sample generates CS0415:

```csharp
// CS0415.cs
using System;
using System.Runtime.CompilerServices;

public interface IA
{
    int this[int index]
    {
        get;
        set;
    }
}

public class A : IA
{
    [IndexerName("Item")]  // CS0415
    int IA.this[int index]
    // Try this line instead:
    // public int this[int index]
    {
        get { return 0; }
        set { }
    }

    static void Main()
    {
    }
}
```

## Attribute argument type parameters

- **CS0416**: *'type parameter': an attribute argument cannot use type parameters*

A type parameter was used as an attribute argument, which is not allowed. Use a non-generic type.

The following sample generates CS0416:

```csharp
// CS0416.cs
public class MyAttribute : System.Attribute
{
   public MyAttribute(System.Type t)
   {
   }
}

class G<T>
{

   [MyAttribute(typeof(G<T>))]  // CS0416
   public void F()
   {
   }

}
```

## Attributes on type arguments

- **CS0447**: *Attributes cannot be used on type arguments, only on type parameters*

This error occurs when you apply an attribute to a type argument that occurs in an invocation statement. It is acceptable to apply an attribute to a type parameter in a class or method declaration statement such as the following:

```csharp
class C<[some attribute] T> {…}
```

The following line of code will generate this error. It is assumed that the class `C`, defined in the previous line of code, has a static method called `MyStaticMethod`.

```csharp
C<[some attribute] T>.MyStaticMethod();
```

The following code generates error CS0447:

```csharp
// CS0447.cs
using System;

namespace Test41
{
    public interface I<A>
    {
        void Meth<B>();
    }
    public class B : I<int>
    {
        void I<[Test] int>.Meth<X>() { }  // CS0447
    }
}
```

> [!NOTE]
> This compiler error is no longer used in Roslyn.

## Conditional attribute restrictions

- **CS0577**: *The Conditional attribute is not valid on 'function' because it is a constructor, destructor, operator, or explicit interface implementation*

> [!NOTE]
> Destructor is a deprecated term for [finalizer](../../programming-guide/classes-and-structs/finalizers.md).

`Conditional` cannot be applied to the specified methods.

For example, you cannot use some attributes on an explicit interface definition. The following sample generates CS0577:

```csharp
// CS0577.cs
// compile with: /target:library
interface I
{
   void m();
}

public class MyClass : I
{
   [System.Diagnostics.Conditional("a")]   // CS0577
   void I.m() {}
}
```

## Conditional attribute return type

- **CS0578**: *The Conditional attribute is not valid on 'function' because its return type is not void*

<xref:System.Diagnostics.ConditionalAttribute> cannot be applied to a method that has a return type other than `void`. The reason for this is that any other return type for a method may be needed by another part of your program.

The following sample generates CS0578. To resolve this error, you must either delete <xref:System.Diagnostics.ConditionalAttribute>, or you must change the return value of the method to `void`.

```csharp
// CS0578.cs
// compile with: /target:library
public class MyClass
{
    [System.Diagnostics.ConditionalAttribute("a")]   // CS0578
    public int TestMethod()
    {
        return 0;
    }
}
```

## Conditional on interface members

- **CS0582**: *The Conditional not valid on interface members*

**ConditionalAttribute** is not valid on an interface member.

The following sample generates CS0582:

```csharp
// CS0582.cs
// compile with: /target:library
using System.Diagnostics;
interface MyIFace
{
   [ConditionalAttribute("DEBUG")]   // CS0582
   void zz();
}
```

## IndexerName on override

- **CS0609**: *Cannot set the IndexerName attribute on an indexer marked override*

The name attribute (**IndexerNameAttribute**) cannot be applied to an indexed property that is an override. For more information, see [Indexers](../../programming-guide/indexers/index.md).

The following sample generates CS0609:

```csharp
// CS0609.cs
using System;
using System.Runtime.CompilerServices;

public class idx
{
   public virtual int this[int iPropIndex]
   {
      get
      {
         return 0;
      }
      set
      {
      }
   }
}

public class MonthDays : idx
{
   [IndexerName("MonthInfoIndexer")]   // CS0609, delete to resolve this CS0609
   public override int this[int iPropIndex]
   {
      get
      {
         return 0;
      }
      set
      {
      }
   }
}

public class test
{
   public static void Main(string[] args)
   {
   }
}
```

> [!NOTE]
> This compiler error is no longer used in Roslyn. The previous code should compile successfully.

## FieldOffset attribute required

- **CS0625**: *'field': instance field types marked with StructLayout(LayoutKind.Explicit) must have a FieldOffset attribute.*

When a struct is marked with an explicit **StructLayout** attribute, all fields in the struct must have the [FieldOffset](xref:System.Runtime.InteropServices.FieldOffsetAttribute) attribute. For more information, see [StructLayoutAttribute Class](xref:System.Runtime.InteropServices.StructLayoutAttribute).

The following sample generates CS0625:

```csharp
// CS0625.cs
// compile with: /target:library
using System;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Explicit)]
struct A
{
   public int i;   // CS0625 not static; an instance field
}

// OK
[StructLayout(LayoutKind.Explicit)]
struct B
{
   [FieldOffset(5)]
   public int i;
}
```

## Conditional on interface implementation

- **CS0629**: *Conditional member 'member' cannot implement interface member 'base class member' in type 'Type Name'*

The <xref:System.Diagnostics.ConditionalAttribute> attribute cannot be used on the implementation of an interface.

The following sample generates CS0629:

```csharp
// CS0629.cs
interface MyInterface
{
   void MyMethod();
}

public class MyClass : MyInterface
{
   [System.Diagnostics.Conditional("debug")]
   public void MyMethod()    // CS0629, remove the Conditional attribute
   {
   }

   public static void Main()
   {
   }
}
```

## StructLayout required

- **CS0636**: *The FieldOffset attribute can only be placed on members of types marked with the StructLayout(LayoutKind.Explicit)*

You must use the **StructLayout(LayoutKind.Explicit)** attribute on the struct declaration, if it contains any members marked with the **FieldOffset** attribute. For more information, see [FieldOffset](xref:System.Runtime.InteropServices.FieldOffsetAttribute).

The following sample generates CS0636:

```csharp
// CS0636.cs
using System;
using System.Runtime.InteropServices;

// To resolve the error, uncomment the following line:
// [StructLayout(LayoutKind.Explicit)]
struct Worksheet
{
   [FieldOffset(4)]public int i;   // CS0636
}

public class MainClass
{
   public static void Main ()
   {
   }
}
```

## FieldOffset on static const

- **CS0637**: *The FieldOffset attribute is not allowed on static or const fields.*

The [FieldOffset](xref:System.Runtime.InteropServices.FieldOffsetAttribute) attribute cannot be used on fields marked with [static](../keywords/static.md) or [const](../keywords/const.md).

The following sample generates CS0637:

```csharp
// CS0637.cs
using System;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Explicit)]
public class MainClass
{
   [FieldOffset(3)]   // CS0637
   public static int i;
   public static void Main ()
   {
   }
}
```

## AttributeUsage attribute

- **CS0641**: *'attribute' : attribute is only valid on classes derived from System.Attribute*

An attribute was used that can only be used on a class that derives from **System.Attribute**.

The following sample generates CS0641:

```csharp
// CS0641.cs
using System;

[AttributeUsage(AttributeTargets.All)]
public class NonAttrClass   // CS0641
// try the following line instead
// public class NonAttrClass : Attribute
{
}

class MyClass
{
   public static void Main()
   {
   }
}
```

## DefaultMember attribute

- **CS0646**: *Cannot specify the DefaultMember attribute on a type containing an indexer*

If a class or other type specifies **System.Reflection.DefaultMemberAttribute**, it cannot contain an indexer. For more information, see [Properties](../../programming-guide/classes-and-structs/properties.md).

The following sample generates CS0646:

```csharp
// CS0646.cs
// compile with: /target:library
[System.Reflection.DefaultMemberAttribute("x")]   // CS0646
class MyClass
{
   public int this[int index]   // an indexer
   {
      get
      {
         return 0;
      }
   }

   public int x = 0;
}

// OK
[System.Reflection.DefaultMemberAttribute("x")]
class MyClass2
{
   public int prop
   {
      get
      {
         return 0;
      }
   }

   public int x = 0;
}

class MyClass3
{
   public int this[int index]   // an indexer
   {
      get
      {
         return 0;
      }
   }

   public int x = 0;
}
```

## Abstract attribute class

- **CS0653**: *Cannot apply attribute class 'class' because it is abstract*

An [abstract](../keywords/abstract.md) custom attribute class cannot be used as an attribute.

The following sample generates CS0653:

```csharp
// CS0653.cs
using System;

public abstract class MyAttribute : Attribute
{
}

public class My2Attribute : MyAttribute
{
}

[My]   // CS0653
// try the following line instead
// [My2]
class MyClass
{
   public static void Main()
   {
   }
}
```

## Invalid attribute location

- **CS0657**: *'attribute modifier' is not a valid attribute location for this declaration. Valid attribute locations for this declaration are 'locations'. All attributes in this block will be ignored.*

The compiler found an attribute modifier in an invalid location. See [Attribute Targets](/dotnet/csharp/advanced-topics/reflection-and-attributes#attribute-targets) for more information.

The following sample generates CS0657:

```csharp
// CS0657.cs
// compile with: /target:library
public class TestAttribute : System.Attribute {}
[return: Test]   // CS0657 return not valid on a class
class Class1 {}
```

## Unrecognized attribute location

- **CS0658**: *'attribute modifier' is not a recognized attribute location. All attributes in this block will be ignored.*

An invalid attribute modifier was specified. See [Attribute Targets](/dotnet/csharp/advanced-topics/reflection-and-attributes#attribute-targets) for more information.

The following sample generates CS0658:

```csharp
// CS0658.cs
using System;
public class TestAttribute : Attribute {}
[badAttributeLocation: Test]   // CS0658, badAttributeLocation is invalid
class ClassTest
{
   public static void Main()
   {
   }
}
```

## Conditional with out parameter

- **CS0685**: *Conditional member 'member' cannot have an out parameter*

When using the <xref:System.Diagnostics.ConditionalAttribute> attribute on a method, that method may not have an out parameter. This is because the value of the variable used for the out parameter would not be defined in the case that the method call is compiled to nothing. To avoid this error, remove the out parameter from the conditional method declaration, or don't use the Conditional Attribute.

The following sample generates CS0685:

```csharp
// CS0685.cs
using System.Diagnostics;

class C
{
    [Conditional("DEBUG")]
    void trace(out int i)  // CS0685
    {
        i = 1;
    }
}
```

## Attributes not allowed

- **CS7014**: *Attributes are not valid in this context.*

Attributes can only be applied to specific declaration contexts. This error occurs when you attempt to apply an attribute in a location where attributes are not syntactically valid.

## Attribute parameter required

- **CS7046**: *Attribute parameter '{0}' must be specified.*

Some attributes require specific parameters to be provided. This error occurs when you apply an attribute but fail to specify a required parameter value.

## Attribute parameters required

- **CS7047**: *Attribute parameter '{0}' or '{1}' must be specified.*

Some attributes require that at least one of multiple possible parameters must be provided. This error occurs when you apply an attribute but fail to specify any of the required parameter values.

## Attribute parameter default argument

- **CS7067**: *Attribute constructor parameter '{0}' is optional, but no default parameter value was specified.*

When an attribute constructor parameter is marked as optional, it must have a default value specified. This error occurs when you declare an optional parameter in an attribute constructor without providing a default value.

## Reserved attribute

- **CS9331**: *Attribute cannot be applied manually.*

- Replace reserved attributes with the equivalent C# syntax. The compiler generates the attribute in the generated code (**CS9331**).
