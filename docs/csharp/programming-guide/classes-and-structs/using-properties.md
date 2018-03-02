---
title: "Using Properties (C# Programming Guide)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "set accessor [C#]"
  - "get accessor [C#]"
  - "properties [C#], about properties"
ms.assetid: f7f67b05-0983-4cdb-96af-1855d24c967c
caps.latest.revision: 24
author: "BillWagner"
ms.author: "wiwagn"
---
# Using Properties (C# Programming Guide)
Properties combine aspects of both fields and methods. To the user of an object, a property appears to be a field, accessing the property requires the same syntax. To the implementer of a class, a property is one or two code blocks, representing a [get](../../../csharp/language-reference/keywords/get.md) accessor and/or a [set](../../../csharp/language-reference/keywords/set.md) accessor. The code block for the `get` accessor is executed when the property is read; the code block for the `set` accessor is executed when the property is assigned a new value. A property without a `set` accessor is considered read-only. A property without a `get` accessor is considered write-only. A property that has both accessors is read-write.  
  
 Unlike fields, properties are not classified as variables. Therefore, you cannot pass a property as a [ref](../../../csharp/language-reference/keywords/ref.md) or [out](../../../csharp/language-reference/keywords/out-parameter-modifier.md) parameter.  
  
 Properties have many uses: they can validate data before allowing a change; they can transparently expose data on a class where that data is actually retrieved from some other source, such as a database; they can take an action when data is changed, such as raising an event, or changing the value of other fields.  
  
 Properties are declared in the class block by specifying the access level of the field, followed by the type of the property, followed by the name of the property, and followed by a code block that declares a `get`-accessor and/or a `set` accessor. For example:  
  
 [!code-csharp[csProgGuideProperties#7](../../../csharp/programming-guide/classes-and-structs/codesnippet/CSharp/using-properties_1.cs)]  
  
 In this example, `Month` is declared as a property so that the `set` accessor can make sure that the `Month` value is set between 1 and 12. The `Month` property uses a private field to track the actual value. The real location of a property's data is often referred to as the property's "backing store." It is common for properties to use private fields as a backing store. The field is marked private in order to make sure that it can only be changed by calling the property. For more information about public and private access restrictions, see [Access Modifiers](../../../csharp/programming-guide/classes-and-structs/access-modifiers.md).  
  
 Auto-implemented properties provide simplified syntax for simple property declarations. For more information, see [Auto-Implemented Properties](../../../csharp/programming-guide/classes-and-structs/auto-implemented-properties.md).  
  
## The get Accessor  
 The body of the `get` accessor resembles that of a method. It must return a value of the property type. The execution of the `get` accessor is equivalent to reading the value of the field. For example, when you are returning the private variable from the `get` accessor and optimizations are enabled, the call to the `get` accessor method is inlined by the compiler so there is no method-call overhead. However, a virtual `get` accessor method cannot be inlined because the compiler does not know at compile-time which method may actually be called at run time. The following is a `get` accessor that returns the value of a private field `name`:  
  
 [!code-csharp[csProgGuideProperties#8](../../../csharp/programming-guide/classes-and-structs/codesnippet/CSharp/using-properties_2.cs)]  
  
 When you reference the property, except as the target of an assignment, the `get` accessor is invoked to read the value of the property. For example:  
  
 [!code-csharp[csProgGuideProperties#9](../../../csharp/programming-guide/classes-and-structs/codesnippet/CSharp/using-properties_3.cs)]  
  
 The `get` accessor must end in a [return](../../../csharp/language-reference/keywords/return.md) or [throw](../../../csharp/language-reference/keywords/throw.md) statement, and control cannot flow off the accessor body.  
  
 It is a bad programming style to change the state of the object by using the `get` accessor. For example, the following accessor produces the side effect of changing the state of the object every time that the `number` field is accessed.  
  
 [!code-csharp[csProgGuideProperties#10](../../../csharp/programming-guide/classes-and-structs/codesnippet/CSharp/using-properties_4.cs)]  
  
 The `get` accessor can be used to return the field value or to compute it and return it. For example:  
  
 [!code-csharp[csProgGuideProperties#11](../../../csharp/programming-guide/classes-and-structs/codesnippet/CSharp/using-properties_5.cs)]  
  
 In the previous code segment, if you do not assign a value to the `Name` property, it will return the value NA.  
  
## The set Accessor  
 The `set` accessor resembles a method whose return type is [void](../../../csharp/language-reference/keywords/void.md). It uses an implicit parameter called `value`, whose type is the type of the property. In the following example, a `set` accessor is added to the `Name` property:  
  
 [!code-csharp[csProgGuideProperties#12](../../../csharp/programming-guide/classes-and-structs/codesnippet/CSharp/using-properties_6.cs)]  
  
 When you assign a value to the property, the `set` accessor is invoked by using an argument that provides the new value. For example:  
  
 [!code-csharp[csProgGuideProperties#13](../../../csharp/programming-guide/classes-and-structs/codesnippet/CSharp/using-properties_7.cs)]  
  
 It is an error to use the implicit parameter name, `value`, for a local variable declaration in a `set` accessor.  
  
## Remarks  
 Properties can be marked as `public`, `private`, `protected`, `internal`, `protected internal` or `private protected`. These access modifiers define how users of the class can access the property. The `get` and `set` accessors for the same property may have different access modifiers. For example, the `get` may be `public` to allow read-only access from outside the type, and the `set` may be `private` or `protected`. For more information, see [Access Modifiers](../../../csharp/programming-guide/classes-and-structs/access-modifiers.md).  
  
 A property may be declared as a static property by using the `static` keyword. This makes the property available to callers at any time, even if no instance of the class exists. For more information, see [Static Classes and Static Class Members](../../../csharp/programming-guide/classes-and-structs/static-classes-and-static-class-members.md).  
  
 A property may be marked as a virtual property by using the [virtual](../../../csharp/language-reference/keywords/virtual.md) keyword. This enables derived classes to override the property behavior by using the [override](../../../csharp/language-reference/keywords/override.md) keyword. For more information about these options, see [Inheritance](../../../csharp/programming-guide/classes-and-structs/inheritance.md).  
  
 A property overriding a virtual property can also be [sealed](../../../csharp/language-reference/keywords/sealed.md), specifying that for derived classes it is no longer virtual. Lastly, a property can be declared [abstract](../../../csharp/language-reference/keywords/abstract.md). This means that there is no implementation in the class, and derived classes must write their own implementation. For more information about these options, see [Abstract and Sealed Classes and Class Members](../../../csharp/programming-guide/classes-and-structs/abstract-and-sealed-classes-and-class-members.md).  
  
> [!NOTE]
>  It is an error to use a [virtual](../../../csharp/language-reference/keywords/virtual.md), [abstract](../../../csharp/language-reference/keywords/abstract.md), or [override](../../../csharp/language-reference/keywords/override.md) modifier on an accessor of a [static](../../../csharp/language-reference/keywords/static.md) property.  
  
## Example  
 This example demonstrates instance, static, and read-only properties. It accepts the name of the employee from the keyboard, increments `NumberOfEmployees` by 1, and displays the Employee name and number.  
  
 [!code-csharp[csProgGuideProperties#2](../../../csharp/programming-guide/classes-and-structs/codesnippet/CSharp/using-properties_8.cs)]  
  
## Example  
 This example demonstrates how to access a property in a base class that is hidden by another property that has the same name in a derived class.  
  
 [!code-csharp[csProgGuideProperties#3](../../../csharp/programming-guide/classes-and-structs/codesnippet/CSharp/using-properties_9.cs)]  
  
 The following are important points in the previous example:  
  
-   The property `Name` in the derived class hides the property `Name` in the base class. In such a case, the `new` modifier is used in the declaration of the property in the derived class:  
  
     [!code-csharp[csProgGuideProperties#4](../../../csharp/programming-guide/classes-and-structs/codesnippet/CSharp/using-properties_10.cs)]  
  
-   The cast `(Employee)` is used to access the hidden property in the base class:  
  
     [!code-csharp[csProgGuideProperties#5](../../../csharp/programming-guide/classes-and-structs/codesnippet/CSharp/using-properties_11.cs)]  
  
     For more information about hiding members, see the [new Modifier](../../../csharp/language-reference/keywords/new-modifier.md).  
  
## Example  
 In this example, two classes, `Cube` and `Square`, implement an abstract class, `Shape`, and override its abstract `Area` property. Note the use of the [override](../../../csharp/language-reference/keywords/override.md) modifier on the properties. The program accepts the side as an input and calculates the areas for the square and cube. It also accepts the area as an input and calculates the corresponding side for the square and cube.  
  
 [!code-csharp[csProgGuideProperties#6](../../../csharp/programming-guide/classes-and-structs/codesnippet/CSharp/using-properties_12.cs)]  
  
## See Also  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [Properties](../../../csharp/programming-guide/classes-and-structs/properties.md)  
 [Interface Properties](../../../csharp/programming-guide/classes-and-structs/interface-properties.md)  
 [Auto-Implemented Properties](../../../csharp/programming-guide/classes-and-structs/auto-implemented-properties.md)
