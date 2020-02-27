#using <System.DLL>

using namespace System;

ref class Sample
{
private:
   void Method()
   {
      // <Snippet1>
      Math::Round(3.44, 1); //Returns 3.4.
      Math::Round(3.45, 1); //Returns 3.4.
      Math::Round(3.46, 1); //Returns 3.5.

      Math::Round(4.34, 1); // Returns 4.3
      Math::Round(4.35, 1); // Returns 4.4
      Math::Round(4.36, 1); // Returns 4.4
      // </Snippet1>
   }
};
