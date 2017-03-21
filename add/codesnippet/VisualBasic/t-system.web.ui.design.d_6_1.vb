   ' Associates the DataMemberConverter with a string property.   
   <TypeConverterAttribute(GetType(DataMemberConverter))>  _
   Public Property dataMember() As String
      Get
         Return member
      End Get
      Set
         member = value
      End Set
   End Property
   Private member As String