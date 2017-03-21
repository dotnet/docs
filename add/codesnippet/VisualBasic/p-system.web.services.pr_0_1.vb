    Public Overrides Sub ProcessMessage(message As SoapMessage)
        Select Case message.Stage
            
            Case SoapMessageStage.BeforeSerialize
            
            Case SoapMessageStage.AfterSerialize
                WriteOutput(message)
            
            Case SoapMessageStage.BeforeDeserialize
                WriteInput(message)
            
            Case SoapMessageStage.AfterDeserialize
            
        End Select
    End Sub    
    