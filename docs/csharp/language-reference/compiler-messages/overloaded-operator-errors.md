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

The following sections provide examples of common issues and how to fix them.

## Inconsistent accessibility

- **CS0056**: *Inconsistent accessibility: return type 'type' is less accessible than operator 'operator'*
- **CS0057**: *Inconsistent accessibility: parameter type 'type' is less accessible than operator 'operator'*

These errors occur when you declare a public operator with return types or parameter types that have more restrictive accessibility than the operator itself. All public constructs must use publicly accessible types for their parameters and return values. For more information, see [Access Modifiers](../programming-guide/classes-and-structs/access-modifiers.md).

**CS0056 example - Return type less accessible:**

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

**CS0057 example - Parameter type less accessible:**

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

To fix these errors, make sure all types used in public operator declarations are also publicly accessible.

## Operator signature requirements

- **CS0448**: *The return type for ++ or -- operator must be the containing type or derived from the containing type*
- **CS0559**: *The parameter type for ++ or -- operator must be the containing type*
- **CS0562**: *The parameter of a unary operator must be the containing type*
- **CS0563**: *One of the parameters of a binary operator must be the containing type*
- **CS0564**: *The first operand of an overloaded shift operator must have the same type as the containing type, and the type of the second operand must be int*
- **CS0567**: *Interfaces can't contain operators*
- **CS0590**: *User-defined operators can't return void*
- **CS9310**: *The return type for this operator must be void*

These errors occur when operator declarations don't follow the required signature rules. Each operator type has specific requirements for parameter types and return types. For more information, see [Operator overloading](../operators/operator-overloading.md).

**CS0448 example - Return type for ++ or -- must be containing type:**

```csharp
// CS0448.cs
class C5
{
   public static int operator ++(C5 c) { return null; }   // CS0448
   public static C5 operator --(C5 c) { return null; }   // OK
   public static void Main() {}
}
```

**CS0559 example - Parameter type for ++ or -- must be containing type:**

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

**CS0562 example - Unary operator parameter must be containing type:**

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

**CS0563 example - Binary operator must have one parameter of containing type:**

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

**CS0564 example - Shift operator requirements:**

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

**CS0567 example - Interfaces can't contain operators:**

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

**CS0590 example - Operators can't return void:**

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

To fix these errors, ensure your operator declarations follow the signature requirements for the specific operator type you're overloading.

## Boolean and short-circuit operators

- **CS0215**: *The return type of operator true or false must be bool*
- **CS0216**: *The operator requires a matching operator to also be defined*
- **CS0217**: *In order to be applicable as a short-circuit operator, a user-defined logical operator must have the same return type as the type of its 2 parameters*
- **CS0218**: *The type must contain declarations of operator true and operator false*

These errors occur when you define logical operators incorrectly. Certain operators must be defined in pairs, and short-circuit operators have specific signature requirements. For more information, see [true and false operators](../operators/true-false-operators.md), [Boolean logical operators](../operators/boolean-logical-operators.md), and [User-defined conditional logical operators](~/_csharpstandard/standard/expressions.md#12153-user-defined-conditional-logical-operators).

**CS0215 example - operator true and false must return bool:**

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

**CS0216 example - Operator requires matching operator:**

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

   public override bool Equals (object o)
   {
      return base.Equals (o);
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

**CS0217 example - Short-circuit operator requires matching return type:**

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

**CS0218 example - Must define operator true and false for short-circuit support:**

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

To fix these errors, ensure you define required paired operators and follow the correct signature patterns for logical operators.

## User-defined conversion restrictions

- **CS0552**: *User-defined conversion to/from interface*
- **CS0553**: *User-defined conversion to/from base class*
- **CS0554**: *User-defined conversion to/from derived class*
- **CS0555**: *User-defined operator can't take an object of the enclosing type and convert to an object of the enclosing type*
- **CS0556**: *User-defined conversion must convert to or from the enclosing type*
- **CS0557**: *Duplicate user-defined conversion in type*

These errors occur when you attempt to create invalid user-defined conversion operators. Conversion operators have specific restrictions about which types they can convert between. For more information, see [User-defined conversion operators](../operators/user-defined-conversion-operators.md).

**CS0552 example - Can't convert to/from interface:**

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

**CS0553 example - Can't convert to/from base class:**

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

**CS0554 example - Can't convert to/from derived class:**

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

**CS0555 example - Can't convert from type to same type:**

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

**CS0556 example - Must convert to/from enclosing type:**

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

**CS0557 example - Duplicate conversion:**

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

To fix these errors, remove invalid conversion operators or restructure your type hierarchy to avoid the restricted conversion patterns.

## Checked operators

- **CS9023**: *Operator can't be made checked*
- **CS9024**: *Operator can't be made unchecked*
- **CS9025**: *Checked operator requires a matching non-checked version to also be declared*

These errors occur when you incorrectly use the `checked` or `unchecked` keywords with operator declarations. Not all operators support checked/unchecked variants, and when they do, certain requirements must be met. For more information, see [Arithmetic operators](../operators/arithmetic-operators.md#user-defined-checked-operators) and [User-defined checked operators](~/_csharpstandard/standard/expressions.md#1249-user-defined-checked-operators).

To fix these errors, either remove the `checked` or `unchecked` keyword from operators that don't support it, or ensure you provide both checked and non-checked versions when required.

## Operator declaration requirements

- **CS0558**: *User-defined operator must be declared static and public*
- **CS0715**: *Static classes can't contain user-defined operators*
- **CS1037**: *Overloadable operator expected*
- **CS1553**: *Declaration isn't valid; use 'modifier operator <dest-type> (...' instead*
- **CS8930**: *Explicit implementation of a user-defined operator must be static*
- **CS8931**: *Explicit implementation must be declared public to implement interface member in type*
- **CS9308**: *User-defined operator must be declared public*

These errors occur when operator declarations don't use the required modifiers or syntax. User-defined operators must be both `static` and `public`, and conversion operators require specific syntax. For more information, see [Operator overloading](../operators/operator-overloading.md) and [User-defined conversion operators](../operators/user-defined-conversion-operators.md).

**CS0558 example - Operator must be static and public:**

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

**CS0715 example - Static classes can't have operators:**

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

**CS1553 example - Conversion operator syntax:**

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

To fix these errors, ensure your operator declarations include the required `static` and `public` modifiers, follow the correct syntax for conversion operators, and don't declare operators in static classes.

## Equality operators

- **CS0660**: *Type defines operator == or operator != but doesn't override Object.Equals(object o)*
- **CS0661**: *Type defines operator == or operator != but doesn't override Object.GetHashCode()*

These warnings occur when you define equality or inequality operators without also overriding the corresponding methods from <xref:System.Object>. When you define custom equality comparison, you should also override <xref:System.Object.Equals%2A?displayProperty=nameWithType> and <xref:System.Object.GetHashCode%2A?displayProperty=nameWithType> to ensure consistent behavior. For more information, see [How to define value equality for a type](../../fundamentals/coding-style/how-to-define-value-equality-for-a-type.md) and [Equality operators](../operators/equality-operators.md).

**CS0660 example - Missing Equals override:**

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

**CS0661 example - Missing GetHashCode override:**

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

To fix these warnings, override both `Equals` and `GetHashCode` when you define custom equality operators.

## Interface and inheritance requirements

- **CS9311**: *Type doesn't implement interface member. The type can't implement member because one of them isn't an operator*
- **CS9312**: *Type can't override inherited member because one of them isn't an operator*
- **CS9313**: *Overloaded compound assignment operator takes one parameter*

These errors occur when there are mismatches between operator declarations and interface implementations or inheritance relationships. Operators have specific rules for interface implementation and overriding. For more information, see [Operator overloading](../operators/operator-overloading.md) and [Interfaces](../fundamentals/types/interfaces.md).

To fix these errors, ensure that operator declarations correctly match interface requirements and follow the rules for operator overriding and compound assignment operators.


