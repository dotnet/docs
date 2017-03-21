'
' SupportingClasses.vb 
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

Namespace Microsoft.Samples.CustomControls



	#Region "SpectrumSlider"

	Public Class SpectrumSlider
		Inherits Slider


		Shared Sub New()

			DefaultStyleKeyProperty.OverrideMetadata(GetType(SpectrumSlider), New FrameworkPropertyMetadata(GetType(SpectrumSlider)))
		End Sub


		Private pickerBrush As LinearGradientBrush



		Private Shared ReadOnly SelectedColorProperty As DependencyProperty = DependencyProperty.Register ("SelectedColor", GetType(Color), GetType(SpectrumSlider), New PropertyMetadata(System.Windows.Media.Colors.Transparent))


		Public Property SelectedColor() As Color
			Get

				Return CType(GetValue(SelectedColorProperty), Color)
			End Get
			Set(ByVal value As Color)
				SetValue(SelectedColorProperty, value)
			End Set

		End Property

		Protected Overrides Sub OnValueChanged(ByVal oldValue As Double, ByVal newValue As Double)

			MyBase.OnValueChanged(oldValue, newValue)
			Dim theColor? As Color = ColorUtilities.ConvertHsvToRgb(360 - newValue, 1, 1)

			SetValue(SelectedColorProperty, theColor)

		End Sub


		Public Overrides Sub OnApplyTemplate()

			MyBase.OnApplyTemplate()
			m_spectrumDisplay = TryCast(GetTemplateChild(SpectrumDisplayName), Rectangle)


			If Not colorsInitialized Then

				updateColorSpectrum()
				OnValueChanged(0, 0)
			End If

		End Sub


		Private Sub updateColorSpectrum()


			If m_spectrumDisplay IsNot Nothing Then
				colorsInitialized = True
				createSpectrum()

			Else
				colorsInitialized = False

			End If
		End Sub



		Private Sub createSpectrum()

			pickerBrush = New LinearGradientBrush()
			pickerBrush.StartPoint = New Point(0.5, 0)
			pickerBrush.EndPoint = New Point(0.5, 1)
			pickerBrush.ColorInterpolationMode = ColorInterpolationMode.SRgbLinearInterpolation


			Dim colorsList As List(Of Color) = ColorUtilities.GenerateHsvSpectrum()
			Dim stopIncrement As Double = CDbl(1) / colorsList.Count

			Dim i As Integer
			For i = 0 To colorsList.Count - 1
				pickerBrush.GradientStops.Add(New GradientStop(colorsList(i), i * stopIncrement))
			Next i

			pickerBrush.GradientStops(i - 1).Offset = 1.0
			m_spectrumDisplay.Fill = pickerBrush

		End Sub


		Private Shared SpectrumDisplayName As String = "PART_SpectrumDisplay"
		Private m_spectrumDisplay As Rectangle
		Private colorsInitialized As Boolean = False

	End Class

	#End Region ' SpectrumSlider


	#Region "ColorUtilities"

	Friend NotInheritable Class ColorUtilities

		' Converts an RGB color to an HSV color.
		Private Sub New()
		End Sub
		Public Shared Function ConvertRgbToHsv(ByVal r As Integer, ByVal b As Integer, ByVal g As Integer) As HsvColor
			Dim otherColor As System.Drawing.Color = System.Drawing.Color.FromArgb(255, r, b, g)

			Return New HsvColor(otherColor.GetHue(), otherColor.GetSaturation(), otherColor.GetBrightness())

		End Function

		' Converts an HSV color to an RGB color.
		Public Shared Function ConvertHsvToRgb(ByVal h As Double, ByVal s As Double, ByVal v As Double) As Color

			Dim r As Double = 0, g As Double = 0, b As Double = 0

			If s = 0 Then
				r = v
				g = v
				b = v
			Else
				Dim i As Integer
				Dim f, p, q, t As Double

				If h = 360 Then
					h = 0
				Else
					h = h / 60
				End If

				i = CInt(Fix(Math.Truncate(h)))
				f = h - i

				p = v * (1.0 - s)
				q = v * (1.0 - (s * f))
				t = v * (1.0 - (s * (1.0 - f)))

				Select Case i
					Case 0
						r = v
						g = t
						b = p

					Case 1
						r = q
						g = v
						b = p

					Case 2
						r = p
						g = v
						b = t

					Case 3
						r = p
						g = q
						b = v

					Case 4
						r = t
						g = p
						b = v

					Case Else
						r = v
						g = p
						b = q
				End Select

			End If

			Return Color.FromArgb(255, CByte(r * 255), CByte(g * 255), CByte(b * 255))

		End Function

		' Generates a list of colors with hues ranging from 0 360
		' and a saturation and value of 1. 
		Public Shared Function GenerateHsvSpectrum() As List(Of Color)

			Dim colorsList As New List(Of Color)(8)


			For i As Integer = 0 To 58

				colorsList.Add(ColorUtilities.ConvertHsvToRgb(i * 6, 1, 1))

			Next i
			colorsList.Add(ColorUtilities.ConvertHsvToRgb(0, 1, 1))


			Return colorsList

		End Function

	End Class

	#End Region ' ColorUtilities


	' Describes a color in terms of
	' Hue, Saturation, and Value (brightness)
	#Region "HsvColor"
	Friend Structure HsvColor

		Public H As Double
		Public S As Double
		Public V As Double

		Public Sub New(ByVal h As Double, ByVal s As Double, ByVal v As Double)
			Me.H = h
			Me.S = s
			Me.V = v

		End Sub
	End Structure
	#End Region ' HsvColor

	#Region "ColorThumb"
	Public Class ColorThumb
		Inherits System.Windows.Controls.Primitives.Thumb

		Shared Sub New()

			DefaultStyleKeyProperty.OverrideMetadata(GetType(ColorThumb), New FrameworkPropertyMetadata(GetType(ColorThumb)))
		End Sub


		Public Shared ReadOnly ThumbColorProperty As DependencyProperty = DependencyProperty.Register ("ThumbColor", GetType(Color), GetType(ColorThumb), New FrameworkPropertyMetadata(Colors.Transparent))

		Public Shared ReadOnly PointerOutlineThicknessProperty As DependencyProperty = DependencyProperty.Register ("PointerOutlineThickness", GetType(Double), GetType(ColorThumb), New FrameworkPropertyMetadata(1.0))

		Public Shared ReadOnly PointerOutlineBrushProperty As DependencyProperty = DependencyProperty.Register ("PointerOutlineBrush", GetType(Brush), GetType(ColorThumb), New FrameworkPropertyMetadata(Nothing))



		Public Property ThumbColor() As Color
			Get
				Return CType(GetValue(ThumbColorProperty), Color)
			End Get
			Set(ByVal value As Color)

				SetValue(ThumbColorProperty, value)
			End Set
		End Property

		Public Property PointerOutlineThickness() As Double
			Get
				Return CDbl(GetValue(PointerOutlineThicknessProperty))
			End Get
			Set(ByVal value As Double)
				SetValue(PointerOutlineThicknessProperty, value)
			End Set
		End Property

		Public Property PointerOutlineBrush() As Brush
			Get
				Return CType(GetValue(PointerOutlineBrushProperty), Brush)
			End Get
			Set(ByVal value As Brush)
				SetValue(PointerOutlineBrushProperty, value)
			End Set
		End Property


	End Class
	#End Region ' ColorThumb


End Namespace