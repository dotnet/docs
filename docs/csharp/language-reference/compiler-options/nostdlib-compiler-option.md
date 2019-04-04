---
title: "-nostdlib (C# Compiler Options)"
ms.date: 07/20/2015
f1_keywords:
  - "/nostdlib"
helpviewer_keywords:
  - "nostdlib compiler option [C#]"
  - "-nostdlib compiler option [C#]"
  - "/nostdlib compiler option [C#]"
ms.assetid: ec197989-fa49-4725-a455-e06b551eb65f
---
# -nostdlib (C# Compiler Options)

**-nostdlib** prevents the import of mscorlib.dll, which defines the entire System namespace.

## Syntax

```console
-nostdlib[+ | -]
```

## Remarks

Use this option if you want to define or create your own System namespace and objects.

If you do not specify **-nostdlib**, mscorlib.dll is imported into your program (same as specifying **-nostdlib-**). Specifying **-nostdlib** is the same as specifying **-nostdlib+**.

### To set this compiler option in Visual Studio

> [!NOTE]
> The following instructions apply to Visual Studio 2015 (and earlier versions) only. The **Do not reference mscorlib.dll** build property doesn't exist in Visual Studio 2017.

1. Open the **Properties** page for the project.

2. Click the **Build** properties page.

3. Click the **Advanced** button.

4. Modify the **Do not reference mscorlib.dll** property.

### To set this compiler option programmatically

For information on how to set this compiler option programmatically, see <xref:VSLangProj80.CSharpProjectConfigurationProperties3.NoStdLib%2A>.

## See also

- [C# Compiler Options](../../../csharp/language-reference/compiler-options/index.md)
