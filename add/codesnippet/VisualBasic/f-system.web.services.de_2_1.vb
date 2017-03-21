            Dim myDescription As ServiceDescription = _
               ServiceDescription.Read("MyWsdl_VB.wsdl")
            Console.WriteLine("Namespace: " & ServiceDescription.Namespace)