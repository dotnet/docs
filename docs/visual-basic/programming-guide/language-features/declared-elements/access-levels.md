---
title: "Access Levels in Visual Basic"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "members [Visual Basic], accessing in Visual Basic"
  - "Friend access modifier"
  - "access levels, declared elements"
  - "access levels"
  - "access modifiers"
  - "Public access modifier"
  - "Protected access modifier"
  - "Protected Friend access modifier"
  - "Private access modifier"
  - "declared elements [Visual Basic], access level"
ms.assetid: 6e06c1ab-fd78-47f0-83a8-1152780b5e1a
caps.latest.revision: 16
author: dotnet-bot
ms.author: dotnetcontent
---
# Access Levels in Visual Basic
The *access level* of a declared element is the extent of the ability to access it, that is, what code has permission to read it or write to it. This is determined not only by how you declare the element itself, but also by the access level of the element's container. Code that cannot access a containing element cannot access any of its contained elements, even those declared as `Public`. For example, a `Public` variable in a `Private` structure can be accessed from inside the class that contains the structure, but not from outside that class.  
  
## Public  
 The [Public](../../../../visual-basic/language-reference/modifiers/public.md) keyword in the declaration statement specifies that the elements can be accessed from code anywhere in the same project, from other projects that reference the project, and from any assembly built from the project. The following code shows a sample `Public` declaration.  
  
```  
Public Class classForEverybody  
```  
  
 You can use `Public` only at module, interface, or namespace level. This means you can declare a public element at the level of a source file or namespace, or inside an interface, module, class, or structure, but not in a procedure.  
  
## Protected  
 The [Protected](../../../../visual-basic/language-reference/modifiers/protected.md) keyword in the declaration statement specifies that the elements can be accessed only from within the same class, or from a class derived from this class. The following code shows a sample `Protected` declaration.  
  
```  
Protected Class classForMyHeirs  
```  
  
 You can use `Protected` only at class level, and only when you declare a member of a class. This means you can declare a protected element in a class, but not at the level of a source file or namespace, or inside an interface, module, structure, or procedure.  
  
## Friend  
 The [Friend](../../../../visual-basic/language-reference/modifiers/friend.md) keyword in the declaration statement specifies that the elements can be accessed from within the same assembly, but not from outside the assembly. The following code shows a sample `Friend` declaration.  
  
```  
Friend stringForThisProject As String  
```  
  
 You can use `Friend` only at module, interface, or namespace level. This means you can declare a friend element at the level of a source file or namespace, or inside an interface, module, class, or structure, but not in a procedure.  
  
## Protected Friend  
 The `Protected` and `Friend` keywords together in the declaration statement specify that the elements can be accessed either from derived classes or from within the same assembly, or both. The following code shows a sample `Protected Friend` declaration.  
  
```  
Protected Friend stringForProjectAndHeirs As String  
```  
  
 You can use `Protected Friend` only at class level, and only when you declare a member of a class. This means you can declare a protected friend element in a class, but not at the level of a source file or namespace, or inside an interface, module, structure, or procedure.  
  
## Private  
 The [Private](../../../../visual-basic/language-reference/modifiers/private.md) keyword in the declaration statement specifies that the elements can be accessed only from within the same module, class, or structure. The following code shows a sample `Private` declaration.  
  
```  
Private numberForMeOnly As Integer  
```  
  
 You can use `Private` only at module level. This means you can declare a private element inside a module, class, or structure, but not at the level of a source file or namespace, inside an interface, or in a procedure.  
  
 At the module level, the `Dim` statement without any access level keywords is equivalent to a `Private` declaration. However, you might want to use the `Private` keyword to make your code easier to read and interpret.  
  
## Access Modifiers  
 The keywords that specify access level are called *access modifiers*. The following table compares the access modifiers.  
  
|Access modifier|Access level granted|Elements you can declare with this access level|Declaration context within which you can use this modifier|  
|---------------------|--------------------------|-----------------------------------------------------|----------------------------------------------------------------|  
|`Public`|Unrestricted:<br /><br /> Any code that can see a public element can access it|Interfaces<br /><br /> Modules<br /><br /> Classes<br /><br /> Structures<br /><br /> Structure members<br /><br /> Procedures<br /><br /> Properties<br /><br /> Member variables<br /><br /> Constants<br /><br /> Enumerations<br /><br /> Events<br /><br /> External declarations<br /><br /> Delegates|Source file<br /><br /> Namespace<br /><br /> Interface<br /><br /> Module<br /><br /> Class<br /><br /> Structure|  
|`Protected`|Derivational:<br /><br /> Code in the class that declares a protected element, or a class derived from it, can access the element|Interfaces<br /><br /> Classes<br /><br /> Structures<br /><br /> Procedures<br /><br /> Properties<br /><br /> Member variables<br /><br /> Constants<br /><br /> Enumerations<br /><br /> Events<br /><br /> External declarations<br /><br /> Delegates|Class|  
|`Friend`|Assembly:<br /><br /> Code in the assembly that declares a friend element can access it|Interfaces<br /><br /> Modules<br /><br /> Classes<br /><br /> Structures<br /><br /> Structure members<br /><br /> Procedures<br /><br /> Properties<br /><br /> Member variables<br /><br /> Constants<br /><br /> Enumerations<br /><br /> Events<br /><br /> External declarations<br /><br /> Delegates|Source file<br /><br /> Namespace<br /><br /> Interface<br /><br /> Module<br /><br /> Class<br /><br /> Structure|  
|`Protected` `Friend`|Union of `Protected` and `Friend`:<br /><br /> Code in the same class or the same assembly as a protected friend element, or within any class derived from the element's class, can access it|Interfaces<br /><br /> Classes<br /><br /> Structures<br /><br /> Procedures<br /><br /> Properties<br /><br /> Member variables<br /><br /> Constants<br /><br /> Enumerations<br /><br /> Events<br /><br /> External declarations<br /><br /> Delegates|Class|  
|`Private`|Declaration context:<br /><br /> Code in the type that declares a private element, including code within contained types, can access the element|Interfaces<br /><br /> Classes<br /><br /> Structures<br /><br /> Structure members<br /><br /> Procedures<br /><br /> Properties<br /><br /> Member variables<br /><br /> Constants<br /><br /> Enumerations<br /><br /> Events<br /><br /> External declarations<br /><br /> Delegates|Module<br /><br /> Class<br /><br /> Structure|  
  
## See Also  
 [Dim Statement](../../../../visual-basic/language-reference/statements/dim-statement.md)  
 [Static](../../../../visual-basic/language-reference/modifiers/static.md)  
 [Declared Element Names](../../../../visual-basic/programming-guide/language-features/declared-elements/declared-element-names.md)  
 [References to Declared Elements](../../../../visual-basic/programming-guide/language-features/declared-elements/references-to-declared-elements.md)  
 [Declared Element Characteristics](../../../../visual-basic/programming-guide/language-features/declared-elements/declared-element-characteristics.md)  
 [Lifetime in Visual Basic](../../../../visual-basic/programming-guide/language-features/declared-elements/lifetime.md)  
 [Scope in Visual Basic](../../../../visual-basic/programming-guide/language-features/declared-elements/scope.md)  
 [How to: Control the Availability of a Variable](../../../../visual-basic/programming-guide/language-features/declared-elements/how-to-control-the-availability-of-a-variable.md)  
 [Variables](../../../../visual-basic/programming-guide/language-features/variables/index.md)  
 [Variable Declaration](../../../../visual-basic/programming-guide/language-features/variables/variable-declaration.md)
