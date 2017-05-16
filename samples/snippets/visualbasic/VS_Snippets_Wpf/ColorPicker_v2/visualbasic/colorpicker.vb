'
' ColorPicker.vb 
' An HSB (hue, saturation, brightness) based
' color picker.
'
' 

Imports Microsoft.VisualBasic
Imports System
Imports System.Windows
Imports System.Windows.Navigation
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Shapes
Imports System.Windows.Ink
Imports System.Windows.Controls
Imports System.Collections.Generic
Imports System.Windows.Input
Imports System.Windows.Data
Imports System.Windows.Markup
Imports System.Text

Namespace Microsoft.Samples.CustomControls


	#Region "ColorPicker"

	Public Class ColorPicker
		Inherits Control


		Shared Sub New()
			DefaultStyleKeyProperty.OverrideMetadata(GetType(ColorPicker), New FrameworkPropertyMetadata(GetType(ColorPicker)))
		End Sub

		Public Sub New()
			m_color = Colors.White
			shouldFindPoint = True
			SetValue(AProperty, m_color.A)
			SetValue(RProperty, m_color.R)
			SetValue(GProperty, m_color.G)
			SetValue(BProperty, m_color.B)
			SetValue(SelectedColorProperty, m_color)
		End Sub


		#Region "Public Methods"

		Public Overrides Sub OnApplyTemplate()

			MyBase.OnApplyTemplate()
			m_ColorDetail = TryCast(GetTemplateChild(ColorDetailName), FrameworkElement)
			m_ColorMarker = TryCast(GetTemplateChild(ColorMarkerName), Path)
			m_ColorSlider = TryCast(GetTemplateChild(ColorSliderName), SpectrumSlider)
			AddHandler m_ColorSlider.ValueChanged, AddressOf BaseColorChanged

			m_ColorMarker.RenderTransform = markerTransform
			m_ColorMarker.RenderTransformOrigin = New Point(0.5, 0.5)

			AddHandler m_ColorDetail.MouseLeftButtonDown, AddressOf OnMouseLeftButtonDown
			AddHandler m_ColorDetail.PreviewMouseMove, AddressOf OnMouseMove
			AddHandler m_ColorDetail.SizeChanged, AddressOf ColorDetailSizeChanged

			shouldFindPoint = True
			setColor(SelectedColor)
		End Sub



		#End Region


		#Region "Public Properties"

		' Gets or sets the selected color.
		Public Property SelectedColor() As System.Windows.Media.Color
			Get

				Return CType(GetValue(SelectedColorProperty), System.Windows.Media.Color)
			End Get
			Set(ByVal value As System.Windows.Media.Color)
				setColor(CType(value, Color))
			End Set
		End Property


		#Region "RGB Properties"
		' Gets or sets the ARGB alpha value of the selected color.
		Public Property A() As Byte
			Get
				Return CByte(GetValue(AProperty))
			End Get
			Set(ByVal value As Byte)
				SetValue(AProperty, value)
			End Set
		End Property

		' Gets or sets the ARGB red value of the selected color.
		Public Property R() As Byte
			Get
				Return CByte(GetValue(RProperty))
			End Get
			Set(ByVal value As Byte)
				SetValue(RProperty, value)
			End Set
		End Property

		' Gets or sets the ARGB green value of the selected color.
		Public Property G() As Byte
			Get
				Return CByte(GetValue(GProperty))
			End Get
			Set(ByVal value As Byte)
				SetValue(GProperty, value)
			End Set
		End Property

		' Gets or sets the ARGB blue value of the selected color.
		Public Property B() As Byte
			Get
				Return CByte(GetValue(BProperty))
			End Get
			Set(ByVal value As Byte)
				SetValue(BProperty, value)
			End Set
		End Property
		#End Region ' RGB Properties

		#Region "ScRGB Properties"

		' Gets or sets the ScRGB alpha value of the selected color.
		Public Property ScA() As Double
			Get
				Return CDbl(GetValue(ScAProperty))
			End Get
			Set(ByVal value As Double)
				SetValue(ScAProperty, value)
			End Set
		End Property

		' Gets or sets the ScRGB red value of the selected color.
		Public Property ScR() As Double
			Get
				Return CDbl(GetValue(ScRProperty))
			End Get
			Set(ByVal value As Double)
				SetValue(RProperty, value)
			End Set
		End Property

		' Gets or sets the ScRGB green value of the selected color.
		Public Property ScG() As Double
			Get
				Return CDbl(GetValue(ScGProperty))
			End Get
			Set(ByVal value As Double)
				SetValue(GProperty, value)
			End Set
		End Property

		' Gets or sets the ScRGB blue value of the selected color.
		Public Property ScB() As Double
			Get
				Return CDbl(GetValue(BProperty))
			End Get
			Set(ByVal value As Double)
				SetValue(BProperty, value)
			End Set
		End Property
		#End Region ' ScRGB Properties

		' Gets or sets the the selected color in hexadecimal notation.
		Public Property HexadecimalString() As String
			Get
				Return CStr(GetValue(HexadecimalStringProperty))
			End Get
			Set(ByVal value As String)
				SetValue(HexadecimalStringProperty, value)
			End Set
		End Property

		#End Region


		#Region "Public Events"

		Public Custom Event SelectedColorChanged As RoutedPropertyChangedEventHandler(Of Color)
			AddHandler(ByVal value As RoutedPropertyChangedEventHandler(Of Color))
				MyBase.AddHandler(SelectedColorChangedEvent, value)
			End AddHandler

			RemoveHandler(ByVal value As RoutedPropertyChangedEventHandler(Of Color))
				MyBase.RemoveHandler(SelectedColorChangedEvent, value)
			End RemoveHandler
			RaiseEvent(ByVal sender As System.Object, ByVal e As RoutedPropertyChangedEventArgs(Of Color))
			End RaiseEvent
		End Event

		#End Region


		#Region "Dependency Property Fields"
		Public Shared ReadOnly SelectedColorProperty As DependencyProperty = DependencyProperty.Register ("SelectedColor", GetType(System.Windows.Media.Color), GetType(ColorPicker), New PropertyMetadata(System.Windows.Media.Colors.Transparent, New PropertyChangedCallback(AddressOf selectedColor_changed)))

		Public Shared ReadOnly ScAProperty As DependencyProperty = DependencyProperty.Register ("ScA", GetType(Single), GetType(ColorPicker), New PropertyMetadata(CSng(1), New PropertyChangedCallback(AddressOf ScAChanged)))

		Public Shared ReadOnly ScRProperty As DependencyProperty = DependencyProperty.Register ("ScR", GetType(Single), GetType(ColorPicker), New PropertyMetadata(CSng(1), New PropertyChangedCallback(AddressOf ScRChanged)))

		Public Shared ReadOnly ScGProperty As DependencyProperty = DependencyProperty.Register ("ScG", GetType(Single), GetType(ColorPicker), New PropertyMetadata(CSng(1), New PropertyChangedCallback(AddressOf ScGChanged)))

		Public Shared ReadOnly ScBProperty As DependencyProperty = DependencyProperty.Register ("ScB", GetType(Single), GetType(ColorPicker), New PropertyMetadata(CSng(1), New PropertyChangedCallback(AddressOf ScBChanged)))

		Public Shared ReadOnly AProperty As DependencyProperty = DependencyProperty.Register ("A", GetType(Byte), GetType(ColorPicker), New PropertyMetadata(CByte(255), New PropertyChangedCallback(AddressOf AChanged)))

		Public Shared ReadOnly RProperty As DependencyProperty = DependencyProperty.Register ("R", GetType(Byte), GetType(ColorPicker), New PropertyMetadata(CByte(255), New PropertyChangedCallback(AddressOf RChanged)))

		Public Shared ReadOnly GProperty As DependencyProperty = DependencyProperty.Register ("G", GetType(Byte), GetType(ColorPicker), New PropertyMetadata(CByte(255), New PropertyChangedCallback(AddressOf GChanged)))

		Public Shared ReadOnly BProperty As DependencyProperty = DependencyProperty.Register ("B", GetType(Byte), GetType(ColorPicker), New PropertyMetadata(CByte(255), New PropertyChangedCallback(AddressOf BChanged)))

		Public Shared ReadOnly HexadecimalStringProperty As DependencyProperty = DependencyProperty.Register ("HexadecimalString", GetType(String), GetType(ColorPicker), New PropertyMetadata("#FFFFFFFF", New PropertyChangedCallback(AddressOf HexadecimalStringChanged)))

		#End Region


		#Region "RoutedEvent Fields"

		Public Shared ReadOnly SelectedColorChangedEvent As RoutedEvent = EventManager.RegisterRoutedEvent("SelectedColorChanged", RoutingStrategy.Bubble, GetType(RoutedPropertyChangedEventHandler(Of Color)), GetType(ColorPicker))
		#End Region


		#Region "Property Changed Callbacks"

		Private Shared Sub AChanged(ByVal d As DependencyObject, ByVal e As DependencyPropertyChangedEventArgs)
			Dim c As ColorPicker = CType(d, ColorPicker)
			c.OnAChanged(CByte(e.NewValue))
		End Sub

		Protected Overridable Sub OnAChanged(ByVal newValue As Byte)

			m_color.A = newValue
			SetValue(ScAProperty, m_color.ScA)
			SetValue(SelectedColorProperty, m_color)

		End Sub

		Private Shared Sub RChanged(ByVal d As DependencyObject, ByVal e As DependencyPropertyChangedEventArgs)
			Dim c As ColorPicker = CType(d, ColorPicker)
			c.OnRChanged(CByte(e.NewValue))
		End Sub

		Protected Overridable Sub OnRChanged(ByVal newValue As Byte)
			m_color.R = newValue
			SetValue(ScRProperty, m_color.ScR)
			SetValue(SelectedColorProperty, m_color)
		End Sub


		Private Shared Sub GChanged(ByVal d As DependencyObject, ByVal e As DependencyPropertyChangedEventArgs)
			Dim c As ColorPicker = CType(d, ColorPicker)
			c.OnGChanged(CByte(e.NewValue))
		End Sub

		Protected Overridable Sub OnGChanged(ByVal newValue As Byte)

			m_color.G = newValue
			SetValue(ScGProperty, m_color.ScG)
			SetValue(SelectedColorProperty, m_color)
		End Sub


		Private Shared Sub BChanged(ByVal d As DependencyObject, ByVal e As DependencyPropertyChangedEventArgs)
			Dim c As ColorPicker = CType(d, ColorPicker)
			c.OnBChanged(CByte(e.NewValue))
		End Sub

		Protected Overridable Sub OnBChanged(ByVal newValue As Byte)
			m_color.B = newValue
			SetValue(ScBProperty, m_color.ScB)
			SetValue(SelectedColorProperty, m_color)
		End Sub


		Private Shared Sub ScAChanged(ByVal d As DependencyObject, ByVal e As DependencyPropertyChangedEventArgs)
			Dim c As ColorPicker = CType(d, ColorPicker)
			c.OnScAChanged(CSng(e.NewValue))
		End Sub

		Protected Overridable Sub OnScAChanged(ByVal newValue As Single)
			isAlphaChange = True
			If shouldFindPoint Then
				m_color.ScA = newValue
				SetValue(AProperty, m_color.A)
				SetValue(SelectedColorProperty, m_color)
				SetValue(HexadecimalStringProperty, m_color.ToString())
			End If
			isAlphaChange = False
		End Sub


		Private Shared Sub ScRChanged(ByVal d As DependencyObject, ByVal e As DependencyPropertyChangedEventArgs)
			Dim c As ColorPicker = CType(d, ColorPicker)
			c.OnScRChanged(CSng(e.NewValue))

		End Sub

		Protected Overridable Sub OnScRChanged(ByVal newValue As Single)
			If shouldFindPoint Then
				m_color.ScR = newValue
				SetValue(RProperty, m_color.R)
				SetValue(SelectedColorProperty, m_color)
				SetValue(HexadecimalStringProperty, m_color.ToString())
			End If
		End Sub


		Private Shared Sub ScGChanged(ByVal d As DependencyObject, ByVal e As DependencyPropertyChangedEventArgs)
			Dim c As ColorPicker = CType(d, ColorPicker)
			c.OnScGChanged(CSng(e.NewValue))
		End Sub

		Protected Overridable Sub OnScGChanged(ByVal newValue As Single)

			If shouldFindPoint Then
				m_color.ScG = newValue
				SetValue(GProperty, m_color.G)
				SetValue(SelectedColorProperty, m_color)
				SetValue(HexadecimalStringProperty, m_color.ToString())
			End If
		End Sub


		Private Shared Sub ScBChanged(ByVal d As DependencyObject, ByVal e As DependencyPropertyChangedEventArgs)
			Dim c As ColorPicker = CType(d, ColorPicker)
			c.OnScBChanged(CSng(e.NewValue))
		End Sub

		Protected Overridable Sub OnScBChanged(ByVal newValue As Single)
			If shouldFindPoint Then
				m_color.ScB = newValue
				SetValue(BProperty, m_color.B)
				SetValue(SelectedColorProperty, m_color)
				SetValue(HexadecimalStringProperty, m_color.ToString())
			End If
		End Sub

		Private Shared Sub HexadecimalStringChanged(ByVal d As DependencyObject, ByVal e As DependencyPropertyChangedEventArgs)
			Dim c As ColorPicker = CType(d, ColorPicker)
			c.OnHexadecimalStringChanged(CStr(e.NewValue))
		End Sub

		Protected Overridable Sub OnHexadecimalStringChanged(ByVal newValue As String)

			If shouldFindPoint Then
				m_color = CType(ColorConverter.ConvertFromString(newValue), Color)
			End If

			SetValue(AProperty, m_color.A)
			SetValue(RProperty, m_color.R)
			SetValue(GProperty, m_color.G)
			SetValue(BProperty, m_color.B)


			If shouldFindPoint AndAlso (Not isAlphaChange) Then
				updateMarkerPosition(m_color)
			End If

		End Sub

		Private Shared Sub selectedColor_changed(ByVal d As DependencyObject, ByVal e As DependencyPropertyChangedEventArgs)
			Dim cPicker As ColorPicker = CType(d, ColorPicker)
			cPicker.OnSelectedColorChanged(CType(e.OldValue, Color), CType(e.NewValue, Color))
		End Sub
'<SnippetRoutedEventArgsRoutedEvent>
		Protected Overridable Sub OnSelectedColorChanged(ByVal oldColor As Color, ByVal newColor As Color)

			Dim newEventArgs As New RoutedPropertyChangedEventArgs(Of Color)(oldColor, newColor)
			newEventArgs.RoutedEvent = ColorPicker.SelectedColorChangedEvent
			MyBase.RaiseEvent(newEventArgs)
		End Sub
'</SnippetRoutedEventArgsRoutedEvent>
		#End Region


		#Region "Template Part Event Handlers"


		Protected Overrides Sub OnTemplateChanged(ByVal oldTemplate As ControlTemplate, ByVal newTemplate As ControlTemplate)

			If oldTemplate IsNot Nothing Then
				RemoveHandler m_ColorSlider.ValueChanged, AddressOf BaseColorChanged
				RemoveHandler m_ColorDetail.MouseLeftButtonDown, AddressOf OnMouseLeftButtonDown
				RemoveHandler m_ColorDetail.PreviewMouseMove, AddressOf OnMouseMove
				RemoveHandler m_ColorDetail.SizeChanged, AddressOf ColorDetailSizeChanged
				m_ColorDetail = Nothing
				m_ColorMarker = Nothing
				m_ColorSlider = Nothing
			End If
			MyBase.OnTemplateChanged(oldTemplate, newTemplate)
		End Sub


		Private Sub BaseColorChanged(ByVal sender As Object, ByVal e As RoutedPropertyChangedEventArgs(Of Double))

			If m_ColorPosition IsNot Nothing Then

				determineColor(CType(m_ColorPosition, Point))
			End If

		End Sub

		Private Overloads Sub OnMouseLeftButtonDown(ByVal sender As Object, ByVal e As MouseButtonEventArgs)

			Dim p As Point = e.GetPosition(m_ColorDetail)
			updateMarkerPosition(p)
		End Sub

		Private Overloads Sub OnMouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)


			If e.LeftButton = MouseButtonState.Pressed Then

				Dim p As Point = e.GetPosition(m_ColorDetail)
				updateMarkerPosition(p)
				Mouse.Synchronize()

			End If
		End Sub

		Private Sub ColorDetailSizeChanged(ByVal sender As Object, ByVal args As SizeChangedEventArgs)

			If args.PreviousSize <> Size.Empty AndAlso args.PreviousSize.Width <> 0 AndAlso args.PreviousSize.Height <> 0 Then
                Dim widthDifference As Double = args.NewSize.Width / args.PreviousSize.Width
                Dim heightDifference As Double = args.NewSize.Height / args.PreviousSize.Height
				markerTransform.X = markerTransform.X * widthDifference
				markerTransform.Y = markerTransform.Y * heightDifference
			End If
		End Sub

		#End Region


		#Region "Color Resolution Helpers"

		Private Sub setColor(ByVal theColor As Color)

			updateMarkerPosition(theColor)
			SetValue(SelectedColorProperty, theColor)
		End Sub

		Private Sub updateMarkerPosition(ByVal p As Point)
			markerTransform.X = p.X
			markerTransform.Y = p.Y
			p.X = p.X / m_ColorDetail.ActualWidth
			p.Y = p.Y / m_ColorDetail.ActualHeight
			m_ColorPosition = p
			determineColor(p)
		End Sub

		Private Sub updateMarkerPosition(ByVal theColor As Color)
			m_ColorPosition = Nothing
			Dim hsv As HsvColor = ColorUtilities.ConvertRgbToHsv(theColor.R, theColor.G, theColor.B)
			m_ColorSlider.Value = 360 - hsv.H
			Dim p As New Point(hsv.S, 1 - hsv.V)
			m_ColorPosition = p
			p.X = p.X * m_ColorDetail.ActualWidth
			p.Y = p.Y * m_ColorDetail.ActualHeight
			markerTransform.X = p.X
			markerTransform.Y = p.Y

		End Sub

		Private Sub determineColor(ByVal p As Point)

			Dim hsv As New HsvColor(360 - m_ColorSlider.Value, 1, 1)
			hsv.S = p.X
			hsv.V = 1 - p.Y
			m_color = ColorUtilities.ConvertHsvToRgb(hsv.H, hsv.S, hsv.V)
			shouldFindPoint = False
			m_color.ScA = CSng(GetValue(ScAProperty))
			SetValue(HexadecimalStringProperty, m_color.ToString())
			shouldFindPoint = True

		End Sub

		#End Region


		#Region "Private Fields"
		Private m_ColorSlider As SpectrumSlider
		Private Shared ReadOnly ColorSliderName As String = "PART_ColorSlider"
		Private m_ColorDetail As FrameworkElement
		Private Shared ReadOnly ColorDetailName As String = "PART_ColorDetail"
		Private markerTransform As New TranslateTransform()
		Private m_ColorMarker As Path
		Private Shared ReadOnly ColorMarkerName As String = "PART_ColorMarker"
		Private m_ColorPosition? As Point
		Private m_color As Color
		Private shouldFindPoint As Boolean
		Private isAlphaChange As Boolean
		#End Region

	End Class

	#End Region ' ColorPicker


End Namespace