   // The Temperature class stores the temperature as a Double
   // and delegates most of the functionality to the Double 
   // implementation.
   public ref class Temperature: public IComparable, public IFormattable
   {
      // IComparable.CompareTo implementation.
   public:
      virtual int CompareTo( Object^ obj )
      {
         if (obj == nullptr) return 1;
         
         if (dynamic_cast<Temperature^>(obj) )
         {
            Temperature^ temp = (Temperature^)(obj);
            return m_value.CompareTo( temp->m_value );
         }
         throw gcnew ArgumentException( "object is not a Temperature" );
      }

      // IFormattable.ToString implementation.
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

      // Parses the temperature from a string in the form
      // [ws][sign]digits['F|'C][ws]
      static Temperature^ Parse( String^ s, NumberStyles styles, IFormatProvider^ provider )
      {
         Temperature^ temp = gcnew Temperature;

         if ( s->TrimEnd(nullptr)->EndsWith( "'F" ) )
         {
            temp->Value = Double::Parse( s->Remove( s->LastIndexOf( '\'' ), 2 ), styles, provider );
         }
         else
         if ( s->TrimEnd(nullptr)->EndsWith( "'C" ) )
         {
            temp->Celsius = Double::Parse( s->Remove( s->LastIndexOf( '\'' ), 2 ), styles, provider );
         }
         else
         {
            temp->Value = Double::Parse( s, styles, provider );
         }
         return temp;
      }

   protected:
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