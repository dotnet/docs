   // Associates the DataSourceConverter with an object property.
public:
   [TypeConverterAttribute(DataSourceConverter::typeid)]
   property Object^ dataSource 
   {
      Object^ get()
      {
         return source;
      }
      void set( Object^ value )
      {
         source = value;
      }
   }
private:
   Object^ source;