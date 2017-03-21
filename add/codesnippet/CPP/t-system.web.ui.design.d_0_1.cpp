   // Associates the DataFieldConverter with a string property.
public:
   [TypeConverterAttribute(DataMemberConverter::typeid)]
   property String^ dataField 
   {
      String^ get()
      {
         return field;
      }
      void set( String^ value )
      {
         field = value;
      }
   }
private:
   String^ field;