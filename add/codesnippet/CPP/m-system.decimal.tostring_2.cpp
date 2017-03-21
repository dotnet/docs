   public ref class PiggyBank
   {
   public:
      void AddPenny()
      {
         MyFortune = Decimal::Add( MyFortune, (Decimal).01 );
      }

      virtual System::String^ ToString() override
      {
         return MyFortune.ToString("C")+" in piggy bank";
      }

   protected:
      Decimal MyFortune;
   };
}