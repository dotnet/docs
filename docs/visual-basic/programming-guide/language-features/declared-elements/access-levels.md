---
title: "Access Levels in Visual Basic"
ms.date: 05/10/2018
helpviewer_keywords: 
  - "members [Visual Basic], accessing in Visual Basic"
  - "Friend access modifier"
  - "access levels, declared elements"
  - "access levels"
  - "access modifiers"
  - "Public access modifier"
  - "Protected access modifier"
  - "Protected Friend access modifier"
  - "Private Protected access modifier"
  - "Private access modifier"
  - "declared elements [Visual Basic], access level"
ms.assetid: 6e06c1ab-fd78-47f0-83a8-1152780b5e1a
---
# Access Levels in Visual Basic
The *access level* of a declared element is the extent of the ability to access it, that is, what code has permission to read it or write to it. This is determined not only by how you declare the element itself, but also by the access level of the element's container. Code that cannot access a containing element cannot access any of its contained elements, even those declared as `Public`. For example, a `Public` variable in a `Private` structure can be accessed from inside the class that contains the structure, but not from outside that class.  
  
## Public  
 The [Public](../../../../visual-basic/language-reference/modifiers/public.md) keyword in the declaration statement specifies that the element can be accessed from code anywhere in the same project, from other projects that reference the project, and from any assembly built from the project. The following code shows a sample `Public` declaration.  
  
```vb  
Public Class classForEverybody  
```  
  
 You can use `Public` only at module, interface, or namespace level. This means you can declare a public element at the level of a source file or namespace, or inside an interface, module, class, or structure, but not in a procedure.  
  
## Protected  
 The [Protected](../../../../visual-basic/language-reference/modifiers/protected.md) keyword in the declaration statement specifies that the element can be accessed only from within the same class, or from a class derived from this class. The following code shows a sample `Protected` declaration.  
  
```vb  
Protected Class classForMyHeirs  
```  
  
 You can use `Protected` only at class level, and only when you declare a member of a class. This means you can declare a protected element in a class, but not at the level of a source file or namespace, or inside an interface, module, structure, or procedure.  
  
## Friend  
 The [Friend](../../../../visual-basic/language-reference/modifiers/friend.md) keyword in the declaration statement specifies that the element can be accessed from within the same assembly, but not from outside the assembly. The following code shows a sample `Friend` declaration.  
  
```vb  
Friend stringForThisProject As String  
```  
  
 You can use `Friend` only at module, interface, or namespace level. This means you can declare a friend element at the level of a source file or namespace, or inside an interface, module, class, or structure, but not in a procedure.  
  
## Protected Friend  
 The [Protected Friend](../../../language-reference/modifiers/protected-friend.md) keyword combination in the declaration statement specifies that the element can be accessed either from derived classes or from within the same assembly, or both. The following code shows a sample `Protected Friend` declaration.  
  
```vb  
Protected Friend stringForProjectAndHeirs As String  
```  
  
 You can use `Protected Friend` only at class level, and only when you declare a member of a class. This means you can declare a protected friend element in a class, but not at the level of a source file or namespace, or inside an interface, module, structure, or procedure.  
  
## Private  
 The [Private](../../../../visual-basic/language-reference/modifiers/private.md) keyword in the declaration statement specifies that the element can be accessed only from within the same module, class, or structure. The following code shows a sample `Private` declaration.  
  
```vb  
Private numberForMeOnly As Integer  
```  
  
 You can use `Private` only at module level. This means you can declare a private element inside a module, class, or structure, but not at the level of a source file or namespace, inside an interface, or in a procedure.  
  
 At the module level, the `Dim` statement without any access level keywords is equivalent to a `Private` declaration. However, you might want to use the `Private` keyword to make your code easier to read and interpret.  

## Private Protected

The [Private Protected](../../../language-reference/modifiers/private-protected.md) keyword combination in the declaration statement specifies that the element can be accessed only from within the same class, as well as from derived classes found in the same assembly as the containing class. The `Private Protected` access modifier is supported starting with Visual Basic 15.5.

The following example shows a `Private Protected` declaration:

```vb
Private Protected internalValue As Integer
```

You can declare a `Private Protected` element only inside of a class. You cannot declare it within an interface or structure, nor can you declare it at the level of a source file or namespace, inside an interface or a structure, or in a procedure.

The `Private Protected` access modifier is supported by Visual Basic 15.5 and later. To use it, you add the following element to your Visual Basic project (*.vbproj) file. As long as Visual Basic 15.5 or later is installed on your system, it lets you take advantage of all the language features supported by the latest version of the Visual Basic compiler:

```xml
<PropertyGroup>
   <LangVersion>latest</LangVersion>
</PropertyGroup>
```

To use the `Private Protected` access modifier, you must add the following element to your Visual Basic project (*.vbproj) file:

```xml
<PropertyGroup>
   <LangVersion>15.5</LangVersion>
</PropertyGroup>
```

For more information see [setting the Visual Basic language version](../../../language-reference/configure-language-version.md).

 ## Access Modifiers  
 The keywords that specify access level are called *access modifiers*. The following table compares the access modifiers.  
  
|Access modifier|Access level granted|Elements you can declare with this access level|Declaration context within which you can use this modifier|  
|---------------------|--------------------------|-----------------------------------------------------|----------------------------------------------------------------|  
|`Public`|Unrestricted:<br /><br /> Any code that can see a public element can access it|Interfaces<br /><br /> Modules<br /><br /> Classes<br /><br /> Structures<br /><br /> Structure members<br /><br /> Procedures<br /><br /> Properties<br /><br /> Member variables<br /><br /> Constants<br /><br /> Enumerations<br /><br /> Events<br /><br /> External declarations<br /><br /> Delegates|Source file<br /><br /> Namespace<br /><br /> Interface<br /><br /> Module<br /><br /> Class<br /><br /> Structure|  
|`Protected`|Derivational:<br /><br /> Code in the class that declares a protected element, or a class derived from it, can access the element|Interfaces<br /><br /> Classes<br /><br /> Structures<br /><br /> Procedures<br /><br /> Properties<br /><br /> Member variables<br /><br /> Constants<br /><br /> Enumerations<br /><br /> Events<br /><br /> External declarations<br /><br /> Delegates|Class|  
|`Friend`|Assembly:<br /><br /> Code in the assembly that declares a friend element can access it|Interfaces<br /><br /> Modules<br /><br /> Classes<br /><br /> Structures<br /><br /> Structure members<br /><br /> Procedures<br /><br /> Properties<br /><br /> Member variables<br /><br /> Constants<br /><br /> Enumerations<br /><br /> Events<br /><br /> External declarations<br /><br /> Delegates|Source file<br /><br /> Namespace<br /><br /> Interface<br /><br /> Module<br /><br /> Class<br /><br /> Structure|  
|`Protected` `Friend`|Union of `Protected` and `Friend`:<br /><br /> Code in the same class or the same assembly as a protected friend element, or within any class derived from the element's class, can access it|Interfaces<br /><br /> Classes<br /><br /> Structures<br /><br /> Procedures<br /><br /> Properties<br /><br /> Member variables<br /><br /> Constants<br /><br /> Enumerations<br /><br /> Events<br /><br /> External declarations<br /><br /> Delegates|Class|  
|`Private`|Declaration context:<br /><br /> Code in the type that declares a private element, including code within contained types, can access the element|Interfaces<br /><br /> Classes<br /><br /> Structures<br /><br /> Structure members<br /><br /> Procedures<br /><br /> Properties<br /><br /> Member variables<br /><br /> Constants<br /><br /> Enumerations<br /><br /> Events<br /><br /> External declarations<br /><br /> Delegates|Module<br /><br /> Class<br /><br /> Structure|
|`Private Protected`|Code in the class that declares a private protected element, or code in a derived class found in the same assembly as the bas class.|Interfaces<br /><br /> Classes<br /><br /> Structures<br /><br /> Procedures<br /><br /> Properties<br /><br /> Member variables<br /><br /> Constants<br /><br /> Enumerations<br /><br /> Events<br /><br /> External declarations<br /><br /> Delegates|Class|
  
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
