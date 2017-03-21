    Private Sub DataContractBehavior() 
        Dim b As New WSHttpBinding(SecurityMode.Message)
        Dim baseAddress As New Uri("http://localhost:1066/calculator")
        Dim sh As New ServiceHost(GetType(Calculator), baseAddress)
        sh.AddServiceEndpoint(GetType(ICalculator), b, "")
        
        ' Find the ContractDescription of the operation to find.
        Dim cd As ContractDescription = sh.Description.Endpoints(0).Contract
        Dim myOperationDescription As OperationDescription = cd.Operations.Find("Add")
        
        ' Find the serializer behavior.
        Dim serializerBehavior As DataContractSerializerOperationBehavior = _
        myOperationDescription.Behaviors.Find _
        (Of DataContractSerializerOperationBehavior)()
        
        ' If the serializer is not found, create one and add it.
        If serializerBehavior Is Nothing Then
            serializerBehavior = New DataContractSerializerOperationBehavior(myOperationDescription)
            myOperationDescription.Behaviors.Add(serializerBehavior)
        End If
        
        ' Change settings of the behavior.
        serializerBehavior.MaxItemsInObjectGraph = 10000
        serializerBehavior.IgnoreExtensionDataObject = True
        
        sh.Open()
        Console.WriteLine("Listening")
        Console.ReadLine()
    
    End Sub 