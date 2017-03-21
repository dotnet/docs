   /// <summary>
   /// Keeping my fortune in Decimals to avoid the round-off errors.
   /// </summary>
   public ref class PiggyBank
   {
   protected:
      Decimal MyFortune;

   public:
      void AddPenny()
      {
         MyFortune = System::Decimal::Add( MyFortune, Decimal(.01) );
      }

      System::Decimal Capacity()
      {
         return MyFortune.MaxValue;
      }

      Decimal Dollars()
      {
         return Decimal::Floor( MyFortune );
      }

      Decimal Cents()
      {
         return Decimal::Subtract( MyFortune, Decimal::Floor( MyFortune ) );
      }

      virtual System::String^ ToString() override
      {
         return MyFortune.ToString("C")+" in piggy bank";
      }
   };
}