---
title: "Compiler Error CS0468 | Microsoft Docs"
ms.custom: ""
ms.date: "11/04/2016"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.tgt_pltfrm: ""
ms.topic: "article"
f1_keywords: 
  - "CS0468"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "CS0468"
ms.assetid: 1ec4f8af-0b32-4ea9-8bc0-bb9e52b9457b
caps.latest.revision: 8
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
translation.priority.ht: 
  - "de-de"
  - "es-es"
  - "fr-fr"
  - "it-it"
  - "ja-jp"
  - "ko-kr"
  - "ru-ru"
  - "zh-cn"
  - "zh-tw"
translation.priority.mt: 
  - "cs-cz"
  - "pl-pl"
  - "pt-br"
  - "tr-tr"
---
# Compiler Error CS0468
Ambiguity between type 'type1' and type 'type2'  
  
 This error is generated when there are two types in the assembly being compiled that have the same fully qualified name. This could occur if they are both in added modules or one is in an added module and one in source.