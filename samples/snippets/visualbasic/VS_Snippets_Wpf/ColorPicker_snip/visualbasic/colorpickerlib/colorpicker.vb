Imports Microsoft.VisualBasic
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Data
'<SnippetUsing1>
Imports System.Windows.Markup
'</SnippetUsing1>
Imports System.ComponentModel

Namespace ColorPickerLib
	Public Class ColorPicker
		Inherits Control
 '<Snippet3>        
		'<SnippetcolorCache>
		Private _colorCache As Color
		'</SnippetcolorCache>

		Shared Sub New()
			DefaultStyleKeyProperty.OverrideMetadata(GetType(ColorPicker), New FrameworkPropertyMetadata(GetType(ColorPicker)))
		End Sub
 '</Snippet3>

'<Snippet9>
		Public Sub New()
			_colorCache = CType(ColorProperty.GetMetadata(Me).DefaultValue, Color)
			SetupColorBindings()
		End Sub
'</Snippet9>

'<Snippet7>
		Private Sub SetupColorBindings()
			Dim binding As New MultiBinding()

			binding.Converter = New ByteColorMultiConverter()
			binding.Mode = BindingMode.TwoWay

			Dim redBinding As New Binding("Red")
			redBinding.Source = Me
			redBinding.Mode = BindingMode.TwoWay
			binding.Bindings.Add(redBinding)

			Dim greenBinding As New Binding("Green")
			greenBinding.Source = Me
			greenBinding.Mode = BindingMode.TwoWay
			binding.Bindings.Add(greenBinding)

			Dim blueBinding As New Binding("Blue")
			blueBinding.Source = Me
			blueBinding.Mode = BindingMode.TwoWay
			binding.Bindings.Add(blueBinding)

			Me.SetBinding(ColorProperty, binding)
		End Sub
'</Snippet7>

'<Snippet10>
		Public Shared ColorProperty As DependencyProperty = DependencyProperty.Register("Color", GetType(Color), GetType(ColorPicker), New PropertyMetadata(Colors.Black))
'<Snippet10>

'<Snippet4>
		Public Property Color() As Color
			Get
				Return CType(GetValue(ColorProperty), Color)
			End Get
			Set(ByVal value As Color)
				SetValue(ColorProperty, value)
			End Set
		End Property
'</Snippet4>

'<Snippet5>
		Public Shared RedProperty As DependencyProperty = DependencyProperty.Register("Red", GetType(Byte), GetType(ColorPicker))

		Public Shared GreenProperty As DependencyProperty = DependencyProperty.Register("Green", GetType(Byte), GetType(ColorPicker))

		Public Shared BlueProperty As DependencyProperty = DependencyProperty.Register("Blue", GetType(Byte), GetType(ColorPicker))
'</Snippet5>

'<SnippetRedGreenBlueCLR>
		Public Property Red() As Byte
			Get
				Return CByte(GetValue(RedProperty))
			End Get
			Set(ByVal value As Byte)
				SetValue(RedProperty, value)
			End Set
		End Property

		Public Property Green() As Byte
			Get
				Return CByte(GetValue(GreenProperty))
			End Get
			Set(ByVal value As Byte)
				SetValue(GreenProperty, value)
			End Set
		End Property

		Public Property Blue() As Byte
			Get
				Return CByte(GetValue(BlueProperty))
			End Get
			Set(ByVal value As Byte)
				SetValue(BlueProperty, value)
			End Set
		End Property
'</SnippetRedGreenBlueCLR>

'<Snippet8>

		'<SnippetColorChangedEvent>
		Public Shared ReadOnly ColorChangedEvent As RoutedEvent = EventManager.RegisterRoutedEvent("ColorChanged", RoutingStrategy.Bubble, GetType(RoutedPropertyChangedEventHandler(Of Color)), GetType(ColorPicker))
		'</SnippetColorChangedEvent>

		'<SnippetColorChanged>
		Public Custom Event ColorChanged As RoutedPropertyChangedEventHandler(Of Color)
			AddHandler(ByVal value As RoutedPropertyChangedEventHandler(Of Color))
				MyBase.AddHandler(ColorChangedEvent, value)
			End AddHandler
			RemoveHandler(ByVal value As RoutedPropertyChangedEventHandler(Of Color))
				MyBase.RemoveHandler(ColorChangedEvent, value)
			End RemoveHandler
			RaiseEvent(ByVal sender As System.Object, ByVal e As RoutedPropertyChangedEventArgs(Of Color))
			End RaiseEvent
		End Event
		'</SnippetColorChanged>

		'<SnippetOnColorChanged>
		Protected Overridable Sub OnColorChanged(ByVal oldValue As Color, ByVal newValue As Color)
			Dim args As New RoutedPropertyChangedEventArgs(Of Color)(oldValue, newValue)
			args.RoutedEvent = ColorPicker.ColorChangedEvent
			MyBase.RaiseEvent(args)
		End Sub
		'</SnippetOnColorChanged>

'</Snippet8>

'<Snippet11>

		'<SnippetOnColorInvalidated>
		Private Shared Sub OnColorInvalidated(ByVal d As DependencyObject, ByVal e As DependencyPropertyChangedEventArgs)
			Dim picker As ColorPicker = CType(d, ColorPicker)

			Dim oldValue As Color = CType(e.OldValue, Color)
			Dim newValue As Color = CType(e.NewValue, Color)

			picker.OnColorChanged(oldValue, newValue)
		End Sub
		'</SnippetOnColorInvalidated>



'</Snippet11>
	End Class
'<Snippet6>
	Public Class ByteColorMultiConverter
		Implements IMultiValueConverter

		Public Function Convert(ByVal values() As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements IMultiValueConverter.Convert
			If values.Length <> 3 Then
				Throw New ArgumentException("need three values")
			End If

			Dim red As Byte = CByte(values(0))
			Dim green As Byte = CByte(values(1))
			Dim blue As Byte = CByte(values(2))

			Return Color.FromRgb(red, green, blue)
		End Function

		Public Function ConvertBack(ByVal value As Object, ByVal targetTypes() As Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object() Implements IMultiValueConverter.ConvertBack
			Dim color As Color = CType(value, Color)

			Return New Object() { color.R, color.G, color.B }
		End Function
	End Class
'</Snippet6>

'<Snippet12>
	Public Class ByteDoubleConverter
		Implements IValueConverter
		Public Function Convert(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements IValueConverter.Convert
			Return CDbl(CByte(value))
		End Function

		Public Function ConvertBack(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements IValueConverter.ConvertBack
			Return CByte(CDbl(value))
		End Function
	End Class
'</Snippet12>

'<Snippet16>
	<ValueConversion(GetType(Color), GetType(SolidColorBrush))>
	Public Class ColorBrushConverter
		Implements IValueConverter
		Public Function Convert(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements IValueConverter.Convert
			Dim color As Color = CType(value, Color)
			Return New SolidColorBrush(color)
		End Function

		Public Function ConvertBack(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements IValueConverter.ConvertBack
			Return Nothing
		End Function
	End Class
'</Snippet16>
End Namespace
