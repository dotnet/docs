---
title: "First statement of this &#39;Sub New&#39; must be a call to &#39;MyBase.New&#39; or &#39;MyClass.New&#39; (No Accessible Constructor Without Parameters)"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "bc30148"
  - "vbc30148"
helpviewer_keywords: 
  - "BC30148"
ms.assetid: 4426e8fc-cb39-4eb8-ba95-503cd32fcc89
caps.latest.revision: 11
author: dotnet-bot
ms.author: dotnetcontent
---
# First statement of this &#39;Sub New&#39; must be a call to &#39;MyBase.New&#39; or &#39;MyClass.New&#39; (No Accessible Constructor Without Parameters)
First statement of this 'Sub New' must be a call to 'MyBase.New' or 'MyClass.New' because base class '\<basename>' of '\<derivedname>' does not have an accessible 'Sub New' that can be called with no arguments.  
  
 In a derived class, every constructor must call a base class constructor (`MyBase.New`). If the base class has a constructor with no parameters that is accessible to derived classes, `MyBase.New` can be called automatically. If not, a base class constructor must be called with parameters, and this cannot be done automatically. In this case, the first statement of every derived class constructor must call a parameterized constructor on the base class, or call another constructor in the derived class that makes a base class constructor call.  
  
 **Error ID:** BC30148  
  
## To correct this error  
  
-   Either call `MyBase.New` supplying the required parameters, or call a peer constructor that makes such a call.  
  
     For example, if the base class has a constructor that’s declared as `Public Sub New(ByVal index as Integer)`, the first statement in the derived class constructor might be `MyBase.New(100)`.  
  
## See Also  
 [Inheritance Basics](../../../visual-basic/programming-guide/language-features/objects-and-classes/inheritance-basics.md)
