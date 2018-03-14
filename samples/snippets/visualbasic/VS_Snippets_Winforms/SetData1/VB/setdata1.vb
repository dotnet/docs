Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Drawing
Imports Microsoft.VisualBasic

Public Class Form1
   Inherits Form

   Public Sub New()
      SetData1()
   End Sub
' <snippet1>
Private Sub SetData1()
   ' Creates a component to store in the data object.
   Dim myComponent As New System.ComponentModel.Component()
   
   ' Creates a data object.
   Dim myDataObject As New DataObject()
   
   ' Adds the component to the data object.
   myDataObject.SetData(myComponent)
   
   ' Checks whether data of the specified type is in the data object.
   Dim myType As Type = myComponent.GetType()
   Dim myMessageText As String
   If myDataObject.GetDataPresent(myType) Then
      myMessageText = "Data of type " + myType.Name + " is present in the data object"
   Else
      myMessageText = "Data of type " + myType.Name + " is not present in the data object"
   End If

   ' Displays the result in a message box.
   MessageBox.Show(myMessageText, "The Test Result")
End Sub 'SetData1
' </snippet1>
    Public Shared Sub Main()
       System.Windows.Forms.Application.Run(New Form1())
    End Sub

End Class

