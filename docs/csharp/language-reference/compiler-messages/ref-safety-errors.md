---
title: Errors and warnings related to ref safety
description: The compiler issues these errors and warnings when the referent of a reference variable might not be valid. These errors prevent you from creating dangling references.
f1_keywords:
  - "CS8166"
  - "CS8167"
  - "CS8168"
  - "CS8169"
  - "CS8345"
  - "CS8351"
  - "CS8374"
  - "CS9077"
  - "CS9078"
  - "CS9079"
  - "CS9085"
  - "CS9086"
  - "CS9088"
  - "CS9089"
  - "CS9090"
  - "CS9091"
  - "CS9091"
  - "CS9092"
  - "CS9093"
  - "CS9094"
  - "CS9095"
  - "CS9096"
  - "CS9097"
helpviewer_keywords:
  - "CS8166"
  - "CS8167"
  - "CS8168"
  - "CS8169"
  - "CS8345"
  - "CS8351"
  - "CS8374"
  - "CS9077"
  - "CS9078"
  - "CS9079"
  - "CS9085"
  - "CS9086"
  - "CS9087"
  - "CS9089"
  - "CS9091"
  - "CS9092"
  - "CS9093"
  - "CS9094"
  - "CS9095"
  - "CS9096"
  - "CS9097"
ai-usage: ai-assisted
ms.date: 11/21/2024
---
# Errors and warnings related to ref safety

The following errors can be generated when reference variable safety rules are violated:

<!-- The text in the bullet lists generate issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->
- [**CS8166**](#ref-safety-violations): *Cannot return a parameter by reference because it is not a `ref` parameter*
- [**CS8167**](#ref-safety-violations): *Cannot return by reference a member of parameter because it is not a `ref` or `out` parameter*
- [**CS8168**](#ref-safety-violations): *Cannot return local by reference because it is not a ref local*
- [**CS8169**](#ref-safety-violations): *Cannot return a member of local variable by reference because it is not a ref local*
- [**CS8345**](#ref-safety-violations): *Field or auto-implemented property cannot be of type unless it is an instance member of a `ref struct`.*
- [**CS8351**](#ref-safety-violations): *Branches of a `ref` conditional operator cannot refer to variables with incompatible declaration scopes*
- [**CS8374**](#ref-safety-violations): *Cannot ref-assign source has a narrower escape scope than destination.*
- [**CS9075**](#ref-safety-violations): *Cannot return a parameter by reference because it is scoped to the current method*
- [**CS9076**](#ref-safety-violations): *Cannot return by reference a member of parameter because it is scoped to the current method*
- [**CS9077**](#ref-safety-violations): *Cannot return a parameter by reference through a `ref` parameter; it can only be returned in a return statement*
- [**CS9078**](#ref-safety-violations): *Cannot return by reference a member of parameter through a `ref` parameter; it can only be returned in a return statement*
- [**CS9079**](#ref-safety-violations): *Cannot ref-assign source to destination because source can only escape the current method through a return statement.*
- [**CS9096**](#ref-safety-violations): *Cannot ref-assign source to destination because source has a wider value escape scope than destination allowing assignment through destination of values with narrower escapes scopes than source.*

The following warnings are generated when reference variable safety rules are violated:

- [**CS9080**](#ref-safety-violations): *Use of variable in this context may expose referenced variables outside of their declaration scope*
- [**CS9081**](#ref-safety-violations): *A result of a stackalloc expression of type in this context may be exposed outside of the containing method*
- [**CS9082**](#ref-safety-violations): *Local is returned by reference but was initialized to a value that cannot be returned by reference*
- [**CS9083**](#ref-safety-violations): *A member of is returned by reference but was initialized to a value that cannot be returned by reference*
- [**CS9084**](#ref-safety-violations): *Struct member returns 'this' or other instance members by reference*
- [**CS9085**](#ref-safety-violations): *This ref-assigns source to destination but source has a narrower escape scope than destination.*
- [**CS9086**](#ref-safety-violations): *The branches of the ref conditional operator refer to variables with incompatible declaration scopes*
- [**CS9087**](#ref-safety-violations): *This returns a parameter by reference but it is not a `ref` parameter*
- [**CS9088**](#ref-safety-violations): *This returns a parameter by reference but it is scoped to the current method*
- [**CS9089**](#ref-safety-violations): *This returns by reference a member of parameter that is not a `ref` or `out` parameter*
- [**CS9090**](#ref-safety-violations): *This returns by reference a member of parameter that is scoped to the current method*
- [**CS9091**](#ref-safety-violations): *This returns local by reference but it is not a ref local*
- [**CS9092**](#ref-safety-violations): *This returns a member of local by reference but it is not a ref local*
- [**CS9093**](#ref-safety-violations): *This ref-assigns source to destination but source can only escape the current method through a return statement.*
- [**CS9094**](#ref-safety-violations): *This returns a parameter by reference through a `ref` parameter; but it can only safely be returned in a return statement*
- [**CS9095**](#ref-safety-violations): *This returns by reference a member of parameter through a `ref` parameter; but it can only safely be returned in a return statement*
- [**CS9097**](#ref-safety-violations): *This ref-assigns source to destination but source has a wider value escape scope than destination allowing assignment through destination of values with narrower escapes scopes than source.*

## Ref safety violations

The compiler tracks the safe context of referents and reference variables. The compiler issues errors, or warnings in unsafe code, when a reference variable refers to a referent variable that's no longer valid. The referent must have a safe context that is at least as wide as the ref safe context of The reference variable. Violating these safety checks means the reference variable accesses random memory instead of the referent variable.

- **CS8166**:  *Cannot return a parameter by reference because it is not a `ref` parameter*
- **CS8167**:  *Cannot return by reference a member of parameter because it is not a `ref` or `out` parameter*
- **CS8168**:  *Cannot return local by reference because it is not a ref local*
- **CS8169**:  *Cannot return a member of local variable by reference because it is not a ref local*
- **CS8345**:  *Field or auto-implemented property cannot be of type unless it is an instance member of a `ref struct`.*
- **CS8351**:  *Branches of a `ref` conditional operator cannot refer to variables with incompatible declaration scopes*
- **CS8374**:  *Cannot ref-assign source has a narrower escape scope than destination.*
- **CS9075**:  *Cannot return a parameter by reference because it is scoped to the current method*
- **CS9076**:  *Cannot return by reference a member of parameter because it is scoped to the current method*
- **CS9077**:  *Cannot return a parameter by reference through a `ref` parameter; it can only be returned in a return statement*
- **CS9078**:  *Cannot return by reference a member of parameter through a `ref` parameter; it can only be returned in a return statement*
- **CS9079**:  *Cannot ref-assign source to destination because source can only escape the current method through a return statement.*
- **CS9096**:  *Cannot ref-assign source to destination because source has a wider value escape scope than destination allowing assignment through destination of values with narrower escapes scopes than source.*

Warnings:

- **CS9080**:  *Use of variable in this context may expose referenced variables outside of their declaration scope*
- **CS9081**:  *A result of a stackalloc expression of type in this context may be exposed outside of the containing method*
- **CS9082**:  *Local is returned by reference but was initialized to a value that cannot be returned by reference*
- **CS9083**:  *A member of is returned by reference but was initialized to a value that cannot be returned by reference*
- **CS9084**:  *Struct member returns 'this' or other instance members by reference*
- **CS9085**:  *This ref-assigns source to destination but source has a narrower escape scope than destination.*
- **CS9086**:  *The branches of the ref conditional operator refer to variables with incompatible declaration scopes*
- **CS9087**:  *This returns a parameter by reference but it is not a `ref` parameter*
- **CS9088**:  *This returns a parameter by reference but it is scoped to the current method*
- **CS9089**:  *This returns by reference a member of parameter that is not a `ref` or `out` parameter*
- **CS9090**:  *This returns by reference a member of parameter that is scoped to the current method*
- **CS9091**:  *This returns local by reference but it is not a ref local*
- **CS9092**:  *This returns a member of local by reference but it is not a ref local*
- **CS9093**:  *This ref-assigns source to destination but source can only escape the current method through a return statement.*
- **CS9094**:  *This returns a parameter by reference through a `ref` parameter; but it can only safely be returned in a return statement*
- **CS9095**:  *This returns by reference a member of parameter through a `ref` parameter; but it can only safely be returned in a return statement*
- **CS9097**:  *This ref-assigns source to destination but source has a wider value escape scope than destination allowing assignment through destination of values with narrower escapes scopes than source.*

The compiler uses static analysis to determine if the referent is valid at all points where the reference variable can be used. You need to refactor code so that the referent remains valid at all locations where the reference variable might refer to it. For details on the rules for ref safety, see the C# standard on [ref safe contexts](~/_csharpstandard/standard/variables.md#972-ref-safe-contexts).
