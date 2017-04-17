using namespace System;

ref class Example
{
   public:

   void Main()
   {
      // <Snippet35>
      Decimal pricePerOunce = (Decimal)17.36;
      String^ s = String::Format("The current price is {0} per ounce.",
                                 pricePerOunce);
      // Result: The current price is 17.36 per ounce.
      // </Snippet35>
      Console::WriteLine(s);
      ShowFormatted();
   }

   void ShowFormatted()
   {
      // <Snippet36>
      Decimal pricePerOunce = (Decimal)17.36;
      String^ s = String::Format("The current price is {0:C2} per ounce.",
                                 pricePerOunce);
      // Result if current culture is en-US:
      //      The current price is $17.36 per ounce.
      // </Snippet36>
      Console::WriteLine(s);
   }
};


void main()
{
   Example^ ex = gcnew Example();
   ex->Main();
}