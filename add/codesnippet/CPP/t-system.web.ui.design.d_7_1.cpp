   // Associates the DataBindingCollectionConverter
   // with a DataBindingCollection property.
public:
   [TypeConverterAttribute(DataBindingCollectionConverter::typeid)]
   property DataBindingCollection^ dataBindings 
   {
      DataBindingCollection^ get()
      {
         return bindings;
      }
      void set( DataBindingCollection^ value )
      {
         bindings = value;
      }
   }
private:
   DataBindingCollection^ bindings;