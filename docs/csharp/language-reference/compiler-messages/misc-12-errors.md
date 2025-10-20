title: Remaining errors introduced in C# 12
description: Not sure what the themes will be, but let's start
f1_keywords:
  - "CS9123"
  - "CS9125"
  - "CS9205"
  - "CS9212"
  - "CS9213"
  - "CS9214"
  - "CS9215"
  - "CS9222"
  - "CS9229"
  - "CS9230"
  - "CS9231"
  - "CS9232"
  - "CS9233"
  - "CS9234"
  - "CS9235"
  - "CS9236"
helpviewer_keywords:
  - "CS9123"
  - "CS9125"
  - "CS9205"
  - "CS9212"
  - "CS9213"
  - "CS9214"
  - "CS9215"
  - "CS9222"
  - "CS9229"
  - "CS9230"
  - "CS9231"
  - "CS9232"
  - "CS9233"
  - "CS9234"
  - "CS9235"
  - "CS9236"
ms.date: 10/10/2025
---
# Errors and warnings introduced in C# 12

The following errors and warnings were introduced in C# 12:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->

Unsafe.
- [**CS9123**](#tbd): *The '&' operator should not be used on parameters or local variables in async methods.*

Fixed sized buffers
- [**CS9125**](#tbd): *Attribute parameter 'SizeConst' must be specified.*

Weird ref safety, based on passing an interpolated string as an `out` parameter.
- [**CS9205**](#tbd): *Expected interpolated string*

// collection expressions
- [**CS9212**](#tbd): *Spread operator '..' cannot operate on variables of type 'type' because 'type' does not contain a public instance or extension definition for 'member'*
- [**CS9213**](#tbd): *Collection expression target 'type' has no element type.*
- [**CS9214**](#tbd): *Collection expression type must have an applicable constructor that can be called with no arguments.*
- [**CS9215**](#tbd): *Collection expression type 'type' must have an instance or extension method 'Add' that can be called with a single argument.*
- [**CS9222**](#tbd): *Collection initializer results in an infinite chain of instantiations of collection 'type'.*

invalid using declaration
- [**CS9229**](#tbd): *Modifiers cannot be placed on using declarations*

dynamic binding
- [**CS9230**](#tbd): *Cannot perform a dynamic invocation on an expression with type 'type'.*

interceptors
- [**CS9231**](#tbd): *The data argument to InterceptsLocationAttribute is not in the correct format.*
- [**CS9232**](#tbd): *Version 'version' of the interceptors format is not supported. The latest supported version is '1'.*
- [**CS9233**](#tbd): *Cannot intercept a call in file 'file' because it is duplicated elsewhere in the compilation.*
- [**CS9234**](#tbd): *Cannot intercept a call in file 'file' because a matching file was not found in the compilation.*
- [**CS9235**](#tbd): *The data argument to InterceptsLocationAttribute refers to an invalid position in file 'file'.*

lambda, but informational only
- [**CS9236**](#tbd): *Compiling requires binding the lambda expression at least count times. Consider declaring the lambda expression with explicit parameter types, or if the containing method call is generic, consider using explicit type arguments.*


