---
description: "C# Compiler Options to control Windows resources embedded in a dotnet application."
title: "C# Compiler Options - resource options"
ms.date: 03/12/2021
f1_keywords: 
  - "cs.build.options"
helpviewer_keywords: 
  - "Win32Resource compiler option [C#]"
  - "Win32Icon compiler option [C#]"
  - "Win32Manifest compiler option [C#]"
  - "NoWin32Manifest compiler option [C#]"
  - "Resources compiler option [C#]"
  - "LinkResources compiler option [C#]"
---
# C# Compiler Options that specify resources

The following options control how the C# compiler creates or imports Win32 resources. The new MSBuild syntax is shown in **Bold**. The older *csc.exe* syntax is shown in `code style`.

- **Win32Resource** / `-win32res`: Specify a Win32 resource file (.res).
- **Win32Icon** / `-win32icon`: Reference metadata from the specified assembly file or files.
- **Win32Manifest** / `-win32manifest`: Specify a Win32 manifest file (.xml).
- **NoWin32Manifest** / `-nowin32manifest`: Don't include the default Win32 manifest.
- **Resources** / `-resource`: Embed the specified resource (Short form: /res).
- **LinkResources** / `-linkresources`: Link the specified resource to this assembly.

## Win32Resource

The **Win32Resource** option inserts a Win32 resource in the output file.

```xml
<Win32Resource>filename</Win32Resource>
```

`filename` is the resource file that you want to add to your output file. A Win32 resource can contain version or bitmap (icon) information that would help identify your application in the File Explorer. If you don't specify this option, the compiler will generate version information based on the assembly version.

## Win32Icon

The **Win32Icon** option inserts an .ico file in the output file, which gives the output file the desired appearance in the File Explorer.
  
```xml
<Win32Icon>filename</Win32Icon>
```

`filename` is the *.ico* file that you want to add to your output file. An *.ico* file can be created with the [Resource Compiler](/windows/desktop/menurc/resource-compiler). The Resource Compiler is invoked when you compile a Visual C++ program; an *.ico* file is created from the *.rc* file.

## Win32Manifest

Use the **Win32Manifest** option to specify a user-defined Win32 application manifest file to be embedded into a project's portable executable (PE) file.

```xml
<Win32Manifest>filename</Win32Manifest>
```

`filename` is the name and location of the custom manifest file. By default, the C# compiler embeds an application manifest that specifies a requested execution level of "asInvoker". It creates the manifest in the same folder in which the executable is built. If you want to supply a custom manifest, for example to specify a requested execution level of "highestAvailable" or "requireAdministrator," use this option to specify the name of the file.

> [!NOTE]
> This option and the **Win32Resources** option are mutually exclusive. If you try to use both options in the same command line you will get a build error.

An application that has no application manifest that specifies a requested execution level will be subject to file and registry virtualization under the User Account Control feature in Windows. For more information, see [User Account Control](/windows/access-protection/user-account-control/user-account-control-overview).

Your application will be subject to virtualization if either of these conditions is true:
  
- You use the **NoWin32Manifest** option and you don't provide a manifest in a later build step or as part of a Windows Resource (*.res*) file by using the **Win32Resource** option.
- You provide a custom manifest that doesn't specify a requested execution level.

Visual Studio creates a default *.manifest* file and stores it in the debug and release directories alongside the executable file. You can add a custom manifest by creating one in any text editor and then adding the file to the project. Or, you can right-click the **Project** icon in **Solution Explorer**, select **Add New Item**, and then select **Application Manifest File**. After you've added your new or existing manifest file, it will appear in the **Manifest** drop down list. For more information, see [Application Page, Project Designer (C#)](/visualstudio/ide/reference/application-page-project-designer-csharp).

You can provide the application manifest as a custom post-build step or as part of a Win32 resource file by using the **NoWin32Manifest** option. Use that same option if you want your application to be subject to file or registry virtualization on Windows Vista.
  
## NoWin32Manifest

Use the **NoWin32Manifest** option to instruct the compiler not to embed any application manifest into the executable file.

```xml  
<NoWin32Manifest />
```

When this option is used, the application will be subject to virtualization on Windows Vista unless you provide an application manifest in a Win32 Resource file or during a later build step.

In Visual Studio, set this option in the **Application Property** page by selecting the **Create Application Without a Manifest** option in the **Manifest** drop down list. For more information, see [Application Page, Project Designer (C#)](/visualstudio/ide/reference/application-page-project-designer-csharp).

## Resources

Embeds the specified resource into the output file.

```xml
<Resources Include=filename>
  <LogicalName>identifier</LogicalName>
  <Access>accessibility-modifier</Access>
</Resources>
```

`filename` is the .NET resource file that you want to embed in the output file. `identifier` (optional) is the logical name for the resource; the name that is used to load the resource. The default is the name of the file. `accessibility-modifier` (optional) is the accessibility of the resource: public or private. The default is public. By default, resources are public in the assembly when they're created by using the C# compiler. To make the resources private, specify `private` as the accessibility modifier. No other accessibility other than `public` or `private` is allowed. If `filename` is a .NET resource file created, for example, by [Resgen.exe](../../../framework/tools/resgen-exe-resource-file-generator.md) or in the development environment, it can be accessed with members in the <xref:System.Resources> namespace. For more information, see <xref:System.Resources.ResourceManager?displayProperty=nameWithType>. For all other resources, use the `GetManifestResource` methods in the <xref:System.Reflection.Assembly> class to access the resource at run time. The order of the resources in the output file is determined from the order specified in the project file.  
  
## LinkResources

Creates a link to a .NET resource in the output file. The resource file isn't added to the output file. **LinkResources** differs from the **Resource** option, which does embed a resource file in the output file.

```xml
<LinkResources Include=filename>
  <LogicalName>identifier</LogicalName>
  <Access>accessibility-modifier</Access>
</LinkResources>
```

`filename` is the .NET resource file to which you want to link from the assembly. `identifier` (optional) is the logical name for the resource; the name that is used to load the resource. The default is the name of the file. `accessibility-modifier` (optional) is the accessibility of the resource: public or private. The default is public. By default, linked resources are public in the assembly when they're created with the C# compiler. To make the resources private, specify `private` as the accessibility modifier. No other modifier other than `public` or `private` is allowed. If `filename` is a .NET resource file created, for example, by [Resgen.exe](../../../framework/tools/resgen-exe-resource-file-generator.md) or in the development environment, it can be accessed with members in the <xref:System.Resources> namespace. For more information, see <xref:System.Resources.ResourceManager?displayProperty=nameWithType>. For all other resources, use the `GetManifestResource` methods in the <xref:System.Reflection.Assembly> class to access the resource at run time. The file specified in `filename` can be any format. For example, you may want to make a native DLL part of the assembly, so that it can be installed into the global assembly cache and accessed from managed code in the assembly. You can do the same thing in the Assembly Linker. For more information, see [Al.exe (Assembly Linker)](../../../framework/tools/al-exe-assembly-linker.md) and [Working with Assemblies and the Global Assembly Cache](../../../framework/app-domains/working-with-assemblies-and-the-gac.md).
