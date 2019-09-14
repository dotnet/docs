---
title: "Set assembly attributes"
ms.date: "08/20/2019"
helpviewer_keywords:
  - "assemblies [.NET Framework], attributes"
  - "assembly binding, attributes"
  - "assembly manifest, attributes"
ms.assetid: 36a98a81-b5b5-4c19-912a-11f91eff7f4e
author: "rpetrusha"
ms.author: "ronpet"
dev_langs:
  - "csharp"
  - "vb"
  - "cpp"
---
# Set assembly attributes

Assembly attributes are values that provide information about an assembly. The attributes are divided into the following sets of information:

- Assembly identity attributes

- Informational attributes

- Assembly manifest attributes

- Strong name attributes

## Assembly identity attributes

Three attributes, together with a strong name (if applicable), determine the identity of an assembly: name, version, and culture. These attributes form the full name of the assembly and are required when referencing the assembly in code. You can use attributes to set an assembly's version and culture. The compiler or the [Assembly Linker (Al.exe)](../../framework/tools/al-exe-assembly-linker.md) sets the name value when the assembly is created, based on the file containing the assembly manifest.

The following table describes the version and culture attributes.

|Assembly identity attribute|Description|
|---------------------------------|-----------------|
|<xref:System.Reflection.AssemblyCultureAttribute>|Enumerated field indicating the culture that the assembly supports. An assembly can also specify culture independence, indicating that it contains the resources for the default culture. **Note:**  The runtime treats any assembly that does not have the culture attribute set to null as a satellite assembly. Such assemblies are subject to satellite assembly binding rules. For more information, see [How the runtime locates assemblies](../../framework/deployment/how-the-runtime-locates-assemblies.md).|
|<xref:System.Reflection.AssemblyFlagsAttribute>|Value that sets assembly attributes, such as whether the assembly can be run side by side.|
|<xref:System.Reflection.AssemblyVersionAttribute>|Numeric value in the format *major*.*minor*.*build*.*revision* (for example, 2.4.0.0). The common language runtime uses this value to perform binding operations in strong-named assemblies. **Note:**  If the <xref:System.Reflection.AssemblyInformationalVersionAttribute> attribute is not applied to an assembly, the version number specified by the <xref:System.Reflection.AssemblyVersionAttribute> attribute is used by the <xref:System.Windows.Forms.Application.ProductVersion%2A?displayProperty=nameWithType>, <xref:System.Windows.Forms.Application.UserAppDataPath%2A?displayProperty=nameWithType>, and <xref:System.Windows.Forms.Application.UserAppDataRegistry%2A?displayProperty=nameWithType> properties.|

The following code example shows how to apply the version and culture attributes to an assembly.

```cpp
// Set version number for the assembly.
[assembly:AssemblyVersionAttribute("4.3.2.1")];
// Set culture as German.
[assembly:AssemblyCultureAttribute("de")];
```

```csharp
// Set version number for the assembly.
[assembly:AssemblyVersionAttribute("4.3.2.1")]
// Set culture as German.
[assembly:AssemblyCultureAttribute("de")]
```

```vb
' Set version number for the assembly.
<Assembly:AssemblyVersionAttribute("4.3.2.1")>
' Set culture as German.
<Assembly:AssemblyCultureAttribute("de")>
```

## Informational attributes

You can use informational attributes to provide additional company or product information for an assembly. The following table describes the informational attributes you can apply to an assembly.

|Informational attribute|Description|
|-----------------------------|-----------------|
|<xref:System.Reflection.AssemblyCompanyAttribute>|String value specifying a company name.|
|<xref:System.Reflection.AssemblyCopyrightAttribute>|String value specifying copyright information.|
|<xref:System.Reflection.AssemblyFileVersionAttribute>|String value specifying the Win32 file version number. This normally defaults to the assembly version.|
|<xref:System.Reflection.AssemblyInformationalVersionAttribute>|String value specifying version information that is not used by the common language runtime, such as a full product version number. **Note:**  If this attribute is applied to an assembly, the string it specifies can be obtained at run time by using the <xref:System.Windows.Forms.Application.ProductVersion%2A?displayProperty=nameWithType> property. The string is also used in the path and registry key provided by the <xref:System.Windows.Forms.Application.UserAppDataPath%2A?displayProperty=nameWithType> and <xref:System.Windows.Forms.Application.UserAppDataRegistry%2A?displayProperty=nameWithType> properties.|
|<xref:System.Reflection.AssemblyProductAttribute>|String value specifying product information.|
|<xref:System.Reflection.AssemblyTrademarkAttribute>|String value specifying trademark information.|

These attributes can appear on the Windows Properties page of the assembly, or they can be overridden using the **/win32res** compiler option to specify your own Win32 resource file.

## Assembly manifest attributes

You can use assembly manifest attributes to provide information in the assembly manifest, including title, description, the default alias, and configuration. The following table describes the assembly manifest attributes.

|Assembly manifest attribute|Description|
|---------------------------------|-----------------|
|<xref:System.Reflection.AssemblyConfigurationAttribute>|String value indicating the configuration of the assembly, such as Retail or Debug. The runtime does not use this value.|
|<xref:System.Reflection.AssemblyDefaultAliasAttribute>|String value specifying a default alias to be used by referencing assemblies. This value provides a friendly name when the name of the assembly itself is not friendly (such as a GUID value). This value can also be used as a short form of the full assembly name.|
|<xref:System.Reflection.AssemblyDescriptionAttribute>|String value specifying a short description that summarizes the nature and purpose of the assembly.|
|<xref:System.Reflection.AssemblyTitleAttribute>|String value specifying a friendly name for the assembly. For example, an assembly named *comdlg* might have the title Microsoft Common Dialog Control.|

## Strong name attributes

You can use strong name attributes to set a strong name for an assembly. The following table describes the strong name attributes.

|Strong name attribute|Description|
|----------------------------|-----------------|
|<xref:System.Reflection.AssemblyDelaySignAttribute>|Boolean value indicating that delay signing is being used.|
|<xref:System.Reflection.AssemblyKeyFileAttribute>|String value indicating the name of the file that contains either the public key (if using delay signing) or both the public and private keys passed as a parameter to the constructor of this attribute. Note that the file name is relative to the output file path (the *.exe* or *.dll*), not the source file path.|
|<xref:System.Reflection.AssemblyKeyNameAttribute>|Indicates the key container that contains the key pair passed as a parameter to the constructor of this attribute.|

The following code example shows the attributes to apply when using delay signing to create a strong-named assembly with a public key file called *myKey.snk*.

```cpp
[assembly:AssemblyKeyFileAttribute("myKey.snk")];
[assembly:AssemblyDelaySignAttribute(true)];
```

```csharp
[assembly:AssemblyKeyFileAttribute("myKey.snk")]
[assembly:AssemblyDelaySignAttribute(true)]
```

```vb
<Assembly:AssemblyKeyFileAttribute("myKey.snk")>
<Assembly:AssemblyDelaySignAttribute(True)>
```

## See also

- [Create assemblies](create.md)
- [Program with assemblies](program.md)
