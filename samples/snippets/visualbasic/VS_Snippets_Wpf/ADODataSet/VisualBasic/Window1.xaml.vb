Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports System.Globalization
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents


Namespace SDKSample
  ''' <summary>
  ''' Interaction logic for Window1.xaml
  ''' </summary>

  Partial Public Class Window1
	  Inherits Window
	  Public Sub New()
		  Me.InitializeComponent()
	  End Sub

	  Private appPath As String
	  Private ReadOnly Property AppDataPath() As String
		  Get
			  If String.IsNullOrEmpty(appPath) Then
				  appPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
			  End If
			  Return appPath
		  End Get
	  End Property

	'<Snippet1>
	Private myDataSet As DataSet

	Private Sub OnInit(ByVal sender As Object, ByVal e As EventArgs)
	  Dim mdbFile As String = Path.Combine(AppDataPath, "BookData.mdb")
	  Dim connString As String = String.Format("Provider=Microsoft.Jet.OLEDB.4.0; Data Source={0}", mdbFile)
	  Dim conn As New OleDbConnection(connString)
	  Dim adapter As New OleDbDataAdapter("SELECT * FROM BookTable;", conn)

	  myDataSet = New DataSet()
	  adapter.Fill(myDataSet, "BookTable")

	  ' myListBox is a ListBox control.
	  ' Set the DataContext of the ListBox to myDataSet
	  myListBox.DataContext = myDataSet
	End Sub
	'</Snippet1>

	Private Sub OnClick(ByVal sender As Object, ByVal e As RoutedEventArgs)
	  Dim myDataTable As DataTable = myDataSet.Tables("BookTable")
	  Dim row As DataRow = myDataTable.NewRow()

	  row("Title") = "Microsoft C# Language Specifications"
	  row("ISBN") = "0-7356-1448-2"
	  row("NumPages") = 431
	  myDataTable.Rows.Add(row)
	End Sub
  End Class
End Namespace
