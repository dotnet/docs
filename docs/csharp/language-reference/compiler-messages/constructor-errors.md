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
 - "CS9122" # ERR_UnexpectedParameterList - Unexpected parameter list.
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

- **CS9105** - *Cannot use primary constructor parameter in this context.*
- **CS9106** - *Identifier is ambiguous between type and parameter in this context.*
- **CS9107** - *Parameter is captured into the state of the enclosing type and its value is also passed to the base constructor. The value might be captured by the base class as well.*
- **CS9108** - *Cannot use parameter that has ref-like type inside an anonymous method, lambda expression, query expression, or local function.*
- **CS9109** - *Cannot use ref, out, or in primary constructor parameter inside an instance member.*
- **CS9110** - *Cannot use primary constructor parameter that has ref-like type inside an instance member.*
- **CS9111** - *Anonymous methods, lambda expressions, query expressions, and local functions inside an instance member of a struct cannot access primary constructor parameter.*
- **CS9112** - *Anonymous methods, lambda expressions, query expressions, and local functions inside a struct cannot access primary constructor parameter also used inside an instance member.*
- **CS9113** - *Parameter is unread.*
- **CS9114** - *A primary constructor parameter of a readonly type cannot be assigned to (except in init-only setter of the type or a variable initializer).*
- **CS9115** - *A primary constructor parameter of a readonly type cannot be returned by writable reference.*
- **CS9116** - *A primary constructor parameter of a readonly type cannot be used as a ref or out value (except in init-only setter of the type or a variable initializer).*
- **CS9117** - *Members of primary constructor parameter of a readonly type cannot be modified (except in init-only setter of the type or a variable initializer).*
- **CS9118** - *Members of primary constructor parameter of a readonly type cannot be returned by writable reference.*
- **CS9119** - *Members of primary constructor parameter' of a readonly type cannot be used as a ref or out value (except in init-only setter of the type or a variable initializer).*
- **CS9120** - *Cannot return primary constructor parameter by reference.*
- **CS9121** - *Struct primary constructor parameter of type causes a cycle in the struct layout.*
- **CS9122** - *Unexpected parameter list.*

## Things
