Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic

Public Class Sample
' <Snippet1>
Public Sub CreateDataView(table As DataTable) 
    Dim view As DataView = New DataView(table, "", _
        "ContactName", DataViewRowState.CurrentRows)

    AddHandler view.ListChanged, _
        New System.ComponentModel.ListChangedEventHandler( _
        AddressOf OnListChanged)
End Sub

Private Sub OnListChanged(sender as Object, _
    args As System.ComponentModel.ListChangedEventArgs)

    Console.WriteLine("ListChanged:")
    Console.WriteLine(vbTab & "    Type = " & args.ListChangedType)
    Console.WriteLine(vbTab & "OldIndex = " & args.OldIndex)
    Console.WriteLine(vbTab & "NewIndex = " & args.NewIndex)
End Sub
' </Snippet1>
End Class