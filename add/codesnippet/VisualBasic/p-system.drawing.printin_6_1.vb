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
