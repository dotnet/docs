   public ref class Temperature
   {
   public:
      static property UInt32 MinValue 
      {
         UInt32 get()
         {
            return UInt32::MinValue;
         }
      }

      static property UInt32 MaxValue 
      {
         UInt32 get()
         {
            return UInt32::MaxValue;
         }
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