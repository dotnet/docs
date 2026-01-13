---
title: Resolve errors and warnings in file-scoped types
description: Learn how to diagnose and correct C# compiler errors and warnings when you declare file scoped types, or write source generators that create file scoped types.
f1_keywords:
  - "CS9051"
  - "CS9052"
  - "CS9053"
  - "CS9054"
  - "CS9055"
  - "CS9056"
  - "CS9068"
  - "CS9069"
  - "CS9071"
helpviewer_keywords:
  - "CS9051"
  - "CS9052"
  - "CS9053"
  - "CS9054"
  - "CS9055"
  - "CS9056"
  - "CS9068"
  - "CS9069"
  - "CS9071"
ms.date: 01/13/2026
ai-usage: ai-assisted
---
# Resolve errors and warnings for file scoped types

The C# compiler generates errors and warnings when you misuse [file-local types](../keywords/file.md). File-local types are visible only within the file where you declare them. These diagnostics help you follow the rules for declaring and using file-local types.

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->
- [**CS9051**](#visibility-restrictions): *File-local type cannot be used in a member signature in non-file-local type.*
- [**CS9052**](#visibility-restrictions): *File-local type cannot use accessibility modifiers.*
- [**CS9053**](#visibility-restrictions): *File-local type cannot be used as a base type of non-file-local type.*
- [**CS9054**](#declaration-rules): *File-local type must be defined in a top level type; it is a nested type.*
- [**CS9055**](#visibility-restrictions): *File-local type cannot be used in a 'global using static' directive.*
- [**CS9056**](#declaration-rules): *Types and aliases cannot be named 'file'.*
- [**CS9068**](#file-path-requirements): *File-local type must be declared in a file with a unique path. Path is used in multiple files.*
- [**CS9069**](#file-path-requirements): *File-local type cannot be used because the containing file path cannot be converted into the equivalent UTF-8 byte representation.*
- [**CS9071**](#declaration-rules): *The namespace already contains a definition for the type in this file.*

## Visibility restrictions

- **CS9051**: *File-local type cannot be used in a member signature in non-file-local type.*
- **CS9052**: *File-local type cannot use accessibility modifiers.*
- **CS9053**: *File-local type cannot be used as a base type of non-file-local type.*
- **CS9055**: *File-local type cannot be used in a 'global using static' directive.*

A [file-local type](../keywords/file.md) is visible only within the file containing its declaration. The compiler enforces restrictions to prevent file-local types from "leaking" outside their intended scope:

- A file-local type can't appear in the signature (parameters, return type, or type constraints) of any member declared in a non-file-local type (**CS9051**). This restriction ensures that code in other files doesn't depend on types it can't access.
- File-local types can't have explicit accessibility modifiers like `public`, `internal`, or `private` (**CS9052**). The `file` modifier already defines the type's visibility scope, making other access modifiers meaningless.
- A non-file-local type can't inherit from a file-local type (**CS9053**). If a derived type is visible outside the file, its base type must also be visible. However, a non-file-local type *can* implement a file-local interface.
- A file-local type can't be used in a `global using static` directive (**CS9055**). Global usings apply to all files in the compilation, but file-local types are visible only in their declaring file.

To resolve these errors, either remove the `file` modifier from the type to make it accessible outside the file, or change the consuming code to avoid exposing the file-local type.

## Declaration rules

- **CS9054**: *File-local type must be defined in a top level type; it is a nested type.*
- **CS9056**: *Types and aliases cannot be named 'file'.*
- **CS9071**: *The namespace already contains a definition for the type in this file.*

The compiler enforces rules about how file-local types are declared:

- File-local types must be declared at the top level of a file, not nested within another type (**CS9054**). To resolve this error, move the type declaration outside any containing type, or remove the `file` modifier.
- Types and type aliases can't be named `file` because it's now a contextual keyword (**CS9056**). To resolve this error, rename the type or use `@file` to escape the identifier.
- A file can't declare multiple file-local types with the same name in the same namespace (**CS9071**). Each file-local type must have a unique name within its namespace scope in that file. To resolve this error, rename one of the conflicting types.

## File path requirements

- **CS9068**: *File-local type must be declared in a file with a unique path. Path is used in multiple files.*
- **CS9069**: *File-local type cannot be used because the containing file path cannot be converted into the equivalent UTF-8 byte representation.*

The compiler uses the file path to generate unique internal names for file-local types. This naming scheme enables multiple files to declare file-local types with the same name without conflict:

- Each file containing file-local types must have a unique path within the compilation (**CS9068**). This error typically occurs with source generators that produce multiple files with the same path. To resolve this error, ensure each generated file has a distinct path.
- The file path must be convertible to UTF-8 encoding (**CS9069**). This error occurs when the file path contains characters that can't be represented in UTF-8. To resolve this error, rename the file or directory to use characters that are valid in UTF-8.

These errors most commonly affect source generator authors. For more information about using file-local types in source generators, see [file-local types](../keywords/file.md).
