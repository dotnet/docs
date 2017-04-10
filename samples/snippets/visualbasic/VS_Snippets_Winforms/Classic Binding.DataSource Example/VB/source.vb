Imports System
Imports System.Data
Imports System.Windows.Forms

Public Class Form1
	Inherits Form

	Protected text1 As TextBox
	' <Snippet1>
	Private Sub GetDataSource
		Dim ds As DataSet = CType(text1.DataBindings(0).DataSource, DataSet)
		Console.WriteLine(ds.Tables(0).TableName)
	End Sub
    ' </Snippet1>
End Class
