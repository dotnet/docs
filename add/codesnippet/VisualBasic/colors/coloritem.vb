Imports Microsoft.VisualBasic
Imports System
Imports System.ComponentModel
Imports System.Reflection
Imports System.Windows.Data
Imports System.Windows.Media
Imports System.Collections.ObjectModel

Namespace SDKSample
	Public Class ColorItemList
		Inherits ObservableCollection(Of ColorItem)
		Public Sub New()
			MyBase.New()
			Dim type As Type = GetType(Brushes)
			For Each propertyInfo As PropertyInfo In type.GetProperties(BindingFlags.Public Or BindingFlags.Static)
				If propertyInfo.PropertyType Is GetType(SolidColorBrush) Then
					Add(New ColorItem(propertyInfo.Name, CType(propertyInfo.GetValue(Nothing, Nothing), SolidColorBrush)))
				End If
			Next propertyInfo
		End Sub
	End Class

	Public Class ColorItem
		Implements INotifyPropertyChanged
		Public Enum Sources
			UserDefined
			BuiltIn
		End Enum

		Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
		Protected Sub OnPropertyChanged(ByVal name As String)
			RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(name))
		End Sub

		Public Sub New(ByVal name As String, ByVal brush As SolidColorBrush)
			_source = Sources.BuiltIn
			_name = name
			_brush = brush
			Dim color As Color = brush.Color
			_alpha = color.A
			_red = color.R
			_green = color.G
			_blue = color.B
			HsvFromRgb()
		End Sub

		Public Sub New(ByVal item As ColorItem)
			_source = Sources.UserDefined
			_name = "New Color"
			_red = item._red
			_green = item._green
			_blue = item._blue
			_hue = item._hue
			_saturation = item._saturation
			_value = item._value
			_alpha = item._alpha
			_luminance = item._luminance
			_brush = New SolidColorBrush(item._brush.Color)
		End Sub

		Private Sub HsvFromRgb()
			Dim imax As Integer = _red, imin As Integer = _red
			If _green > imax Then
				imax = _green
				ElseIf _green < imin Then
					imin = _green
				End If
			If _blue > imax Then
				imax = _blue
				ElseIf _blue < imin Then
					imin = _blue
				End If
			Dim max As Double = imax / 255.0, min As Double = imin / 255.0

			Dim value As Double = max
			Dim saturation As Double = If((max > 0), (max - min) / max, 0.0)
			Dim hue As Double = _hue

			If imax > imin Then
				Dim f As Double = 1.0 / ((max - min) * 255.0)
                hue = If((imax = _red), 0.0 + f * (CDbl(_green) - CDbl(_blue)), If((imax = _green), 2.0 + f * (CDbl(_blue) - CDbl(_red)), 4.0 + f * (CDbl(_red) - CDbl(_green))))
				hue = hue * 60.0
				If hue < 0.0 Then
					hue += 360.0
				End If
			End If

			' now update the real values as necessary
			If hue <> _hue Then
				_hue = hue
				OnPropertyChanged("Hue")
			End If
			If saturation <> _saturation Then
				_saturation = saturation
				OnPropertyChanged("Saturation")
			End If
			If value <> _value Then
				_value = value
				OnPropertyChanged("Value")
			End If

			UpdateBrush()
		End Sub

		Private Sub RgbFromHsv()
			Dim red As Double = 0.0, green As Double = 0.0, blue As Double = 0.0
			If _saturation = 0.0 Then
				blue = _value
				green = blue
				red = green
			Else
				Dim h As Double = _hue
				Do While h >= 360.0
					h -= 360.0
				Loop

				h = h / 60.0
				Dim i As Integer = CInt(Fix(h))

				Dim f As Double = h - i
				Dim r As Double = _value * (1.0 - _saturation)
				Dim s As Double = _value * (1.0 - _saturation * f)
				Dim t As Double = _value * (1.0 - _saturation * (1.0 - f))

				Select Case i
					Case 0
						red = _value
						green = t
						blue = r
					Case 1
						red = s
						green = _value
						blue = r
					Case 2
						red = r
						green = _value
						blue = t
					Case 3
						red = r
						green = s
						blue = _value
					Case 4
						red = t
						green = r
						blue = _value
					Case 5
						red = _value
						green = r
						blue = s
				End Select
			End If

			Dim iRed As Byte = CByte(red * 255.0), iGreen As Byte = CByte(green * 255.0), iBlue As Byte = CByte(blue * 255.0)
			If iRed <> _red Then
				_red = iRed
				OnPropertyChanged("Red")
			End If
			If iGreen <> _green Then
				_green = iGreen
				OnPropertyChanged("Green")
			End If
			If iBlue <> _blue Then
				_blue = iBlue
				OnPropertyChanged("Blue")
			End If

			UpdateBrush()
		End Sub

		Private Sub UpdateBrush()
			Dim color As Color = _brush.Color
			If _alpha <> color.A OrElse _red <> color.R OrElse _green <> color.G OrElse _blue <> color.B Then
				color = Color.FromArgb(_alpha, _red, _green, _blue)
				_brush = New SolidColorBrush(color)
				OnPropertyChanged("Brush")
			End If

			Dim luminance As Double = (0.30 * _red + 0.59 * _green + 0.11 * _blue) / 255.0
			If _luminance <> luminance Then
				_luminance = luminance
				OnPropertyChanged("Luminance")
			End If
		End Sub

		Private _name As String
		Public Property Name() As String
			Get
				Return _name
			End Get
			Set(ByVal value As String)
				_name = value
				OnPropertyChanged("Name")
			End Set
		End Property

		Private _source As Sources = Sources.UserDefined
		Public ReadOnly Property Source() As Sources
			Get
				Return _source
			End Get
		End Property

		Private _luminance As Double
		Public Property Luminance() As Double
			Get
				Return _luminance
			End Get
			Set(ByVal value As Double)
				Me._luminance = value
			End Set
		End Property

		Private _brush As SolidColorBrush
		Public ReadOnly Property Brush() As SolidColorBrush
			Get
				Return _brush
			End Get
		End Property

		Private _alpha As Byte
		Public Property Alpha() As Byte
			Get
				Return _alpha
			End Get
			Set(ByVal value As Byte)
				_alpha = value
				OnPropertyChanged("Alpha")
				UpdateBrush()
			End Set
		End Property

		Private _red As Byte
		Public Property Red() As Byte
			Get
				Return _red
			End Get
			Set(ByVal value As Byte)
				_red = value
				OnPropertyChanged("Red")
				HsvFromRgb()
			End Set
		End Property

		Private _green As Byte
		Public Property Green() As Byte
			Get
				Return _green
			End Get
			Set(ByVal value As Byte)
				_green = value
				OnPropertyChanged("Green")
				HsvFromRgb()
			End Set
		End Property

		Private _blue As Byte
		Public Property Blue() As Byte
			Get
				Return _blue
			End Get
			Set(ByVal value As Byte)
				_blue = value
				OnPropertyChanged("Blue")
				HsvFromRgb()
			End Set
		End Property

		Private _hue As Double
		Public Property Hue() As Double
			Get
				Return _hue
			End Get
			Set(ByVal value As Double)
				If value > 360.0 Then
					value = 360.0
				End If
					If value < 0.0 Then
						value = 0.0
					End If
				_hue = value
				OnPropertyChanged("Hue")
				RgbFromHsv()
			End Set
		End Property

		Private _saturation As Double
		Public Property Saturation() As Double
			Get
				Return _saturation
			End Get
			Set(ByVal value As Double)
				If value > 1.0 Then
					value = 1.0
				End If
					If value < 0.0 Then
						value = 0.0
					End If
				_saturation = value
				OnPropertyChanged("Saturation")
				RgbFromHsv()
			End Set
		End Property

		Private _value As Double
		Public Property Value() As Double
			Get
				Return _value
			End Get
			Set(ByVal value As Double)
				If value > 1.0 Then
					value = 1.0
				End If
					If value < 0.0 Then
						value = 0.0
					End If
				_value = value
				OnPropertyChanged("Value")
				RgbFromHsv()
			End Set
		End Property
	End Class
End Namespace
