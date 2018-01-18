---
title: "Event Statement"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vb.Event"
  - "vb.Custom"
helpviewer_keywords: 
  - "Event statement [Visual Basic]"
  - "declaring events [Visual Basic], syntax"
  - "Public keyword [Visual Basic], Event statements"
  - "Custom keyword [Visual Basic]"
  - "declarations [Visual Basic], events"
  - "event keyword [Visual Basic]"
  - "WithEvents keyword [Visual Basic], Event statements"
  - "events [Visual Basic], declaring"
  - "ByVal keyword [Visual Basic], Event statements"
  - "events [Visual Basic], custom"
  - "ByRef keyword [Visual Basic], Event statements"
  - "declaring user-defined events"
ms.assetid: 306ff8ed-74dd-4b6a-bd2f-e91b17474042
caps.latest.revision: 33
author: dotnet-bot
ms.author: dotnetcontent
---
# Event Statement
Declares a user-defined event.  
  
## Syntax  
  
```  
[ <attrlist> ] [ accessmodifier ] _  
[ Shared ] [ Shadows ] Event eventname[(parameterlist)] _  
[ Implements implementslist ]  
' -or-  
[ <attrlist> ] [ accessmodifier ] _  
[ Shared ] [ Shadows ] Event eventname As delegatename _  
[ Implements implementslist ]  
' -or-  
 [ <attrlist> ] [ accessmodifier ] _  
[ Shared ] [ Shadows ] Custom Event eventname As delegatename _  
[ Implements implementslist ]  
   [ <attrlist> ] AddHandler(ByVal value As delegatename)  
      [ statements ]  
   End AddHandler  
   [ <attrlist> ] RemoveHandler(ByVal value As delegatename)  
      [ statements ]  
   End RemoveHandler  
   [ <attrlist> ] RaiseEvent(delegatesignature)  
      [ statements ]  
   End RaiseEvent  
End Event  
```  
  
## Parts  
  
|Part|Description|  
|---|---|  
|`attrlist`|Optional. List of attributes that apply to this event. Multiple attributes are separated by commas. You must enclose the [Attribute List](../../../visual-basic/language-reference/statements/attribute-list.md) in angle brackets ("`<`" and "`>`").|  
|`accessmodifier`|Optional. Specifies what code can access the event. Can be one of the following:<br /><br /> -   [Public](../../../visual-basic/language-reference/modifiers/public.md)—any code that can access the element that declares it can access it.<br />-   [Protected](../../../visual-basic/language-reference/modifiers/protected.md)—only code within its class or a derived class can access it.<br />-   [Friend](../../../visual-basic/language-reference/modifiers/friend.md)—only code in the same assembly can access it.<br />-   [Private](../../../visual-basic/language-reference/modifiers/private.md)—only code in the element that declares it can access it.<br /><br /> You can specify `Protected Friend` to enable access from code in the event's class, a derived class, or the same assembly.|  
|`Shared`|Optional. Specifies that this event is not associated with a specific instance of a class or structure.|  
|`Shadows`|Optional. Indicates that this event redeclares and hides an identically named programming element, or set of overloaded elements, in a base class. You can shadow any kind of declared element with any other kind.<br /><br /> A shadowed element is unavailable from within the derived class that shadows it, except from where the shadowing element is inaccessible. For example, if a `Private` element shadows a base-class element, code that does not have permission to access the `Private` element accesses the base-class element instead.|  
|`eventname`|Required. Name of the event; follows standard variable naming conventions.|  
|`parameterlist`|Optional. List of local variables that represent the parameters of this event. You must enclose the [Parameter List](../../../visual-basic/language-reference/statements/parameter-list.md) in parentheses.|  
|`Implements`|Optional. Indicates that this event implements an event of an interface.|  
|`implementslist`|Required if `Implements` is supplied. List of `Sub` procedures being implemented. Multiple procedures are separated by commas:<br /><br /> *implementedprocedure* [ , *implementedprocedure* ... ]<br /><br /> Each `implementedprocedure` has the following syntax and parts:<br /><br /> `interface`.`definedname`<br /><br /> -   `interface` - Required. Name of an interface that this procedure's containing class or structure is implementing.<br />-   `Definedname` - Required. Name by which the procedure is defined in `interface`. This does not have to be the same as `name`, the name that this procedure is using to implement the defined procedure.|  
|`Custom`|Required. Events declared as `Custom` must define custom `AddHandler`, `RemoveHandler`, and `RaiseEvent` accessors.|  
|`delegatename`|Optional. The name of a delegate that specifies the event-handler signature.|  
|`AddHandler`|Required. Declares an `AddHandler` accessor, which specifies the statements to execute when an event handler is added, either explicitly by using the `AddHandler` statement or implicitly by using the `Handles` clause.|  
|`End AddHandler`|Required. Terminates the `AddHandler` block.|  
|`value`|Required. Parameter name.|  
|`RemoveHandler`|Required. Declares a `RemoveHandler` accessor, which specifies the statements to execute when an event handler is removed using the `RemoveHandler` statement.|  
|`End RemoveHandler`|Required. Terminates the `RemoveHandler` block.|  
|`RaiseEvent`|Required. Declares a `RaiseEvent` accessor, which specifies the statements to execute when the event is raised using the `RaiseEvent` statement. Typically, this invokes a list of delegates maintained by the `AddHandler` and `RemoveHandler` accessors.|  
|`End RaiseEvent`|Required. Terminates the `RaiseEvent` block.|  
|`delegatesignature`|Required. List of parameters that matches the parameters required by the `delegatename` delegate. You must enclose the [Parameter List](../../../visual-basic/language-reference/statements/parameter-list.md) in parentheses.|  
|`statements`|Optional. Statements that contain the bodies of the `AddHandler`, `RemoveHandler`, and `RaiseEvent` methods.|  
|`End Event`|Required. Terminates the `Event` block.|  
  
## Remarks  
 Once the event has been declared, use the `RaiseEvent` statement to raise the event. A typical event might be declared and raised as shown in the following fragments:  
  
 [!code-vb[VbVbalrEvents#13](../../../visual-basic/language-reference/statements/codesnippet/VisualBasic/event-statement_1.vb)]  
  
> [!NOTE]
>  You can declare event arguments just as you do arguments of procedures, with the following exceptions: events cannot have named arguments, `ParamArray` arguments, or `Optional` arguments. Events do not have return values.  
  
 To handle an event, you must associate it with an event handler subroutine using either the `Handles` or `AddHandler` statement. The signatures of the subroutine and the event must match. To handle a shared event, you must use the `AddHandler` statement.  
  
 You can use `Event` only at module level. This means the *declaration context* for an event must be a class, structure, module, or interface, and cannot be a source file, namespace, procedure, or block. For more information, see [Declaration Contexts and Default Access Levels](../../../visual-basic/language-reference/statements/declaration-contexts-and-default-access-levels.md).  
  
 In most circumstances, you can use the first syntax in the Syntax section of this topic for declaring events. However, some scenarios require that you have more control over the detailed behavior of the event. The last syntax in the Syntax section of this topic, which uses the `Custom` keyword, provides that control by enabling you to define custom events. In a custom event, you specify exactly what occurs when code adds or removes an event handler to or from the event, or when code raises the event. For examples, see [How to: Declare Custom Events To Conserve Memory](../../../visual-basic/programming-guide/language-features/events/how-to-declare-custom-events-to-conserve-memory.md) and [How to: Declare Custom Events To Avoid Blocking](../../../visual-basic/programming-guide/language-features/events/how-to-declare-custom-events-to-avoid-blocking.md).  
  
## Example  
 The following example uses events to count down seconds from 10 to 0. The code illustrates several of the event-related methods, properties, and statements. This includes the `RaiseEvent` statement.  
  
 The class that raises an event is the event source, and the methods that process the event are the event handlers. An event source can have multiple handlers for the events it generates. When the class raises the event, that event is raised on every class that has elected to handle events for that instance of the object.  
  
 The example also uses a form (`Form1`) with a button (`Button1`) and a text box (`TextBox1`). When you click the button, the first text box displays a countdown from 10 to 0 seconds. When the full time (10 seconds) has elapsed, the first text box displays "Done".  
  
 The code for `Form1` specifies the initial and terminal states of the form. It also contains the code executed when events are raised.  
  
 To use this example, open a new Windows Forms project. Then add a button named `Button1` and a text box named `TextBox1` to the main form, named `Form1`. Then right-click the form and click **View Code** to open the code editor.  
  
 Add a `WithEvents` variable to the declarations section of the `Form1` class:  
  
 [!code-vb[VbVbalrEvents#14](../../../visual-basic/language-reference/statements/codesnippet/VisualBasic/event-statement_2.vb)]  
  
 Add the following code to the code for `Form1`. Replace any duplicate procedures that may exist, such as `Form_Load` or `Button_Click`.  
  
 [!code-vb[VbVbalrEvents#15](../../../visual-basic/language-reference/statements/codesnippet/VisualBasic/event-statement_3.vb)]  
  
 Press F5 to run the previous example, and click the button labeled **Start**. The first text box starts to count down the seconds. When the full time (10 seconds) has elapsed, the first text box displays "Done".  
  
> [!NOTE]
>  The `My.Application.DoEvents` method does not process events in the same way the form does. To enable the form to handle the events directly, you can use multithreading. For more information, see [Threading](../../programming-guide/concepts/threading/index.md).  
  
## See Also  
 [RaiseEvent Statement](../../../visual-basic/language-reference/statements/raiseevent-statement.md)  
 [Implements Statement](../../../visual-basic/language-reference/statements/implements-statement.md)  
 [Events](../../../visual-basic/programming-guide/language-features/events/index.md)  
 [AddHandler Statement](../../../visual-basic/language-reference/statements/addhandler-statement.md)  
 [RemoveHandler Statement](../../../visual-basic/language-reference/statements/removehandler-statement.md)  
 [Handles](../../../visual-basic/language-reference/statements/handles-clause.md)  
 [Delegate Statement](../../../visual-basic/language-reference/statements/delegate-statement.md)  
 [How to: Declare Custom Events To Conserve Memory](../../../visual-basic/programming-guide/language-features/events/how-to-declare-custom-events-to-conserve-memory.md)  
 [How to: Declare Custom Events To Avoid Blocking](../../../visual-basic/programming-guide/language-features/events/how-to-declare-custom-events-to-avoid-blocking.md)  
 [Shared](../../../visual-basic/language-reference/modifiers/shared.md)  
 [Shadows](../../../visual-basic/language-reference/modifiers/shadows.md)
