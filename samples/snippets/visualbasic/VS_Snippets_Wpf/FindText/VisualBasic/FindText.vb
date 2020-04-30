'****************************************************************************************
' * File: FindText.cs
' *
' * Description: 
' *    This sample demonstrates the UI Automation TextPattern and TextPatternRange classes.
' * 
' *    The sample consists of a Windows Presentation Foundation (WPF) client and the choice 
' *    of a WPF FlowDocumentReader target or a Win32 WordPad target. The client uses the 
' *    TextPattern control pattern and the TextPatternRange class to interact with the text 
' *    controls in either target.  
' * 
' *    The functionality demonstrated by the sample includes the ability to search for and 
' *    select text, expand a selection to a specific TextUnit, navigate by TextUnit, access 
' *    embedded objects within a selection, and access the enclosing element of a selection.
' * 
' *    Note: Three WPF documents, a RichText document, and a plain text document are provided 
' *          in the Content folder of the TextProvider project.
' * 
' *
' * This file is part of the Microsoft .NET Framework SDK Code Samples.
' * 
' * Copyright (C) Microsoft Corporation.  All rights reserved.
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
' *****************************************************************************************

Imports System.Windows
Imports System.Windows.Documents
Imports System.Windows.Automation
Imports System.Windows.Controls
Imports System.Diagnostics
Imports System.ComponentModel
Imports System.Threading
Imports System.IO

Namespace SDKSample

    Public Class FindText
        Inherits Application

        Protected Overrides Sub OnStartup(ByVal e As StartupEventArgs)
            ' Initialize the sample
            Dim sw As New SearchWindow()
            sw.SearchWindow()
        End Sub

        ' Window shut down event handler
        Protected Overrides Sub OnExit(ByVal e As ExitEventArgs)
            MyBase.OnExit(e)
        End Sub


        ' Launch the sample application.

        Friend NotInheritable Class TestMain

            <System.STAThread()> _
            Shared Sub Main()
                Thread.CurrentThread.SetApartmentState(System.Threading.ApartmentState.STA)
                ' Create an instance of the sample class and call its Run() method to start it.
                Dim app As New FindText()
                app.Run()
            End Sub
        End Class

    End Class

End Namespace
