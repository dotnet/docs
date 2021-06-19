---
description: "Learn more about: How to: Call a Windows Function that Takes Unsigned Types (Visual Basic)"
title: "How to: Call a Windows Function that Takes Unsigned Types"
ms.date: 07/20/2015
helpviewer_keywords:
  - "Windows functions [Visual Basic], calling"
  - "unsigned data types [Visual Basic]"
  - "UShort data type [Visual Basic], using"
  - "functions [Visual Basic], calling Windows functions"
  - "ULong data type [Visual Basic], using"
  - "UInteger data type [Visual Basic], using"
  - "data types [Visual Basic], using"
  - "unsigned types [Visual Basic]"
  - "data types [Visual Basic], unsigned"
  - "data types [Visual Basic], numeric"
  - "unsigned types [Visual Basic], using"
ms.assetid: c2c0e712-8dc2-43b9-b4c6-345fbb02e7ce
---

# How to: Call a Windows Function that Takes Unsigned Types (Visual Basic)

If you are consuming a class, module, or structure that has members of unsigned integer types, you can access these members with Visual Basic.

## To call a Windows function that takes an unsigned type

1. Use a [Declare Statement](../../language-reference/statements/declare-statement.md) to tell Visual Basic which library holds the function, what its name is in that library, what its calling sequence is, and how to convert strings when calling it.

2. In the `Declare` statement, use `UInteger`, `ULong`, `UShort`, or `Byte` as appropriate for each parameter with an unsigned type.

3. Consult the documentation for the Windows function you are calling to find the names and values of the constants it uses. Many of these are defined in the WinUser.h file.

4. Declare the necessary constants in your code. Many Windows constants are 32-bit unsigned values, and you should declare these `As UInteger`.

5. Call the function in the normal way. The following example calls the Windows function `MessageBox`, which takes an unsigned integer argument.

    ```vb
    Public Class windowsMessage
        Private Declare Auto Function mb Lib "user32.dll" Alias "MessageBox" (
            ByVal hWnd As Integer,
            ByVal lpText As String,
            ByVal lpCaption As String,
            ByVal uType As UInteger) As Integer
        Private Const MB_OK As UInteger = 0
        Private Const MB_ICONEXCLAMATION As UInteger = &H30
        Private Const IDOK As UInteger = 1
        Private Const IDCLOSE As UInteger = 8
        Private Const c As UInteger = MB_OK Or MB_ICONEXCLAMATION
        Public Function messageThroughWindows() As String
            Dim r As Integer = mb(0, "Click OK if you see this!",
                "Windows API call", c)
            Dim s As String = "Windows API MessageBox returned " &
                 CStr(r)& vbCrLf & "(IDOK = " & CStr(IDOK) &
                 ", IDCLOSE = " & CStr(IDCLOSE) & ")"
            Return s
        End Function
    End Class
    ```

     You can test the function `messageThroughWindows` with the following code.

    ```vb
    Public Sub consumeWindowsMessage()
        Dim w As New windowsMessage
        w.messageThroughWindows()
    End Sub
    ```

    > [!CAUTION]
    > The `UInteger`, `ULong`, `UShort`, and `SByte` data types are not part of the [Language Independence and Language-Independent Components](../../../standard/language-independence.md) (CLS), so CLS-compliant code cannot consume a component that uses them.

    > [!IMPORTANT]
    > Making a call to unmanaged code, such as the Windows application programming interface (API), exposes your code to potential security risks.

    > [!IMPORTANT]
    > Calling the Windows API requires unmanaged code permission, which might affect its execution in partial-trust situations. For more information, see <xref:System.Security.Permissions.SecurityPermission> and [Code Access Permissions](/previous-versions/dotnet/netframework-4.0/h846e9b3(v=vs.100)).

## See also

- [Data Types](../../language-reference/data-types/index.md)
- [Integer Data Type](../../language-reference/data-types/integer-data-type.md)
- [UInteger Data Type](../../language-reference/data-types/uinteger-data-type.md)
- [Declare Statement](../../language-reference/statements/declare-statement.md)
- [Walkthrough: Calling Windows APIs](walkthrough-calling-windows-apis.md)
