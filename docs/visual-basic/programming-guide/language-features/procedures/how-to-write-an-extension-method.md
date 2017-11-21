---
title: "How to: Write an Extension Method (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "extending data types [Visual Basic]"
  - "writing extension methods [Visual Basic]"
  - "extension methods [Visual Basic]"
ms.assetid: fb2739cc-958d-4ef4-a38b-214a74c93413
caps.latest.revision: 11
author: dotnet-bot
ms.author: dotnetcontent
---
# How to: Write an Extension Method (Visual Basic)
Extension methods enable you to add methods to an existing class. The extension method can be called as if it were an instance of that class.  
  
### To define an extension method  
  
1.  Open a new or existing Visual Basic application in Visual Studio.  
  
2.  At the top of the file in which you want to define an extension method, include the following import statement:  
  
    ```  
    Imports System.Runtime.CompilerServices  
    ```  
  
3.  Within a module in your new or existing application, begin the method definition with the extension attribute:  
  
    ```  
    <Extension()>  
    ```  
  
4.  Declare your method in the ordinary way, except that the type of the first parameter must be the data type you want to extend.  
  
    ```  
    <Extension()>   
    Public Sub subName (ByVal para1 As ExtendedType, <other parameters>)  
         ' < Body of the method >  
    End Sub  
    ```  
  
## Example  
 The following example declares an extension method in module `StringExtensions`. A second module, `Module1`, imports `StringExtensions` and calls the method. The extension method must be in scope when it is called. Extension method `PrintAndPunctuate` extends the <xref:System.String> class with a method that displays the string instance followed by a string of punctuation symbols sent in as a parameter.  
  
```vb  
' Declarations will typically be in a separate module.  
Imports System.Runtime.CompilerServices  
  
Module StringExtensions  
    <Extension()>   
    Public Sub PrintAndPunctuate(ByVal aString As String,   
                                 ByVal punc As String)  
        Console.WriteLine(aString & punc)  
    End Sub  
  
End Module  
```  
  
```vb  
' Import the module that holds the extension method you want to use,   
' and call it.  
  
Imports ConsoleApplication2.StringExtensions  
  
Module Module1  
  
    Sub Main()  
        Dim example = "Hello"  
        example.PrintAndPunctuate("?")  
        example.PrintAndPunctuate("!!!!")  
    End Sub  
  
End Module  
```  
  
 Notice that the method is defined with two parameters and called with only one. The first parameter, `aString`, in the method definition is bound to `example`, the instance of `String` that calls the method. The output of the example is as follows:  
  
 `Hello?`  
  
 `Hello!!!!`  
  
## See Also  
 <xref:System.Runtime.CompilerServices.ExtensionAttribute>  
 [Extension Methods](./extension-methods.md)  
 [Module Statement](../../../../visual-basic/language-reference/statements/module-statement.md)  
 [Procedure Parameters and Arguments](./procedure-parameters-and-arguments.md)  
 [Scope in Visual Basic](../../../../visual-basic/programming-guide/language-features/declared-elements/scope.md)
