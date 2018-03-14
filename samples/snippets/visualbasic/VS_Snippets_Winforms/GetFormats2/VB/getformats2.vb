Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Drawing
Imports Microsoft.VisualBasic

Public Class Form1
   Inherits Form
' <snippet1>
Private Sub GetFormats2()
   ' Creates a new data object using a string and the UnicodeText format.
   Dim myDataObject As New DataObject(DataFormats.UnicodeText, "My text string")
   
   ' Gets the original data formats in the data object by setting the automatic
   ' conversion parameter to false.
   Dim myFormatsArray As [String]() = myDataObject.GetFormats(False)
   
   ' Stores the results in a string.
   Dim theResult As String = "The original format associated with the data is:" & vbCr
   Dim i As Integer
   For i = 0 To myFormatsArray.Length - 1
      theResult += myFormatsArray(i) + vbCr
   Next i 
   ' Gets all data formats and data conversion formats for the data object.
   myFormatsArray = myDataObject.GetFormats(True)
   
   ' Stores the results in the string.
   theResult += vbCr + "The data format(s) and conversion format(s) associated with " & _
     "the data are:" & vbCr
   For i = 0 To myFormatsArray.Length - 1
      theResult += myFormatsArray(i) + vbCr
   Next i
   ' Displays the results.
   MessageBox.Show(theResult)
End Sub 'GetFormats2
' </snippet1>
    Public Shared Sub Main()
       System.Windows.Forms.Application.Run(New Form1())
    End Sub

End Class

