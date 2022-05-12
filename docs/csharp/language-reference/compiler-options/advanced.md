---
description: "Advanced C# Compiler Options. These options are used in advanced scenarios."
title: "C# Compiler Options - advanced scenarios"
ms.date: 03/12/2021
f1_keywords: 
  - "cs.build.options"
helpviewer_keywords: 
  - "BaseAddress compiler option [C#]"
  - "ChecksumAlgorithm compiler option [C#]"
  - "CodePage compiler option [C#]"
  - "Utf8Output compiler option [C#]"
  - "MainEntryPoint compiler option [C#]"
  - "GenerateFullPaths compiler option [C#]"
  - "FileAlignment compiler option [C#]"
  - "PathMap compiler option [C#]"
  - "PdbFile compiler option [C#]"
  - "ErrorEndLocation compiler option [C#]"
  - "NoStandardLib compiler option [C#]"
  - "PreferredUILang compiler option [C#]"
  - "SubsystemVersion compiler option [C#]"
  - "AdditionalLibPaths compiler option [C#]"
  - "ApplicationConfiguration compiler option [C#]"
  - "ModuleAssemblyName compiler option [C#]"

---
# Advanced C# compiler options

The following options support advanced scenarios. The new MSBuild syntax is shown in **Bold**. The older `csc.exe` syntax is shown in `code style`.

- **MainEntryPoint**, **StartupObject** / `-main`: Specify the type that contains the entry point.
- **PdbFile** / `-pdb`: Specify debug information file name.
- **PathMap** / `-pathmap`: Specify a mapping for source path names output by the compiler.
- **ApplicationConfiguration** / `-appconfig`: Specify an application configuration file containing assembly binding settings.
- **AdditionalLibPaths** / `-lib`: Specify additional directories to search in for references.
- **GenerateFullPaths** / `-fullpath`: Compiler generates fully qualified paths.
- **PreferredUILang** / `-preferreduilang`: Specify the preferred output language name.
- **BaseAddress** / `-baseaddress`: Specify the base address for the library to be built.
- **ChecksumAlgorithm** / `-checksumalgorithm` : Specify algorithm for calculating source file checksum stored in PDB.
- **CodePage** / `-codepage`: Specify the codepage to use when opening source files.
- **Utf8Output** / `-utf8output`: Output compiler messages in UTF-8 encoding.
- **FileAlignment** / `-filealign`: Specify the alignment used for output file sections.
- **ErrorEndLocation** / `-errorendlocation`: Output line and column of the end location of each error.
- **NoStandardLib** / `-nostdlib`: Don't reference standard library *mscorlib.dll*.
- **SubsystemVersion** / `-subsystemversion`: Specify subsystem version of this assembly.
- **ModuleAssemblyName** / `-moduleassemblyname`: Name of the assembly that this module will be a part of.

## MainEntryPoint or StartupObject

This option specifies the class that contains the entry point to the program, if more than one class contains a `Main` method.

```xml
<StartupObject>MyNamespace.Program</StartupObject>
```

or

```xml
<MainEntryPoint>MyNamespace.Program</MainEntryPoint>
```

Where `Program` is the type that contains the `Main` method. The provided class name must be fully qualified; it must include the full namespace containing the class, followed by the class name. For example, when the `Main` method is located inside the `Program` class in the `MyApplication.Core` namespace, the compiler option has to be `-main:MyApplication.Core.Program`. If your compilation includes more than one type with a [`Main`](../../fundamentals/program-structure/main-command-line.md) method, you can specify which type contains the `Main` method.

> [!NOTE]
> This option can't be used for a project that includes [top-level statements](../../fundamentals/program-structure/top-level-statements.md), even if that project contains one or more `Main` methods.

## PdbFile

The **PdbFile** compiler option specifies the name and location of the debug symbols file.  The `filename` value specifies the name and location of the debug symbols file.  

```xml
<PdbFile>filename</PdbFile>
```

When you specify [**DebugType**](code-generation.md#debugtype), the compiler will create a *.pdb* file in the same directory where the compiler will create the output file (.exe or .dll). The *.pdb* file has the same base file name as the name of the output file. **PdbFile** allows you to specify a non-default file name and location for the .pdb file. This compiler option cannot be set in the Visual Studio development environment, nor can it be changed programmatically.  

## PathMap

The **PathMap** compiler option specifies how to map physical paths to source path names output by the compiler. This option maps each physical path on the machine where the compiler runs to a corresponding path that should be written in the output files. In the following example, `path1` is the full path to the source files in the current environment, and `sourcePath1` is the source path substituted for `path1` in any output files. To specify multiple mapped source paths, separate each with a semicolon.

```xml
<PathMap>path1=sourcePath1;path2=sourcePath2</PathMap>
```

The compiler writes the source path into its output for the following reasons:

1. The source path is substituted for an argument when the <xref:System.Runtime.CompilerServices.CallerFilePathAttribute> is applied to an optional parameter.
1. The source path is embedded in a PDB file.
1. The path of the PDB file is embedded into a PE (portable executable) file.

## ApplicationConfiguration

The **ApplicationConfiguration** compiler option enables a C# application to specify the location of an assembly's application configuration (app.config) file to the common language runtime (CLR) at assembly binding time.

```xml
<ApplicationConfiguration>file</ApplicationConfiguration>
```

Where `file` is the application configuration file that contains assembly binding settings. One use of **ApplicationConfiguration** is advanced scenarios in which an assembly has to reference both the .NET Framework version and the .NET Framework for Silverlight version of a particular reference assembly at the same time. For example, a XAML designer written in Windows Presentation Foundation (WPF) might have to reference both the WPF Desktop, for the designer's user interface, and the subset of WPF that is included with Silverlight. The same designer assembly has to access both assemblies. By default, the separate references cause a compiler error, because assembly binding sees the two assemblies as equivalent. The **ApplicationConfiguration** compiler option enables you to specify the location of an app.config file that disables the default behavior by using a `<supportPortability>` tag, as shown in the following example.

```xml
<supportPortability PKT="7cec85d7bea7798e" enable="false"/>
```

The compiler passes the location of the file to the CLR's assembly-binding logic.

> [!NOTE]
> To use the app.config file that is already set in the project, add property tag `<UseAppConfigForCompiler>` to the *.csproj* file and set its value to `true`. To specify a different app.config file, add property tag `<AppConfigForCompiler>` and set its value to the location of the file.

The following example shows an app.config file that enables an application to have references to both the .NET Framework implementation and the .NET Framework for Silverlight implementation of any .NET Framework assembly that exists in both implementations. The **ApplicationConfiguration** compiler option specifies the location of this app.config file.

```xml
<configuration>
  <runtime>
    <assemblyBinding>
      <supportPortability PKT="7cec85d7bea7798e" enable="false"/>
      <supportPortability PKT="31bf3856ad364e35" enable="false"/>
    </assemblyBinding>
  </runtime>
</configuration>
```

## AdditionalLibPaths

The **AdditionalLibPaths** option specifies the location of assemblies referenced with the [**References**](inputs.md#references) option.

```xml
<AdditionalLibPaths>dir1[,dir2]</AdditionalLibPaths>
```

Where `dir1` is a directory for the compiler to look in if a referenced assembly isn't found in the current working directory (the directory from which you're invoking the compiler) or in the common language runtime's system directory. `dir2` is one or more additional directories to search in for assembly references. Separate directory names with a comma, and without white space between them. The compiler searches for assembly references that aren't fully qualified in the following order:  

1. Current working directory.
1. The common language runtime system directory.
1. Directories specified by **AdditionalLibPaths**.
1. Directories specified by the LIB environment variable.

Use **Reference** to specify an assembly reference. **AdditionalLibPaths** is additive. Specifying it more than once appends to any prior values. Since the path to the dependent assembly isn't specified in the assembly manifest, the application will find and use the assembly in the global assembly cache. The compiler referencing the assembly doesn't imply the common language runtime can find and load the assembly at run time. See [How the Runtime Locates Assemblies](../../../framework/deployment/how-the-runtime-locates-assemblies.md) for details on how the runtime searches for referenced assemblies.  

## GenerateFullPaths

The **GenerateFullPaths** option causes the compiler to specify the full path to the file when listing compilation errors and warnings.
  
```Xml
<GenerateFullPaths>true</GenerateFullPaths>
```

By default, errors and warnings that result from compilation specify the name of the file in which an error was found. The **GenerateFullPaths** option causes the compiler to specify the full path to the file. This compiler option is unavailable in Visual Studio and cannot be changed programmatically.

## PreferredUILang

By using the **PreferredUILang** compiler option, you can specify the language in which the C# compiler displays output, such as error messages.

```xml
<PreferredUILang>language</PreferredUILang>
```

Where `language` is the [language name](/windows/desktop/Intl/language-names) of the language to use for compiler output. You can use the **PreferredUILang** compiler option to specify the language that you want the C# compiler to use for error messages and other command-line output. If the language pack for the language isn't installed, the language setting of the operating system is used instead.

## BaseAddress

The **BaseAddress** option lets you specify the preferred base address at which to load a DLL. For more information about when and why to use this option, see [Larry Osterman's WebLog](/archive/blogs/larryosterman/why-should-i-even-bother-to-use-dlls-in-my-system).

```xml
<BaseAddress>address</BaseAddress>
```

Where `address` is the base address for the DLL. This address can be specified as a decimal, hexadecimal, or octal number. The default base address for a DLL is set by the .NET common language runtime. The lower-order word in this address will be rounded. For example, if you specify `0x11110001`, it will be rounded to `0x11110000`. To complete the signing process for a DLL, use SN.EXE with the -R option.

## ChecksumAlgorithm

This option controls the checksum algorithm we use to encode source files in the PDB.

```xml
<ChecksumAlgorithm>algorithm</ChecksumAlgorithm>
```

The `algorithm` must be either `SHA1` (default) or `SHA256`.

## CodePage

This option specifies which codepage to use during compilation if the required page isn't the current default codepage for the system.
  
```xml
<CodePage>id</CodePage>
```

Where `id` is the id of the code page to use for all source code files in the compilation. The compiler will first attempt to interpret all source files as UTF-8. If your source code files are in an encoding other than UTF-8 and use characters other than 7-bit ASCII characters, use the **CodePage** option to specify which code page should be used. **CodePage** applies to all source code files in your compilation. See [GetCPInfo](/windows/desktop/api/winnls/nf-winnls-getcpinfo) for information on how to find which code pages are supported on your system.

## Utf8Output

The **Utf8Output** option displays compiler output using UTF-8 encoding.

```xml
<Utf8Output>true</Utf8Output>
```

In some international configurations, compiler output cannot correctly be displayed in the console. Use **Utf8Output** and redirect compiler output to a file.

## FileAlignment

The **FileAlignment** option lets you specify the size of sections in your output file. Valid values are 512, 1024, 2048, 4096, and 8192. These values are in bytes.

```xml
<FileAlignment>number</FileAlignment>
```

You set the **FileAlignment** option from the **Advanced** page of the **Build** properties for your project in Visual Studio. Each section will be aligned on a boundary that is a multiple of the **FileAlignment** value. There's no fixed default. If **FileAlignment** isn't specified, the common language runtime picks a default at compile time. By specifying the section size, you affect the size of the output file. Modifying section size may be useful for programs that will run on smaller devices. Use [DUMPBIN](/cpp/build/reference/dumpbin-options) to see information about sections in your output file.

## ErrorEndLocation

Instructs the compiler to output line and column of the end location of each error.

```xml
<ErrorEndLocation>true</ErrorEndLocation>
```

By default, the compiler writes the starting location in source for all errors and warnings. When this option is set to true, the compiler writes both the starting and end location for each error and warning.

## NoStandardLib

**NoStandardLib** prevents the import of mscorlib.dll, which defines the entire System namespace.

```xml
<NoStandardLib>true</NoStandardLib>
```

Use this option if you want to define or create your own System namespace and objects. If you don't specify **NoStandardLib**, mscorlib.dll is imported into your program (same as specifying `<NoStandardLib>false</NoStandardLib>`).

## SubsystemVersion

Specifies the minimum version of the subsystem on which the executable file runs. Most commonly, this option ensures that the executable file can use security features that aren’t available with older versions of Windows.

> [!NOTE]
> To specify the subsystem itself, use the [**TargetType**](./output.md#targettype) compiler option.

```xml
<SubsystemVersion>major.minor</SubsystemVersion>
```

The `major.minor` specify the minimum required version of the subsystem, as expressed in a dot notation for major and minor versions. For example, you can specify that an application can't run on an operating system that's older than Windows 7. Set the value of this option to 6.01, as the table later in this article describes. You specify the values for `major` and `minor` as integers. Leading zeroes in the `minor` version don't change the version, but trailing zeroes do. For example, 6.1 and 6.01 refer to the same version, but 6.10 refers to a different version. We recommend expressing the minor version as two digits to avoid confusion.

The following table lists common subsystem versions of Windows.

|Windows version|Subsystem version|
|---------------------|-----------------------|
|Windows Server 2003|5.02|
|Windows Vista|6.00|
|Windows 7|6.01|
|Windows Server 2008|6.01|
|Windows 8|6.02|

The default value of the **SubsystemVersion** compiler option depends on the conditions in the following list:

- The default value is 6.02 if any compiler option in the following list is set:
  - [-target:appcontainerexe](output.md)
  - [-target:winmdobj](output.md)
  - [-platform:arm](output.md)
- The default value is 6.00 if you're using MSBuild, you're targeting .NET Framework 4.5, and you haven't set any of the compiler options that were specified earlier in this list.
- The default value is 4.00 if none of the previous conditions are true.

## ModuleAssemblyName

Specifies the name of an assembly whose non-public types a *.netmodule* can access.

```xml
<ModuleAssemblyName>assembly_name</ModuleAssemblyName>
```

**ModuleAssemblyName** should be used when building a *.netmodule*, and where the following conditions are true:

- The *.netmodule* needs access to non-public types in an existing assembly.
- You know the name of the assembly into which the .netmodule will be built.
- The existing assembly has granted friend assembly access to the assembly into which the .*netmodule* will be built.

For more information on building a .netmodule, see [**TargetType**](output.md#targettype) option of **module**. For more information on friend assemblies, see [Friend Assemblies](../../../standard/assembly/friend.md).
