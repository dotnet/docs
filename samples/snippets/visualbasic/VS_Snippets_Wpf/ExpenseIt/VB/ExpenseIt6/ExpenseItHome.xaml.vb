Imports System.Text

Namespace ExpenseIt
	''' <summary>
	''' Interaction logic for ExpenseItHome.xaml
	''' </summary>
	Partial Public Class ExpenseItHome
		Inherits Page
		Public Sub New()
			InitializeComponent()
		End Sub

		'<Snippet16>
		Private Sub Button_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			' View Expense Report
			Dim expenseReportPage As New ExpenseReportPage()
			Me.NavigationService.Navigate(expenseReportPage)

		End Sub
		'</Snippet16>
	End Class
End Namespace
