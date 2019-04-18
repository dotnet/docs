---
title: "-deterministic"
ms.date: 04/11/2018
helpviewer_keywords:
  - "deterministic compiler option [Visual Basic]"
  - "-deterministic compiler option [Visual Basic]"
  - "-deterministic compiler option [Visual Basic]"
---
# -deterministic

Causes the compiler to produce an assembly whose byte-for-byte output is identical across compilations for identical inputs.

## Syntax

```
-deterministic
```

## Remarks

By default, compiler output from a given set of inputs is unique, since the compiler adds a timestamp and a GUID that is generated from random numbers. You use the `-deterministic` option to produce a *deterministic assembly*, one whose binary content is identical across compilations as long as the input remains the same.

The compiler considers the following inputs for the purpose of determinism:

- The sequence of command-line parameters.
- The contents of the compiler's .rsp response file.
- The precise version of the compiler used, and its referenced assemblies.
- The current directory path.
- The binary contents of all files explicitly passed to the compiler either directly or indirectly, including:
  - Source files
  - Referenced assemblies
  - Referenced modules
  - Resources
  - The strong name key file
  - @ response files
  - Analyzers
  - Rulesets
  - Additional files that may be used by analyzers
- The current culture (for the language in which diagnostics and exception messages are produced).
- The default encoding (or the current code page) if the encoding is not specified.
- The existence, non-existence, and contents of files on the compiler's search paths (specified, for example, by `/lib` or `/recurse`).
- The CLR platform on which the compiler is run.
- The value of `%LIBPATH%`, which can affect analyzer dependency loading.

When sources are publicly available, deterministic compilation can be used for establishing whether a binary is compiled from a trusted source. It can also be useful in a continuous build system for determining whether build steps that are dependent on changes to a binary need to be executed.

## See also

- [Visual Basic Command-Line Compiler](../../../visual-basic/reference/command-line-compiler/index.md)
- [Sample Compilation Command Lines](../../../visual-basic/reference/command-line-compiler/sample-compilation-command-lines.md)
