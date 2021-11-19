---
title: "Compiler-generated exceptions"
description: Learn about compiler-generated exceptions. Review a list of automatically thrown exceptions and their error conditions.
ms.date: 05/14/2021
helpviewer_keywords: 
  - "exceptions [C#], compiler-generated"
---
# Compiler-generated exceptions

Some exceptions are thrown automatically by the .NET runtime when basic operations fail. These exceptions and their error conditions are listed in the following table.

|Exception|Description|
|---------------|-----------------|
|<xref:System.ArithmeticException>|A base class for exceptions that occur during arithmetic operations, such as <xref:System.DivideByZeroException> and <xref:System.OverflowException>.|
|<xref:System.ArrayTypeMismatchException>|Thrown when an array can't store a given element because the actual type of the element is incompatible with the actual type of the array.|
|<xref:System.DivideByZeroException>|Thrown when an attempt is made to divide an integral value by zero.|
|<xref:System.IndexOutOfRangeException>|Thrown when an attempt is made to index an array when the index is less than zero or outside the bounds of the array.|
|<xref:System.InvalidCastException>|Thrown when an explicit conversion from a base type to an interface or to a derived type fails at run time.|
|<xref:System.NullReferenceException>|Thrown when an attempt is made to reference an object whose value is [null](../../language-reference/keywords/null.md).|
|<xref:System.OutOfMemoryException>|Thrown when an attempt to allocate memory using the [new](../../language-reference/operators/new-operator.md) operator fails. This exception indicates that the memory available to the common language runtime has been exhausted.|
|<xref:System.OverflowException>|Thrown when an arithmetic operation in a `checked` context overflows.|
|<xref:System.StackOverflowException>|Thrown when the execution stack is exhausted by having too many pending method calls; usually indicates a very deep or infinite recursion.|
|<xref:System.TypeInitializationException>|Thrown when a static constructor throws an exception and no compatible `catch` clause exists to catch it.|

## See also

- [try-catch](../../language-reference/keywords/try-catch.md)
- [try-finally](../../language-reference/keywords/try-finally.md)
- [try-catch-finally](../../language-reference/keywords/try-catch-finally.md)
