 '************************************************************************************************
' *
' * File: Invoker.cs
' *
' * Description: Defines a class that implements IInvokeProvider. This interface enables a 
' * UIAutomation client to invoke a control by using InvokePattern.Invoke. 
' * 
' * An instance of this class is returned to the control in its implementation of 
' * IRawElementProviderSimple.GetPatternProvider.
' * 
' * See ProviderForm.cs for a full description of this sample.
' * 
' *     
' * This file is part of the Microsoft WinFX SDK Code Samples.
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
' ************************************************************************************************

Imports System
Imports System.Text
Imports System.Collections
Imports System.Windows
Imports System.Windows.Forms
Imports System.Windows.Automation
Imports System.Windows.Automation.Text
Imports System.Windows.Automation.Provider



Public Class InvokePatternProvider
    Inherits MarshalByRefObject
    Implements IInvokeProvider
    Private rawElementProvider As IRawElementProviderSimple
    Private ProviderControl As RootButton
    
    
    ''' <summary>
    ''' Constructor.
    ''' </summary>
    ''' <param name="providerElement">Object that implements IRawElementProviderSimple.</param>
    ''' <param name="control">Control object.</param>
    ''' <remarks>These are different views of the same object.</remarks>
    Friend Sub New(ByVal providerElement As IRawElementProviderSimple, ByVal control As RootButton)
        rawElementProvider = providerElement
        ProviderControl = control

    End Sub 'New


    ''' <summary>
    ''' Responds to an InvokePattern.Invoke by simulating a MouseDown event.
    ''' </summary>
    ''' <remarks>
    ''' ProviderControl is a button control object that also implements 
    ''' IRawElementProviderSimple.
    ''' </remarks>
    Sub Invoke()  Implements IInvokeProvider.Invoke
        ' If the control is not enabled, we're responsible for letting UIAutomation know.
        ' It catches the exception and then throws it to the client.
        If False = CBool(rawElementProvider.GetPropertyValue(AutomationElementIdentifiers.IsEnabledProperty.Id)) Then
            Throw New ElementNotEnabledException()
        End If
        
        ' Create arguments for the event. The parameters aren't used.
        Dim mouseArgs As New MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0)
        
        ' Invoke the MouseDown handler. We cannot call MyControl_MouseDown directly, 
        ' because it is illegal to update the UI from a different thread.
        'Dim onMouseEvent As MouseEventHandler = AddressOf ProviderControl.RootButtonControl_MouseDown
        'ProviderControl.BeginInvoke(onMouseEvent, New Object() {Me, mouseArgs})
    End Sub 'IInvokeProvider.Invoke
End Class 'InvokePatternProvider
