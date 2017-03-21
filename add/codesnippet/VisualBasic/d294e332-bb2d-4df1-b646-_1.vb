    Public Shared Sub Constructor7() 
        ' Create an instance of the StreamingContext to hold
        ' context data.
        Dim sc As New StreamingContext()
        
        ' Create an XmlDictionary and add values to it.
        Dim d As New XmlDictionary()
        Dim name_value As XmlDictionaryString =d.Add("Customer")
        Dim ns_value As XmlDictionaryString = d.Add("http://www.contoso.com")
        
        ' Create an instance of a class that implements the 
        ' ISurrogateSelector interface. The implementation code
        ' is not shown here.
        Dim mySurrogateSelector As New MySelector()
        
        Dim ser As New System.Runtime.Serialization. _
          NetDataContractSerializer( _
          name_value, _
          ns_value, _
          sc, _
          65536, _
          True, _
          FormatterAssemblyStyle.Simple, _
          mySurrogateSelector)

        ' Other code not shown.    

    End Sub 