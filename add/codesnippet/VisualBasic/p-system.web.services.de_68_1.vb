         Dim myInputOperationMessage As OperationMessage = _
            CType(New OperationInput(), OperationMessage)
         Dim myXmlQualifiedName As New XmlQualifiedName("AddSoapIn", _
            myDescription.TargetNamespace)
         myInputOperationMessage.Message = myXmlQualifiedName