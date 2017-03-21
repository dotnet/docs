' *****************************************************************************************
' * File: FindText.vb
' *
' * Description: 
' *    This sample opens a 'canned' text file (Text.txt) in Notepad and shows how to use 
' *    UI Automation to find/select text and track text selection changes in the Notepad instance.
' * 
' *    Text.txt should be automatically copied to the same folder as the executable when 
' *    you build the sample. You may have to manually copy this file if you receive an error 
' *    stating the file cannot be found.
' *
' *
' * Programming Elements:
' *    This sample demonstrates the following UI Automation programming elements from...
' * 
' *       System.Windows.Automation Namespace:
' *         Automation Class
' *           AddAutomationEventHandler
' *         WindowPattern Class
' *           WindowClosedEvent field
' *         AutomationPattern Class 
' *         AutomationEventHandler Delegate
' *         AutomationElement Class
' *           RootElement property
' *           GetCurrentPropertyValue method
' *           BoundingRectangleProperty field
' *           GetCurrentPattern method
' *           FromHandle method
' *           ControlTypeProperty field
' *           FindFirst method
' *           SetFocus method
' *         TreeScope Enumeration
' *           Element member
' *           Descendants member
' *         ControlType Class
' *           Edit field
' *         TextPattern Class
' *           Pattern field
' *           TextSelectionChangedEvent field
' *           SupportsTextSelection property
' *           DocumentRange property
' * 
' *       System.Windows.Automation.Searcher Namespace:
' *         PropertyCondition Class
' * 
' *       System.Windows.Automation.Text Namespace:
' *         TextPatternRange Class
' *           FindText method
' *           Select method
' *         TextPatternRangeEndpoint Enumeration
' *
' *
' * Copyright (C) 2003 by Microsoft Corporation.  All rights reserved.
' *
' ******************************************************************************************

Imports System
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
            End Sub 'Main
        End Class 'TestMain

    End Class

End Namespace
