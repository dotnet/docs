   ' Associates the DataFieldConverter with a string property.   
   <TypeConverterAttribute(GetType(DataMemberConverter))>  _
   Public Property dataField() As String
      Get
         Return field
      End Get
      Set
         field = value
      End Set
   End Property
   Private field As String