    Public Shared Function CreateCustomBinding() As Binding 
        ' Create an empty BindingElementCollection to populate, 
        ' then create a custom binding from it.
        Dim outputBec As New BindingElementCollection()
        
        ' Create a SymmetricSecurityBindingElement.
        Dim ssbe As New SymmetricSecurityBindingElement()
        
        ' Set the algorithm suite to one that uses 128-bit keys.
        ssbe.DefaultAlgorithmSuite = SecurityAlgorithmSuite.Basic128
        
        ' Set MessageProtectionOrder to SignBeforeEncrypt.
        ssbe.MessageProtectionOrder = MessageProtectionOrder.SignBeforeEncrypt
        
        ' Use a Kerberos token as the protection token.
        ssbe.ProtectionTokenParameters = New KerberosSecurityTokenParameters()
        
        ' Add the SymmetricSecurityBindingElement to the BindingElementCollection.
        outputBec.Add(ssbe)
        outputBec.Add(New TextMessageEncodingBindingElement())
        outputBec.Add(New HttpTransportBindingElement())
        
        ' Create a CustomBinding and return it; otherwise, return null.
        Return New CustomBinding(outputBec)
    
    End Function 