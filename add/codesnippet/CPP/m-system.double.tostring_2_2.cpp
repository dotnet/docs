   public ref class Temperature: public IFormattable
   {
      // IFormattable.ToString implementation.
   public:
      virtual String^ ToString( String^ format, IFormatProvider^ provider )
      {
         if ( format != nullptr )
         {
            if ( format->Equals( "F" ) )
            {
               return String::Format( "{0}'F", this->Value.ToString() );
            }

            if ( format->Equals( "C" ) )
            {
               return String::Format( "{0}'C", this->Celsius.ToString() );
            }
         }

         return m_value.ToString( format, provider );
      }

   protected:
      // The value holder
      double m_value;

   public:
      property double Value 
      {
         double get()
         {
            return m_value;
         }
         void set( double value )
         {
            m_value = value;
         }
      }

      property double Celsius 
      {
         double get()
         {
            return (m_value - 32.0) / 1.8;
         }
         void set( double value )
         {
            m_value = 1.8 * value + 32.0;
         }
      }
   };