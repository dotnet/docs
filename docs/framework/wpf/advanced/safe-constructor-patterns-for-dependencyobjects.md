---
title: "Safe Constructor Patterns for DependencyObjects"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-wpf"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "constructor patterns for dependency objects [WPF]"
  - "dependency objects [WPF], constructor patterns"
  - "FXCop tool [WPF]"
ms.assetid: f704b81c-449a-47a4-ace1-9332e3cc6d60
caps.latest.revision: 12
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Safe Constructor Patterns for DependencyObjects
Generally, class constructors should not call callbacks such as virtual methods or delegates, because constructors can be called as base initialization of constructors for a derived class. Entering the virtual might be done at an incomplete initialization state of any given object. However, the property system itself calls and exposes callbacks internally, as part of the dependency property system. As simple an operation as setting a dependency property value with <xref:System.Windows.DependencyObject.SetValue%2A> call potentially includes a callback somewhere in the determination. For this reason, you should be careful when setting dependency property values within the body of a constructor, which can become problematic if your type is used as a base class. There is a particular pattern for implementing <xref:System.Windows.DependencyObject> constructors that avoids specific problems with dependency property states and the inherent callbacks, which is documented here.  
  
 
  
<a name="Property_System_Virtual_Methods"></a>   
## Property System Virtual Methods  
 The following virtual methods or callbacks are potentially called during the computations of the <xref:System.Windows.DependencyObject.SetValue%2A> call that sets a dependency property value: <xref:System.Windows.ValidateValueCallback>, <xref:System.Windows.PropertyChangedCallback>, <xref:System.Windows.CoerceValueCallback>, <xref:System.Windows.DependencyObject.OnPropertyChanged%2A>. Each of these virtual methods or callbacks serves a particular purpose in expanding the versatility of the [!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)] property system and dependency properties. For more information on how to use these virtuals to customize property value determination, see [Dependency Property Callbacks and Validation](../../../../docs/framework/wpf/advanced/dependency-property-callbacks-and-validation.md).  
  
### FXCop Rule Enforcement vs. Property System Virtuals  
 If you use the Microsoft tool FXCop as part of your build process, and you either derive from certain [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] framework classes calling the base constructor, or implement your own dependency properties on derived classes, you might encounter a particular FXCop rule violation. The name string for this violation is:  
  
 `DoNotCallOverridableMethodsInConstructors`  
  
 This is a rule that is part of the default public rule set for FXCop. What this rule might be reporting is a trace through the dependency property system that eventually calls a dependency property system virtual method. This rule violation might continue to appear even after following the recommended constructor patterns documented in this topic, so you might need to disable or suppress that rule in your FXCop rule set configuration.  
  
### Most Issues Come From Deriving Classes, Not Using Existing Classes  
 The issues reported by this rule occur when a class that you implement with virtual methods in its construction sequence is then derived from. If you seal your class, or otherwise know or enforce that your class will not be derived from, the considerations explained here and the issues that motivated the FXCop rule do not apply to you. However, if you are authoring classes in such a way that they are intended to be used as base classes, for instance if you are creating templates, or an expandable control library set, you should follow the patterns recommended here for constructors.  
  
### Default Constructors Must Initialize All Values Requested By Callbacks  
 Any instance members that are used by your class overrides or callbacks (the callbacks from the list in the Property System Virtuals section) must be initialized in your class default constructor, even if some of those values are filled by "real" values through parameters of the nondefault constructors.  
  
 The following example code (and subsequent examples) is a pseudo-C# example that violates this rule and explains the problem:  
  
```  
public class MyClass : DependencyObject  
{  
    public MyClass() {}  
    public MyClass(object toSetWobble)  
        : this()  
    {  
        Wobble = toSetWobble; //this is backed by a DependencyProperty  
        _myList = new ArrayList();    // this line should be in the default ctor  
    }  
    public static readonly DependencyProperty WobbleProperty =   
        DependencyProperty.Register("Wobble", typeof(object), typeof(MyClass));  
    public object Wobble  
    {  
        get { return GetValue(WobbleProperty); }  
        set { SetValue(WobbleProperty, value); }  
    }  
    protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)  
    {  
        int count = _myList.Count;    // null-reference exception  
    }  
    private ArrayList _myList;  
}  
```  
  
 When application code calls `new MyClass(objectvalue)`, this calls the default constructor and base class constructors. Then it sets `Property1 = object1`, which calls the virtual method `OnPropertyChanged` on the owning `MyClass` <xref:System.Windows.DependencyObject>.  The override refers to `_myList`, which has not been initialized yet.  
  
 One way to avoid these issues is to make sure that callbacks use only other dependency properties, and that each such dependency property has an established default value as part of its registered metadata.  
  
<a name="Safe_Constructor_Patterns"></a>   
## Safe Constructor Patterns  
 To avoid the risks of incomplete initialization if your class is used as a base class, follow these patterns:  
  
#### Default constructors calling base initialization  
 Implement these constructors calling the base default:  
  
```  
public MyClass : SomeBaseClass {  
    public MyClass() : base() {  
        // ALL class initialization, including initial defaults for   
        // possible values that other ctors specify or that callbacks need.  
    }  
}  
```  
  
#### Non-default (convenience) constructors, not matching any base signatures  
 If these constructors use the parameters to set dependency properties in the initialization, first call your own class default constructor for initialization, and then use the parameters to set dependency properties. These could either be dependency properties defined by your class, or dependency properties inherited from base classes, but in either case use the following pattern:  
  
```  
public MyClass : SomeBaseClass {  
    public MyClass(object toSetProperty1) : this() {  
        // Class initialization NOT done by default.  
        // Then, set properties to values as passed in ctor parameters.  
        Property1 = toSetProperty1;  
    }  
}  
```  
  
#### Non-default (convenience) constructors, which do match base signatures  
 Instead of calling the base constructor with the same parameterization, again call your own class' default constructor. Do not call the base initializer; instead you should call `this()`. Then reproduce the original constructor behavior by using the passed parameters as values for setting the relevant properties. Use the original base constructor documentation for guidance in determining the properties that the particular parameters are intended to set:  
  
```  
public MyClass : SomeBaseClass {  
    public MyClass(object toSetProperty1) : this() {  
        // Class initialization NOT done by default.  
        // Then, set properties to values as passed in ctor parameters.  
        Property1 = toSetProperty1;  
    }  
}  
```  
  
#### Must match all signatures  
 For cases where the base type has multiple signatures, you must deliberately match all possible signatures with a constructor implementation of your own that uses the recommended pattern of calling the class default constructor before setting further properties.  
  
#### Setting dependency properties with SetValue  
 These same patterns apply if you are setting a property that does not have a wrapper for property setting convenience, and set values with <xref:System.Windows.DependencyObject.SetValue%2A>. Your calls to <xref:System.Windows.DependencyObject.SetValue%2A> that pass through constructor parameters should also call the class' default constructor for initialization.  
  
## See Also  
 [Custom Dependency Properties](../../../../docs/framework/wpf/advanced/custom-dependency-properties.md)  
 [Dependency Properties Overview](../../../../docs/framework/wpf/advanced/dependency-properties-overview.md)  
 [Dependency Property Security](../../../../docs/framework/wpf/advanced/dependency-property-security.md)
