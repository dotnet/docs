Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.Windows.Automation.Provider
Imports System.Windows.Automation
Imports System.Security.Permissions


Namespace UIAITransformProvider_snip
	Public Class CustomControl
		Inherits Control
		' The UI Automation provider for this instance of the control.
		Private myTransformProvider As TransformProvider

		' The control dimensions.
		Private controlWidth As Integer = 50
		Private controlHeight As Integer = 100

		' The form dimensions.
		Public formWidth As Integer = ProviderForm.ActiveForm.Width
		Public formHeight As Integer = ProviderForm.ActiveForm.Height

		''' <summary>
		''' Constructor.
		''' </summary>
		Public Sub New()
			Me.Size = New Size(controlWidth, controlHeight)
		End Sub

		Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
			' Use SystemBrushes for colors of a control.
			Dim backgroundBrush As System.Drawing.Brush = SystemBrushes.Window
			Dim focusedBrush As System.Drawing.Brush
			If Me.Focused Then
				focusedBrush = SystemBrushes.Highlight
			Else
				focusedBrush = New SolidBrush(Color.DarkGray)
			End If

			e.Graphics.FillRectangle(backgroundBrush, DisplayRectangle)


			' Calling the base class OnPaint
			MyBase.OnPaint(e)
		End Sub

		#Region "UI Automation related methods"

		''' <summary>
		''' Gets the UI Automation provider for the control.
		''' </summary>
		Public ReadOnly Property Provider() As TransformProvider
			Get
				Return myTransformProvider
			End Get
		End Property

		''' <summary>
		''' Gets a value that specifies whether the UI Automation provider is attached.
		''' </summary>
		Protected ReadOnly Property AutomationIsActive() As Boolean
			Get
				Return (myTransformProvider IsNot Nothing)
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
					myTransformProvider = New TransformProvider(Me)
				End If

				m.Result = AutomationInteropProvider.ReturnRawElementProvider(Handle, m.WParam, m.LParam, myTransformProvider)
				Return
			End If
			MyBase.WndProc(m)
		End Sub

		#End Region ' UI Automation related methods
	End Class
End Namespace
