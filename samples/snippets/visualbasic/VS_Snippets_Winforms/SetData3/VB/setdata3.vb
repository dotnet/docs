Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Drawing

Public Class Form1
   Inherits Form

   Public Sub New()
      SetData3()
   End Sub
' <snippet1>
Private Sub SetData3()
   ' Creates a component.
   Dim myComponent As New System.ComponentModel.Component()
   
   ' Gets the type of the component.
   Dim myType As Type = myComponent.GetType()
   
   ' Creates a data object.
   Dim myDataObject As New DataObject()
   
   ' Stores the component in the data object.
   myDataObject.SetData(myType, myComponent)
   
   ' Checks whether data of the specified type is in the data object.
   Dim myMessageText As String
   If myDataObject.GetDataPresent(myType) Then
      myMessageText = "Data of type " & myType.Name & " is stored in the data object"
   Else
      myMessageText = "No data of type " & myType.Name & " is stored in the data object"
   End If
   
   ' Displays the result.
   MessageBox.Show(myMessageText, "The Test Result")
End Sub 'SetData3
' </snippet1>
    Public Shared Sub Main()
       System.Windows.Forms.Application.Run(New Form1())
    End Sub

End Class


