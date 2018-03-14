Imports System
Imports System.Data
Imports System.Drawing.Printing
Imports System.ComponentModel
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected useMyPrintController As Boolean
    Protected wantsStatusDialog As Boolean
    Protected myPrintDocument As PrintDocument    
    
' <Snippet1>
 Public Sub myPrint()
     If useMyPrintController = True Then
         myPrintDocument.PrintController = New myControllerImplementation()
         If wantsStatusDialog = True Then
             myPrintDocument.PrintController = _
                New PrintControllerWithStatusDialog( _
                myPrintDocument.PrintController)
         End If
     End If
     myPrintDocument.Print()
 End Sub

' </Snippet1>
End Class

Public Class myControllerImplementation
    Inherits PrintController
End Class
