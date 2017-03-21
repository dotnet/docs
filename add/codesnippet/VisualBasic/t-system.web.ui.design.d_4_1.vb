   ' Associates the DataSourceConverter with an object property.   
   <TypeConverterAttribute(GetType(DataSourceConverter))>  _
   Public Property dataSource() As Object
      Get
         Return [source]
      End Get
      Set
         [source] = value
      End Set
   End Property
   Private [source] As Object