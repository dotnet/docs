'<SnippetThreadingWeatherCodeBehind>

Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Media.Imaging
Imports System.Windows.Shapes
Imports System.Windows.Threading
Imports System.Threading

Namespace SDKSamples
	Partial Public Class Window1
		Inherits Window
		' Delegates to be used in placking jobs onto the Dispatcher.
		Private Delegate Sub NoArgDelegate()
		'<SnippetThreadingWeatherDelegates>
		Private Delegate Sub OneArgDelegate(ByVal arg As String)
		'</SnippetThreadingWeatherDelegates>

		' Storyboards for the animations.
		Private showClockFaceStoryboard As Storyboard
		Private hideClockFaceStoryboard As Storyboard
		Private showWeatherImageStoryboard As Storyboard
		Private hideWeatherImageStoryboard As Storyboard

		Public Sub New()
			MyBase.New()
			InitializeComponent()
		End Sub

		Private Sub Window_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
			' Load the storyboard resources.
			showClockFaceStoryboard = CType(Me.Resources("ShowClockFaceStoryboard"), Storyboard)
			hideClockFaceStoryboard = CType(Me.Resources("HideClockFaceStoryboard"), Storyboard)
			showWeatherImageStoryboard = CType(Me.Resources("ShowWeatherImageStoryboard"), Storyboard)
			hideWeatherImageStoryboard = CType(Me.Resources("HideWeatherImageStoryboard"), Storyboard)
		End Sub

		'<SnippetThreadingWeatherButtonHandler>
		Private Sub ForecastButtonHandler(ByVal sender As Object, ByVal e As RoutedEventArgs)
			' Change the status image and start the rotation animation.
			fetchButton.IsEnabled = False
			fetchButton.Content = "Contacting Server"
			weatherText.Text = ""
			hideWeatherImageStoryboard.Begin(Me)

			' Start fetching the weather forecast asynchronously.
			Dim fetcher As New NoArgDelegate(AddressOf Me.FetchWeatherFromServer)

			fetcher.BeginInvoke(Nothing, Nothing)
		End Sub
		'</SnippetThreadingWeatherButtonHandler>

		'<SnippetThreadingWeatherFetchWeather>
		Private Sub FetchWeatherFromServer()
			' Simulate the delay from network access.
			Thread.Sleep(4000)

			' Tried and true method for weather forecasting - random numbers.
			Dim rand As New Random()
			Dim weather As String

			If rand.Next(2) = 0 Then
				weather = "rainy"
			Else
				weather = "sunny"
			End If

			'<SnippetThreadingWeatherDispatcherOneArge>
			' Schedule the update function in the UI thread.
			tomorrowsWeather.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, New OneArgDelegate(AddressOf UpdateUserInterface), weather)
			'</SnippetThreadingWeatherDispatcherOneArge>
		End Sub
		'</SnippetThreadingWeatherFetchWeather>

		'<SnippetThreadingWeatherUpdateUI>
		Private Sub UpdateUserInterface(ByVal weather As String)
			'Set the weather image
			If weather = "sunny" Then
				weatherIndicatorImage.Source = CType(Me.Resources("SunnyImageSource"), ImageSource)
			ElseIf weather = "rainy" Then
				weatherIndicatorImage.Source = CType(Me.Resources("RainingImageSource"), ImageSource)
			End If

			'Stop clock animation
			showClockFaceStoryboard.Stop(Me)
			hideClockFaceStoryboard.Begin(Me)

			'Update UI text
			fetchButton.IsEnabled = True
			fetchButton.Content = "Fetch Forecast"
			weatherText.Text = weather
		End Sub
		'</SnippetThreadingWeatherUpdateUI>

		Private Sub HideClockFaceStoryboard_Completed(ByVal sender As Object, ByVal args As EventArgs)
			showWeatherImageStoryboard.Begin(Me)
		End Sub

		Private Sub HideWeatherImageStoryboard_Completed(ByVal sender As Object, ByVal args As EventArgs)
			showClockFaceStoryboard.Begin(Me, True)
		End Sub
	End Class
End Namespace
'</SnippetThreadingWeatherCodeBehind>
