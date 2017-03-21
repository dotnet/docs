Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Navigation


Namespace Microsoft.Samples.Animation
	Partial Public Class SampleViewer
		Inherits Page
		Public Sub New()
			InitializeComponent()
			MyAnimatingSizeExampleFrame.Content = New AnimatingSizeExample()
			MyRotateAboutCenterExampleFrame.Content = New RotateAboutCenterExample()
		End Sub
	End Class

	Public Class ElapsedTimeControl
		Inherits Control
		Private theClock As Clock
		Private previousTime? As TimeSpan

		Public Sub New()
		End Sub

		Public Property Clock() As Clock
			Get
				Return theClock
			End Get
			Set(ByVal value As Clock)
				If theClock IsNot Nothing Then
					RemoveHandler theClock.CurrentTimeInvalidated, AddressOf onClockTimeInvalidated
				End If

				theClock = value

				If theClock IsNot Nothing Then
					AddHandler theClock.CurrentTimeInvalidated, AddressOf onClockTimeInvalidated
				End If
			End Set
		End Property

		Private Sub onClockTimeInvalidated(ByVal sender As Object, ByVal args As EventArgs)
			SetValue(CurrentTimeProperty, theClock.CurrentTime)
		End Sub

		Public Shared ReadOnly CurrentTimeProperty As DependencyProperty = DependencyProperty.Register("CurrentTime", GetType(TimeSpan?), GetType(ElapsedTimeControl), New FrameworkPropertyMetadata(CType(Nothing, TimeSpan?), New PropertyChangedCallback(AddressOf currentTime_Changed)))


		Private Shared Sub currentTime_Changed(ByVal d As DependencyObject, ByVal args As DependencyPropertyChangedEventArgs)
			'((ElapsedTimeControl)d).onCurrentTimeChanged(oldValue, newValue)
		End Sub

		Private Sub onCurrentTimeChanged(ByVal oldValue As Object, ByVal newValue As Object)
			If previousTime IsNot Nothing AndAlso (CType(previousTime, TimeSpan)).Milliseconds <> (CType(theClock.CurrentTime, TimeSpan)).Milliseconds Then
				SetValue(CurrentTimeAsStringProperty, theClock.CurrentTime.ToString())
				previousTime = CType(theClock.CurrentTime, TimeSpan)
			ElseIf previousTime Is Nothing Then
				SetValue(CurrentTimeAsStringProperty, theClock.CurrentTime.ToString())
				previousTime = CType(theClock.CurrentTime, TimeSpan)
			End If

		End Sub

		Public Shared ReadOnly CurrentTimeAsStringProperty As DependencyProperty = DependencyProperty.Register("CurrentTimeAsString", GetType(String), GetType(ElapsedTimeControl))
	End Class
End Namespace
