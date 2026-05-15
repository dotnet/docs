---
title: Errors and warnings associated with source generators and interceptors
description: You might see these errors and warnings when code is compiled with source generators and interceptors. They indicate some condition where the compiler can't run the source generator, or the generate code isn't compilable.
f1_keywords:
  - "CS8032"
  - "CS8033"
  - "CS8034"
  - "CS8040"
  - "CS8700"
  - "CS8784"
  - "CS8785"
  - "CS8850"
  - "CS9057"
  - "CS9067"
  - "CS9137"
  - "CS9138"
  - "CS9139"
  - "CS9140"
  - "CS9141"
  - "CS9142"
  - "CS9143"
  - "CS9144"
  - "CS9145"
  - "CS9146"
  - "CS9147"
  - "CS9148"
  - "CS9149"
  - "CS9150"
  - "CS9151"
  - "CS9152"
  - "CS9153"
  - "CS9154"
  - "CS9155"
  - "CS9156"
  - "CS9157"
  - "CS9158"
  - "CS9159"
  - "CS9160"
  - "CS9161"
  - "CS9177"
  - "CS9178"
  - "CS9206"
  - "CS9207"
  - "CS9231"
  - "CS9232"
  - "CS9233"
  - "CS9234"
  - "CS9235"
  - "CS9270"
helpviewer_keywords:
  - "CS8032"
  - "CS8033"
  - "CS8034"
  - "CS8040"
  - "CS8700"
  - "CS8784"
  - "CS8785"
  - "CS8850"
  - "CS9057"
  - "CS9067"
  - "CS9137"
  - "CS9138"
  - "CS9139"
  - "CS9140"
  - "CS9141"
  - "CS9142"
  - "CS9143"
  - "CS9144"
  - "CS9145"
  - "CS9146"
  - "CS9147"
  - "CS9148"
  - "CS9149"
  - "CS9150"
  - "CS9151"
  - "CS9152"
  - "CS9153"
  - "CS9154"
  - "CS9155"
  - "CS9156"
  - "CS9157"
  - "CS9158"
  - "CS9159"
  - "CS9160"
  - "CS9161"
  - "CS9177"
  - "CS9178"
  - "CS9206"
  - "CS9207"
  - "CS9231"
  - "CS9232"
  - "CS9233"
  - "CS9234"
  - "CS9235"
  - "CS9270"
ms.date: 01/27/2026
---
# Errors and warnings associated with source generators and interceptors

The following errors occur when the compiler loads source generators or interceptors during compilation:

- [**CS9137**](#interceptors-are-experimental): *The 'interceptors' feature is not enabled in this namespace. Add `<Features>InterceptorsPreview</Features>` to your project.*
- [**CS9138**](#incorrect-interceptor-declaration): *Method 'method' cannot be used as an interceptor because its containing type has type parameters.*
- [**CS9139**](#incorrect-mapping): *Cannot intercept: compilation does not contain a file with path.*
- [**CS9140**](#incorrect-mapping): *Cannot intercept: compilation does not contain a file with path 'path'. Did you mean to use path 'candidatePath'?*
- [**CS9141**](#incorrect-mapping): *The provided line and character number does not refer to an interceptable method name, but rather to token 'token'.*
- [**CS9142**](#incorrect-mapping): *The given file has `n` lines, which is fewer than the provided line number `m`.*
- [**CS9143**](#incorrect-mapping): *The given line is `c` characters long, which is fewer than the provided character number `n`.*
- [**CS9144**](#signature-mismatch): *Cannot intercept method `M` with interceptor `V` because the signatures do not match.*
- [**CS9145**](#incorrect-mapping): *Cannot intercept: Path is unmapped. Expected mapped path.*
- [**CS9146**](#incorrect-interceptor-declaration): *An interceptor method must be an ordinary member method.*
- [**CS9147**](#incorrect-mapping): *The provided line and character number does not refer to the start of token 'token'. Did you mean to use line 'n' and character 'c'?*
- [**CS9148**](#signature-mismatch): *Interceptor must have a `this` parameter matching parameter.*
- [**CS9149**](#signature-mismatch): *Interceptor must not have a `this` parameter because method does not have a `this` parameter.*
- [**CS9150**](#incorrect-mapping): *Interceptor cannot have a `null` file path.*
- [**CS9151**](#incorrect-interceptor-declaration): *Possible method name `M` cannot be intercepted because it is not being invoked.*
- [**CS9152**](#incorrect-interceptor-declaration): *Cannot intercept a call in file with path 'path' because multiple files in the compilation have this path.*
- [**CS9153**](#incorrect-interceptor-declaration): *The indicated call is intercepted multiple times.*
- [**CS9155**](#signature-mismatch): *Cannot intercept call with `M` because it is not accessible within `V`.*
- [**CS9156**](#signature-mismatch): *Cannot intercept call to `M` with `V` because of a difference in 'scoped' modifiers or `[UnscopedRef]` attributes.*
- [**CS9157**](#incorrect-mapping): *Line and character numbers provided to `InterceptsLocationAttribute` must be positive.*
- [**CS9160**](#incorrect-interceptor-declaration): *A nameof operator cannot be intercepted.*
- [**CS9161**](#incorrect-interceptor-declaration): *An interceptor cannot be marked with `UnmanagedCallersOnlyAttribute`.*
- [**CS9177**](#signature-mismatch): *Method 'method' must be non-generic or have arity 'arity' to match 'target'.*
- [**CS9178**](#signature-mismatch): *Method 'method' must be non-generic to match 'target'.*
- [**CS9206**](#incorrect-interceptor-declaration): *An interceptor cannot be declared in the global namespace.*
- [**CS9207**](#incorrect-interceptor-declaration): *Cannot intercept 'method' because it is not an invocation of an ordinary member method.*
- [**CS9231**](#incorrect-interceptor-declaration): *The data argument to InterceptsLocationAttribute is not in the correct format.*
- [**CS9232**](#incorrect-interceptor-declaration): *Version 'version' of the interceptors format is not supported. The latest supported version is '1'.*
- [**CS9233**](#incorrect-interceptor-declaration): *Cannot intercept a call in file 'file' because it is duplicated elsewhere in the compilation.*
- [**CS9234**](#incorrect-interceptor-declaration): *Cannot intercept a call in file 'file' because a matching file was not found in the compilation.*
- [**CS9235**](#incorrect-interceptor-declaration): *The data argument to InterceptsLocationAttribute refers to an invalid position in file 'file'.*

The following warnings occur when the compiler loads source generators or interceptors during compilation:

- [**CS8032**](#analyzer-and-source-generator-compatibility): *An instance of analyzer 'analyzer' cannot be created from 'assembly' : 'reason'.*
- [**CS8033**](#analyzer-and-source-generator-compatibility): *The assembly 'assembly' does not contain any analyzers.*
- [**CS8034**](#analyzer-and-source-generator-compatibility): *Unable to load Analyzer assembly 'assembly' : 'reason'*
- [**CS8040**](#analyzer-and-source-generator-compatibility): *Skipping some types in analyzer assembly 'assembly' due to a ReflectionTypeLoadException : 'exception'.*
- [**CS8700**](#analyzer-and-source-generator-compatibility): *Multiple analyzer config files cannot be in the same directory ('directory').*
- [**CS8784**](#source-generator-failures): *Generator 'generator' failed to initialize. It will not contribute to the output and compilation errors may occur as a result. Exception was of type 'exception' with message 'message'.*
- [**CS8785**](#source-generator-failures): *Generator 'generator' failed to generate source. It will not contribute to the output and compilation errors may occur as a result. Exception was of type 'exception' with message 'message'.*
- [**CS8850**](#analyzer-and-source-generator-compatibility): *The assembly 'assembly' containing type 'type' references .NET Framework, which is not supported.*
- [**CS9057**](#analyzer-and-source-generator-compatibility): *Analyzer assembly 'assembly' cannot be used because it references version 'version' of the compiler, which is newer than the currently running version 'currentVersion'.*
- [**CS9067**](#analyzer-and-source-generator-compatibility): *Analyzer reference 'reference' specified multiple times*
- [**CS9154**](#signature-mismatch): *Intercepting a call to `M` with interceptor `V`, but the signatures do not match.*
- [**CS9158**](#signature-mismatch): *Nullability of reference types in return type doesn't match interceptable method.*
- [**CS9159**](#signature-mismatch): *Nullability of reference types in type of parameter doesn't match interceptable method.*
- [**CS9270**](#signature-mismatch): *'`InterceptsLocationAttribute(string, int, int)`' is not supported. Move to 'InterceptableLocation'-based generation of these attributes instead. [(https://github.com/dotnet/roslyn/issues/72133)](https://github.com/dotnet/roslyn/issues/72133)*

These errors and warnings follow these themes:

## Source generator failures

- **CS8784**: *Generator 'generator' failed to initialize. It will not contribute to the output and compilation errors may occur as a result. Exception was of type 'exception' with message 'message'.*
- **CS8785**: *Generator 'generator' failed to generate source. It will not contribute to the output and compilation errors may occur as a result. Exception was of type 'exception' with message 'message'.*

These warnings indicate that a source generator threw an unhandled exception during compilation. Source generators run as part of the build pipeline, and a failure prevents the generator from contributing its output to the compilation. For more information about implementing source generators, see [Source Generators](../../roslyn-sdk/source-generators-overview.md).

To correct these warnings, follow this guidance:

- Examine the full exception details in the build output to identify the root cause (**CS8784**, **CS8785**). The warning message includes the exception type, message, and stack trace, which can help you or the generator author diagnose the failure.
- Ensure all required dependencies for the source generator are available in the project (**CS8784**). Initialization failures often occur when the generator can't locate a required assembly or resource during startup. Verify that the generator's NuGet package is correctly installed and all transitive dependencies are resolved.
- Report the failure to the source generator's maintainer if the exception originates in third-party generator code (**CS8784**, **CS8785**). Include the full exception details from the build output in your bug report.
- If you authored the source generator, add exception handling within your `Initialize` or `Execute` methods to catch and report errors gracefully (**CS8784**, **CS8785**).

## Analyzer and source generator compatibility

- **CS8032**: *An instance of analyzer 'analyzer' cannot be created from 'assembly' : 'reason'.*
- **CS8033**: *The assembly 'assembly' does not contain any analyzers.*
- **CS8034**: *Unable to load Analyzer assembly 'assembly' : 'reason'*
- **CS8040**: *Skipping some types in analyzer assembly 'assembly' due to a ReflectionTypeLoadException : 'exception'.*
- **CS8700**: *Multiple analyzer config files cannot be in the same directory ('directory').*
- **CS8850**: *The assembly 'assembly' containing type 'type' references .NET Framework, which is not supported.*
- **CS9057**: *Analyzer assembly 'assembly' cannot be used because it references version 'version' of the compiler, which is newer than the currently running version 'currentVersion'.*
- **CS9067**: *Analyzer reference 'reference' specified multiple times*

These warnings and errors indicate problems with loading, instantiating, or configuring analyzer and source generator assemblies. Because source generators load as analyzer assemblies, these diagnostics apply to both analyzers and source generators.

To correct these problems, follow this guidance:

- Upgrade your .NET SDK or compiler version to match the analyzer's requirements, or use an older version of the analyzer package that is compatible with your current compiler (**CS9057**). This error occurs when an analyzer assembly targets a newer Roslyn API version than the running compiler provides.
- Remove duplicate analyzer references from your project (**CS9067**). Check your project file for repeated `<Analyzer>` or `<PackageReference>` elements that include the same analyzer assembly through different paths. Transitive package dependencies can also cause duplicates.
- Verify the analyzer assembly is a valid .NET assembly and isn't corrupted (**CS8034**). If the assembly can't be loaded at all, ensure the file exists at the referenced path and was built for a compatible target framework. Rebuild or reinstall the NuGet package to get a fresh copy.
- Ensure the analyzer type has a public parameterless constructor (**CS8032**). The compiler instantiates analyzers by calling their default constructor. If the constructor throws an exception or requires parameters, the analyzer can't be created.
- Verify the referenced assembly actually exports analyzer or source generator types (**CS8033**). An assembly referenced as an analyzer must contain types that implement `DiagnosticAnalyzer` or `ISourceGenerator`/`IIncrementalGenerator`. If the assembly is a runtime dependency rather than an analyzer, reference it as a normal project or package reference instead.
- Resolve type loading problems in the analyzer assembly by ensuring all its dependencies are available (**CS8040**). A `ReflectionTypeLoadException` typically means the assembly references types from other assemblies that can't be found. Make sure all required dependencies are included in the analyzer's NuGet package.
- Ensure analyzer config files (`.editorconfig` or `.globalconfig`) are unique per directory (**CS8700**). The compiler doesn't allow multiple analyzer configuration files in the same directory because the precedence rules would be ambiguous. Merge the files or remove the duplicate.
- Update the analyzer or source generator to target .NET Standard or modern .NET instead of .NET Framework (**CS8850**). Assemblies that reference .NET Framework aren't supported in the modern .NET compiler toolchain. If you maintain the analyzer, retarget it to `netstandard2.0`. If it's a third-party package, upgrade to a version that supports modern .NET.

## Interceptors are experimental

- **CS9137**: *The 'interceptors' feature is not enabled in this namespace. Add `<Features>InterceptorsPreview</Features>` to your project.*

To use interceptors, add the `<Features>InterceptorsPreview</Features>` element to your project file within a `<PropertyGroup>` section (**CS9137**). Interceptors are an experimental feature and aren't enabled by default. This explicit opt-in is required because the interceptors feature is subject to breaking changes or removal in future releases. The compiler needs confirmation that you understand the risks before allowing its use. For more information about interceptors and their capabilities, see [Interceptors](../../whats-new/csharp-12.md#interceptors) in the C# 12 features documentation.

## Signature mismatch

The following errors and warnings indicate a mismatch between the interceptor method and the interceptable method.

- **CS9144**: *Cannot intercept method `M` with interceptor `V` because the signatures do not match.*
- **CS9148**: *Interceptor must have a `this` parameter matching parameter.*
- **CS9149**: *Interceptor must not have a `this` parameter because method does not have a `this` parameter.*
- **CS9155**: *Cannot intercept call with `M` because it is not accessible within `V`.*
- **CS9156**: *Cannot intercept call to `M` with `V` because of a difference in 'scoped' modifiers or `[UnscopedRef]` attributes.*
- **CS9177**: *Method 'method' must be non-generic or have arity 'arity' to match 'target'.*
- **CS9178**: *Method 'method' must be non-generic to match 'target'.*

In addition, the following warnings indicate a mismatch in the signatures of the interceptor and the interceptable method:

- **CS9154**: *Intercepting a call to `M` with interceptor `V`, but the signatures do not match.*
- **CS9158**: *Nullability of reference types in return type doesn't match interceptable method.*
- **CS9159**: *Nullability of reference types in type of parameter doesn't match interceptable method.*
- **CS9270**: *'`InterceptsLocationAttribute(string, int, int)`' is not supported. Move to 'InterceptableLocation'-based generation of these attributes instead. [(https://github.com/dotnet/roslyn/issues/72133)](https://github.com/dotnet/roslyn/issues/72133)*

To correct these issues, ensure your interceptor method matches the interceptable method's signature and access requirements:

- Ensure the interceptor method signature exactly matches the interceptable method (**CS9144**, **CS9154**). The parameter types, modifiers, order, and return type must be identical. Review both method declarations and align their signatures.
- Add a `this` parameter to your interceptor when the interceptable method is an instance method (**CS9148**), or remove the `this` parameter when the interceptable method is static (**CS9149**). Instance interceptors require a `this` parameter of the declaring type, while static interceptors must not have one.
- Declare your interceptor in a location where the interceptable method is accessible (**CS9155**). If the interceptable method is `internal`, the interceptor must be in the same assembly. If it's `private`, the interceptor must be in the same type or a nested type.
- Match the [`scoped`](../statements/declarations.md#scoped-ref) modifiers and [`[UnscopedRef]`](../attributes/general.md#unscopedref-attribute) attributes on corresponding `ref` parameters (**CS9156**). Each `ref` parameter in the interceptor must have the same lifetime annotations as the corresponding parameter in the interceptable method to ensure memory safety.
- Ensure both methods have matching generic arity (**CS9177**, **CS9178**). If the interceptable method is non-generic, the interceptor must also be non-generic. If the interceptable method has type parameters, the interceptor must have the same number of type parameters with compatible constraints.
- Match the nullability annotations in the return type (**CS9158**) and parameter types (**CS9159**). Enable nullable reference types in your project and ensure the interceptor's nullability annotations match the interceptable method exactly to maintain type safety.
- Use the updated `InterceptableLocation`-based generation for `InterceptsLocationAttribute` instead of the deprecated `(string, int, int)` constructor (**CS9270**). The newer format provides better tooling support and compile-time validation. See the [GitHub issue](https://github.com/dotnet/roslyn/issues/72133) for migration guidance.

## Incorrect mapping

Interceptors require a source mapping that maps the interceptable method and the interceptor method. The following errors indicate an issue with the mapping:

- **CS9139**: *Cannot intercept: compilation does not contain a file with path.*
- **CS9140**: *Cannot intercept: compilation does not contain a file with path 'path'. Did you mean to use path 'candidatePath'?*
- **CS9141**: *The provided line and character number does not refer to an interceptable method name, but rather to token 'token'.*
- **CS9142**: *The given file has `n` lines, which is fewer than the provided line number `m`.*
- **CS9143**: *The given line is `c` characters long, which is fewer than the provided character number `n`.*
- **CS9145**: *Cannot intercept: Path is unmapped. Expected mapped path.*
- **CS9147**: *The provided line and character number does not refer to the start of token 'token'. Did you mean to use line 'n' and character 'c'?*
- **CS9150**: *Interceptor cannot have a `null` file path.*
- **CS9157**: *Line and character numbers provided to `InterceptsLocationAttribute` must be positive.*

To correct mapping errors, ensure your `InterceptsLocationAttribute` contains valid file paths and accurate position information:

- Verify the file path matches a file in your compilation exactly (**CS9139**, **CS9140**). Use the exact path as it appears in your project, including correct casing and directory separators. If the compiler suggests an alternative path, update your attribute to use that path.
- Use mapped file paths when working with source generators that transform file paths (**CS9145**). Source generators often remap paths for generated files, and you must use the mapped path that the compiler recognizes, not the original source path.
- Ensure the file path isn't `null` in your `InterceptsLocationAttribute` (**CS9150**). Every interception must specify a valid, non-null file path that identifies the source file containing the call to intercept.
- Provide positive, 1-based line and character numbers (**CS9157**). Line numbers and character positions must start at 1, not 0. Verify your source generator uses 1-based indexing when calculating positions.
- Point to the exact start of the method name token (**CS9141**, **CS9147**). The line and character numbers must identify the first character of the method name in the invocation, not whitespace, operators, or other tokens. If the compiler suggests alternative coordinates, use those to target the correct token start.
- Stay within the file's bounds (**CS9142**, **CS9143**). Verify the line number doesn't exceed the total line count and the character number doesn't exceed the line length. Recalculate positions if the source file has changed since the attribute was generated.

## Incorrect interceptor declaration

The following errors indicate problems with interceptor declarations, including issues with the `InterceptsLocationAttribute` format or violations of interceptor rules:

- **CS9138**: *Method 'method' cannot be used as an interceptor because its containing type has type parameters.*
- **CS9146**: *An interceptor method must be an ordinary member method.*
- **CS9151**: *Possible method name `M` cannot be intercepted because it is not being invoked.*
- **CS9152**: *Cannot intercept a call in file with path 'path' because multiple files in the compilation have this path.*
- **CS9153**: *The indicated call is intercepted multiple times.*
- **CS9160**: *A nameof operator cannot be intercepted.*
- **CS9161**: *An interceptor cannot be marked with `UnmanagedCallersOnlyAttribute`.*
- **CS9206**: *An interceptor cannot be declared in the global namespace.*
- **CS9207**: *Cannot intercept 'method' because it is not an invocation of an ordinary member method.*
- **CS9231**: *The data argument to InterceptsLocationAttribute is not in the correct format.*
- **CS9232**: *Version 'version' of the interceptors format is not supported. The latest supported version is '1'.*
- **CS9233**: *Cannot intercept a call in file 'file' because it is duplicated elsewhere in the compilation.*
- **CS9234**: *Cannot intercept a call in file 'file' because a matching file was not found in the compilation.*
- **CS9235**: *The data argument to InterceptsLocationAttribute refers to an invalid position in file 'file'.*

To correct interceptor declaration errors, follow these rules for valid interceptor declarations and `InterceptsLocationAttribute` usage:

- Format the `InterceptsLocationAttribute` data argument correctly (**CS9231**). The attribute requires specifically structured data that encodes file path and position information. Ensure your source generator produces data in the expected format matching the current interceptors specification.
- Use version '1' in your `InterceptsLocationAttribute` (**CS9232**), because it's the latest supported version. Update your source generator to output version 1 format attributes rather than unsupported version numbers.
- Ensure unique file paths in your compilation (**CS9233**, **CS9234**). When the compilation contains duplicate file paths, rename or reorganize files to make each path unique. Verify that the file path in the attribute matches a file actually included in the compilation.
- Validate position data points to valid code locations (**CS9235**). The line and character numbers must reference a valid interception point within the specified file. Regenerate the attribute if the source file changed or if the position falls outside the file's bounds.
- Declare non-generic interceptor methods in non-generic types (**CS9138**). Interceptors can't be declared in types that have type parameters. If you need to intercept a generic method, create a non-generic interceptor in a non-generic containing type that works with the specific constructed type.
- Make interceptors ordinary member methods (**CS9146**). Interceptors can't be operators, constructors, finalizers, properties, or indexers. Declare your interceptor as a regular static or instance method.
- Intercept actual method invocations, not expressions (**CS9151**, **CS9207**). You can only intercept calls to ordinary member methods that are being invoked. You can't intercept method groups, delegates, or methods referenced without being called. Ensure the interceptable location identifies an actual method call.
- Remove duplicate interception attempts (**CS9153**). Each method call can only be intercepted once. If multiple `InterceptsLocationAttribute` instances target the same call, remove all but one to resolve the ambiguity.
- Don't intercept `nameof` operators (**CS9160**). The `nameof` operator doesn't invoke methods at runtime, so it can't be intercepted. Only intercept actual method calls that execute at runtime.
- Remove `UnmanagedCallersOnlyAttribute` from interceptors (**CS9161**). Interceptors must be callable from managed code and can't be marked with `UnmanagedCallersOnlyAttribute`. Remove the attribute from your interceptor method declaration.
- Declare interceptors within a namespace (**CS9206**). Interceptors can't be declared in the global namespace and must be contained within at least one namespace declaration. Wrap your interceptor class in a namespace.
- Resolve duplicate file paths at the compilation level (**CS9152**). When multiple files share the same path in the compilation, the compiler can't determine which file to intercept. Ensure build configuration produces unique file paths or use a different organization strategy for your source files.
