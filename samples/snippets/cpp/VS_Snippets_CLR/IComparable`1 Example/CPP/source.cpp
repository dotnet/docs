//<snippet1>
#using <System.dll>

using namespace System;
using namespace System::Collections::Generic;

public ref class Temperature: public IComparable<Temperature^> {

protected:
   // The underlying temperature value.
   Double m_value;

public:
   // Implement the generic CompareTo method with the Temperature class 
   // as the Type parameter. 
   virtual Int32 CompareTo( Temperature^ other ) {
   
      // If other is not a valid object reference, this instance 
      // is greater.
      if (other == nullptr) return 1;
      
      // The temperature comparison depends on the comparison of the
      // the underlying Double values. 
      return m_value.CompareTo( other->m_value );
   }

       // Define the is greater than operator.
    bool operator>=  (Temperature^ other)
    {
       return CompareTo(other) == 1;
    }
    
    // Define the is less than operator.
    bool operator<  (Temperature^ other)
    {
       return CompareTo(other) == -1;
    }
    
       // Define the is greater than or equal to operator.
    bool operator>  (Temperature^ other)
    {
       return CompareTo(other) >= 0;
    }
    
    // Define the is less than or equal to operator.
    bool operator<=  (Temperature^ other)
    {
       return CompareTo(other) <= 0;
    }

   property Double Celsius {
      Double get() {
         return m_value + 273.15;
      }
   }

   property Double Kelvin {
      Double get() {
         return m_value;
      }
      void set( Double value ) {
         if (value < 0)
            throw gcnew ArgumentException("Temperature cannot be less than absolute zero.");
         else
            m_value = value;
      }
   }

   Temperature(Double kelvins) {
      this->Kelvin = kelvins;
   }
};

int main() {
   SortedList<Temperature^, String^>^ temps = 
      gcnew SortedList<Temperature^, String^>();

   // Add entries to the sorted list, out of order.
   temps->Add(gcnew Temperature(2017.15), "Boiling point of Lead");
   temps->Add(gcnew Temperature(0), "Absolute zero");
   temps->Add(gcnew Temperature(273.15), "Freezing point of water");
   temps->Add(gcnew Temperature(5100.15), "Boiling point of Carbon");
   temps->Add(gcnew Temperature(373.15), "Boiling point of water");
   temps->Add(gcnew Temperature(600.65), "Melting point of Lead");

   for each( KeyValuePair<Temperature^, String^>^ kvp in temps )
   {
      Console::WriteLine("{0} is {1} degrees Celsius.", kvp->Value, kvp->Key->Celsius);
   }
}
/* The example displays the following output:
      Absolute zero is 273.15 degrees Celsius.
      Freezing point of water is 546.3 degrees Celsius.
      Boiling point of water is 646.3 degrees Celsius.
      Melting point of Lead is 873.8 degrees Celsius.
      Boiling point of Lead is 2290.3 degrees Celsius.
      Boiling point of Carbon is 5373.3 degrees Celsius.
*/
//</snippet1>
