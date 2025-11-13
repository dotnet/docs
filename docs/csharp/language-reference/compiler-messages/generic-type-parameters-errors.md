---
title: Resolve errors and warnings related to generic type parameters and type arguments.
description: These compiler errors and warnings indicate errors in generic type parameters and type arguments.
f1_keywords:
  - "CS0080"
  - "CS0081"
  - "CS0304"
  - "CS0305"
  - "CS0306"
  - "CS0307"
  - "CS0308"
  - "CS0310"
  - "CS0311"
  - "CS0312"
  - "CS0313"
  - "CS0314"
  - "CS0315"
  - "CS0403"
  - "CS0412"
  - "CS0413"
  - "CS0417"
  - "CS0694"
  - "CS0695"
  - "CS0698"
  - "CS9338"
helpviewer_keywords:
  - "CS0080"
  - "CS0081"
  - "CS0304"
  - "CS0305"
  - "CS0306"
  - "CS0307"
  - "CS0308"
  - "CS0310"
  - "CS0311"
  - "CS0312"
  - "CS0313"
  - "CS0314"
  - "CS0315"
  - "CS0403"
  - "CS0412"
  - "CS0413"
  - "CS0694"
  - "CS0695"
  - "CS0698"
  - "CS0417"
  - "CS9338"
ms.date: 11/13/2025
ai-usage: ai-assisted
---
# Resolve errors and warnings related to generic type parameters and generic type arguments

This article covers the following compiler errors:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->
- [**CS0080**](#constraints-on-non-generic-declarations): *Constraints are not allowed on non-generic declarations*
- [**CS0081**](#type-parameter-declaration): *Type parameter declaration must be an identifier not a type*
- [**CS0224**](#vararg-method-restrictions): *A method with vararg cannot be generic, be in a generic type, or have a params parameter*
- [**CS0304**](#new-constraint): *Cannot create an instance of the variable type 'type' because it does not have the new() constraint*
- [**CS0305**](#type-argument-count): *Using the generic type 'generic type' requires 'number' type arguments*
- [**CS0306**](#invalid-type-argument): *The type 'type' may not be used as a type argument*
- [**CS0307**](#non-generic-construct): *The 'construct' 'identifier' is not a generic method. If you intended an expression list, use parentheses around the < expression.*
- [**CS0308**](#non-generic-construct): *The non-generic type-or-method 'identifier' cannot be used with type arguments.*
- [**CS0310**](#new-constraint): *The type 'typename' must be a non-abstract type with a public parameterless constructor in order to use it as parameter 'parameter' in the generic type or method 'generic'*
- [**CS0311**](#constraint-conversions): *The type 'type1' cannot be used as type parameter 'T' in the generic type or method '\<name>'. There is no implicit reference conversion from 'type1' to 'type2'.*
- [**CS0312**](#nullable-type-constraints): *The type 'type1' cannot be used as type parameter 'name' in the generic type or method 'name'. The nullable type 'type1' does not satisfy the constraint of 'type2'.*
- [**CS0314**](#constraint-conversions): *The type 'type1' cannot be used as type parameter 'name' in the generic type or method 'name'. There is no boxing conversion or type parameter conversion from 'type1' to 'type2'.*
- [**CS0313**](#nullable-type-constraints): *The type 'type1' cannot be used as type parameter 'parameter name' in the generic type or method 'type2'. The nullable type 'type1' does not satisfy the constraint of 'type2'. Nullable types cannot satisfy any interface constraints.*
- [**CS0413**](#type-parameter-with-as-operator): *The type parameter 'type parameter' cannot be used with the 'as' operator because it does not have a class type constraint nor a 'class' constraint*
- [**CS0417**](#new-constraint): *'identifier': cannot provide arguments when creating an instance of a variable type*
- [**CS0338**](#type-argument-visibility): *Inconsistent accessibility: type argument is less accessible than class.*

## Constraints on non-generic declarations

The syntax found may only be used in a generic declaration to apply constraints to the type parameter. For more information, see [Generics](../fundamentals/types/generics.md).

The following sample generates CS0080 because MyClass is not a generic class and Foo is not a generic method.

```csharp
namespace MyNamespace
{
    public class MyClass where MyClass : System.IDisposable // CS0080    //the following line shows an example of correct syntax
    //public class MyClass<T> where T : System.IDisposable
    {
        public void Foo() where Foo : new() // CS0080
        //the following line shows an example of correct syntax
        //public void Foo<U>() where U : struct
        {
        }
    }

    public class Program
    {
        public static void Main()
        {
        }
    }
}
```

## Type parameter declaration

When you declare a generic method or type, specify the type parameter as an identifier, for example "T" or "inputType". When client code calls the method, it supplies the type, which replaces each occurrence of the identifier in the method or class body. For more information, see [Generic Type Parameters](../programming-guide/generics/generic-type-parameters.md).

```csharp
// CS0081.cs
class MyClass
{
   public void F<int>() {}   // CS0081
   public void F<T>(T input) {}   // OK

   public static void Main()
   {
      MyClass a = new MyClass();
      a.F<int>(2);
      a.F<double>(.05);
   }
}
```

## Vararg method restrictions

A method with vararg cannot be generic, be in a generic type, or have a params parameter. This restriction applies to methods that use the `__arglist` keyword for variable argument lists.

## new() constraint

When you implement a generic class, and you want to use the `new` keyword to create a new instance of any type that is supplied for a type parameter `T`, you must apply the [new() constraint](../keywords/new-constraint.md) to `T` in the class declaration, as shown in the following example.

```csharp
class C<T> where T : new()
```

The `new()` constraint enforces type safety by guaranteeing that any concrete type that is supplied for `T` has a parameterless constructor. CS0304 occurs if you attempt to use the `new` operator in the body of the class to create an instance of type parameter `T` when `T` does not specify the `new()` constraint. On the client side, if code attempts to instantiate the generic class with a type that has no parameterless constructor, that code will generate CS0310.

The following example generates CS0304.

```csharp
// CS0304.cs
// Compile with: /target:library.
class C<T>
{
    // The following line generates CS0304.
    T t = new T();
}
```

The `new` operator also is not allowed in methods of the class.

```csharp
// Compile with: /target:library.
class C<T>
{
    public void ExampleMethod()
    {
        // The following line generates CS0304.
        T t = new T();
    }
}
```

To avoid the error, declare the class by using the `new()` constraint, as shown in the following example.

```csharp
// Compile with: /target:library.
class C<T> where T : new()
{
    T t = new T();

    public void ExampleMethod()
    {
        T t = new T();
    }
}
```

The generic type or method defines the `new()` constraint in its `where` clause, so any type must have a public parameterless constructor in order to be used as a type argument for that generic type or method. To avoid this error, make sure that the type has the correct constructor, or modify the constraint clause of the generic type or method.

The following sample generates CS0310:

```csharp
// CS0310.cs
using System;

class G<T> where T : new()
{
    T t;

    public G()
    {
        t = new T();
        Console.WriteLine(t);
    }
}

class B
{
    private B() { }
    // Try this instead:
    // public B() { }
}

class CMain
{
    public static void Main()
    {
        G<B> g = new G<B>();   // CS0310
        Console.WriteLine(g.ToString());
    }
}
```

This error occurs if a call to the `new` operator on a type parameter has arguments. The only constructor that can be called by using the `new` operator on an unknown parameter type is a constructor that has no arguments. If you need to call another constructor, consider using a class type constraint or interface constraint.

The following example generates CS0417:

```csharp
// CS0417
class ExampleClass<T> where T : new()
{
    // The following line causes CS0417.
    T instance1 = new T(1);

    // The following line doesn't cause the error.
    T instance2 = new T();
}
```

## Type argument count

This error occurs when the expected number of type arguments was not found. To resolve C0305, use the required number of type arguments.

## Example

The following sample generates CS0305.

```csharp
// CS0305.cs
public class MyList<T> {}
public class MyClass<T> {}

class MyClass
{
   public static void Main()
   {
      MyList<MyClass, MyClass> list1 = new MyList<MyClass>();   // CS0305
      MyList<MyClass> list2 = new MyList<MyClass>();   // OK
   }
}
```

## Invalid type argument

The type used as a type parameter is not allowed. This could be because the type is a pointer type.

The following example generates CS0306:

```csharp
// CS0306.cs
class C<T>
{
}

class M
{
    // CS0306 – int* not allowed as a type parameter
     C<int*> f;
}
```

## Non-generic construct

The construct named was not a type or a method, the only constructs that can take generic arguments. Remove the type arguments in angle brackets. If a generic is needed, declare your generic construct as a generic type or method.

The method or type is not generic, but it was used with type arguments. To avoid this error, remove the angled brackets and type arguments, or redeclare the method or type as a generic method or type.

The following sample generates CS0307:

```csharp
// CS0307.cs
class C
{
   public int P { get { return 1; } }
   public static void Main()
   {
      C c = new C();
      int p = c.P<int>();  // CS0307 – C.P is a property
      // Try this instead
      // int p = c.P;
   }
}
```

The following example generates CS0308:

```csharp
// CS0308a.cs
class MyClass
{
   public void F() {}
   public static void Main()
   {
      F<int>();  // CS0308 – F is not generic.
      // Try this instead:
      // F();
   }
}
```

The following example also generates CS0308. To resolve the error, use the directive "using System.Collections.Generic."

```csharp
// CS0308b.cs
// compile with: /t:library
using System.Collections;
// To resolve, uncomment the following line:
// using System.Collections.Generic;
public class MyStack<T>
{
    // Store the elements of the stack:
    private T[] items = new T[100];
    private int stack_counter = 0;

    // Define the iterator block:
    public IEnumerator<T> GetEnumerator()   // CS0308
    {
        for (int i = stack_counter - 1 ; i >= 0; i--)
        yield return items[i];
    }
}
```

## Constraint conversions

When a constraint is applied to a generic type parameter, an implicit identity or reference conversion must exist from the concrete argument to the type of the constraint.

## To correct this error

1. Change the type argument you are using to one that fulfills the constraint.

2. If you own the class, you can remove the constraint or else do something to enable an implicit reference or identity conversion. For example, you can make the second type inherit from the first.

## Example

```csharp
// cs0311.cs
class B {}
class C {}
class Test<T> where T : C
{ }

class Program
{
    static void Main()
    {
        Test<B> test = new Test<B>(); //CS0311
    }
}
```

If this error occurs when trying to use a value-type argument, notice that an implicit numeric conversion, for example from `short` to `int`, does not satisfy a generic type parameter.

When a generic type uses a type parameter that is constrained, the new class must also satisfy those same constraints.

## To correct this error

1. In the example that follows, add `where T : ClassConstraint` to class `B`.

## Example

The following code generates CS0314:

```csharp
// cs0314.cs
// Compile with: /target:library
public class ClassConstraint { }

public class A<T> where T : ClassConstraint
{ }

public class B<T> : A<T> //CS0314
{ }

// Try using this instead.
public class C<T> : A<T> where T : ClassConstraint
{ }
```

This error occurs when you constrain a generic type to a particular class, and try to construct an instance of that class by using a value type that cannot be implicitly boxed to it.

## To correct this error

1. One solution is to redefine the struct as a class.

## Example

The following example generates CS0315:

```csharp
// cs0315.cs
public class ClassConstraint { }
public struct ViolateClassConstraint { }

public class Gen<T> where T : ClassConstraint
{
}
public class Test
{
    public static int Main()
    {
        Gen<ViolateClassConstraint> g = new Gen<ViolateClassConstraint>(); //CS0315
        return 1;
    }
}
```

## Nullable type constraints

A nullable value type is distinct from its non-nullable counterpart; no implicit reference conversion or identify conversion exists between them. A nullable boxing conversion does not satisfy a generic type constraint. In the example that follows, the first type parameter is a `Nullable<int>` and the second type parameter is a `System.Int32`.

## To correct this error

1. Remove the constraint.

2. In the following example, make the second type argument either `int?` or `object`.

## Example

The following code generates CS0312:

```csharp
// cs0312.cs
class Program
{
    static void MTyVar<T, U>() where T : U { }

    static int Main()
    {
        MTyVar<int?, int>(); // CS0312
        return 1;
    }
}
```

Although a nullable value type is distinct from a non-nullable type, various kinds of conversions are allowed between nullable and non-nullable values.

A nullable value type is not equivalent to its non-nullable counterpart. In the example that follows, `ImplStruct` satisfies the `BaseInterface` constraint but `ImplStruct?` does not because `Nullable<ImplStruct>` does not implement `BaseInterface`.

## To correct this error

1. Using the code that follows as an example, one solution is to specify an ordinary `ImplStruct` as the first type argument in the call to `TestMethod`. Then modify `TestMethod` to create a nullable version of `Implstruct` in its return statement:

    ```csharp
    return new Nullable<T>(t);
    ```

## Example

The following code generates CS0313:

```csharp
// cs0313.cs
public interface BaseInterface { }
public struct ImplStruct : BaseInterface { }

public class TestClass
{
    public T? TestMethod<T, U>(T t) where T : struct, U
    {
        return t;
    }
}

public class NullableTest
{
    public static void Run()
    {

        TestClass tc = new TestClass();
        tc.TestMethod<ImplStruct?, BaseInterface>(new ImplStruct?()); // CS0313
    }
    public static void Main()
    { }
}
```

## Null assignment to type parameter

You cannot assign null to the unknown type named because it might be a value type, which does not allow null assignment. If your generic class is not intended to accept value types, use the class type constraint. If it can accept value types, such as the built-in types, you may be able to replace the assignment to null with the expression `default(T)`, as shown in the following example.

## Example

The following sample generates CS0403.

```csharp
// CS0403.cs
// compile with: /target:library
class C<T>
{
   public void f()
   {
      T t = null;  // CS0403
      T t2 = default(T);   // OK
    }
}

class D<T> where T : class
{
   public void f()
   {
      T t = null;  // OK
    }
}
```

## Type parameter name conflict

There is a name conflict between the type parameter of a generic method and a local variable in the method or one of the method's parameters. To avoid this error, rename any conflicting parameters or local variables.

## Example

The following sample generates CS0412:

```csharp
// CS0412.cs
using System;

class C
{
    // Parameter name is the same as method type parameter name
    public void G<T>(int T)  // CS0412
    {
    }
    public void F<T>()
    {
        // Method local variable name is the same as method type
        // parameter name
        double T = 0.0;  // CS0412
        Console.WriteLine(T);
    }

    public static void Main()
    {
    }
}
```

## Type parameter with as operator

This error occurs if a generic type uses the [as](../operators/type-testing-and-cast.md#the-as-operator) operator, but that generic type does not have a class type constraint. The `as` operator is only allowed with reference and nullable value types, so the type parameter must be constrained to guarantee that it is not a value type. To avoid this error, use a class type constraint or a reference type constraint.

This is because the `as` operator could return `null`, which is not a possible value for a value type, and the type parameter must be treated as a value type unless it is a class type constraint or a reference type constraint.

## Example

The following sample generates CS0413.

```csharp
// CS0413.cs
// compile with: /target:library
class A {}
class B : A {}

class CMain
{
   A a = null;
   public void G<T>()
   {
      a = new A();
      System.Console.WriteLine (a as T);  // CS0413
   }

   // OK
   public void H<T>() where T : A
   {
      a = new A();
      System.Console.WriteLine (a as T);
   }
}
```

## Type parameter same name as containing type or method

You must use a different name for the type parameter since the type parameter's name cannot be identical to the type or method name that contains the type parameter.

### Example 1

The following sample generates CS0694.

```csharp
// CS0694.cs
// compile with: /target:library
class C<C> {}   // CS0694
```

### Example 2

In addition to the above case involving a generic class, this error may occur with a method:

```csharp
// CS0694_2.cs
// compile with: /target:library
class A
{
   public void F<F>(F arg);   // CS0694
}
```

## Cannot implement same generic interface with different type parameters

This error occurs when a generic class implements more than one parameterization of the same generic interface, and there exists a type parameter substitution which would make the two interfaces identical. To avoid this error, implement only one of the interfaces, or change the type parameters to avoid the conflict.

The following sample generates CS0695:

```csharp
// CS0695.cs
// compile with: /target:library

interface I<T>
{
}

class G<T1, T2> : I<T1>, I<T2>  // CS0695
{
}
```

## Generic type cannot derive from attribute

Any class that derives from an attribute class is an attribute. Attributes are not allowed to be generic types.

The following sample generates CS0698:

```csharp
// CS0698.cs
class C<T> : System.Attribute  // CS0698
{
}
```

## Type argument visibility

The following errors relate to accessibilty of type arguments:

- **CS0338**: *Inconsistent accessibility: type argument is less accessible than class.*
