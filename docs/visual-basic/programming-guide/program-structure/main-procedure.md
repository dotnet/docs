---
title: "Main Procedure in Visual Basic"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vb.Main"
helpviewer_keywords: 
  - "Main procedure"
  - "Main method [Visual Basic]"
  - "main function"
ms.assetid: f0db283e-f283-4464-b521-b90858cc1b44
caps.latest.revision: 16
author: dotnet-bot
ms.author: dotnetcontent
---
# Main Procedure in Visual Basic
Every Visual Basic application must contain a procedure called `Main`. This procedure serves as the starting point and overall control for your application. The .NET Framework calls your `Main` procedure when it has loaded your application and is ready to pass control to it. Unless you are creating a Windows Forms application, you must write the `Main` procedure for applications that run on their own.  
  
 `Main` contains the code that runs first. In `Main`, you can determine which form is to be loaded first when the program starts, find out if a copy of your application is already running on the system, establish a set of variables for your application, or open a database that the application requires.  
  
## Requirements for the Main Procedure  
 A file that runs on its own (usually with extension .exe) must contain a `Main` procedure. A library (for example with extension .dll) does not run on its own and does not require a `Main` procedure. The requirements for the different types of projects you can create are as follows:  
  
-   Console applications run on their own, and you must supply at least one `Main` procedure. .  
  
-   Windows Forms applications run on their own. However, the Visual Basic compiler automatically generates a `Main` procedure in such an application, and you do not need to write one.  
  
-   Class libraries do not require a `Main` procedure. These include Windows Control Libraries and Web Control Libraries. Web applications are deployed as class libraries.  
  
## Declaring the Main Procedure  
 There are four ways to declare the `Main` procedure. It can take arguments or not, and it can return a value or not.  
  
> [!NOTE]
>  If you declare `Main` in a class, you must use the `Shared` keyword. In a module, `Main` does not need to be `Shared`.  
  
-   The simplest way is to declare a `Sub` procedure that does not take arguments or return a value.  
  
    ```  
    Module mainModule  
        Sub Main()  
            MsgBox("The Main procedure is starting the application.")  
            ' Insert call to appropriate starting place in your code.  
            MsgBox("The application is terminating.")  
        End Sub  
    End Module  
    ```  
  
-   `Main` can also return an `Integer` value, which the operating system uses as the exit code for your program. Other programs can test this code by examining the Windows ERRORLEVEL value. To return an exit code, you must declare `Main` as a `Function` procedure instead of a `Sub` procedure.  
  
    ```  
    Module mainModule  
        Function Main() As Integer  
            MsgBox("The Main procedure is starting the application.")  
            Dim returnValue As Integer = 0  
            ' Insert call to appropriate starting place in your code.  
            ' On return, assign appropriate value to returnValue.  
            ' 0 usually means successful completion.  
            MsgBox("The application is terminating with error level " &  
                 CStr(returnValue) & ".")  
            Return returnValue  
        End Function  
    End Module  
    ```  
  
-   `Main` can also take a `String` array as an argument. Each string in the array contains one of the command-line arguments used to invoke your program. You can take different actions depending on their values.  
  
    ```  
    Module mainModule  
        Function Main(ByVal cmdArgs() As String) As Integer  
            MsgBox("The Main procedure is starting the application.")  
            Dim returnValue As Integer = 0  
            ' See if there are any arguments.  
            If cmdArgs.Length > 0 Then  
                For argNum As Integer = 0 To UBound(cmdArgs, 1)  
                    ' Insert code to examine cmdArgs(argNum) and take  
                    ' appropriate action based on its value.  
                Next argNum  
            End If  
            ' Insert call to appropriate starting place in your code.  
            ' On return, assign appropriate value to returnValue.  
            ' 0 usually means successful completion.  
            MsgBox("The application is terminating with error level " &  
                 CStr(returnValue) & ".")  
            Return returnValue  
        End Function  
    End Module  
    ```  
  
-   You can declare `Main` to examine the command-line arguments but not return an exit code, as follows.  
  
    ```  
    Module mainModule  
        Sub Main(ByVal cmdArgs() As String)  
            MsgBox("The Main procedure is starting the application.")  
            Dim returnValue As Integer = 0  
            ' See if there are any arguments.  
            If cmdArgs.Length > 0 Then  
                For argNum As Integer = 0 To UBound(cmdArgs, 1)  
                    ' Insert code to examine cmdArgs(argNum) and take  
                    ' appropriate action based on its value.  
                Next argNum  
            End If  
            ' Insert call to appropriate starting place in your code.  
            MsgBox("The application is terminating.")  
        End Sub  
    End Module  
    ```  
  
## See Also  
 <xref:Microsoft.VisualBasic.Interaction.MsgBox%2A>  
 <xref:System.Array.Length%2A>  
 <xref:Microsoft.VisualBasic.Information.UBound%2A>  
 [Structure of a Visual Basic Program](../../../visual-basic/programming-guide/program-structure/structure-of-a-visual-basic-program.md)  
 [/main](../../../visual-basic/reference/command-line-compiler/main.md)  
 [Shared](../../../visual-basic/language-reference/modifiers/shared.md)  
 [Sub Statement](../../../visual-basic/language-reference/statements/sub-statement.md)  
 [Function Statement](../../../visual-basic/language-reference/statements/function-statement.md)  
 [Integer Data Type](../../../visual-basic/language-reference/data-types/integer-data-type.md)  
 [String Data Type](../../../visual-basic/language-reference/data-types/string-data-type.md)
