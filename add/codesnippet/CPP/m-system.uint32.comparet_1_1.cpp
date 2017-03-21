   public ref class Temperature: public IComparable
   {
   public:
      /// <summary>
      /// IComparable.CompareTo implementation.
      /// </summary>
      virtual int CompareTo( Object^ obj )
      {
         if ( (Temperature^)( obj ) )
         {
            Temperature^ temp = (Temperature^)( obj );

            return m_value.CompareTo( temp->m_value );
         }

         throw gcnew ArgumentException( "object is not a Temperature" );
      }

   protected:
      // The value holder
      UInt32 m_value;

   public:
      property UInt32 Value 
      {
         UInt32 get()
         {
            return m_value;
         }
         void set( UInt32 value )
         {
            m_value = value;
         }
      }
   };
}