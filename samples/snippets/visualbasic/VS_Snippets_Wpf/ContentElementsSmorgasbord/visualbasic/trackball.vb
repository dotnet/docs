'---------------------------------------------------------------------------
' <copyright file="Trackball.vb" company="Microsoft">
'    Copyright (c) Microsoft Corporation.  All rights reserved.
' </copyright>
'---------------------------------------------------------------------------



Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Windows
Imports System.Windows.Input
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Documents


Namespace DemoDev
	Public Class FastZoom
		Public Sub New()
		End Sub
		'NOTE currently has funky behavior in the MouseMove
		'but doesn't matter because I am not showing that
		Public Sub Attach(ByVal element As FrameworkContentElement)
			AddHandler element.MouseMove, AddressOf MouseMoveHandler
			AddHandler element.MouseRightButtonDown, AddressOf MouseDownHandler
			AddHandler element.MouseRightButtonUp, AddressOf MouseUpHandler
		End Sub

		Public Sub Detach(ByVal element As FrameworkContentElement)
			RemoveHandler element.MouseMove, AddressOf MouseMoveHandler
			RemoveHandler element.MouseRightButtonDown, AddressOf MouseDownHandler
			RemoveHandler element.MouseRightButtonUp, AddressOf MouseUpHandler
		End Sub
		Private Sub MouseMoveHandler(ByVal sender As Object, ByVal e As System.Windows.Input.MouseEventArgs)
			Dim el As ContentElement = CType(sender, ContentElement)
			If Not el.IsEnabled Then
				Return
			End If
			e.Handled = True

			If el.IsMouseCaptured Then
				Dim delta As Vector = _point - e.MouseDevice.GetPosition(el)
				Dim b As Block = TryCast(el, Block)
				If b IsNot Nothing Then
					origFontSize = b.FontSize
					Dim factor As Double = delta.X / 1000
					Do While b.FontSize + factor >= origFontSize AndAlso b.FontSize + factor < 200
						b.FontSize += factor
					Loop
				End If
			End If
		End Sub
'<SnippetUIElementMouseCapture>
		Private Sub MouseDownHandler(ByVal sender As Object, ByVal e As MouseButtonEventArgs)
			Dim el As ContentElement = CType(sender, ContentElement)
			If Not el.IsEnabled Then
				Return
			End If
			e.Handled = True
			el.CaptureMouse()
			_point = e.MouseDevice.GetPosition(el)
		End Sub

		Private Sub MouseUpHandler(ByVal sender As Object, ByVal e As MouseButtonEventArgs)
			Dim el As ContentElement = CType(sender, ContentElement)
			If Not el.IsEnabled Then
				Return
			End If
			e.Handled = True
			el.ReleaseMouseCapture()
		End Sub
'</SnippetUIElementMouseCapture>
		Private _point As Point
		Private origFontSize As Double
	End Class
End Namespace

