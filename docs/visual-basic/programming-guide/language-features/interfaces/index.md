---
title: "Interfaces (Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "Visual Basic code, interfaces"
  - "interfaces [Visual Basic], Visual Basic"
  - "interfaces"
  - "interfaces [Visual Basic]"
ms.assetid: 61b06674-12c9-430b-be68-cc67ecee1f5b
caps.latest.revision: 11
author: dotnet-bot
ms.author: dotnetcontent
---
# Interfaces (Visual Basic)
*Interfaces* define the properties, methods, and events that classes can implement. Interfaces allow you to define features as small groups of closely related properties, methods, and events; this reduces compatibility problems because you can develop enhanced implementations for your interfaces without jeopardizing existing code. You can add new features at any time by developing additional interfaces and implementations.  
  
 There are several other reasons why you might want to use interfaces instead of class inheritance:  
  
-   Interfaces are better suited to situations in which your applications require many possibly unrelated object types to provide certain functionality.  
  
-   Interfaces are more flexible than base classes because you can define a single implementation that can implement multiple interfaces.  
  
-   Interfaces are better in situations in which you do not have to inherit implementation from a base class.  
  
-   Interfaces are useful when you cannot use class inheritance. For example, structures cannot inherit from classes, but they can implement interfaces.  
  
## Declaring Interfaces  
 Interface definitions are enclosed within the `Interface` and `End Interface` statements. Following the `Interface` statement, you can add an optional `Inherits` statement that lists one or more inherited interfaces. The `Inherits` statements must precede all other statements in the declaration except comments. The remaining statements in the interface definition should be `Event`, `Sub`, `Function`, `Property`, `Interface`, `Class`, `Structure`, and `Enum` statements. Interfaces cannot contain any implementation code or statements associated with implementation code, such as `End Sub` or `End Property`.  
  
 In a namespace, interface statements are `Friend` by default, but they can also be explicitly declared as `Public` or `Friend`. Interfaces defined within classes, modules, interfaces, and structures are `Public` by default, but they can also be explicitly declared as `Public`, `Friend`, `Protected`, or `Private`.  
  
> [!NOTE]
>  The `Shadows` keyword can be applied to all interface members. The `Overloads` keyword can be applied to `Sub`, `Function`, and `Property` statements declared in an interface definition. In addition, `Property` statements can have the `Default`, `ReadOnly`, or `WriteOnly` modifiers. None of the other modifiers—`Public`, `Private`, `Friend`, `Protected`, `Shared`, `Overrides`, `MustOverride`, or `Overridable`—are allowed. For more information, see [Declaration Contexts and Default Access Levels](../../../../visual-basic/language-reference/statements/declaration-contexts-and-default-access-levels.md).  
  
 For example, the following code defines an interface with one function, one property, and one event.  
  
 [!code-vb[VbVbalrOOP#17](../../../../visual-basic/misc/codesnippet/VisualBasic/index_1.vb)]  
  
## Implementing Interfaces  
 The [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] reserved word `Implements` is used in two ways. The `Implements` statement signifies that a class or structure implements an interface. The `Implements` keyword signifies that a class member or structure member implements a specific interface member.  
  
### Implements Statement  
 If a class or structure implements one or more interfaces, it must include the `Implements` statement immediately after the `Class` or `Structure` statement. The `Implements` statement requires a comma-separated list of interfaces to be implemented by a class. The class or structure must implement all interface members using the `Implements` keyword.  
  
### Implements Keyword  
 The `Implements` keyword requires a comma-separated list of interface members to be implemented. Generally, only a single interface member is specified, but you can specify multiple members. The specification of an interface member consists of the interface name, which must be specified in an implements statement within the class; a period; and the name of the member function, property, or event to be implemented. The name of a member that implements an interface member can use any legal identifier, and it is not limited to the `InterfaceName_MethodName` convention used in earlier versions of [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)].  
  
 For example, the following code shows how to declare a subroutine named `Sub1` that implements a method of an interface:  
  
 [!code-vb[VbVbalrOOP#69](../../../../visual-basic/misc/codesnippet/VisualBasic/index_2.vb)]  
  
 The parameter types and return types of the implementing member must match the interface property or member declaration in the interface. The most common way to implement an element of an interface is with a member that has the same name as the interface, as shown in the previous example.  
  
 To declare the implementation of an interface method, you can use any attributes that are legal on instance method declarations, including `Overloads`, `Overrides`, `Overridable`, `Public`, `Private`, `Protected`, `Friend`, `Protected Friend`, `MustOverride`, `Default`, and `Static`. The `Shared` attribute is not legal since it defines a class rather than an instance method.  
  
 Using `Implements`, you can also write a single method that implements multiple methods defined in an interface, as in the following example:  
  
 [!code-vb[VbVbalrOOP#70](../../../../visual-basic/misc/codesnippet/VisualBasic/index_3.vb)]  
  
 You can use a private member to implement an interface member. When a private member implements a member of an interface, that member becomes available by way of the interface even though it is not available directly on object variables for the class.  
  
### Interface Implementation Examples  
 Classes that implement an interface must implement all its properties, methods, and events.  
  
 The following example defines two interfaces. The second interface, `Interface2`, inherits `Interface1` and defines an additional property and method.  
  
 [!code-vb[VbVbalrOOP#39](../../../../visual-basic/misc/codesnippet/VisualBasic/index_4.vb)]  
  
 The next example implements `Interface1`, the interface defined in the previous example:  
  
 [!code-vb[VbVbalrOOP#40](../../../../visual-basic/misc/codesnippet/VisualBasic/index_5.vb)]  
  
 The final example implements `Interface2`, including a method inherited from `Interface1`:  
  
 [!code-vb[VbVbalrOOP#41](../../../../visual-basic/misc/codesnippet/VisualBasic/index_6.vb)]  
  
 You can implement a readonly property with a readwrite property (that is, you do not have to declare it readonly in the implementing class).  Implementing an interface promises to implement at least the members that the interface declares, but you can offer more functionality, such as allowing your property to be writable.  
  
## Related Topics  
  
|Title|Description|  
|-----------|-----------------|  
|[Walkthrough: Creating and Implementing Interfaces](../../../../visual-basic/programming-guide/language-features/interfaces/walkthrough-creating-and-implementing-interfaces.md)|Provides a detailed procedure that takes you through the process of defining and implementing your own interface.|  
|[Variance in Generic Interfaces](../../concepts/covariance-contravariance/variance-in-generic-interfaces.md)|Discusses covariance and contravariance in generic interfaces and provides a list of variant generic interfaces in the .NET Framework.|
