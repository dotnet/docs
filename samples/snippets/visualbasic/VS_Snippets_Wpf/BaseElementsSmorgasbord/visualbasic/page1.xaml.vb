Imports Microsoft.VisualBasic
Imports System
Imports System.Windows
Imports System.ComponentModel
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Media
Imports System.Windows.Navigation
Imports System.Windows.Shapes

Namespace Foo
	''' <summary>
	''' Interaction logic for Page1.xaml
	''' </summary>

	Partial Public Class Page1
		Inherits Page
		Private myDataObject As MyData
		'<SnippetBringIntoViewRectCode>
		Private Sub GoToLake(ByVal sender As Object, ByVal e As RoutedEventArgs)
			mapframe.BringIntoView(New Rect(800, 400, 200, 200))
		End Sub
		'</SnippetBringIntoViewRectCode>

		Private Sub BuildAndAdd(ByVal sender As Object, ByVal e As EventArgs)
			'<SnippetSetBindingPath>
			myDataObject = New MyData(Date.Now)
			root.DataContext = myDataObject
			myText.SetBinding(TextBlock.TextProperty, "MyDataProperty")
			'</SnippetSetBindingPath>
		End Sub
		'<SnippetFETryFindResource>
		Private Sub TryFind(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Dim b As Button = TryCast(e.Source, Button)
			b.Background = CType(b.TryFindResource("customBrush"), Brush)
		End Sub
		'</SnippetFETryFindResource>

	End Class

	 Public Class MyData
		 Implements INotifyPropertyChanged
		Private _myDataProperty As String

		Public Sub New(ByVal adate As Date)
		   _myDataProperty = "Last bound time was " & adate.ToLongTimeString()
		End Sub

		Public Property MyDataProperty() As String
			Get
				Return _myDataProperty
			End Get
			Set(ByVal value As String)
				_myDataProperty = value
				OnPropertyChanged("MyDataProperty")
			End Set
		End Property

		' Declare event
		Public Event PropertyChanged As System.ComponentModel.PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
		' OnPropertyChanged event handler to update property value in binding
		Private Sub OnPropertyChanged(ByVal info As String)
		RaiseEvent PropertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs(info))
		End Sub
	 End Class
End Namespace