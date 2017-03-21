    Public Shared Sub Constructor4() 
        ' Create an XmlDictionary and add values to it.
        Dim d As New XmlDictionary()
        Dim name_value As XmlDictionaryString =d.Add("Customer")
        Dim ns_value As XmlDictionaryString = d.Add("http://www.contoso.com")
        
        ' Create the serializer.
        Dim ser As New System.Runtime.Serialization. _
           NetDataContractSerializer(name_value, ns_value)
   
        ' Other code not shown.
    
    End Sub 