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
 - "CS0710"
 - "CS0768"
 - "CS0824" # WRN_ExternCtorNoImplementation
 - "CS8054" # ERR_EnumsCantContainDefaultConstructor
 - "CS8091" # ERR_ExternHasConstructorInitializer
 - "CS8358" # ERR_AttributeCtorInParameter
 - "CS8861"
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
 - "CS9124"
 - "CS9136"
 - "CS9179"
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
 - "CS8054"
 - "CS8091"
 - "CS8358"
 - "CS8861"
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
 - "CS9124"
 - "CS9136"
 - "CS9179"
ms.date: 11/22/2024
---
# Resolve errors and warnings in constructor declarations

This article covers the following compiler errors:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->
- [**CS0514**](#static-constructors): *static constructor cannot have an explicit 'this' or 'base' constructor call.*
- [**CS0515**](#static-constructors): *access modifiers are not allowed on static constructors.*
- [**CS0516**](#constructor-calls-with-base-and-this): *Constructor 'constructor' can not call itself.*
- [**CS0517**](#constructor-declaration): *'class' has no base class and cannot call a base constructor.*
- [**CS0522**](#constructor-calls-with-base-and-this): *structs cannot call base class constructors.*
- [**CS0526**](#constructor-declaration): *Interfaces cannot contain constructors.*
- [**CS0568**](#constructors-in-struct-types): *Structs cannot contain explicit parameterless constructors.*
- [**CS0710**](#constructor-declaration): *Static classes cannot have instance constructors.*
- [**CS0768**](#constructor-calls-with-base-and-this): *Constructor cannot call itself through another constructor.*
- [**CS8054**](#constructor-declaration): *Enums cannot contain explicit parameterless constructors.*
- [**CS8091**](#constructor-declaration): *cannot be extern and have a constructor initializer.*
- [**CS8861**](#primary-constructor-declaration): *Unexpected argument list.*
- [**CS8862**](#primary-constructor-declaration): *A constructor declared in a type with parameter list must have 'this' constructor initializer.*
- [**CS8358**](#constructor-declaration): *Cannot use attribute constructor because it has 'in' parameters.*
- [**CS8867**](#records-and-copy-constructors): *No accessible copy constructor found in base type '{0}'.*
- [**CS8868**](#records-and-copy-constructors): *A copy constructor in a record must call a copy constructor of the base, or a parameterless object constructor if the record inherits from object.*
- [**CS8878**](#records-and-copy-constructors): *A copy constructor '{0}' must be public or protected because the record is not sealed.*
- [**CS8910**](#records-and-copy-constructors): *The primary constructor conflicts with the synthesized copy constructor.*
- [**CS8958**](#constructors-in-struct-types): *The parameterless struct constructor must be 'public'.*
- [**CS8982**](#constructors-in-struct-types): *A constructor declared in a 'struct' with parameter list must have a 'this' initializer that calls the primary constructor or an explicitly declared constructor.*
- [**CS8983**](#constructors-in-struct-types): *A 'struct' with field initializers must include an explicitly declared constructor.*
- [**CS9105**](#primary-constructor-declaration): *Cannot use primary constructor parameter in this context.*
- [**CS9106**](#primary-constructor-declaration): *Identifier is ambiguous between type and parameter in this context.*
- [**CS9108**](#primary-constructor-declaration): *Cannot use parameter that has ref-like type inside an anonymous method, lambda expression, query expression, or local function.*
- [**CS9109**](#primary-constructor-declaration): *Cannot use `ref`, `out`, or `in` primary constructor parameter inside an instance member.*
- [**CS9110**](#primary-constructor-declaration): *Cannot use primary constructor parameter that has ref-like type inside an instance member.*
- [**CS9111**](#primary-constructor-declaration): *Anonymous methods, lambda expressions, query expressions, and local functions inside an instance member of a struct cannot access primary constructor parameter.*
- [**CS9112**](#primary-constructor-declaration): *Anonymous methods, lambda expressions, query expressions, and local functions inside a struct cannot access primary constructor parameter also used inside an instance member.*
- [**CS9114**](#primary-constructor-declaration): *A primary constructor parameter of a readonly type cannot be assigned to (except in init-only setter of the type or a variable initializer).*
- [**CS9115**](#primary-constructor-declaration): *A primary constructor parameter of a readonly type cannot be returned by writable reference.*
- [**CS9116**](#primary-constructor-declaration): *A primary constructor parameter of a readonly type cannot be used as a ref or out value (except in init-only setter of the type or a variable initializer).*
- [**CS9117**](#primary-constructor-declaration): *Members of primary constructor parameter of a readonly type cannot be modified (except in init-only setter of the type or a variable initializer).*
- [**CS9118**](#primary-constructor-declaration): *Members of primary constructor parameter of a readonly type cannot be returned by writable reference.*
- [**CS9119**](#primary-constructor-declaration): *Members of primary constructor parameter of a readonly type cannot be used as a `ref` or `out` value (except in init-only setter of the type or a variable initializer).*
- [**CS9120**](#primary-constructor-declaration): *Cannot return primary constructor parameter by reference.*
- [**CS9121**](#primary-constructor-declaration): *Struct primary constructor parameter of type causes a cycle in the struct layout.*
- [**CS9122**](#primary-constructor-declaration): *Unexpected parameter list.*
- [**CS9136**](#primary-constructor-declaration): *Cannot use primary constructor parameter of type inside an instance member.*

In addition, the following warnings are covered in this article:

- [**CS0824**](#constructor-declaration): *Constructor 'name' is marked external.*
- [**CS9107**](#primary-constructor-declaration): *Parameter is captured into the state of the enclosing type and its value is also passed to the base constructor. The value might be captured by the base class as well.*
- [**CS9113**](#primary-constructor-declaration): *Parameter is unread.*
- [**CS9124**](#primary-constructor-declaration): *Parameter is captured into the state of the enclosing type and its value is also used to initialize a field, property, or event.*
- [**CS9179**](#primary-constructor-declaration): *Primary constructor parameter is shadowed by a member from base*

## Static constructors

- **CS0514**: *Static constructor cannot have an explicit 'this' or 'base' constructor call.*
- **CS0515**: *Access modifiers are not allowed on static constructors.*

You can write at most one static constructor for a type. The declaration of a static constructor must obey the following rules:

- The static constructor has the `static` modifier, but no other modifiers, such as `public`, `protected`, `private`, or `internal`.
- The static constructor must be a parameterless constructor.
- The static constructor must not call `base()` or `this()`. If the base class includes a static constructor, the runtime calls it automatically.

## Constructor declaration

- **CS0526**: *Interfaces cannot contain constructors.*
- **CS0710**: *Static classes cannot have instance constructors.*
- **CS8054**: *Enums cannot contain explicit parameterless constructors.*
- **CS8358**: *Cannot use attribute constructor because it has 'in' parameters.*
- **CS8091**: *A constructor cannot be extern and have a constructor initializer.*

Constructors are allowed only in `class` and `struct` types, including `record class` and `record struct` types. You can't define them in `enum` or `interface` types. Furthermore, [attribute](../attributes/general.md) class types can't declare `in` parameters. Instead, pass parameters by value.

You can declare `extern` constructors, however you can't use `base()` or `this()` constructor calls to call another constructor from a constructor declared `extern`.

In addition, the following warnings can be generated for constructor declarations:

- **CS0824**: *Constructor is marked external.*

When a constructor is marked `extern`, the compiler can't guarantee the constructor exists. Therefore, the compiler generates this warning.

## Constructors in struct types

- **CS0568**: *Structs cannot contain explicit parameterless constructors.*
- **CS8958**: *The parameterless struct constructor must be 'public'.*
- **CS8982**: *A constructor declared in a 'struct' with parameter list must have a 'this' initializer that calls the primary constructor or an explicitly declared constructor.*
- **CS8983**: *A 'struct' with field initializers must include an explicitly declared constructor.*

Recent features in C# remove earlier restrictions to `struct` types. **CS0568** is generated when you declare a parameterless instance constructor in older versions of C#. You can declare an explicit parameterless instance constructor in newer versions of C#. That explicit parameterless constructor must be `public`. If your `struct` declares any [field initializers](../../programming-guide/classes-and-structs/fields.md), you must also declare an explicit instance constructor. This constructor can be a parameterless constructor with an empty body.

When a `struct` type declares a primary constructor, including `record struct` types, all other instance constructors except a parameterless constructor must call the primary constructor or another explicitly declared constructor using `this()`.

## Constructor calls with `base` and `this`

- **CS0516**: *Constructor can not call itself.*
- **CS0517**: *Class has no base class and cannot call a base constructor.*
- **CS0522**: *Structs cannot call base class constructors.*
- **CS0768**: *Constructor cannot call itself through another constructor.*

You can use `base()` and `this()` to have one constructor call another in the same type or the base type. Calling constructors can minimize duplicated constructor logic. You must follow these rules when calling another constructor using `this()` or `base()`:

- A constructor can't call itself either directly or indirectly through another constructor. For example, the following code is illegal:

  ```csharp
  public class C
  {
    public C() : this() // Error!
    {
    }
  }

  public class C2
  {
    public class C2() : this(10) {}

    public class C2(int capacity) : this() 
    {
        _capacity = capacity;
    }

    private int _capacity;
  }
  ``

- Struct types can't call `base()`. Neither can <xref:System.Object?displayProperty=fullName>.

## Records and copy constructors

- **CS8867**: *No accessible copy constructor found in base type.*
- **CS8868**: *A copy constructor in a record must call a copy constructor of the base, or a parameterless object constructor if the record inherits from object.*
- **CS8878**: *A copy constructor must be public or protected because the record is not sealed.*
- **CS8910**: *The primary constructor conflicts with the synthesized copy constructor.*

Adding the `record` modifier to a `struct` or `class` type creates a [record](../builtin-types/record.md). Records include a compiler-synthesized [copy constructor](../builtin-types/record.md#nondestructive-mutation). You can write an explicit copy constructor yourself, but it must adhere to the following rules:

- Copy constructors must be `public` or `protected` unless the type is [`sealed`](../keywords/sealed.md).
- Copy constructors must call the `base()` copy constructor unless the base class is <xref:System.Object?displayProperty=nameWithType>.
- Furthermore, the base type must have a copy constructor. `record` types always have a copy constructor.

## Primary constructor declaration

The compiler emits the following errors when a primary constructor violates one or more rules on primary constructors for classes and structs:

- **CS8861**: *Unexpected argument list.*
- **CS8862**: *A constructor declared in a type with parameter list must have 'this' constructor initializer.*
- **CS9105**: *Cannot use primary constructor parameter in this context.*
- **CS9106**: *Identifier is ambiguous between type and parameter in this context.*
- **CS9108**: *Cannot use parameter that has ref-like type inside an anonymous method, lambda expression, query expression, or local function.*
- **CS9109**: *Cannot use `ref`, `out`, or `in` primary constructor parameter inside an instance member.*
- **CS9110**: *Cannot use primary constructor parameter that has ref-like type inside an instance member.*
- **CS9111**: *Anonymous methods, lambda expressions, query expressions, and local functions inside an instance member of a struct cannot access primary constructor parameter.*
- **CS9112**: *Anonymous methods, lambda expressions, query expressions, and local functions inside a struct cannot access primary constructor parameter also used inside an instance member.*
- **CS9114**: *A primary constructor parameter of a readonly type cannot be assigned to (except in init-only setter of the type or a variable initializer).*
- **CS9115**: *A primary constructor parameter of a readonly type cannot be returned by writable reference.*
- **CS9116**: *A primary constructor parameter of a readonly type cannot be used as a `ref` or `out` value (except in init-only setter of the type or a variable initializer).*
- **CS9117**: *Members of primary constructor parameter of a readonly type cannot be modified (except in init-only setter of the type or a variable initializer).*
- **CS9118**: *Members of primary constructor parameter of a readonly type cannot be returned by writable reference.*
- **CS9119**: *Members of primary constructor parameter of a readonly type cannot be used as a `ref` or `out` value (except in init-only setter of the type or a variable initializer).*
- **CS9120**: *Cannot return primary constructor parameter by reference.*
- **CS9121**: *Struct primary constructor parameter of type causes a cycle in the struct layout.*
- **CS9122**: *Unexpected parameter list.*
- **CS9124**: *Parameter is captured into the state of the enclosing type and its value is also used to initialize a field, property, or event.*
- **CS9136**: *Cannot use primary constructor parameter of type inside an instance member.*

Primary constructor parameters are in scope in the body of that type. The compiler can synthesize a field that stores the parameter for use in members or in field initializers. Because a primary constructor parameter may be copied to a field, the following restrictions apply:

- Primary constructors can be declared on `struct` and `class` types, but not on `interface` types.
- Primary constructor parameters can't be used in a `base()` constructor call except as part of the primary constructor.
- Primary constructor parameters of `ref struct` type can't be accessed in lambda expressions, query expressions, or local functions.
- If the type isn't a `ref struct`, `ref struct` parameters can't be accessed in instance members.
- In a `ref struct` type, primary constructor parameters with the `in`, `ref`, or `out` modifiers can't be used in any instance methods or property accessors.

Struct types have the following extra restrictions on primary constructor parameters:

- Primary constructor parameters can't be captured in lambda expressions, query expressions, or local functions.
- Primary constructor parameters can't be returned by reference (`ref` return or `readonly ref` return).

Readonly only struct types have the following extra restrictions on primary constructor parameters:

- Primary constructor parameters and their members can't be reassigned in a `readonly` struct.
- Primary constructor parameters and their members can't be `ref` returned in a `readonly` struct.
- Primary constructor parameters and their members can't be `ref` or `out` arguments to any method.

In all these cases, the restrictions on primary constructor parameters are consistent with restrictions on data fields in those types. The restrictions are because a primary constructor parameter may be transformed into a synthesized field in the type. Therefore primary constructor parameters must follow the rules that apply to that synthesized field.

A derived primary constructor calls the base primary constructor by supplying the parameters to the base constructor. You must use the parameter names from the derived constructor declaration.

The warnings provide guidance on captured or shadowed primary constructor parameters.

- **CS9107**: *Parameter is captured into the state of the enclosing type and its value is also passed to the base constructor. The value might be captured by the base class as well.* This warning indicates that your code may be allocated two copies of a primary constructor parameter. Because the parameter is passed to the base class, the base class likely uses it. Because the derived class accesses it, it may have a second copy of the same parameter. That extra storage may not be intended.
- **CS9113**: *Parameter is unread.* This warning indicates that your class never references the primary constructor, even to pass it to the base primary constructor. It likely isn't needed.
- **CS9124**: *Parameter is captured into the state of the enclosing type and its value is also used to initialize a field, property, or event.* This warning indicates that the constructor parameter of a nested type is also captured by the enclosing type. The parameter is likely stored twice.
- **CS9179**: *Primary constructor parameter is shadowed by a member from base*
