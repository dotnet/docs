Imports System
Imports System.ComponentModel
Imports System.Collections
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Windows.Automation.Provider
Imports System.Windows.Automation
Imports System.Security.Permissions

Namespace UIAIToggleProvider_snip
	Partial Public Class CustomControl
		Inherits Control
		' The UI Automation provider for this instance of the control.
		Private myToggleProvider As ToggleProvider

		' The control dimensions.
		Private controlWidth As Integer
		Private controlHeight As Integer
		Private controlRectangle As Rectangle
		Private controlHWND As IntPtr
		'Public ArrayList togglestateColor = New ArrayList(3)
		Public controlColor As Color
		Public toggleStateColor As New Dictionary(Of Color, ToggleState)()

		''' <summary>
		''' Constructor.
		''' </summary>
		Public Sub New(ByVal mainForm As Form, ByVal rect As Rectangle)
			' Initialize painting area and color.
			controlWidth = 50
			controlHeight = 100
			controlRectangle = New Rectangle(rect.X, rect.Y, rect.Width, rect.Height)
			Me.Size = New Size(controlWidth, controlHeight)
			controlHWND = Me.Handle

			' Give the control a Control.Location and Size so that it will trap mouse clicks
			' and will be repainted as necessary.
			Size = New System.Drawing.Size(controlRectangle.Width, controlRectangle.Height)
			Location = New System.Drawing.Point(controlRectangle.X, controlRectangle.Y)
			
			toggleStateColor(Color.Green) = ToggleState.On
			toggleStateColor(Color.Red) = ToggleState.Off
			toggleStateColor(Color.Yellow) = ToggleState.Indeterminate
            controlColor = Color.Yellow
		End Sub

		#Region "Private/Internal methods"

		''' <summary>
		''' Handles Paint event.
		''' </summary>
		''' <param name="e">Event arguments.</param>
		Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
			Dim brush As New SolidBrush(controlColor)
			e.Graphics.FillRectangle(brush, controlRectangle)
		End Sub

		#End Region ' Private/Internal methods

		#Region "UI Automation related methods"
		''' <summary>
		''' Gets the UI Automation provider for the control.
		''' </summary>
		Public ReadOnly Property Provider() As ToggleProvider
			Get
				Return myToggleProvider
			End Get
		End Property

		''' <summary>
		''' Gets a value that specifies whether the UI Automation provider is attached.
		''' </summary>
		Protected ReadOnly Property AutomationIsActive() As Boolean
			Get
				Return (myToggleProvider IsNot Nothing)
			End Get
		End Property

		''' <summary>
		''' Handles WM_GETOBJECT message; others are passed to base handler.
		''' </summary>
		''' <param name="winMessage">Windows message.</param>
		''' <remarks>This method enables UI Automation to find the control.</remarks>
		<SecurityPermission(SecurityAction.Demand, Flags := SecurityPermissionFlag.UnmanagedCode)>
		Protected Overrides Sub WndProc(ByRef m As Message)
			Const WM_GETOBJECT As Integer = &H003D

			If m.Msg = WM_GETOBJECT Then
				If Not AutomationIsActive Then
					' If no provider has been created, then create one.
					myToggleProvider = New ToggleProvider(Me)
				End If

				m.Result = AutomationInteropProvider.ReturnRawElementProvider(Handle, m.WParam, m.LParam, myToggleProvider)
				Return
			End If
			MyBase.WndProc(m)
		End Sub

		#End Region ' UI Automation related methods
	End Class
End Namespace
