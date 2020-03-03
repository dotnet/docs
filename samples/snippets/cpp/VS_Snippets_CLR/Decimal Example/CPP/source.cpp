using namespace System;

namespace Snippets
{
//<snippet1>
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
//</snippet1>

using namespace Snippets;
int main( void )
{
   PiggyBank ^ pb = gcnew PiggyBank;
   for ( Int32 i = 0; i < 378; i++ )
   {
      pb->AddPenny();

   }
   Console::WriteLine( pb );
}


namespace Snippets2
{
   //<snippet2>
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
//</snippet2>

namespace Snippets3
{
   //<snippet3>
   public ref class PiggyBank
   {
   public:
      Decimal Dollars()
      {
         return Decimal::Floor( MyFortune );
      }

      void AddPenny()
      {
         MyFortune = Decimal::Add(MyFortune, (Decimal).01);
      }

   protected:
      Decimal MyFortune;
   };

}
//</snippet3>

namespace Snippets4
{
//<snippet4>
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
//</snippet4>

namespace Snippets5
{
//<snippet5>
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
//</snippet5>
