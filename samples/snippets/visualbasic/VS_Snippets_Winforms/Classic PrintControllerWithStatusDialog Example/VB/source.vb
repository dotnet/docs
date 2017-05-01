Imports System
Imports System.IO
Imports System.Data
Imports System.Drawing.Printing
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    Protected useMyPrintController As Boolean
    Protected wantsStatusDialog As Boolean
    Protected myDocumentPrinter As PrintDocument    
    
' <Snippet1>
 Sub myPrint()
     If useMyPrintController = True Then
         myDocumentPrinter.PrintController = New myControllerImplementation()
         If wantsStatusDialog = True Then
             myDocumentPrinter.PrintController = _
                New PrintControllerWithStatusDialog(myDocumentPrinter.PrintController)
         End If
     End If
     myDocumentPrinter.Print()
 End Sub

' </Snippet1>
End Class

Public Class myControllerImplementation
    Inherits PrintController
End Class
