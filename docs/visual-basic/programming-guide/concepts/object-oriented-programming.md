---
title: "Object-Oriented Programming (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
ms.assetid: 49794de4-64c3-473c-b8ed-fe98835df69c
caps.latest.revision: 4
author: dotnet-bot
ms.author: dotnetcontent
---
# Object-Oriented Programming (Visual Basic)
Visual Basic provides full support for object-oriented programming including encapsulation, inheritance, and polymorphism.  
  
 *Encapsulation* means that a group of related properties, methods, and other members are treated as a single unit or object.  
  
 *Inheritance* describes the ability to create new classes based on an existing class.  
  
 *Polymorphism* means that you can have multiple classes that can be used interchangeably, even though each class implements the same properties or methods in different ways.  
  
 This section describes the following concepts:  
  
-   [Classes and objects](#classes-and-objects)  
  
    -   [Class members](#members)  
  
         [Properties and fields](#properties-and-fields)  
  
         [Methods](#methods)  
  
         [Constructors](#constructors)  
  
         [Destructors](#destructors)  
  
         [Events](#events)  
  
         [Nested classes](#nested-classes)  
  
    -   [Access modifiers and access levels](#access-modifiers-and-access-levels)  
  
    -   [Instantiating classes](#instantiating-classes)  
  
    -   [Shared classes and members](#shared-classes-and-members)  
  
    -   [Anonymous types](#anonymous-types)  
  
-   [Inheritance](#inheritance)  
  
    -   [Overriding members](#overriding-members)  
  
-   [Interfaces](#interfaces)  
  
-   [Generics](#generics)  
  
-   [Delegates](#delegates)  
  
## Classes and objects  
The terms *class* and *object* are sometimes used interchangeably, but in fact, classes describe the *type* of objects, while objects are usable *instances* of classes. So, the act of creating an object is called *instantiation*. Using the blueprint analogy, a class is a blueprint, and an object is a building made from that blueprint.

To define a class:

```vb  
Class SampleClass
End Class
```

Visual Basic also provides a light version of classes called *structures* that are useful when you need to create large array of objects and do not want to consume too much memory for that.

To define a structure:  

```vb
Structure SampleStructure
End Structure
```

For more information, see:

- [Class Statement](../../../visual-basic/language-reference/statements/class-statement.md)

- [Structure Statement](../../../visual-basic/language-reference/statements/structure-statement.md)

### Class members
Each class can have different *class members* that include properties that describe class data, methods that define class behavior, and events that provide communication between different classes and objects.

#### Properties and fields
Fields and properties represent information that an object contains. Fields are like variables because they can be read or set directly.

To define a field:

```vb
Class SampleClass
    Public SampleField As String
End Class
```

Properties have get and set procedures, which provide more control on how values are set or returned.

Visual Basic allows you either to create a private field for storing the property value or use so-called auto-implemented properties that create this field automatically behind the scenes and provide the basic logic for the property procedures.

To define an auto-implemented property:

```vb
Class SampleClass
    Public Property SampleProperty as String
End Class
```

If you need to perform some additional operations for reading and writing the property value, define a field for storing the property value and provide the basic logic for storing and retrieving it:

```vb
Class SampleClass
    Private m_Sample As String
    Public Property Sample() As String
        Get
            ' Return the value stored in the field.
            Return m_Sample
        End Get
        Set(ByVal Value As String)
            ' Store the value in the field.
            m_Sample = Value
        End Set
    End Property
End Class
```

Most properties have methods or procedures to both set and get the property value. However, you can create read-only or write-only properties to restrict them from being modified or read. In Visual Basic you can use `ReadOnly` and `WriteOnly` keywords. However, auto-implemented properties cannot be read-only or write-only.

For more information, see:
  
-   [Property Statement](../../../visual-basic/language-reference/statements/property-statement.md)  
  
-   [Get Statement](../../../visual-basic/language-reference/statements/get-statement.md)  
  
-   [Set Statement](../../../visual-basic/language-reference/statements/set-statement.md)  
  
-   [ReadOnly](../../../visual-basic/language-reference/modifiers/readonly.md)  
  
-   [WriteOnly](../../../visual-basic/language-reference/modifiers/writeonly.md)  
  
#### Methods  
 A *method* is an action that an object can perform.  

> [!NOTE]
>  In Visual Basic, there are two ways to create a method: the `Sub` statement is used if the method does not return a value; the `Function` statement is used if a method returns a value.

To define a method of a class:

```vb
Class SampleClass
    Public Function SampleFunc(ByVal SampleParam As String)
        ' Add code here
    End Function
End Class
```

A class can have several implementations, or *overloads*, of the same method that differ in the number of parameters or parameter types.

To overload a method:

```vb
Overloads Sub Display(ByVal theChar As Char)
    ' Add code that displays Char data.
End Sub
Overloads Sub Display(ByVal theInteger As Integer)
    ' Add code that displays Integer data.
End Sub
```

In most cases you declare a method within a class definition. However, Visual Basic also supports *extension methods* that allow you to add methods to an existing class outside the actual definition of the class.

For more information, see:

- [Function Statement](../../../visual-basic/language-reference/statements/function-statement.md)  

- [Sub Statement](../../../visual-basic/language-reference/statements/sub-statement.md)  

- [Overloads](../../../visual-basic/language-reference/modifiers/overloads.md)  

- [Extension Methods](../../../visual-basic/programming-guide/language-features/procedures/extension-methods.md)  

#### Constructors  
Constructors are class methods that are executed automatically when an object of a given type is created. Constructors usually initialize the data members of the new object. A constructor can run only once when a class is created. Furthermore, the code in the constructor always runs before any other code in a class. However, you can create multiple constructor overloads in the same way as for any other method.

To define a constructor for a class:

```vb
Class SampleClass
    Sub New(ByVal s As String)
        // Add code here.
    End Sub
End Class 
```

For more information, see: [Object Lifetime: How Objects Are Created and Destroyed](../../../visual-basic/programming-guide/language-features/objects-and-classes/object-lifetime-how-objects-are-created-and-destroyed.md).

#### Destructors
Destructors are used to destruct instances of classes. In the .NET Framework, the garbage collector automatically manages the allocation and release of memory for the managed objects in your application. However, you may still need destructors to clean up any unmanaged resources that your application creates. There can be only one destructor for a class.

For more information about destructors and garbage collection in the .NET Framework, see [Garbage Collection](../../../standard/garbage-collection/index.md).

#### Events
Events enable a class or object to notify other classes or objects when something of interest occurs. The class that sends (or raises) the event is called the *publisher* and the classes that receive (or handle) the event are called *subscribers*. For more information about events, how they are raised and handled, see [Events](../../../standard/events/index.md).

- To declare events, use the [Event Statement](../../../visual-basic/language-reference/statements/event-statement.md).

- To raise events, use the [RaiseEvent Statement](../../../visual-basic/language-reference/statements/raiseevent-statement.md).

- To specify event handlers using a declarative way, use the [WithEvents](../../../visual-basic/language-reference/modifiers/withevents.md) statement and the [Handles](../../../visual-basic/language-reference/statements/handles-clause.md) clause.

- To be able to dynamically add, remove, and change the event handler associated with an event, use the [AddHandler Statement](../../../visual-basic/language-reference/statements/addhandler-statement.md) and [RemoveHandler Statement](../../../visual-basic/language-reference/statements/removehandler-statement.md) together with the [AddressOf Operator](../../../visual-basic/language-reference/operators/addressof-operator.md).

#### Nested classes  
A class defined within another class is called *nested*. By default, the nested class is private.

```vb
Class Container
    Class Nested
    ' Add code here.
    End Class
End Class
```

To create an instance of the nested class, use the name of the container class followed by the dot and then followed by the name of the nested class:

```vb
Dim nestedInstance As Container.Nested = New Container.Nested()
```

### Access modifiers and access levels  
All classes and class members can specify what access level they provide to other classes by using *access modifiers*.

The following access modifiers are available:

|Visual Basic Modifier|Definition|
|---------------------------|----------------|
|[Public](../../../visual-basic/language-reference/modifiers/public.md)|The type or member can be accessed by any other code in the same assembly or another assembly that references it.|
|[Private](../../../visual-basic/language-reference/modifiers/private.md)|The type or member can only be accessed by code in the same class.|
|[Protected](../../../visual-basic/language-reference/modifiers/protected.md)|The type or member can only be accessed by code in the same class or in a derived class.|
|[Friend](../../../visual-basic/language-reference/modifiers/friend.md)|The type or member can be accessed by any code in the same assembly, but not from another assembly.|
|`Protected Friend`|The type or member can be accessed by any code in the same assembly, or by any derived class in another assembly.|

For more information, see [Access levels in Visual Basic](../../../visual-basic/programming-guide/language-features/declared-elements/access-levels.md).

### Instantiating classes  
To create an object, you need to instantiate a class, or create a class instance.

```vb
Dim sampleObject as New SampleClass()
```

After instantiating a class, you can assign values to the instance's properties and fields and invoke class methods.

```vb
' Set a property value.
sampleObject.SampleProperty = "Sample String"
' Call a method.
sampleObject.SampleMethod()
```

To assign values to properties during the class instantiation process, use object initializers:

```vb
Dim sampleObject = New SampleClass With
    {.FirstProperty = "A", .SecondProperty = "B"}
```

For more information, see:

- [New Operator](../../../visual-basic/language-reference/operators/new-operator.md)

- [Object Initializers: Named and Anonymous Types](../../../visual-basic/programming-guide/language-features/objects-and-classes/object-initializers-named-and-anonymous-types.md)

###  <a name="Static"></a> Shared Classes and Members  
 A shared member of the class is a property, procedure, or field that is shared by all instances of a class.  
  
 To define a shared member:  
  
```vb  
Class SampleClass  
    Public Shared SampleString As String = "Sample String"  
End Class  
```  
  
 To access the shared member, use the name of the class without creating an object of this class:  
  
```vb  
MsgBox(SampleClass.SampleString)  
```  
  
 Shared modules in Visual Basic have shared members only and cannot be instantiated. Shared members also cannot access non-shared properties, fields or methods  
  
 For more information, see:  
  
-   [Shared](../../../visual-basic/language-reference/modifiers/shared.md)  
  
-   [Module Statement](../../../visual-basic/language-reference/statements/module-statement.md)  
  
### Anonymous types  
Anonymous types enable you to create objects without writing a class definition for the data type. Instead, the compiler generates a class for you. The class has no usable name and contains the properties you specify in declaring the object.

To create an instance of an anonymous type:

```vb
' sampleObject is an instance of a simple anonymous type.
Dim sampleObject =
    New With {Key .FirstProperty = "A", .SecondProperty = "B"}
```

For more information, see: [Anonymous Types](../../../visual-basic/programming-guide/language-features/objects-and-classes/anonymous-types.md).

## Inheritance
Inheritance enables you to create a new class that reuses, extends, and modifies the behavior that is defined in another class. The class whose members are inherited is called the *base class*, and the class that inherits those members is called the *derived class*. However, all classes in Visual Basic implicitly inherit from the <xref:System.Object> class that supports .NET class hierarchy and provides low-level services to all classes.

> [!NOTE]
>  Visual Basic doesn't support multiple inheritance. That is, you can specify only one base class for a derived class.

To inherit from a base class:

```vb
Class DerivedClass
    Inherits BaseClass
End Class
```

By default all classes can be inherited. However, you can specify whether a class must not be used as a base class, or create a class that can be used as a base class only.

To specify that a class cannot be used as a base class:

```vb
NotInheritable Class SampleClass
End Class
```

To specify that a class can be used as a base class only and cannot be instantiated:

```vb
MustInherit Class BaseClass
End Class
```

For more information, see:

- [Inherits Statement](../../../visual-basic/language-reference/statements/inherits-statement.md)

- [NotInheritable](../../../visual-basic/language-reference/modifiers/notinheritable.md)

- [MustInherit](../../../visual-basic/language-reference/modifiers/mustinherit.md)

### Overriding members
By default, a derived class inherits all members from its base class. If you want to change the behavior of the inherited member, you need to override it. That is, you can define a new implementation of the method, property or event in the derived class.

The following modifiers are used to control how properties and methods are overridden:

|Visual Basic Modifier|Definition|
|---------------------------|----------------|
|[Overridable](../../../visual-basic/language-reference/modifiers/overridable.md)|Allows a class member to be overridden in a derived class.|
|[Overrides](../../../visual-basic/language-reference/modifiers/overrides.md)|Overrides a virtual (overridable) member defined in the base class.|
|[NotOverridable](../../../visual-basic/language-reference/modifiers/notoverridable.md)|Prevents a member from being overridden in an inheriting class.|
|[MustOverride](../../../visual-basic/language-reference/modifiers/mustoverride.md)|Requires that a class member to be overridden in the derived class.|
|[Shadows](../../../visual-basic/language-reference/modifiers/shadows.md)|Hides a member inherited from a base class|

## Interfaces
Interfaces, like classes, define a set of properties, methods, and events. But unlike classes, interfaces do not provide implementation. They are implemented by classes, and defined as separate entities from classes. An interface represents a contract, in that a class that implements an interface must implement every aspect of that interface exactly as it is defined.

To define an interface:

```vb
Public Interface ISampleInterface
    Sub DoSomething()
End Interface
```

To implement an interface in a class:

```vb
Class SampleClass
    Implements ISampleInterface
    Sub DoSomething
        ' Method implementation.
    End Sub
End Class
```

For more information, see:

- [Interfaces](../../../visual-basic/programming-guide/language-features/interfaces/index.md)  

- [Interface Statement](../../../visual-basic/language-reference/statements/interface-statement.md)  

- [Implements Statement](../../../visual-basic/language-reference/statements/implements-statement.md)  

## Generics
Classes, structures, interfaces and methods in .NET can include *type parameters* that define types of objects that they can store or use. The most common example of generics is a collection, where you can specify the type of objects to be stored in a collection.  

To define a generic class:

```vb
Class SampleGeneric(Of T)
    Public Field As T
End Class
```

To create an instance of a generic class:

```vb
Dim sampleObject As New SampleGeneric(Of String)
sampleObject.Field = "Sample string"
```

For more information, see:

- [Generics](~/docs/standard/generics/index.md)

- [Generic Types in Visual Basic](../../../visual-basic/programming-guide/language-features/data-types/generic-types.md)

## Delegates
 A *delegate* is a type that defines a method signature, and can provide a reference to any method with a compatible signature. You can invoke (or call) the method through the delegate. Delegates are used to pass methods as arguments to other methods.

> [!NOTE]
>  Event handlers are nothing more than methods that are invoked through delegates. For more information about using delegates in event handling, see [Events](../../../standard/events/index.md).

To create a delegate:

```vb
Delegate Sub SampleDelegate(ByVal str As String)
```

To create a reference to a method that matches the signature specified by the delegate:

```vb
Class SampleClass
    ' Method that matches the SampleDelegate signature.
    Sub SampleSub(ByVal str As String)
        ' Add code here.
    End Sub
    ' Method that instantiates the delegate.
    Sub SampleDelegateSub()
        Dim sd As SampleDelegate = AddressOf SampleSub
        sd("Sample string")
    End Sub
End Class
```

For more information, see:

- [Delegates](../../../visual-basic/programming-guide/language-features/delegates/index.md)

- [Delegate Statement](../../../visual-basic/language-reference/statements/delegate-statement.md)

- [AddressOf Operator](../../../visual-basic/language-reference/operators/addressof-operator.md)

## See also
 [Visual Basic Programming Guide](../../../visual-basic/programming-guide/index.md)
