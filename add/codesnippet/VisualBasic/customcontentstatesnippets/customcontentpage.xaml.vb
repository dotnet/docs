Imports Microsoft.VisualBasic
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes

Partial Public Class CustomContentPage
	Inherits Page
	Implements IProvideCustomContentState
	Private dateTime As Date = Date.Now

	Public Sub New()
		InitializeComponent()
		AddHandler Loaded, AddressOf CustomContentPage_Loaded
	End Sub

	Private Sub CustomContentPage_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
		Me.textBlockLabel.Text = Me.dateTime.ToString()
	End Sub

	Private Sub addBackEntryButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
		Me.NavigationService.AddBackEntry(New MyCustomContentState(Me.textBlockLabel.Text, Me.textBlockLabel))
		Me.dateTime = Date.Now
		Me.textBlockLabel.Text = Me.dateTime.ToString()
	End Sub

	#Region "IProvideCustomContentState Members"

	' Called when AddBackEntry(null) is called, and when a journal
	' navigation takes place (either via navigation chrome, or custom 
	' navigation buttons)
	Public Function GetContentState() As CustomContentState Implements IProvideCustomContentState.GetContentState
		Return New MyCustomContentState(Me.textBlockLabel.Text, Me.textBlockLabel)
	End Function

	#End Region
End Class