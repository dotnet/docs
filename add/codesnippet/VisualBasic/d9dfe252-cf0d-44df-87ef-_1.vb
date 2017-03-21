    Public Shared Sub Constructor8() 

        ' Create a generic List of types and add the known types
        ' to the collection.
        Dim knownTypeList As New List(Of Type)
        knownTypeList.Add(GetType(PurchaseOrder))
        knownTypeList.Add(GetType(PurchaseOrderV3))

        ' Create an instance of a class that 
        ' implements the IDataContractSurrogate interface.
        ' The implementation code is not shown here.
        Dim mySurrogate As New DCSurrogate()

        Dim ser As New DataContractSerializer(GetType(Person), _
        "Customer", _
        "http://www.contoso.com", _
        knownTypeList, _
        64 * 1064, _
        True, _
        True, _
        mySurrogate)
    
        ' Other code not shown.
    End Sub 