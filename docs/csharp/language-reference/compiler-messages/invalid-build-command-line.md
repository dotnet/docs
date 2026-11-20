---
title: "Resolve errors and warnings related to compiler options and build configuration"
description: "This article helps you diagnose and correct compiler errors and warnings related to compiler options, Roslyn API options, build configuration, and compiler invocation problems"
f1_keywords:
  - "CS0006"
  - "CS0007"
  - "CS0016"
  - "CS1564"
  - "CS1616"
  - "CS1668"
  - "CS1719"
  - "CS1773"
  - "CS2007"
  - "CS2008"
  - "CS2011"
  - "CS2019"
  - "CS2023"
  - "CS2029"
  - "CS2032"
  - "CS2036"
  - "CS2038"
  - "CS2039"
  - "CS2040"
  - "CS2041"
  - "CS2042"
  - "CS2043"
  - "CS2044"
  - "CS2045"
  - "CS2046"
  - "CS3012"
  - "CS3013"
  - "CS7038"
  - "CS7089"
  - "CS7093"
  - "CS8001"
  - "CS8035"
  - "CS8101"
  - "CS8111"
  - "CS8113"
  - "CS8190"
  - "CS8191"
  - "CS8202"
  - "CS8308"
  - "CS8309"
  - "CS8357"
  - "CS8751"
  - "CS8771"
  - "CS8772"
  - "CS9400" # ERR_BadCompilationOptionValueAccepted: Invalid 'option' value: 'value'. Accepted values are listed.
helpviewer_keywords:
  - "CS0006"
  - "CS0007"
  - "CS0016"
  - "CS1564"
  - "CS1616"
  - "CS1668"
  - "CS1719"
  - "CS1773"
  - "CS2007"
  - "CS2008"
  - "CS2011"
  - "CS2019"
  - "CS2023"
  - "CS2029"
  - "CS2032"
  - "CS2036"
  - "CS2038"
  - "CS2039"
  - "CS2040"
  - "CS2041"
  - "CS2042"
  - "CS2043"
  - "CS2044"
  - "CS2045"
  - "CS2046"
  - "CS3012"
  - "CS3013"
  - "CS7038"
  - "CS7089"
  - "CS7093"
  - "CS8001"
  - "CS8035"
  - "CS8101"
  - "CS8111"
  - "CS8113"
  - "CS8190"
  - "CS8191"
  - "CS8202"
  - "CS8308"
  - "CS8309"
  - "CS8357"
  - "CS8751"
  - "CS8771"
  - "CS8772"
  - "CS9400"
ms.date: 11/05/2026
ai-usage: ai-assisted
---
# Resolve errors and warnings for compiler options and build configuration

This article covers the following compiler errors and warnings:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error or warning for SEO purposes.
 -->
- [**CS0006**](#input-and-output-file-errors): *Metadata file 'file' could not be found*
- [**CS0007**](#compiler-infrastructure-errors): *Unexpected common language runtime initialization error — 'description'*
- [**CS0016**](#input-and-output-file-errors): *Could not write to output file 'file' -- 'reason'*
- [**CS1564**](#conflicting-or-missing-options): *Conflicting options specified: Win32 resource file; Win32 manifest*
- [**CS1616**](#conflicting-or-missing-options): *Option 'option' overrides attribute 'attribute' given in a source file or added module*
- [**CS1668**](#input-and-output-file-errors): *Invalid search path 'path' specified in 'option' -- 'reason'*
- [**CS1719**](#input-and-output-file-errors): *Error opening Win32 resource file 'file' -- 'reason'*
- [**CS1773**](#invalid-option-values): *Invalid version value for /subsystemversion. The version must be 6.02 or greater for ARM or AppContainerExe, and 4.00 or greater otherwise*
- [**CS2007**](#correct-unrecognized-or-ignored-switches): *Unrecognized option: 'option'*
- [**CS2008**](#input-and-output-file-errors): *No source files specified.*
- [**CS2011**](#validate-configuration-and-response-files): *Error opening response file 'file'*
- [**CS2019**](#invalid-option-values): *Invalid target type for /target: must specify 'exe', 'winexe', 'library', or 'module'*
- [**CS2023**](#correct-unrecognized-or-ignored-switches): *Ignoring /noconfig option because it was specified in a response file*
- [**CS2029**](#invalid-option-values): *Invalid name for a preprocessing symbol; 'identifier' is not a valid identifier*
- [**CS2032**](#invalid-option-values): *Character 'character' is not allowed on the command-line or in response files*
- [**CS2036**](#conflicting-or-missing-options): *The /pdb option requires that the /debug option also be used*
- [**CS2038**](#invalid-option-values): *The language name 'name' is invalid.*
- [**CS2039**](#invalid-option-values): *Command-line syntax error: Invalid Guid format 'value' for option 'option'*
- [**CS2040**](#invalid-option-values): *Command-line syntax error: Missing Guid for option 'option'*
- [**CS2041**](#invalid-option-values): *Invalid output name: name*
- [**CS2042**](#invalid-option-values): *Invalid debug information format: format*
- [**CS2043**](#invalid-option-values): *'id#' syntax is no longer supported. Use '$id' instead.*
- [**CS2044**](#conflicting-or-missing-options): */sourcelink switch is only supported when emitting PDB.*
- [**CS2045**](#conflicting-or-missing-options): */embed switch is only supported when emitting a PDB.*
- [**CS2046**](#invalid-option-values): *Command-line syntax error: 'value' is not a valid value for the 'option' option. The value must be of the form 'format'.*
- [**CS3012**](#module-and-assembly-configuration): *You must specify the CLSCompliant attribute on the assembly, not the module, to enable CLS compliance checking*
- [**CS3013**](#module-and-assembly-configuration): *Added modules must be marked with the CLSCompliant attribute to match the assembly*
- [**CS7038**](#compiler-infrastructure-errors): *Failed to emit module 'module': error*
- [**CS7089**](#validate-configuration-and-response-files): *AppConfigPath must be absolute.*
- [**CS7093**](#validate-configuration-and-response-files): *Cannot read config file 'file' -- 'reason'*
- [**CS8001**](#correct-unrecognized-or-ignored-switches): *The command line switch 'switch' is not yet implemented and was ignored.*
- [**CS8035**](#validate-configuration-and-response-files): *Error reading ruleset file path - reason*
- [**CS8101**](#invalid-option-values): *The pathmap option was incorrectly formatted.*
- [**CS8111**](#instrumentation-and-pdb-options): *Invalid instrumentation kind: instrumentation kind*
- [**CS8113**](#instrumentation-and-pdb-options): *Invalid hash algorithm name: 'hash algorithm name'*
- [**CS8190**](#parse-and-documentation-api-options): *Provided source code kind is unsupported or invalid: 'source code kind'*
- [**CS8191**](#parse-and-documentation-api-options): *Provided documentation mode is unsupported or invalid: 'documentation mode'.*
- [**CS8202**](#public-signing-and-reference-assembly-output): *Public signing is not supported for netmodules.*
- [**CS8308**](#public-signing-and-reference-assembly-output): *Do not use refout when using refonly.*
- [**CS8309**](#public-signing-and-reference-assembly-output): *Cannot compile net modules when using /refout or /refonly.*
- [**CS8357**](#deterministic-assembly-versions): *The specified version string 'version string' contains wildcards, which are not compatible with determinism. Either remove wildcards from the version string, or disable determinism for this compilation*
- [**CS8751**](#compiler-infrastructure-errors): *Internal error in the C# compiler.*
- [**CS8771**](#conflicting-or-missing-options): *Output directory could not be determined*
- [**CS8772**](#invalid-option-values): *stdin argument '-' is specified, but input has not been redirected from the standard input stream.*
- [**CS9400**](#invalid-option-values): *Invalid 'option' value: 'value'. Accepted values are: value1, value2, ...*

## Input and output file errors

- **CS0006**: *Metadata file 'file' could not be found*
- **CS0016**: *Could not write to output file 'file' -- 'reason'*
- **CS1668**: *Invalid search path 'path' specified in 'option' -- 'reason'*
- **CS1719**: *Error opening Win32 resource file 'file' -- 'reason'*
- **CS2008**: *No source files specified.*

These errors indicate that the compiler can't find, read, or write files needed for compilation. For the full list of file-related compiler options, see [C# compiler options - Inputs](../compiler-options/inputs.md) and [C# compiler options - Resources](../compiler-options/resources.md).

- Verify the path you pass to [**References**](../compiler-options/inputs.md#references) or related options points to an existing assembly (**CS0006**). This error typically occurs when an assembly reference in the project file or command line specifies a path that doesn't exist. Check for typos, ensure the referenced project is built, and confirm the file isn't moved or deleted.
- Check the output path to make sure it exists and is writable, and ensure no process currently has a lock on the file (**CS0016**). For example, ensure your executable isn't running when you attempt to build. If a previously built file is already at the location, verify that it isn't read-only.
- Verify that the path you supply to [**AdditionalLibPaths**](../compiler-options/advanced.md#additionallibpaths) or the LIB environment variable exists and is accessible (**CS1668**). The error message in single quotation marks contains the operating system error that explains why the path is invalid.
- Correct the problem described in the error reason for the Win32 resource file (**CS1719**). The most common causes are "file not found" (verify the path) or "access denied" (check file permissions).
- Pass at least one source-code file to the compiler (**CS2008**). This error occurs when you specify compiler options but don't provide any `.cs` files as input.

## Invalid option values

- **CS1773**: *Invalid version value for /subsystemversion. The version must be 6.02 or greater for ARM or AppContainerExe, and 4.00 or greater otherwise*
- **CS2019**: *Invalid target type for /target: must specify 'exe', 'winexe', 'library', or 'module'*
- **CS2029**: *Invalid name for a preprocessing symbol; 'identifier' is not a valid identifier*
- **CS2032**: *Character 'character' is not allowed on the command-line or in response files*
- **CS2038**: *The language name 'name' is invalid.*
- **CS2039**: *Command-line syntax error: Invalid Guid format 'value' for option 'option'*
- **CS2040**: *Command-line syntax error: Missing Guid for option 'option'*
- **CS2041**: *Invalid output name: name*
- **CS2042**: *Invalid debug information format: format*
- **CS2043**: *'id#' syntax is no longer supported. Use '$id' instead.*
- **CS2046**: *Command-line syntax error: 'value' is not a valid value for the 'option' option. The value must be of the form 'format'.*
- **CS8101**: *The pathmap option was incorrectly formatted.*
- **CS8772**: *stdin argument '-' is specified, but input has not been redirected from the standard input stream.*
- **CS9400**: *Invalid 'option' value: 'value'. Accepted values are: value1, value2, ...*

These errors indicate that a value you passed to a compiler option is malformed or outside the allowed set of values. For the full list of compiler options, see [C# Compiler Options](../compiler-options/index.md).

- Supply a valid version number for the [**SubsystemVersion**](../compiler-options/advanced.md#subsystemversion) option (**CS1773**). ARM and AppContainerExe targets require version 6.02 or greater; other targets require 4.00 or greater.
- Use one of the valid [**OutputType**](../compiler-options/output.md#outputtype) values: `exe`, `winexe`, `library`, or `module` (**CS2019**). The compiler rejects any other value for the **/target** option.
- Ensure preprocessing symbols you pass to [**DefineConstants**](../compiler-options/language.md#defineconstants) are valid C# identifiers (**CS2029**). Identifiers must start with a letter or underscore and contain only letters, digits, or underscores. You can't suppress this warning by using the [**NoWarn**](../compiler-options/errors-warnings.md#nowarn) option.
- Remove ASCII control characters (range 0–31) and the pipe (`|`) character from command-line arguments and [response files](../compiler-options/miscellaneous.md#responsefiles) (**CS2032**). The command-line processor and IDE typically filter these characters, so this error most commonly appears when you use response files that contain invalid characters. Newer versions of the compiler don't generate this error.
- Supply a valid culture name recognized by the compiler (**CS2038**). Check the spelling against the list of supported culture names.
- Supply a properly formatted GUID to the legacy `/sqmsessionguid` option, or remove that option (**CS2039**, **CS2040**). For example, `/sqmsessionguid:01234567-89ab-cdef-0123-456789abcdef` supplies a valid GUID. CS2039 indicates an invalid GUID value, and CS2040 indicates a missing value. The compiler retains this option's parsing for backward compatibility. These diagnostics don't describe the [**ChecksumAlgorithm**](../compiler-options/advanced.md#checksumalgorithm) option, which accepts `SHA1` or `SHA256`, not a GUID.
- Remove invalid characters from the output file name (**CS2041**). Output names can't contain characters that are invalid in file paths on the target operating system.
- Provide a valid debug information format value (**CS2042**). Accepted values depend on the compiler version and typically include `full`, `pdbonly`, `portable`, and `embedded`.
- Replace the legacy `id#` syntax with `$id` (**CS2043**). The compiler no longer supports the older syntax.
- Supply a value that matches the expected format for the specified option (**CS2046**). The error message indicates the expected form.
- Format each [**PathMap**](../compiler-options/advanced.md#pathmap) entry as `source=destination`, with a nonempty value on both sides, and separate mappings with commas (**CS8101**). For example, `/pathmap:C:\work\src=/_/src,C:\work\generated=/_/generated` supplies two mappings. An entry such as `/pathmap:C:\work\src` is missing `=destination`. Double a literal comma or equals sign within a path as `,,` or `==`; quotation marks alone don't escape these mapping separators.

  On the compiler command line, quote paths containing spaces so the shell passes the complete option as one argument, for example `/pathmap:"C:\work tree=/_/src"`. In a project file, use `<PathMap>C:\work tree=/_/src</PathMap>` without command-line quotation marks. XML escaping still applies to characters such as `&`, which you write as `&amp;` in element text.

- Redirect standard input when using the `-` (stdin) argument (**CS8772**). The compiler expects piped input when you pass `-` as the source file argument. Use a pipeline (for example, `cat file.cs | csc -`) or remove the `-` argument and pass the source file directly.
- Set the experimental Roslyn `CSharpCompilationOptions.MemorySafetyRulesVersion` option to a supported enum member (**CS9400**). `WithMemorySafetyRulesVersion` accepts `MemorySafetyRulesVersion.Version1` (`1`, legacy rules) or `MemorySafetyRulesVersion.Version2` (`2`, updated rules). Casting another integer, such as `0` or `3`, to this enum produces CS9400 with the accepted values `1, 2`. This diagnostic validates the Roslyn API option, not values passed to the `updated-memory-safety-rules` feature flag. A valid value can still require another language version: `Version2` with C# 15.0 produces [CS8630](feature-version-errors.md#feature-not-available-in-language-version), because the updated rules require `preview`.

## Instrumentation and PDB options

- **CS8111**: *Invalid instrumentation kind: instrumentation kind*
- **CS8113**: *Invalid hash algorithm name: 'hash algorithm name'*

Use a supported instrumentation kind when you pass the `/instrument` option. The command-line option accepts `TestCoverage`; Roslyn API consumers must provide a valid <xref:Microsoft.CodeAnalysis.Emit.InstrumentationKind> value in <xref:Microsoft.CodeAnalysis.Emit.EmitOptions.InstrumentationKinds?displayProperty=nameWithType> (**CS8111**).

Provide a cryptographic hash algorithm supported by the current platform in <xref:Microsoft.CodeAnalysis.Emit.EmitOptions.PdbChecksumAlgorithm?displayProperty=nameWithType> (**CS8113**). Deterministic emission also requires a nonempty PDB checksum algorithm. This API setting calculates the PDB checksum stored in the compiled file. It's distinct from the [**ChecksumAlgorithm** compiler option](../compiler-options/advanced.md#checksumalgorithm), which selects `SHA1` or `SHA256` for source-file checksums stored in the PDB. Invalid command-line values are rejected while parsing the command line rather than reported as CS8113.

## Parse and documentation API options

- **CS8190**: *Provided source code kind is unsupported or invalid: 'source code kind'*
- **CS8191**: *Provided documentation mode is unsupported or invalid: 'documentation mode'.*

Ordinary `csc` command-line option parsing doesn't produce these public Roslyn API diagnostics. When a <xref:Microsoft.CodeAnalysis.CSharp.CSharpParseOptions> instance contains an invalid enum value, `CSharpParseOptions.Errors` exposes them. `CSharpCompilation.GetDiagnostics()` also reports them after a syntax tree that uses those options is included in a compilation, but `CSharpSyntaxTree.GetDiagnostics()` doesn't report them.

- Use <xref:Microsoft.CodeAnalysis.SourceCodeKind.Regular?displayProperty=nameWithType> for C# source files or <xref:Microsoft.CodeAnalysis.SourceCodeKind.Script?displayProperty=nameWithType> for scripts (**CS8190**). The obsolete `Interactive` value is rejected; use `Script` instead.
- Use <xref:Microsoft.CodeAnalysis.DocumentationMode.None?displayProperty=nameWithType>, <xref:Microsoft.CodeAnalysis.DocumentationMode.Parse?displayProperty=nameWithType>, or <xref:Microsoft.CodeAnalysis.DocumentationMode.Diagnose?displayProperty=nameWithType> (**CS8191**). Don't cast an arbitrary integer to `DocumentationMode`.

## Conflicting or missing options

- **CS1564**: *Conflicting options specified: Win32 resource file; Win32 manifest*
- **CS1616**: *Option 'option' overrides attribute 'attribute' given in a source file or added module*
- **CS2036**: *The /pdb option requires that the /debug option also be used*
- **CS2044**: */sourcelink switch is only supported when emitting PDB.*
- **CS2045**: */embed switch is only supported when emitting a PDB.*
- **CS8771**: *Output directory could not be determined*

These errors indicate that compiler options contradict each other, override source-level attributes, or require companion options that you didn't specify. For the full list of compiler options, see [C# Compiler Options](../compiler-options/index.md).

- Include the custom Win32 manifest inside the Win32 resource file and remove the **/win32manifest** compiler option (**CS1564**). You can't specify both [**Win32Resource**](../compiler-options/resources.md#win32resource) and [**Win32Manifest**](../compiler-options/resources.md#win32manifest) simultaneously. If you use **/Win32res**, include the manifest in the resource file.
- Remove the conflicting source attribute or the conflicting command-line option so they don't contradict each other (**CS1616**). This warning occurs when assembly attributes like <xref:System.Reflection.AssemblyKeyFileAttribute> or <xref:System.Reflection.AssemblyKeyNameAttribute> in source conflict with the [**KeyFile**](../compiler-options/security.md#keyfile) or [**KeyContainer**](../compiler-options/security.md#keycontainer) command-line option.
- Enable **/debug** when you want output at the [**PdbFile**](../compiler-options/advanced.md#pdbfile) path, or remove **/pdb** if you don't need a PDB (**CS2036**). The **/pdb** option selects the PDB path; it doesn't enable PDB generation. Current Roslyn accepts **/pdb** without **/debug**, but doesn't generate a PDB or report CS2036 for that combination. For more information, see [**DebugType** (C# Compiler Options)](../compiler-options/code-generation.md#debugtype).
- Add the **/debug** option (or set `DebugType` in the project) to enable PDB generation when using **/sourcelink** or **/embed** (**CS2044**, **CS2045**). Source links and embedded source both require PDB output because the source information is stored in the PDB file.
- Ensure the project or command line specifies a valid output directory (**CS8771**). Verify the `OutputPath` or `OutDir` property in your project file, or pass a valid `/out:` argument to the compiler.

## Module and assembly configuration

- **CS3012**: *You must specify the CLSCompliant attribute on the assembly, not the module, to enable CLS compliance checking*
- **CS3013**: *Added modules must be marked with the CLSCompliant attribute to match the assembly*

These warnings involve mismatches between the CLSCompliant attribute on modules and assemblies. For more information on the CLS, see [Language independence and language-independent components](../../../standard/language-independence.md).

- Put `[assembly:System.CLSCompliant(true)]` on the assembly to enable CLS compliance checking, rather than specifying only `[module:System.CLSCompliant(true)]` (**CS3012**). A module-level declaration alone doesn't enable checking for the assembly.
- When building a CLS-compliant assembly, rebuild each unmarked module added via [**AddModule**](../compiler-options/inputs.md#addmodules) with `[assembly:System.CLSCompliant(true)]` in its source (**CS3013**). This declaration is preserved when the source is compiled as a netmodule. Marking only the consuming assembly doesn't mark the modules it includes.

## Public signing and reference assembly output

- **CS8202**: *Public signing is not supported for netmodules.*
- **CS8308**: *Do not use refout when using refonly.*
- **CS8309**: *Cannot compile net modules when using /refout or /refonly.*

A netmodule contains metadata and compiled code but no assembly manifest. Because public signing applies a public key and signed flag to an assembly manifest, don't combine [**PublicSign**](../compiler-options/security.md#publicsign) with the `module` [**OutputType**](../compiler-options/output.md#outputtype) (**CS8202**). Produce an assembly, or disable public signing for the netmodule.

The `/refout` option produces a reference assembly in addition to the implementation assembly. The `/refonly` option produces only a reference assembly as the primary output. Remove `/refout` when using `/refonly` (**CS8308**). Reference assemblies require an assembly manifest, so don't combine either option with `/target:module` (**CS8309**). For MSBuild projects, use [**ProduceReferenceAssembly**](../compiler-options/output.md#producereferenceassembly) or [**ProduceOnlyReferenceAssembly**](../compiler-options/code-generation.md#produceonlyreferenceassembly), but not both.

## Deterministic assembly versions

- **CS8357**: *The specified version string 'version string' contains wildcards, which are not compatible with determinism. Either remove wildcards from the version string, or disable determinism for this compilation*

Deterministic compilation requires the same inputs to produce the same output. A wildcard in <xref:System.Reflection.AssemblyVersionAttribute> derives part of the version from changing values, so it isn't compatible with [**Deterministic** compilation](../compiler-options/code-generation.md#deterministic). Replace the wildcard with fixed numeric components. Disable deterministic compilation only when a generated wildcard version is required.

## Compiler infrastructure errors

- **CS0007**: *Unexpected common language runtime initialization error — 'description'*
- **CS7038**: *Failed to emit module 'module': error*
- **CS8751**: *Internal error in the C# compiler.*

These errors indicate failures in the compiler's own infrastructure rather than problems with your source code or command-line options.

- Verify that the runtime version specified in *csc.exe.config* is installed and not corrupted (**CS0007**). The setup process configures this file and you shouldn't change it. If you modified the file, check that the specified runtime version is present on the machine. If the correct version is present but might be corrupted, reinstall the common language runtime. Newer versions of the compiler no longer generate this error and it doesn't apply to the modern `dotnet build` toolchain.
- Try a clean rebuild, verify all assembly references are valid and not corrupted, and check for conflicting reference versions (**CS7038**). This error wraps a lower-level failure during the assembly emit phase. The nested error message provides more specific details about what went wrong.
- [File an issue in the Roslyn repository](https://github.com/dotnet/roslyn/issues/new/choose) with a minimal reproduction (**CS8751**). This error indicates a bug in the compiler itself. Your code exposed a code path the compiler team didn't anticipate.

## Validate configuration and response files

- **CS2011**: *Error opening response file 'file'*
- **CS7089**: *AppConfigPath must be absolute.*
- **CS7093**: *Cannot read config file 'file' -- 'reason'*
- **CS8035**: *Error reading ruleset file path - reason*

Correct the path to the [response file](../compiler-options/miscellaneous.md#responsefiles) passed as `@file.rsp`, and ensure the file exists and is readable by the process that runs the compiler (**CS2011**). A response file contains compiler arguments; supply its path after `@` rather than treating it as a source file. Quote a path containing spaces, for example `@"C:\build settings\options.rsp"`.

Use an absolute application-configuration path when a compiler integration requires `AppConfigPath` (**CS7089**). This diagnostic remains defined in the compiler, but current command-line parsing resolves relative `/appconfig` paths against the compiler's base directory rather than reporting CS7089. A relative command-line path alone isn't a reproduction of this diagnostic.

Check the file and reason named in **CS7093**, and correct the [**ApplicationConfiguration**](../compiler-options/advanced.md#applicationconfiguration) input supplied through `/appconfig`. Ensure the file exists, is readable, and contains valid application-configuration XML. For example, `/appconfig:missing.config` produces CS7093 when that file doesn't exist; point the option to an existing, valid configuration file instead. A file that opens successfully can still produce this error if its XML can't be read.

Correct the [**CodeAnalysisRuleSet**](../compiler-options/errors-warnings.md#codeanalysisruleset) path supplied through `/ruleset`, and use the reason in **CS8035** to fix missing or invalid ruleset files. The file must contain valid ruleset XML, not an EditorConfig file renamed to `.ruleset`. If the reason identifies an invalid included ruleset, correct that file too. Relative `<Include Path="...">` values are resolved against the directory containing the including ruleset.

## Correct unrecognized or ignored switches

- **CS2007**: *Unrecognized option: 'option'*
- **CS2023**: *Ignoring /noconfig option because it was specified in a response file*
- **CS8001**: *The command line switch 'switch' is not yet implemented and was ignored.*

Remove an unrecognized option, or use the documented spelling and argument from [C# compiler options](../compiler-options/index.md) (**CS2007**). For example, the following source produces CS2007 when you compile it with `/recur`:

```csharp
// Compile with: csc /recur Example.cs
class Example
{
    public static void Main() { }
}
```

To include source files recursively, use `/recurse:*.cs`, or remove `/recur` and pass the source file directly.

Move [`/noconfig`](../compiler-options/miscellaneous.md#noconfig) out of the response file and onto the compiler command line (**CS2023**). The option controls whether the compiler uses its default response file, so you must supply it on the command line rather than inside a response file. For example, remove `/noconfig` from `options.rsp` and invoke `csc /noconfig @options.rsp Example.cs` instead. You can't suppress this warning by using the [NoWarn](../compiler-options/errors-warnings.md#nowarn) option.

Remove a recognized but unimplemented switch, such as `/bugreport`, from the command line or response file (**CS8001**). Unlike CS2007, this warning means the compiler recognizes the switch but ignores it; the requested behavior doesn't occur. Removing it doesn't remove an active compiler feature. To report a compiler problem, collect a minimal reproduction and [file an issue in the Roslyn repository](https://github.com/dotnet/roslyn/issues/new/choose) instead.
