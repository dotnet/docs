---
description: "Learn more about: <compiler> Element"
title: "<compiler> Element"
ms.date: 08/14/2018
f1_keywords:
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#compiler"
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/system.codedom/compilers/compiler"
helpviewer_keywords:
  - "compiler configuration elements, <compiler> element"
  - "<compiler> element"
  - "compiler configuration attributes"
  - "compiler element"
ms.assetid: 7a151659-b803-4c27-b5ce-1c4aa0d5a823
---
# \<compiler> Element

Specifies the compiler configuration attributes for a language provider.

[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.codedom>**](system-codedom-element.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<compilers>**](compilers-element.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<compiler>**

## Syntax

```xml
<compiler
  language="languageName[;...;...]"
  extension="fileExtension[;...;...]"
  type="typeName, assemblyName"
  warningLevel="number"
  compilerOptions="option1 option2"
/>
```

## Attributes and Elements

The following sections describe attributes, child elements, and parent elements.

### Attributes

|Attribute|Description|
|---------------|-----------------|
|`compilerOptions`|Optional attribute.<br /><br /> Specifies additional compiler-specific arguments for compilation. The values for the `compilerOptions` attribute are typically listed in a compiler options topic for the compiler.|
|`extension`|Required attribute.<br /><br /> Provides a semicolon-separated list of file name extensions used by source files for the language provider. For example, ".cs".|
|`language`|Required attribute.<br /><br /> Provides a semicolon-separated list of language names supported by the language provider. For example, "c#;cs;csharp".|
|`type`|Required attribute.<br /><br /> Specifies the type name of the language provider, including the name of the assembly containing the provider implementation. The type name must meet the requirements defined in [Specifying Fully Qualified Type Names](../../../reflection-and-codedom/specifying-fully-qualified-type-names.md).|
|`warningLevel`|Optional attribute.<br /><br /> Specifies the default compiler warning level; determines the level at which the language provider treats compilation warnings as errors.|

### Child Elements

|Element|Description|
|-------------|-----------------|
|[\<providerOption> Element](provideroption-element.md)|Specifies compiler version attributes for a language provider.|

### Parent Elements

|Element|Description|
|-------------|-----------------|
|[\<configuration> Element](../configuration-element.md)|The root element in every configuration file used by the common language runtime and .NET Framework applications.|
|[\<system.codedom> Element](system-codedom-element.md)|Specifies compiler configuration settings for available language providers.|
|[\<compilers> Element](compilers-element.md)|Container for compiler configuration elements; contains zero or more `<compiler>` elements.|

## Remarks

Each `<compiler>` element specifies the compiler configuration attributes for a specific language provider. The provider extends the <xref:System.CodeDom.Compiler.CodeDomProvider?displayProperty=nameWithType> class for a specific language; the `<compiler>` element defines the compiler and code generator settings for the language provider.

The .NET Framework defines the initial compiler settings in the machine configuration file (Machine.config). Developers and compiler vendors can add configuration settings for a new <xref:System.CodeDom.Compiler.CodeDomProvider> implementation. Use the <xref:System.CodeDom.Compiler.CodeDomProvider.GetAllCompilerInfo%2A?displayProperty=nameWithType> method to programmatically enumerate language provider and compiler configuration settings on a computer.

Compiler elements in the application or Web configuration file can supplement or override the settings in the machine configuration file. If more than one provider implementation is configured for the same language name or the same file extension, the last matching configuration overrides any previous configured providers for that language name or file extension.

## Configuration File

This element can be used in the machine configuration file and the application configuration file.

## Example

The following example illustrates a typical compiler configuration element:

```xml
<configuration>
  <system.codedom>
    <compilers>
      <!-- zero or more compiler elements -->
      <compiler
        language="c#;cs;csharp"
        extension=".cs"
        type="Microsoft.CSharp.CSharpCodeProvider, System,
          Version=2.0.3600.0, Culture=neutral,
          PublicKeyToken=b77a5c561934e089"
        compilerOptions="/optimize"
        warningLevel="1" />
    </compilers>
  </system.codedom>
</configuration>
```

## See also

- <xref:System.CodeDom.Compiler.CompilerInfo>
- <xref:System.CodeDom.Compiler.CodeDomProvider>
- [Configuration File Schema](../index.md)
- [\<compilers> Element](compilers-element.md)
- [Specifying Fully Qualified Type Names](../../../reflection-and-codedom/specifying-fully-qualified-type-names.md)
- [compiler Element for compilers for compilation (ASP.NET Settings Schema)](/previous-versions/dotnet/netframework-4.0/a15ebt6c(v=vs.100))
