Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Drawing

Public Class Form1
   Inherits Form

   Public Sub New()
      SetData2()
   End Sub
' <snippet1>
Private Sub SetData2()
   ' Creates a data object.
   Dim myDataObject As New DataObject()
   
   ' Stores a string, specifying the UnicodeText format.
   myDataObject.SetData(DataFormats.UnicodeText, "Hello World!")
   
   ' Retrieves the data by specifying the Text format.
   Dim myMessageText As String = "The data type is " & _
             myDataObject.GetData(DataFormats.Text).GetType().Name
   
   ' Displays the result.
   MessageBox.Show(myMessageText, "The Test Result")
End Sub 'SetData2
' </snippet1>
    Public Shared Sub Main()
       System.Windows.Forms.Application.Run(New Form1())
    End Sub

End Class


