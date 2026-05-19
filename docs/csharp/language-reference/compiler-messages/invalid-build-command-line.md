---
title: "Resolve errors and warnings related to invalid command-line options and build configuration"
description: "This article helps you diagnose and correct compiler errors and warnings related to invalid command-line switches, build configuration, and compiler invocation problems"
f1_keywords:
  - "CS0006"
  - "CS0007"
  - "CS0016"
  - "CS1564"
  - "CS1616"
  - "CS1668"
  - "CS1719"
  - "CS1773"
  - "CS2008"
  - "CS2019"
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
  - "CS8751"
  - "CS8771"
  - "CS8772"
helpviewer_keywords:
  - "CS0006"
  - "CS0007"
  - "CS0016"
  - "CS1564"
  - "CS1616"
  - "CS1668"
  - "CS1719"
  - "CS1773"
  - "CS2008"
  - "CS2019"
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
  - "CS8751"
  - "CS8771"
  - "CS8772"
ms.date: 05/19/2026
ai-usage: ai-assisted
---
# Resolve errors and warnings for invalid command-line options and build configuration

This article covers the following compiler errors and warnings:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->
- [**CS0006**](#anchor-tbd): *Metadata file 'file' could not be found*
- [**CS0007**](#anchor-tbd): *Unexpected common language runtime initialization error — 'description'*
- [**CS0016**](#anchor-tbd): *Could not write to output file 'file' -- 'reason'*
- [**CS1564**](#anchor-tbd): *Conflicting options specified: Win32 resource file; Win32 manifest*
- [**CS1616**](#anchor-tbd): *Option 'option' overrides attribute 'attribute' given in a source file or added module*
- [**CS1668**](#anchor-tbd): *Invalid search path 'path' specified in 'option' -- 'reason'*
- [**CS1719**](#anchor-tbd): *Error opening Win32 resource file 'file' -- 'reason'*
- [**CS1773**](#anchor-tbd): *Invalid version 'version' for /subsystemversion. The version must be 6.02 or greater for ARM or AppContainerExe, and 4.00 or greater otherwise*
- [**CS2008**](#anchor-tbd): *No source files specified.*
- [**CS2019**](#anchor-tbd): *Invalid target type for /target: must specify 'exe', 'winexe', 'library', or 'module'*
- [**CS2029**](#anchor-tbd): *Invalid name for a preprocessing symbol; 'identifier' is not a valid identifier*
- [**CS2032**](#anchor-tbd): *Character 'character' is not allowed on the command-line or in response files*
- [**CS2036**](#anchor-tbd): *The /pdb option requires that the /debug option also be used*
- [**CS2038**](#anchor-tbd): *The language name 'name' is invalid.*
- [**CS2039**](#anchor-tbd): *Command-line syntax error: Invalid Guid format 'value' for option 'option'*
- [**CS2040**](#anchor-tbd): *Command-line syntax error: Missing Guid for option 'option'*
- [**CS2041**](#anchor-tbd): *Invalid output name: 'name'*
- [**CS2042**](#anchor-tbd): *Invalid debug information format: 'format'*
- [**CS2043**](#anchor-tbd): *'id#' syntax is no longer supported. Use '$id' instead.*
- [**CS2044**](#anchor-tbd): */sourcelink switch is only supported when emitting PDB.*
- [**CS2045**](#anchor-tbd): */embed switch is only supported when emitting a PDB.*
- [**CS2046**](#anchor-tbd): *Command-line syntax error: 'value' is not a valid value for the 'option' option. The value must be of the form 'format'.*
- [**CS3012**](#anchor-tbd): *You must specify the CLSCompliant attribute on the assembly, not the module, to enable CLS compliance checking*
- [**CS3013**](#anchor-tbd): *Added modules must be marked with the CLSCompliant attribute to match the assembly*
- [**CS7038**](#anchor-tbd): *Failed to emit module 'module': 'error'*
- [**CS8751**](#anchor-tbd): *Internal error in the C# compiler.*
- [**CS8771**](#anchor-tbd): *Output directory could not be determined*
- [**CS8772**](#anchor-tbd): *stdin argument '-' is specified, but input has not been redirected from the standard input stream.*

## CS0006

Metadata file 'dll_name' could not be found.

The program was compiled and explicitly passed the name of a file that contained metadata; however, the .dll was not found. For more information, see [**References** (C# Compiler Options)](../compiler-options/inputs.md#references).

## CS0007

Unexpected common language runtime initialization error — 'description'.

This error occurs if the runtime could not be loaded. This could occur if the version of the common language runtime that the compiler attempts to load is not present on the machine, or if the common language runtime installation or configuration is corrupt.

This can happen if the *csc.exe.config* file was changed. This file is configured during setup and should not be changed. If there is a possibility that the *csc.exe.config* file was changed, check the file to make sure that the version of the runtime specified in the file is present on the machine. If the correct version is present, it may be corrupted. Reinstall the common language runtime.

## CS0016

Could not write to output file 'file' — 'reason'.

The compiler could not write to an output file. Check the path to the file to make sure it exists. If a previously built file is already at the location, make sure it is writeable, and that no process currently has a lock on the file. For example, make sure your executable is not running when you attempt to build.

## CS1564

Conflicting options specified: Win32 resource file; Win32 manifest.

If you use the **/Win32res** compiler option, you must include the custom Win32 manifest (if it is required) in the resource file. You cannot provide a custom Win32 manifest separately from a Win32 resource file. Use the **/win32manifest** option only if you are not specifying a win32 resource file.

To correct this error, add the win32 manifest to the win32 resource file and remove the **/win32manifest** compiler option.

For more information, see [**Win32Manifest** (C# Compiler Options)](../compiler-options/resources.md#win32manifest) and [**Win32Resource** (C# Compiler Options)](../compiler-options/resources.md#win32resource).

## CS1616

Option 'option' overrides attribute 'attribute' given in a source file or added module.

This warning occurs if the assembly attributes <xref:System.Reflection.AssemblyKeyFileAttribute> or <xref:System.Reflection.AssemblyKeyNameAttribute> found in source conflict with the [**KeyFile**](../compiler-options/security.md#keyfile) or [**KeyContainer**](../compiler-options/security.md#keycontainer) command line option or key file name or key container specified in the Project Properties.

To resolve this warning, remove the conflicting source attribute or remove the conflicting command-line option so they don't contradict each other.

## CS1668

Invalid search path 'path' specified in 'option' -- 'reason'.

The path supplied to [**AdditionalLibPaths**](../compiler-options/advanced.md#additionallibpaths) at the command line was not valid, or a path in the LIB environment variable is invalid. Check the path used to verify that it exists and can be accessed. The error message in single quotation marks is the error returned from the operating system.

## CS1719

Error opening Win32 resource file 'File Name' -- 'reason'.

An attempt to read the Win32 resource file failed for the reason given in the error, typically something like "file not found" or "access denied." This error is resolved by correcting the problem described by the reason.

## CS2008

No source files specified.

The compiler was invoked and compiler options were specified, but no source-code files were passed.

## CS2019

Invalid target type for /target: must specify 'exe', 'winexe', 'library', or 'module'.

The [**OutputType**](../compiler-options/output.md#outputtype) compiler option was used, but an invalid parameter was passed. To resolve this error, recompile the program using the form of the **/target** option that is appropriate to your output file.

## CS2029

Invalid value for '/define'; 'identifier' is not a valid identifier.

This warning occurs if the value that is used in the [**DefineConstants**](../compiler-options/language.md#defineconstants) option has some invalid characters.

This warning cannot be suppressed by the [**NoWarn**](../compiler-options/errors-warnings.md#nowarn) option.

## CS2032

Character 'character' is not allowed on the command-line or in response files.

Response files and the command line options for csc.exe cannot contain ASCII control characters in the range 0-31 or the pipe (`|`) character.

Compiler error CS2032 is difficult to demonstrate from the command line because the command line processor and the integrated development environment (IDE) filter out characters that are not valid. The following procedure generates the error by using a [response file](../compiler-options/miscellaneous.md#responsefiles).

1. In the *My Documents* folder, create a text file that is named *CS2032.rsp*, and then enter the following compiler options in it: `/target:exe /out:cs|2032.exe cs2032.cs`
2. In the *My Documents* folder, create a text file that's named *cs2032.cs* and that contains whatever you want.
3. Open [Visual Studio Developer Command Prompt or Visual Studio Developer PowerShell](/visualstudio/ide/reference/command-prompt-powershell).
4. Change the current directory to `C:\Users\<YourUsername>\Documents`.
5. Run the following command from the command prompt: `csc @cs2032.rsp`
6. The CS2032 error message appears because the response file, *CS2032.rsp*, contains a pipe character.

## CS2036

The /pdb option requires that the /debug option also be used.

Program database files are only generated for debug builds. The **/pdb** option is therefore meaningless in a retail build.

To correct this error, add the **/debug** compiler option, or remove the **/pdb** compiler option.

For more information, see [**PdbFile** (C# Compiler Options)](../compiler-options/advanced.md#pdbfile) and [**DebugType** (C# Compiler Options)](../compiler-options/code-generation.md#debugtype).

## CS3012

You cannot specify the CLSCompliant attribute on a module that differs from the CLSCompliant attribute on the assembly.

In order for a module to be compliant with the Common Language Specification (CLS) through `[module:System.CLSCompliant(true)]`, it must be built with the **module** element of the [**OutputType**](../compiler-options/output.md#outputtype) compiler option. For more information on the CLS, see [Language independence and language-independent components](../../../../standard/language-independence.md).

## CS3013

Added modules must be marked with the CLSCompliant attribute to match the assembly.

A module that was compiled with the **module** element of the [**OutputType**](../compiler-options/output.md#outputtype) compiler option was added to a compilation with [**AddModule**](../compiler-options/inputs.md#addmodules). However, the module's compliance with the Common Language Specification (CLS) does not agree with the CLS state of the current compilation.

CLS compliance is indicated with the module attribute. For example, `[module:CLSCompliant(true)]` indicates that the module is CLS compliant, and `[module:CLSCompliant(false)]` indicates that the module is not CLS compliant. The default is `[module:CLSCompliant(false)]`. For more information on the CLS, see [Language independence and language-independent components](../../../../standard/language-independence.md).
