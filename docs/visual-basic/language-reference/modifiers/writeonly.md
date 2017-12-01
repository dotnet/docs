---
title: "WriteOnly (Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "WriteOnly"
  - "vb.WriteOnly"
helpviewer_keywords: 
  - "write-only properties"
  - "WriteOnly keyword [Visual Basic]"
  - "sensitive data, protecting"
  - "properties [Visual Basic], write-only"
  - "sensitive data"
ms.assetid: 488d2899-b09f-4cee-92f0-6f9f9fc4f944
caps.latest.revision: 16
author: dotnet-bot
ms.author: dotnetcontent
---
# WriteOnly (Visual Basic)
Specifies that a property can be written but not read.  
  
## Remarks  
  
## Rules  
 **Declaration Context.** You can use `WriteOnly` only at module level. This means the declaration context for a `WriteOnly` property must be a class, structure, or module, and cannot be a source file, namespace, or procedure.  
  
 You can declare a property as `WriteOnly`, but not a variable.  
  
## When to Use WriteOnly  
 Sometimes you want the consuming code to be able to set a value but not discover what it is. For example, sensitive data, such as a social registration number or a password, needs to be protected from access by any component that did not set it. In these cases, you can use a `WriteOnly` property to set the value.  
  
> [!IMPORTANT]
>  When you define and use a `WriteOnly` property, consider the following additional protective measures:  
  
-   **Overriding.** If the property is a member of a class, allow it to default to [NotOverridable](../../../visual-basic/language-reference/modifiers/notoverridable.md), and do not declare it `Overridable` or `MustOverride`. This prevents a derived class from making undesired access through an override.  
  
-   **Access Level.** If you hold the property's sensitive data in one or more variables, declare them [Private](../../../visual-basic/language-reference/modifiers/private.md) so that no other code can access them.  
  
-   **Encryption.** Store all sensitive data in encrypted form rather than in plain text. If malicious code somehow gains access to that area of memory, it is more difficult to make use of the data. Encryption is also useful if it is necessary to serialize the sensitive data.  
  
-   **Resetting.** When the class, structure, or module defining the property is being terminated, reset the sensitive data to default values or to other meaningless values. This gives extra protection when that area of memory is freed for general access.  
  
-   **Persistence.** Do not persist any sensitive data, for example on disk, if you can avoid it. Also, do not write any sensitive data to the Clipboard.  
  
 The `WriteOnly` modifier can be used in this context:  
  
 [Property Statement](../../../visual-basic/language-reference/statements/property-statement.md)  
  
## See Also  
 [ReadOnly](../../../visual-basic/language-reference/modifiers/readonly.md)  
 [Private](../../../visual-basic/language-reference/modifiers/private.md)  
 [Keywords](../../../visual-basic/language-reference/keywords/index.md)
