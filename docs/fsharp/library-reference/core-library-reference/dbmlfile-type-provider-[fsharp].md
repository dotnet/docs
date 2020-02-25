---
title: DbmlFile Type Provider (F#)
description: DbmlFile Type Provider (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 23365adb-4c04-4b74-9ec3-9bb921cc55d3 
---

# DbmlFile Type Provider (F#)

Provides the types for a database schema encoded in a `.dbml` file, the database schema format used by LINQ to SQL. `.dbml` files contain a schema for a database.

**Namespace/Module Path:** Microsoft.FSharp.Data.TypeProviders

**Assembly:** FSharp.Data.TypeProviders (in FSharp.Data.TypeProviders.dll)


## Syntax

```fsharp
type DbmlFile<File : string,              
                     ?ResolutionFolder : string,
                     ?ContextTypeName : string,
                     ?Serializable : bool>
```

## Static Type Parameters


|Type Parameter|Description|
|--------------|-----------|
|File : string|The path to the DBML file for the database mapping.|
|?ResolutionFolder : string|A folder to be used to resolve relative file paths at compile time. The default value is the folder that contains the project or script.|
|?ContextTypeName : string|The name of the container type that you use to access all the generated types.|
|?Serializable : bool|`true` if you want the generated types to be serializable. The default is `false`.|

## Remarks
The `.dbml` file is an XML file that contains the full description or schema for a relational database. DBML stands for Database Modeling Language and is the database schema format that LINQ to SQL uses. You can generate a `.dbml` file by using the command-line tool, `SQLMetal.exe`. For more information on `SQLMetal.exe`, see [SqlMetal.exe &#40;Code Generation Tool&#41;](https://msdn.microsoft.com/library/bb386987). For more information on LINQ to SQL, see [LINQ to SQL](https://msdn.microsoft.com/library/bb386976).

For a walkthrough on how to use the **DbmlFile** type provider, see [Walkthrough: Generating F&#35; Types from a DBML File &#40;F&#35;&#41;](Walkthrough-Generating-FSharp-Types-from-a-DBML-File-%5BFSharp%5D.md).


## Platforms
Windows 8.1, Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)