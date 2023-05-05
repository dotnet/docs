---
title: Lambda expression warnings
description: Ths article helps you diagnose and correct compiler errors and warnings for lambda expression declarations and usage.
f1_keywords:
  - "CS0748"
  - "CS0834"
  - "CS0835"
  - "CS1621"
  - "CS1628"
  - "CS1632"
  - "CS1673"
  - "CS1686"
  - "CS1706"
  - "CS1951"
  - "CS1952"
  - "CS8153"
  - "CS8155"
  - "CS8175"
  - "CS9098" # ERR_ImplicitlyTypedDefaultParameter: Implicitly typed lambda parameter '{0}' cannot have a default value.
  - "CS9099" # WRN_OptionalParamValueMismatch: The default parameter value does not match in the target delegate type.
  - "CS9100" # WRN_ParamsArrayInLambdaOnly: Parameter has params modifier in lambda but not in target delegate type.
  # Add the following (currently undocumented errors)
    # CS4034 'await` in a lambda that's not `async`
        # Test: Action f2 = () => await Task.Factory.StartNew(() => { });
    # CS8030: Anonymous function converted to a void returning delegate cannot return a value
        # Test: Action q11 = ()=>{ return 1; }
    # CS8031: Async lambda expression converted to a '{0}' returning delegate cannot return a value 
        # Test: Func<Task> F2 = async () => { await Task.Factory.StartNew(() => { }); return 1; };
    # CS8916: Attributes on lambda expressions require a parenthesized parameter list.
        # Test: Func<object, object> f = [A][B] x => x;
    # CS8971: InterpolatedStringHandlerArgument has no effect when applied to lambda parameters and will be ignored at the call site.
        # Test: ??
    # cS8972: A lambda expression with attributes cannot be converted to an expression tree
        # Test: Expression<Func<int, int>> e = [A] (x) => x;
    # CS8975: The contextual keyword 'var' cannot be used as an explicit lambda return type
        # Test: d = var () => throw null
    # CS1989: Async lambda expressions cannot be converted to expression trees
        # Test: Expression<Func<dynamic, Task<dynamic>>> e1 = async x => await d
    # CS2037: An expression tree lambda may not contain a COM call with ref omitted on arguments
        # Test: Expression<Func<int, int, int>> F = (x, y) => ref1.M(x, y) ref1 is a COM interface
    # CS8072: An expression tree lambda may not contain a null propagating operator.
        # Test: ??
    # CS8074: An expression tree lambda may not contain a dictionary initializer.
        # Test: ??
    # CS8075: An extension Add method is not supported for a collection initializer in an expression lambda.
        # Test: ??
    # CS9108: Cannot use parameter '{0}' that has ref-like type inside an anonymous method, lambda expression, query expression, or local function
        # Test: ?
helpviewer_keywords:
  - "CS0748"
  - "CS0834"
  - "CS0835"
  - "CS1621"
  - "CS1628"
  - "CS1632"
  - "CS1673"
  - "CS1686"
  - "CS1706"
  - "CS1951"
  - "CS1952"
  - "CS8153"
  - "CS8155"
  - "CS8175"
  - "CS9098"
  - "CS9099"
  - "CS9100"
ms.date: 05/04/2023
---
# Errors and warnings when declaring and using lambda expressions and anonymous functions

There are several errors related to declaring and using lambda expressions:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's be design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->
- [**CS0748**](#lambda-expression-parameter-declarations) - *Inconsistent lambda parameter usage; parameter types must be all explicit or all implicit.*
- [**CS0834**](#conversion-to-expression-trees) - *A lambda expression must have an expression body to be converted to an expression tree.*
- [**CS9098**](#lambda-expression-parameter-declarations) - *Implicitly type lambda parameter '...' cannot have a default value.*

In addition, there are several warnings related to declaring and using lambda expressions:

- [**CS9099**](#lambda-expression-delegate-type) - *The default parameter value does not match in the target delegate type.*
- [**CS9100**](#lambda-expression-delegate-type) - *Parameter has params modifier in lambda but not in target delegate type.*

## Syntax limitations in lambda expressions

### CS1621

The yield statement cannot be used inside an anonymous method or lambda expression

You cannot use the [yield](../statements/yield.md) statement in an [anonymous method](../operators/delegate-operator.md) or a [lambda expression](../operators/lambda-expressions.md).

The following sample generates CS1621:

```csharp
// CS1621.cs

using System.Collections;

delegate object MyDelegate();

class C : IEnumerable
{
    public IEnumerator GetEnumerator()
    {
        MyDelegate d = delegate
        {
            yield return this; // CS1621
            return this;
        };
        d();
        // Try this instead:
        // MyDelegate d = delegate { return this; };
        // yield return d();
    }

    public static void Main()
    {
    }
}
```

### CS1628

Cannot use in ref or out parameter 'parameter' inside an anonymous method, lambda expression, or query expression

This error occurs if you use an `in`, `ref`, or `out` parameter inside an anonymous method block. To avoid this error, use a local variable or some other construct.

The following sample generates CS1628:

```csharp
// CS1628.cs

delegate int MyDelegate();

class C
{
  public static void F(ref int i)
  {
      MyDelegate d = delegate { return i; };  // CS1628
      // Try this instead:
      // int tmp = i;
      // MyDelegate d = delegate { return tmp; };
  }

  public static void Main()
  {

  }
}
```

### CS1632

Control cannot leave the body of an anonymous method or lambda expression

This error occurs if a jump statement (**break**, `goto`, **continue**, etc.) attempts to move control out of an anonymous method block. An anonymous method block is a function body and can only be exited by a return statement or by reaching the end of the block.

The following sample generates CS1632:

```csharp
// CS1632.cs
// compile with: /target:library
delegate void MyDelegate();
class MyClass
{
   public void Test()
   {
      for (int i = 0 ; i < 5 ; i++)
      {
         MyDelegate d = delegate {
            break;   // CS1632
          };
      }
   }
}
```

### CS1673

Anonymous methods, lambda expressions, and query expressions inside structs cannot access instance members of 'this'. Consider copying 'this' to a local variable outside the anonymous method, lambda expression or query expression and using the local instead.

The following sample generates CS1673:

```csharp
// CS1673.cs
delegate int MyDelegate();

public struct S
{
   int member;

   public int F(int i)
   {
       member = i;
       // Try assigning to a local variable
       // S s = this;
       MyDelegate d = delegate()
       {
          i = this.member;  // CS1673
          // And use the local variable instead of "this"
          // i =  s.member;
          return i;

       };
       return d();
   }
}

class CMain
{
   public static void Main()
   {
   }
}
```

### CS1686

Local 'variable' or its members cannot have their address taken and be used inside an anonymous method or lambda expression

This error is generated when you use a variable, and attempt to take its address, and one of these actions is done inside an anonymous method.

The following sample generates CS1686.

```csharp
// CS1686.cs
// compile with: /unsafe /target:library
class MyClass
{
   public unsafe delegate int * MyDelegate();

   public unsafe int * Test()
   {
      int j = 0;
      MyDelegate d = delegate { return &j; };   // CS1686
      return &j;   // OK
   }
}
```

### CS1951

An expression tree lambda may not contain an in, out, or ref parameter.

An expression tree just represents expressions as data structures. There is no way to represent specific memory locations as is required when you pass a parameter by reference.

The only option is to remove the modifier in the delegate definition and pass the parameter by value.

The following example generates CS1951:

```csharp
// cs1951.cs
using System.Linq;
public delegate int TestDelegate(ref int i);
class Test
{
    static void Main()
    {
        System.Linq.Expressions.Expression<TestDelegate> tree1 = (ref int x) => x; // CS1951
    }
}
```

### CS1952

An expression tree lambda may not contain a method with variable arguments

The unsupported `__arglist` keyword is not allowed in lambda expressions that compile to expression trees.

Forget that you ever heard of `__arglist`.

The following code produces CS1952:

```csharp
// cs1952.cs
using System;
using System.Linq.Expressions;

class Test
{
    public static int M(__arglist)
    {
        return 1;
    }

    static int Main()
    {
        Expression<Func<int, int>> f = x => Test.M(__arglist(x)); // CS1952
        return 1;
    }
}
```

### CS8175

Cannot use ref local inside an anonymous method, lambda expression, or query expression

Remember that expression capturing is a compile-time operation and by-reference refers to a run-time location.

The following sample generates CS8175:

```csharp
// CS8175.cs (10,21)

using System;
class C
{
    void M()
    {
        ref readonly int x = ref (new int[1])[0];
        Action a = () =>
        {
            int i = x;
        };
    }
}
```

Removing the use of by-reference variables corrects this error.  In the example code, this can be done by first assigning the value of the referenced variable to a by-value variable:

```csharp

using System;
class C
{
    void M()
    {
        ref readonly int x = ref (new int[1])[0];
        int vx = x;
        Action a = () =>
        {
            int i = vx;
        };
    }
}
```

## Lambda expression parameter declarations

These errors indicate a problem with a parameter declaration:

- **CS9098** - *Implicitly type lambda parameter '...' cannot have a default value.*

Starting with C# 12, lambda expressions can include default values on parameters. However, those parameter declarations must have a type:

```csharp
var l = (x = 7) => x; // Error: CS9098
```

To fix this, either remove the default value, or declare an explicit type for the parameter:

```csharp
var l = (int x = 7) => x;
Func<int, int> l2 = x => x;
```

### CS0748

Inconsistent lambda parameter usage; parameter types must be all explicit or all implicit.

If a lambda expression has multiple input parameters, some parameters cannot use implicit typing while others use explicit typing.

To correct this error, either omit all parameter type declarations or explicitly specify the type of all parameters.

The following code generates CS0748, because, in the lambda expression, only `alpha` is given an explicit type:

```csharp
class CS0748
{
    System.Func<int, int, int> d = (int alpha, beta) => beta / alpha;
}
```

## Lambda expression delegate type

- [**CS9099**](#lambda-expression-delegate-type) - Warning: *The default parameter value does not match in the target delegate type.*

When you declare a default value or add the `params` modifier with a lambda expression parameter, the delegate type isn't one of the `Func` or `Action` types. Rather, it's a custom type that includes the default parameter value or `params` modifier. The following code generates warnings because you've assigned a lambda expression that has a default parameter to an `Action` type:

```csharp
Action<int> a1 = (int i = 2) => { };
Action<string[]> a3 = (params string[] s) => { };
```

To fix the error, either remove the default parameter or use an implicitly typed variable for the delegate type:

```csharp
Action<int> a1 = (int i) => { };
var a2 = (int i = 2) => { };
Action<string[]> a3 = (string[] s) => { };
var a4 = (params string[] s) => { };
```

## Conversion to expression trees

### CS0834

A lambda expression must have an expression body to be converted to an expression tree.

Lambdas that are translated to expression trees must be expression lambdas; statement lambdas and anonymous methods can only be converted to delegate types.

Remove the statement from the lambda expression.

The following example generates CS0834:

```csharp
// cs0834.cs
using System;
using System.Linq;
using System.Linq.Expressions;

public class C
{
    public static int Main()
    {
        Expression<Func<int, int>> e = x => { return x; }; // CS0834
    }
}
```

### CS0835

Cannot convert lambda to an expression tree whose type argument 'type' is not a delegate type.
If a lambda expression is converted to an expression tree, the expression tree must have a delegate type for its argument. Furthermore, the lambda expression must be convertible to the delegate type.

### CS0835

Cannot convert lambda to an expression tree whose type argument 'type' is not a delegate type.

If a lambda expression is converted to an expression tree, the expression tree must have a delegate type for its argument. Furthermore, the lambda expression must be convertible to the delegate type.

1. Change the type parameter from `int` to a delegate type, for example `Func<int,int>`.

The following example generates CS0835:

```csharp
// cs0835.cs
using System;
using System.Linq;
using System.Linq.Expressions;

public class C
{
    public static int Main()
    {
        Expression<int> e = x => x + 1; // CS0835

        // Try the following line instead.
       // Expression<Func<int,int>> e2 = x => x + 1;

        return 1;
    }
}
```

To correct this error, change the type parameter from `int` to a delegate type, for example `Func<int,int>`.

```csharp
// cs0835.cs
using System;
using System.Linq;
using System.Linq.Expressions;

public class C
{
    public static int Main()
    {
        Expression<int> e = x => x + 1; // CS0835

        // Try the following line instead.
       // Expression<Func<int,int>> e2 = x => x + 1;

        return 1;
    }
}
```

### CS8153

An expression tree lambda may not contain a call to a method, property, or indexer that returns by reference

The following sample generates CS8153:

```csharp
// CS8153.cs (11,46)

using System;
using System.Linq.Expressions;

namespace RefPropCrash
{
    class Program
    {
        static void Main(string[] args)
        {
            TestExpression(() => new Model { Value = 1 });
        }

        static void TestExpression(Expression<Func<Model>> expression)
        {
        }
    }

    class Model
    {
        int value;
        public ref int Value => ref value;
    }
}
```

To use a method within an expression, ensure it is not by reference.  For example:

```csharp
    class Model
    {
        public int Value { get; set; }
    }
```

### CS8155

Lambda expressions that return by reference cannot be converted to expression trees

The following sample generates CS8155:

```csharp
// CS8155.cs (11,51)

using System.Linq.Expressions;
class TestClass
{
    int x = 0;

    delegate ref int RefReturnIntDelegate(int y);

    void TestFunction()
    {
        Expression<RefReturnIntDelegate> lambda = (y) => ref x;
    }
}
```

To be convertible to an expression tree, refactoring to return by value corrects this error:

```csharp
class TestClass
{
    int x = 0;

    delegate int RefReturnIntDelegate(int y);

    void TestFunction()
    {
        Expression<RefReturnIntDelegate> lambda = (y) => x;
    }
}
```

## Not sure yet

### CS1706

Expression cannot contain anonymous methods  or lambda expressions

You cannot insert an anonymous method inside an expression.

1. Use a regular `delegate` in the expression.

The following example generates CS1706.

```csharp
// CS1706.cs
using System;

delegate void MyDelegate();
class MyAttribute : Attribute
{
    public MyAttribute(MyDelegate d) { }
}

// Anonymous Method in Attribute declaration is not allowed.
[MyAttribute(delegate{/* anonymous Method in Attribute declaration */})]  // CS1706
class Program
{
}
```
