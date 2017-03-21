    Public Shared Sub Constructor6() 
        ' Create an instance of the StreamingContext to hold
        ' context data.
        Dim sc As New StreamingContext()
        
        ' Create an instance of a class that implements the 
        ' ISurrogateSelector interface. The implementation code
        ' is not shown here.
        Dim mySurrogateSelector As New MySelector()
        
        Dim ser As New System.Runtime.Serialization. _
          NetDataContractSerializer( _
          "Customer", _
          "http://www.contoso.com", _
          sc, _
          65536, _
          True, _
          FormatterAssemblyStyle.Simple, _
          mySurrogateSelector)

        ' Other code not shown.            
    
    End Sub 