   public ref class PiggyBank
   {
   public:
      Decimal Cents()
      {
         return Decimal::Subtract( MyFortune, Decimal::Floor( MyFortune ) );
      }

      void AddPenny()
      {
         MyFortune = Decimal::Add(MyFortune, (Decimal).01);
      }

   protected:
      Decimal MyFortune;
   };
}