 '******************************************************************************
' * File: NativeMethods.vb
' *
' * Description: 
' * Contains definitions for Win32 API elements used by the application for 
' * customizing the forms that make up the highlight rectangle.
' * 
' * See ClientForm.vb for a full description of the sample.
' *      
' * 
' *  This file is part of the Microsoft Windows SDK Code Samples.
' * 
' *  Copyright (C) Microsoft Corporation.  All rights reserved.
' * 
' * This source code is intended only as a supplement to Microsoft
' * Development Tools and/or on-line documentation.  See these other
' * materials for detailed information regarding Microsoft code samples.
' * 
' * THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
' * KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
' * IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
' * PARTICULAR PURPOSE.
' * 
' *****************************************************************************
Friend Class NativeMethods

    <System.Runtime.InteropServices.DllImport("user32.dll")> _
    Friend Shared Function ShowWindow(ByVal hWnd As IntPtr, ByVal nCmdShow As Integer) As Boolean
    End Function


    <System.Runtime.InteropServices.DllImport("user32.dll")> _
    Friend Shared Function SetWindowPos(ByVal hWnd As IntPtr, ByVal hwndAfter As IntPtr, ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer, ByVal flags As Integer) As Boolean
    End Function


    <System.Runtime.InteropServices.DllImport("user32.dll")> _
    Friend Shared Function GetWindowLong(ByVal hWnd As IntPtr, ByVal nIndex As Integer) As Integer
    End Function


    <System.Runtime.InteropServices.DllImport("user32.dll")> _
    Friend Shared Function SetWindowLong(ByVal hWnd As IntPtr, ByVal nIndex As Integer, ByVal dwNewLong As Integer) As Integer
    End Function
    ' <Snippet101>
    <System.Runtime.InteropServices.DllImport("user32.dll")> _
    Friend Shared Function SetProcessDPIAware() As Boolean
    End Function
    ' </Snippet101>

    Friend Const GWL_EXSTYLE As Integer = -20

    Friend Const SW_SHOWNA As Integer = 8
    Friend Const WS_EX_TOOLWINDOW As Integer = &H80

    ' SetWindowPos constants (used by highlight rect)
    Friend Const SWP_NOACTIVATE As Integer = &H10
    Friend Shared HWND_TOPMOST As New IntPtr(-1)
End Class

