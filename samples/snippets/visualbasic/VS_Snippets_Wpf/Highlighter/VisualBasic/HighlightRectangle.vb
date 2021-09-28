 '******************************************************************************
' * File: HighlightRectangle.vb
' *
' * Description: 
' * Contains a class that represents the highlight rectangle, which is made up
' * of four Form objects. Windows takes care of properly drawing and erasing 
' * these forms.
' * 
' * See ClientForm.vb for a full description of the sample.
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

Imports System.Drawing
Imports System.Windows.Forms
Imports System.Runtime.InteropServices

Friend Class HighlightRectangle

#Region "Private Fields"

    Private highlightShown As Boolean
    Private highlightLineWidth As Integer
    Private highlightLocation As Rectangle

    Private leftForm As Form
    Private topForm As Form
    Private rightForm As Form
    Private bottomForm As Form

#End Region

#Region "Constructor"


    ''' <summary>
    ''' Constructor.
    ''' </summary>
    ''' <remarks>
    ''' Creates each side of the highlight rectangle as a form, so that
    ''' drawing and erasing are handled automatically.
    ''' </remarks>
    Public Sub New()
        ' Construct the rectangle and set some values.
        highlightShown = False
        highlightLineWidth = 3
        leftForm = New Form()
        topForm = New Form()
        rightForm = New Form()
        bottomForm = New Form()
        Dim forms As Form() = {leftForm, topForm, rightForm, bottomForm}
        Dim form As Form
        For Each form In forms
            With form
                .FormBorderStyle = FormBorderStyle.None
                .ShowInTaskbar = False
                .TopMost = True
                .Visible = False
                .Left = 0
                .Top = 0
                .Width = 1
                .Height = 1
                .BackColor = Color.Red

                ' Make it a tool window so it doesn't show up with Alt+Tab.
                Dim style As Integer = NativeMethods.GetWindowLong(.Handle, _
                    NativeMethods.GWL_EXSTYLE)
                NativeMethods.SetWindowLong(.Handle, NativeMethods.GWL_EXSTYLE, _
                    Fix(style Or NativeMethods.WS_EX_TOOLWINDOW))
            End With
        Next form

    End Sub

#End Region


#Region "Public Properties"

    ''' <summary>
    ''' Sets the visible state of the rectangle.
    ''' </summary>
    ''' <remarks>
    ''' The Layout method is called by using BeginInvoke, to prevent
    ''' cross-thread updates to the UI. This method can be called on
    ''' any form that belongs to the UI thread.
    ''' </remarks>
    Public WriteOnly Property Visible() As Boolean
        Set(ByVal value As Boolean)
            If highlightShown <> value Then
                highlightShown = value
                If highlightShown Then
                    Dim mi As New MethodInvoker(AddressOf Layout)
                    leftForm.BeginInvoke(mi)
                    mi = New MethodInvoker(AddressOf ShowRectangle)
                    leftForm.BeginInvoke(mi)
                Else
                    Dim mi As New MethodInvoker(AddressOf HideRectangle)
                    leftForm.BeginInvoke(mi)
                End If
            End If
        End Set
    End Property

    ''' <summary>
    ''' Sets the location of the highlight.
    ''' </summary>

    Public WriteOnly Property Location() As Rectangle
        Set(ByVal value As Rectangle)
            highlightLocation = value
            Dim mi As New MethodInvoker(AddressOf Layout)
            leftForm.BeginInvoke(mi)
        End Set
    End Property

#End Region


#Region "Private Methods"


    ''' <summary>
    ''' Shows or hides the rectangle.
    ''' </summary>
    ''' <param name="show">true to show, false to hide.</param>
    Private Sub Show(ByVal show As Boolean)
        If show Then
            NativeMethods.ShowWindow(leftForm.Handle, NativeMethods.SW_SHOWNA)
            NativeMethods.ShowWindow(topForm.Handle, NativeMethods.SW_SHOWNA)
            NativeMethods.ShowWindow(rightForm.Handle, NativeMethods.SW_SHOWNA)
            NativeMethods.ShowWindow(bottomForm.Handle, NativeMethods.SW_SHOWNA)
        Else
            leftForm.Hide()
            topForm.Hide()
            rightForm.Hide()
            bottomForm.Hide()
        End If

    End Sub


    ''' <summary>
    ''' Shows the highlight.
    ''' </summary>
    ''' <remarks> Parameterless method for MethodInvoker.</remarks>
    Sub ShowRectangle()

        Show(True)

    End Sub


    ''' <summary>
    ''' Hides the highlight.
    ''' </summary>
    ''' <remarks> Parameterless method for MethodInvoker.</remarks>
    Sub HideRectangle()

        Show(False)

    End Sub


    ''' <summary>
    ''' Sets the position and size of the four forms that make up the rectangle.
    ''' </summary>
    ''' <remarks>
    ''' Use the Win32 SetWindowPosfunction so that SWP_NOACTIVATE can be set. 
    ''' This ensures that the windows are shown without receiving the focus.
    ''' </remarks>
    Private Sub Layout()

        ' Use SetWindowPos instead of changing the location via form properties: 
        ' this allows us to also specify HWND_TOPMOST. 
        ' Using Form.TopMost = true to do this has the side-effect
        ' of activating the rectangle windows, causing them to gain the focus.
        NativeMethods.SetWindowPos(leftForm.Handle, NativeMethods.HWND_TOPMOST, highlightLocation.Left - highlightLineWidth, highlightLocation.Top, highlightLineWidth, highlightLocation.Height, NativeMethods.SWP_NOACTIVATE)
        NativeMethods.SetWindowPos(topForm.Handle, NativeMethods.HWND_TOPMOST, highlightLocation.Left - highlightLineWidth, highlightLocation.Top - highlightLineWidth, highlightLocation.Width + 2 * highlightLineWidth, highlightLineWidth, NativeMethods.SWP_NOACTIVATE)
        NativeMethods.SetWindowPos(rightForm.Handle, NativeMethods.HWND_TOPMOST, highlightLocation.Left + highlightLocation.Width, highlightLocation.Top, highlightLineWidth, highlightLocation.Height, NativeMethods.SWP_NOACTIVATE)
        NativeMethods.SetWindowPos(bottomForm.Handle, NativeMethods.HWND_TOPMOST, highlightLocation.Left - highlightLineWidth, highlightLocation.Top + highlightLocation.Height, highlightLocation.Width + 2 * highlightLineWidth, highlightLineWidth, NativeMethods.SWP_NOACTIVATE)

    End Sub

#End Region

End Class
