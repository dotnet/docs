---
title: "-unsafe (C# Compiler Options)"
ms.date: 04/25/2018
f1_keywords: 
  - "/unsafe"
helpviewer_keywords: 
  - "-unsafe compiler option [C#]"
  - "unsafe compiler option [C#]"
  - "/unsafe compiler option [C#]"
---
# -unsafe (C# Compiler Options)

The **-unsafe** compiler option allows code that uses the [unsafe](../keywords/unsafe.md) keyword to compile.  
  
## Syntax  
  
```console  
-unsafe  
```  
  
## Remarks

For more information about unsafe code, see [Unsafe Code and Pointers](../../programming-guide/unsafe-code-pointers/index.md).  
  
### To set this compiler option in the Visual Studio development environment  
  
1. Open the project's **Properties** page.  
  
2. Click the **Build** property page.  
  
3. Select the **Allow Unsafe Code** check box.  
  
### To add this option in a csproj file

Open the .csproj file for a project, and add the following elements:

```xml
  <PropertyGroup>
    <AllowUnsafeBlocks>true</AllowUnsafeBlocks>
  </PropertyGroup>
```

 For information about how to set this compiler option programmatically, see <xref:VSLangProj80.CSharpProjectConfigurationProperties3.AllowUnsafeBlocks%2A>.  
  
## Example

Compile `in.cs` for unsafe mode:  
  
```console  
csc -unsafe in.cs  
```  
  
## See also

- [C# Compiler Options](index.md)
- [Managing Project and Solution Properties](/visualstudio/ide/managing-project-and-solution-properties)
