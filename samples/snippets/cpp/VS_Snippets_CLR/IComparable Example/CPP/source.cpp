// IComparableExample.cpp : main project file.

// <Snippet1>
using namespace System;
using namespace System::Collections;

public ref class Temperature: public IComparable {
   /// <summary>
   /// IComparable.CompareTo implementation.
   /// </summary>
protected:
   // The value holder
   Double m_value;

public:
   virtual Int32 CompareTo( Object^ obj ) {
   
      if (obj == nullptr) return 1;
      
      if ( obj->GetType() == Temperature::typeid ) {
         Temperature^ temp = dynamic_cast<Temperature^>(obj);

         return m_value.CompareTo( temp->m_value );
      }
      throw gcnew ArgumentException(  "object is not a Temperature" );
   }

   property Double Value {
      Double get() {
         return m_value;
      }
      void set( Double value ) {
         m_value = value;
      }
   }

   property Double Celsius  {
      Double get() {
         return (m_value - 32) / 1.8;
      }
      void set( Double value ) {
         m_value = (value * 1.8) + 32;
      }
   }
};

int main()
{
   ArrayList^ temperatures = gcnew ArrayList;
   // Initialize random number generator.
   Random^ rnd = gcnew Random;

   // Generate 10 temperatures between 0 and 100 randomly.
   for (int ctr = 1; ctr <= 10; ctr++)
   {
      int degrees = rnd->Next(0, 100);
      Temperature^ temp = gcnew Temperature;
      temp->Value = degrees;
      temperatures->Add(temp);
   }

   // Sort ArrayList.
   temperatures->Sort();
      
   for each (Temperature^ temp in temperatures)
      Console::WriteLine(temp->Value);
   return 0;
}
// The example displays the following output to the console (individual
// values may vary because they are randomly generated):
//       2
//       7
//       16
//       17
//       31
//       37
//       58
//       66
//       72
//       95
// </Snippet1>
