    Public Shared Sub Constructor4() 
        ' Create an instance of the DataContractSerializer
        ' specifying the type, and name and 
        ' namespace as XmlDictionaryString objects.
        ' Create an XmlDictionary and add values to it.
        Dim d As New XmlDictionary()
        Dim name_value As XmlDictionaryString = d.Add("Customer")
        Dim ns_value As XmlDictionaryString = d.Add("http://www.contoso.com")
        
        ' Create the serializer.
        Dim ser As New DataContractSerializer(GetType(Person), _
        name_value, _
        ns_value)

        ' Other code not shown.
    End Sub 