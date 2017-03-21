   public ref class PiggyBank
   {
   public:
      Decimal Capacity()
      {
         return MyFortune.MaxValue;
      }

      void AddPenny()
      {
         MyFortune = Decimal::Add(MyFortune, (Decimal).01);
      }

   protected:
      Decimal MyFortune;
   };

}