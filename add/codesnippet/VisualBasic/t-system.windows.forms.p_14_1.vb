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
