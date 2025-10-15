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
  - "CS1554"
  - "CS9308"
  - "CS9310"
  - "CS9311"
  - "CS9312"
  - "CS9313"
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
  - "CS1554"
  - "CS9308"
  - "CS9310"
  - "CS9311"
  - "CS9312"
  - "CS9313"
ms.date: 10/15/2025
ai-usage: ai-assisted
---
# Errors and warnings for overloaded, or user-defined operator declarations

There are several errors related to declaring overloaded operators. Overloaded operators are also referred to as user-defined operators

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->
- [**CS0056**](#cs0056): *Inconsistent accessibility: return type 'type' is less accessible than operator 'operator'*
- [**CS0057**](#cs0057): *Inconsistent accessibility: parameter type 'type' is less accessible than operator 'operator'*
- [**CS0215**](#cs0215): *The return type of operator True or False must be bool*
- [**CS0216**](#cs0216): *The operator 'operator' requires a matching operator 'missing_operator' to also be defined*
- [**CS0217**](#cs0217): *In order to be applicable as a short circuit operator a user-defined logical operator ('operator') must have the same return type as the type of its 2 parameters.*
- [**CS0218**](#cs0218): *The type ('type') must contain declarations of operator true and operator false*
- [**CS0448**](#cs0448): *The return type for ++ or -- operator must be the containing type or derived from the containing type*
- [**CS0552**](#cs0552): *'conversion routine' : user defined conversion to/from interface*
- [**CS0553**](#cs0553): *'conversion routine' : user defined conversion to/from base class*
- [**CS0554**](#cs0554): *'conversion routine' : user defined conversion to/from derived class*
- [**CS0555**](#cs0555): *User-defined operator cannot take an object of the enclosing type and convert to an object of the enclosing type*
- [**CS0556**](#cs0556): *User-defined conversion must convert to or from the enclosing type*
- [**CS0557**](#cs0557): *Duplicate user-defined conversion in type*
- [**CS0558**](#cs0558): *User-defined operator must be declared static and public*
- [**CS0559**](#cs0559): *The parameter type for ++ or -- operator must be the containing type*
- [**CS0562**](#cs0562): *The parameter of a unary operator must be the containing type*
- [**CS0563**](#cs0563): *One of the parameters of a binary operator must be the containing type*
- [**CS0564**](#cs0564): *The first operand of an overloaded shift operator must have the same type as the containing type, and the type of the second operand must be int*
- [**CS0567**](#cs0567): *Interfaces cannot contain operators*
- [**CS0590**](#cs0590): *User-defined operators cannot return void*
- [**CS0660**](#cs0660): *Type defines operator == or operator != but does not override Object.Equals(object o)*
- [**CS0661**](#cs0661): *Type defines operator == or operator != but does not override Object.GetHashCode()*
- [**CS0715**](#cs0715): *Static classes cannot contain user-defined operators*
- [**CS1037**](#cs1037): *Overloadable operator expected*
- [**CS1553**](#cs1553): *Declaration is not valid; use 'modifier operator \<dest-type> (...' instead*
- [**CS1554**](#cs1554): *Declaration is not valid; use '\<type> operator op (...' instead*
- **CS9308**: *User-defined operator must be declared public.*
- **CS9310**: *The return type for this operator must be void.*
- **CS9311**: *Type does not implement interface member. The type cannot implement member because one of them is not an operator.*
- **CS9312**: *Type cannot override inherited member because one of them is not an operator.*
- **CS9313**: *Overloaded compound assignment operator takes one parameter.*

The following sections provide examples of common issues and how to fix them.

## CS0056

Inconsistent accessibility: return type 'type' is less accessible than operator 'operator'

A public construct must return a publicly accessible object. For more information, see [Access Modifiers](../programming-guide/classes-and-structs/access-modifiers.md).

The following sample generates CS0056:

```csharp
// CS0056.cs
class MyClass
// try the following line instead
// public class MyClass
{
}

public class A
{
   public static implicit operator MyClass(A a)   // CS0056
   {
      return new MyClass();
   }

   public static void Main()
   {
   }
}
```

## CS0057

Inconsistent accessibility: parameter type 'type' is less accessible than operator 'operator'

A public construct must return a publicly accessible object. For more information, see [Access Modifiers](../programming-guide/classes-and-structs/access-modifiers.md).

The following sample generates CS0057:

```csharp
// CS0057.cs
class MyClass //defaults to private accessibility
// try the following line instead
// public class MyClass
{
}

public class MyClass2
{
   public static implicit operator MyClass2(MyClass iii)   // CS0057
   {
      return new MyClass2();
   }

   public static void Main()
   {
   }
}
```

## CS0215

The return type of operator True or False must be bool

User-defined [true and false](../language-reference/operators/true-false-operators.md) operators must have a return type of [bool](../language-reference/builtin-types/bool.md).

The following sample generates CS0215:

```csharp
// CS0215.cs
class MyClass
{
   public static int operator true (MyClass MyInt)   // CS0215
   // try the following line instead
   // public static bool operator true (MyClass MyInt)
   {
      return true;
   }

   public static int operator false (MyClass MyInt)   // CS0215
   // try the following line instead
   // public static bool operator false (MyClass MyInt)
   {
      return true;
   }

   public static void Main()
   {
   }
}
```

## CS0216

The operator 'operator' requires a matching operator 'missing_operator' to also be defined

A user-defined [==](../language-reference/operators/equality-operators.md#equality-operator-) operator requires a user-defined [!=](../language-reference/operators/equality-operators.md#inequality-operator-) operator, and vice versa.
The same applies also to a user-defined [true](../language-reference/operators/true-false-operators.md) operator and a user-defined [false](../language-reference/operators/true-false-operators.md) operator.

The following sample generates CS0216:

```csharp
// CS0216.cs
class MyClass
{
   public static bool operator == (MyClass MyIntLeft, MyClass MyIntRight)   // CS0216
   {
      return MyIntLeft == MyIntRight;
   }

   // to resolve, uncomment the following operator definition
   /*
   public static bool operator != (MyClass MyIntLeft, MyClass MyIntRight)
   {
      return MyIntLeft != MyIntRight;
   }
   */

   public override bool Equals (object obj)
   {
      return base.Equals (obj);
   }

   public override int GetHashCode()
   {
      return base.GetHashCode();
   }

   public static void Main()
   {
   }
}
```

## CS0217

In order to be applicable as a short circuit operator a user-defined logical operator ('operator') must have the same return type as the type of its 2 parameters.

If you define an operator for a user-defined type, and then try to use the operator as a short-circuit operator, the user-defined operator must have parameters and return values of the same type. For more information about short-circuit operators, see [`&&` operator](../language-reference/operators/boolean-logical-operators.md#conditional-logical-and-operator-) and [`||` operator](../language-reference/operators/boolean-logical-operators.md#conditional-logical-or-operator-). For more information about user-defined short-circuit, or conditional, operators, see the [User-defined conditional logical operators](~/_csharpstandard/standard/expressions.md#12153-user-defined-conditional-logical-operators ) section of the [C# language specification](~/_csharpstandard/standard/README.md).

The following sample generates CS0217:

```csharp
// CS0217.cs
using System;

public class MyClass
{
   public static bool operator true (MyClass f)
   {
      return false;
   }

   public static bool operator false (MyClass f)
   {
      return false;
   }

   public static implicit operator int(MyClass x)
   {
      return 0;
   }

   public static int operator & (MyClass f1, MyClass f2)   // CS0217
   // try the following line instead
   // public static MyClass operator & (MyClass f1, MyClass f2)
   {
      return new MyClass();
   }

   public static void Main()
   {
      MyClass f = new MyClass();
      int i = f && f;
   }
}
```

### See also

- [Operator overloading](../language-reference/operators/operator-overloading.md)
- [true and false operators](../language-reference/operators/true-false-operators.md)

## CS0218

The type ('type') must contain declarations of operator true and operator false

If a user-defined type overloads the [& operator](../language-reference/operators/boolean-logical-operators.md#logical-and-operator-) or [&#124; operator](../language-reference/operators/boolean-logical-operators.md#logical-or-operator-), it must also define [true and false](../language-reference/operators/true-false-operators.md) operators, in order to make short-circuiting [&& operator](../language-reference/operators/boolean-logical-operators.md#conditional-logical-and-operator-) or [&#124;&#124; operator](../language-reference/operators/boolean-logical-operators.md#conditional-logical-or-operator-) defined.

The following sample generates CS0218:

```csharp
// CS0218.cs
using System;
public class MyClass
{
   // uncomment these operator declarations to resolve this CS0218
   /*
   public static bool operator true (MyClass f)
   {
      return false;
   }

   public static bool operator false (MyClass f)
   {
      return false;
   }
   */

   public static implicit operator int(MyClass x)
   {
      return 0;
   }

   public static MyClass operator & (MyClass f1, MyClass f2)
   {
      return new MyClass();
   }

   public static void Main()
   {
      MyClass f = new MyClass();
      int i = f && f;   // CS0218, requires operators true and false
   }
}
```

### See also

- [Operator overloading](../language-reference/operators/operator-overloading.md)

## CS0448

The return type for ++ or -- operator must be the containing type or derived from the containing type

When you override the `++` or `--` operators, they must return the same type as the containing type, or return a type that is derived from the containing type.

### Example 1

The following sample generates CS0448.

```csharp
// CS0448.cs
class C5
{
   public static int operator ++(C5 c) { return null; }   // CS0448
   public static C5 operator --(C5 c) { return null; }   // OK
   public static void Main() {}
}
```

### Example 2

The following sample generates CS0448.

```csharp
// CS0448_b.cs
public struct S
{
   public static S? operator ++(S s) { return new S(); }   // CS0448
   public static S? operator --(S s) { return new S(); }   // CS0448
}

public struct T
{
// OK
   public static T operator --(T t) { return new T(); }
   public static T operator ++(T t) { return new T(); }

   public static T? operator --(T? t) { return new T(); }
   public static T? operator ++(T? t) { return new T(); }

   public static void Main() {}
}
```

## CS0552

You can't create a user-defined conversion to or from an interface. If you need the conversion routine, resolve this error by making the interface a class or derive a class from the interface.

The following sample generates CS0552:

```csharp
// CS0552.cs
public interface ii
{
}

public class a
{
   // delete the routine to resolve CS0552
   public static implicit operator ii(a aa) // CS0552
   {
      return new ii();
   }

   public static void Main()
   {
   }
}
```

## CS0553

'conversion routine' : user defined conversion to/from base class

User-defined conversions to values of a base class are not allowed; you don't need such an operator.

The following sample generates CS0553:

```csharp
// CS0553.cs
namespace x
{
   public class ii
   {
   }

   public class a : ii
   {
      // delete the conversion routine to resolve CS0553
      public static implicit operator ii(a aa) // CS0553
      {
         return new ii();
      }

      public static void Main()
      {
      }
   }
}
```

## CS0554

'conversion routine' : user defined conversion to/from derived class

User-defined conversions to values of a derived class are not allowed; you don't need such an operator.

See chapter 6 in the C# language specification for more information on user-defined conversions.

The following sample generates CS0554:

```csharp
// CS0554.cs
namespace x
{
   public class ii
   {
      // delete the conversion routine to resolve CS0554
      public static implicit operator ii(a aa) // CS0554
      {
         return new ii();
      }
   }

   public class a : ii
   {
      public static void Main()
      {
      }
   }
}
```

## CS0555

User-defined operator cannot take an object of the enclosing type and convert to an object of the enclosing type

User-defined conversions to values of the enclosing class are not allowed; you don't need such an operator.

The following sample generates CS0555:

```csharp
// CS0555.cs
public class MyClass
{
   // delete the following operator to resolve this CS0555
   public static implicit operator MyClass(MyClass aa)   // CS0555
   {
      return new MyClass();
   }

   public static void Main()
   {
   }
}
```

## CS0556

User-defined conversion must convert to or from the enclosing type

A user-defined conversion routine must convert to or from the class that contains the routine.

The following sample generates CS0556:

```csharp
// CS0556.cs
namespace x
{
   public class ii
   {
      public class iii
      {
         public static implicit operator int(byte aa)   // CS0556
         // try the following line instead
         // public static implicit operator int(iii aa)
         {
            return 0;
         }
      }

      public static void Main()
      {
      }
   }
}
```

## CS0557

Duplicate user-defined conversion in type

Duplicate conversion routines are not allowed in a class.

The following example generates CS0557:

```csharp
// CS0557.cs
namespace x
{
    public class ii
    {
        public class iii
        {
        public static implicit operator int(iii aa)
        {
            return 0;
        }

    // CS0557, delete duplicate
        public static explicit operator int(iii aa)
        {
            return 0;
        }
        }

        public static void Main()
        {
        }
    }
}
```

## CS0558

User-defined operator must be declared static and public

Both the **static** and **public** access [modifiers](../keywords/index.md) must be specified on user-defined operators.

The following sample generates CS0558:

```csharp
// CS0558.cs
namespace x
{
   public class ii
   {
      public class iii
      {
         static implicit operator int(iii aa)   // CS0558, add public
         {
            return 0;
         }
      }

      public static void Main()
      {
      }
   }
}
```

## CS0559

The parameter type for ++ or -- operator must be the containing type

The method declaration for an operator overload must follow certain guidelines. For the ++ and -- operators, it is required that the parameter be of the same type as the type in which the operator is being overloaded.

### Example 1

The following sample generates CS0559:

```csharp
// CS0559.cs
// compile with: /target:library
public class iii
{
   public static implicit operator int(iii x)
   {
      return 0;
   }

   public static implicit operator iii(int x)
   {
      return null;
   }

   public static int operator ++(int aa)   // CS0559
   // try the following line instead
   // public static iii operator ++(iii aa)
   {
      return (iii)0;
   }
}
```

### Example 2

The following sample generates CS0559.

```csharp
// CS0559_b.cs
// compile with: /target:library
public struct S
{
   public static S operator ++(S? s) { return new S(); }   // CS0559
   public static S operator --(S? s) { return new S(); }   // CS0559
}

public struct T
{
// OK
   public static T operator --(T t) { return new T(); }
   public static T operator ++(T t) { return new T(); }

   public static T? operator --(T? t) { return new T(); }
   public static T? operator ++(T? t) { return new T(); }
}
```

## CS0562

The parameter of a unary operator must be the containing type

The method declaration for an operator overload must follow certain guidelines. For more information, see [Operator overloading](../operators/operator-overloading.md).

The following sample generates CS0562:

```csharp
// CS0562.cs
public class iii
{
    public static implicit operator int(iii x)
    {
        return 0;
    }

    public static implicit operator iii(int x)
    {
        return null;
    }

    public static iii operator +(int aa)   // CS0562
    // try the following line instead
    // public static iii operator +(iii aa)
    {
        return (iii)0;
    }

    public static void Main()
    {
    }
}
```

## CS0563

One of the parameters of a binary operator must be the containing type

The method declaration for an [operator overload](../operators/operator-overloading.md) must follow certain guidelines.

### Example

The following sample generates CS0563:

```csharp
// CS0563.cs
public class iii
{
    public static implicit operator int(iii x)
    {
        return 0;
    }
    public static implicit operator iii(int x)
    {
        return null;
    }
    public static int operator +(int aa, int bb)   // CS0563
    // Use the following line instead:
    // public static int operator +(int aa, iii bb)
    {
        return 0;
    }
    public static void Main()
    {
    }
}
```

## CS0564

The first operand of an overloaded shift operator must have the same type as the containing type, and the type of the second operand must be int

You attempted to overload a shift operator (<< or >>) with incorrectly typed operands. The first operand must be the type and the second operand must be of the type `int`.

The following sample generates CS0564:

```csharp
// CS0564.cs
using System;
class C
{
   public static int operator << (C c1, C c2) // CS0564
// To correct, change second operand to int, like so:
// public static int operator << (C c1, int c2)
   {
      return 0;
   }
   static void Main()
   {
   }
}
```

## CS0567

Interfaces cannot contain operators

Operators are not permitted in [interface](../keywords/interface.md) definitions.

The following sample generates CS0567:

```csharp
// CS0567.cs
interface IA
{
   int operator +(int aa, int bb);   // CS0567
}

class Sample
{
   public static void Main()
   {
   }
}
```

## CS0590

User-defined operators cannot return void

The purpose of a user-defined operator is to return an object.

The following sample generates CS0590:

```csharp
// CS0590.cs
namespace x
{
   public class a
   {
      public static void operator+(a A1, a A2)   // CS0590
      {
      }

      // try the following user-defined operator
      /*
      public static a operator+(a A1, a A2)
      {
         return A2;
      }
      */

      public static int Main()
      {
         return 1;
      }
   }
}
```

## CS0660

Type defines operator == or operator != but does not override Object.Equals(object o)

The compiler detected the user-defined equality or inequality operator, but no override for the <xref:System.Object.Equals%2A?displayProperty=nameWithType> method. A user-defined equality or inequality operator implies that you also want to override the <xref:System.Object.Equals%2A> method. For more information, see [How to define value equality for a type](../../fundamentals/coding-style/how-to-define-value-equality-for-a-type.md).

The following sample generates CS0660:

```csharp
// CS0660.cs
// compile with: /W:3 /warnaserror
class Test   // CS0660
{
   public static bool operator == (object o, Test t)
   {
      return true;
   }

   // uncomment the Equals function to resolve
   // public override bool Equals(object o)
   // {
   //    return true;
   // }

   public override int GetHashCode()
   {
      return 0;
   }

   public static void Main()
   {
   }
}
```

## CS0661

Type defines operator == or operator != but does not override Object.GetHashCode()

The compiler detected the user-defined equality or inequality operator, but no override for the **GetHashCode** function. A user-defined equality or inequality operator implies that you also want to override the **GetHashCode** function.

The following sample generates CS0661:

```csharp
// CS0661.cs
// compile with: /W:3
class Test   // CS0661
{
   public static bool operator == (object o, Test t)
   {
      return true;
   }

   public static bool operator != (object o, Test t)
   {
      return true;
   }

   public override bool Equals(object o)
   {
      return true;
   }

   // uncomment the GetHashCode function to resolve
   // public override int GetHashCode()
   // {
   //    return 0;
   // }

   public static void Main()
   {
   }
}
```

## CS0715

Static classes cannot contain user-defined operators

User defined operators operate on instances of classes. Static classes cannot be instantiated, so it is not possible to create instances for operators to act upon. Hence, user defined operators are not allowed for static classes.

The following sample generates CS0715:

```csharp
// CS0715.cs
public static class C
{
   public static C operator+(C c)  // CS0715
   {
   }

   public static void Main()
   {
   }
}
```

## CS1037

Overloadable operator expected

## CS1553

Declaration is not valid; use 'modifier operator \<dest-type> (...' instead

The return type for a [conversion operator](../operators/user-defined-conversion-operators.md) must immediately precede the parameter list, and *modifier* is either `implicit` or `explicit`.

The following sample generates CS1553:

```csharp
// CS1553.cs
class MyClass
{
   public static int implicit operator (MyClass f)   // CS1553
   // try the following line instead
   // public static implicit operator int (MyClass f)
   {
      return 6;
   }

   public static void Main()
   {
   }
}
```

## CS1554

Declaration is not valid; use '\<type> operator op (...' instead

The return type of an [overloaded operator](../operators/operator-overloading.md) must appear before the `operator` keyword.

The following sample generates CS1554:

```csharp
// CS1554.cs
class MyClass
{
   public static operator ++ MyClass (MyClass f)    // CS1554
   // try the following line instead
   // public static MyClass operator ++ (MyClass f)
   {
      return new MyClass ();
   }

   public static void Main()
   {
   }
}
```

