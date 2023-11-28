---
title: Static abstract interface members errors and warnings
description: These warnings and errors are generated when static abstract or virtual members are used incorrectly. Learn how to correct these errors.
f1_keywords:
  - "CS8920"
  - "CS8921"
  - "CS8922"
  - "CS8923"
  - "CS8924"
  - "CS8925"
  - "CS8926"
  - "CS8928"
  - "CS9030"
  - "CS8931"
  - "CS8932"
helpviewer_keywords:
  - "CS8920"
  - "CS8921"
  - "CS8922"
  - "CS8923"
  - "CS8924"
  - "CS8925"
  - "CS8926"
  - "CS8928"
  - "CS8930"
  - "CS8931"
  - "CS8932"
ms.date: 11/27/2023
---
# Static abstract and virtual interface member errors and warnings

The compiler generates the following errors for invalid declarations of static abstract or virtual members in interfaces:

- **CS8920**: *The interface cannot be used as type argument. Static member does not have a most specific implementation in the interface.*
- **CS8921**: *The parameter of a unary operator must be the containing type, or its type parameter constrained to it.*
- **CS8922**: *The parameter type for `++` or `--` operator must be the containing type, or its type parameter constrained to it.*
- **CS8923**: *The return type for `++` or `--` operator must either match the parameter type, or be derived from the parameter type, or be the containing type's type parameter constrained to it unless the parameter type is a different type parameter.*
- **CS8924**: *One of the parameters of a binary operator must be the containing type, or its type parameter constrained to it.*
- **CS8925**: *The first operand of an overloaded shift operator must have the same type as the containing type or its type parameter constrained to it*
- **CS8926**: *A static virtual or abstract interface member can be accessed only on a type parameter.*
- **CS8928**: *Type does not implement static interface member. The method cannot implement the interface member because it is not static.*
- **CS8930**: *Explicit implementation of a user-defined operator '{0}' must be declared static*
- **CS8931**: *User-defined conversion in an interface must convert to or from a type parameter on the enclosing type constrained to the enclosing type*
- **CS8932**: *'UnmanagedCallersOnly' method cannot implement interface member in type*
