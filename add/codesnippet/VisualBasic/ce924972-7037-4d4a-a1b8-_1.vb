    Public Shared Sub Constructor6() 
        ' Create a generic List of types and add the known types
        ' to the collection.
        Dim knownTypeList As New List(Of Type)
        knownTypeList.Add(GetType(PurchaseOrder))
        knownTypeList.Add(GetType(PurchaseOrderV3))

        ' Create an XmlDictionary and add values to it.
        Dim d As New XmlDictionary()
        Dim name_value As XmlDictionaryString = d.Add("Customer")
        Dim ns_value As XmlDictionaryString = d.Add("http://www.contoso.com")
        
        Dim ser As New DataContractSerializer(GetType(Person), _
        name_value, _
        ns_value, _
        knownTypeList)
    
        ' Other code not shown.
     End Sub 