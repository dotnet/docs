Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Shapes
Imports System.Collections.ObjectModel


Namespace SDKSample
	''' <summary>
	''' Interaction logic for Window1.xaml
	''' </summary>

	Partial Public Class Window1
		Inherits Window

        Private Sub OnLoad(ByVal sender As Object, ByVal e As RoutedEventArgs)
            '<SnippetListViewView>
            Dim myListView As New ListView()
            '<SnippetGridViewColumn>

            '<SnippetGridViewAllowsColumnReorder>
            Dim myGridView As New GridView()
            myGridView.AllowsColumnReorder = True
            myGridView.ColumnHeaderToolTip = "Employee Information"
            '</SnippetGridViewAllowsColumnReorder>

            '<SnippetGridViewColumnProperties>
            Dim gvc1 As New GridViewColumn()
            gvc1.DisplayMemberBinding = New Binding("FirstName")
            gvc1.Header = "FirstName"
            gvc1.Width = 100
            '</SnippetGridViewColumnProperties>
            myGridView.Columns.Add(gvc1)
            Dim gvc2 As New GridViewColumn()
            gvc2.DisplayMemberBinding = New Binding("LastName")
            gvc2.Header = "Last Name"
            gvc2.Width = 100
            myGridView.Columns.Add(gvc2)
            '<SnippetAddToColumns>
            Dim gvc3 As New GridViewColumn()
            gvc3.DisplayMemberBinding = New Binding("EmployeeNumber")
            gvc3.Header = "Employee No."
            gvc3.Width = 100
            myGridView.Columns.Add(gvc3)
            '</SnippetAddToColumns>

            '</SnippetGridViewColumn>
            'ItemsSource is ObservableCollection of EmployeeInfo objects
            myListView.ItemsSource = New myEmployees()
            myListView.View = myGridView
            myStackPanel.Children.Add(myListView)
            '</SnippetListViewView>
        End Sub

        Private Sub LastNameCM_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            ' handle ascending/descending last name context menu choices
        End Sub
    End Class

	Public Class EmployeeInfo
		Private _firstName As String
		Private _lastName As String
		Private _employeeNumber As String

		Public Property FirstName() As String
			Get
				Return _firstName
			End Get
			Set(ByVal value As String)
				_firstName = value
			End Set
		End Property

		Public Property LastName() As String
			Get
				Return _lastName
			End Get
			Set(ByVal value As String)
				_lastName = value
			End Set
		End Property

		Public Property EmployeeNumber() As String
			Get
				Return _employeeNumber
			End Get
			Set(ByVal value As String)
				_employeeNumber = value
			End Set
		End Property

		Public Sub New(ByVal firstname As String, ByVal lastname As String, ByVal empnumber As String)
			_firstName = firstname
			_lastName = lastname
			_employeeNumber = empnumber
		End Sub
	End Class
	Public Class myEmployees
		Inherits ObservableCollection(Of EmployeeInfo)
		Public Sub New()
			Add(New EmployeeInfo("Jesper", "Aaberg", "12345"))
			Add(New EmployeeInfo("Dominik", "Paiha", "98765"))
			Add(New EmployeeInfo("Yale", "Li", "23875"))
			Add(New EmployeeInfo("Muru", "Subramani", "49392"))
		End Sub
	End Class
End Namespace