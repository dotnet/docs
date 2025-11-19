---
title: Resolve errors and warnings related to user-defined operator declarations
description: This article helps you diagnose and correct compiler errors and warnings when you declare user-defined operators in your types
f1_keywords:
  - "CS0056"
  - "CS0057"
  - "CS0215"
  - "CS0216"
  - "CS0217"
  - "CS0218"
  - "CS0448"
  - "CS0552"
  - "CS0553"
  - "CS0554"
  - "CS0555"
  - "CS0556"
  - "CS0557"
  - "CS0558"
  - "CS0559"
  - "CS0562"
  - "CS0563"
  - "CS0564"
  - "CS0567"
  - "CS0590"
  - "CS0660"
  - "CS0661"
  - "CS0715"
  - "CS1037"
  - "CS1553"
  - "CS8930"
  - "CS8931"
  - "CS9023"
  - "CS9024"
  - "CS9025"
  - "CS9308"
  - "CS9310"
  - "CS9311"
  - "CS9312"
  - "CS9313"
  - "CS9340"
  - "CS9341"
  - "CS9342"
helpviewer_keywords:
  - "CS0056"
  - "CS0057"
  - "CS0215"
  - "CS0216"
  - "CS0217"
  - "CS0218"
  - "CS0448"
  - "CS0552"
  - "CS0553"
  - "CS0554"
  - "CS0555"
  - "CS0556"
  - "CS0557"
  - "CS0558"
  - "CS0559"
  - "CS0562"
  - "CS0563"
  - "CS0564"
  - "CS0567"
  - "CS0590"
  - "CS0660"
  - "CS0661"
  - "CS0715"
  - "CS1037"
  - "CS1553"
  - "CS8930"
  - "CS8931"
  - "CS9023"
  - "CS9024"
  - "CS9025"
  - "CS9308"
  - "CS9310"
  - "CS9311"
  - "CS9312"
  - "CS9313"
  - "CS9340"
  - "CS9341"
  - "CS9342"
ms.date: 11/07/2025
ai-usage: ai-assisted
---
# Resolve errors and warnings in user-defined operator declarations

This article covers the following compiler errors:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->
- [**CS0056**](#inconsistent-accessibility): *Inconsistent accessibility: return type 'type' is less accessible than operator 'operator'*
- [**CS0057**](#inconsistent-accessibility): *Inconsistent accessibility: parameter type 'type' is less accessible than operator 'operator'*
- [**CS0215**](#boolean-and-short-circuit-operators): *The return type of operator True or False must be bool*
- [**CS0216**](#boolean-and-short-circuit-operators): *The operator 'operator' requires a matching operator 'missing_operator' to also be defined*
- [**CS0217**](#boolean-and-short-circuit-operators): *In order to be applicable as a short circuit operator a user-defined logical operator ('operator') must have the same return type as the type of its 2 parameters.*
- [**CS0218**](#boolean-and-short-circuit-operators): *The type ('type') must contain declarations of operator true and operator false*
- [**CS0448**](#operator-signature-requirements): *The return type for `++` or `--` operator must be the containing type or derived from the containing type*
- [**CS0552**](#user-defined-conversion-restrictions): *'conversion routine' : user defined conversion to/from interface*
- [**CS0553**](#user-defined-conversion-restrictions): *'conversion routine' : user defined conversion to/from base class*
- [**CS0554**](#user-defined-conversion-restrictions): *'conversion routine' : user defined conversion to/from derived class*
- [**CS0555**](#user-defined-conversion-restrictions): *User-defined operator cannot take an object of the enclosing type and convert to an object of the enclosing type*
- [**CS0556**](#user-defined-conversion-restrictions): *User-defined conversion must convert to or from the enclosing type*
- [**CS0557**](#user-defined-conversion-restrictions): *Duplicate user-defined conversion in type*
- [**CS0558**](#operator-declaration-requirements): *User-defined operator must be declared static and public*
- [**CS0559**](#operator-signature-requirements): *The parameter type for `++` or `--` operator must be the containing type*
- [**CS0562**](#operator-signature-requirements): *The parameter of a unary operator must be the containing type*
- [**CS0563**](#operator-signature-requirements): *One of the parameters of a binary operator must be the containing type*
- [**CS0564**](#operator-signature-requirements): *The first operand of an overloaded shift operator must have the same type as the containing type, and the type of the second operand must be int*
- [**CS0567**](#operator-signature-requirements): *Interfaces cannot contain operators*
- [**CS0590**](#operator-signature-requirements): *User-defined operators cannot return void*
- [**CS0660**](#equality-operators): *Type defines `operator ==` or `operator !=` but does not override `Object.Equals(object o)`*
- [**CS0661**](#equality-operators): *Type defines `operator ==` or `operator !=` but does not override `Object.GetHashCode()`*
- [**CS0715**](#operator-declaration-requirements): *Static classes cannot contain user-defined operators*
- [**CS1037**](#operator-declaration-requirements): *Overloadable operator expected*
- [**CS1553**](#operator-declaration-requirements): *Declaration is not valid; use 'modifier operator \<dest-type> (...' instead*
- [**CS8930**](#operator-declaration-requirements): *Explicit implementation of a user-defined operator must be static.*
- [**CS8931**](#operator-declaration-requirements): *Explicit implementation must be declared public to implement interface member in type.*
- [**CS9023**](#checked-operators): *Operator cannot be made checked.*
- [**CS9024**](#checked-operators): *Operator cannot be made unchecked.*
- [**CS9025**](#checked-operators): *Operator requires a matching non-checked version to also be declared.*
- [**CS9308**](#operator-declaration-requirements): *User-defined operator must be declared public.*
- [**CS9310**](#operator-signature-requirements): *The return type for this operator must be void.*
- [**CS9311**](#interface-and-inheritance-requirements): *Type does not implement interface member. The type cannot implement member because one of them is not an operator.*
- [**CS9312**](#interface-and-inheritance-requirements): *Type cannot override inherited member because one of them is not an operator.*
- [**CS9313**](#interface-and-inheritance-requirements): *Overloaded compound assignment operator takes one parameter.*
- [**CS9340**](#operator-signature-requirements): *Operator cannot be applied to operands. The closest inapplicable candidate is shown.*
- [**CS9341**](#operator-signature-requirements): *Operator cannot be applied to operand. The closest inapplicable candidate is shown.*
- [**CS9342**](#operator-signature-requirements): *Operator resolution is ambiguous between the following members.*

## Operator signature requirements

- **CS0448**: *The return type for `++` or `--` operator must be the containing type or derived from the containing type.*
- **CS0559**: *The parameter type for `++` or `--` operator must be the containing type.*
- **CS0562**: *The parameter of a unary operator must be the containing type.*
- **CS0563**: *One of the parameters of a binary operator must be the containing type.*
- **CS0564**: *The first operand of an overloaded shift operator must have the same type as the containing type, and the type of the second operand must be int.*
- **CS0567**: *Interfaces can't contain operators.*
- **CS0590**: *User-defined operators can't return void.*
- **CS9310**: *The return type for this operator must be void.*
- **CS9340**: *Operator cannot be applied to operands. The closest inapplicable candidate is shown.*
- **CS9341**: *Operator cannot be applied to operand. The closest inapplicable candidate is shown.*
- **CS9342**: *Operator resolution is ambiguous between the following members.*

To declare operators with correct signatures, follow these requirements for the specific operator type. For more information, see [Operator overloading](../operators/operator-overloading.md).

- Return the containing type (or a derived type) from `++` and `--` operators (**CS0448**).
- Use the containing type as the parameter for `++` and `--` operators (**CS0559**).
- Use the containing type as the parameter for unary operators (**CS0562**).
- Include the containing type as at least one parameter in binary operators (**CS0563**).
- Use the containing type as the first parameter and `int` as the second parameter for shift operators (**CS0564**).
- Don't declare operators in interfaces (**CS0567**). Interfaces can't contain operator implementations.
- Return a non-void type from most operators (**CS0590**), except for specific operators that require `void` returns (**CS9310**).
- Provide operator overloads that accept the correct parameter types to avoid resolution failures (**CS9340**, **CS9341**).
- Disambiguate operator calls by using explicit casts or providing more specific overloads (**CS9342**).

> [!IMPORTANT]
> The signature requirements for static binary operators and the corresponding instance compound assignment operators are different. Make sure the signature matches the declaration you want.

The following example demonstrates signature errors:

```csharp
class C1
{
    public static int operator ++(C1 c) => 0;   // CS0448
    public static C1 operator --(C1 c) => null;   // OK
}
public class C2
{
    public static implicit operator int(C2 x) => 0;
    public static implicit operator C2(int x) => new C2();
    public static int operator ++(int aa) => 0;  // CS0559
}
public class C3
{
    public static implicit operator int(C3 x) => 0;
    public static implicit operator C3(int x) => null;
    public static C3 operator +(int aa) => 0;   // CS0562
}
public class C4
{
    public static implicit operator int(C4 x) => 0;
    public static implicit operator C4(int x) => null;
    public static int operator +(int aa, int bb) => 0;   // CS0563
}
class C5
{
    // To correct, change second operand to int, like so:
    // public static int operator << (C c1, int c2)
    public static int operator <<(C5 c1, C5 c2) => 0; // CS0564
}
interface IA
{
    int operator +(int aa, int bb);   // CS0567
}
public class C6
{
    public static void operator +(C6 A1, C6 A2) { }  // CS0590
}
```

## Operator declaration requirements

- **CS0558**: *User-defined operator must be declared static and public.*
- **CS0715**: *Static classes can't contain user-defined operators.*
- **CS1037**: *Overloadable operator expected.*
- **CS1553**: *Declaration isn't valid; use 'modifier operator \<dest-type\> (...' instead.*
- **CS8930**: *Explicit implementation of a user-defined operator must be static.*
- **CS8931**: *Explicit implementation must be declared public to implement interface member in type.*
- **CS9308**: *User-defined operator must be declared public.*

To declare operators correctly, follow these requirements for modifiers and containing types. For more information, see [Operator overloading](../operators/operator-overloading.md) and [User-defined conversion operators](../operators/user-defined-conversion-operators.md).

- Declare operators with both `static` and `public` modifiers (**CS0558**, **CS9308**).
- Don't declare operators in static classes (**CS0715**). Use regular classes or structs.
- Use valid, overloadable operator symbols (**CS1037**).
- Follow the correct syntax for conversion operators: `public static implicit/explicit operator <dest-type>(<source-type> parameter)` (**CS1553**).
- Ensure explicit interface implementations of operators are `static` (**CS8930**) and `public` (**CS8931**).

The following example demonstrates declaration errors:

```csharp
public class C
{
    static implicit operator int(C aa) => 0;   // CS0558, add public
}
public static class C1
{
    public static int operator +(C1 c) => 0;  // CS0715
}
class C2
{
    public static int implicit operator (C2 f) => 6;   // CS1553
}
```

## Inconsistent accessibility

- **CS0056**: *Inconsistent accessibility: return type 'type' is less accessible than operator 'operator'.*
- **CS0057**: *Inconsistent accessibility: parameter type 'type' is less accessible than operator 'operator'.*

To ensure consistent accessibility in operator declarations, make all types used in public operators publicly accessible. For more information, see [Access Modifiers](../../programming-guide/classes-and-structs/access-modifiers.md).

- Ensure return types have at least the same accessibility as the operator (**CS0056**).
- Ensure parameter types have at least the same accessibility as the operator (**CS0057**).

When you declare a `public` operator, all types used as parameters or return values must also be publicly accessible.

The following example demonstrates accessibility errors:

```csharp
class C { }

public class C2
{
    public static implicit operator C(C2 a) => new C();   // CS0056
}

public class C3
{
    public static implicit operator C3(C c) => new C3();   // CS0057
}
```

## User-defined conversion restrictions

- **CS0552**: *User-defined conversion to/from interface.*
- **CS0553**: *User-defined conversion to/from base class.*
- **CS0554**: *User-defined conversion to/from derived class.*
- **CS0555**: *User-defined operator can't take an object of the enclosing type and convert to an object of the enclosing type.*
- **CS0556**: *User-defined conversion must convert to or from the enclosing type.*
- **CS0557**: *Duplicate user-defined conversion in type.*

To create valid user-defined conversion operators, follow these restrictions. For more information, see [User-defined conversion operators](../operators/user-defined-conversion-operators.md).

- Don't define conversions to or from interfaces (**CS0552**). Use explicit interface implementations instead.
- Don't define conversions to or from base classes (**CS0553**). The conversion already exists through inheritance.
- Don't define conversions to or from derived classes (**CS0554**). The conversion already exists through inheritance.
- Don't define conversions from the enclosing type to itself (**CS0555**). This conversion is implicit.
- Ensure at least one type in the conversion is the enclosing type (**CS0556**). You can't define conversions between two external types.
- Don't define duplicate conversions (**CS0557**). Each conversion operator must be unique.

The following example demonstrates conversion restriction errors:

```csharp
public interface I
{
}
public class C
{
    public static implicit operator I(C aa) => default;// CS0552
}

public class B
{
}
public class D : B
{
    public static implicit operator B(D aa) => new B();// CS0553
}

public class B2
{
    // delete the conversion routine to resolve CS0554
    public static implicit operator B2(D2 d) => new B2();// CS0554
}
public class D2 : B2 { }

public class C2
{
    public static implicit operator C2(C2 aa) => new C2();   // CS0555
}

public class C3
{
    public static implicit operator int(byte aa) => 0;   // CS0556
}

public class C4
{
    public static implicit operator int(C4 aa) => 0;

    // CS0557, delete duplicate
    public static explicit operator int(C4 aa) => 0;
}
```

## Boolean and short-circuit operators

- **CS0215**: *The return type of operator true or false must be bool.*
- **CS0216**: *The operator requires a matching operator to also be defined.*
- **CS0217**: *In order to be applicable as a short-circuit operator, a user-defined logical operator must have the same return type as the type of its 2 parameters.*
- **CS0218**: *The type must contain declarations of operator true and operator false.*

To define logical operators correctly, follow these pairing and signature requirements. For more information, see [true and false operators](../operators/true-false-operators.md), [Boolean logical operators](../operators/boolean-logical-operators.md), and [User-defined conditional logical operators](~/_csharpstandard/standard/expressions.md#12163-user-defined-conditional-logical-operators).

- Return `bool` from `operator true` and `operator false` (**CS0215**).
- Define required paired operators (**CS0216**):
  - `operator ==` requires `operator !=`
  - `operator <` requires `operator >`
  - `operator <=` requires `operator >=`
  - `operator true` requires `operator false`
- Match the return type with the parameter types for short-circuit operators (`&` and `|`) that work with custom types (**CS0217**).
- Implement both `operator true` and `operator false` when using custom types in boolean contexts like `&&` and `||` (**CS0218**).

The following example demonstrates logical operator errors:

```csharp
class C
{
    public static int operator true(C c) => 0;   // CS0215
    public static int operator false(C c) => 0; // CS0215
}

class C2
{
    public static bool operator ==(C2 left, C2 right) => left.Equals(right);   // CS0216

    public override bool Equals(object? o) => base.Equals(o);
    public override int GetHashCode() => base.GetHashCode();
}

public class C3
{
    public static bool operator true(C3 f) => false;
    public static bool operator false(C3 f) => true;
    public static implicit operator int(C3 x) => 0;
    public static int operator &(C3 f1, C3 f2) => new C3();  // CS0217
}

public class C4
{
    public static implicit operator int(C4 x) => 0;
    public static C4 operator &(C4 f1, C4 f2) => new C4();

    public static void Main()
    {
        C4 f = new C4();
        int i = f && f;   // CS0218, requires operators true and false
    }
}
```

## Checked operators

- **CS9023**: *Operator can't be made checked*
- **CS9024**: *Operator can't be made unchecked*
- **CS9025**: *Checked operator requires a matching non-checked version to also be declared*

To use checked operators correctly, follow these requirements. For more information, see [Arithmetic operators](../operators/arithmetic-operators.md#user-defined-checked-operators) and [User-defined checked operators](~/_csharplang/proposals/csharp-11.0/checked-user-defined-operators.md).

- Apply `checked` or `unchecked` keywords only to supported arithmetic operators: `+`, `-`, `*`, `/`, `++`, `--`, and explicit conversions (**CS9023**, **CS9024**).
- Provide both checked and unchecked versions when declaring a checked operator (**CS9025**). The compiler needs both to handle different contexts.

## Interface and inheritance requirements

- **CS9311**: *Type doesn't implement interface member. The type can't implement member because one of them isn't an operator*
- **CS9312**: *Type can't override inherited member because one of them isn't an operator*
- **CS9313**: *Overloaded compound assignment operator takes one parameter*

To implement and override operators correctly, follow these requirements. For more information, see [Operator overloading](../operators/operator-overloading.md) and [Interfaces](../../fundamentals/types/interfaces.md).

- Ensure operator declarations match the signature and type of interface members (**CS9311**). An operator can't implement a non-operator member.
- Verify that inherited members being overridden are also operators (**CS9312**). An operator can't override a non-operator member.
- Declare compound assignment operators with one parameter (**CS9313**). The left operand is implicitly `this`.

## Equality operators

- **CS0660**: *Type defines operator == or operator != but doesn't override Object.Equals(object o)*
- **CS0661**: *Type defines operator == or operator != but doesn't override Object.GetHashCode()*

To implement equality correctly, override the corresponding `Object` methods when defining custom equality operators. For more information, see [How to define value equality for a type](../../programming-guide/statements-expressions-operators/how-to-define-value-equality-for-a-type.md) and [Equality operators](../operators/equality-operators.md).

- Override <xref:System.Object.Equals%2A?displayProperty=nameWithType> when you define `operator ==` or `operator !=` (**CS0660**).
- Override <xref:System.Object.GetHashCode%2A?displayProperty=nameWithType> when you define `operator ==` or `operator !=` (**CS0661**).

Overriding these methods ensures consistent equality behavior across different APIs and collection types.
