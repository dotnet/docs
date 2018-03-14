Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.Windows.Automation.Provider
Imports System.Security.Permissions

Namespace UIAIRangeValueProvider_snip
	Partial Public Class CustomControl
		Inherits Control
		' The UI Automation provider for this instance of the control.
		Private myRangeValueProvider As RangeValueProvider

		' The control dimensions.
		Private controlWidth As Integer
		Private controlHeight As Integer
		Public controlColor As Color
		Public colorAlpha As Integer

		Public Sub New()
			controlWidth = 100
			controlHeight = 100
			colorAlpha = 255
			controlColor = Color.FromArgb(colorAlpha,Color.Blue)
			Me.Size = New Size(controlWidth, controlHeight)
			Me.Enabled = True
		End Sub

		Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
			' Use SystemBrushes for colors of a control.
			Dim backgroundBrush As System.Drawing.Brush = New SolidBrush(controlColor)

			e.Graphics.FillRectangle(backgroundBrush, DisplayRectangle)

			' Calling the base class OnPaint
			MyBase.OnPaint(e)
		End Sub


		#Region "UI Automation related methods"

		''' <summary>
		''' Gets the UI Automation provider for the control.
		''' </summary>
		Private ReadOnly Property Provider() As RangeValueProvider
			Get
				Return myRangeValueProvider
			End Get
		End Property

		''' <summary>
		''' Gets a value that specifies whether the UI Automation provider is attached.
		''' </summary>
		Protected ReadOnly Property AutomationIsActive() As Boolean
			Get
				Return (myRangeValueProvider IsNot Nothing)
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
					myRangeValueProvider = New RangeValueProvider(Me)
				End If

				m.Result = AutomationInteropProvider.ReturnRawElementProvider(Handle, m.WParam, m.LParam, myRangeValueProvider)
				Return
			End If
			MyBase.WndProc(m)
		End Sub

		#End Region ' UI Automation related methods
	End Class
End Namespace
