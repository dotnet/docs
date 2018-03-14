' System.Windows.Forms.DataFormats.Dif
' The following example demonstrates the 'Dif' field of 'DataFormats' class.
' It  creates a 'FileStream' object of the Temp.dif file.
' It stores the object in the form of the 'Dif' format in the 'DataObject'. 
' Then it checks whether the data stored in 'Dif' format is present or not.

Imports System
Imports System.Data
Imports System.Windows.Forms
Imports System.IO
Imports Microsoft.VisualBasic

Public Class DataFormats_Dif
   
   Public Shared Sub Main()
      Try
' <Snippet1>
         Dim myFileStream As FileStream = File.Open("Temp.dif", FileMode.Open)
         ' Store the data into Dif format.
         Dim myDataObject As New DataObject()
         myDataObject.SetData(DataFormats.Dif, myFileStream)
         
         ' Check whether the data is stored or not in the specified format.
         Dim formatPresent As Boolean = myDataObject.GetDataPresent(DataFormats.Dif)
         If formatPresent Then
            Console.WriteLine(("The data has been stored in the Dif format is:'" + formatPresent.ToString() + "'"))
         Else
            Console.WriteLine("The data has not been stored in the specified format")
         End If
' </Snippet1>
      Catch e As Exception
         Console.WriteLine(("The Exception is:" + e.Message))
      End Try
   End Sub 'Main
End Class 'DataFormats_Dif