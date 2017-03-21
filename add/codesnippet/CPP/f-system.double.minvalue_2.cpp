   public ref class Temperature
   {
   public:
      static property double MinValue 
      {
         double get()
         {
            return Double::MinValue;
         }
      }

      static property double MaxValue 
      {
         double get()
         {
            return Double::MaxValue;
         }
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