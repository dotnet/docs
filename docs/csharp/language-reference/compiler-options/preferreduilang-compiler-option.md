---
title: "-preferreduilang (C# Compiler Options)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "/preferreduilang"
helpviewer_keywords: 
  - "preferreduilang compiler option [C#]"
  - "/preferreduilang compiler option [C#]"
  - "-preferreduilang compiler option [C#]"
ms.assetid: 68b2462f-6778-48d7-8052-62805fe8e02c
caps.latest.revision: 15
author: "BillWagner"
ms.author: "wiwagn"
---
# -preferreduilang (C# Compiler Options)
By using the `-preferreduilang` compiler option, you can specify the language in which the C# compiler displays output, such as error messages.  
  
## Syntax  
  
```console  
-preferreduilang: language  
```  
  
## Arguments  
 `language`  
 The [language name](https://msdn.microsoft.com/library/windows/desktop/dd318696(v=vs.85).aspx) of the language to use for compiler output.  
  
## Remarks  
 You can use the `-preferreduilang` compiler option to specify the language that you want the C# compiler to use for error messages and other command-line output. If the language pack for the language is not installed, the language setting of the operating system is used instead, and no error is reported.  
  
```csharp  
csc.exe -preferreduilang:ja-JP  
```  
  
## Requirements  
  
## See Also  
 [C# Compiler Options](../../../csharp/language-reference/compiler-options/index.md)
