---
title: Resolve errors related to constructor declarations
description: These compiler errors and warnings indicate violations when declaring constructors in classes or structs, including records. This article provides guidance on resolving those errors.
f1_keywords:
 - "CS0514"
 - "CS0515"
 - "CS0516"
 - "CS0517"
 - "CS0522"
 - "CS0526"
 - "CS0568"
 - "CS710"
 - "CS0768"
 - "CS0824" # WRN_ExternCtorNoImplementation
 - "CS1729"
 - "CS8054" # ERR_EnumsCantContainDefaultConstructor
 - "CS8091" # ERR_ExternHasConstructorInitializer
 - "CS8358" # ERR_AttributeCtorInParameter
 - "CS8862" # ERR_UnexpectedOrMissingConstructorInitializerInRecord
 - "CS8867" # ERR_NoCopyConstructorInBaseType
 - "CS8868" # ERR_CopyConstructorMustInvokeBaseCopyConstructor 
 - "CS8878" # ERR_CopyConstructorWrongAccessibility
 - "CS8910" # ERR_RecordAmbigCtor
 - "CS8958" # ERR_NonPublicParameterlessStructConstructor
 - "CS8982" # ERR_RecordStructConstructorCallsDefaultConstructor
 - "CS8983" # ERR_StructHasInitializersAndNoDeclaredConstructor
 - "CS9105" # ERR_InvalidPrimaryConstructorParameterReference - Cannot use primary constructor parameter '{0}' in this context.
 - "CS9106" # ERR_AmbiguousPrimaryConstructorParameterAsColorColorReceiver - Identifier '{0}' is ambiguous between type '{1}' and parameter '{2}' in this context.
 - "CS9107" # WRN_CapturedPrimaryConstructorParameterPassedToBase - Parameter '{0}' is captured into the state of the enclosing type and its value is also passed to the base constructor. The value might be captured by the base class as well.
 - "CS9108" # ERR_AnonDelegateCantUseRefLike - Cannot use parameter '{0}' that has ref-like type inside an anonymous method, lambda expression, query expression, or local function
 - "CS9109" # ERR_UnsupportedPrimaryConstructorParameterCapturingRef - Cannot use ref, out, or in primary constructor parameter '{0}' inside an instance member
 - "CS9110" # ERR_UnsupportedPrimaryConstructorParameterCapturingRefLike - Cannot use primary constructor parameter '{0}' that has ref-like type inside an instance member
 - "CS9111" # ERR_AnonDelegateCantUseStructPrimaryConstructorParameterInMember - Anonymous methods, lambda expressions, query expressions, and local functions inside an instance member of a struct cannot access primary constructor parameter
 - "CS9112" # ERR_AnonDelegateCantUseStructPrimaryConstructorParameterCaptured - Anonymous methods, lambda expressions, query expressions, and local functions inside a struct cannot access primary constructor parameter also used inside an instance member
 - "CS9113" # WRN_UnreadPrimaryConstructorParameter - Parameter '{0}' is unread.
 - "CS9114" # ERR_AssgReadonlyPrimaryConstructorParameter - A primary constructor parameter of a readonly type cannot be assigned to (except in init-only setter of the type or a variable initializer)
 - "CS9115" # ERR_RefReturnReadonlyPrimaryConstructorParameter - A primary constructor parameter of a readonly type cannot be returned by writable reference
 - "CS9116" # ERR_RefReadonlyPrimaryConstructorParameter - A primary constructor parameter of a readonly type cannot be used as a ref or out value (except in init-only setter of the type or a variable initializer)
 - "CS9117" # ERR_AssgReadonlyPrimaryConstructorParameter2 - Members of primary constructor parameter '{0}' of a readonly type cannot be modified (except in init-only setter of the type or a variable initializer)
 - "CS9118" # ERR_RefReturnReadonlyPrimaryConstructorParameter2 - Members of primary constructor parameter '{0}' of a readonly type cannot be returned by writable reference
 - "CS9119" # ERR_RefReadonlyPrimaryConstructorParameter2 - Members of primary constructor parameter '{0}' of a readonly type cannot be used as a ref or out value (except in init-only setter of the type or a variable initializer)
 - "CS9120" # ERR_RefReturnPrimaryConstructorParameter - Cannot return primary constructor parameter '{0}' by reference.
 - "CS9121" # ERR_StructLayoutCyclePrimaryConstructorParameter - Struct primary constructor parameter '{0}' of type '{1}' causes a cycle in the struct layout
 - "CS9122" # ERR_UnexpectedParameterList - Unexpected parameter list. Test: Interfaces can't have primary constructors.
helpviewer_keywords:
 - "CS0514"
 - "CS0515"
 - "CS0516"
 - "CS0517"
 - "CS0522"
 - "CS0526"
 - "CS0568"
 - "CS0710"
 - "CS0768"
 - "CS0824"
 - "CS1729"
 - "CS8054"
 - "CS8091"
 - "CS8358"
 - "CS8862"
 - "CS8867"
 - "CS8868"
 - "CS8878"
 - "CS8910"
 - "CS8958"
 - "CS8982"
 - "CS8983"
 - "CS9105"
 - "CS9106"
 - "CS9107"
 - "CS9108"
 - "CS9109"
 - "CS9110"
 - "CS9111"
 - "CS9112"
 - "CS9113"
 - "CS9114"
 - "CS9115"
 - "CS9116"
 - "CS9117"
 - "CS9118"
 - "CS9119"
 - "CS9120"
 - "CS9121"
 - "CS9122"
ms.date: 05/08/2023
---
# Resolve errors and warnings in constructor declarations

This article covers the following compiler errors:

- [**CS0514**](#cs0514) - *'constructor' : static constructor cannot have an explicit 'this' or 'base' constructor call.*
- [**CS0515**](#cs0515) - *access modifiers are not allowed on static constructors.*
- [**CS0516**](#cs0516) - *Constructor 'constructor' can not call itself.*
- [**CS0517**](#cs0517) - *'class' has no base class and cannot call a base constructor.*
- [**CS0522**](#cs0522) - *'constructor' : structs cannot call base class constructors.*
- [**CS0526**](#cs0526) - *Interfaces cannot contain constructors.*
- **CS0568** - *Structs cannot contain explicit parameterless constructors.*
- [**CS0710**](#cs0710) - *Static classes cannot have instance constructors.*
- [**CS1729**](#cs1729) - *'type' does not contain a constructor that takes 'number' arguments.*
- [**CS9105**](#primary-constructor-syntax) - *Cannot use primary constructor parameter in this context.*
- [**CS9106**](#primary-constructor-syntax) - *Identifier is ambiguous between type and parameter in this context.*
class as well.*
- [**CS9108**](#primary-constructor-syntax) - *Cannot use parameter that has ref-like type inside an anonymous method, lambda expression, query expression, or local function.*
- [**CS9109**](#primary-constructor-syntax) - *Cannot use ref, out, or in primary constructor parameter inside an instance member.*
- [**CS9110**](#primary-constructor-syntax) - *Cannot use primary constructor parameter that has ref-like type inside an instance member.*
- [**CS9111**](#primary-constructor-syntax) - *Anonymous methods, lambda expressions, query expressions, and local functions inside an instance member of a struct cannot access primary constructor parameter.*
- [**CS9112**](#primary-constructor-syntax) - *Anonymous methods, lambda expressions, query expressions, and local functions inside a struct cannot access primary constructor parameter also used inside an instance member.*
- [**CS9114**](#primary-constructor-syntax) - *A primary constructor parameter of a readonly type cannot be assigned to (except in init-only setter of the type or a variable initializer).*
- [**CS9115**](#primary-constructor-syntax) - *A primary constructor parameter of a readonly type cannot be returned by writable reference.*
- [**CS9116**](#primary-constructor-syntax) - *A primary constructor parameter of a readonly type cannot be used as a ref or out value (except in init-only setter of the type or a variable initializer).*
- [**CS9117**](#primary-constructor-syntax) - *Members of primary constructor parameter of a readonly type cannot be modified (except in init-only setter of the type or a variable initializer).*
- [**CS9118**](#primary-constructor-syntax) - *Members of primary constructor parameter of a readonly type cannot be returned by writable reference.*
- [**CS9119**](#primary-constructor-syntax) - *Members of primary constructor parameter' of a readonly type cannot be used as a ref or out value (except in init-only setter of the type or a variable initializer).*
- [**CS9120**](#primary-constructor-syntax) - *Cannot return primary constructor parameter by reference.*
- [**CS9121**](#primary-constructor-syntax) - *Struct primary constructor parameter of type causes a cycle in the struct layout.*
- [**CS9122**](#primary-constructor-syntax) - *Unexpected parameter list.*

In addition, the following warnings are covered in this article:

- [**CS0824**](#cs0824) - *Constructor 'name' is marked external.*
- [**CS9107**](#primary-constructor-syntax) - *Parameter is captured into the state of the enclosing type and its value is also passed to the base constructor. The value might be captured by the base class as well.*
- [**CS9113**](#primary-constructor-syntax) - *Parameter is unread.*

## Errors to add

- **CS0768** - *Constructor '{0}' cannot call itself through another constructor.*
- **CS8054** - *Enums cannot contain explicit parameterless constructors.*
- **CS8091** - *'{0}' cannot be extern and have a constructor initializer.*
- **CS8358** - *Cannot use attribute constructor '{0}' because it has 'in' parameters.*
- **CS8862** - *A constructor declared in a type with parameter list must have 'this' constructor initializer.*
- **CS8867** - *No accessible copy constructor found in base type '{0}'.*
- **CS8868** - *A copy constructor in a record must call a copy constructor of the base, or a parameterless object constructor if the record inherits from object.*
- **CS8878** - *A copy constructor '{0}' must be public or protected because the record is not sealed.*
- **CS8910** - *The primary constructor conflicts with the synthesized copy constructor.*
- **CS8958** - *The parameterless struct constructor must be 'public'.*
- **CS8982** - *A constructor declared in a 'struct' with parameter list must have a 'this' initializer that calls the primary constructor or an explicitly declared constructor.*
- **CS8983** - *A 'struct' with field initializers must include an explicitly declared constructor.*

## Primary constructor syntax

The compiler emits the following errors when a primary constructor violates one or more rules on primary constructors for classes and structs:

- **CS9105** - *Cannot use primary constructor parameter in this context.*
- **CS9106** - *Identifier is ambiguous between type and parameter in this context.*
- **CS9108** - *Cannot use parameter that has ref-like type inside an anonymous method, lambda expression, query expression, or local function.*
- **CS9109** - *Cannot use ref, out, or in primary constructor parameter inside an instance member.*
- **CS9110** - *Cannot use primary constructor parameter that has ref-like type inside an instance member.*
- **CS9111** - *Anonymous methods, lambda expressions, query expressions, and local functions inside an instance member of a struct cannot access primary constructor parameter.*
- **CS9112** - *Anonymous methods, lambda expressions, query expressions, and local functions inside a struct cannot access primary constructor parameter also used inside an instance member.*
- **CS9114** - *A primary constructor parameter of a readonly type cannot be assigned to (except in init-only setter of the type or a variable initializer).*
- **CS9115** - *A primary constructor parameter of a readonly type cannot be returned by writable reference.*
- **CS9116** - *A primary constructor parameter of a readonly type cannot be used as a ref or out value (except in init-only setter of the type or a variable initializer).*
- **CS9117** - *Members of primary constructor parameter of a readonly type cannot be modified (except in init-only setter of the type or a variable initializer).*
- **CS9118** - *Members of primary constructor parameter of a readonly type cannot be returned by writable reference.*
- **CS9119** - *Members of primary constructor parameter' of a readonly type cannot be used as a ref or out value (except in init-only setter of the type or a variable initializer).*
- **CS9120** - *Cannot return primary constructor parameter by reference.*
- **CS9121** - *Struct primary constructor parameter of type causes a cycle in the struct layout.*
- **CS9122** - *Unexpected parameter list.*

Primary constructor parameters are in scope in the body of that type. The compiler can synthesize a field that stores the parameter for use in members or in field initializers. Because a primary constructor parameter may be copied to a field, the following restrictions apply:

- Primary constructors can be declared on `struct` and `class` types, but not on `interface` types.
- Primary constructor parameters can't be used in a `base()` constructor call except as part of the primary constructor.
- Primary constructor parameters of `ref struct` type can't be accessed in lambda expressions, query expressions, or local functions.
- If the type isn't a `ref struct`, `ref struct` parameters can't be accessed in instance members.
- In a `ref struct` type, primary constructor parameters with the `in`, `ref` or `out` modifiers can't be used in any instance methods, or property accessors.

Struct types have the following additional restrictions on primary constructor parameters:

- Primary constructor parameters can't be captured in lambda expressions, query expressions, or local functions.
- Primary constructor parameters can't be returned by reference (`ref` return or `readonly ref` return).

Readonly only struct types have the following additional restrictions on primary constructor parameters:

- Neither primary constructor parameters or their members can't be reassigned in a `readonly` struct.
- Neither primary constructor parameters or their members can't be `ref` returned in a `readonly` struct.
- Neither primary constructor parameters or their members can be passed by `ref` or `out` to any method.

In all these cases, the restrictions on primary constructor parameters are consistent with restrictions on data fields in those types. The restrictions are because a primary constructor parameter may be transformed into a synthesized field in the type. Therefore primary constructor parameters must follow the rules that apply to that synthesized field.

The two warnings provide guidance on captured primary constructor parameters.

- **CS9107** - *Parameter is captured into the state of the enclosing type and its value is also passed to the base constructor. The value might be captured by the base class as well.* This warning indicates that your code may be allocated two copies of a primary constructor parameter. Because the parameter is passed to the base class, the base class likely uses it. Because the derived class access it, it may have a second copy of the same parameter. That may not be intended.
- **CS9113** - *Parameter is unread.* This warning indicates that your class never references the primary constructor, even to pass it to the base primary constructor. It likely isn't needed.

## Existing error codes

### CS0514

'constructor' : static constructor cannot have an explicit 'this' or 'base' constructor call

Calling `this` in the static constructor is not allowed because the static constructor is called automatically before creating any instance of the class. Also, static constructors are not inherited, and cannot be called directly.

For more information, see [this](../../language-reference/keywords/this.md) and [base](../../language-reference/keywords/base.md).

The following example generates CS0514:

```csharp
// CS0514.cs
class A
{
    static A() : base(0) // CS0514
    {
    }

    public A(object o)
    {
    }
}

class B
{
    static B() : this(null) // CS0514
    {
    }

    public B(object o)
    {
    }
}
```

### CS0515

'function' : access modifiers are not allowed on static constructors

A static constructor cannot have an [access modifier](../../language-reference/keywords/index.md).

The following sample generates CS0515:

```csharp
// CS0515.cs
public class Clx
{
    public static void Main()
    {
    }
}

public class Clz
{
    public static Clz()   // CS0515, remove public keyword
    {
    }
}
```

### CS0516

Constructor 'constructor' can not call itself

A program cannot recursively call constructors.

The following sample generates CS0516:

```csharp
// CS0516.cs
namespace x
{
   public class clx
   {
      public clx() : this()   // CS0516, delete "this()"
      {
      }

      public static void Main()
      {
      }
   }
}
```

### CS0517

'class' has no base class and cannot call a base constructor

CS0517 can occur only when the .NET runtime compiles the source code for the object class, which is the only class that has no base class.

### CS0522

'constructor' : structs cannot call base class constructors

A [struct](../../language-reference/builtin-types/struct.md) cannot call a base class constructor; remove the call to the base class constructor.

The following sample generates CS0522:

```csharp
// CS0522.cs
public class clx
{
   public clx(int i)
   {
   }

   public static void Main()
   {
   }
}

public struct cly
{
   public cly(int i):base(0)   // CS0522
   // try the following line instead
   // public cly(int i)
   {
   }
}
```

### CS0526

Interfaces cannot contain constructors

Constructors cannot be defined for [interfaces](../../language-reference/keywords/interface.md). A method is considered a constructor if it has the same name as the class and no return type.

The following sample generates CS0526:

```csharp
// CS0526.cs
namespace x
{
   public interface clx
   {
      public clx()   // CS0526
      {
      }
   }

   public class cly
   {
      public static void Main()
      {
      }
   }
}
```

### CS0710

Static classes cannot have instance constructors

A static class cannot be instantiated, hence it has no need for constructors. To avoid this error, remove any constructors from static classes, or if you really want to construct instances, make the class non-static.

The following sample generates CS0710:

```csharp
// CS0710.cs
public static class C
{
   public C()  // CS0710
   {
   }

   public static void Main()
   {
   }
}
```

### CS0824

Warning level 1

Constructor 'name' is marked external.

A constructor may be marked as extern. However, the compiler cannot verify that the constructor actually exists. Therefore the warning is generated.

To correct this warning:

1. Use a pragma warning directive to ignore it.
1. Move the constructor inside the type.

The following code generates CS0824:

```csharp
// cs0824.cs
public class C
{
    extern C(); // CS0824
    public static int Main()
    {
        return 1;
    }
}
```

### CS1729

'type' does not contain a constructor that takes 'number' arguments.

This error occurs when you either directly or indirectly invoke the constructor of a class but the compiler cannot find any constructors with the same number of parameters. In the following example, the `test` class has no constructors that take any arguments. It therefore has only a parameterless constructor that takes zero arguments. Because in the second line in which the error is generated, the derived class declares no constructors of its own, the compiler provides a parameterless constructor. That constructor invokes a parameterless constructor in the base class. Because the base class has no such constructor, CS1729 is generated.

To correct this error  
  
1. Adjust the number of parameters in the call to the constructor.
1. Modify the class to provide a constructor with the parameters you must call.
1. Provide a parameterless constructor in the base class.

The following example generates CS1729:

```csharp
// cs1729.cs
class Test
{
    static int Main()
    {
        // Class Test has only a parameterless constructor, which takes no arguments.
        Test test1 = new Test(2); // CS1729
        // The following line resolves the error.
        Test test2 = new Test();

        // Class Parent has only one constructor, which takes two int parameters.
        Parent exampleParent1 = new Parent(10); // CS1729
        // The following line resolves the error.
        Parent exampleParent2 = new Parent(10, 1);

        return 1;
    }
}

public class Parent
{
    // The only constructor for this class has two parameters.
    public Parent(int i, int j) { }
}

// The following declaration causes a compiler error because class Parent
// does not have a constructor that takes no arguments. The declaration of
// class Child2 shows how to resolve this error.
public class Child : Parent { } // CS1729

public class Child2 : Parent
{
    // The constructor for Child2 has only one parameter. To access the
    // constructor in Parent, and prevent this compiler error, you must provide
    // a value for the second parameter of Parent. The following example provides 0.
    public Child2(int k)
        : base(k, 0)
    {
        // Add the body of the constructor here.
    }
}
```
