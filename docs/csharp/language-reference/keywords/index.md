---
title: "C# Keywords"
ms.date: 03/07/2017
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "cs.keywords"
helpviewer_keywords: 
  - "keywords [C#]"
  - "C# language, keywords"
  - "Visual C#, keywords"
  - "@ keyword"
ms.assetid: e929b0f2-4b92-4d37-8060-23d323b098ad
caps.latest.revision: 22
author: "BillWagner"
ms.author: "wiwagn"
---
# C# Keywords
Keywords are predefined, reserved identifiers that have special meanings to the compiler. They cannot be used as identifiers in your program unless they include `@` as a prefix. For example, `@if` is a valid identifier, but `if` is not because `if` is a keyword.  
  
 The first table in this topic lists keywords that are reserved identifiers in any part of a C# program. The second table in this topic lists the contextual keywords in C#. Contextual keywords have special meaning only in a limited program context and can be used as identifiers outside that context. Generally, as new keywords are added to the C# language, they are added as contextual keywords in order to avoid breaking programs written in earlier versions.  
  
|||||  
|---|---|---|---|  
|[abstract](../../../csharp/language-reference/keywords/abstract.md)|[as](../../../csharp/language-reference/keywords/as.md)|[base](../../../csharp/language-reference/keywords/base.md)|[bool](../../../csharp/language-reference/keywords/bool.md)|  
|[break](../../../csharp/language-reference/keywords/break.md)|[byte](../../../csharp/language-reference/keywords/byte.md)|[case](../../../csharp/language-reference/keywords/switch.md)|[catch](../../../csharp/language-reference/keywords/try-catch.md)|  
|[char](../../../csharp/language-reference/keywords/char.md)|[checked](../../../csharp/language-reference/keywords/checked.md)|[class](../../../csharp/language-reference/keywords/class.md)|[const](../../../csharp/language-reference/keywords/const.md)|  
|[continue](../../../csharp/language-reference/keywords/continue.md)|[decimal](../../../csharp/language-reference/keywords/decimal.md)|[default](../../../csharp/language-reference/keywords/default.md)|[delegate](../../../csharp/language-reference/keywords/delegate.md)|  
|[do](../../../csharp/language-reference/keywords/do.md)|[double](../../../csharp/language-reference/keywords/double.md)|[else](../../../csharp/language-reference/keywords/if-else.md)|[enum](../../../csharp/language-reference/keywords/enum.md)|  
|[event](../../../csharp/language-reference/keywords/event.md)|[explicit](../../../csharp/language-reference/keywords/explicit.md)|[extern](../../../csharp/language-reference/keywords/extern.md)|[false](../../../csharp/language-reference/keywords/false.md)|  
|[finally](../../../csharp/language-reference/keywords/try-finally.md)|[fixed](../../../csharp/language-reference/keywords/fixed-statement.md)|[float](../../../csharp/language-reference/keywords/float.md)|[for](../../../csharp/language-reference/keywords/for.md)|  
|[foreach](../../../csharp/language-reference/keywords/foreach-in.md)|[goto](../../../csharp/language-reference/keywords/goto.md)|[if](../../../csharp/language-reference/keywords/if-else.md)|[implicit](../../../csharp/language-reference/keywords/implicit.md)|  
|[in](../../../csharp/language-reference/keywords/in.md)|[int](../../../csharp/language-reference/keywords/int.md)|[interface](../../../csharp/language-reference/keywords/interface.md)|[internal](../../../csharp/language-reference/keywords/internal.md)|
|[is](../../../csharp/language-reference/keywords/is.md)|[lock](../../../csharp/language-reference/keywords/lock-statement.md)|[long](../../../csharp/language-reference/keywords/long.md)|[namespace](../../../csharp/language-reference/keywords/namespace.md)|
|[new](../../../csharp/language-reference/keywords/new.md)|[null](../../../csharp/language-reference/keywords/null.md)|[object](../../../csharp/language-reference/keywords/object.md)|[operator](../../../csharp/language-reference/keywords/operator.md)|
|[out](../../../csharp/language-reference/keywords/out.md)|[override](../../../csharp/language-reference/keywords/override.md)|[params](../../../csharp/language-reference/keywords/params.md)|[private](../../../csharp/language-reference/keywords/private.md)|
|[protected](../../../csharp/language-reference/keywords/protected.md)|[public](../../../csharp/language-reference/keywords/public.md)|[readonly](../../../csharp/language-reference/keywords/readonly.md)|[ref](../../../csharp/language-reference/keywords/ref.md)|
|[return](../../../csharp/language-reference/keywords/return.md)|[sbyte](../../../csharp/language-reference/keywords/sbyte.md)|[sealed](../../../csharp/language-reference/keywords/sealed.md)|[short](../../../csharp/language-reference/keywords/short.md)||
[sizeof](../../../csharp/language-reference/keywords/sizeof.md)|[stackalloc](../../../csharp/language-reference/keywords/stackalloc.md)|[static](../../../csharp/language-reference/keywords/static.md)|[string](../../../csharp/language-reference/keywords/string.md)|
|[struct](../../../csharp/language-reference/keywords/struct.md)|[switch](../../../csharp/language-reference/keywords/switch.md)|[this](../../../csharp/language-reference/keywords/this.md)|[throw](../../../csharp/language-reference/keywords/throw.md)|
|[true](../../../csharp/language-reference/keywords/true.md)|[try](../../../csharp/language-reference/keywords/try-catch.md)|[typeof](../../../csharp/language-reference/keywords/typeof.md)|[uint](../../../csharp/language-reference/keywords/uint.md)|
|[ulong](../../../csharp/language-reference/keywords/ulong.md)|[unchecked](../../../csharp/language-reference/keywords/unchecked.md)|[unsafe](../../../csharp/language-reference/keywords/unsafe.md)|[ushort](../../../csharp/language-reference/keywords/ushort.md)|
|[using](../../../csharp/language-reference/keywords/using.md)|[using static](using-static.md)|[virtual](../../../csharp/language-reference/keywords/virtual.md)|[void](../../../csharp/language-reference/keywords/void.md)|
|[volatile](../../../csharp/language-reference/keywords/volatile.md)|[while](../../../csharp/language-reference/keywords/while.md)|

## Contextual Keywords  
 A contextual keyword is used to provide a specific meaning in the code, but it is not a reserved word in C#. Some contextual keywords, such as `partial` and `where`, have special meanings in two or more contexts.  
  
||||  
|---|---|---|  
|[add](../../../csharp/language-reference/keywords/add.md)|[alias](../../../csharp/language-reference/keywords/extern-alias.md)|[ascending](../../../csharp/language-reference/keywords/ascending.md)|  
|[async](../../../csharp/language-reference/keywords/async.md)|[await](../../../csharp/language-reference/keywords/await.md)|[descending](../../../csharp/language-reference/keywords/descending.md)|  
|[dynamic](../../../csharp/language-reference/keywords/dynamic.md)|[from](../../../csharp/language-reference/keywords/from-clause.md)|[get](../../../csharp/language-reference/keywords/get.md)|  
|[global](../../../csharp/language-reference/keywords/global.md)|[group](../../../csharp/language-reference/keywords/group-clause.md)|[into](../../../csharp/language-reference/keywords/into.md)|  
|[join](../../../csharp/language-reference/keywords/join-clause.md)|[let](../../../csharp/language-reference/keywords/let-clause.md)|[nameof](nameof.md)|   
|[orderby](../../../csharp/language-reference/keywords/orderby-clause.md)|[partial (type)](../../../csharp/language-reference/keywords/partial-type.md)|[partial (method)](../../../csharp/language-reference/keywords/partial-method.md)|   
|[remove](../../../csharp/language-reference/keywords/remove.md)|[select](../../../csharp/language-reference/keywords/select-clause.md)|[set](../../../csharp/language-reference/keywords/set.md)|   
|[value](../../../csharp/language-reference/keywords/value.md)|[var](../../../csharp/language-reference/keywords/var.md)|[when (filter condition)](when.md)|   
|[where (generic type constraint)](../../../csharp/language-reference/keywords/where-generic-type-constraint.md)|[where (query clause)](../../../csharp/language-reference/keywords/where-clause.md)|[yield](../../../csharp/language-reference/keywords/yield.md)|  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)
