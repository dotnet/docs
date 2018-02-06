---
title: "Ildasm.exe (IL Disassembler)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "PE files, MSIL Disassembler"
  - "portable executable files, MSIL Disassembler"
  - "Ildasm.exe"
  - "MSIL Disassembler"
  - "text files produced by MSIL Disassembler"
  - "disassembling file for MSIL Assembler input"
ms.assetid: db27f6b2-f1ec-499e-be3a-7eecf95ca42b
caps.latest.revision: 33
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Ildasm.exe (IL Disassembler)

The IL Disassembler is a companion tool to the IL Assembler (*Ilasm.exe*). *Ildasm.exe* takes a portable executable (PE) file that contains intermediate language (IL) code and creates a text file suitable as input to *Ilasm.exe*.

This tool is automatically installed with Visual Studio. To run the tool, use the Developer Command Prompt (or the Visual Studio Command Prompt in Windows 7). For more information, see [Command Prompts](../../../docs/framework/tools/developer-command-prompt-for-vs.md).

At the command prompt, type the following:

## Syntax

```
ildasm [options] [PEfilename] [options]
```

#### Parameters

The following options are available for *.exe*, *.dll*, *.obj*, *.lib*, and *.winmd* files.

| Option | Description |
| ------ | ----------- |
|**/out=** `filename`|Creates an output file with the specified `filename`, rather than displaying the results in a graphical user interface.|
|**/rtf**|Produces output in rich text format. Invalid with the **/text** option.|
|**/text**|Displays the results to the console window, rather than in a graphical user interface or as an output file.|
|**/html**|Produces output in HTML format. Valid with the **/output** option only.|
|**/?**|Displays the command syntax and options for the tool.|

The following additional options are available for *.exe*, *.dll*, and *.winmd* files.

| Option | Description |
| ------ | ----------- |
|**/bytes**|Shows actual bytes, in hexadecimal format, as instruction comments.|
|**/caverbal**|Produces custom attribute blobs in verbal form. The default is binary form.|
|**/linenum**|Includes references to original source lines.|
|**/nobar**|Suppresses the disassembly progress indicator pop-up window.|
|**/noca**|Suppresses the output of custom attributes.|
|**/project**|Displays metadata the way it appears to managed code, instead of the way it appears in the native [!INCLUDE[wrt](../../../includes/wrt-md.md)]. If `PEfilename` is not a Windows metadata (*.winmd*) file, this option has no effect. See [.NET Framework Support for Windows Store Apps and Windows Runtime](../../../docs/standard/cross-platform/support-for-windows-store-apps-and-windows-runtime.md).|
|**/pubonly**|Disassembles only public types and members. Equivalent to **/visibility:PUB**.|
|**/quoteallnames**|Includes all names in single quotes.|
|**/raweh**|Shows exception handling clauses in raw form.|
|**/source**|Shows original source lines as comments.|
|**/tokens**|Shows metadata tokens of classes and members.|
|**/visibility:** `vis`[+`vis`...]|Disassembles only types or members with the specified visibility. The following are valid values for `vis`:<br /><br /> **PUB** — Public<br /><br /> **PRI** — Private<br /><br /> **FAM** — Family<br /><br /> **ASM** — Assembly<br /><br /> **FAA** — Family and Assembly<br /><br /> **FOA** — Family or Assembly<br /><br /> **PSC** — Private Scope<br /><br /> For definitions of these visibility modifiers, see <xref:System.Reflection.MethodAttributes> and <xref:System.Reflection.TypeAttributes>.|

The following options are valid for *.exe*, *.dll*, and *.winmd* files for file or console output only.

| Option | Description |
| ------ | ----------- |
|**/all**|Specifies a combination of the **/header**, **/bytes**, **/stats**, **/classlist**, and **/tokens** options.|
|**/classlist**|Includes a list of classes defined in the module.|
|**/forward**|Uses forward class declaration.|
|**/headers**|Includes file header information in the output.|
|**/item:** `class`[**::** `member`[`(sig`]]|Disassembles the following depending upon the argument supplied:<br /><br /> -   Disassembles the specified `class`.<br />-   Disassembles the specified `member` of the `class`.<br />-   Disassembles the `member` of the `class` with the specified signature `sig`. The format of `sig` is:<br />     [`instance`] `returnType`(`parameterType1`, `parameterType2`, …, `parameterTypeN`)<br />     **Note** In the .NET Framework versions 1.0 and 1.1, `sig` must be followed by a closing parenthesis: `(sig)`. Starting with the Net Framework 2.0 the closing parenthesis must be omitted: (`sig`.|
|**/noil**|Suppresses IL assembly code output.|
|**/stats**|Includes statistics on the image.|
|**/typelist**|Produces the full list of types, to preserve type ordering in a round trip.|
|**/unicode**|Uses Unicode encoding for the output.|
|**/utf8**|Uses UTF-8 encoding for the output. ANSI is the default.|

The following options are valid for *.exe*, *.dll*, *.obj*, *.lib*, and *.winmd* files for file or console output only.

| Option | Description |
| ------ | ----------- |
|**/metadata**[=`specifier`]|Shows metadata, where `specifier` is:<br /><br /> **MDHEADER** — Show the metadata header information and sizes.<br /><br /> **HEX** — Show information in hex as well as in words.<br /><br /> **CSV** — Show the record counts and heap sizes.<br /><br /> **UNREX** — Show unresolved externals.<br /><br /> **SCHEMA** — Show the metadata header and schema information.<br /><br /> **RAW** — Show the raw metadata tables.<br /><br /> **HEAPS** — Show the raw heaps.<br /><br /> **VALIDATE** — Validate the consistency of the metadata.<br /><br /> You can specify **/metadata** multiple times, with different values for `specifier`.|

The following options are valid for *.lib* files for file or console output only.

| Option | Description |
| ------ | ----------- |
|**/objectfile**=`filename`|Shows the metadata of a single object file in the specified library.|

> [!NOTE]
> All options for *Ildasm.exe* are case-insensitive and recognized by the first three letters. For example, **/quo** is equivalent to **/quoteallnames**. Options that specify arguments accept either a colon (:) or an equal sign (=) as the separator between the option and the argument. For example, **/output:** *filename* is equivalent to **/output=** *filename*.

## Remarks

*Ildasm.exe* only operates on PE files on disk. It does not operate on files installed in the global assembly cache.

The text file produced by *Ildasm.exe* can be used as input to the IL Assembler (*Ilasm.exe*). This is useful, for example, when compiling code in a programming language that does not support all the runtime metadata attributes. After compiling the code and running its output through *Ildasm.exe*, the resulting IL text file can be hand-edited to add the missing attributes. You can then run this text file through the IL Assembler to produce a final executable file.

> [!NOTE]
> Currently, you cannot use this technique with PE files that contain embedded native code (for example, PE files produced by Visual C++).  

You can use the default GUI in the IL Disassembler to view the metadata and disassembled code of any existing PE file in a hierarchical tree view. To use the GUI, type **ildasm** at the command line without supplying the *PEfilename* argument or any options. From the **File** menu, you can navigate to the PE file that you want to load into *Ildasm.exe*. To save the metadata and disassembled code displayed for the selected PE, select the **Dump** command from the **File** menu. To save the hierarchical tree view only, select the **Dump Treeview** command from the **File** menu. For a detailed guide to loading a file into *Ildasm.exe* and interpreting the output, see the *Ildasm.exe* Tutorial, located in the Samples folder that ships with the [!INCLUDE[winsdklong](../../../includes/winsdklong-md.md)].

If you provide *Ildasm.exe* with a *PEfilename* argument that contains embedded resources, the tool produces multiple output files: a text file that contains IL code and, for each embedded managed resource, a .resources file produced using the resource's name from metadata. If an unmanaged resource is embedded in *PEfilename*, a .res file is produced using the filename specified for IL output by the **/output** option.

> [!NOTE]
> *Ildasm.exe* shows only metadata descriptions for *.obj* and *.lib* input files. IL code for these file types is not disassembled.

You can run *Ildasm.exe* over an.exe or *.dll* file to determine whether the file is managed. If the file is not managed, the tool displays a message stating that the file has no valid common language runtime header and cannot be disassembled. If the file is managed, the tool runs successfully.

## Version Information

Starting with the [!INCLUDE[net_v45](../../../includes/net-v45-md.md)], *Ildasm.exe* handles an unrecognized marshal BLOB (binary large object) by displaying the raw binary content. For example, the following code shows how a marshal BLOB generated by a C# program is displayed:

```csharp
public void Test([MarshalAs((short)70)] int test) { }
```

```
// IL from Ildasm.exe output
.method public hidebysig instance void Test(int32  marshal({ 46 }) test) cil managed
```

Starting with the [!INCLUDE[net_v45](../../../includes/net-v45-md.md)], *Ildasm.exe* displays attributes that are applied to interface implementations, as shown in the following excerpt from *Ildasm.exe* output:

```
.class public auto ansi beforefieldinit MyClass
  extends [mscorlib]System.Object
  implements IMyInterface
  {
    .interfaceimpl type IMyInterface
    .custom instance void
      [mscorlib]System.Diagnostics.DebuggerNonUserCodeAttribute::.ctor() = ( 01 00 00 00 )
      …
```

## Examples

The following command causes the metadata and disassembled code for the PE file `MyHello.exe` to display in the *Ildasm.exe* default GUI.

```console
ildasm myHello.exe
```

The following command disassembles the file `MyFile.exe` and stores the resulting IL Assembler text in the file *MyFile.il*.

```console
ildasm MyFile.exe /output:MyFile.il
```

The following command disassembles the file `MyFile.exe` and displays the resulting IL Assembler text to the console window.

```console
ildasm MyFile.exe /text
```

If the file `MyApp.exe` contains embedded managed and unmanaged resources, the following command produces four files: *MyApp.il*, *MyApp.res*, *Icons.resources*, and *Message.resources*:

```console
ildasm MyApp.exe /output:MyApp.il
```

The following command disassembles the method `MyMethod` within the class `MyClass` in `MyFile.exe` and displays the output to the console window.

```console
ildasm /item:MyClass::MyMethod MyFile.exe /text
```

In the previous example, there could be several methods named `MyMethod` with different signatures. The following command disassembles the instance method `MyMethod` with the return type of **void** and the parameter types **int32** and **string**.

```console
ildasm /item:"MyClass::MyMethod(instance void(int32,string)" MyFile.exe /text
```

> [!NOTE]
> In the .NET Framework versions 1.0 and 1.1, the left parenthesis that follows the method name must be balanced by a right parenthesis after the signature: `MyMethod(instance void(int32))`. Starting with the .NET Framework 2.0 the closing parenthesis must be omitted: `MyMethod(instance void(int32)`.

To retrieve a `static` method (`Shared` method in Visual Basic), omit the keyword `instance`. Class types that are not primitive types like `int32` and `string` must include the namespace and must be preceded by the keyword `class`. External types must be preceded by the library name in square brackets. The following command disassembles a static method named `MyMethod` that has one parameter of type <xref:System.AppDomain> and has a return type of <xref:System.AppDomain>.

```console
ildasm /item:"MyClass::MyMethod(class [mscorlib]System.AppDomain(class [mscorlib]System.AppDomain)" MyFile.exe /text
```

A nested type must be preceded by its containing class, delimited by a forward slash. For example, if the `MyNamespace.MyClass` class contains a nested class named `NestedClass`, the nested class is identified as follows: `class MyNamespace.MyClass/NestedClass`.

## See also

[Tools](../../../docs/framework/tools/index.md)  
[Ilasm.exe (IL Assembler)](../../../docs/framework/tools/ilasm-exe-il-assembler.md)  
[Managed Execution Process](../../../docs/standard/managed-execution-process.md)  
[Command Prompts](../../../docs/framework/tools/developer-command-prompt-for-vs.md)
