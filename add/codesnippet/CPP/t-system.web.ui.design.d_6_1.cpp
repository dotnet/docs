   // Associates the DataMemberConverter with a string property.
public:
   [TypeConverterAttribute(DataMemberConverter::typeid)]
   property String^ dataMember 
   {
      String^ get()
      {
         return member;
      }
      void set( String^ value )
      {
         member = value;
      }
   }
private:
   String^ member;