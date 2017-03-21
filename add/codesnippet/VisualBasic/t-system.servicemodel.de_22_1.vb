    Private Sub PrintDescription(ByVal sh As ServiceHost) 
        ' Declare variables.
        Dim i, j, k, l, c As Integer
        Dim servDesc As ServiceDescription = sh.Description
        Dim opDesc As OperationDescription
        Dim contractDesc As ContractDescription
        Dim methDesc As MessageDescription
        Dim mBodyDesc As MessageBodyDescription
        Dim partDesc As MessagePartDescription
        Dim servBeh As IServiceBehavior
        Dim servEP As ServiceEndpoint
        
        ' Print the behaviors of the service.
        Console.WriteLine("Behaviors:")
        For c = 0 To servDesc.Behaviors.Count-1
            servBeh = servDesc.Behaviors(c)
            Console.WriteLine(vbTab + "{0}", servBeh)
        Next c
        
        ' Print the endpoint descriptions of the service.
        Console.WriteLine("Endpoints")
        For i = 0 To servDesc.Endpoints.Count-1
            ' Print the endpoint names.
            servEP = servDesc.Endpoints(i)
            Console.WriteLine(vbTab + "Name: {0}", servEP.Name)
            contractDesc = servEP.Contract
            
            Console.WriteLine(vbTab + "Operations:")
            For j = 0 To contractDesc.Operations.Count-1
                ' Print operation names.
                opDesc = servEP.Contract.Operations(j)
                Console.WriteLine(vbTab + vbTab + "{0}", opDesc.Name)
                Console.WriteLine(vbTab + vbTab + "Actions:")
                For k = 0 To opDesc.Messages.Count-1
                    ' Print the message action. 
                    methDesc = opDesc.Messages(k)
                    Console.WriteLine(vbTab + vbTab + vbTab + _
                      "Action:{0}", methDesc.Action)
                    
                    ' Check for the existence of a body, then the body description.
                    mBodyDesc = methDesc.Body
                    If mBodyDesc.Parts.Count > 0 Then
                        For l = 0 To methDesc.Body.Parts.Count-1
                            partDesc = methDesc.Body.Parts(l)
                            Console.WriteLine(vbTab + vbTab + _
                            vbTab + vbTab + "{0}", partDesc.Name)
                        Next l
                    End If
                Next k
            Next j
        Next i
    
    End Sub     