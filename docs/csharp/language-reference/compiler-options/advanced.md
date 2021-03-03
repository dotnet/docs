---
description: "Advanced C# Compiler Options"
title: "C# Compiler Options - advanced scenarios"
ms.date: 02/18/2021
f1_keywords: 
  - "cs.build.options"
helpviewer_keywords: 
  - "BaseAddress compiler option [C#]"
  - "CodePage compiler option [C#]"
  - "Utf8Output compiler option [C#]"
  - "MainEntryPoint compiler option [C#]"
  - "GenerateFullPaths compiler option [C#]"
  - "FileAlignment compiler option [C#]"
  - "PathMap compiler option [C#]"
  - "PdbFile compiler option [C#]"
  - "NoStandardLib compiler option [C#]"
  - "SubsystemVersion compiler option [C#]"
  - "AdditionalLibPaths compiler option [C#]"
  - "ErrorReport compiler option [C#]"
  - "ApplicationConfiguration compiler option [C#]"
  - "ModuleAssemblyName compiler option [C#]"

---
# Advanced C# compiler options

The following options support advanced scenarios. The new MSBuild syntax is shown in **Bold**. The older `csc.exe` syntax is shown in `code style`.

- **BaseAddress** / `-baseaddress`: Specify the base address for the library to be built.
- **??** / `-bugreport`: Create a 'Bug Report' file.
- **??** / `-checksumalgorithm` : Specify algorithm for calculating source file checksum stored in PDB. Supported values are: `SHA1` (default) or `SHA256`.
- **CodePage** / `-codepage`: Reference metadata from the specified assembly file or files.
- **Utf8Output** / `-utf8output`: Include all files in the current directory and subdirectories according to the wildcard specifications
- **MainEntryPoint**, **StartupObject** / `-main`: Embed metadata from the specified interop assembly files.
- **GenerateFullPaths** / `-fullpath`: Run the analyzers from the specified assembly.
- **FileAlignment** / `-filealign`: Add additional files that don't directly affect code generation but may be used by analyzers for producing errors or warnings.
- **PathMap** / `-pathmap`: Specify a mapping for source path names output by the compiler. Two consecutive separator characters are treated as a single character that is part of the key or value (i.e. `==` stands for `=` and `,,` for `,`).
- **PdbFile** / `-pdb`: Specify debug information file name (default: output file name with .pdb extension).
- **??** / `-errorendlocation`: Output line and column of the end location of each error.
- **??** / `-preferreduilang`: Specify the preferred output language name.
- **NoStandardLib** / `-nostdlib`: Do not reference standard library *mscorlib.dll*.
- **SubsystemVersion** / `-subsystemversion`: Specify subsystem version of this assembly.
- **AdditionalLibPaths** / `-lib`: Specify additional directories to search in for references.
- **ErrorReport** / `-errorreport`: Specify how to handle internal compiler errors: `prompt`, `send`, `queue`, or `none`. The default is `queue`.
- **ApplicationConfiguration** / `-appconfig`: Specify an application configuration file containing assembly binding settings.
- **ModuleAssemblyName** / `-moduleassemblyname`: Name of the assembly which this module will be a part of.

## BaseAddress

The **BaseAddress** option lets you specify the preferred base address at which to load a DLL. For more information about when and why to use this option, see [Larry Osterman's WebLog](/archive/blogs/larryosterman/why-should-i-even-bother-to-use-dlls-in-my-system).

```xml
<BaseAddress>address</BaseAddress>
```

Where `address` is the base address for the DLL. This address can be specified as a decimal, hexadecimal, or octal number. The default base address for a DLL is set by the .NET common language runtime. Be aware that the lower-order word in this address will be rounded. For example, if you specify `0x11110001`, it will be rounded to `0x11110000`. To complete the signing process for a DLL, use SN.EXE with the -R option.

## -bugreport

Specifies that debug information should be placed in a file for later analysis.
  
```console
-bugreport:file
```

Where `file` is the name of the file that you want to contain your bug report.

The **-bugreport** option specifies that the following information should be placed in `file`:

- A copy of all source code files in the compilation.
- A listing of the compiler options used in the compilation.
- Version information about your compiler, run time, and operating system.
- Referenced assemblies and modules, saved as hexadecimal digits, except assemblies that are shipped with .NET and the .NET SDK.
- Compiler output, if any.
- A description of the problem, which you will be prompted for.
- A description of how you think the problem should be fixed, which you will be prompted for.

If this option is used with **-errorreport:prompt** or **-errorreport:send**, the information in the file will be sent to Microsoft Corporation. Because a copy of all source code files will be placed in `file`, you might want to reproduce the suspected code defect in the shortest possible program. Notice that contents of the generated file expose source code that could result in inadvertent information disclosure.

## -checksumalgorithm

TODO.

## CodePage

This option specifies which codepage to use during compilation if the required page is not the current default codepage for the system.
  
```xml
<CodePage>id</CodePage>
```

Where `id` is the id of the code page to use for all source code files in the compilation. The compiler will first attempt to interpret all source files as UTF-8. If your source code files are in an encoding other than UTF-8 and use characters other than 7-bit ASCII characters, use the **CodePage** option to specify which code page should be used. **-codepage** applies to all source code files in your compilation. See [GetCPInfo](/windows/desktop/api/winnls/nf-winnls-getcpinfo) for information on how to find which code pages are supported on your system.

## Utf8Output

The **Utf8Output** option displays compiler output using UTF-8 encoding.

```xml
<Utf8Output>true</Utf8Output>
```

In some international configurations, compiler output cannot correctly be displayed in the console. In these configurations, use **Utf8Output** and redirect compiler output to a file.

## MainEntryPoint or StartupObject

This option specifies the class that contains the entry point to the program, if more than one class contains a `Main` method.

```xml
<StartupObject>MyNamespace.Program</StartupObject>
```

or

```xml
<MainEntryPoint>MyNamespace.Program</MainEntryPoint>
```

Where `Program` is the type that contains the `Main` method. The provided class name must be fully qualified; it must include the full namespace containing the class, followed by the class name. For example, when the `Main` method is located inside the `Program` class in the `MyApplication.Core` namespace, the compiler option has to be `-main:MyApplication.Core.Program`. If your compilation includes more than one type with a [Main](../../programming-guide/main-and-command-args/index.md) method, you can specify which type contains the **Main** method that you want to use as the entry point into the program.

## GenerateFullPaths

The **GenerateFullPaths** option causes the compiler to specify the full path to the file when listing compilation errors and warnings.
  
```Xml
<GenerateFullPaths>true</GenerateFullPaths>
```

By default, errors and warnings that result from compilation specify the name of the file in which an error was found. The **GenerateFullPaths** option causes the compiler to specify the full path to the file. This compiler option is unavailable in Visual Studio and cannot be changed programmatically.

## FileAlignment

The **FileAlignment** option lets you specify the size of sections in your output file. The `number` argument specifies the size of sections in the output file. Valid values are 512, 1024, 2048, 4096, and 8192. These values are in bytes.

```xml
<FileAlignment>number</FileAlignment>
```

You set the **FileAlignment** option from the **Advanced** page of the **Build** properties for your project in Visual Studio. Each section will be aligned on a boundary that is a multiple of the **FileAlignment** value. There's no fixed default. If **FileAlignment** is not specified, the common language runtime picks a default at compile time. By specifying the section size, you affect the size of the output file. Modifying section size may be useful for programs that will run on smaller devices. Use [DUMPBIN](/cpp/build/reference/dumpbin-options) to see information about sections in your output file.

## PathMap

The **PathMap** compiler option specifies how to map physical paths to source path names output by the compiler. This option maps each physical path on the machine where the compiler runs to a corresponding path that should be written in the output files. In the following example, `path1` is the full path to the source files in the current environment, and `sourcePath1` is the source path substituted for `path1` in any output files. To specify multiple mapped source paths, separate each with a semicolon.

```xml
<PathMap>path1=sourcePath1;path2=sourcePath2</PathMap>
```

The compiler writes the source path into its output for the following reasons:

1. The source path is substituted for an argument when the <xref:System.Runtime.CompilerServices.CallerFilePathAttribute> is applied to an optional parameter.
1. The source path is embedded in a PDB file.
1. The path of the PDB file is embedded into a PE (portable executable) file.

## PdbFile

The **PdbFile** compiler option specifies the name and location of the debug symbols file.  The `filename` value specifies the name and location of the debug symbols file.  

```xml
<PdbFile>filename</PdbFile>
```

When you specify [-debug](./debug-compiler-option.md), the compiler will create a *.pdb* file in the same directory where the compiler will create the output file (.exe or .dll). The *.pdb* file has the same base file name as the name of the output file. **PdbFile** allows you to specify a non-default file name and location for the .pdb file. This compiler option cannot be set in the Visual Studio development environment, nor can it be changed programmatically.  

## errorendlocation

TODO.

## -preferreduilang

By using the `-preferreduilang` compiler option, you can specify the language in which the C# compiler displays output, such as error messages.

```console
-preferreduilang: language
```

Where `language` is the [language name](/windows/desktop/Intl/language-names) of the language to use for compiler output. You can use the `-preferreduilang` compiler option to specify the language that you want the C# compiler to use for error messages and other command-line output. If the language pack for the language is not installed, the language setting of the operating system is used instead, and no error is reported.

## NoStandardLib

**NoStandardLib** prevents the import of mscorlib.dll, which defines the entire System namespace.

### Syntax

```xml
<NoStandardLib>true</NoStandardLib>
```

Use this option if you want to define or create your own System namespace and objects. If you do not specify **NoStandardLib**, mscorlib.dll is imported into your program (same as specifying `<NoStandardLib>false</NoStandardLib>`).

## SubsystemVersion

Specifies the minimum version of the subsystem on which the generated executable file can run, thereby determining the versions of Windows on which the executable file can run. Most commonly, this option ensures that the executable file can leverage particular security features that aren’t available with older versions of Windows.

> [!NOTE]
> To specify the subsystem itself, use the [-target](./target-compiler-option.md) compiler option.

```xml
<SubsystemVersion>major.minor</SubsystemVersion>
```

The `major.minor` specify the minimum required version of the subsystem, as expressed in a dot notation for major and minor versions. For example, you can specify that an application can't run on an operating system that's older than Windows 7 if you set the value of this option to 6.01, as the table later in this topic describes. You must specify the values for `major` and `minor` as integers. Leading zeroes in the `minor` version don't change the version, but trailing zeroes do. For example, 6.1 and 6.01 refer to the same version, but 6.10 refers to a different version. We recommend expressing the minor version as two digits to avoid confusion.

The following table lists common subsystem versions of Windows.

|Windows version|Subsystem version|
|---------------------|-----------------------|
|Windows 2000|5.00|
|Windows XP|5.01|
|Windows Server 2003|5.02|
|Windows Vista|6.00|
|Windows 7|6.01|
|Windows Server 2008|6.01|
|Windows 8|6.02|

The default value of the **SubsystemVersion** compiler option depends on the conditions in the following list:

- The default value is 6.02 if any compiler option in the following list is set:
  - [-target:appcontainerexe](./target-appcontainerexe-compiler-option.md)
  - [-target:winmdobj](./target-winmdobj-compiler-option.md)
  - [-platform:arm](./platform-compiler-option.md)
- The default value is 6.00 if you're using MSBuild, you're targeting .NET Framework 4.5, and you haven't set any of the compiler options that were specified earlier in this list.
- The default value is 4.00 if none of the previous conditions is true.

## AdditionalLibPaths

The **AdditionalLibPaths** option specifies the location of assemblies referenced by means of the [-reference (C# Compiler Options)](./reference-compiler-option.md) option.

```xml
<AdditionalLibPaths>dir1[,dir2]</AdditionalLibPaths>
```

Where `dir1` is a directory for the compiler to look in if a referenced assembly is not found in the current working directory (the directory from which you are invoking the compiler) or in the common language runtime's system directory. `dir2` is one or more additional directories to search in for assembly references. Separate additional directory names with a comma, and without white space between them. The compiler searches for assembly references that are not fully qualified in the following order:  

1. Current working directory. This is the directory from which the compiler is invoked.
1. The common language runtime system directory.
1. Directories specified by **AdditionalLibPaths**.
1. Directories specified by the LIB environment variable.

Use **Reference** to specify an assembly reference. **AdditionalLibPaths** is additive; specifying it more than once appends to any prior values. An alternative to using **AdditionalLibPaths** is to copy into the working directory any required assemblies; this will allow you to simply pass the assembly name to **Reference**. You can then delete the assemblies from the working directory. Since the path to the dependent assembly is not specified in the assembly manifest, the application can be started on the target computer and will find and use the assembly in the global assembly cache. Because the compiler can reference the assembly does not imply the common language runtime will be able to find and load the assembly at runtime. See [How the Runtime Locates Assemblies](../../../framework/deployment/how-the-runtime-locates-assemblies.md) for details on how the runtime searches for referenced assemblies.  

## ErrorReport

This option provides a convenient way to report a C# internal compiler error to Microsoft.

> [!NOTE]
> On Windows Vista and Windows Server 2008, the error reporting settings that you make for Visual Studio do not override the settings made through Windows Error Reporting (WER). WER settings always take precedence over Visual Studio error reporting settings.

```xml
<ErrorReport>setting</ErrorReport>
```

The argument must be one of:

- **none**: Reports about internal compiler errors will not be collected or sent to Microsoft.
- **prompt**: Prompts you to send a report when you receive an internal compiler error. **prompt** is the default when you compile an application in the development environment.
- **queue**: Queues the error report. When you log on with administrative credentials, you can report any failures since the last time that you were logged on. You will not be prompted to send reports for failures more than once every three days. **queue** is the default when you compile an application at the command line.
- **send**: Automatically sends reports of internal compiler errors to Microsoft. To enable this option, you must first agree to the Microsoft data collection policy. The first time that you specify `<ErrorReport>send</ErrorReport>` on a computer, a compiler message will refer you to a Web site that contains the Microsoft data collection policy.

An internal compiler error (ICE) results when the compiler cannot process a source code file. When an ICE occurs, the compiler does not produce an output file or any useful diagnostic that you can use to fix your code.

In previous releases, when you received an ICE, you were encouraged to contact Microsoft Product Support Services to report the problem. By using **ErrorReport**, you can provide ICE information to the Visual C# team. Your error reports can help improve future compiler releases. A user's ability to send reports depends on computer and user policy permissions.

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
> If you are using the Microsoft Build Engine (MSBuild) to build your application, you can set the **ApplicationConfiguration** compiler option by adding a property tag to the .csproj file. To use the app.config file that is already set in the project, add property tag `<UseAppConfigForCompiler>` to the *.csproj* file and set its value to `true`. To specify a different app.config file, add property tag `<AppConfigForCompiler>` and set its value to the location of the file.

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

## ModuleAssemblyName

Specifies an assembly whose non-public types a *.netmodule* can access. The `assembly_name` value specifies the name of the assembly whose non-public types the *.netmodule* can access.  

```xml
<ModuleAssemblyName>assembly_name</ModuleAssemblyName>
```

**ModuleAssemblyName** should be used when building a *.netmodule*, and where the following conditions are true:

- The *.netmodule* needs access to non-public types in an existing assembly.
- You know the name of the assembly into which the .netmodule will be built.
- The existing assembly has granted friend assembly access to the assembly into which the .netmodule will be built.

For more information on building a .netmodule, see [-target:module (C# Compiler Options)](./target-module-compiler-option.md). For more information on friend assemblies, see [Friend Assemblies](../../../standard/assembly/friend.md).
