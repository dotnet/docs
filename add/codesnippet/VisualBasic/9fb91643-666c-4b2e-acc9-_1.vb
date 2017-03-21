    Public Shared Sub Constructor5() 

        ' Create a generic List of types and add the known types
        ' to the collection.
        Dim knownTypeList As New List(Of Type)
        knownTypeList.Add(GetType(PurchaseOrder))
        knownTypeList.Add(GetType(PurchaseOrderV3))
        
        Dim ser As New DataContractSerializer(GetType(Person), _
        "Customer", _
        "http://www.contoso.com", _
        knownTypeList)

        ' Other code not shown.

    End Sub 