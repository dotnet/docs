---
description: "C# Compiler Options that affect optimizations"
title: "C# Compiler Options - Optimization options"
ms.date: 02/18/2021
f1_keywords: 
  - "cs.build.options"
helpviewer_keywords: 
  - "FileAlignment compiler option [C#]"
  - "Optimize compiler option [C#]"
---
# C# Compiler Options for optimization

The following options control compiler optimizations for size and speed. The new MSBuild syntax is shown in **Bold**. The older `csc.exe` syntax is shown in `code style`.

- **FileAlignment** / `-filealign`: Specify the size of sections in your output file.
- **Optimize** / `-optimize`: Enable or disable compiler optimizations.

## FileAlignment

The **FileAlignment** option lets you specify the size of sections in your output file. The `number` argument specifies the size of sections in the output file. Valid values are 512, 1024, 2048, 4096, and 8192. These values are in bytes.
  
```xml
<FileAlignment>number</FileAlignment>
```

You set the **FileAlignment** option from the **Advanced** page of the **Build** properties for your project in Visual Studio.

Each section will be aligned on a boundary that is a multiple of the **FileAlignment** value. There's no fixed default. If **FileAlignment** is not specified, the common language runtime picks a default at compile time. By specifying the section size, you affect the size of the output file. Modifying section size may be useful for programs that will run on smaller devices. Use [DUMPBIN](/cpp/build/reference/dumpbin-options) to see information about sections in your output file.
