---
title: "Walkthrough: Calling Windows APIs (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "DLLs, calling"
  - "Windows API, walkthroughs"
  - "platform invoke, walkthroughs"
  - "API calls [Visual Basic], walkthroughs [Visual Basic]"
  - "Windows API, calling"
  - "walkthroughs [Visual Basic], API calls"
  - "DllImport attribute, calling Windows API"
  - "Declare statement [Visual Basic], declaring DLL functions"
ms.assetid: 9280ca96-7a93-47a3-8d01-6d01be0657cb
caps.latest.revision: 20
author: dotnet-bot
ms.author: dotnetcontent
---
# Walkthrough: Calling Windows APIs (Visual Basic)
Windows APIs are dynamic-link libraries (DLLs) that are part of the Windows operating system. You use them to perform tasks when it is difficult to write equivalent procedures of your own. For example, Windows provides a function named `FlashWindowEx` that lets you make the title bar for an application alternate between light and dark shades.  
  
 The advantage of using Windows APIs in your code is that they can save development time because they contain dozens of useful functions that are already written and waiting to be used. The disadvantage is that Windows APIs can be difficult to work with and unforgiving when things go wrong.  
  
 Windows APIs represent a special category of interoperability. Windows APIs do not use managed code, do not have built-in type libraries, and use data types that are different than those used with Visual Studio. Because of these differences, and because Windows APIs are not COM objects, interoperability with Windows APIs and the [!INCLUDE[dnprdnshort](~/includes/dnprdnshort-md.md)] is performed using platform invoke, or PInvoke. Platform invoke is a service that enables managed code to call unmanaged functions implemented in DLLs. For more information, see [Consuming Unmanaged DLL Functions](../../../framework/interop/consuming-unmanaged-dll-functions.md). You can use PInvoke in [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] by using either the `Declare` statement or applying the `DllImport` attribute to an empty procedure.  
  
 Windows API calls were an important part of [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] programming in the past, but are seldom necessary with Visual Basic .NET. Whenever possible, you should use managed code from the [!INCLUDE[dnprdnshort](~/includes/dnprdnshort-md.md)] to perform tasks, instead of Windows API calls. This walkthrough provides information for those situations in which using Windows APIs is necessary.  
  
[!INCLUDE[note_settings_general](~/includes/note-settings-general-md.md)]  
  
## API Calls Using Declare  
 The most common way to call Windows APIs is by using the `Declare` statement.  
  
#### To declare a DLL procedure  
  
1.  Determine the name of the function you want to call, plus its arguments, argument types, and return value, as well as the name and location of the DLL that contains it.  
  
    > [!NOTE]
    >  For complete information about the Windows APIs, see the Win32 SDK documentation in the Platform SDK Windows API. For more information about the constants that Windows APIs use, examine the header files such as Windows.h included with the Platform SDK.  
  
2.  Open a new Windows Application project by clicking **New** on the **File** menu, and then clicking **Project**. The **New Project** dialog box appears.  
  
3.  Select **Windows Application** from the list of [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] project templates. The new project is displayed.  
  
4.  Add the following `Declare` function either to the class or module in which you want to use the DLL:  
  
     [!code-vb[VbVbalrInterop#9](../../../visual-basic/programming-guide/com-interop/codesnippet/VisualBasic/walkthrough-calling-windows-apis_1.vb)]  
  
### Parts of the Declare Statement  
 The `Declare` statement includes the following elements.  
  
#### Auto modifier  
 The `Auto` modifier instructs the runtime to convert the string based on the method name according to common language runtime rules (or alias name if specified).  
  
#### Lib and Alias keywords  
 The name following the `Function` keyword is the name your program uses to access the imported function. It can be the same as the real name of the function you are calling, or you can use any valid procedure name and then employ the `Alias` keyword to specify the real name of the function you are calling.  
  
 Specify the `Lib` keyword, followed by the name and location of the DLL that contains the function you are calling. You do not need to specify the path for files located in the Windows system directories.  
  
 Use the `Alias` keyword if the name of the function you are calling is not a valid [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] procedure name, or conflicts with the name of other items in your application. `Alias` indicates the true name of the function being called.  
  
#### Argument and Data Type Declarations  
 Declare the arguments and their data types. This part can be challenging because the data types that Windows uses do not correspond to Visual Studio data types. [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] does a lot of the work for you by converting arguments to compatible data types, a process called *marshaling*. You can explicitly control how arguments are marshaled by using the <xref:System.Runtime.InteropServices.MarshalAsAttribute> attribute defined in the <xref:System.Runtime.InteropServices> namespace.  
  
> [!NOTE]
>  Previous versions of [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] allowed you to declare parameters `As Any`, meaning that data of any data type could be used. [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] requires that you use a specific data type for all `Declare` statements.  
  
#### Windows API Constants  
 Some arguments are combinations of constants. For example, the `MessageBox` API shown in this walkthrough accepts an integer argument called `Typ` that controls how the message box is displayed. You can determine the numeric value of these constants by examining the `#define` statements in the file WinUser.h. The numeric values are generally shown in hexadecimal, so you may want to use a calculator to add them and convert to decimal. For example, if you want to combine the constants for the exclamation style `MB_ICONEXCLAMATION` 0x00000030 and the Yes/No style `MB_YESNO` 0x00000004, you can add the numbers and get a result of 0x00000034, or 52 decimal. Although you can use the decimal result directly, it is better to declare these values as constants in your application and combine them using the `Or` operator.  
  
###### To declare constants for Windows API calls  
  
1.  Consult the documentation for the Windows function you are calling. Determine the name of the constants it uses and the name of the .h file that contains the numeric values for these constants.  
  
2.  Use a text editor, such as Notepad, to view the contents of the header (.h) file, and find the values associated with the constants you are using. For example, the `MessageBox` API uses the constant `MB_ICONQUESTION` to show a question mark in the message box. The definition for `MB_ICONQUESTION` is in WinUser.h and appears as follows:  
  
     `#define MB_ICONQUESTION             0x00000020L`  
  
3.  Add equivalent `Const` statements to your class or module to make these constants available to your application. For example:  
  
     [!code-vb[VbVbalrInterop#11](../../../visual-basic/programming-guide/com-interop/codesnippet/VisualBasic/walkthrough-calling-windows-apis_2.vb)]  
  
###### To call the DLL procedure  
  
1.  Add a button named `Button1` to the startup form for your project, and then double-click it to view its code. The event handler for the button is displayed.  
  
2.  Add code to the `Click` event handler for the button you added, to call the procedure and provide the appropriate arguments:  
  
     [!code-vb[VbVbalrInterop#12](../../../visual-basic/programming-guide/com-interop/codesnippet/VisualBasic/walkthrough-calling-windows-apis_3.vb)]  
  
3.  Run the project by pressing F5. The message box is displayed with both **Yes** and **No** response buttons. Click either one.  
  
#### Data Marshaling  
 [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] automatically converts the data types of parameters and return values for Windows API calls, but you can use the `MarshalAs` attribute to explicitly specify unmanaged data types that an API expects. For more information about interop marshaling, see [Interop Marshaling](../../../framework/interop/interop-marshaling.md).  
  
###### To use Declare and MarshalAs in an API call  
  
1.  Determine the name of the function you want to call, plus its arguments, data types, and return value.  
  
2.  To simplify access to the `MarshalAs` attribute, add an `Imports` statement to the top of the code for the class or module, as in the following example:  
  
     [!code-vb[VbVbalrInterop#13](../../../visual-basic/programming-guide/com-interop/codesnippet/VisualBasic/walkthrough-calling-windows-apis_4.vb)]  
  
3.  Add a function prototype for the imported function to the class or module you are using, and apply the `MarshalAs` attribute to the parameters or return value. In the following example, an API call that expects the type `void*` is marshaled as `AsAny`:  
  
     [!code-vb[VbVbalrInterop#14](../../../visual-basic/programming-guide/com-interop/codesnippet/VisualBasic/walkthrough-calling-windows-apis_5.vb)]  
  
## API Calls Using DllImport  
 The `DllImport` attribute provides a second way to call functions in DLLs without type libraries. `DllImport` is roughly equivalent to using a `Declare` statement but provides more control over how functions are called.  
  
 You can use `DllImport` with most Windows API calls as long as the call refers to a shared (sometimes called *static*) method. You cannot use methods that require an instance of a class. Unlike `Declare` statements, `DllImport` calls cannot use the `MarshalAs` attribute.  
  
#### To call a Windows API using the DllImport attribute  
  
1.  Open a new Windows Application project by clicking **New** on the **File** menu, and then clicking **Project**. The **New Project** dialog box appears.  
  
2.  Select **Windows Application** from the list of [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] project templates. The new project is displayed.  
  
3.  Add a button named `Button2` to the startup form.  
  
4.  Double-click `Button2` to open the code view for the form.  
  
5.  To simplify access to `DllImport`, add an `Imports` statement to the top of the code for the startup form class:  
  
     [!code-vb[VbVbalrInterop#13](../../../visual-basic/programming-guide/com-interop/codesnippet/VisualBasic/walkthrough-calling-windows-apis_4.vb)]  
  
6.  Declare an empty function preceding the `End Class` statement for the form, and name the function `MoveFile`.  
  
7.  Apply the `Public` and `Shared` modifiers to the function declaration and set parameters for `MoveFile` based on the arguments the Windows API function uses:  
  
     [!code-vb[VbVbalrInterop#16](../../../visual-basic/programming-guide/com-interop/codesnippet/VisualBasic/walkthrough-calling-windows-apis_6.vb)]  
  
     Your function can have any valid procedure name; the `DllImport` attribute specifies the name in the DLL. It also handles interoperability marshaling for the parameters and return values, so you can choose Visual Studio data types that are similar to the data types the API uses.  
  
8.  Apply the `DllImport` attribute to the empty function. The first parameter is the name and location of the DLL containing the function you are calling. You do not need to specify the path for files located in the Windows system directories. The second parameter is a named argument that specifies the name of the function in the Windows API. In this example, the `DllImport` attribute forces calls to `MoveFile` to be forwarded to `MoveFileW` in KERNEL32.DLL. The `MoveFileW` method copies a file from the path `src` to the path `dst`.  
  
     [!code-vb[VbVbalrInterop#17](../../../visual-basic/programming-guide/com-interop/codesnippet/VisualBasic/walkthrough-calling-windows-apis_7.vb)]  
  
9. Add code to the `Button2_Click` event handler to call the function:  
  
     [!code-vb[VbVbalrInterop#18](../../../visual-basic/programming-guide/com-interop/codesnippet/VisualBasic/walkthrough-calling-windows-apis_8.vb)]  
  
10. Create a file named Test.txt and place it in the C:\Tmp directory on your hard drive. Create the Tmp directory if necessary.  
  
11. Press F5 to start the application. The main form appears.  
  
12. Click **Button2**. The message "The file was moved successfully" is displayed if the file can be moved.  
  
## See Also  
 <xref:System.Runtime.InteropServices.DllImportAttribute>  
 <xref:System.Runtime.InteropServices.MarshalAsAttribute>  
 [Declare Statement](../../../visual-basic/language-reference/statements/declare-statement.md)  
 [Auto](../../../visual-basic/language-reference/modifiers/auto.md)  
 [Alias](../../../visual-basic/language-reference/statements/alias-clause.md)  
 [COM Interop](../../../visual-basic/programming-guide/com-interop/index.md)  
 [Creating Prototypes in Managed Code](../../../framework/interop/creating-prototypes-in-managed-code.md)  
 [Marshaling a Delegate as a Callback Method](../../../framework/interop/marshaling-a-delegate-as-a-callback-method.md)
