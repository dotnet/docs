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
- [**CS0080**](#type-parameter-declaration-and-naming): *Constraints are not allowed on non-generic declarations*
- [**CS0081**](#type-parameter-declaration-and-naming): *Type parameter declaration must be an identifier not a type*
- [**CS0224**](#type-argument-count-and-usage): *A method with vararg cannot be generic, be in a generic type, or have a params parameter*
- [**CS0304**](#constructor-constraints): *Cannot create an instance of the variable type 'type' because it does not have the new() constraint*
- [**CS0305**](#type-argument-count-and-usage): *Using the generic type 'generic type' requires 'number' type arguments*
- [**CS0306**](#type-argument-count-and-usage): *The type 'type' may not be used as a type argument*
- [**CS0307**](#type-argument-count-and-usage): *The 'construct' 'identifier' is not a generic method. If you intended an expression list, use parentheses around the < expression.*
- [**CS0308**](#type-argument-count-and-usage): *The non-generic type-or-method 'identifier' cannot be used with type arguments.*
- [**CS0310**](#constructor-constraints): *The type 'typename' must be a non-abstract type with a public parameterless constructor in order to use it as parameter 'parameter' in the generic type or method 'generic'*
- [**CS0311**](#constraint-satisfaction-and-conversions): *The type 'type1' cannot be used as type parameter 'T' in the generic type or method '\<name>'. There is no implicit reference conversion from 'type1' to 'type2'.*
- [**CS0312**](#constraint-satisfaction-and-conversions): *The type 'type1' cannot be used as type parameter 'name' in the generic type or method 'name'. The nullable type 'type1' does not satisfy the constraint of 'type2'.*
- [**CS0313**](#constraint-satisfaction-and-conversions): *The type 'type1' cannot be used as type parameter 'parameter name' in the generic type or method 'type2'. The nullable type 'type1' does not satisfy the constraint of 'type2'. Nullable types cannot satisfy any interface constraints.*
- [**CS0314**](#constraint-satisfaction-and-conversions): *The type 'type1' cannot be used as type parameter 'name' in the generic type or method 'name'. There is no boxing conversion or type parameter conversion from 'type1' to 'type2'.*
- [**CS0315**](#constraint-satisfaction-and-conversions): *The type 'valueType' cannot be used as type parameter 'T' in the generic type or method 'TypeorMethod\\<T>'. There is no boxing conversion from 'valueType' to 'referenceType'.*
- [**CS0403**](#generic-type-usage-restrictions): *Cannot use null as type argument for 'type parameter' because it may not be a reference type. Consider using 'default' instead.*
- [**CS0412**](#type-parameter-declaration-and-naming): *'parameter': a parameter, local variable, or local function cannot have the same name as a method type parameter*
- [**CS0413**](#generic-type-usage-restrictions): *The type parameter 'type parameter' cannot be used with the 'as' operator because it does not have a class type constraint nor a 'class' constraint*
- [**CS0417**](#constructor-constraints): *'identifier': cannot provide arguments when creating an instance of a variable type*
- [**CS0694**](#type-parameter-declaration-and-naming): *Type parameter 'identifier' has the same name as the containing type, or method*
- [**CS0695**](#generic-type-usage-restrictions): *Generic class cannot implement both 'generic interface' and 'generic interface' because they may unify for some type parameter substitutions*
- [**CS0698**](#generic-type-usage-restrictions): *A generic type cannot derive from 'type' because it is an attribute class*
- [**CS9338**](#generic-type-usage-restrictions): *Type argument 'type' must be public because it is used in a public signature.*

## Type parameter declaration and naming

The following errors relate to how type parameters are declared and named in generic types and methods:

- **CS0080**: *Constraints are not allowed on non-generic declarations*
- **CS0081**: *Type parameter declaration must be an identifier not a type*
- **CS0412**: *'generic': a parameter or local variable cannot have the same name as a method type parameter*
- **CS0694**: *Type parameter 'identifier' has the same name as the containing type, or method*

Type parameters must be declared using identifiers (like `T` or `TInput`), not actual types. Constraints can only be applied to generic declarations. Additionally, type parameter names must not conflict with the containing type, method, or other parameters.

For more information, see [Generic Type Parameters](../programming-guide/generics/generic-type-parameters.md) and [Generics](../fundamentals/types/generics.md).

### Constraints on non-generic declarations

The syntax found may only be used in a generic declaration to apply constraints to the type parameter.

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

### Type parameter declaration

When you declare a generic method or type, specify the type parameter as an identifier, for example "T" or "inputType". When client code calls the method, it supplies the type, which replaces each occurrence of the identifier in the method or class body.

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

### Type parameter name conflicts

Type parameter names must not conflict with other identifiers in scope.

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

Type parameter names also cannot match the containing type or method name:

```csharp
// CS0694.cs
// compile with: /target:library
class C<C> {}   // CS0694

class A
{
   public void F<F>(F arg);   // CS0694
}
```

## Type argument count and usage

The following errors relate to providing the correct number and type of type arguments to generic types and methods:

- **CS0224**: *A method with vararg cannot be generic, be in a generic type, or have a params parameter*
- **CS0305**: *Using the generic type 'generic type' requires 'number' type arguments*
- **CS0306**: *The type 'type' may not be used as a type argument*
- **CS0307**: *The 'construct' 'identifier' is not a generic method. If you intended an expression list, use parentheses around the < expression.*
- **CS0308**: *The non-generic type-or-method 'identifier' cannot be used with type arguments.*

These errors occur when generic types or methods are used incorrectly with type arguments, or when certain restrictions on generic declarations are violated.

For more information, see [Generic Type Parameters](../programming-guide/generics/generic-type-parameters.md) and [Generics](../fundamentals/types/generics.md).

### CS0224: Vararg method restrictions

A method with vararg cannot be generic, be in a generic type, or have a params parameter. This restriction applies to methods that use the `__arglist` keyword for variable argument lists.

### CS0305: Wrong number of type arguments

This error occurs when the expected number of type arguments was not found. Use the required number of type arguments for the generic type:

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

### CS0306: Invalid type argument

Certain types cannot be used as type arguments. This error commonly occurs when pointer types are used as type arguments:

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

### CS0307 and CS0308: Non-generic construct with type arguments

The construct named was not a generic type or method, but it was used with type arguments. Remove the type arguments in angle brackets, or redeclare the construct as a generic type or method.

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

The following example also generates CS0308. To resolve the error, use the directive "using System.Collections.Generic":

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

## Constructor constraints

The following errors relate to the `new()` constraint on generic type parameters:

- **CS0304**: *Cannot create an instance of the variable type 'type' because it does not have the new() constraint*
- **CS0310**: *The type 'typename' must be a non-abstract type with a public parameterless constructor in order to use it as parameter 'parameter' in the generic type or method 'generic'*
- **CS0417**: *'identifier': cannot provide arguments when creating an instance of a variable type*

When you implement a generic class and want to use the `new` keyword to create a new instance of any type that is supplied for a type parameter `T`, you must apply the [new() constraint](../keywords/new-constraint.md) to `T` in the class declaration, as shown in the following example.

```csharp
class C<T> where T : new()
```

The `new()` constraint enforces type safety by guaranteeing that any concrete type that is supplied for `T` has a parameterless constructor.

### CS0304: Missing new() constraint

This error occurs if you attempt to use the `new` operator to create an instance of type parameter `T` when `T` does not specify the `new()` constraint:

```csharp
// CS0304.cs
// Compile with: /target:library.
class C<T>
{
    // The following line generates CS0304.
    T t = new T();
}

class C2<T>
{
    public void ExampleMethod()
    {
        // The following line also generates CS0304.
        T t = new T();
    }
}
```

To avoid the error, declare the class by using the `new()` constraint:

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

### CS0310: Type must have parameterless constructor

When a generic type or method defines the `new()` constraint in its `where` clause, any type argument must have a public parameterless constructor. The following sample generates CS0310:

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

To avoid this error, make sure the type has the correct constructor, or modify the constraint clause of the generic type or method.

### CS0417: Cannot provide arguments to constructor

This error occurs if a call to the `new` operator on a type parameter has arguments. The only constructor that can be called using the `new` operator on an unknown parameter type is a parameterless constructor. If you need to call another constructor, consider using a class type constraint or interface constraint:

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

For more information, see [Constraints on type parameters](../programming-guide/generics/constraints-on-type-parameters.md).

## Constraint satisfaction and conversions

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

## Constraint satisfaction and conversions

The following errors relate to type arguments not satisfying the constraints of generic type parameters:

- **CS0311**: *The type 'type1' cannot be used as type parameter 'T' in the generic type or method '\<name>'. There is no implicit reference conversion from 'type1' to 'type2'.*
- **CS0312**: *The type 'type1' cannot be used as type parameter 'name' in the generic type or method 'name'. The nullable type 'type1' does not satisfy the constraint of 'type2'.*
- **CS0313**: *The type 'type1' cannot be used as type parameter 'parameter name' in the generic type or method 'type2'. The nullable type 'type1' does not satisfy the constraint of 'type2'. Nullable types cannot satisfy any interface constraints.*
- **CS0314**: *The type 'type1' cannot be used as type parameter 'name' in the generic type or method 'name'. There is no boxing conversion or type parameter conversion from 'type1' to 'type2'.*
- **CS0315**: *The type 'valueType' cannot be used as type parameter 'T' in the generic type or method 'TypeorMethod\\<T>'. There is no boxing conversion from 'valueType' to 'referenceType'.*

When a constraint is applied to a generic type parameter, an implicit identity or reference conversion must exist from the concrete argument to the type of the constraint.

For more information, see [Constraints on type parameters](../programming-guide/generics/constraints-on-type-parameters.md).

### CS0311: No implicit reference conversion

To correct this error, change the type argument to one that fulfills the constraint, or enable an implicit reference or identity conversion (for example, make the second type inherit from the first):

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

Note that an implicit numeric conversion (such as from `short` to `int`) does not satisfy a generic type parameter constraint.

### CS0314: Type parameter constraint not satisfied in derived class

When a generic type uses a type parameter that is constrained, any derived class must also satisfy those same constraints. Add the constraint to the derived class:

```csharp
// cs0314.cs
// Compile with: /target:library
public class ClassConstraint { }

public class A<T> where T : ClassConstraint
{ }

public class B<T> : A<T> //CS0314
{ }

// Correct: Add the constraint to the derived class
public class C<T> : A<T> where T : ClassConstraint
{ }
```

### CS0315: No boxing conversion

This error occurs when you try to use a value type as a type argument where a reference type is required by the constraint. One solution is to redefine the struct as a class:

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

### CS0312 and CS0313: Nullable type constraints

A nullable value type is distinct from its non-nullable counterpart. No implicit reference conversion or identity conversion exists between them, and a nullable boxing conversion does not satisfy a generic type constraint.

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

To correct this error, remove the constraint or make the second type argument either `int?` or `object`.

Similarly, a nullable value type cannot satisfy interface constraints. The following code generates CS0313:

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

One solution is to specify an ordinary `ImplStruct` as the first type argument, then modify `TestMethod` to create a nullable version in its return statement using `return new Nullable<T>(t);`.

## Generic type usage restrictions

The following errors relate to restrictions on how generic types can be used:

- **CS0403**: *Cannot use null as type argument for 'type parameter' because it may not be a reference type. Consider using 'default' instead.*
- **CS0413**: *The type parameter 'type parameter' cannot be used with the 'as' operator because it does not have a class type constraint nor a 'class' constraint*
- **CS0695**: *Generic class cannot implement both 'generic interface' and 'generic interface' because they may unify for some type parameter substitutions*
- **CS0698**: *A generic type cannot derive from 'type' because it is an attribute class*
- **CS9338**: *Type argument 'type' must be public because it is used in a public signature.*

For more information, see [Constraints on type parameters](../programming-guide/generics/constraints-on-type-parameters.md).

### CS0403: Null assignment to type parameter

You cannot assign null to an unconstrained type parameter because it might be a value type, which does not allow null assignment. If your generic class is not intended to accept value types, use the class type constraint. If it can accept value types, such as the built-in types, you may be able to replace the assignment to null with the expression `default(T)`.

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

### CS0413: Type parameter with as operator

This error occurs if a generic type uses the [as](../operators/type-testing-and-cast.md#the-as-operator) operator, but that generic type does not have a class type constraint. The `as` operator is only allowed with reference and nullable value types, so the type parameter must be constrained to guarantee that it is not a value type. To avoid this error, use a class type constraint or a reference type constraint.

This is because the `as` operator could return `null`, which is not a possible value for a value type, and the type parameter must be treated as a value type unless it is a class type constraint or a reference type constraint.

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

### CS0695: Cannot implement same generic interface with different type parameters

This error occurs when a generic class implements more than one parameterization of the same generic interface, and there exists a type parameter substitution which would make the two interfaces identical. To avoid this error, implement only one of the interfaces, or change the type parameters to avoid the conflict.

The following sample generates CS0695.

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

### CS0698: Generic type cannot derive from attribute

Any class that derives from an attribute class is an attribute. Attributes are not allowed to be generic types.

The following sample generates CS0698.

```csharp
// CS0698.cs
class C<T> : System.Attribute  // CS0698
{
}
```

### CS9338: Type argument visibility

Type arguments used in public signatures must themselves be publicly accessible. This error occurs when you use a non-public type as a type argument in a public context.

Ensure that all type arguments used in public or protected members are themselves public:
