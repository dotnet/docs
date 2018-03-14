Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Windows.Automation.Provider
Imports System.Security.Permissions

Namespace UIAIValueProvider_snip
	Partial Public Class CustomControl
		Inherits Control
		' The UI Automation provider for this instance of the control.
		Private myValueProvider As ValueProvider

		' The control dimensions.
		Private controlWidth As Integer = 100
		Private controlHeight As Integer = 25

		Public Sub New()
			Me.Size = New Size(controlWidth, controlHeight)
		End Sub

		''' <summary>
		''' Responds to Paint event.
		''' </summary>
		''' <param name="e">Event arguments.</param>
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

			Dim itemTextFont As System.Drawing.Font = SystemFonts.DefaultFont

			Dim itemInk As System.Drawing.Brush = SystemBrushes.ControlText

			' draw text onto screen
			Dim pt As New Point(DisplayRectangle.Left + 2, DisplayRectangle.Top + controlHeight)
			Dim rc As New Rectangle(DisplayRectangle.X, DisplayRectangle.Top + controlHeight + 1, DisplayRectangle.Width, controlHeight)
			rc = New Rectangle(rc.X, rc.Y + 2, controlWidth, controlHeight)

			e.Graphics.DrawString(Me.Text, itemTextFont, itemInk, rc)

			e.Dispose()
		End Sub

		#Region "UI Automation related methods"

		''' <summary>
		''' Gets the UI Automation provider for the control.
		''' </summary>
		Public ReadOnly Property Provider() As ValueProvider
			Get
				Return myValueProvider
			End Get
		End Property

		''' <summary>
		''' Gets a value that specifies whether the UI Automation provider is attached.
		''' </summary>
		Protected ReadOnly Property AutomationIsActive() As Boolean
			Get
				Return (myValueProvider IsNot Nothing)
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
					myValueProvider = New ValueProvider(Me)
				End If

				m.Result = AutomationInteropProvider.ReturnRawElementProvider(Handle, m.WParam, m.LParam, myValueProvider)
				Return
			End If
			MyBase.WndProc(m)
		End Sub

		#End Region ' UI Automation related methods
	End Class
End Namespace
