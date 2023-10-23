---
title: Errors and warnings associated with reference parameter modifiers
description: The compiler issues these errors and warnings when you have used the reference parameter modifiers incorrectly. They indicate you've got some mismatch between the modifier on the parameter, the argument, or the use of the parameter in the method.
f1_keywords:
  - "CS9190"
  - "CS0192"
  - "CS0199"
  - "CS0206"
  - "CS0631"
  - "CS0767"
  - "CS1510"
  - "CS1605"
  - "CS1623"
  - "CS1649"
  - "CS1651"
  - "CS1655"
  - "CS1657"
  - "CS1741"
  - "CS1939"
  - "CS1988"
  - "CS7084"
  - "CS8166"
  - "CS8167"
  - "CS8168"
  - "CS8169"
  - "CS8325"
  - "CS8326"
  - "CS8327"
  - "CS8329"
  - "CS8330"
  - "CS8331"
  - "CS8332"
  - "CS8337"
  - "CS8338"
  - "CS8345"
  - "CS8351"
  - "CS8373"
  - "CS8374"
  - "CS8388"
  - "CS8977"
  - "CS9072"
  - "CS9077"
  - "CS9078"
  - "CS9079"
  - "CS9096"
  - "CS9109"
  - "CS9110"
  - "CS9116"
  - "CS9119"
  - "CS9130"
  - "CS9190"
  - "CS9199"
  - "CS9085"
  - "CS9086"
  - "CS9087"
  - "CS9089"
  - "CS9091"
  - "CS9092"
  - "CS9093"
  - "CS9094"
  - "CS9095"
  - "CS9097"
  - "CS9184"
  - "CS9191"
  - "CS9192"
  - "CS9193"
  - "CS9195"
  - "CS9196"
  - "CS9197"
  - "CS9198"
  - "CS9200"
  - "CS9201"
helpviewer_keywords:
  - "CS9190"
  - "CS0192"
  - "CS0199"
  - "CS0206"
  - "CS0631"
  - "CS0767"
  - "CS1510"
  - "CS1605"
  - "CS1623"
  - "CS1649"
  - "CS1651"
  - "CS1655"
  - "CS1657"
  - "CS1741"
  - "CS1939"
  - "CS1988"
  - "CS7084"
  - "CS8166"
  - "CS8167"
  - "CS8168"
  - "CS8169"
  - "CS8325"
  - "CS8326"
  - "CS8327"
  - "CS8329"
  - "CS8330"
  - "CS8331"
  - "CS8332"
  - "CS8337"
  - "CS8338"
  - "CS8345"
  - "CS8351"
  - "CS8373"
  - "CS8374"
  - "CS8388"
  - "CS8977"
  - "CS9072"
  - "CS9077"
  - "CS9078"
  - "CS9079"
  - "CS9096"
  - "CS9109"
  - "CS9110"
  - "CS9116"
  - "CS9119"
  - "CS9130"
  - "CS9190"
  - "CS9199"
  - "CS9085"
  - "CS9086"
  - "CS9087"
  - "CS9089"
  - "CS9091"
  - "CS9092"
  - "CS9093"
  - "CS9094"
  - "CS9095"
  - "CS9097"
  - "CS9184"
  - "CS9191"
  - "CS9192"
  - "CS9193"
  - "CS9195"
  - "CS9196"
  - "CS9197"
  - "CS9198"
  - "CS9200"
  - "CS9201"
ms.date: 10/24/2023
---
# Errors and warnings associated with reference parameters, variables, and returns

The following errors may be generated when source generators or interceptors are loaded during a compilation:

- [**CS0192**](#readonly-fields-and-variables-cant-be-writable-reference-variables) - *A `readonly` field cannot be used as a `ref` or `out` value (except in a constructor)*
- [**CS0199**](#readonly-fields-and-variables-cant-be-writable-reference-variables) - *A `static readonly` field cannot be used as a `ref` or `out` value (except in a static constructor)*
- [**CS0206**](#reference-variable-cant-be-value-expression) - *A non ref-returning property or indexer may not be used as an `out` or `ref` value*
- [**CS0631**](#incompatible-language-constructs) - *`ref` and `out` are not valid in this context*
- [**CS0767**](#incompatible-language-constructs) - *Cannot inherit interface with the specified type parameters because it causes method to contain overloads which differ only on `ref` and `out`*
- [**CS1510**](#reference-variable-cant-be-value-expression) - *A `ref` or `out` value must be an assignable variable*
- [**CS1605**](#readonly-fields-and-variables-cant-be-writable-reference-variables) - *Cannot use variable as a `ref` or `out` value because it is read-only*
- [**CS1623**](#incompatible-language-constructs) - *Iterators cannot have `ref`, `in` or `out` parameters*
- [**CS1649**](#readonly-fields-and-variables-cant-be-writable-reference-variables) - *Members of a `readonly` field cannot be used as a `ref` or `out` value (except in a constructor)*
- [**CS1651**](#readonly-fields-and-variables-cant-be-writable-reference-variables) - *Fields of a static readonly field cannot be used as a `ref` or `out` value (except in a static constructor)*
- [**CS1655**](#readonly-fields-and-variables-cant-be-writable-reference-variables) - *Cannot use fields of type as a `ref` or `out` value*
- [**CS1657**](#reference-variable-cant-be-value-expression) - *Cannot use variable as a `ref` or `out` value*
- [**CS1741**](#incompatible-language-constructs) - *A `ref` or `out` parameter cannot have a default value*
- [**CS1939**](#incompatible-language-constructs) - *Cannot pass the range variable as an `out` or `ref` parameter*
- [**CS1988**](#incompatible-language-constructs) - *Async methods cannot have `ref`, `in` or `out` parameters*
- [**CS7084**](#incompatible-language-constructs) - *A Windows Runtime event may not be passed as an `out` or `ref` parameter.*
- [**CS8166**](#ref-safety-violations) - *Cannot return a parameter by reference because it is not a `ref` parameter*
- [**CS8167**](#ref-safety-violations) - *Cannot return by reference a member of parameter because it is not a `ref` or `out` parameter*
- [**CS8168**](#ref-safety-violations) - *Cannot return local by reference because it is not a ref local*
- [**CS8169**](#ref-safety-violations) - *Cannot return a member of local variable by reference because it is not a ref local*
- [**CS8325**](#incompatible-language-constructs) - *'`await`' cannot be used in an expression containing a `ref` conditional operator*
- [**CS8326**](#incompatible-language-constructs) - *Both conditional operator values must be ref values or neither may be a ref value*
- [**CS8327**](#incompatible-language-constructs) - *The expression must be of correct type to match the alternative ref value*
- [**CS8329**](#readonly-fields-and-variables-cant-be-writable-reference-variables) - *Cannot use variable as a `ref` or `out` value because it is a readonly variable*
- [**CS8330**](#readonly-fields-and-variables-cant-be-writable-reference-variables) - *Members of variable cannot be used as a `ref` or `out` value because it is a readonly variable*
- [**CS8331**](#readonly-fields-and-variables-cant-be-writable-reference-variables) - *Cannot assign to variable or use it as the right hand side of a `ref` assignment because it is a readonly variable*
- [**CS8332**](#readonly-fields-and-variables-cant-be-writable-reference-variables) - *Cannot assign to a member of variable or use it as the right hand side of a `ref` assignment because it is a readonly variable*
- [**CS8337**](#incompatible-language-constructs) - *The first parameter of a '`ref`' extension method must be a value type or a generic type constrained to struct.*
- [**CS8338**](#incompatible-language-constructs) - *The first '`in`' or '`ref readonly`' parameter of the extension method must be a concrete (non-generic) value type.*
- [**CS8345**](#ref-safety-violations) - *Field or auto-implemented property cannot be of type unless it is an instance member of a `ref struct`.*
- [**CS8351**](#ref-safety-violations) - *Branches of a `ref` conditional operator cannot refer to variables with incompatible declaration scopes*
- [**CS8373**](#incompatible-language-constructs) - *The left-hand side of a `ref` assignment must be a ref variable.*
- [**CS8374**](#ref-safety-violations) - *Cannot ref-assign source has a narrower escape scope than destination.*
- [**CS8388**](#incompatible-language-constructs) - *An `out` variable cannot be declared as a ref local*
- [**CS8977**](#incompatible-language-constructs) - *Cannot use '`ref`', '`in`', or '`out`' in the signature of a method attributed with 'UnmanagedCallersOnly'.*
- [**CS9072**](#incompatible-language-constructs) - *A deconstruction variable cannot be declared as a ref local*
- [**CS9077**](#ref-safety-violations) - *Cannot return a parameter by reference through a `ref` parameter; it can only be returned in a return statement*
- [**CS9078**](#ref-safety-violations) - *Cannot return by reference a member of parameter through a `ref` parameter; it can only be returned in a return statement*
- [**CS9079**](#ref-safety-violations) - *Cannot ref-assign because source can only escape the current method through a return statement.*
- [**CS9096**](#ref-safety-violations) - *Cannot ref-assign because source has a wider value escape scope than destination allowing assignment through source of values with narrower escapes scopes than destination.*
- [**CS9109**](#ref-safety-violations) - *Cannot use `ref`, `out`, or `in` primary constructor parameter inside an instance member*
- [**CS9110**](#ref-safety-violations) - *Cannot use primary constructor parameter that has ref-like type inside an instance member*
- [**CS9116**](#readonly-fields-and-variables-cant-be-writable-reference-variables) - *A primary constructor parameter of a readonly type cannot be used as a `ref` or `out` value (except in init-only setter of the type or a variable initializer)*
- [**CS9119**](#readonly-fields-and-variables-cant-be-writable-reference-variables) - *Members of primary constructor parameter of a readonly type cannot be used as a `ref` or `out` value (except in init-only setter of the type or a variable initializer)*
- [**CS9130**](#incompatible-language-constructs) - *Using alias cannot be a '`ref`' type.*
- [**CS9190**](#incompatible-language-constructs) - *`readonly` modifier must be specified after `ref`.*
- [**CS9199**](#incompatible-language-constructs) - *A `ref readonly` parameter cannot have the Out attribute.*

The following warnings may be generated when reference variables are used incorrectly:

- [**CS9085**](#ref-safety-violations) - *This ref-assigns variable but destination has a narrower escape scope than source.*
- [**CS9086**](#ref-safety-violations) - *The branches of the `ref` conditional operator refer to variables with incompatible declaration scopes*
- [**CS9087**](#ref-safety-violations) - *This returns a parameter by reference but it is not a `ref` parameter*
- [**CS9089**](#ref-safety-violations) - *This returns by reference a member of parameter that is not a `ref` or `out` parameter*
- [**CS9091**](#ref-safety-violations) - *This returns local by reference but it is not a ref local*
- [**CS9092**](#ref-safety-violations) - *This returns a member of local by reference but it is not a ref local*
- [**CS9093**](#ref-safety-violations) - *This ref-assigns but source can only escape the current method through a return statement.*
- [**CS9094**](#ref-safety-violations) - *This returns a parameter by reference through a `ref` parameter; but it can only safely be returned in a return statement*
- [**CS9095**](#ref-safety-violations) - *This returns by reference a member of parameter through a `ref` parameter; but it can only safely be returned in a return statement*
- [**CS9097**](#ref-safety-violations) - *This ref-assigns  but source has a wider value escape scope than destination allowing assignment through destination of values with narrower escapes scopes than source.*
- [**CS9184**](#incompatible-language-constructs) - *'Inline arrays' language feature is not supported for inline array types with element field which is either a '`ref`' field, or has type that is not valid as a type argument.*
- [**CS9191**](#reference-variable-cant-be-value-expression) - *The `ref` modifier for argument corresponding to `in` parameter is equivalent to `in`. Consider using `in` instead.*
- [**CS9192**](#reference-variable-cant-be-value-expression) - *Argument should be passed with `ref` or `in` keyword.*
- [**CS9193**](#reference-variable-cant-be-value-expression) - *Argument should be a variable because it is passed to a `ref readonly` parameter*
- [**CS9195**](#reference-variable-cant-be-value-expression) - *Argument should be passed with the `in` keyword*
- [**CS9196**](#incompatible-language-constructs) - *Reference kind modifier of parameter doesn't match the corresponding parameter in overridden or implemented member.*
- [**CS9197**](#incompatible-language-constructs) - *Reference kind modifier of parameter doesn't match the corresponding parameter in hidden member.*
- [**CS9198**](#incompatible-language-constructs) - *Reference kind modifier of parameter doesn't match the corresponding parameter in target.*
- [**CS9200**](#incompatible-language-constructs) - *A default value is specified for `ref readonly` parameter, but `ref readonly` should be used only for references. Consider declaring the parameter as `in`.*
- [**CS9201**](#incompatible-language-constructs) - *Ref field should be ref-assigned before use.*

These errors and warnings follow these themes:

- ***[Language constructs where `ref` variables aren't valid](#incompatible-language-constructs)*** - Some C# idioms don't allow variables. Usually this is because ref safety analysis can't be performed reliably.
- ***[Value expression used as reference variable](#reference-variable-cant-be-value-expression)*** - The expression used as a reference variable must be a variable, not a value expression.
- ***[Readonly variables used as writable reference variables](#readonly-fields-and-variables-can-be-writable-reference-variables)*** - A reference to a readonly variable can't be passed by writable reference.
- ***[violations of ref safety](#ref-safety-violations)*** - A reference variable can't refer to a variable that has a narrower context. That would mean the reference variable could refer to invalid memory.

## Incompatible language constructs

- **CS0631** - *`ref` and `out` are not valid in this context*
- **CS0767** - *Cannot inherit interface with the specified type parameters because it causes method to contain overloads which differ only on `ref` and `out`*
- **CS1623** - *Iterators cannot have `ref`, `in` or `out` parameters*
- **CS1741** - *A `ref` or `out` parameter cannot have a default value*
- **CS1939** - *Cannot pass the range variable as an `out` or `ref` parameter*
- **CS1988** - *Async methods cannot have `ref`, `in` or `out` parameters*
- **CS7084** - *A Windows Runtime event may not be passed as an `out` or `ref` parameter.*
- **CS8325** - *'await' cannot be used in an expression containing a `ref` conditional operator*
- **CS8326** - *Both conditional operator values must be ref values or neither may be a ref value*
- **CS8327** - *The expression must be of correct type to match the alternative ref value*
- **CS8337** - *The first parameter of a '`ref`' extension method must be a value type or a generic type constrained to struct.*
- **CS8338** - *The first '`in`' or '`ref readonly`' parameter of the extension method must be a concrete (non-generic) value type.*
- **CS8373** - *The left-hand side of a `ref` assignment must be a ref variable.*
- **CS8388** - *An `out` variable cannot be declared as a ref local*
- **CS8977** - *Cannot use '`ref`', '`in`', or '`out`' in the signature of a method attributed with 'UnmanagedCallersOnly'.*
- **CS9072** - *A deconstruction variable cannot be declared as a ref local*
- **CS9130** - *Using alias cannot be a '`ref`' type.*
- **CS9190** - *`readonly` modifier must be specified after `ref`.*
- **CS9199** - *A `ref readonly` parameter cannot have the Out attribute.*

Warnings:

- **CS9184** - *'Inline arrays' language feature is not supported for inline array types with element field which is either a '`ref`' field, or has type that is not valid as a type argument.*
- **CS9196** - *Reference kind modifier of parameter doesn't match the corresponding parameter in overridden or implemented member.*
- **CS9197** - *Reference kind modifier of parameter doesn't match the corresponding parameter in hidden member.*
- **CS9198** - *Reference kind modifier of parameter doesn't match the corresponding parameter in target.*
- **CS9200** - *A default value is specified for `ref readonly` parameter, but `ref readonly` should be used only for references. Consider declaring the parameter as `in`.*
- **CS9201** - *Ref field should be ref-assigned before use.*

## Reference variable can't be value expression

- **CS0206** - *A non ref-returning property or indexer may not be used as an `out` or `ref` value*
- **CS1510** - *A `ref` or `out` value must be an assignable variable*
- **CS1657** - *Cannot use variable as a `ref` or `out` value*

Warnings:

- **CS9191** - *The `ref` modifier for argument corresponding to `in` parameter is equivalent to `in`. Consider using `in` instead.*
- **CS9192** - *Argument should be passed with `ref` or `in` keyword.*
- **CS9193** - *Argument should be a variable because it is passed to a `ref readonly` parameter*
- **CS9195** - *Argument should be passed with the `in` keyword*

## Readonly fields and variables can't be writable reference variables

- **CS0192** - *A `readonly` field cannot be used as a `ref` or `out` value (except in a constructor)*
- **CS0199** - *A `static readonly` field cannot be used as a `ref` or `out` value (except in a static constructor)*
- **CS1605** - *Cannot use variable as a `ref` or `out` value because it is read-only*
- **CS1649** - *Members of a `readonly` field cannot be used as a `ref` or `out` value (except in a constructor)*
- **CS1651** - *Fields of a `static readonly` field cannot be used as a `ref` or `out` value (except in a static constructor)*
- **CS1655** - *Cannot use fields of type as a `ref` or `out` value*
- **CS8329** - *Cannot use variable as a `ref` or `out` value because it is a readonly variable*
- **CS8330** - *Members of variable cannot be used as a `ref` or `out` value because it is a readonly variable*
- **CS8331** - *Cannot assign to variable or use it as the right hand side of a `ref` assignment because it is a readonly variable*
- **CS8332** - *Cannot assign to a member of variable or use it as the right hand side of a `ref` assignment because it is a readonly variable*
- **CS9116** - *A primary constructor parameter of a `readonly` type cannot be used as a `ref` or `out` value (except in init-only setter of the type or a variable initializer)*
- **CS9119** - *Members of primary constructor parameter of a readonly type cannot be used as a `ref` or `out` value (except in init-only setter of the type or a variable initializer)*

## Ref safety violations

- **CS8166** - *Cannot return a parameter by reference because it is not a `ref` parameter*
- **CS8167** - *Cannot return by reference a member of parameter because it is not a `ref` or `out` parameter*
- **CS8168** - *Cannot return local by reference because it is not a ref local*
- **CS8169** - *Cannot return a member of local variable by reference because it is not a ref local*
- **CS8345** - *Field or auto-implemented property cannot be of type unless it is an instance member of a `ref struct`.*
- **CS8351** - *Branches of a `ref` conditional operator cannot refer to variables with incompatible declaration scopes*
- **CS8374** - *Cannot ref-assign source has a narrower escape scope than destination.*
- **CS9077** - *Cannot return a parameter by reference through a `ref` parameter; it can only be returned in a return statement*
- **CS9078** - *Cannot return by reference a member of parameter through a `ref` parameter; it can only be returned in a return statement*
- **CS9079** - *Cannot ref-assign source to destination because source can only escape the current method through a return statement.*
- **CS9096** - *Cannot ref-assign source to destination because source has a wider value escape scope than destination allowing assignment through destination of values with narrower escapes scopes than source.*
- **CS9109** - *Cannot use `ref`, `out`, or `in` primary constructor parameter inside an instance member*
- **CS9110** - *Cannot use primary constructor parameter that has ref-like type inside an instance member*

Warnings:

- **CS9085** - *This ref-assigns source to destination but source has a narrower escape scope than destination.*
- **CS9086** - *The branches of the ref conditional operator refer to variables with incompatible declaration scopes*
- **CS9087** - *This returns a parameter by reference but it is not a `ref` parameter*
- **CS9089** - *This returns by reference a member of parameter that is not a `ref` or `out` parameter*
- **CS9091** - *This returns local by reference but it is not a ref local*
- **CS9092** - *This returns a member of local by reference but it is not a ref local*
- **CS9093** - *This ref-assigns source to destination but source can only escape the current method through a return statement.*
- **CS9094** - *This returns a parameter by reference through a `ref` parameter; but it can only safely be returned in a return statement*
- **CS9095** - *This returns by reference a member of parameter through a `ref` parameter; but it can only safely be returned in a return statement*
- **CS9097** - *This ref-assigns source to destination but source has a wider value escape scope than destination allowing assignment through destination of values with narrower escapes scopes than source.*

## Old content starts here

### Compiler Error CS0192

Fields of static readonly field 'name' cannot be passed ref or out (except in a static constructor)

A field (variable) marked with the [readonly](../../language-reference/keywords/readonly.md) keyword cannot be passed either to a [ref](../../language-reference/keywords/ref.md) or [out](../../language-reference/keywords/out-parameter-modifier.md) parameter except inside a constructor. For more information, see [Fields](../programming-guide/classes-and-structs/fields.md).

CS0192 also results if the `readonly` field is [static](../../language-reference/keywords/static.md) and the constructor is not marked `static`.

The following sample generates CS0192.

```csharp
// CS0192.cs
class MyClass
{
    public readonly int TestInt = 6;
    static void TestMethod(ref int testInt)
    {
        testInt = 0;
    }

    MyClass()
    {
        TestMethod(ref TestInt);   // OK
    }

    public void PassReadOnlyRef()
    {
        TestMethod(ref TestInt);   // CS0192
    }

    public static void Main()
    {
    }
}
```

### Compiler Error CS0199

Fields of static readonly field 'name' cannot be passed ref or out (except in a static constructor)

A [readonly](../../language-reference/keywords/readonly.md) variable must have the same [static](../../language-reference/keywords/static.md) usage as the constructor in which you want to pass it as a [ref](../../language-reference/keywords/ref.md) or [out](../../language-reference/keywords/out-parameter-modifier.md) parameter. For more information, see [Method Parameters](../../language-reference/keywords/method-parameters.md).

The following sample generates CS0199:

```csharp
// CS0199.cs
class MyClass
{
    public static readonly int TestInt = 6;

    static void TestMethod(ref int testInt)
    {
        testInt = 0;
    }

    MyClass()
    {
        TestMethod(ref TestInt);   // CS0199, TestInt is static
    }

    public static void Main()
    {
    }
}
```

### Compiler Error CS0206

A property or indexer may not be passed as an out or ref parameter

A [property](../programming-guide/classes-and-structs/properties.md) is not available to be passed as a [ref](../../language-reference/keywords/ref.md) or [out](../../language-reference/keywords/out-parameter-modifier.md) parameter. For more information, see [Method Parameters](../../language-reference/keywords/method-parameters.md).

The following sample generates CS0206:

```csharp
// CS0206.cs
public class MyClass
{
    public static int P
    {
        get
        {
            return 0;
        }
        set
        {
        }
    }

    public static void MyMethod(ref int i)
    // public static void MyMethod(int i)
    {
    }

    public static void Main()
    {
        MyMethod(ref P);   // CS0206
        // try the following line instead
        // MyMethod(P);   // CS0206
    }
}
```

### Compiler Error CS0631

ref and out are not valid in this context

The declaration for an [indexer](../programming-guide/indexers/index.md) cannot include the use of [ref](../../language-reference/keywords/ref.md) or [out](../../language-reference/keywords/out-parameter-modifier.md) parameters.

The following sample generates CS0631:

```csharp
// CS0631.cs
public class MyClass
{
    public int this[ref int i]   // CS0631
    // try the following line instead
    // public int this[int i]
    {
        get
        {
            return 0;
        }
    }
}

public class MyClass2
{
    public static void Main()
    {
    }
}
```

### Compiler Error CS0767

Cannot inherit interface with the specified type parameters because it causes method to contain overloads which differ only on ref and out

The following sample generates CS0767:

```csharp
// CS0767.cs (0,0)

using System;

namespace Stuff
{
    interface ISomeInterface<T, U>
    {
        void Method(ref Func<U, T> _);
        void Method(out Func<T, U> _);
    }

    class Explicit : ISomeInterface<int, int>
    {
        void ISomeInterface<int, int>.Method(ref Func<int, int> v) { v = _ => throw new NotImplementedException(); }
        void ISomeInterface<int, int>.Method(out Func<int, int> v) { v = _ => throw new NotImplementedException(); }
    }
}
```

In this example, implementing `ISomeInterface<int,int>` creates two `Method` overloads with the same type of parameter but differs only by `ref`/`out`.  This effectively declares a class that would otherwise raise error CS0663:

```csharp
    class BadClass 
    {
        void Method(ref Func<int, int> v) { v = _ => throw new NotImplementedException(); }
        void Method(out Func<int, int> v) { v = _ => throw new NotImplementedException(); }
    }
```

The simplest way to correct this error is to use different type arguments for `ISomeInterface<T,U>`, for example:

```csharp
    class Explicit : ISomeInterface<int, long>
    {
        void ISomeInterface<int, long>.Method(ref Func<long, int> v) { v = _ => throw new NotImplementedException(); }
        void ISomeInterface<int, long>.Method(out Func<int, long> v) { v = _ => throw new NotImplementedException(); }
    }
```

### Compiler Error CS1510

A ref or out argument must be an assignable variable

Only a variable can be passed as a [ref](../../language-reference/keywords/ref.md) parameter in a method call. A `ref` value is like passing a pointer.

The following sample generates CS1510:

```csharp
// CS1510.cs
public class C
{
   public static int j = 0;

   public static void M(ref int j)
   {
      j++;
   }

   public static void Main ()
   {
      M (ref 2);   // CS1510, can't pass a number as a ref parameter
      // try the following to resolve the error
      // M (ref j);
   }
}
```

### Compiler Error CS1605

Cannot pass 'var' as a ref or out argument because it is read-only

A variable passed as a [ref](../../language-reference/keywords/ref.md) or [out](../../language-reference/keywords/out-parameter-modifier.md) parameter is expected to be modified in the called method. Therefore, it is not possible to pass a read-only parameter as `ref` or `out`.

The following sample generates CS1605:

```csharp
// CS1605.cs
class C
{
    public void Mutate(ref C c) {}

    public void CallMutate()
    {
        Mutate(ref this);   // CS1605
    }
}
```

### Compiler Error CS1623

Iterators cannot have in ref or out parameters

This error occurs if an iterator method takes an `in`, `ref`, or `out` parameter. To avoid this error, remove the `in`, `ref`, or `out` keyword from the method signature.

The following sample generates CS1623:

```csharp
// CS1623.cs
using System.Collections;

class C : IEnumerable
{
    public IEnumerator GetEnumerator()
    {
        yield return 0;
    }

    // To resolve the error, remove in  
    public IEnumerator GetEnumerator(in short i)  // CS1623  
    {
        yield return i;
    }
    // To resolve the error, remove ref  
    public IEnumerator GetEnumerator(ref int i)  // CS1623  
    {
        yield return i;
    }

    // To resolve the error, remove out  
    public IEnumerator GetEnumerator(out float f)  // CS1623  
    {
        f = 0.0F;
        yield return f;
    }
}
```

### Compiler Error CS1649

Members of readonly field 'identifier' cannot be passed ref or out (except in a constructor)

This error occurs if you pass a variable to a function that is a member of a `readonly` field as a `ref` or `out` argument. Since `ref` and `out` parameters may be modified by the function, this is not allowed. To resolve this error, remove the `readonly` keyword on the field, or do not pass the members of the `readonly` field to the function. For example, you might try creating a temporary variable which can be modified and passing the temporary as a `ref` argument, as shown in the following example.

The following sample generates CS1649:

```csharp
// CS1649.cs
public struct Inner
    {
        public int i;
    }

class Outer
{
    public readonly Inner inner = new Inner();
}
 
class D
{
    static void f(ref int iref)
    {
    }

    static void Main()
    {
        Outer outer = new Outer();
        f(ref outer.inner.i);  // CS1649
        // Try this code instead:
        // int tmp = outer.inner.i;
        // f(ref tmp);
    }
}
```

### Compiler Error CS1651

Fields of static readonly field 'identifier' cannot be passed ref or out (except in a static constructor)

This error occurs if you pass a variable to a function that is a member of a static readonly field as a ref argument. Since ref parameters may be modified by the function, this is not allowed. To resolve this error, remove the **readonly** keyword on the field, or do not pass the members of the readonly field to the function. For example, you might try creating a temporary variable which can be modified and passing the temporary as a ref argument, as shown in the following example.

The following sample generates CS1651:

```csharp
// CS1651.cs
public struct Inner
  {
    public int i;
  }

class Outer
{
  public static readonly Inner inner = new Inner();
}

class D
{
   static void f(ref int iref)
   {
   }

   static void Main()
   {
      f(ref Outer.inner.i);  // CS1651
      // Try this instead:
      // int tmp = Outer.inner.i;
      // f(ref tmp);
   }
}
```

### Compiler Error CS1655

Cannot pass fields of 'variable' as a ref or out argument because it is a 'readonly variable type'

This error occurs if you are attempting to pass a member of a [foreach](../../language-reference/statements/iteration-statements.md#the-foreach-statement) variable, a [using](../../language-reference/statements/using.md) variable, or a [fixed](../../language-reference/statements/fixed.md) variable to a function as a ref or out argument. Because these variables are considered read-only in these contexts, this is not allowed.

The following sample generates CS1655:

```csharp
// CS1655.cs
struct S
{
   public int i;
}

class CMain
{
  static void f(ref int iref)
  {
  }

  public static void Main()
  {
     S[] sa = new S[10];
     foreach(S s in sa)
     {
        CMain.f(ref s.i);  // CS1655
     }
  }
}
```

### Compiler Error CS1657

Cannot pass 'parameter' as a ref or out argument because 'reason'

This error occurs when a variable is passed as a [ref](../../language-reference/keywords/ref.md) or [out](../../language-reference/keywords/out-parameter-modifier.md) argument in a context in which that variable is readonly. Readonly contexts include [foreach](../../language-reference/statements/iteration-statements.md#the-foreach-statement) iteration variables, [using](../../language-reference/statements/using.md) variables, and `fixed` variables. To resolve this error, do not call functions that take the `foreach`, `using` or `fixed` variable as a `ref` or `out` parameter in `using` blocks, `foreach` statements, and `fixed` statements.

The following sample generates CS1657:

```csharp
// CS1657.cs
using System;
class C : IDisposable
{
    public int i;
    public void Dispose() {}
}

class CMain
{
    static void f(ref C c)
    {
    }
    static void Main()
    {
        using (C c = new C())
        {
            f(ref c);  // CS1657
        }
    }
}
```

The following code illustrates the same problem in a `fixed` statement:

```csharp
// CS1657b.cs
// compile with: /unsafe
unsafe class C
{
    static void F(ref int* p)
    {
    }

    static void Main()
    {
        int[] a = new int[5];
        fixed(int* p = a) F(ref p); // CS1657
    }
}
```

### Compiler Error CS1741

 `ref` or `out` parameter cannot have a default value

Using `ref` or `out` in a method signature causes arguments to be passed by reference, making the parameter an alias for the argument.  Since the parameter must be a variable should the default value be used, no variable would exist as the alias for the argument.

The following sample generates CS1741:

```csharp
// CS1741.cs (6,21)
class Program
{
    static void Main(string[] args)
    {
        void RefOut(ref int x = 2)
        {
            x++;
        }
        int y = 2;
        RefOut(ref y);
    }
}
```

In this example, removing the `ref` modifier from the method signature would be a logic error--the method's body would have no visible side effects when executed.  To correct this error, remove the unnecessary default value from the method signature:

```csharp
    static void Main(string[] args)
    {
        void RefOut(ref int x)
        {
            x++;
        }
        int y = 2;
        RefOut(ref y);
    }
```

### Compiler Error CS1939

Cannot pass the range variable 'name' as an out or ref parameter.

A range variable is a read-only variable that is introduced in a query expression and serves as an identifier for each successive element in a source sequence. Because it cannot be modified in any way, there is no point in passing it by `ref` or `out`. Therefore, both operations are not valid.

To correct this error, pass the range variable by value.

The following example generates CS1939:

```csharp
// cs1939.cs
using System.Linq;
class Test
{
    public static void F(ref int i)
    {
    }
    public static void Main()
    {
        var list = new int[] { 0, 1, 2, 3, 4, 5 };
        var q = from x in list
                let k = x
                select Test.F(ref x); // CS1939
    }
}
```

### Compiler Error CS1988

Async methods cannot have `ref`, `in` or `out` parameters

`ref` parameters are not supported in `async` methods because the method may not have completed when control returns to the calling code.  Any changes to the referenced variables will not be visible to the calling code, resulting in a CS1988 error.

The following sample generates CS1988:

```csharp
class C
{
    async Task M(ref int left, ref int right)
    {
        await Task.Run(() =>
        {
            left = 1;
            right = 2;
        });
    }
}
```

One reason to use the `ref` keyword is that a method conceptually has more than one result but implemented with more than one `ref` parameter.  In this case, correcting the error can be achieved by transforming the method to return a single result through the use of a tuple:

```csharp
    async Task<(int,int)> M(int left, int right)
    {
        await Task.Run(() =>
        {
            left = 1;
            right = 2;
        });

        return (left, right);
    }
```

### Compiler Error CS8166

Cannot return a parameter by reference because it is not a ref parameter

The following sample generates CS8166:

```csharp
// CS8166.cs (11,20)

public class Test
{
    public struct S1
    {
        public char x;
    }

    ref char Test1(char arg1, S1 arg2)
    {
        return ref arg1;
    }
}
```

To return a parameter that is not passed by reference, refactoring to use return by value will correct this error:

```csharp
public class Test
{
    public struct S1
    {
        public char x;
    }

    char Test1(char arg1, S1 arg2)
    {
        return arg1;
    }
}
```

### Compiler Error CS8167

Cannot return by reference a member of parameter because it is not a ref or out parameter

The following sample generates CS8167:

```csharp
// CS8167.cs (11,20)

public class Test
{
    public struct S1
    {
        public char x;
    }

    ref char Test1(char arg1, S1 arg2)
    {
        return ref arg1;
    }
}
```

To return a parameter that is not declared with `out` or `ref`, refactoring to return by value corrects this error:

```csharp
public class Test
{
    public struct S1
    {
        public char x;
    }

    char Test1(char arg1, S1 arg2)
    {
        return arg1;
    }
}
```

### Compiler Error CS8168

Cannot return local by reference because it is not a ref local

The following sample generates CS8168:

```csharp
// CS8168.cs (8,14)

public class Test
{
    ref char Test1()
    {
        char l = default(char);

        return ref l;
    }
}
```

The scope of `l` is within the body of the method.  If a reference to `l` were to leave the scope of this method, that reference would outlive the object to which it refers.  The compiler's scope rules cause error CS8168 to be generated in this example.

To return the value of a local, refactoring to return by value will correct this error:

```csharp
// CS8168.cs (8,14)

public class Test
{
    char Test1()
    {
        char l = default(char);

        return l;
    }
}
```

### Compiler Error CS8169

Cannot return a member of local by reference because it is not a ref local

The following sample generates CS8169:

```csharp
// CS8169.cs (17,15)

public class Test
{
    public struct S1
    {
        public char x;
    }

    ref char Test1(char arg1, ref S1 arg2)
    {
        S1 l = default(S1);
        // valid
        ref char r = ref l.x;

        // invalid
        return ref l.x;
    }
}
```

Using a `ref` to `S1.x` within the `Test1` method is valid because use of the reference does not leave the scope of the value type `l`.  Upon returning from `Test`, `l` would become invalid along with any references to its properties.

### Compiler Error CS8373

The left-hand side of a ref assignment must be a ref variable.

The following sample generates CS8373:

```csharp
// CS8373.cs (6,90)

public class C
{
    void M(int a, ref int b)
    {
        a = ref b;
    }
}
```

To assign the value of a `ref` variable, removing the `ref` keyword corrects this error:

```csharp
public class C
{
    void M(int a, ref int b)
    {
        a = b;
    }
}
```

### Compiler Error CS8374

Cannot ref-assign to because has a narrower escape scope than.

The following sample generates CS8374 because the reference contained in `r1` is externally visible but the scope of `rx`'s value (its lifetime) is local:

```csharp
// CS8374.cs (6,9)

class C
{
    void M(ref int r1)
    {
        int x = 0;
        ref int rx = ref x;
        for (int i = 0; i < (r1 = ref rx); i++)
        {
        }
    }
}
```
