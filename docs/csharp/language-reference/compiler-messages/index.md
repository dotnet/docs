---
description: "C# Compiler Errors"
title: "Compiler messages"
ms.date: 05/19/2026
f1_keywords:
  - "CS8751"
  - "CS8771"
  - "CS8772"
helpviewer_keywords: 
  - "C# language, compiler errors"
---
# C# Compiler Errors

Some C# compiler errors have corresponding topics that explain why the error is generated, and, in some cases, how to fix the error. Use one of the following steps to see whether help is available for a particular error message.

- If you're using Visual Studio, choose the error number (for example, CS0029) in the [Output Window](/visualstudio/ide/reference/output-window), and then choose the F1 key.
- Type the error number in the *Filter by title* box in the table of contents.
  
If none of these steps leads to information about your error, go to the end of this page, and send feedback that includes the number or text of the error.

For information about how to configure error and warning options in C#, see [C# compiler options](../compiler-options/index.md) or the Visual Studio [Build Page, Project Designer (C#)](/visualstudio/ide/reference/build-page-project-designer-csharp).

[!INCLUDE[note_settings_general](~/includes/note-settings-general-md.md)]

## Internal compiler error (CS8751)

- **CS8751**: *Internal error in the C# compiler.*

CS8751 indicates an internal compiler error. Your code exposed a bug in the compiler itself, not in your source code. If you encounter this error, [file an issue in the Roslyn repository](https://github.com/dotnet/roslyn/issues/new/choose) with a minimal reproduction so the compiler team can investigate and fix the problem.

## Command-line errors (CS8771, CS8772)

- **CS8771**: *Output directory could not be determined*
- **CS8772**: *stdin argument '-' is specified, but input has not been redirected from the standard input stream.*

These errors indicate problems with compiler invocation rather than source code issues.

- Ensure the project or command line specifies a valid output directory (**CS8771**). This error typically occurs when the build system can't resolve the output path. Verify the `OutputPath` or `OutDir` property in your project file, or pass a valid `/out:` argument to the compiler.
- Redirect standard input when using the `-` (stdin) argument (**CS8772**). The compiler expects piped input when you pass `-` as the source file argument. Use a pipeline (for example, `cat file.cs | csc -`) or remove the `-` argument and pass the source file directly.

## See also

- [C# Compiler Options](../compiler-options/index.md)
- [Build Page, Project Designer (C#)](/visualstudio/ide/reference/build-page-project-designer-csharp)
- [**WarningLevel** (C# Compiler Options)](../compiler-options/errors-warnings.md#warninglevel)
- [**NoWarn** (C# Compiler Options)](../compiler-options/errors-warnings.md#nowarn)
