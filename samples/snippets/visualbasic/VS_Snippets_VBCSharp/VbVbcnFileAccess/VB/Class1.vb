'********************************************************************
Imports System.Windows.Forms

Public Class Class1

  Sub Test()
    Dim ListBox1 As New System.Windows.Forms.listbox

    '********************************************************************
    '<Snippet1>
        For Each foundDirectory As String In
               My.Computer.FileSystem.GetDirectories(
                   My.Computer.FileSystem.SpecialDirectories.MyDocuments,
                   FileIO.SearchOption.SearchTopLevelOnly,
                   "*Logs*")

            ListBox1.Items.Add(foundDirectory)
        Next
    '</Snippet1>
  End Sub

End Class
