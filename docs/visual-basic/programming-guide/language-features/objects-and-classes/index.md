---
title: "Objects and classes in Visual Basic"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "classes [Visual Basic]"
  - "objects [Visual Basic]"
ms.assetid: c68c5752-1006-46e1-975a-6717b62a42fc
caps.latest.revision: 26
author: dotnet-bot
ms.author: dotnetcontent
---
# Objects and classes in Visual Basic
An *object* is a combination of code and data that can be treated as a unit. An object can be a piece of an application, like a control or a form. An entire application can also be an object.

When you create an application in [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)], you constantly work with objects. You can use objects provided by [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)], such as controls, forms, and data access objects. You can also use objects from other applications within your [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] application. You can even create your own objects and define additional properties and methods for them. Objects act like prefabricated building blocks for programs — they let you write a piece of code once and reuse it over and over.  
  
This topic discusses objects in detail.  

## Objects and classes
Each object in [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] is defined by a *class*. A class describes the variables, properties, procedures, and events of an object. Objects are instances of classes; you can create as many objects you need once you have defined a class.

To understand the relationship between an object and its class, think of cookie cutters and cookies. The cookie cutter is the class. It defines the characteristics of each cookie, for example size and shape. The class is used to create objects. The objects are the cookies.

You must create an object before you can access its members.  

#### To create an object from a class

1. Determine from which class you want to create an object.  

2. Write a [Dim Statement](../../../../visual-basic/language-reference/statements/dim-statement.md) to create a variable to which you can assign a class instance. The variable should be of the type of the desired class.

   ```vb
   Dim nextCustomer As customer
   ```

3. Add the [New Operator](../../../../visual-basic/language-reference/operators/new-operator.md) keyword to initialize the variable to a new instance of the class.

   ```vb
   Dim nextCustomer As New customer
   ```

4. You can now access the members of the class through the object variable.  

   ```vb
   nextCustomer.accountNumber = lastAccountNumber + 1  
   ```

> [!NOTE]
>  Whenever possible, you should declare the variable to be of the class type you intend to assign to it. This is called *early binding*. If you don't know the class type at compile time, you can invoke *late binding* by declaring the variable to be of the [Object Data Type](../../../../visual-basic/language-reference/data-types/object-data-type.md). However, late binding can make performance slower and limit access to the run-time object's members. For more information, see [Object Variable Declaration](../../../../visual-basic/programming-guide/language-features/variables/object-variable-declaration.md).

### Multiple instances
Objects newly created from a class are often identical to each other. Once they exist as individual objects, however, their variables and properties can be changed independently of the other instances. For example, if you add three check boxes to a form, each check box object is an instance of the <xref:System.Windows.Forms.CheckBox> class. The individual <xref:System.Windows.Forms.CheckBox> objects share a common set of characteristics and capabilities (properties, variables, procedures, and events) defined by the class. However, each has its own name, can be separately enabled and disabled, and can be placed in a different location on the form.

## Object members
An object is an element of an application, representing an *instance* of a class. Fields, properties, methods, and events are the building blocks of objects and constitute their *members*.

### Member Access
You access a member of an object by specifying, in order, the name of the object variable, a period (`.`), and the name of the member. The following example sets the <xref:System.Windows.Forms.Control.Text%2A> property of a <xref:System.Windows.Forms.Label> object.

```vb
warningLabel.Text = "Data not saved"
```

#### IntelliSense listing of members
IntelliSense lists members of a class when you invoke its List Members option, for example when you type a period (`.`) as a member-access operator. If you type the period following the name of a variable declared as an instance of that class, IntelliSense lists all the instance members and none of the shared members. If you type the period following the class name itself, IntelliSense lists all the shared members and none of the instance members. For more information, see [Using IntelliSense](/visualstudio/ide/using-intellisense).

### Fields and properties
*Fields* and *properties* represent information stored in an object. You retrieve and set their values with assignment statements the same way you retrieve and set local variables in a procedure. The following example retrieves the <xref:System.Windows.Forms.Control.Width%2A> property and sets the <xref:System.Windows.Forms.Control.ForeColor%2A> property of a <xref:System.Windows.Forms.Label> object.

```vb
Dim warningWidth As Integer = warningLabel.Width
warningLabel.ForeColor = System.Drawing.Color.Red
```

Note that a field is also called a *member variable*.
  
Use property procedures when:

- You need to control when and how a value is set or retrieved.

- The property has a well-defined set of values that need to be validated.

- Setting the value causes some perceptible change in the object's state, such as an `IsVisible` property.

- Setting the property causes changes to other internal variables or to the values of other properties.

- A set of steps must be performed before the property can be set or retrieved.

Use fields when:  

- The value is of a self-validating type. For example, an error or automatic data conversion occurs if a value other than `True` or `False` is assigned to a `Boolean` variable.

- Any value in the range supported by the data type is valid. This is true of many properties of type `Single` or `Double`.

- The property is a `String` data type, and there is no constraint on the size or value of the string.

- For more information, see [Property Procedures](../../../../visual-basic/programming-guide/language-features/procedures/property-procedures.md).

### Methods
A *method* is an action that an object can perform. For example, <xref:System.Windows.Forms.ComboBox.ObjectCollection.Add%2A> is a method of the <xref:System.Windows.Forms.ComboBox> object that adds a new entry to a combo box.

The following example demonstrates the <xref:System.Windows.Forms.Timer.Start%2A> method of a <xref:System.Windows.Forms.Timer> object.

```vb
Dim safetyTimer As New System.Windows.Forms.Timer
safetyTimer.Start()
```

Note that a method is simply a *procedure* that is exposed by an object.

For more information, see [Procedures](../../../../visual-basic/programming-guide/language-features/procedures/index.md).

### Events
An event is an action recognized by an object, such as clicking the mouse or pressing a key, and for which you can write code to respond. Events can occur as a result of a user action or program code, or they can be caused by the system. Code that signals an event is said to *raise* the event, and code that responds to it is said to *handle* it.

You can also develop your own custom events to be raised by your objects and handled by other objects. For more information, see [Events](../../../../visual-basic/programming-guide/language-features/events/index.md).

### Instance members and shared members
When you create an object from a class, the result is an instance of that class. Members that are not declared with the [Shared](../../../../visual-basic/language-reference/modifiers/shared.md) keyword are *instance members*, which belong strictly to that particular instance. An instance member in one instance is independent of the same member in another instance of the same class. An instance member variable, for example, can have different values in different instances.

Members declared with the `Shared` keyword are *shared members*, which belong to the class as a whole and not to any particular instance. A shared member exists only once, no matter how many instances of its class you create, or even if you create no instances. A shared member variable, for example, has only one value, which is available to all code that can access the class.

#### Accessing nonshared members  

###### To access a nonshared member of an object

1. Make sure the object has been created from its class and assigned to an object variable.

   ```vb
   Dim secondForm As New System.Windows.Forms.Form  
   ```  

2. In the statement that accesses the member, follow the object variable name with the *member-access operator* (`.`) and then the member name.

   ```vb
   secondForm.Show()
   ```

#### Accessing shared members

###### To access a shared member of an object

- Follow the class name with the *member-access operator* (`.`) and then the member name. You should always access a `Shared` member of the object directly through the class name.

   ```vb
   MsgBox("This computer is called " & Environment.MachineName)  
   ```

- If you have already created an object from the class, you can alternatively access a `Shared` member through the object's variable.

### Differences between classes and modules
The main difference between classes and modules is that classes can be instantiated as objects while standard modules cannot. Because there is only one copy of a standard module's data, when one part of your program changes a public variable in a standard module, any other part of the program gets the same value if it then reads that variable. In contrast, object data exists separately for each instantiated object. Another difference is that unlike standard modules, classes can implement interfaces.

> [!NOTE]
> When the `Shared` modifier is applied to a class member, it is associated with the class itself instead of a particular instance of the class. The member is accessed directly by using the class name, the same way module members are accessed.

Classes and modules also use different scopes for their members. Members defined within a class are scoped within a specific instance of the class and exist only for the lifetime of the object. To access class members from outside a class, you must use fully qualified names in the format of *Object*.*Member*.

On the other hand, members declared within a module are publicly accessible by default, and can be accessed by any code that can access the module. This means that variables in a standard module are effectively global variables because they are visible from anywhere in your project, and they exist for the life of the program.

## Reusing classes and objects  
Objects let you declare variables and procedures once and then reuse them whenever needed. For example, if you want to add a spelling checker to an application you could define all the variables and support functions to provide spell-checking functionality. If you create your spelling checker as a class, you can then reuse it in other applications by adding a reference to the compiled assembly. Better yet, you may be able to save yourself some work by using a spelling checker class that someone else has already developed.

The [!INCLUDE[dnprdnshort](~/includes/dnprdnshort-md.md)] provides many examples of components that are available for use. The following example uses the <xref:System.TimeZone> class in the <xref:System> namespace. <xref:System.TimeZone> provides members that allow you to retrieve information about the time zone of the current computer system.

```vb
Public Sub examineTimeZone()
    Dim tz As System.TimeZone = System.TimeZone.CurrentTimeZone
    Dim s As String = "Current time zone is "
    s &= CStr(tz.GetUtcOffset(Now).Hours) & " hours and "
    s &= CStr(tz.GetUtcOffset(Now).Minutes) & " minutes "
    s &= "different from UTC (coordinated universal time)"
    s &= vbCrLf & "and is currently "
    If tz.IsDaylightSavingTime(Now) = False Then s &= "not "
    s &= "on ""summer time""."
    MsgBox(s)
End Sub
```

In the preceding example, the first [Dim Statement](../../../../visual-basic/language-reference/statements/dim-statement.md) declares an object variable of type <xref:System.TimeZone> and assigns to it a <xref:System.TimeZone> object returned by the <xref:System.TimeZone.CurrentTimeZone%2A> property.

## Relationships among objects  
Objects can be related to each other in several ways. The principal kinds of relationship are *hierarchical* and *containment*.

### Hierarchical relationship
When classes are derived from more fundamental classes, they are said to have a *hierarchical relationship*. Class hierarchies are useful when describing items that are a subtype of a more general class.

In the following example, suppose you want to define a special kind of <xref:System.Windows.Forms.Button> that acts like a normal <xref:System.Windows.Forms.Button> but also exposes a method that reverses the foreground and background colors.

##### To define a class is derived from an already existing class

1. Use a [Class Statement](../../../../visual-basic/language-reference/statements/class-statement.md) to define a class from which to create the object you need.

   ```vb
   Public Class reversibleButton
   ```

   Be sure an `End Class` statement follows the last line of code in your class. By default, the integrated development environment (IDE) automatically generates an `End Class` when you enter a `Class` statement.

2. Follow the `Class` statement immediately with an [Inherits Statement](../../../../visual-basic/language-reference/statements/inherits-statement.md). Specify the class from which your new class derives.  
  
   ```vb
   Inherits System.Windows.Forms.Button
   ```

  Your new class inherits all the members defined by the base class.

3. Add the code for the additional members your derived class exposes. For example, you might add a `reverseColors` method, and your derived class might look as follows:

   ```vb
   Public Class reversibleButton
       Inherits System.Windows.Forms.Button
           Public Sub reverseColors()
               Dim saveColor As System.Drawing.Color = Me.BackColor
               Me.BackColor = Me.ForeColor
               Me.ForeColor = saveColor
          End Sub
   End Class
   ```

   If you create an object from the `reversibleButton` class, it can access all the members of the <xref:System.Windows.Forms.Button> class, as well as the `reverseColors` method and any other new members you define on `reversibleButton`.

Derived classes inherit members from the class they are based on, allowing you to add complexity as you progress in a class hierarchy. For more information, see [Inheritance Basics](../../../../visual-basic/programming-guide/language-features/objects-and-classes/inheritance-basics.md).

#### Compiling the code
Be sure the compiler can access the class from which you intend to derive your new class. This might mean fully qualifying its name, as in the preceding example, or identifying its namespace in an [Imports Statement (.NET Namespace and Type)](../../../../visual-basic/language-reference/statements/imports-statement-net-namespace-and-type.md). If the class is in a different project, you might need to add a reference to that project. For more information, see [Managing references in a project](/visualstudio/ide/managing-references-in-a-project).

### Containment relationship
Another way that objects can be related is a *containment relationship*. Container objects logically encapsulate other objects. For example, the <xref:System.OperatingSystem> object logically contains a <xref:System.Version> object, which it returns through its <xref:System.OperatingSystem.Version%2A> property. Note that the container object does not physically contain any other object.

#### Collections
One particular type of object containment is represented by *collections*. Collections are groups of similar objects that can be enumerated. [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] supports a specific syntax in the [For Each...Next Statement](../../../../visual-basic/language-reference/statements/for-each-next-statement.md) that allows you to iterate through the items of a collection. Additionally, collections often allow you to use an <xref:Microsoft.VisualBasic.Collection.Item%2A> to retrieve elements by their index or by associating them with a unique string. Collections can be easier to use than arrays because they allow you to add or remove items without using indexes. Because of their ease of use, collections are often used to store forms and controls.

## Related topics  
 [Walkthrough: Defining Classes](../../../../visual-basic/programming-guide/language-features/objects-and-classes/walkthrough-defining-classes.md)  
 Provides a step-by-step description of how to create a class.  

 [Overloaded Properties and Methods](../../../../visual-basic/programming-guide/language-features/objects-and-classes/overloaded-properties-and-methods.md)  
 Overloaded Properties and Methods  

 [Inheritance Basics](../../../../visual-basic/programming-guide/language-features/objects-and-classes/inheritance-basics.md)  
 Covers inheritance modifiers, overriding methods and properties, MyClass, and MyBase.  

 [Object Lifetime: How Objects Are Created and Destroyed](../../../../visual-basic/programming-guide/language-features/objects-and-classes/object-lifetime-how-objects-are-created-and-destroyed.md)  
 Discusses creating and disposing of class instances.  

 [Anonymous Types](../../../../visual-basic/programming-guide/language-features/objects-and-classes/anonymous-types.md)  
 Describes how to create and use anonymous types, which allow you to create objects without writing a class definition for the data type.  

 [Object Initializers: Named and Anonymous Types](../../../../visual-basic/programming-guide/language-features/objects-and-classes/object-initializers-named-and-anonymous-types.md)  
 Discusses object initializers, which are used to create instances of named and anonymous types by using a single expression.  

 [How to: Infer Property Names and Types in Anonymous Type Declarations](../../../../visual-basic/programming-guide/language-features/objects-and-classes/how-to-infer-property-names-and-types-in-anonymous-type-declarations.md)  
 Explains how to infer property names and types in anonymous type declarations. Provides examples of successful and unsuccessful inference.
