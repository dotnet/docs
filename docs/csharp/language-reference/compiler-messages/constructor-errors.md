---
title: Resolve errors related to constructor declarations
description: These compiler errors and warnings indicate violations when declaring constructors in classes or structs, including records. This article provides guidance on resolving those errors.
f1_keywords:
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

This article covers the following compiler warnings:

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

- **CS9107** - *Parameter is captured into the state of the enclosing type and its value is also passed to the base constructor. The value might be captured by the base class as well.*
- **CS9113** - *Parameter is unread.*

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
