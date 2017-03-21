   public ref class Temperature
   {
      // Parses the temperature from a string in form
      // [ws][sign]digits['F|'C][ws]
   public:
      static Temperature^ Parse( String^ s )
      {
         Temperature^ temp = gcnew Temperature;
         if ( s->TrimEnd(nullptr)->EndsWith( "'F" ) )
         {
            temp->Value = Double::Parse( s->Remove( s->LastIndexOf( '\'' ), 2 ) );
         }
         else
         if ( s->TrimEnd(nullptr)->EndsWith( "'C" ) )
         {
            temp->Celsius = Double::Parse( s->Remove( s->LastIndexOf( '\'' ), 2 ) );
         }
         else
         {
            temp->Value = Double::Parse( s );
         }

         return temp;
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