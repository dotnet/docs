---
title: "How to: Display Command Line Arguments - C# Programming Guide"
ms.custom: seodec18
ms.date: 07/20/2015
helpviewer_keywords: 
  - "command-line arguments [C#], displaying"
ms.assetid: b8479f2d-9e05-4d38-82da-2e61246e5437
---
# How to: Display Command Line Arguments (C# Programming Guide)
Arguments provided to an executable on the command-line are accessible through an optional parameter to `Main`. The arguments are provided in the form of an array of strings. Each element of the array contains one argument. White-space between arguments is removed. For example, consider these command-line invocations of a fictitious executable:  
  
|Input on Command-line|Array of strings passed to Main|  
|----------------------------|-------------------------------------|  
|**executable.exe a b c**|"a"<br /><br /> "b"<br /><br /> "c"|  
|**executable.exe one two**|"one"<br /><br /> "two"|  
|**executable.exe "one two" three**|"one two"<br /><br /> "three"|  
  
> [!NOTE]
>  When you are running an application in Visual Studio, you can specify command-line arguments in the [Debug Page, Project Designer](/visualstudio/ide/reference/debug-page-project-designer).  
  
## Example  
 This example displays the command line arguments passed to a command-line application. The output shown is for the first entry in the table above.  
  
 [!code-csharp[csProgGuideMain#9](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideMain/CS/Class1.cs#9)]  
  
## See also

- [C# Programming Guide](../index.md)
- [Command-line Building With csc.exe](../../language-reference/compiler-options/command-line-building-with-csc-exe.md)
- [Main() and Command-Line Arguments](./index.md)
- [Main() Return Values](./main-return-values.md)
