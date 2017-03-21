   public ref class Temperature: public IComparable
   {
   protected:

      /// <summary>
      /// IComparable.CompareTo implementation.
      /// </summary>
      // The value holder
      short m_value;

   public:
      virtual Int32 CompareTo( Object^ obj )
      {
         if ( obj->GetType() == Temperature::typeid )
         {
            Temperature^ temp = dynamic_cast<Temperature^>(obj);
            return m_value.CompareTo( temp->m_value );
         }

         throw gcnew ArgumentException(  "object is not a Temperature" );
      }


      property short Value 
      {
         short get()
         {
            return m_value;
         }

         void set( short value )
         {
            m_value = value;
         }

      }

      property short Celsius 
      {
         short get()
         {
            return (short)((m_value - 32) / 2);
         }

         void set( short value )
         {
            m_value = (value * 2 + 32);
         }

      }

   };

}