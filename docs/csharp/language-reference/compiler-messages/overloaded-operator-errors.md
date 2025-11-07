---
title: Errors and warnings related to user defined operator declarations
description: This article helps you diagnose and correct compiler errors and warnings when you declare user defined operators in your types
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
ms.date: 10/15/2025
ai-usage: ai-assisted
---
# Errors and warnings for overloaded, or user-defined operator declarations

There are several errors related to declaring overloaded operators. Overloaded operators are also referred to as user-defined operators

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

The following sections provide examples of common issues and how to fix them.

## Operator signature requirements

- **CS0448**: *The return type for `++` or `--` operator must be the containing type or derived from the containing type.*
- **CS0559**: *The parameter type for `++` or `--` operator must be the containing type.*
- **CS0562**: *The parameter of a unary operator must be the containing type.*
- **CS0563**: *One of the parameters of a binary operator must be the containing type.*
- **CS0564**: *The first operand of an overloaded shift operator must have the same type as the containing type, and the type of the second operand must be int.*
- **CS0567**: *Interfaces can't contain operators.*
- **CS0590**: *User-defined operators can't return void.*
- **CS9310**: *The return type for this operator must be void.*

These errors occur when operator declarations don't follow the required signature rules. Each operator type has specific requirements for parameter types and return types.

> [!IMPORTANT]
> The signature requirements for static binary operators and the corresponding instance compound assignment operators are different. Make sure the signature matches the declaration you want.

For more information, see [Operator overloading](../operators/operator-overloading.md). The following example demonstrates these errors:

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

To fix these errors, ensure your operator declarations follow the signature requirements for the specific operator type you're overloading.

## Operator declaration requirements

- **CS0558**: *User-defined operator must be declared static and public.*
- **CS0715**: *Static classes can't contain user-defined operators.*
- **CS1037**: *Overloadable operator expected.*
- **CS1553**: *Declaration isn't valid; use 'modifier operator \<dest-type\> (...' instead.*
- **CS8930**: *Explicit implementation of a user-defined operator must be static.*
- **CS8931**: *Explicit implementation must be declared public to implement interface member in type.*
- **CS9308**: *User-defined operator must be declared public.*

These errors occur when operator declarations don't use the required modifiers or syntax. Most user-defined operators must be both `static` and `public`, and conversion operators require specific syntax. For more information, see [Operator overloading](../operators/operator-overloading.md) and [User-defined conversion operators](../operators/user-defined-conversion-operators.md). The following code demonstrates these errors:

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

To fix these errors, ensure your operator declarations include the required `static` and `public` modifiers, follow the correct syntax for conversion operators, and don't declare operators in static classes.

## Inconsistent accessibility

- **CS0056**: *Inconsistent accessibility: return type 'type' is less accessible than operator 'operator'.*
- **CS0057**: *Inconsistent accessibility: parameter type 'type' is less accessible than operator 'operator'.*

These errors occur when you declare a public operator with return types or parameter types that have more restrictive accessibility than the operator itself. All public constructs must use publicly accessible types for their parameters and return values. For more information, see [Access Modifiers](../../programming-guide/classes-and-structs/access-modifiers.md).

The following code snippets demonstrate these errors:

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

To fix these errors, make sure all types used in public operator declarations are also publicly accessible.

## User-defined conversion restrictions

- **CS0552**: *User-defined conversion to/from interface.*
- **CS0553**: *User-defined conversion to/from base class.*
- **CS0554**: *User-defined conversion to/from derived class.*
- **CS0555**: *User-defined operator can't take an object of the enclosing type and convert to an object of the enclosing type.*
- **CS0556**: *User-defined conversion must convert to or from the enclosing type.*
- **CS0557**: *Duplicate user-defined conversion in type.*

These errors occur when you attempt to create invalid user-defined conversion operators. Conversion operators have specific restrictions about which types they can convert between. For more information, see [User-defined conversion operators](../operators/user-defined-conversion-operators.md). The following code demonstrates the preceding errors:

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

To fix these errors, remove invalid conversion operators or restructure your type hierarchy to avoid the restricted conversion patterns.

## Boolean and short-circuit operators

- **CS0215**: *The return type of operator true or false must be bool.*
- **CS0216**: *The operator requires a matching operator to also be defined.*
- **CS0217**: *In order to be applicable as a short-circuit operator, a user-defined logical operator must have the same return type as the type of its 2 parameters.*
- **CS0218**: *The type must contain declarations of operator true and operator false.*

These errors occur when you define logical operators incorrectly. Certain operators must be defined in pairs, and short-circuit operators have specific signature requirements. For more information, see [true and false operators](../operators/true-false-operators.md), [Boolean logical operators](../operators/boolean-logical-operators.md), and [User-defined conditional logical operators](~/_csharpstandard/standard/expressions.md#12163-user-defined-conditional-logical-operators). The following code demonstrates these errors:

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

To fix these errors, ensure you define required paired operators and follow the correct signature patterns for logical operators.

## Checked operators

- **CS9023**: *Operator can't be made checked*
- **CS9024**: *Operator can't be made unchecked*
- **CS9025**: *Checked operator requires a matching non-checked version to also be declared*

These errors occur when you incorrectly use the `checked` or `unchecked` keywords with operator declarations. Not all operators support checked/unchecked variants, and when they do, certain requirements must be met. For more information, see [Arithmetic operators](../operators/arithmetic-operators.md#user-defined-checked-operators) and [User-defined checked operators](~/_csharplang/proposals/csharp-11.0/checked-user-defined-operators.md).

To fix these errors, either remove the `checked` or `unchecked` keyword from operators that don't support it, or ensure you provide both checked and non-checked versions when required.

## Interface and inheritance requirements

- **CS9311**: *Type doesn't implement interface member. The type can't implement member because one of them isn't an operator*
- **CS9312**: *Type can't override inherited member because one of them isn't an operator*
- **CS9313**: *Overloaded compound assignment operator takes one parameter*

These errors occur when there are mismatches between operator declarations and interface implementations or inheritance relationships. Operators have specific rules for interface implementation and overriding. For more information, see [Operator overloading](../operators/operator-overloading.md) and [Interfaces](../../fundamentals/types/interfaces.md).

To fix these errors, ensure that operator declarations correctly match interface requirements and follow the rules for operator overriding and compound assignment operators.

## Equality operators

- **CS0660**: *Type defines operator == or operator != but doesn't override Object.Equals(object o)*
- **CS0661**: *Type defines operator == or operator != but doesn't override Object.GetHashCode()*

These warnings occur when you define equality or inequality operators without also overriding the corresponding methods from <xref:System.Object>. When you define custom equality comparison, you should also override <xref:System.Object.Equals%2A?displayProperty=nameWithType> and <xref:System.Object.GetHashCode%2A?displayProperty=nameWithType> to ensure consistent behavior. For more information, see [How to define value equality for a type](../../programming-guide/statements-expressions-operators/how-to-define-value-equality-for-a-type.md) and [Equality operators](../operators/equality-operators.md).

To fix these warnings, override both `Equals` and `GetHashCode` when you define custom equality operators.
