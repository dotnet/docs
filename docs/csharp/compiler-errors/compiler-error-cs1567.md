---
title: "Compiler Error CS1567"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.tgt_pltfrm: ""
ms.topic: "error-reference"
f1_keywords: 
  - "CS1567"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "CS1567"
ms.assetid: 837b9855-191b-4384-ad45-52960906679c
caps.latest.revision: 7
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
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
# Compiler Error CS1567
Error generating Win32 resource: 'file'  
  
 Your compilation either used the [/win32icon](../compiler-options/-win32icon--csharp-compiler-options-.md) compiler option or did not use [/win32res](../compiler-options/-win32res--csharp-compiler-options-.md), which causes the compiler to generate a file that contains resource information, but the compiler was unable to create the file due to insufficient disk space or some other error.  
  
 If you are unable to resolve the file-generation problem, you could use [/win32res](../compiler-options/-win32res--csharp-compiler-options-.md), which does not generate a file that contains resource information.