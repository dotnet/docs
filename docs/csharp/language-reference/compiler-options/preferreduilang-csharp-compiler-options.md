---
title: "-preferreduilang (C# Compiler Options) | Microsoft Docs"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.tgt_pltfrm: ""
ms.topic: "article"
f1_keywords: 
  - "/preferreduilang"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "preferreduilang compiler option [C#]"
  - "/preferreduilang compiler option [C#]"
  - "-preferreduilang compiler option [C#]"
ms.assetid: 68b2462f-6778-48d7-8052-62805fe8e02c
caps.latest.revision: 15
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
---
# /preferreduilang (C# Compiler Options)
[!INCLUDE[csharpbanner](../../../includes/csharpbanner.md)]

By using the `/preferreduilang` compiler option, you can specify the language in which the C# compiler displays output, such as error messages.  
  
## Syntax  
  
```  
/preferreduilang: language  
```  
  
## Arguments  
 `language`  
 The [language name](http://go.microsoft.com/fwlink/p/?LinkId=236992) of the language to use for compiler output.  
  
## Remarks  
 You can use the `/preferreduilang` compiler option to specify the language that you want the C# compiler to use for error messages and other command-line output. If the language pack for the language is not installed, the language setting of the operating system is used instead, and no error is reported.  
  
```csharp  
csc.exe /preferreduilang:ja-JP  
```  
  
## Requirements  
  
## See Also  
 [C# Compiler Options](../../../csharp/language-reference/compiler-options/index.md)