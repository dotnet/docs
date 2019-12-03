---
title: "-codepage (C# Compiler Options)"
ms.date: 07/20/2015
f1_keywords: 
  - "/codepage"
helpviewer_keywords: 
  - "/codepage compiler option [C#]"
  - "codepage compiler option [C#]"
  - "-codepage compiler option [C#]"
ms.assetid: 75942989-b69a-4308-90a0-840c73d2c478
---
# -codepage (C# Compiler Options)
This option specifies which codepage to use during compilation if the required page is not the current default codepage for the system.  
  
## Syntax  
  
```console  
-codepage:id  
```  
  
## Arguments  
 `id`  
 The id of the code page to use for all source code files in the compilation.  
  
## Remarks  
 The compiler will first attempt to interpret all source files as UTF-8. If your source code files are in an encoding other than UTF-8 and use characters other than 7-bit ASCII characters, use the **-codepage** option to specify which code page should be used. **-codepage** applies to all source code files in your compilation.  
    
 See [GetCPInfo](/windows/desktop/api/winnls/nf-winnls-getcpinfo) for information on how to find which code pages are supported on your system.  
  
 This compiler option is unavailable in Visual Studio and cannot be changed programmatically.  
  
## See also

- [C# Compiler Options](./index.md)
- [Managing Project and Solution Properties](/visualstudio/ide/managing-project-and-solution-properties)
