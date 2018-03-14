---
title: "Inheritance Basics (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "derived classes [Visual Basic], inheritance"
  - "MyClass keyword [Visual Basic], using"
  - "MyBase keyword [Visual Basic], using"
  - "Inherits statement [Visual Basic], inheritance"
  - "overriding, Overridable keyword"
  - "MustInherit keyword [Visual Basic], using"
  - "Overrides keyword [Visual Basic], using"
  - "inheritance"
  - "MustInherit classes [Visual Basic]"
  - "MustOverride keyword [Visual Basic], using"
  - "classes [Visual Basic], derived"
  - "NotInheritable keyword [Visual Basic], using"
  - "base classes [Visual Basic], extending properties and methods [Visual Basic]"
  - "NotOverridable keyword [Visual Basic], using"
  - "base classes [Visual Basic], inheritance"
  - "abstract classes [Visual Basic], inheritance"
  - "overriding, Overrides keyword"
ms.assetid: dfc8deba-f5b3-4d1d-a937-7cb826446fc5
caps.latest.revision: 23
author: dotnet-bot
ms.author: dotnetcontent
---
# Inheritance Basics (Visual Basic)
The `Inherits` statement is used to declare a new class, called a *derived class*, based on an existing class, known as a *base class*. Derived classes inherit, and can extend, the properties, methods, events, fields, and constants defined in the base class. The following section describes some of the rules for inheritance, and the modifiers you can use to change the way classes inherit or are inherited:  
  
-   By default, all classes are inheritable unless marked with the `NotInheritable` keyword. Classes can inherit from other classes in your project or from classes in other assemblies that your project references.  
  
-   Unlike languages that allow multiple inheritance, [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] allows only single inheritance in classes; that is, derived classes can have only one base class. Although multiple inheritance is not allowed in classes, classes can implement multiple interfaces, which can effectively accomplish the same ends.  
  
-   To prevent exposing restricted items in a base class, the access type of a derived class must be equal to or more restrictive than its base class. For example, a `Public` class cannot inherit a `Friend` or a `Private` class, and a `Friend` class cannot inherit a `Private` class.  
  
## Inheritance Modifiers  
 [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] introduces the following class-level statements and modifiers to support inheritance:  
  
-   `Inherits` statement — Specifies the base class.  
  
-   `NotInheritable` modifier — Prevents programmers from using the class as a base class.  
  
-   `MustInherit` modifier — Specifies that the class is intended for use as a base class only. Instances of `MustInherit` classes cannot be created directly; they can only be created as base class instances of a derived class. (Other programming languages, such as C++ and C#, use the term *abstract class* to describe such a class.)  
  
## Overriding Properties and Methods in Derived Classes  
 By default, a derived class inherits properties and methods from its base class. If an inherited property or method has to behave differently in the derived class it can be *overridden*. That is, you can define a new implementation of the method in the derived class. The following modifiers are used to control how properties and methods are overridden:  
  
-   `Overridable` — Allows a property or method in a class to be overridden in a derived class.  
  
-   `Overrides` — Overrides an `Overridable` property or method defined in the base class.  
  
-   `NotOverridable` — Prevents a property or method from being overridden in an inheriting class. By default, `Public` methods are `NotOverridable`.  
  
-   `MustOverride` — Requires that a derived class override the property or method. When the `MustOverride` keyword is used, the method definition consists of just the `Sub`, `Function`, or `Property` statement. No other statements are allowed, and specifically there is no `End Sub` or `End Function` statement. `MustOverride` methods must be declared in `MustInherit` classes.  
  
 Suppose you want to define classes to handle payroll. You could define a generic `Payroll` class that contains a `RunPayroll` method that calculates payroll for a typical week. You could then use `Payroll` as a base class for a more specialized `BonusPayroll` class, which could be used when distributing employee bonuses.  
  
 The `BonusPayroll` class can inherit, and override, the `PayEmployee` method defined in the base `Payroll` class.  
  
 The following example defines a base class, `Payroll,` and a derived class, `BonusPayroll`, which overrides an inherited method, `PayEmployee`. A procedure, `RunPayroll`, creates and then passes a `Payroll` object and a `BonusPayroll` object to a function, `Pay`, that executes the `PayEmployee` method of both objects.  
  
 [!code-vb[VbVbalrOOP#28](../../../../visual-basic/misc/codesnippet/VisualBasic/inheritance-basics_1.vb)]  
  
## The MyBase Keyword  
 The `MyBase` keyword behaves like an object variable that refers to the base class of the current instance of a class. `MyBase` is frequently used to access base class members that are overridden or shadowed in a derived class. In particular, `MyBase.New` is used to explicitly call a base class constructor from a derived class constructor.  
  
 For example, suppose you are designing a derived class that overrides a method inherited from the base class. The overridden method can call the method in the base class and modify the return value as shown in the following code fragment:  
  
 [!code-vb[VbVbalrOOP#109](../../../../visual-basic/misc/codesnippet/VisualBasic/inheritance-basics_2.vb)]  
  
 The following list describes restrictions on using `MyBase`:  
  
-   `MyBase` refers to the immediate base class and its inherited members. It cannot be used to access `Private` members in the class.  
  
-   `MyBase` is a keyword, not a real object. `MyBase` cannot be assigned to a variable, passed to procedures, or used in an `Is` comparison.  
  
-   The method that `MyBase` qualifies does not have to be defined in the immediate base class; it may instead be defined in an indirectly inherited base class. In order for a reference qualified by `MyBase` to compile correctly, some base class must contain a method matching the name and types of parameters that appear in the call.  
  
-   You cannot use `MyBase` to call `MustOverride` base class methods.  
  
-   `MyBase` cannot be used to qualify itself. Therefore, the following code is not valid:  
  
     `MyBase.MyBase.BtnOK_Click()`  
  
-   `MyBase` cannot be used in modules.  
  
-   `MyBase` cannot be used to access base class members that are marked as `Friend` if the base class is in a different assembly.  
  
 For more information and another example, see [How to: Access a Variable Hidden by a Derived Class](../../../../visual-basic/programming-guide/language-features/declared-elements/how-to-access-a-variable-hidden-by-a-derived-class.md).  
  
## The MyClass Keyword  
 The `MyClass` keyword behaves like an object variable that refers to the current instance of a class as originally implemented. `MyClass` resembles `Me`, but every method and property call on `MyClass` is treated as if the method or property were [NotOverridable](../../../../visual-basic/language-reference/modifiers/notoverridable.md). Therefore, the method or property is not affected by overriding in a derived class.  
  
-   `MyClass` is a keyword, not a real object. `MyClass` cannot be assigned to a variable, passed to procedures, or used in an `Is` comparison.  
  
-   `MyClass` refers to the containing class and its inherited members.  
  
-   `MyClass` can be used as a qualifier for `Shared` members.  
  
-   `MyClass` cannot be used inside a `Shared` method, but can be used inside an instance method to access a shared member of a class.  
  
-   `MyClass` cannot be used in standard modules.  
  
-   `MyClass` can be used to qualify a method that is defined in a base class and that has no implementation of the method provided in that class. Such a reference has the same meaning as `MyBase.`*Method*.  
  
 The following example compares `Me` and `MyClass`.  
  
```vb
Class baseClass  
    Public Overridable Sub testMethod()  
        MsgBox("Base class string")  
    End Sub  
    Public Sub useMe()  
        ' The following call uses the calling class's method, even if   
        ' that method is an override.  
        Me.testMethod()  
    End Sub  
    Public Sub useMyClass()  
        ' The following call uses this instance's method and not any  
        ' override.  
        MyClass.testMethod()  
    End Sub  
End Class  
Class derivedClass : Inherits baseClass  
    Public Overrides Sub testMethod()  
        MsgBox("Derived class string")  
    End Sub  
End Class  
Class testClasses  
    Sub startHere()  
        Dim testObj As derivedClass = New derivedClass()  
        ' The following call displays "Derived class string".  
        testObj.useMe()  
        ' The following call displays "Base class string".  
        testObj.useMyClass()  
    End Sub  
End Class  
```  
  
 Even though `derivedClass` overrides `testMethod`, the `MyClass` keyword in `useMyClass` nullifies the effects of overriding, and the compiler resolves the call to the base class version of `testMethod`.  
  
## See Also  
 [Inherits Statement](../../../../visual-basic/language-reference/statements/inherits-statement.md)  
 [Me, My, MyBase, and MyClass](../../../../visual-basic/programming-guide/program-structure/me-my-mybase-and-myclass.md)
