'<SnippetPersonClass>

Imports Microsoft.VisualBasic
Imports System.ComponentModel

Namespace SDKSample
  ' This class implements INotifyPropertyChanged
  ' to support one-way and two-way bindings
  ' (such that the UI element updates when the source
  ' has been changed dynamically)
  Public Class Person
	  Implements INotifyPropertyChanged
	  Private name As String
	  ' Declare the event
	  Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

	  Public Sub New()
	  End Sub

	  Public Sub New(ByVal value As String)
		  Me.name = value
	  End Sub

	  Public Property PersonName() As String
		  Get
			  Return name
		  End Get
		  Set(ByVal value As String)
			  name = value
			  ' Call OnPropertyChanged whenever the property is updated
			  OnPropertyChanged("PersonName")
		  End Set
	  End Property

	  ' Create the OnPropertyChanged method to raise the event
	  Protected Sub OnPropertyChanged(ByVal name As String)
		  Dim handler As PropertyChangedEventHandler = PropertyChangedEvent
		  If handler IsNot Nothing Then
			  handler(Me, New PropertyChangedEventArgs(name))
		  End If
	  End Sub
  End Class
End Namespace
'</SnippetPersonClass>