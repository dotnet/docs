---
title: "How to display command-line arguments"
description: Learn how to display command-line arguments. See a code example and view additional available resources.
ms.date: 03/08/2021
ms.topic: how-to
helpviewer_keywords: 
  - "command-line arguments [C#], displaying"
ms.assetid: b8479f2d-9e05-4d38-82da-2e61246e5437
---
# How to display command-line arguments

Arguments provided to an executable on the command line are accessible in [top-level statements](../program-structure/top-level-statements.md) or through an optional parameter to `Main`. The arguments are provided in the form of an array of strings. Each element of the array contains one argument. White-space between arguments is removed. For example, consider these command-line invocations of a fictitious executable:  
  
|Input on command line|Array of strings passed to Main|  
|----------------------------|-------------------------------------|  
|**executable.exe a b c**|"a"<br /><br /> "b"<br /><br /> "c"|  
|**executable.exe one two**|"one"<br /><br /> "two"|  
|**executable.exe "one two" three**|"one two"<br /><br /> "three"|  
  
> [!NOTE]
> When you are running an application in Visual Studio, you can specify command-line arguments in the [Debug Page, Project Designer](/visualstudio/ide/reference/debug-page-project-designer).  
  
## Example  

 This example displays the command-line arguments passed to a command-line application. The output shown is for the first entry in the table above.  
  
 :::code language="csharp" source="./snippets/command-line-arguments/Program.cs" :::
