---
title: "Extension Methods (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vb.ExtensionMethods"
helpviewer_keywords: 
  - "extending data types [Visual Basic]"
  - "extension methods [Visual Basic]"
ms.assetid: b8020aae-374d-46a9-bcb7-8cc2390b93b6
caps.latest.revision: 41
author: dotnet-bot
ms.author: dotnetcontent
---
# Extension Methods (Visual Basic)
Extension methods enable developers to add custom functionality to data types that are already defined without creating a new derived type. Extension methods make it possible to write a method that can be called as if it were an instance method of the existing type.  
  
## Remarks  
 An extension method can be only a `Sub` procedure or a `Function` procedure. You cannot define an extension property, field, or event. All extension methods must be marked with the extension attribute `<Extension()>` from the <xref:System.Runtime.CompilerServices?displayProperty=nameWithType> namespace.  
  
 The first parameter in an extension method definition specifies which data type the method extends. When the method is run, the first parameter is bound to the instance of the data type that invokes the method.  
  
## Example  
  
### Description  
 The following example defines a `Print` extension to the <xref:System.String> data type. The method uses `Console.WriteLine` to display a string. The parameter of the `Print` method, `aString`, establishes that the method extends the <xref:System.String> class.  
  
 [!code-vb[VbVbalrExtensionMethods#1](./codesnippet/VisualBasic/extension-methods_1.vb)]  
  
 Notice that the extension method definition is marked with the extension attribute `<Extension()>`. Marking the module in which the method is defined is optional, but each extension method must be marked. <xref:System.Runtime.CompilerServices> must be imported in order to access the extension attribute.  
  
 Extension methods can be declared only within modules. Typically, the module in which an extension method is defined is not the same module as the one in which it is called. Instead, the module that contains the extension method is imported, if it needs to be, to bring it into scope. After the module that contains `Print` is in scope, the method can be called as if it were an ordinary instance method that takes no arguments, such as `ToUpper`:  
  
 [!code-vb[VbVbalrExtensionMethods#2](./codesnippet/VisualBasic/extension-methods_2.vb)]  
  
 The next example, `PrintAndPunctuate`, is also an extension to <xref:System.String>, this time defined with two parameters. The first parameter, `aString`, establishes that the extension method extends <xref:System.String>. The second parameter, `punc`, is intended to be a string of punctuation marks that is passed in as an argument when the method is called. The method displays the string followed by the punctuation marks.  
  
 [!code-vb[VbVbalrExtensionMethods#3](./codesnippet/VisualBasic/extension-methods_3.vb)]  
  
 The method is called by sending in a string argument for `punc`: `example.PrintAndPunctuate(".")`  
  
 The following example shows `Print` and `PrintAndPunctuate` defined and called. <xref:System.Runtime.CompilerServices> is imported in the definition module in order to enable access to the extension attribute.  
  
### Code  
  
```vb  
Imports System.Runtime.CompilerServices  
  
Module StringExtensions  
  
    <Extension()>   
    Public Sub Print(ByVal aString As String)  
        Console.WriteLine(aString)  
    End Sub  
  
    <Extension()>   
    Public Sub PrintAndPunctuate(ByVal aString As String,   
                                 ByVal punc As String)  
        Console.WriteLine(aString & punc)  
    End Sub  
  
End Module  
```  
  
 Next, the extension methods are brought into scope and called.  
  
```vb  
Imports ConsoleApplication2.StringExtensions  
Module Module1  
  
    Sub Main()  
  
        Dim example As String = "Example string"  
        example.Print()  
  
        example = "Hello"  
        example.PrintAndPunctuate(".")  
        example.PrintAndPunctuate("!!!!")  
  
    End Sub  
End Module  
```  
  
### Comments  
 All that is required to be able to run these or similar extension methods is that they be in scope. If the module that contains an extension method is in scope, it is visible in IntelliSense and can be called as if it were an ordinary instance method.  
  
 Notice that when the methods are invoked, no argument is sent in for the first parameter. Parameter `aString` in the previous method definitions is bound to `example`, the instance of `String` that calls them. The compiler will use `example` as the argument sent to the first parameter.  
  
 If an extension method is called for an object that is set to `Nothing`, the extension method executes. This does not apply to ordinary instance methods. You can explicitly check for `Nothing` in the extension method.  
  
## Types That Can Be Extended  
 You can define an extension method on most types that can be represented in a Visual Basic parameter list, including the following:  
  
-   Classes (reference types)  
  
-   Structures (value types)  
  
-   Interfaces  
  
-   Delegates  
  
-   ByRef and ByVal arguments  
  
-   Generic method parameters  
  
-   Arrays  
  
 Because the first parameter specifies the data type that the extension method extends, it is required and cannot be optional. For that reason, `Optional` parameters and `ParamArray` parameters cannot be the first parameter in the parameter list.  
  
 Extension methods are not considered in late binding. In the following example, the statement `anObject.PrintMe()` raises a <xref:System.MissingMemberException> exception, the same exception you would see if the second `PrintMe` extension method definition were deleted.  
  
 [!code-vb[VbVbalrExtensionMethods#9](./codesnippet/VisualBasic/extension-methods_4.vb)]  
  
## Best Practices  
 Extension methods provide a convenient and powerful way to extend an existing type. However, to use them successfully, there are some points to consider. These considerations apply mainly to authors of class libraries, but they might affect any application that uses extension methods.  
  
 Most generally, extension methods that you add to types that you do not own are more vulnerable than extension methods added to types that you control. A number of things can occur in classes you do not own that can interfere with your extension methods.  
  
-   If any accessible instance member exists that has a signature that is compatible with the arguments in the calling statement, with no narrowing conversions required from argument to parameter, the instance method will be used in preference to any extension method. Therefore, if an appropriate instance method is added to a class at some point, an existing extension member that you rely on may become inaccessible.  
  
-   The author of an extension method cannot prevent other programmers from writing conflicting extension methods that may have precedence over the original extension.  
  
-   You can improve robustness by putting extension methods in their own namespace. Consumers of your library can then include a namespace or exclude it, or select among namespaces, separately from the rest of the library.  
  
-   It may be safer to extend interfaces than it is to extend classes, especially if you do not own the interface or class. A change in an interface affects every class that implements it. Therefore, the author may be less likely to add or change methods in an interface. However, if a class implements two interfaces that have extension methods with the same signature, neither extension method is visible.  
  
-   Extend the most specific type you can. In a hierarchy of types, if you select a type from which many other types are derived, there are layers of possibilities for the introduction of instance methods or other extension methods that might interfere with yours.  
  
## Extension Methods, Instance Methods, and Properties  
 When an in-scope instance method has a signature that is compatible with the arguments of a calling statement, the instance method is chosen in preference to any extension method. The instance method has precedence even if the extension method is a better match. In the following example, `ExampleClass` contains an instance method named `ExampleMethod` that has one parameter of type `Integer`. Extension method `ExampleMethod` extends `ExampleClass`, and has one parameter of type `Long`.  
  
 [!code-vb[VbVbalrExtensionMethods#4](./codesnippet/VisualBasic/extension-methods_5.vb)]  
  
 The first call to `ExampleMethod` in the following code calls the extension method, because `arg1` is `Long` and is compatible only with the `Long` parameter in the extension method. The second call to `ExampleMethod` has an `Integer` argument, `arg2`, and it calls the instance method.  
  
 [!code-vb[VbVbalrExtensionMethods#5](./codesnippet/VisualBasic/extension-methods_6.vb)]  
  
 Now reverse the data types of the parameters in the two methods:  
  
 [!code-vb[VbVbalrExtensionMethods#6](./codesnippet/VisualBasic/extension-methods_7.vb)]  
  
 This time the code in `Main` calls the instance method both times. This is because both `arg1` and `arg2` have a widening conversion to `Long`, and the instance method takes precedence over the extension method in both cases.  
  
 [!code-vb[VbVbalrExtensionMethods#7](./codesnippet/VisualBasic/extension-methods_8.vb)]  
  
 Therefore, an extension method cannot replace an existing instance method. However, when an extension method has the same name as an instance method but the signatures do not conflict, both methods can be accessed. For example, if class `ExampleClass` contains a method named `ExampleMethod` that takes no arguments, extension methods with the same name but different signatures are permitted, as shown in the following code.  
  
 [!code-vb[VbVbalrExtensionMethods#8](./codesnippet/VisualBasic/extension-methods_9.vb)]  
  
 The output from this code is as follows:  
  
 `Extension method`  
  
 `Instance method`  
  
 The situation is simpler with properties: if an extension method has the same name as a property of the class it extends, the extension method is not visible and cannot be accessed.  
  
## Extension Method Precedence  
 When two extension methods that have identical signatures are in scope and accessible, the one with higher precedence will be invoked. An extension method's precedence is based on the mechanism used to bring the method into scope. The following list shows the precedence hierarchy, from highest to lowest.  
  
1.  Extension methods defined inside the current module.  
  
2.  Extension methods defined inside data types in the current namespace or any one of its parents, with child namespaces having higher precedence than parent namespaces.  
  
3.  Extension methods defined inside any type imports in the current file.  
  
4.  Extension methods defined inside any namespace imports in the current file.  
  
5.  Extension methods defined inside any project-level type imports.  
  
6.  Extension methods defined inside any project-level namespace imports.  
  
 If precedence does not resolve the ambiguity, you can use the fully qualified name to specify the method that you are calling. If the `Print` method in the earlier example is defined in a module named `StringExtensions`, the fully qualified name is `StringExtensions.Print(example)` instead of `example.Print()`.  
  
## See Also  
 <xref:System.Runtime.CompilerServices>  
 <xref:System.Runtime.CompilerServices.ExtensionAttribute>  
 [Extension Methods](../../../../csharp/programming-guide/classes-and-structs/extension-methods.md)  
 [Module Statement](../../../../visual-basic/language-reference/statements/module-statement.md)  
 [Procedure Parameters and Arguments](./procedure-parameters-and-arguments.md)  
 [Optional Parameters](./optional-parameters.md)  
 [Parameter Arrays](./parameter-arrays.md)  
 [Attributes overview](../../../../visual-basic/programming-guide/concepts/attributes/index.md)  
 [Scope in Visual Basic](../../../../visual-basic/programming-guide/language-features/declared-elements/scope.md)
