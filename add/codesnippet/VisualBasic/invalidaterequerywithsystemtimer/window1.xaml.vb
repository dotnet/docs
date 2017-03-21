Imports System.Windows.Threading
Imports System.Timers
Imports System.Globalization

Namespace SDKSamples
	''' <summary>
	''' Interaction logic for Window1.xaml
	''' </summary>

	Partial Public Class Window1
		Inherits Window
		' The custom routed command.
		Public Shared customCommand As New RoutedCommand()

		' The timer. 
		Private timer As System.Timers.Timer

		' Delegate for thr worker item to place on the Dispatcher
		Private Delegate Sub TimerDispatcherDelegate()

		Public Sub New()
			InitializeComponent()

			' System Timer setup.
			timer = New System.Timers.Timer()
			AddHandler timer.Elapsed, AddressOf timer_Elapsed
			timer.Interval = 1000
			timer.Enabled = True
		End Sub

		' System.Timers.Timer.Elapsed handler
		'<SnippetSystemTimerDispatcherInvoke>
		' Places the delegate onto the UI Thread's Dispatcher
		Private Sub timer_Elapsed(ByVal sender As Object, ByVal e As ElapsedEventArgs)
			' Place delegate on the Dispatcher.
			Me.Dispatcher.Invoke(DispatcherPriority.Normal, New TimerDispatcherDelegate(AddressOf TimerWorkItem))
		End Sub
		'</SnippetSystemTimerDispatcherInvoke>

		' Method to place onto the UI thread's dispatcher.
		' Updates the current second display and calls 
		' InvalidateRequerySuggested on the CommandManager to force the
		' Command to raise the CanExecuteChanged event.
		Private Sub TimerWorkItem()
			' Update current second display.
			lblSeconds.Content = Date.Now.Second

			' Forcing the CommandManager to raie the RequerySuggested event.
			CommandManager.InvalidateRequerySuggested()
		End Sub

		' Executed Event Handler.
		'
		' Updates the result TextBox with the current seconds and the 
		' target second, which is the value passed from the command source.
		Private Sub CustomCommandExecuted(ByVal sender As Object, ByVal e As ExecutedRoutedEventArgs)
            txtResults.Text = "Command Executed at " & Date.Now.Second & " seconds after the minute " & vbLf & vbLf & "The target second is set to " & e.Parameter.ToString()
		End Sub

		' CanExecute Event Handler.
		'
		' True if the current seconds are greater than the target value that is 
		' set on the Slider, which is defined in the XMAL file.
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

		Private Sub OnSliderMouseWheel(ByVal sender As Object, ByVal e As MouseWheelEventArgs)
			Dim source As Slider = TryCast(e.Source, Slider)
			If source IsNot Nothing Then
				If e.Delta > 0 Then
					' Execute the Slider DecreaseSmall RoutedCommand.
					' The slider.value propety is passed as the command parameter.
					CType(Slider.DecreaseSmall, RoutedCommand).Execute(source.Value, source)

				Else
					' Execute the Slider IncreaseSmall RoutedCommand.
					' The slider.value propety is passed as the command parameter.
					CType(Slider.IncreaseSmall, RoutedCommand).Execute(source.Value, source)
				End If
			End If
		End Sub

		' Moves the slider when the mouse extended buttons are pressed
		Private Sub OnSliderMouseUp(ByVal sender As Object, ByVal e As MouseButtonEventArgs)
			Dim source As Slider = TryCast(e.Source, Slider)

			If source IsNot Nothing Then
				If e.ChangedButton = MouseButton.XButton1 Then
					' Execute the Slider DecreaseSmall RoutedCommand.
					' The slider.value propety is passed as the command parameter.
					CType(Slider.DecreaseSmall, RoutedCommand).Execute(source.Value, source)
				End If
				If e.ChangedButton = MouseButton.XButton2 Then
					' Execute the Slider IncreaseSmall RoutedCommand.
					' The slider.value propety is passed as the command parameter.
					CType(Slider.IncreaseSmall, RoutedCommand).Execute(source.Value, source)
				End If
			End If
		End Sub
	End Class

	' Converter to convert the Slider value property to an int32.
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