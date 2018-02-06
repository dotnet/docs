---
title: "&#39;&lt;interfacename&gt;.&lt;membername&gt;&#39; is already implemented by the base class &#39;&lt;baseclassname&gt;&#39;. Re-implementation of &lt;type&gt; assumed"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vbc42015"
  - "bc42015"
helpviewer_keywords: 
  - "BC42015"
ms.assetid: 658c070a-113e-4bd8-b294-12c243191160
caps.latest.revision: 12
author: dotnet-bot
ms.author: dotnetcontent
---
# &#39;&lt;interfacename&gt;.&lt;membername&gt;&#39; is already implemented by the base class &#39;&lt;baseclassname&gt;&#39;. Re-implementation of &lt;type&gt; assumed
A property, procedure, or event in a derived class uses an `Implements` clause specifying an interface member that is already implemented in the base class.  
  
 A derived class can reimplement an interface member that is implemented by its base class. This is not the same as overriding the base class implementation. For more information, see [Implements](../../../visual-basic/language-reference/statements/implements-clause.md).  
  
 By default, this message is a warning. For information on hiding warnings or treating warnings as errors, see [Configuring Warnings in Visual Basic](/visualstudio/ide/configuring-warnings-in-visual-basic).  
  
 **Error ID:** BC42015  
  
## To correct this error  
  
-   If you intend to reimplement the interface member, you do not need to take any action. Code in your derived class accesses the reimplemented member unless you use the `MyBase` keyword to access the base class implementation.  
  
-   If you do not intend to reimplement the interface member, remove the `Implements` clause from the property, procedure, or event declaration.  
  
## See Also  
 [Interfaces](../../../visual-basic/programming-guide/language-features/interfaces/index.md)
