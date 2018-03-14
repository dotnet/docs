 '************************************************************************************************
' *
' * File: MyControl.cs
' *
' * Description: Implements a custom control that supports UI Automation.
' * 
' * See ProviderForm.cs for a full description of this sample.
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

Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows.Automation.Provider
Imports System.Windows.Automation
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Diagnostics
Imports System.Security.Permissions




Public Class RootButton
    Inherits Control
    Implements IRawElementProviderFragmentRoot

    Private ChildControl As New ListBox()
    Private myRectangle As Rectangle
    Private myColor As Color
    'Form ownerForm
    'IntPtr ownerFormHandle
    Private myInvokePatternProvider As InvokePatternProvider = Nothing
    Private myHWND As IntPtr



    ''' <summary>
    ''' Constructor.
    ''' </summary>
    ''' <param name="mainForm">Host form.</param>
    ''' <param name="rect">Position and size of control.</param>
    Public Sub New(ByVal mainForm As Form, ByVal rect As Rectangle)
        ' Create an object that implements IInvokeProvider see Invoker.cs.
        myInvokePatternProvider = New InvokePatternProvider(Me, Me)

        ' Initialize painting area and color.
        myRectangle = New Rectangle(rect.X, rect.Y, rect.Width, rect.Height)
        myColor = Color.Green
        myHWND = Me.Handle

        ' Give the control a Control.Location and Size so that it will trap
        '  mouse clicks and will be repainted as necessary.
        Size = New System.Drawing.Size(myRectangle.Width, myRectangle.Height)
        Location = New System.Drawing.Point(myRectangle.X, myRectangle.Y)

        ' Add MouseDown event handler.
        AddHandler Me.MouseDown, AddressOf Me.RootButtonControl_MouseDown

    End Sub 'New



    ''' <summary>
    ''' Handles WM_GETOBJECT message others are passed to base handler.
    ''' </summary>
    ''' <param name="m">Windows message.</param>
    <SecurityPermission(SecurityAction.Demand, Flags:=SecurityPermissionFlag.UnmanagedCode)> _
    Protected Overrides Sub WndProc(ByRef m As Message)
        Const WM_GETOBJECT As Integer = &H3D

        If m.Msg = WM_GETOBJECT _
            AndAlso m.LParam.ToInt32() = AutomationInteropProvider.RootObjectId _
        Then
            m.Result = AutomationInteropProvider.ReturnRawElementProvider( _
                Me.Handle, m.WParam, m.LParam, DirectCast(Me,  _
                    IRawElementProviderSimple))
            Return
        End If
        MyBase.WndProc(m)

    End Sub 'WndProc


    ''' <summary>
    ''' Handles Paint event.
    ''' </summary>
    ''' <param name="e">Event arguments.</param>
    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim brush As New SolidBrush(myColor)
        e.Graphics.FillRectangle(brush, DisplayRectangle)

    End Sub 'OnPaint

    ''' <summary>
    ''' Handles MouseDown event.
    ''' </summary>
    ''' <param name="sender">Object that raised the event.</param>
    ''' <param name="e">Event arguments.</param>
    Private Sub RootButtonControl_MouseDown(ByVal sender As Object, _
        ByVal e As MouseEventArgs)
        OnCustomButtonClicked()
        Return
    End Sub 'RootButtonControl_MouseDown

    '' <Snippet150>
    ''' <summary>
    ''' Responds to a button click, regardless of whether it was caused by a 
    ''' mouse or keyboard click or by InvokePattern.Invoke. 
    ''' </summary>
    Private Sub OnCustomButtonClicked()

        '' TODO  Perform program actions invoked by the control.

        '' Raise an event.
        If AutomationInteropProvider.ClientsAreListening Then
            Dim args As AutomationEventArgs = _
                New AutomationEventArgs(InvokePatternIdentifiers.InvokedEvent)
            AutomationInteropProvider.RaiseAutomationEvent( _
                InvokePatternIdentifiers.InvokedEvent, Me, args)
        End If
    End Sub
    '' </Snippet150>


#Region "IRawElementProviderSimple"


    ' <Snippet101>
    ''' <summary>
    ''' Returns the object that supports the specified pattern.
    ''' </summary>
    ''' <param name="patternId">ID of the pattern.</param>
    ''' <returns>Object that implements IInvokeProvider.</returns>
    Function GetPatternProvider(ByVal patternId As Integer) As Object _
        Implements IRawElementProviderSimple.GetPatternProvider
        If patternId = InvokePatternIdentifiers.Pattern.Id Then
            ' Return an object that implements IInvokeProvider.
            Return myInvokePatternProvider
        Else
            Return Nothing
        End If

    End Function 'IRawElementProviderSimple.GetPatternProvider
    ' </Snippet101>

    ' <Snippet102>
    Function GetPropertyValue(ByVal propertyId As Integer) As Object _
        Implements IRawElementProviderSimple.GetPropertyValue

        If propertyId = AutomationElementIdentifiers.NameProperty.Id Then
            Return "RootButtonControl"
        ElseIf propertyId = AutomationElementIdentifiers.ClassNameProperty.Id Then
            Return "RootButtonControlClass"
        ElseIf propertyId = AutomationElementIdentifiers.ControlTypeProperty.Id Then
            Return ControlType.Button.Id
        ElseIf propertyId = AutomationElementIdentifiers.IsContentElementProperty.Id Then
            Return False
        ElseIf propertyId = AutomationElementIdentifiers.IsControlElementProperty.Id Then
            Return True
        Else
            Return Nothing
        End If

    End Function 'IRawElementProviderSimple.GetPropertyValue
    ' </Snippet102>

    ' <Snippet103>
    ReadOnly Property HostRawElementProvider() As IRawElementProviderSimple _
        Implements IRawElementProviderSimple.HostRawElementProvider

        Get
            ' myHWND is the handle of the window that contains this control.
            Return AutomationInteropProvider.HostProviderFromHandle(myHWND)
        End Get
    End Property
    ' </Snippet103>

    ' <Snippet104>
    ReadOnly Property ProviderOptions() As ProviderOptions _
        Implements IRawElementProviderSimple.ProviderOptions

        Get
            Return ProviderOptions.ServerSideProvider
        End Get
    End Property
    ' </Snippet104>
#End Region
    Private __unknown As IRawElementProviderSimple

#Region "IRawElementProviderFragment Members"

    ReadOnly Property BoundingRectangle() As System.Windows.Rect _
        Implements IRawElementProviderFragment.BoundingRectangle
        Get
            Console.WriteLine("RootButton:  Got BoundingRectangle property.")
            Return System.Windows.Rect.Empty
        End Get
    End Property


    ReadOnly Property FragmentRoot() As IRawElementProviderFragmentRoot _
        Implements IRawElementProviderFragment.FragmentRoot
        Get
            Console.WriteLine("RootButton:  Got FragmentRoot property.")
            Return Me
        End Get
    End Property


    Function GetEmbeddedFragmentRoots() As IRawElementProviderSimple() _
        Implements IRawElementProviderFragment.GetEmbeddedFragmentRoots
        Return Nothing
    End Function 'IRawElementProviderFragment.GetEmbeddedFragmentRoots


    Function GetRuntimeId() As Integer() Implements IRawElementProviderFragment.GetRuntimeId
        Return Nothing
    End Function 'IRawElementProviderFragment.GetRuntimeId

    ' <Snippet105>
    Function Navigate(ByVal direction As NavigateDirection) As IRawElementProviderFragment _
        Implements IRawElementProviderFragment.Navigate

        If direction = NavigateDirection.FirstChild _
            OrElse direction = NavigateDirection.LastChild Then
            ' Return the provider that is the sole child of this one.
            Return CType(ChildControl, IRawElementProviderFragment)
        Else
            Return Nothing
        End If

    End Function 'IRawElementProviderFragment.Navigate
    ' </Snippet105>

    Sub SetFocus() Implements IRawElementProviderFragment.SetFocus
        '  TODO  See spec for requirements
        Throw New Exception("The method or operation is not implemented.")

    End Sub 'IRawElementProviderFragment.SetFocus

#End Region

#Region "IRawElementProviderFragmentRoot Members"


    Function ElementProviderFromPoint(ByVal x As Double, _
       ByVal y As Double) As IRawElementProviderFragment _
       Implements IRawElementProviderFragmentRoot.ElementProviderFromPoint

        Throw New Exception("The method or operation is not implemented.")
    End Function 'IRawElementProviderFragmentRoot.ElementProviderFromPoint

    Function GetFocus() As IRawElementProviderFragment _
        Implements IRawElementProviderFragmentRoot.GetFocus
        ' TODO  Unsure of the idea here -- it returns the element within this tree that has 
        '  focus, but only if the focus is actually on an element in this tree? Or is it the element
        '  that gains focus when the user navigates to the root element?
        Throw New Exception("The method or operation is not implemented.")
    End Function 'IRawElementProviderFragmentRoot.GetFocus

#End Region
End Class 'RootButton 

