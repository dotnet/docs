---
title: "Object Lifetime: How Objects Are Created and Destroyed (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vb.Constructor"
helpviewer_keywords: 
  - "destructors, object lifetime"
  - "Sub Finalize destructor"
  - "objects [Visual Basic], destroying"
  - "lifetime [Visual Basic], objects"
  - "Sub New constructor, object lifetime"
  - "Finalize method [Visual Basic], object lifetime"
  - "objects [Visual Basic], creating"
  - "Class_Terminate"
  - "Dispose method [Visual Basic], object lifetime"
  - "Class_Initialize"
  - "object creation [Visual Basic], object lifetime"
  - "parameterized constructors"
  - "objects [Visual Basic], lifetime"
  - "objects [Visual Basic], garbage collection"
  - "constructors [Visual Basic], object lifetime"
  - "Sub Dispose destructor"
  - "garbage collection [Visual Basic], Visual Basic"
ms.assetid: f1ee8458-b156-44e0-9a8a-5dd171648cd8
caps.latest.revision: 22
author: dotnet-bot
ms.author: dotnetcontent
---
# Object Lifetime: How Objects Are Created and Destroyed (Visual Basic)
An instance of a class, an object, is created by using the `New` keyword. Initialization tasks often must be performed on new objects before they are used. Common initialization tasks include opening files, connecting to databases, and reading values of registry keys. Visual Basic controls the initialization of new objects using procedures called *constructors* (special methods that allow control over initialization).  
  
 After an object leaves scope, it is released by the common language runtime (CLR). Visual Basic controls the release of system resources using procedures called *destructors*. Together, constructors and destructors support the creation of robust and predictable class libraries.  
  
## Using Constructors and Destructors  
 Constructors and destructors control the creation and destruction of objects. The `Sub New` and `Sub Finalize` procedures in Visual Basic initialize and destroy objects; they replace the `Class_Initialize` and `Class_Terminate` methods used in [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] 6.0 and earlier versions.  
  
### Sub New  
 The `Sub New` constructor can run only once when a class is created. It cannot be called explicitly anywhere other than in the first line of code of another constructor from either the same class or from a derived class. Furthermore, the code in the `Sub New` method always runs before any other code in a class. [!INCLUDE[vbprvblong](~/includes/vbprvblong-md.md)] and later versions implicitly create a `Sub New` constructor at run time if you do not explicitly define a `Sub New` procedure for a class.  
  
 To create a constructor for a class, create a procedure named `Sub New` anywhere in the class definition. To create a parameterized constructor, specify the names and data types of arguments to `Sub New` just as you would specify arguments for any other procedure, as in the following code:  
  
 [!code-vb[VbVbalrOOP#42](../../../../visual-basic/misc/codesnippet/VisualBasic/object-lifetime-how-objects-are-created-and-destroyed_1.vb)]  
  
 Constructors are frequently overloaded, as in the following code:  
  
 [!code-vb[VbVbalrOOP#116](../../../../visual-basic/misc/codesnippet/VisualBasic/object-lifetime-how-objects-are-created-and-destroyed_2.vb)]  
  
 When you define a class derived from another class, the first line of a constructor must be a call to the constructor of the base class, unless the base class has an accessible constructor that takes no parameters. A call to the base class that contains the above constructor, for example, would be `MyBase.New(s)`. Otherwise, `MyBase.New` is optional, and the [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] runtime calls it implicitly.  
  
 After you write the code to call the parent object's constructor, you can add any additional initialization code to the `Sub New` procedure. `Sub New` can accept arguments when called as a parameterized constructor. These parameters are passed from the procedure calling the constructor, for example, `Dim AnObject As New ThisClass(X)`.  
  
### Sub Finalize  
 Before releasing objects, the CLR automatically calls the `Finalize` method for objects that define a `Sub Finalize` procedure. The `Finalize` method can contain code that needs to execute just before an object is destroyed, such as code for closing files and saving state information. There is a slight performance penalty for executing `Sub Finalize`, so you should define a `Sub Finalize` method only when you need to release objects explicitly.  
  
> [!NOTE]
>  The garbage collector in the CLR does not (and cannot) dispose of *unmanaged objects*, objects that the operating system executes directly, outside the CLR environment. This is because different unmanaged objects must be disposed of in different ways. That information is not directly associated with the unmanaged object; it must be found in the documentation for the object. A class that uses unmanaged objects must dispose of them in its `Finalize` method.  
  
 The `Finalize` destructor is a protected method that can be called only from the class it belongs to, or from derived classes. The system calls `Finalize` automatically when an object is destroyed, so you should not explicitly call `Finalize` from outside of a derived class's `Finalize` implementation.  
  
 Unlike `Class_Terminate`, which executes as soon as an object is set to nothing, there is usually a delay between when an object loses scope and when Visual Basic calls the `Finalize` destructor. [!INCLUDE[vbprvblong](~/includes/vbprvblong-md.md)] and later versions allow for a second kind of destructor, <xref:System.IDisposable.Dispose%2A>, which can be explicitly called at any time to immediately release resources.  
  
> [!NOTE]
>  A `Finalize` destructor should not throw exceptions, because they cannot be handled by the application and can cause the application to terminate.  
  
### How New and Finalize Methods Work in a Class Hierarchy  
 Whenever an instance of a class is created, the common language runtime (CLR) attempts to execute a procedure named `New`, if it exists in that object. `New` is a type of procedure called a `constructor` that is used to initialize new objects before any other code in an object executes. A `New` constructor can be used to open files, connect to databases, initialize variables, and take care of any other tasks that need to be done before an object can be used.  
  
 When an instance of a derived class is created, the `Sub New` constructor of the base class executes first, followed by constructors in derived classes. This happens because the first line of code in a `Sub New` constructor uses the syntax `MyBase.New()`to call the constructor of the class immediately above itself in the class hierarchy. The `Sub New` constructor is then called for each class in the class hierarchy until the constructor for the base class is reached. At that point, the code in the constructor for the base class executes, followed by the code in each constructor in all derived classes and the code in the most derived classes is executed last.  
  
 ![Constructors and Inheritance](../../../../visual-basic/programming-guide/language-features/objects-and-classes/media/vaconstructorsinheritance.gif "vaConstructorsInheritance")  
  
 When an object is no longer needed, the CLR calls the <xref:System.Object.Finalize%2A> method for that object before freeing its memory. The <xref:System.Object.Finalize%2A> method is called a `destructor` because it performs cleanup tasks, such as saving state information, closing files and connections to databases, and other tasks that must be done before releasing the object.  
  
 ![Constructors Inheritance2](../../../../visual-basic/programming-guide/language-features/objects-and-classes/media/vaconstructorsinheritance_2.gif "vaConstructorsInheritance_2")  
  
## IDisposable Interface  
 Class instances often control resources not managed by the CLR, such as Windows handles and database connections. These resources must be disposed of in the `Finalize` method of the class, so that they will be released when the object is destroyed by the garbage collector. However, the garbage collector destroys objects only when the CLR requires more free memory. This means that the resources may not be released until long after the object goes out of scope.  
  
 To supplement garbage collection, your classes can provide a mechanism to actively manage system resources if they implement the <xref:System.IDisposable> interface. <xref:System.IDisposable> has one method, <xref:System.IDisposable.Dispose%2A>, which clients should call when they finish using an object. You can use the <xref:System.IDisposable.Dispose%2A> method to immediately release resources and perform tasks such as closing files and database connections. Unlike the `Finalize` destructor, the <xref:System.IDisposable.Dispose%2A> method is not called automatically. Clients of a class must explicitly call <xref:System.IDisposable.Dispose%2A> when you want to immediately release resources.  
  
### Implementing IDisposable  
 A class that implements the <xref:System.IDisposable> interface should include these sections of code:  
  
-   A field for keeping track of whether the object has been disposed:  
  
    ```  
    Protected disposed As Boolean = False  
    ```  
  
-   An overload of the <xref:System.IDisposable.Dispose%2A> that frees the class's resources. This method should be called by the <xref:System.IDisposable.Dispose%2A> and `Finalize` methods of the base class:  
  
    ```  
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)  
        If Not Me.disposed Then  
            If disposing Then  
                ' Insert code to free managed resources.  
            End If  
            ' Insert code to free unmanaged resources.  
        End If  
        Me.disposed = True  
    End Sub  
    ```  
  
-   An implementation of <xref:System.IDisposable.Dispose%2A> that contains only the following code:  
  
    ```  
    Public Sub Dispose() Implements IDisposable.Dispose  
        Dispose(True)  
        GC.SuppressFinalize(Me)  
    End Sub  
    ```  
  
-   An override of the `Finalize` method that contains only the following code:  
  
    ```  
    Protected Overrides Sub Finalize()  
        Dispose(False)  
        MyBase.Finalize()  
    End Sub  
    ```  
  
### Deriving from a Class that Implements IDisposable  
 A class that derives from a base class that implements the <xref:System.IDisposable> interface does not need to override any of the base methods unless it uses additional resources that need to be disposed. In that situation, the derived class should override the base class's `Dispose(disposing)` method to dispose of the derived class's resources. This override must call the base class's `Dispose(disposing)` method.  
  
```  
Protected Overrides Sub Dispose(ByVal disposing As Boolean)  
    If Not Me.disposed Then  
        If disposing Then  
            ' Insert code to free managed resources.  
        End If  
        ' Insert code to free unmanaged resources.  
    End If  
    MyBase.Dispose(disposing)  
End Sub  
```  
  
 A derived class should not override the base class's <xref:System.IDisposable.Dispose%2A> and `Finalize` methods. When those methods are called from an instance of the derived class, the base class's implementation of those methods call the derived class's override of the `Dispose(disposing)` method.  
  
## Garbage Collection and the Finalize Destructor  
 The [!INCLUDE[dnprdnshort](~/includes/dnprdnshort-md.md)] uses the *reference-tracing garbage collection* system to periodically release unused resources. Visual Basic 6.0 and earlier versions used a different system called *reference counting* to manage resources. Although both systems perform the same function automatically, there are a few important differences.  
  
 The CLR periodically destroys objects when the system determines that such objects are no longer needed. Objects are released more quickly when system resources are in short supply, and less frequently otherwise. The delay between when an object loses scope and when the CLR releases it means that, unlike with objects in Visual Basic 6.0 and earlier versions, you cannot determine exactly when the object will be destroyed. In such a situation, objects are said to have *non-deterministic lifetime*. In most cases, non-deterministic lifetime does not change how you write applications, as long as you remember that the `Finalize` destructor may not immediately execute when an object loses scope.  
  
 Another difference between the garbage-collection systems involves the use of `Nothing`. To take advantage of reference counting in Visual Basic 6.0 and earlier versions, programmers sometimes assigned `Nothing` to object variables to release the references those variables held. If the variable held the last reference to the object, the object's resources were released immediately. In later versions of Visual Basic, while there may be cases in which this procedure is still valuable, performing it never causes the referenced object to release its resources immediately. To release resources immediately, use the object's <xref:System.IDisposable.Dispose%2A> method, if available. The only time you should set a variable to `Nothing` is when its lifetime is long relative to the time the garbage collector takes to detect orphaned objects.  
  
## See Also  
 <xref:System.IDisposable.Dispose%2A>  
 [Initialization and Termination of Components](http://msdn.microsoft.com/library/58444076-a9d2-4c91-b3f6-0e180dc0695d)  
 [New Operator](../../../../visual-basic/language-reference/operators/new-operator.md)  
 [Cleaning Up Unmanaged Resources](../../../../standard/garbage-collection/unmanaged.md)  
 [Nothing](../../../../visual-basic/language-reference/nothing.md)
