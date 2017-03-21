   ' Associates the DataBindingCollectionConverter 
   ' with a DataBindingCollection property.   
   <TypeConverterAttribute(GetType(DataBindingCollectionConverter))>  _
   Public Property dataBindings() As DataBindingCollection
      Get
         Return bindings
      End Get
      Set
         bindings = value
      End Set
   End Property
   Private bindings As DataBindingCollection