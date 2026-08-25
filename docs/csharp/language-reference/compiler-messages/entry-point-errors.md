---
title: Resolve errors related to the Main method and top-level statements
description: These compiler errors and warnings indicate problems with the program entry point, including the Main method declaration, the StartupObject compiler option, and top-level statements. This article provides guidance on resolving those errors.
ai-usage: ai-assisted
f1_keywords:
  - "CS0017"
  - "CS0028"
  - "CS0402"
  - "CS1555"
  - "CS1556"
  - "CS1557"
  - "CS1558"
  - "CS1559"
  - "CS2017"
  - "CS5001"
  - "CS7022"
  - "CS8801"
  - "CS8802"
  - "CS8803"
  - "CS8805"
  - "CS8899"
  - "CS8937"
helpviewer_keywords:
  - "CS0017"
  - "CS0028"
  - "CS0402"
  - "CS1555"
  - "CS1556"
  - "CS1557"
  - "CS1558"
  - "CS1559"
  - "CS2017"
  - "CS5001"
  - "CS7022"
  - "CS8801"
  - "CS8802"
  - "CS8803"
  - "CS8805"
  - "CS8899"
  - "CS8937"
ms.date: 03/23/2026
---
# Resolve errors and warnings related to a program entry point

This article covers the following compiler errors and warnings:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error or warning for SEO purposes.
 -->
- [**CS0017**](#main-method-declaration): *Program 'output file name' has more than one entry point defined. Compile with /main to specify the type that contains the entry point.*
- [**CS0028**](#main-method-declaration): *'function declaration' has the wrong signature to be an entry point*
- [**CS0402**](#main-method-declaration): *'identifier': an entry point cannot be generic or in a generic type*
- [**CS1555**](#startupobject-compiler-option): *Could not find 'class' specified for Main method*
- [**CS1556**](#startupobject-compiler-option): *'construct' specified for Main method must be a valid class or struct*
- [**CS1557**](#startupobject-compiler-option): *Cannot use 'class' for Main method because it is in a different output file*
- [**CS1558**](#main-method-declaration): *'class' does not have a suitable static Main method*
- [**CS1559**](#startupobject-compiler-option): *Cannot use 'object' for Main method because it is imported*
- [**CS2017**](#startupobject-compiler-option): *Cannot specify /main if building a module or library*
- [**CS5001**](#main-method-declaration): *Program does not contain a static 'Main' method suitable for an entry point*
- [**CS7022**](#top-level-statements): *The entry point of the program is global code; ignoring '{0}' entry point.*
- [**CS8801**](#top-level-statements): *Cannot use local variable or local function '{0}' declared in a top-level statement in this context.*
- [**CS8802**](#top-level-statements): *Only one compilation unit can have top-level statements.*
- [**CS8803**](#top-level-statements): *Top-level statements must precede namespace and type declarations.*
- [**CS8805**](#top-level-statements): *Program using top-level statements must be an executable.*
- [**CS8899**](#main-method-declaration): *Application entry points cannot be attributed with 'UnmanagedCallersOnly'.*
- [**CS8937**](#top-level-statements): *At least one top-level statement must be non-empty.*

## `Main` method declaration

- **CS0017**: *Program 'output file name' has more than one entry point defined. Compile with /main to specify the type that contains the entry point.*
- **CS0028**: *'function declaration' has the wrong signature to be an entry point*
- **CS0402**: *'identifier': an entry point cannot be generic or in a generic type*
- **CS1558**: *'class' does not have a suitable static Main method*
- **CS5001**: *Program does not contain a static 'Main' method suitable for an entry point*
- **CS8899**: *Application entry points cannot be attributed with 'UnmanagedCallersOnly'.*

A program that compiles to an executable must contain a valid `Main` method as its entry point. For more information, see [Main() and command-line arguments](../../fundamentals/program-structure/main-command-line.md).

To correct these errors, ensure your `Main` method declaration follows these rules:

- Declare the `Main` method as `static` with a return type of `void`, `int`, `Task`, or `Task<int>`, because the runtime requires a specific signature to identify the program's entry point (**CS0028**, **CS1558**). The method can optionally accept a `string[]` parameter for command-line arguments. If you use the `async` modifier, the return type must be `Task` or `Task<int>`, and you must target [C# language version](../configure-language-version.md) 7.1 or higher.
- Move the `Main` method out of any generic type, because the runtime can't resolve a unique entry point when the containing type requires type arguments (**CS0402**).
- Remove the <xref:System.Runtime.InteropServices.UnmanagedCallersOnlyAttribute> attribute from the `Main` method, because entry points must be callable from managed code and `UnmanagedCallersOnly` restricts the method to unmanaged callers only (**CS8899**).
- When your code contains multiple `Main` methods across different types, use the [**StartupObject**](../compiler-options/advanced.md#startupobject) compiler option to specify which type contains the intended entry point (**CS0017**). Without that option, the compiler can't determine which `Main` method to use.
- Verify that your executable project defines a `Main` method with a correct signature, because a project with an [**OutputType**](../compiler-options/output.md#outputtype) of **exe** or **winexe** requires an entry point (**CS5001**, **CS1558**). The method name is case-sensitive - `main` doesn't qualify. If you don't need an executable, change the output type to **library**.

> [!NOTE]
> CS0028 is a legacy diagnostic that the current C# compiler doesn't produce. Modern versions of the compiler report **CS1558** or **CS5001** instead when the `Main` method has an invalid signature.

> [!NOTE]
> CS0017, CS0028, CS0402, CS1558, and CS5001 are reported only during **Build** or **Rebuild** operations. They don't appear as IntelliSense diagnostics while you type in the IDE.

## `StartupObject` compiler option

- **CS1555**: *Could not find 'class' specified for Main method*
- **CS1556**: *'construct' specified for Main method must be a valid class or struct*
- **CS1557**: *Cannot use 'class' for Main method because it is in a different output file*
- **CS1559**: *Cannot use 'object' for Main method because it is imported*
- **CS2017**: *Cannot specify /main if building a module or library*

The [**StartupObject**](../compiler-options/advanced.md#startupobject) compiler option (also known as `/main`) specifies which type contains the program's `Main` method when multiple types define one. For more information, see [**StartupObject**](../compiler-options/advanced.md#startupobject) and [Main() and command-line arguments](../../fundamentals/program-structure/main-command-line.md).

To correct these errors, ensure the `StartupObject` option references a valid type:

- Verify that the fully qualified class name you pass to `StartupObject` matches a type defined in the current compilation's source code. The compiler searches only the source files being compiled - not referenced assemblies - for the specified type (**CS1555**). Check for typos in the fully qualified name, including the namespace.
- Ensure the identifier you pass to `StartupObject` refers to a non-generic `class` or `struct`. The compiler requires a concrete type that can contain a valid `Main` method (**CS1556**). Interfaces, enums, delegates, and generic types aren't valid targets.
- Move the specified class into the same output file as the current compilation. The `/main` option resolves the entry point within a single output assembly and can't reference types compiled into a different output (**CS1557**).
- Ensure the specified type is defined in the current project's source code rather than in a referenced assembly. The compiler can't designate an imported type as the entry point (**CS1559**).
- Remove the `/main` option when building a library or module. Only executable projects (with an [**OutputType**](../compiler-options/output.md#outputtype) of **exe** or **winexe**) have entry points (**CS2017**). If you need an entry point, change the output type to an executable.
- Ensure the type specified by `StartupObject` declares a valid `Main` method. If the type exists but doesn't contain a suitable static `Main` method, the compiler generates [**CS1558**](#main-method-declaration). See the [`Main` method declaration](#main-method-declaration) section for the required signature.

> [!NOTE]
> CS1557 and CS1559 are legacy diagnostics that the current C# compiler doesn't produce. The scenarios that triggered these errors are no longer supported or occur too infrequently to warrant detection.

> [!NOTE]
> CS1555 and CS1556 are reported only during **Build** or **Rebuild** operations. They don't appear as IntelliSense diagnostics while you type in the IDE.

## Top-level statements

- **CS7022**: *The entry point of the program is global code; ignoring '{0}' entry point.*
- **CS8801**: *Cannot use local variable or local function '{0}' declared in a top-level statement in this context.*
- **CS8802**: *Only one compilation unit can have top-level statements.*
- **CS8803**: *Top-level statements must precede namespace and type declarations.*
- **CS8805**: *Program using top-level statements must be an executable.*
- **CS8937**: *At least one top-level statement must be non-empty.*

[Top-level statements](../../fundamentals/program-structure/top-level-statements.md) replace the explicit `Main` method as the program's entry point. For more information, see [Top-level statements](../../fundamentals/program-structure/top-level-statements.md) in the C# programming guide and the [top-level statements](~/_csharpstandard/standard/basic-concepts.md#713-using-top-level-statements) section of the C# language specification.

To correct these errors, ensure your use of top-level statements follows these rules:

- Consolidate all top-level statements into a single file, because only one compilation unit (file) can contain top-level statements (**CS8802**). Move any top-level code from other files into that single file. Restructure the remaining files so they contain only namespace and type declarations.
- Place all top-level statements before any `namespace` or `type` declarations in the file, because the compiler requires top-level statements to appear first (**CS8803**). If you have `using` directives, those directives can still precede the top-level statements.
- Include at least one statement that contains executable code, because a file with only empty statements, whitespace, or comments doesn't qualify as a valid entry point (**CS8937**). Add a statement such as a method call, variable assignment, or expression to satisfy the requirement.
- Access local variables and local functions declared in top-level statements only from within the top-level statement context itself, because those declarations are scoped to the generated entry point method and aren't visible to other files or to type members declared in the same file (**CS8801**). If you need to share state across files, declare the variable as a static field or property on a type instead.
- Set the project's [**OutputType**](../compiler-options/output.md#outputtype) to **exe**, because top-level statements define an entry point and entry points are only valid in executable projects (**CS8805**). If you're building a library, remove the top-level statements and use types and methods instead.
- Remove or rename any explicit `Main` method when top-level statements are present, because the compiler treats the top-level statements as the entry point and ignores any `Main` method, producing a warning (**CS7022**). If you intend to use an explicit `Main` method, move the top-level statement code into that method and remove the top-level statements.
