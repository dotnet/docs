'************************************************************************************************
' *
' * File: ProviderForm.cs
' *
' * Description: 
' * 
' * This sample demonstrates how to implement a complex custom control that can interact with
' * UI Automation.
' * 
' * When you develop an application using standard controls such as Win32 or WinForms controls,
' * UI Automation is automatically supported by standard proxy objects. UI Automation can find 
' * the controls on your form, get properties from them, and act on them; for example, by invoking
' * a button control or adding text to a textbox.
' * 
' * However, if you develop custom controls, perhaps within a custom user interface not based
' * on a standard platform such as WinForms, UI Automation will not be able to communicate with
' * those custom controls unless, at a minimum, you take the steps demonstrated in this sample.
' *     
' * The sample shows how to implement a "fragment," which is a hierarchy of UI Automation elements.
' * The fragment consists of a custom list box that handles its own collection of list items. The
' * list box itself is the fragment root, and the list items are children of the list box.
' * 
' * Build and run the sample, then launch UISpy.exe to see UI Automation's view of the application.
' * You can also run the sample client application to see how a client can use control patterns and 
' * events to monitor and manipulate the selection and to get the value of list items.
' * 
' *    
' *  This file is part of the Microsoft WinfFX SDK Code Samples.
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
' ************************************************************************************************

Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms




Partial Class UIAFragmentProviderForm
    Inherits Form '
    Private Shared myList As ParentList


    ''' <summary>
    ''' Constructor for the application window.
    ''' </summary>
    Public Sub New()
        InitializeComponent()

        ' Create an instance of the custom control.
        myList = New ParentList(Me, 10, 10)
        myList.Enabled = True

        ' Add it to the form's controls. Among other things, this makes it possible for
        ' UIAutomation to discover it, as it will become a child of the application window.
        Me.Controls.Add(myList)
        myList.Add("Aster")
        myList.Add("Daffodil")
        myList.Add("Orchid")
        myList.Add("Tulip")
        myList.Add("Zinnia")

    End Sub


    ''' <summary>
    ''' Button click handler.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
        Application.Exit()

    End Sub
End Class
'
'ToDo: Error processing original source shown below
'    }
'}
'-^--- expression expected
