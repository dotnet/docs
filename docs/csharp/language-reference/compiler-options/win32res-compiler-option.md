---
title: "-win32res (C# Compiler Options) | Microsoft Docs"
ms.date: "2015-07-20"
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "/win32res"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "win32res compiler option"
  - "/win32res compiler option [C#]"
  - "-win32res compiler option [C#]"
  - "win32res compiler option [C#]"
ms.assetid: 3c33f750-6948-4c7e-a27e-bef98f77255b
caps.latest.revision: 16
author: "BillWagner"
ms.author: "wiwagn"
translation.priority.ht: 
  - "cs-cz"
  - "de-de"
  - "es-es"
  - "fr-fr"
  - "it-it"
  - "ja-jp"
  - "ko-kr"
  - "pl-pl"
  - "pt-br"
  - "ru-ru"
  - "tr-tr"
  - "zh-cn"
  - "zh-tw"
---
# /win32res (C# Compiler Options)
The **/win32res** option inserts a Win32 resource in the output file.  
  
## Syntax  
  
```  
/win32res:filename  
```  
  
## Arguments  
 `filename`  
 The resource file that you want to add to your output file.  
  
## Remarks  
 A Win32 resource file can be created with the [Resource Compiler](http://go.microsoft.com/fwlink/?LinkId=148370). The Resource Compiler is invoked when you compile a Visual C++ program; a .res file is created from the .rc file.  
  
 A Win32 resource can contain version or bitmap (icon) information that would help identify your application in the File Explorer. If you do not specify **/win32res**, the compiler will generate version information based on the assembly version.  
  
 See [/linkresource](../../../csharp/language-reference/compiler-options/linkresource-compiler-option.md) (to reference) or [/resource](../../../csharp/language-reference/compiler-options/resource-compiler-option.md) (to attach) a .NET Framework resource file.  
  
### To set this compiler option in the Visual Studio development environment  
  
1.  Open the project's **Properties** page.  
  
2.  Click the **Application** property page.  
  
3.  Click on the **Resource File** button and choose a file by using the combo box.  
  
## Example  
 Compile `in.cs` and attach a Win32 resource file `rf.res` to produce `in.exe`:  
  
```  
csc /win32res:rf.res in.cs  
```  
  
## See Also  
 [C# Compiler Options](../../../csharp/language-reference/compiler-options/index.md)   
 [NIB How to: Modify Project Properties and Configuration Settings](http://msdn.microsoft.com/en-us/e7184bc5-2f2b-4b4f-aa9a-3ecfcbc48b67)