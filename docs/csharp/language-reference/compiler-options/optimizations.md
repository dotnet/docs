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

- **FileAlignment**: Specify the size of sections in your output file.
- **Optimize**: Enable or disable compiler optimizations.

## FileAlignment

The **FileAlignment** option lets you specify the size of sections in your output file. The `number` argument specifies the size of sections in the output file. Valid values are 512, 1024, 2048, 4096, and 8192. These values are in bytes.
  
```xml
<FileAlignment>number</FileAlignment>
```

You set the **FileAlignment** option from the **Advanced** page of the **Build** properties for your project in Visual Studio.

Each section will be aligned on a boundary that is a multiple of the **FileAlignment** value. There is no fixed default. If **FileAlignment** is not specified, the common language runtime picks a default at compile time. By specifying the section size, you affect the size of the output file. Modifying section size may be useful for programs that will run on smaller devices. Use [DUMPBIN](/cpp/build/reference/dumpbin-options) to see information about sections in your output file.

## Optimize

The **Optimize** option enables or disables optimizations performed by the compiler to make your output file smaller, faster, and more efficient.

```xml
<Optimize>true</Optimize>
```

You set the **Optimize** option from **Build** properties page for your project in Visual Studio.

**Optimize** also tells the common language runtime to optimize code at runtime. By default, optimizations are disabled. Specify **Optimize+** to enable optimizations. When building a module to be used by an assembly, use the same **Optimize** settings as those of the assembly. It is possible to combine the **Optimize** and [Debug](./debug-compiler-option.md) options.
