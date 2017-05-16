Imports Microsoft.VisualBasic
Imports System
Imports System.Windows
Imports System.Windows.Media
Imports System.Windows.Media.Animation

Namespace Microsoft.Samples.PerFrameAnimations

	Public Class TimeTracker
		#Region "Private Memebers"

		Private _lastTime As Date
		Private _deltaTime As Double
		Private _timerInterval As Double = -1
		#End Region

		#Region "Properties"

		Public Property TimerInterval() As Double
			Get
				Return _timerInterval
			End Get
			Set(ByVal value As Double)
				_timerInterval = value
			End Set
		End Property

		Public ReadOnly Property ElapsedTime() As Date
			Get
				Return _lastTime
			End Get
		End Property

		Public ReadOnly Property DeltaSeconds() As Double
			Get
				Return _deltaTime
			End Get
		End Property

		#End Region

		#Region "Events"
		Public Event TimerFired As EventHandler
		#End Region

		#Region "Constructors"
		Public Sub New()

			_lastTime = Date.Now
		End Sub
		#End Region

		Public Function Update() As Double


			Dim currentTime As Date = Date.Now


			'get the difference in time
			Dim diffTime As TimeSpan = currentTime.Subtract(_lastTime)
			_deltaTime = diffTime.TotalSeconds



				'does the user want a callback on regular intervals?
				If _timerInterval > 0.0 Then

                If currentTime <> _lastTime Then
                    RaiseEvent TimerFired(Me, Nothing)
                End If

				End If


			'cycle old time
			_lastTime = currentTime

			Return _deltaTime
		End Function
	End Class

End Namespace