---
title: "C# Keywords"
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
  - "cs.keywords"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "keywords [C#]"
  - "C# language, keywords"
  - "Visual C#, keywords"
  - "@ keyword"
ms.assetid: e929b0f2-4b92-4d37-8060-23d323b098ad
caps.latest.revision: 22
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
# C# Keywords
Keywords are predefined, reserved identifiers that have special meanings to the compiler. They cannot be used as identifiers in your program unless they include `@` as a prefix. For example, `@if` is a valid identifier but `if` is not because `if` is a keyword.  
  
 The first table in this topic lists keywords that are reserved identifiers in any part of a C# program. The second table in this topic lists the contextual keywords in C#. Contextual keywords have special meaning only in a limited program context and can be used as identifiers outside that context. Generally, as new keywords are added to the C# language, they are added as contextual keywords in order to avoid breaking programs written in earlier versions.  
  
|||||  
|-|-|-|-|  
|[abstract](../keywords/abstract--csharp-reference-.md)|[as](../keywords/as--csharp-reference-.md)|[base](../keywords/base--csharp-reference-.md)|[bool](../keywords/bool--csharp-reference-.md)|  
|[break](../keywords/break--csharp-reference-.md)|[byte](../keywords/byte--csharp-reference-.md)|[case](../keywords/switch--csharp-reference-.md)|[catch](../keywords/try-catch--csharp-reference-.md)|  
|[char](../keywords/char--csharp-reference-.md)|[checked](../keywords/checked--csharp-reference-.md)|[class](../keywords/class--csharp-reference-.md)|[const](../keywords/const--csharp-reference-.md)|  
|[continue](../keywords/continue--csharp-reference-.md)|[decimal](../keywords/decimal--csharp-reference-.md)|[default](../keywords/default--csharp-reference-.md)|[delegate](../keywords/delegate--csharp-reference-.md)|  
|[do](../keywords/do--csharp-reference-.md)|[double](../keywords/double--csharp-reference-.md)|[else](../keywords/if-else--csharp-reference-.md)|[enum](../keywords/enum--csharp-reference-.md)|  
|[event](../keywords/event--csharp-reference-.md)|[explicit](../keywords/explicit--csharp-reference-.md)|[extern](../keywords/extern--csharp-reference-.md)|[false](../keywords/false--csharp-reference-.md)|  
|[finally](../keywords/try-finally--csharp-reference-.md)|[fixed](../keywords/fixed-statement--csharp-reference-.md)|[float](../keywords/float--csharp-reference-.md)|[for](../keywords/for--csharp-reference-.md)|  
|[foreach](../keywords/foreach--in--csharp-reference-.md)|[goto](../keywords/goto--csharp-reference-.md)|[if](../keywords/if-else--csharp-reference-.md)|[implicit](../keywords/implicit--csharp-reference-.md)|  
|[in](../keywords/foreach--in--csharp-reference-.md)|[in (generic modifier)](../keywords/in--generic-modifier---csharp-reference-.md)|[int](../keywords/int--csharp-reference-.md)|[interface](../keywords/interface--csharp-reference-.md)|  
|[internal](../keywords/internal--csharp-reference-.md)|[is](../keywords/is--csharp-reference-.md)|[lock](../keywords/lock-statement--csharp-reference-.md)|[long](../keywords/long--csharp-reference-.md)|  
|[namespace](../keywords/namespace--csharp-reference-.md)|[new](../keywords/new--csharp-reference-.md)|[null](../keywords/null--csharp-reference-.md)|[object](../keywords/object--csharp-reference-.md)|  
|[operator](../keywords/operator--csharp-reference-2.md)|[out](../keywords/out--csharp-reference-.md)|[out (generic modifier)](../keywords/out--generic-modifier---csharp-reference-.md)|[override](../keywords/override--csharp-reference-.md)|  
|[params](../keywords/params--csharp-reference-.md)|[private](../keywords/private--csharp-reference-.md)|[protected](../keywords/protected--csharp-reference-.md)|[public](../keywords/public--csharp-reference-.md)|  
|[readonly](../keywords/readonly--csharp-reference-.md)|[ref](../keywords/ref--csharp-reference-.md)|[return](../keywords/return--csharp-reference-.md)|[sbyte](../keywords/sbyte--csharp-reference-.md)|  
|[sealed](../keywords/sealed--csharp-reference-.md)|[short](../keywords/short--csharp-reference-.md)|[sizeof](../keywords/sizeof--csharp-reference-.md)|[stackalloc](../keywords/stackalloc--csharp-reference-.md)|  
|[static](../keywords/static--csharp-reference-.md)|[string](../keywords/string--csharp-reference-.md)|[struct](../keywords/struct--csharp-reference-.md)|[switch](../keywords/switch--csharp-reference-.md)|  
|[this](../keywords/this--csharp-reference-.md)|[throw](../keywords/throw--csharp-reference-.md)|[true](../keywords/true--csharp-reference-.md)|[try](../keywords/try-catch--csharp-reference-.md)|  
|[typeof](../keywords/typeof--csharp-reference-.md)|[uint](../keywords/uint--csharp-reference-.md)|[ulong](../keywords/ulong--csharp-reference-.md)|[unchecked](../keywords/unchecked--csharp-reference-.md)|  
|[unsafe](../keywords/unsafe--csharp-reference-.md)|[ushort](../keywords/ushort--csharp-reference-.md)|[using](../keywords/using--csharp-reference-.md)|[virtual](../keywords/virtual--csharp-reference-.md)|  
|[void](../keywords/void--csharp-reference-.md)|[volatile](../keywords/volatile--csharp-reference-.md)|[while](../keywords/while--csharp-reference-.md)||  
  
## Contextual Keywords  
 A contextual keyword is used to provide a specific meaning in the code, but it is not a reserved word in C#. Some contextual keywords, such as `partial` and `where`, have special meanings in two or more contexts.  
  
||||  
|-|-|-|  
|[add](../keywords/add--csharp-reference-.md)|[alias](../keywords/extern-alias--csharp-reference-.md)|[ascending](../keywords/ascending--csharp-reference-.md)|  
|[async](../keywords/async--csharp-reference-.md)|[await](../keywords/await--csharp-reference-.md)|[descending](../keywords/descending--csharp-reference-.md)|  
|[dynamic](../keywords/dynamic--csharp-reference-.md)|[from](../keywords/from-clause--csharp-reference-.md)|[get](../keywords/get--csharp-reference-.md)|  
|[global](../keywords/global--csharp-reference-.md)|[group](../keywords/group-clause--csharp-reference-.md)|[into](../keywords/into--csharp-reference-.md)|  
|[join](../keywords/join-clause--csharp-reference-.md)|[let](../keywords/let-clause--csharp-reference-.md)|[orderby](../keywords/orderby-clause--csharp-reference-.md)|  
|[partial (type)](../keywords/partial--type---csharp-reference-.md)|[partial (method)](../keywords/partial--method---csharp-reference-.md)|[remove](../keywords/remove--csharp-reference-.md)|  
|[select](../keywords/select-clause--csharp-reference-.md)|[set](../keywords/set--csharp-reference-.md)|[value](../keywords/value--csharp-reference-.md)|  
|[var](../keywords/var--csharp-reference-.md)|[where (generic type constraint)](../keywords/where--generic-type-constraint---csharp-reference-.md)|[where (query clause)](../keywords/where-clause--csharp-reference-.md)|  
|[yield](../keywords/yield--csharp-reference-.md)||  
  
## See Also  
 [C# Reference](../language-reference/csharp-reference.md)   
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)