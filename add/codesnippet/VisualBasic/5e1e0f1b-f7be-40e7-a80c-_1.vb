    Public Shared Sub Constructor2() 

        ' Create a generic List of types and add the known types
        ' to the collection.
        Dim knownTypeList As New List(Of Type)
        knownTypeList.Add(GetType(PurchaseOrder))
        knownTypeList.Add(GetType(PurchaseOrderV3))
        
        ' Create a DatatContractSerializer with the collection.
        Dim ser2 As New DataContractSerializer(GetType(Orders), knownTypeList)

        ' Other code not shown.
   End Sub 