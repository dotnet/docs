---
title: "-preferreduilang (C# Compiler Options) | Microsoft Docs"
ms.date: "2015-07-20"
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
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
# /preferreduilang (C# Compiler Options)
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