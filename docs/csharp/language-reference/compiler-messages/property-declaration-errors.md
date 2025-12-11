---
title: Compiler Errors on partial type and member declarations
description: Use this article to diagnose and correct compiler errors and warnings when you write `partial` types and `partial` members.
f1_keywords:
  - "CS0200"
  - "CS0545"
  - "CS0571"
  - "CS0840"
  - "CS1014"
  - "CS1043"
  - "CS8050"
  - "CS8145"
  - "CS9029"
  - "CS9030"
  - "CS9031"
  - "CS9032"
  - "CS9033"
  - "CS9034"
  - "CS9035"
  - "CS9036"
  - "CS9037"
  - "CS9038"
  - "CS9039"
  - "CS9040"
  - "CS9042"
  - "CS9045"
  - "CS9258"
  - "CS9263"
  - "CS9264"
  - "CS9266"
  - "CS9273"
helpviewer_keywords:
  - "CS0200"
  - "CS0545"
  - "CS0571"
  - "CS0840"
  - "CS1014"
  - "CS1043"
  - "CS8050"
  - "CS8145"
  - "CS9029"
  - "CS9030"
  - "CS9031"
  - "CS9032"
  - "CS9033"
  - "CS9034"
  - "CS9035"
  - "CS9036"
  - "CS9037"
  - "CS9038"
  - "CS9039"
  - "CS9040"
  - "CS9042"
  - "CS9045"
  - "CS9258"
  - "CS9263"
  - "CS9264"
  - "CS9266"
  - "CS9273"
ms.date: 12/11/2025
---
# Errors and warnings related to property declarations

There are numerous *errors* related to property declarations:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->
- [**CS0200**](#cs0200---read-only-properties): *Property or indexer 'property' cannot be assigned to -- it is read only*
- [**CS0545**](#cs0545---property-accessor-overrides): *'function' : cannot override because 'property' does not have an overridable get accessor*
- [**CS0571**](#cs0571---explicit-accessor-calls): *'function' : cannot explicitly call operator or accessor*
- [**CS0840**](#cs0840---auto-implemented-property-accessors): *'Property name' must declare a body because it is not marked abstract or extern. Automatically implemented properties must define both get and set accessors.*
- [**CS1014**](#cs1014---property-accessor-declarations): *A get or set accessor expected*
- [**CS1043**](#cs1043---property-accessor-syntax): *{ or ; expected*
- **CS8050**: *Only auto-implemented properties, or properties that use the 'field' keyword, can have initializers.*
- [**CS8145**](#cs8145---ref-returning-properties): *Auto-implemented properties cannot return by reference*
- **CS9029**: *Types and aliases cannot be named 'required'.*
- **CS9030**: *Member must be required because it overrides required member.*
- **CS9031**: *Required member cannot be hidden by derived member.*
- **CS9032**: *Required member cannot be less visible or have a setter less visible than the containing type.*
- **CS9033**: *Do not use '`System.Runtime.CompilerServices.RequiredMemberAttribute'`. Use the 'required' keyword on required fields and properties instead.*
- **CS9034**: *Required member must be settable.*
- **CS9035**: *Required member must be set in the object initializer or attribute constructor.*
- [**CS9036**](#cs9036---required-member-initialization): *Required member 'memberName' must be assigned a value, it cannot use a nested member or collection initializer.*
- **CS9037**: *he required members list is malformed and cannot be interpreted.*
- **CS9038**: *The required members list for the base type is malformed and cannot be interpreted. To use this constructor, apply the '`SetsRequiredMembers`' attribute*.
- **CS9039**: *This constructor must add '`SetsRequiredMembers`' because it chains to a constructor that has that attribute.*
- **CS9040**: *Type cannot satisfy the '`new()`' constraint on parameter in the generic type or or method because it has required members.*
- **CS9042**: *Required member should not be attributed with '`ObsoleteAttribute`' unless the containing type is obsolete or all constructors are obsolete.*
- **CS9045**: *Required members are not allowed on the top level of a script or submission.*
- [**CS9258**](#field-backed-properties): *In this language version, the '`field`' keyword binds to a synthesized backing field for the property. To avoid generating a synthesized backing field, and to refer to the existing member, use '`this.field`' or '`@field`' instead.*
- [**CS9263**](#field-backed-properties): *A partial property cannot have an initializer on both the definition and implementation.*

The following warnings can be generated for field backed properties:

- [**CS9264**](#field-backed-properties): *Non-nullable property must contain a non-null value when exiting constructor. Consider adding the 'required' modifier, or declaring the property as nullable, or adding '`[field: MaybeNull, AllowNull]`' attributes.**
- [**CS9266**](#field-backed-properties): *One accessor of property  should use '`field`' because the other accessor is using it.*
- [**CS9273**](#field-backed-properties): *In this language version, '`field`' is a keyword within a property accessor. Rename the variable or use the identifier '`@field`' instead.*

The following sections explain the cause and fixes for these errors and warnings.

## field backed properties

- **CS9258**: *In this language version, the '`field`' keyword binds to a synthesized backing field for the property. To avoid generating a synthesized backing field, and to refer to the existing member, use '`this.field`' or '`@field`' instead.*
- **CS9263**: *A partial property cannot have an initializer on both the definition and implementation.*
- **CS9264**: *Non-nullable property must contain a non-null value when exiting constructor. Consider adding the 'required' modifier, or declaring the property as nullable, or adding '`[field: MaybeNull, AllowNull]`' attributes.**
- **CS9266**: *One accessor of property  should use '`field`' because the other accessor is using it.*
- **CS9273**: *In this language version, '`field`' is a keyword within a property accessor. Rename the variable or use the identifier '`@field`' instead.*

Beginning with C# 14, `field` backed properties allow you to access the compiler synthesized backing field for a property. **CS9258** or **CS9273** indicate that you have a variable named `field`, which can be hidden by the contextual keyword `field`.

**CS9263** indicates that your declaring declaration includes an implementation. That implementation might be accessing the compiler synthesized backing field for that property. **CS9264** indicates that your use of `field` assumes a non-nullable backing field while the property declaration is nullable. The compiler assumes both the backing field and the property have the same nullability. You need to add the `[field:MaybeNull, AllowNull]` attribute to the property declaration to indicate that the `field` value should be considered nullable. **CS9266** indicates that one of a property's accessors uses the `field` keyword, but the other uses a hand-declared backing field. The warning indicates that might be a mistake.

## CS0200 - Read-only properties

- **CS0200**: *Property or indexer 'property' cannot be assigned to -- it is read only*

An attempt was made to assign a value to a [property](../../programming-guide/classes-and-structs/using-properties.md), but the property does not have a set accessor or the assignment was outside of the constructor. Resolve the error by adding a set accessor. For more information, see [How to declare and use read-write properties](../../programming-guide/classes-and-structs/how-to-declare-and-use-read-write-properties.md).

The following sample generates CS0200:

```csharp
// CS0200.cs
public class Example
{
    private int _mi;
    int I
    {
        get
        {
            return _mi;
        }
        // uncomment the set accessor and declaration for _mi
        /*
        set
        {
            _mi = value;
        }
        */
    }

    public static void Main()
    {  
        Example example = new Example();
        example.I = 9;   // CS0200
    }
}  
```

The following sample uses [automatically implemented properties](../../programming-guide/classes-and-structs/auto-implemented-properties.md) and [object initializers](../../programming-guide/classes-and-structs/object-and-collection-initializers.md) and still generates CS0200:

```csharp
// CS0200.cs
public class Example
{
    int I
    {
        get;
        // uncomment the set accessor and declaration
        //set;
    }

    public static void Main()
    {  
        var example = new Example
        {
            I = 9   // CS0200
        };
    }
}
```

To assign to a property or indexer 'property' that's read-only, add a set accessor or assign the value in the object's constructor.

```csharp
public class Example
{
    int I { get; }

    public Example()
    {
        I = -7;
    }
}
```

## CS9036 - Required member initialization

- **CS9036**: *Required member 'memberName' must be assigned a value, it cannot use a nested member or collection initializer.*

When initializing an object with a `required` member, you must directly assign the member a value. You cannot use a nested member or collection initializer to set properties of the `required` member without first instantiating it.

The following sample generates CS9036:

```csharp
class C
{
    public string? Prop { get; set; }
}

class Program
{
    public required C C { get; set; }

    static void Main()
    {
        var program = new Program()
        {
            // error CS9036: Required member 'Program.C' must be assigned a value, it cannot use a nested member or collection initializer.
            C = { Prop = "a" }
        };
    }
}
```

To fix this error, directly assign a new instance of the required property and initialize its members:

```csharp
class C
{
    public string? Prop { get; set; }
}

class Program
{
    public required C C { get; set; }

    static void Main()
    {
        var program = new Program()
        {
            // Correct: Assign a new instance of C and then initialize its Prop property
            C = new C { Prop = "a" }
        };
    }
}
```

For more information on required members, see the [required modifier](../keywords/required.md) reference article and [Object and Collection Initializers](../../programming-guide/classes-and-structs/object-and-collection-initializers.md) guide.

## CS0840 - Auto-implemented property accessors

- **CS0840**: *'Property name' must declare a body because it is not marked abstract or extern. Automatically implemented properties must define both get and set accessors.*

Unless a regular property is marked as `abstract` or `extern`, or is a member of a `partial` type, it must supply a body. Automatically implemented properties do not provide accessor bodies, but they must specify both accessors. To create a read-only automatically implemented property, make the set accessor `private`.

The following example generates CS0840:

```csharp
// cs0840.cs
// Compile with /target:library
using System;
class Test
{
    public int myProp { get; } // CS0840

    // to create a read-only property
    // try the following line instead
    public int myProp2 { get; private set; }

}
```

Supply the missing body or accessor or else use the [abstract](../keywords/abstract.md), [extern](../keywords/extern.md), or [partial (Type)](../keywords/partial-type.md) modifiers on it and/or its enclosing type.

For more information, see [Automatically implemented properties](../../programming-guide/classes-and-structs/auto-implemented-properties.md).

## CS0545 - Property accessor overrides

- **CS0545**: *'function' : cannot override because 'property' does not have an overridable get accessor*

A try was made to define an override for a property accessor when the base class has no such definition to override. You can resolve this error by:

- Adding a `set` accessor in the base class.

- Removing the `set` accessor from the derived class.

- Hiding the base class property by adding the [new](../keywords/new-modifier.md) keyword to a property in a derived class.

- Making the base class property [virtual](../keywords/virtual.md).

The following sample generates CS0545:

```csharp
// CS0545.cs
// compile with: /target:library
// CS0545
public class a
{
   public virtual int i
   {
      set {}

      // Uncomment the following line to resolve.
      // get { return 0; }
   }
}

public class b : a
{
   public override int i
   {
      get { return 0; }
      set {}   // OK
   }
}
```

For more information, see [Using Properties](../../programming-guide/classes-and-structs/using-properties.md).

## CS8145 - Ref-returning properties

- **CS8145**: *Auto-implemented properties cannot return by reference*

Automatically implemented properties are not guaranteed to have a member or variable that can be referenced and thus do not support return by reference.

The following sample generates CS8145:

```csharp
// CS8145.cs (4,13)

public class C
{
    public ref int Property1 { get; }
}
```

If the property can be implemented through a backing field, then refactoring to use a backing field and `ref`-returning the field will correct this error:

```csharp
public class C
{
    private int property1;

    public ref int Property1 => ref property1;
}
```

If the property cannot be implemented through a backing field, then removing the `ref` modifier from the property corrects this error:

```csharp
public class C
{
    public int Property1 { get; }
}
```

## CS0571 - Explicit accessor calls

- **CS0571**: *'function' : cannot explicitly call operator or accessor*

Certain operators have internal names. For example, **op_Increment** is the internal name of the ++ operator. You should not use or explicitly call such method names.

The following sample generates CS0571:

```csharp
// CS0571.cs
public class MyClass
{
   public static MyClass operator ++ (MyClass c)
   {
      return null;
   }

   public static int prop
   {
      get
      {
         return 1;
      }
      set
      {
      }
   }

   public static void Main()
   {
      op_Increment(null);   // CS0571
      // use the increment operator as follows
      // MyClass x = new MyClass();
      // x++;

      set_prop(1);      // CS0571
      // try the following line instead
      // prop = 1;
   }
}
```

## CS1043 - Property accessor syntax

- **CS1043**: *{ or ; expected*

A property accessor was declared incorrectly. For more information, see [Using Properties](../../programming-guide/classes-and-structs/using-properties.md).

The following sample generates CS1043:

```csharp
// CS1043.cs
// compile with: /target:library
public class MyClass
{
   public int DoSomething
   {
      get return 1;   // CS1043
      set {}
   }

   // OK
   public int DoSomething2
   {
      get { return 1;}
   }
}
```

## CS1014 - Property accessor declarations

- **CS1014**: *A get or set accessor expected*

A method declaration was found in a property declaration. You can only declare `get` and `set` methods in a property.

For more information on properties, see [Using Properties](../../programming-guide/classes-and-structs/using-properties.md).

The following sample generates CS1014:

```csharp
// CS1014.cs
// compile with: /target:library
class Sample
{
   public int TestProperty
   {
      get
      {
         return 0;
      }
      int z;   // CS1014  not get or set
   }
}
```
