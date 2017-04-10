Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms



Public Class Form1
    Inherits Form

Shared Sub Main()

End Sub
    Protected dataGrid1 As DataGrid
    
    ' <Snippet1>
    Private Sub BindToDataView(myGrid As DataGrid)
        ' Create a DataView using the DataTable.
        Dim myTable As New DataTable("Suppliers")
        ' Insert code to create and populate columns.
        Dim myDatatView As New DataView(myTable)
        myGrid.DataSource = myDatatView
    End Sub 'BindToDataView
    
    Private Sub BindToDataSet(myGrid As DataGrid)
        ' Create a DataSet.
        Dim myDataSet As New DataSet("myDataSet")
        ' Insert code to populate DataSet with several tables.
        myGrid.DataSource = myDataSet
        ' Use the DataMember property to specify the DataTable.
        myGrid.DataMember = "Suppliers"
    End Sub 'BindToDataSet
    
    Private Function GetDataViewFromDataSource() As DataView
        ' Create a DataTable variable, and set it to the DataSource.
        Dim myDatatView As DataView
        myDatatView = CType(dataGrid1.DataSource, DataView)
        Return myDatatView
    End Function 'GetDataViewFromDataSource
    
    Private Function GetDataSetFromDataSource() As DataSet
        ' Create a DataSet variable, and set it to the DataSource.
        Dim myDataSet As DataSet
        myDataSet = CType(dataGrid1.DataSource, DataSet)
        Return myDataSet
    End Function 'GetDataSetFromDataSource
    ' </Snippet1>
End Class 'Form1 

