---
title: "Resolve errors from invalid expression contexts"
description: "This article helps you diagnose and correct compiler errors and warnings from expressions that appear in contexts where they are not permitted"
f1_keywords:
  - "CS0175"
  - "CS0186"
  - "CS1547"
  - "CS8115"
  - "CS8185"
  - "CS8209"
  - "CS8310"
  - "CS8312"
helpviewer_keywords:
  - "CS0175"
  - "CS0186"
  - "CS1547"
  - "CS8115"
  - "CS8185"
  - "CS8209"
  - "CS8310"
  - "CS8312"
ms.date: 08/20/2026
ai-usage: ai-assisted
---

# Resolve errors from invalid expression contexts

This article covers the following compiler errors and warnings:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->

- [**CS0175**](#invalid-expression-contexts): *Use of keyword 'base' is not valid in this context*
- [**CS0186**](#invalid-expression-contexts): *Use of null is not valid in this context*
- [**CS1547**](#invalid-expression-contexts): *Keyword 'void' cannot be used in this context*
- [**CS8115**](#invalid-expression-contexts): *A throw expression is not allowed in this context.*
- [**CS8185**](#invalid-expression-contexts): *A declaration is not allowed in this context.*
- [**CS8209**](#invalid-expression-contexts): *A value of type 'void' may not be assigned.*
- [**CS8310**](#invalid-expression-contexts): *Operator 'operator' cannot be applied to operand 'operand'*
- [**CS8312**](#invalid-expression-contexts): *Use of default literal is not valid in this context*

## Invalid expression contexts

The following diagnostics identify expressions that appear in contexts where they are not permitted. These errors typically arise when keywords, literals, or expressions are used in positions where the compiler does not permit them. The remediation strategy depends on the specific keyword or expression type.

- **CS0175**: *Use of keyword 'base' is not valid in this context*. The `base` keyword must be used to access a specific member of the base class. It cannot be used as a standalone expression. When you need to reference the base class, access a member explicitly: `base.MemberName` instead of just `base`. For example, avoid `Console.WriteLine(base);` and instead use `Console.WriteLine(base.Member);`. Similarly, do not attempt to assign to `base` directly; instead, assign to a specific base member: `base.Member = value;`. Ensure you always specify which base class member you need to access. This error also occurs when using `base` outside of an instance method in a derived class.

- **CS0186**: *Use of null is not valid in this context*. The `null` literal cannot be used in contexts where the compiler expects a concrete collection or enumerable. This error commonly occurs in `foreach` loops where `null` is provided as the collection to iterate over. In a `foreach` loop, the collection must implement `IEnumerable` (or similar interface) and must be non-null. If your data source might be null, check for null before the loop:

  ```csharp
  IEnumerable collection = /* your source */;
  if (collection != null)
  {
      foreach (var item in collection)
      {
          // Process item
      }
  }
  ```

  Alternatively, use a null-coalescing operator or default empty collection:

  ```csharp
  foreach (var item in collection ?? Enumerable.Empty<T>())
  {
      // Process item
  }
  ```

- **CS1547**: *Keyword 'void' cannot be used in this context*. The `void` keyword indicates the absence of a return value and cannot be used as a variable type or field type. It is valid only as a method return type (`void Method() { }`), a delegate return type (`public delegate void Action();`), or a pointer-to-void in unsafe code (`void* ptr;`). If you encounter this error, you are likely attempting to declare a variable of type `void`, which is invalid. Instead, choose an appropriate type for the variable. If you need a method that performs an action without returning a value, call it as a standalone statement (`MyMethod();`); do not attempt to assign its result.

- **CS8115**: *A throw expression is not allowed in this context.*. The compiler permits throw expressions only in specific contexts where an expression can appear and the exception is immediately propagated. Move the `throw` expression to a valid context, such as a conditional arm of a ternary or switch expression (where the throw is one of the arms), an assignment to evaluate the throw in place of the assigned value, or an argument to a method call where throwing is appropriate. A throw expression can also appear in a statement in a lambda or local function body (not within a method that must return a value). If the throw expression appears in a position where the expression value must be used (such as within arithmetic or operator expressions), extract it into a separate statement or conditional check.

- **CS8185**: *A declaration is not allowed in this context.*. The compiler permits declaration expressions (`out var`, pattern-matching declarations) only in specific positions, including `out` parameter declarations in method calls and in certain statement contexts. Remove the declaration expression from contexts where it's not permitted, such as lambda expression bodies (unless the lambda is a statement body), query expressions where the grammar forbids declarations, inside attribute arguments, or in contexts that require a read-only expression. If you need to use an out variable, call the method in a separate statement, then reference the resulting variable. Alternatively, use a local variable declaration before the expression.

- **CS8209**: *A value of type 'void' may not be assigned.*. The `void` type is not a value type; it represents the absence of a return value. Remove the assignment of void-returning expressions. If you need to invoke a method that returns `void`, call it as a standalone statement. If you need a result, use a method that returns a value instead. Ensure that expressions assigned to variables always have a meaningful return type.

- **CS8310**: *Operator 'operator' cannot be applied to operand 'operand'* and **CS8312**: *Use of default literal is not valid in this context*. The `default` literal and typeless expressions (such as `null` or `new` without a target type) require a target type for the compiler to infer the expression type. When an operator is applied to these expressions without enough context, the compiler cannot determine the operand type. Provide the target type by adding an explicit type cast (`(int)default` or `(MyType)new`), assigning to a typed variable (`int x = default;`), using a method parameter or return type to establish context, or using the verbose form `default(Type)` instead of the `default` literal for clarity. If the operator itself requires a specific type, ensure the operand can be implicitly converted to that type.
