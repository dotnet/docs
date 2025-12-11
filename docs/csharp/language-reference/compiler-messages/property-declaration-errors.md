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
  - "CS8051"
  - "CS8053"
  - "CS8145"
  - "CS8147"
  - "CS8341"
  - "CS8657"
  - "CS8658"
  - "CS8659"
  - "CS8660"
  - "CS8661"
  - "CS8664"
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
  - "CS8051"
  - "CS8053"
  - "CS8145"
  - "CS8147"
  - "CS8341"
  - "CS8657"
  - "CS8658"
  - "CS8659"
  - "CS8660"
  - "CS8661"
  - "CS8664"
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
ai-usage: ai-assisted
---
# Errors and warnings related to property declarations

There are numerous *errors* related to property declarations:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->
- [**CS0200**](#readonly-properties): *Property or indexer 'property' cannot be assigned to -- it is read only*
- [**CS0545**](#property-accessor-syntax): *'function' : cannot override because 'property' does not have an overridable get accessor*
- [**CS0571**](#property-accessor-syntax): *'function' : cannot explicitly call operator or accessor*
- [**CS0840**](#auto-implemented-properties): *'Property name' must declare a body because it is not marked abstract or extern. Automatically implemented properties must define both get and set accessors.*
- [**CS1014**](#auto-implemented-properties): *A get or set accessor expected*
- [**CS1043**](#property-accessor-syntax): *{ or ; expected*
- [**CS8050**](#property-initializers): *Only auto-implemented properties, or properties that use the 'field' keyword, can have initializers*
- [**CS8051**](#property-initializers): *Auto-implemented properties must have get accessors*
- [**CS8053**](#property-initializers): *Instance properties in interfaces cannot have initializers*
- [**CS8145**](#ref-returning-properties): *Auto-implemented properties cannot return by reference*
- [**CS8147**](#ref-returning-properties): *Properties which return by reference cannot have set accessors*
- [**CS8341**](#readonly-properties): *Auto-implemented instance properties in readonly structs must be readonly*
- [**CS8657**](#readonly-properties): *Static member cannot be marked 'readonly'*
- [**CS8658**](#readonly-properties): *Auto-implemented 'set' accessor cannot be marked 'readonly'*
- [**CS8659**](#readonly-properties): *Auto-implemented property cannot be marked 'readonly' because it has a 'set' accessor*
- [**CS8660**](#readonly-properties): *Cannot specify 'readonly' modifiers on both property and its accessor*
- [**CS8661**](#readonly-properties): *Cannot specify 'readonly' modifiers on both accessors of property*
- [**CS8664**](#readonly-properties): *'readonly' can only be used on accessors if property has both get and set*
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

## Property initializers

- **CS8050**: *Only auto-implemented properties, or properties that use the 'field' keyword, can have initializers*
- **CS8051**: *Auto-implemented properties must have get accessors*
- **CS8053**: *Instance properties in interfaces cannot have initializers*

Property initializers provide a concise syntax to initialize properties at the point of declaration. However, only certain kinds of properties support initializers, and there are specific rules about which properties can have them.

You can add an initializer to an [auto-implemented property](../../programming-guide/classes-and-structs/auto-implemented-properties.md) or to a property that uses the [`field` keyword](../../programming-guide/classes-and-structs/properties.md) to access the compiler-synthesized backing field. If you attempt to initialize a property with explicit accessor implementations that don't use `field`, you'll encounter **CS8050**. To resolve this error, either convert the property to use auto-implemented syntax, use the `field` keyword in the accessor, or remove the initializer and assign the value in a constructor instead.

Auto-implemented properties must include a `get` accessor to support initialization (**CS8051**). This requirement ensures that the property value can be read after initialization. If you need a write-only property, you must implement the accessors explicitly without using auto-implemented syntax.

Interface properties cannot have instance property initializers (**CS8053**), as interfaces define contracts rather than implementation details. Instance properties in interfaces declare the structure that implementing classes must provide, but they cannot specify initial values. If you need default values for interface properties, consider using default interface methods (available in C# 8.0 and later) to provide the implementation.

For more information on properties, see [Properties](../../programming-guide/classes-and-structs/properties.md) and [Auto-Implemented Properties](../../programming-guide/classes-and-structs/auto-implemented-properties.md).

## field backed properties

- **CS9258**: *In this language version, the '`field`' keyword binds to a synthesized backing field for the property. To avoid generating a synthesized backing field, and to refer to the existing member, use '`this.field`' or '`@field`' instead.*
- **CS9263**: *A partial property cannot have an initializer on both the definition and implementation.*
- **CS9264**: *Non-nullable property must contain a non-null value when exiting constructor. Consider adding the 'required' modifier, or declaring the property as nullable, or adding '`[field: MaybeNull, AllowNull]`' attributes.**
- **CS9266**: *One accessor of property  should use '`field`' because the other accessor is using it.*
- **CS9273**: *In this language version, '`field`' is a keyword within a property accessor. Rename the variable or use the identifier '`@field`' instead.*

Beginning with C# 14, `field` backed properties allow you to access the compiler synthesized backing field for a property. **CS9258** or **CS9273** indicate that you have a variable named `field`, which can be hidden by the contextual keyword `field`.

**CS9263** indicates that your declaring declaration includes an implementation. That implementation might be accessing the compiler synthesized backing field for that property. **CS9264** indicates that your use of `field` assumes a non-nullable backing field while the property declaration is nullable. The compiler assumes both the backing field and the property have the same nullability. You need to add the `[field:MaybeNull, AllowNull]` attribute to the property declaration to indicate that the `field` value should be considered nullable. **CS9266** indicates that one of a property's accessors uses the `field` keyword, but the other uses a hand-declared backing field. The warning indicates that might be a mistake.

## Readonly properties

- **CS0200**: *Property or indexer 'property' cannot be assigned to -- it is read only*
- **CS8341**: *Auto-implemented instance properties in readonly structs must be readonly*
- **CS8657**: *Static member cannot be marked 'readonly'*
- **CS8658**: *Auto-implemented 'set' accessor cannot be marked 'readonly'*
- **CS8659**: *Auto-implemented property cannot be marked 'readonly' because it has a 'set' accessor*
- **CS8660**: *Cannot specify 'readonly' modifiers on both property and its accessor*
- **CS8661**: *Cannot specify 'readonly' modifiers on both accessors of property*
- **CS8664**: *'readonly' can only be used on accessors if property has both get and set*

Properties can be read-only (lacking a `set` accessor) or marked with the `readonly` modifier. These errors relate to improper assignments to read-only properties and incorrect usage of the `readonly` modifier.

A property without a `set` accessor (or with a `set` accessor that's inaccessible in the current context) is read-only and cannot be assigned outside of its declaring constructor (**CS0200**). To resolve this, either add a `set` accessor to make the property writable, use an [init accessor](../keywords/init.md) to allow initialization, or move the assignment into the object's constructor. For more information, see [Properties](../../programming-guide/classes-and-structs/properties.md).

When using the `readonly` modifier on properties and accessors (introduced in C# 8.0 for struct members), several rules must be followed. Auto-implemented instance properties within a `readonly struct` must themselves be `readonly` (**CS8341**), ensuring the struct's immutability contract. Static members cannot be marked `readonly` (**CS8657**), as the `readonly` modifier only applies to instance members of structs. 

For auto-implemented properties, you cannot mark a `set` accessor as `readonly` (**CS8658**), and if a property has a `set` accessor, the property itself cannot be marked `readonly` (**CS8659**). These restrictions exist because `set` accessors modify state by definition, which contradicts the purpose of `readonly`. Instead, use `init` accessors for properties that should be settable only during initialization.

The `readonly` modifier cannot appear in multiple places on the same property (**CS8660**, **CS8661**, **CS8664**). If you want to mark accessors as `readonly`, place the modifier on the individual accessors, not the property declaration itself. However, both a `get` and `set` accessor must exist if you're marking individual accessors as `readonly` (**CS8664**). You cannot mark both the property and its accessors as `readonly` (**CS8660**), nor can you mark both accessors individually as `readonly` (**CS8661**)—instead, mark the property itself as `readonly`.

For more information, see [readonly instance members](../../language-reference/builtin-types/struct.md#readonly-instance-members) and [Properties](../../programming-guide/classes-and-structs/properties.md).

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

## Auto-implemented properties

- **CS0840**: *'Property name' must declare a body because it is not marked abstract or extern. Automatically implemented properties must define both get and set accessors.*
- **CS1014**: *A get or set accessor expected*

[Auto-implemented properties](../../programming-guide/classes-and-structs/auto-implemented-properties.md) provide a concise syntax for declaring properties without explicitly implementing accessor bodies. However, they must follow specific structural requirements.

An auto-implemented property must include both `get` and `set` accessors, or use appropriate modifiers (**CS0840**). If you want a read-only auto-implemented property, make the `set` accessor `private` rather than omitting it entirely. Alternatively, if the property is marked as `abstract`, `extern`, or is part of a `partial` type declaration, you don't need to provide accessor bodies. If you need full control over the accessor implementation, provide explicit accessor bodies instead of using auto-implemented syntax.

Within a property declaration, only `get` and `set` accessor declarations are allowed (**CS1014**). You cannot declare fields, methods, or other members inside a property body. If you need additional logic or storage, implement the accessors explicitly with a backing field, or consider whether the member should be declared outside the property.

For more information, see [Properties](../../programming-guide/classes-and-structs/properties.md) and [Auto-Implemented Properties](../../programming-guide/classes-and-structs/auto-implemented-properties.md).

## Property accessor syntax

- **CS0545**: *'function' : cannot override because 'property' does not have an overridable get accessor*
- **CS0571**: *'function' : cannot explicitly call operator or accessor*
- **CS1043**: *{ or ; expected*

Property accessors must follow specific syntax rules and usage patterns. These errors indicate violations of accessor declaration syntax or improper attempts to call accessor methods directly.

When overriding a property in a derived class, you can only override accessors that exist and are overridable in the base class (**CS0545**). If the base class property has only a `set` accessor (or only a `get` accessor), you cannot override a `get` accessor (or `set` accessor) that doesn't exist. To resolve this, either add the missing accessor to the base class and mark it `virtual`, remove the problematic accessor from the derived class, or use the `new` keyword to hide the base class property instead of overriding it. For more information, see [Inheritance](../../fundamentals/object-oriented/inheritance.md) and [Using Properties](../../programming-guide/classes-and-structs/using-properties.md).

Property accessors are compiled to methods with special internal names, such as `get_PropertyName` and `set_PropertyName` (**CS0571**). These methods should never be called explicitly in your code. Instead, access properties using standard property syntax (`obj.Property` or `obj.Property = value`). Similarly, operators like `++` are compiled to methods like `op_Increment`, which should also not be called directly.

Property accessor declarations must use proper syntax (**CS1043**). Each accessor body must be enclosed in braces `{ }`, or for expression-bodied members, use the `=>` syntax. Auto-implemented properties should end with a semicolon after the accessor list. If you see this error, check that your accessor syntax matches one of the valid forms shown in the [properties documentation](../../programming-guide/classes-and-structs/properties.md).

## Ref-returning properties

- **CS8145**: *Auto-implemented properties cannot return by reference*
- **CS8147**: *Properties which return by reference cannot have set accessors*

[Ref returns](../../programming-guide/classes-and-structs/ref-returns.md) allow properties to return a reference to a variable rather than a copy of its value. However, ref-returning properties have specific restrictions.

Auto-implemented properties cannot return by reference (**CS8145**) because the compiler-generated backing field is private and inaccessible to callers, making it impossible to return a reference to it. To create a ref-returning property, you must explicitly implement the property with a backing field and use the `ref` keyword in the return expression (`=> ref backingField`). Alternatively, if you don't need ref-return semantics, remove the `ref` modifier from the property declaration.

Ref-returning properties cannot have `set` accessors (**CS8147**) because the reference itself provides direct write access to the underlying storage. When a property returns a reference, callers can modify the value directly through that reference, making a separate `set` accessor redundant and potentially confusing. If you need a ref-returning property, remove the `set` accessor and rely on the reference for both read and write operations.

For more information, see [ref returns and ref locals](../../language-reference/statements/jump-statements.md#ref-returns) and [Properties](../../programming-guide/classes-and-structs/properties.md).

## Readonly properties
