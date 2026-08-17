---
title: "Resolve errors and warnings related to tuples"
description: "This article helps you diagnose and correct compiler errors and warnings related to tuple declarations, element names, metadata, conversions, equality, type inference, and pattern matching"
f1_keywords:
  - CS8123
  - CS8124
  - CS8125
  - CS8126
  - CS8127
  - CS8128
  - CS8135
  - CS8137
  - CS8138
  - CS8139
  - CS8140
  - CS8141
  - CS8142
  - CS8179
  - CS8181
  - CS8182
  - CS8210
  - CS8306
  - CS8307
  - CS8383
  - CS8384
  - CS8516
  - CS8522
helpviewer_keywords:
  - CS8123
  - CS8124
  - CS8125
  - CS8126
  - CS8127
  - CS8128
  - CS8135
  - CS8137
  - CS8138
  - CS8139
  - CS8140
  - CS8141
  - CS8142
  - CS8179
  - CS8181
  - CS8182
  - CS8210
  - CS8306
  - CS8307
  - CS8383
  - CS8384
  - CS8516
  - CS8522
ms.date: 08/17/2026
ai-usage: ai-assisted
---

# Resolve errors and warnings for tuples

This article covers the following compiler errors and warnings:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->

- [**CS8123**](#tuple-element-names): *The tuple element name 'name' is ignored because a different name or no name is specified by the target type 'type'.*
- [**CS8124**](#tuple-structure-and-literals): *Tuple must contain at least two elements.*
- [**CS8125**](#tuple-element-names): *Tuple element name 'name' is only allowed at position N.*
- [**CS8126**](#tuple-element-names): *Tuple element name 'name' is disallowed at any position.*
- [**CS8127**](#tuple-element-names): *Tuple element names must be unique.*
- [**CS8128**](#valuetuple-infrastructure): *Member 'member' was not found on type 'type' from assembly 'assembly'.*
- [**CS8135**](#tuple-structure-and-literals): *Tuple with 'count' elements cannot be converted to type 'type'.*
- [**CS8137**](#tuple-metadata): *Cannot define a class or member that utilizes tuples because the compiler required type 'type' cannot be found. Are you missing a reference?*
- [**CS8138**](#tuple-metadata): *Cannot reference 'System.Runtime.CompilerServices.TupleElementNamesAttribute' explicitly. Use the tuple syntax to define tuple names.*
- [**CS8139**](#tuple-element-names-in-type-hierarchy): *'member': cannot change tuple element names when overriding inherited member 'base member'.*
- [**CS8140**](#tuple-element-names-in-type-hierarchy): *'interface' is already listed in the interface list on type 'type' with different tuple element names, as 'alias'.*
- [**CS8141**](#tuple-element-names-in-type-hierarchy): *The tuple element names in the signature of method 'method' must match the tuple element names of interface method 'interface method' (including on the return type).*
- [**CS8142**](#tuple-element-names-in-type-hierarchy): *Both partial member declarations, 'member' and 'other partial', must use the same tuple element names.*
- [**CS8179**](#valuetuple-infrastructure): *Predefined type 'type' is not defined or imported*
- [**CS8181**](#tuple-structure-and-literals): *'new' cannot be used with tuple type. Use a tuple literal expression instead.*
- [**CS8182**](#valuetuple-infrastructure): *Predefined type 'type' must be a struct.*
- [**CS8210**](#tuple-structure-and-literals): *A tuple may not contain a value of type 'void'.*
- [**CS8306**](#tuple-type-inference): *Tuple element name 'name' is inferred. Please use language version 7.1 or greater to access an element by its inferred name.*
- [**CS8307**](#tuple-type-inference): *The first operand of an 'as' operator may not be a tuple literal without a natural type.*
- [**CS8383**](#tuple-equality): *The tuple element name 'name' is ignored because a different name or no name is specified on the other side of the tuple == or != operator.*
- [**CS8384**](#tuple-equality): *Tuple types used as operands of an == or != operator must have matching cardinalities. But this operator has tuple types of cardinality 'left' on the left and 'right' on the right.*
- [**CS8516**](#pattern-matching-with-tuples): *The name 'name' does not identify tuple element 'element'.*
- [**CS8522**](#pattern-matching-with-tuples): *Element names are not permitted when pattern-matching via 'System.Runtime.CompilerServices.ITuple'.*

## Tuple element names

- **CS8123**: *The tuple element name 'name' is ignored because a different name or no name is specified by the target type 'type'.*
- **CS8125**: *Tuple element name 'name' is only allowed at position N.*
- **CS8126**: *Tuple element name 'name' is disallowed at any position.*
- **CS8127**: *Tuple element names must be unique.*

The compiler warns or reports an error when tuple element names are inconsistent with the surrounding context.

**CS8123** is a warning that appears when a tuple literal provides element names, but the target type expects different names or no names. Element names in a tuple literal are ignored during type conversion; assigning a named tuple to a variable of an unnamed or differently named tuple type does not copy the names. Rename the element names in the tuple literal to match the target type, or change the target type to preserve the intended names (**CS8123**).

**CS8125** occurs when the reserved `ItemN` naming scheme is used but the name is placed at the wrong position. The names `Item1`, `Item2`, and so on are allowed only at their corresponding positions—`Item1` at position 1, `Item2` at position 2. For example, `(Item2: 2, Item1: 1)` is invalid because `Item2` is at position 1 and `Item1` is at position 2. Reorder the elements so that `ItemN` names correspond to their declared position, or use distinct custom names (**CS8125**).

**CS8126** occurs when a tuple element uses a name that is reserved for the tuple's underlying `ValueTuple` infrastructure. Names such as `Rest`, `ToString`, `GetHashCode`, `Equals`, and members of `System.Runtime.CompilerServices.ITuple` cannot be used as element names. Choose a different element name (**CS8126**).

**CS8127** occurs when two elements in the same tuple declaration use the same name. All element names within a tuple must be distinct. Rename one of the conflicting elements (**CS8127**):

```csharp
internal struct NewStruct
{
    public int a;
    public int b;

    // Error: both elements named 'a'
    // public static implicit operator (int a, int a)(NewStruct value) => (value.a, value.b);

    // Fix: use distinct names
    public static implicit operator (int a, int b)(NewStruct value) => (value.a, value.b);
}
```

## Tuple element names in type hierarchy

- **CS8139**: *'member': cannot change tuple element names when overriding inherited member 'base member'.*
- **CS8140**: *'interface' is already listed in the interface list on type 'type' with different tuple element names, as 'alias'.*
- **CS8141**: *The tuple element names in the signature of method 'method' must match the tuple element names of interface method 'interface method' (including on the return type).*
- **CS8142**: *Both partial member declarations, 'member' and 'other partial', must use the same tuple element names.*

Tuple element names are part of the method signature and must be consistent across overrides, interface implementations, and partial member declarations.

**CS8139** occurs when an overriding method changes the tuple element names from those declared in the virtual or abstract base member. Match the tuple element names in the overriding method's signature to those in the base member (**CS8139**):

```csharp
public class Base
{
    public virtual (object a, object b) M((object c, object d) x) { return x; }
}

class Derived : Base
{
    // Error: return type changed 'a','b' to unnamed
    // public override (object, object) M((object c, object d) y) { return y; }

    // Fix: preserve names from base
    public override (object a, object b) M((object c, object d) y) { return y; }
}
```

**CS8140** occurs when a class implements the same generic interface twice through inheritance, but with different tuple element names. The class cannot satisfy both simultaneously. Align the tuple element names across all base types and interface implementations so that all paths to the same generic interface use the same element names (**CS8140**):

```csharp
interface I<T>
{
    T GetValue();
}

interface I2 : I<(int c, int d)>
{
}

// Error: I is implemented via I2 with (int c, int d),
// but also directly with (int a, int b)
// class C : I<(int a, int b)>, I2
// {
//     public (int c, int d) GetValue() => (1, 2);
// }

// Fix: align element names across all paths to I<T>
class C : I<(int c, int d)>, I2
{
    public (int c, int d) GetValue() => (1, 2);
}
```

**CS8141** occurs when an explicit or implicit interface implementation uses different tuple element names than the interface member it implements. Match the tuple element names in the implementing method to those declared in the interface, for both parameters and return types (**CS8141**):

```csharp
public interface IGrabber<out T>
{
    T GetOne();
}

// Error: implementation adds names to unnamed tuple
// class SomeGrabber : IGrabber<(int, int)>
// {
//     public (int a, int b) GetOne() => (1, 2);
// }

// Fix: match the interface's unnamed tuple
class SomeGrabber : IGrabber<(int, int)>
{
    public (int, int) GetOne() => (1, 2);
}
```

**CS8142** occurs when the two halves of a partial method or property declaration specify different tuple element names. Both declarations must use exactly the same tuple element names. Update one declaration to match the other (**CS8142**).

## Tuple metadata

- **CS8137**: *Cannot define a class or member that utilizes tuples because the compiler required type 'type' cannot be found. Are you missing a reference?*
- **CS8138**: *Cannot reference 'System.Runtime.CompilerServices.TupleElementNamesAttribute' explicitly. Use the tuple syntax to define tuple names.*

When a type signature includes named tuples, the compiler must be able to reference `TupleElementNamesAttribute` to store the element names in metadata.

**CS8137** occurs when `TupleElementNamesAttribute` itself is missing from the referenced runtime. Ensure your project references a .NET runtime that provides `System.Runtime.CompilerServices.TupleElementNamesAttribute`. For older frameworks, add a reference to the `System.Runtime` NuGet package and rebuild (**CS8137**).

**CS8138** occurs when source code explicitly references `[TupleElementNames(...)]`. This attribute is reserved for compiler use and cannot be applied in source. Use tuple literal syntax with element names—for example, `(int x, string y)`—and the compiler will generate the metadata automatically (**CS8138**).

## ValueTuple infrastructure

- **CS8128**: *Member 'member' was not found on type 'type' from assembly 'assembly'.*
- **CS8179**: *Predefined type 'type' is not defined or imported*
- **CS8182**: *Predefined type 'type' must be a struct.*

These errors occur when the compiler cannot find or validate the required `System.ValueTuple` types that underlie tuple syntax.

**CS8179** occurs when the `System.ValueTuple` type is completely absent. Tuples require this type. It is built into .NET Framework 4.7 and later, .NET Core, and .NET 5+. For older frameworks, add the `System.ValueTuple` NuGet package (**CS8179**).

**CS8182** occurs when a `ValueTuple` type exists in the referenced assembly but is a class rather than a struct. The compiler requires it to be a struct. Verify that you are not shadowing the system `ValueTuple` types with a custom class in your project or a referenced assembly (**CS8182**).

**CS8128** occurs when a specific member (such as `Item1`, `Item2`, or `Rest` for large tuples) is missing from the predefined `ValueTuple` type in the referenced assembly. This usually indicates an assembly mismatch or a corrupted custom `ValueTuple` implementation. Verify that your project references the correct version of the runtime or NuGet package (**CS8128**).

## Tuple structure and literals

- **CS8124**: *Tuple must contain at least two elements.*
- **CS8135**: *Tuple with 'count' elements cannot be converted to type 'type'.*
- **CS8181**: *'new' cannot be used with tuple type. Use a tuple literal expression instead.*
- **CS8210**: *A tuple may not contain a value of type 'void'.*

These errors relate to how tuple expressions are formed.

**CS8124** occurs when a tuple type or literal declares fewer than two elements. Tuples require at least two elements. Change a zero- or one-element tuple to use two or more elements (**CS8124**):

```csharp
// Error: () and (int a) are invalid tuple types
// void M(int x, () y, (int a) z) { }

// Fix: use at least two elements
void M(int x, (int, int) y, (int a, int b) z) { }
```

**CS8135** occurs when a tuple expression has a different number of elements than the target type expects. Ensure the tuple literal has the same element count as the destination type (**CS8135**).

**CS8181** occurs when you write `new (T1, T2)(...)` using `new` with a tuple type. Tuple values are created with tuple literal syntax, not with `new`. Replace `new (T1, T2)(v1, v2)` with the literal `(v1, v2)` (**CS8181**).

**CS8210** occurs when a tuple element expression evaluates to `void`—for example, by calling a `void`-returning method as a tuple element. Tuples can only contain values; they cannot hold a `void` result. Replace the `void` method call with an expression that produces a value, or redesign the tuple to exclude that element (**CS8210**):

```csharp
void Method()
{
}

void Test()
{
    // Error: Method() returns void and cannot be a tuple element
    // var x = ("something", Method());
}
```

## Tuple type inference

- **CS8306**: *Tuple element name 'name' is inferred. Please use language version 7.1 or greater to access an element by its inferred name.*
- **CS8307**: *The first operand of an 'as' operator may not be a tuple literal without a natural type.*

**CS8306** occurs when code accesses an inferred tuple element name—a name derived from a variable or member expression, such as `(x, y).x`—but the project targets a language version earlier than C# 7.1. To resolve, set `<LangVersion>7.1</LangVersion>` or higher in your project file, or access the element by position (`Item1`, `Item2`) instead of its inferred name (**CS8306**).

**CS8307** occurs when a tuple literal without explicit element types is used as the left operand of an `as` operator. The `as` operator requires type information, and a bare tuple literal has no natural type. Either assign the literal to a typed variable first, then apply `as` to the variable, or annotate the tuple with an explicit type before using `as` (**CS8307**).

## Tuple equality

- **CS8383**: *The tuple element name 'name' is ignored because a different name or no name is specified on the other side of the tuple == or != operator.*
- **CS8384**: *Tuple types used as operands of an == or != operator must have matching cardinalities. But this operator has tuple types of cardinality 'left' on the left and 'right' on the right.*

**CS8383** is a warning that appears when the two operands of a `==` or `!=` comparison have different or absent element names. Element names do not affect equality semantics—the comparison still compares element values positionally—but the mismatch often indicates a naming inconsistency. Align the element names on both sides of the operator, or use unnamed tuples if the names are not meaningful for this comparison (**CS8383**).

**CS8384** occurs when the two operands of a `==` or `!=` comparison have different numbers of elements. Tuples of different sizes are not comparable. Adjust the tuple literals or types so that both operands have the same element count (**CS8384**).

## Pattern matching with tuples

- **CS8516**: *The name 'name' does not identify tuple element 'element'.*
- **CS8522**: *Element names are not permitted when pattern-matching via 'System.Runtime.CompilerServices.ITuple'.*

**CS8516** occurs when a tuple pattern uses a property name that does not match any element name of the tuple type being matched. Tuple patterns match elements by name; check the element names of the tuple type and correct the pattern property name (**CS8516**):

```csharp
var point = (x: 1, y: 2);

// Error: 'a' and 'b' do not identify elements of (int x, int y)
// if (point is (a: 1, b: _)) { }

// Fix: use the declared element names
if (point is (x: 1, y: _)) { }
```

**CS8522** occurs when a positional pattern uses named subpatterns against a type that implements `System.Runtime.CompilerServices.ITuple` but is not a known tuple type. When pattern-matching via the `ITuple` interface, elements must be matched positionally, not by name. Remove the element names from the pattern (**CS8522**).

## See also

- [Value tuples](../builtin-types/value-tuples.md)
- [Deconstruction](../../fundamentals/functional/deconstruct.md)
- [Pattern matching](../../fundamentals/functional/pattern-matching.md)
- [Void](../builtin-types/void.md)

