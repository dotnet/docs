Imports System.Globalization
Imports System.ComponentModel
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Data
Imports System.Windows.Media

Namespace SDKSample
	Public Class MyData
		Implements INotifyPropertyChanged
		Private _thedate As Date

		Public Sub New()
			_thedate = Date.Now
		End Sub

		Public Property TheDate() As Date
			Get
				Return _thedate
			End Get
			Set(ByVal value As Date)
                If _thedate <> value Then
                    _thedate = value
                    OnPropertyChanged("TheDate")
                End If
			End Set
		End Property

		' Declare event
		Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

		' OnPropertyChanged event handler to update property value in binding
		Private Sub OnPropertyChanged(ByVal info As String)
			RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(info))
		End Sub
	End Class
End Namespace