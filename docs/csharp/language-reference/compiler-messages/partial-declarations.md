---
title: Compiler Errors on partial type and member declarations
description: Use this article to diagnose and correct compiler errors and warnings when you write `partial` types and `partial` members.
f1_keywords:
  - "CS0260"
  - "CS0261"
  - "CS0262"
  - "CS0263"
  - "CS0264"
  - "CS0265"
  - "CS0267"
  - "CS0282"
  - "CS0501"
  - "CS0750"
  - "CS0751"
  - "CS0754"
  - "CS0755"
  - "CS0756"
  - "CS0757"
  - "CS0759"
  - "CS0761"
  - "CS0762"
  - "CS0763"
  - "CS0764"
  - "CS1067"
  - "CS8142"
  - "CS8663"
  - "CS8796"
  - "CS8795"
  - "CS8797"
  - "CS8798"
  - "CS8799"
  - "CS8800"
  - "CS8817"
  - "CS8818"
  - "CS8863"
  - "CS8988"
  - "CS9248"
  - "CS9249"
  - "CS9250"
  - "CS9251"
  - "CS9152"
  - "CS9253"
  - "CS9254"
  - "CS9255"
  - "CS9256"
  - "CS9257"
  - "CS9258"
  - "CS9263"
  - "CS9264"
  - "CS9266"
helpviewer_keywords:
  - "CS0260"
  - "CS0261"
  - "CS0262"
  - "CS0263"
  - "CS0264"
  - "CS0265"
  - "CS0267"
  - "CS0282"
  - "CS0501"
  - "CS0750"
  - "CS0751"
  - "CS0754"
  - "CS0755"
  - "CS0756"
  - "CS0757"
  - "CS0759"
  - "CS0761"
  - "CS0762"
  - "CS0763"
  - "CS0764"
  - "CS1067"
  - "CS8142"
  - "CS8663"
  - "CS8796"
  - "CS8795"
  - "CS8797"
  - "CS8798"
  - "CS8799"
  - "CS8800"
  - "CS8817"
  - "CS8818"
  - "CS8863"
  - "CS8988"
  - "CS9248"
  - "CS9249"
  - "CS9250"
  - "CS9251"
  - "CS9152"
  - "CS9253"
  - "CS9254"
  - "CS9255"
  - "CS9256"
  - "CS9257"
  - "CS9258"
  - "CS9263"
  - "CS9266"
ms.date: 11/06/2024
---
# Errors and warnings related to `partial` type and `partial` member declarations

There are numerous *errors* related to `partial` type and `partial` member declarations:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->
- [**CS0260**](#partial-types): *Missing partial modifier on declaration of type; another partial declaration of this type exists*
- [**CS0261**](#partial-types): *Partial declarations of type must be all classes, all structs, or all interfaces*
- [**CS0262**](#partial-types): *Partial declarations of type have conflicting accessibility modifiers*
- [**CS0263**](#partial-types): *Partial declarations of type must not specify different base classes*
- [**CS0264**](#partial-types): *Partial declarations of type must have the same type parameter names in the same order*
- [**CS0265**](#partial-types): *Partial declarations of type have inconsistent constraints for type parameter 'type parameter'*
- [**CS0267**](#partial-types): *The '`partial`' modifier can only appear immediately before '`class`', '`record`', '`struct`', '`interface`', or a method or property return type.*
- [**CS0282**](#partial-types): *There is no defined ordering between fields in multiple declarations of partial class or struct 'type'. To specify an ordering, all instance fields must be in the same declaration.*
- [**CS0501**](#partial-methods): *'member function' must declare a body because it is not marked `abstract`, `extern`, or `partial`*
- [**CS0750**](#partial-members): *A partial member cannot have the '`abstract`' modifier.*
- [**CS0751**](#partial-members): *A partial member must be declared in a partial `class` or partial `struct`*
- [**CS0754**](#partial-members): *A partial member may not explicitly implement an interface method.*
- [**CS0755**](#partial-methods): *Both partial method declarations must be extension methods or neither may be an extension method.*
- [**CS0756**](#partial-methods): *A partial method may not have multiple defining declarations.*
- [**CS0757**](#partial-methods): *A partial method may not have multiple implementing declarations.*
- [**CS0759**](#partial-methods): *No defining declaration found for implementing declaration of partial method.*
- [**CS0761**](#partial-methods): *Partial method declarations of `method<T>` have inconsistent type parameter constraints.*
- [**CS0762**](#partial-methods): *Cannot create delegate from method because it is a partial method without an implementing declaration*
- [**CS0763**](#partial-members): *Both partial method declarations must be `static` or neither may be `static`.*
- [**CS0764**](#partial-members): *Both partial method declarations must be `unsafe` or neither may be `unsafe`*
- [**CS1067**](#partial-methods): *Partial declarations must have the same type parameter names and variance modifiers in the same order.*
- [**CS8142**](#partial-members): *Both partial member declarations must use the same tuple element names.*
- [**CS8663**](#partial-members): *Both partial member declarations must be readonly or neither may be readonly*
- [**CS8796**](#partial-methods): *Partial method must have accessibility modifiers because it has a non-void return type.*
- [**CS8795**](#partial-methods): *Partial member must have an implementation part because it has accessibility modifiers.*
- [**CS8797**](#partial-methods): *Partial method  must have accessibility modifiers because it has '`out`' parameters.*
- [**CS8798**](#partial-methods): *Partial method must have accessibility modifiers because it has a '`virtual`', '`override`', '`sealed`', '`new`', or '`extern`' modifier.*
- [**CS8799**](#partial-members): *Both partial member declarations must have identical accessibility modifiers.*
- [**CS8800**](#partial-members): *Both partial member declarations must have identical combinations of `virtual`, `override`, `sealed`, and `new` modifiers.*
- [**CS8817**](#partial-methods): *Both partial method declarations must have the same return type.*
- [**CS8818**](#partial-members): *Partial member declarations must have matching `ref` return values.*
- [**CS8863**](#partial-types): *Only a single partial type declaration may have a parameter list*
- [**CS8988**](#partial-members): *The `scoped` modifier of parameter doesn't match partial definition.*
- [**CS9248**](#partial-properties): *Partial property must have an implementation part.*
- [**CS9249**](#partial-properties): *Partial property must have a definition part.*
- [**CS9250**](#partial-properties): *A partial property may not have multiple defining declarations, and cannot be an auto-property.*
- [**CS9251**](#partial-properties): *A partial property may not have multiple implementing declarations*
- [**CS9252**](#partial-properties): *Property accessor must be implemented because it is declared on the definition part*
- [**CS9253**](#partial-properties): *Property accessor does not implement any accessor declared on the definition part*
- [**CS9254**](#partial-properties): *Property accessor must match the definition part*
- [**CS9255**](#partial-properties): *Both partial property declarations must have the same type.*
- [**CS9256**](#partial-properties): *Partial property declarations have signature differences.*
- [**CS9257**](#partial-properties): *Both partial property declarations must be required or neither may be required*
- [**CS9258**](#field-backed-properties): *In this language version, the '`field`' keyword binds to a synthesized backing field for the property. To avoid generating a synthesized backing field, and to refer to the existing member, use '`this.field`' or '`@field`' instead.*
- [**CS9263**](#field-backed-properties): *A partial property cannot have an initializer on both the definition and implementation.*

The following warnings can be generated for field backed properties:

- [**CS9264**](#field-backed-properties): *Non-nullable property must contain a non-null value when exiting constructor. Consider adding the 'required' modifier, or declaring the property as nullable, or adding '`[field: MaybeNull, AllowNull]`' attributes.**
- [**CS9266**](#field-backed-properties): *One accessor of property  should use '`field`' because the other accessor is using it.*

The following sections explain the cause and fixes for these errors and warnings.

## Partial types

- [**CS0260**](#partial-types): *Missing partial modifier on declaration of type; another partial declaration of this type exists*
- [**CS0261**](#partial-types): *Partial declarations of type must be all classes, all structs, or all interfaces*
- [**CS0262**](#partial-types): *Partial declarations of type have conflicting accessibility modifiers*
- [**CS0263**](#partial-types): *Partial declarations of type must not specify different base classes*
- [**CS0264**](#partial-types): *Partial declarations of type must have the same type parameter names in the same order*
- [**CS0265**](#partial-types): *Partial declarations of type have inconsistent constraints for type parameter 'type parameter'*
- [**CS0267**](#partial-types): *The '`partial`' modifier can only appear immediately before '`class`', '`record`', '`struct`', '`interface`', or a method or property return type.*
- [**CS8863**](#partial-types): *Only a single partial type declaration may have a parameter list*

Your partial type declaration can cause the compiler to emit the following warning:

- [**CS0282**](#partial-types): *There is no defined ordering between fields in multiple declarations of partial `class` or `struct` 'type'. To specify an ordering, all instance fields must be in the same declaration.*

For any partial type, the `partial` keyword must immediately precede `class`, `record`, `struct`, or `interface`. The compiler emits an error if it appears in any other order. In addition:

- All declarations of a partial type must match in terms of the type (`class`, `struct`, `record class`, `record struct`, `readonly struct`, or `readonly record struct`).
- All declarations must include the `partial` modifier.
- The declarations for a generic partial type must include the same type parameters in the same order.

Some parts of the declaration aren't required to be repeated on all declarations for a type. However, if these elements are repeated on multiple `partial` declarations, they must match:

- Any access modifiers, such as `public`.
- Any base class or implemented interfaces.
- Any constraints on type parameters.

A primary constructor can be declared on at most one declaration for a partial type.

The compiler warns you if you have multiple fields declared in multiple files for a `partial struct` type. If the layout order is important, you must declare all fields in the same file. If order doesn't matter, you can use the <xref:System.Runtime.InteropServices.StructLayoutAttribute?displayProperty=fullName> with the <xref:System.Runtime.InteropServices.LayoutKind.Auto?displayProperty=nameWithType> value.

## Partial members

- **CS0750**: *A partial member cannot have the '`abstract`' modifier.*
- **CS0751**: *A partial member must be declared in a partial `class` or partial `struct`*
- **CS0754**: *A partial member may not explicitly implement an interface method.*
- **CS0763**: *Both partial method declarations must be `static` or neither may be `static`.*
- **CS0764**: *Both partial method declarations must be `unsafe` or neither may be `unsafe`*
- **CS8142**: *Both partial member declarations must use the same tuple element names.*
- **CS8663**: *Both partial member declarations must be readonly or neither may be readonly*
- **CS8799**: *Both partial member declarations must have identical accessibility modifiers.*
- **CS8800**: *Both partial member declarations must have identical combinations of `virtual`, `override`, `sealed`, and `new` modifiers.*
- **CS8818**: *Partial member declarations must have matching `ref` return values.*
- **CS8988**: *The `scoped` modifier of parameter doesn't match partial definition.*

Partial members have two declarations. The declaration without an implementation is the *declaring declaration*. The declaration with the implementation is the *implementing declaration*. Partial members are allowed only in a `partial` type. Partial members can't be `abstract`. Partial members can't explicitly implement an interface. Both declarations of a partial member must have identical signatures. For example, either both or neither declarations can include the `static` or `unsafe` modifiers.

## Partial methods

- **CS0501**: *'member function' must declare a body because it is not marked `abstract`, `extern`, or `partial`*
- **CS0755**: *Both partial method declarations must be extension methods or neither may be an extension method.*
- **CS0756**: *A partial method may not have multiple defining declarations.*
- **CS0757**: *A partial method may not have multiple implementing declarations.*
- **CS0759**: *No defining declaration found for implementing declaration of partial method.*
- **CS0761**: *Partial method declarations of `method<T>` have inconsistent type parameter constraints.*
- **CS0762**: *Cannot create delegate from method because it is a partial method without an implementing declaration*
- **CS1067**: *Partial declarations must have the same type parameter names and variance modifiers in the same order.*
- **CS8796**: *Partial method must have accessibility modifiers because it has a non-void return type.*
- **CS8795**: *Partial member must have an implementation part because it has accessibility modifiers.*
- **CS8797**: *Partial method  must have accessibility modifiers because it has '`out`' parameters.*
- **CS8798**: *Partial method must have accessibility modifiers because it has a '`virtual`', '`override`', '`sealed`', '`new`', or '`extern`' modifier.*
- **CS8817**: *Both partial method declarations must have the same return type.*

Certain `partial` method declarations don't require an *implementing declaration*. That is, if the member returns `void`, doesn't declare any access modifiers (including the default `private` modifier), and doesn't include any of the `virtual`, `override`, `sealed`, or `new` modifiers. Otherwise, any partial method must include both the declaring and implementing declarations.

When a partial method includes an implementing declaration, both declarations must be identical. Exactly one implementing declaration can be defined.

## Partial properties

The following errors indicate mistakes in your partial property or indexer declarations:

- **CS9248**: *Partial property must have an implementation part.*
- **CS9249**: *Partial property must have a definition part.*
- **CS9250**: *A partial property may not have multiple defining declarations, and cannot be an auto-property.*
- **CS9251**: *A partial property may not have multiple implementing declarations*
- **CS9252**: *Property accessor must be implemented because it is declared on the definition part*
- **CS9253**: *Property accessor does not implement any accessor declared on the definition part*
- **CS9254**: *Property accessor must match the definition part*
- **CS9255**: *Both partial property declarations must have the same type.*
- **CS9257**: *Both partial property declarations must be required or neither may be required*

The following warning indicates a signature difference in the declaring and implementing declarations in a partial property:

- **CS9256**: *Partial property declarations have signature differences.*

A partial property or indexer must have both a *declaring declaration* and an *implementing declaration*. The signatures for both declarations must match. Because the *declaring declaration* uses the same syntax as an automatically implemented property, the *implementing declaration* can't be an automatically implemented property. The accessors must have at least one accessor body. Beginning in C# 13, you can use the [`field`](../keywords/field.md) keyword to declare one accessor using a concise syntax:

```csharp
public partial int ImplementingDeclaration { get => field; set; }
```

## field backed properties

- **CS9258**: *In this language version, the '`field`' keyword binds to a synthesized backing field for the property. To avoid generating a synthesized backing field, and to refer to the existing member, use '`this.field`' or '`@field`' instead.*
- **CS9263**: *A partial property cannot have an initializer on both the definition and implementation.*
- **CS9264**: *Non-nullable property must contain a non-null value when exiting constructor. Consider adding the 'required' modifier, or declaring the property as nullable, or adding '`[field: MaybeNull, AllowNull]`' attributes.**
- **CS9266**: *One accessor of property  should use '`field`' because the other accessor is using it.*

[!INCLUDE[field-preview](../../includes/field-preview.md)]

Beginning with C# 13, the preview feature, `field` backed properties allows you to access the compiler synthesized backing field for a property. **CS9258** indicates that you have a variable named `field`, which can be hidden by the contextual keyword `field`.

**CS9263** indicates that your declaring declaration includes an implementation. That implementation might be accessing the compiler synthesized backing field for that property. **CS9264** indicates that the your use of `field` assumes a non-nullable backing field while the property declaration is nullable. The compiler assumes both the backing field and the property have the same nullability. You need to add the `[field:MaybeNull, AllowNull]` attribute to the property declaration to indicate that the `field` value should be considered nullable. **CS9266** indicates that one of a properties accessors uses the `field` keyword, but the other uses a hand-declared backing field. The warning indicates you may have done that by accident.
