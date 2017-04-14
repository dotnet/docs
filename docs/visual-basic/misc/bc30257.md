---
title: "Class &#39;&lt;classname&gt;&#39; cannot inherit from itself: &lt;message&gt; | Microsoft Docs"

ms.date: "2015-07-20"
ms.prod: .net


ms.technology: 
  - "devlang-visual-basic"

ms.topic: "article"
f1_keywords: 
  - "vbc30257"
  - "bc30257"
helpviewer_keywords: 
  - "BC30257"
ms.assetid: 03e3034c-a0fa-4619-84b9-5bc9aa0dfe80
caps.latest.revision: 8
author: dotnet-bot
ms.author: dotnetcontent

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
# Class &#39;&lt;classname&gt;&#39; cannot inherit from itself: &lt;message&gt;
An [Inherits Statement](../../visual-basic/language-reference/statements/inherits-statement.md) in a class definition specifies its own class.  
  
 A class can inherit from another class, which provides it with all the members of the class it inherits from, so it does not have to define those members again. Such a class is called a *derived class*, and the class it inherits from is called the *base class*.  
  
 It is meaningless for a class to inherit from itself, because it already possesses all its own members.  
  
 **Error ID:** BC30257  
  
## To correct this error  
  
1.  Check the spelling of the class name in the `Inherits` statement.  
  
2.  If you do not intend to inherit from a different class, remove the `Inherits` statement entirely.  
  
3.  Examine the cited message for suggestions.  
  
## See Also  
 [NOT IN BUILD: Inheritance in Visual Basic](http://msdn.microsoft.com/en-us/e5e6e240-ed31-4657-820c-079b7c79313c)   
 [NOT IN BUILD: Understanding Classes](http://msdn.microsoft.com/en-us/cc2355a2-cb98-4353-9440-736585aec46c)