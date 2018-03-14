Imports System.Windows.Threading
Imports System.Globalization
Imports System.Windows

Namespace SDKSamples
	''' <summary>
	''' Interaction logic for Window1.xaml
	''' </summary>

	Partial Public Class Window1
		Inherits Window
		'  The custom routed command.
		Public Shared customCommand As New RoutedCommand()

		'  The timer.
		Private dispatcherTimer As Threading.DispatcherTimer

		Public Sub New()
			InitializeComponent()

			'<SnippetInvalidateSampleDispatcherTimerInit>
			'  DispatcherTimer setup
			dispatcherTimer = New Threading.DispatcherTimer()
			AddHandler dispatcherTimer.Tick, AddressOf dispatcherTimer_Tick
			dispatcherTimer.Interval = New TimeSpan(0,0,1)
			dispatcherTimer.Start()
			'</SnippetInvalidateSampleDispatcherTimerInit>
		End Sub

		'<SnippetInvalidateSampleDispatcherTimer>
		'  System.Windows.Threading.DispatcherTimer.Tick handler
		'
		'  Updates the current seconds display and calls
		'  InvalidateRequerySuggested on the CommandManager to force 
		'  the Command to raise the CanExecuteChanged event.
		Private Sub dispatcherTimer_Tick(ByVal sender As Object, ByVal e As EventArgs)
			' Updating the Label which displays the current second
			lblSeconds.Content = Date.Now.Second

			' Forcing the CommandManager to raise the RequerySuggested event
			CommandManager.InvalidateRequerySuggested()
		End Sub
		'</SnippetInvalidateSampleDispatcherTimer>

		'<SnippetInvalidateSampleExecuted>
		'  Executed Event Handler
		'
		'  Updates the output TextBox with the current seconds 
		'  and the target second, which is passed through Args.Parameter.
		Private Sub CustomCommandExecuted(ByVal sender As Object, ByVal e As ExecutedRoutedEventArgs)
            txtResults.Text = "Command Executed at " & Date.Now.Second & " seconds after the minute " & vbLf & vbLf & "The target second is set to " & e.Parameter.ToString()
		End Sub
		'</SnippetInvalidateSampleExecuted>

		'<SnippetInvalidateSampleCanExecute>
		'CanExecute Event Handler
		'
		'  Retrun True, if the current seconds are greater than the target value
		'  which is set on the Slider that is defined in the XMAL file.
		Private Sub CustomCommandCanExecute(ByVal sender As Object, ByVal e As CanExecuteRoutedEventArgs)
			If secondSlider IsNot Nothing Then
				If Date.Now.Second > secondSlider.Value Then
					e.CanExecute = True
				Else
					e.CanExecute = False
				End If
			Else
				e.CanExecute = False
			End If
		End Sub
		'</SnippetInvalidateSampleCanExecute>

		'<SnippetInvalidateSampleWheelHandler>
		' Moves the slider when the mouse wheel is rotated.
		Private Sub OnSliderMouseWheel(ByVal sender As Object, ByVal e As MouseWheelEventArgs)
			Dim source As Slider = TryCast(e.Source, Slider)

			If source IsNot Nothing Then

				If e.Delta > 0 Then
					'execute the Slider DecreaseSmall RoutedCommand
					'the slider.value propety is passed as the command parameter
					CType(Slider.DecreaseSmall, RoutedCommand).Execute(source.Value,source)

				Else
					'execute the Slider IncreaseSmall RoutedCommand
					'the slider.value propety is passed as the command parameter
					CType(Slider.IncreaseSmall, RoutedCommand).Execute(source.Value,source)
				End If
			End If
		End Sub
		'</SnippetInvalidateSampleWheelHandler>

		'<SnippetInvalidateSampleMouseUpHandler>
		' Moves the slider when the mouse extended buttons are pressed.
		Private Sub OnSliderMouseUp(ByVal sender As Object, ByVal e As MouseButtonEventArgs)
			Dim source As Slider = TryCast(e.Source, Slider)

			If source IsNot Nothing Then
				If e.ChangedButton = MouseButton.XButton1 Then
					'  Execute the Slider DecreaseSmall RoutedCommand
					'  The slider.value propety is passed as the command parameter
					CType(Slider.DecreaseSmall, RoutedCommand).Execute(source.Value, source)
				End If
				If e.ChangedButton = MouseButton.XButton2 Then
					'  Execute the Slider IncreaseSmall RoutedCommand
					'  The slider.value propety is passed as the command parameter
					CType(Slider.IncreaseSmall, RoutedCommand).Execute(source.Value, source)
				End If
			End If
		'</SnippetInvalidateSampleMouseUpHandler>
		End Sub
	End Class

	'Converter to convert the Slider value property from a Double to an Int
	<ValueConversion(GetType(Double), GetType(Integer))>
	Public Class SliderValueConverter
		Implements IValueConverter
		Public Function Convert(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As CultureInfo) As Object Implements IValueConverter.Convert
			Dim sliderValue As Double = CDbl(value)

			Return CInt(Fix(sliderValue))
		End Function

		Public Function ConvertBack(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As CultureInfo) As Object Implements IValueConverter.ConvertBack
			Return Nothing
		End Function
	End Class
End Namespace