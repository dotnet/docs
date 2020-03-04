
// System::Int32::Equals(Object)
/*
The following program demonstrates the 'Equals(Object)' method
of struct 'Int32'. This compares an instance of 'Int32' with the
passed in object and returns true if they are equal.
*/
using namespace System;
int main()
{
   try
   {
      
      // <Snippet1>
      Int32 myVariable1 = 60;
      Int32 myVariable2 = 60;
      
      // Get and display the declaring type.
      Console::WriteLine( "\nType of 'myVariable1' is '{0}' and  value is : {1}", myVariable1.GetType(), myVariable1 );
      Console::WriteLine( "Type of 'myVariable2' is '{0}' and  value is : {1}", myVariable2.GetType(), myVariable2 );
      
      // Compare 'myVariable1' instance with 'myVariable2' Object.
      if ( myVariable1.Equals( myVariable2 ) )
            Console::WriteLine( "\nStructures 'myVariable1' and 'myVariable2' are equal" );
      else
            Console::WriteLine( "\nStructures 'myVariable1' and 'myVariable2' are not equal" );
      
      // </Snippet1>
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception : {0}", e->Message );
   }

}

/* expected return values:
20'F
-6'C
20'F
0
72'F
-52
*/
/*
namespace Snippets2 {
 //<snippet2>

 public __gc class Temperature {
 // The value holder
 protected:
  short m_value;

 public:
  __property static short get_MinValue() {
   return Int32.MinValue;
  }

  __property static short get_MaxValue() {
   return Int32.MaxValue;
  }

  __property short get_Value(){
   return m_value;
  }
  __property void set_Value( short value){
   m_value = value;
  }

  __property short get_Celsius(){
   return (short)((m_value-32)/2);
  }

  __property void set_Celsius( short value){
   m_value = (short)(value*2+32);
  }
 }
 //</snippet2>
}

namespace Snippets3 {
 //<snippet3>
 public __gc class Temperature : IComparable {
  /// <summary>
  /// IComparable.CompareTo implementation.
  /// </summary>
 // The value holder
 protected:
  short m_value;

 public:
  Int32 CompareTo(Object* obj) {
   if(obj->GetType() == __typeof(Temperature)) {
    Temperature temp = dynamic_cast<Temperature*>(obj);
    return m_value.CompareTo(temp.m_value);
   }
   
   throw new ArgumentException("object is not a Temperature");
  }

  __property short get_Value() {
   return m_value;
  }

  __property void set_Value( short value) {
   m_value = value;
  }

  __property short get_Celsius() {
   return (short)((m_value-32)/2);
  }

  __property void set_Celsius( Int32 value) {
   m_value = (short)(value*2+32);
  }
 }
 //</snippet3>
}

namespace Snippets4 {
 //<snippet4>
 public __gc class Temperature : IFormattable {
  /// <summary>
  /// IFormattable.ToString implementation.
  /// </summary>
 // The value holder
 protected:
  short m_value;

 public:
  String* ToString(String* format, IFormatProvider provider) {
   if( format != NULL ) {
    if( format->Equals("F") ) {
     return String::Format("{0}'F", this->Value->ToString());
    }
    if( format->Equals("C") ) {
     return String::Format("{0}'C", this->Celsius->ToString());
    }
   }

   return m_value->ToString(format, provider);
  }

  __property short get_Value() {
   return m_value;
  }

  __property void set_Value( short value) {
   m_value = value;
  }

  __property short get_Celsius() {
   return (short)((m_value-32)/2);
  }

  __property void set_Celsius( short value) {
   m_value = (short)(value*2+32);
  }
 }
 //</snippet4>
}
namespace Snippets5 {
 //<snippet5>
 public __gc class Temperature {
  /// <summary>
  /// Parses the temperature from a string in form
  /// [ws][sign]digits['F|'C][ws]
  /// </summary>
 // The value holder
 protected:
  short m_value;

 public:
  static Temperature* Parse(String* s) {
   Temperature* temp = new Temperature();

   if( s->TrimEnd(NULL)->EndsWith("'F") ) {
    temp->Value = Int32::Parse( s->Remove(s->LastIndexOf('\''), 2) );
   }
   else {
    if( s->TrimEnd(NULL)->EndsWith("'C") ) {
     temp->Celsius = Int32::Parse( s->Remove(s->LastIndexOf('\''), 2) );
    }
    else {
     temp->Value = Int32::Parse(s);
    }
   }
   return temp;
  }

  __property short get_Value() {
   return m_value;
  }

  __property void set_Value( short value) {
   m_value = value;
  }

  __property short get_Celsius() {
   return (short)((m_value-32)/2);
  }

  __property void set_Celsius( short value) {
    m_value = (short)(value*2+32);
   }
  }
 }
 //</snippet5>
}
namespace Snippets6 {
 //<snippet6>
 public class Temperature {
  /// <summary>
  /// Parses the temperature from a string in form
  /// [ws][sign]digits['F|'C][ws]
  /// </summary>

 // The value holder
 protected:
  short m_value;

 public:
  static Temperature* Parse(String* s, IFormatProvider provider) {
   Temperature* temp = new Temperature();

   if( s->TrimEnd(NULL)->EndsWith("'F") ) {
    temp->Value = Int32::Parse( s->Remove(s->LastIndexOf('\''), 2), provider);
   }
   else {
    if( s->TrimEnd(NULL)->EndsWith("'C") ) {
     temp->Celsius = Int32::Parse( s->Remove(s->LastIndexOf('\''), 2), provider);
    }
    else {
     temp->Value = Int32::Parse(s, provider);
    }
   }

   return temp;
  }

  __property short get_Value() {
   return m_value;
  }

  __property void set_Value( short value) {
   m_value = value;
  }

  __property short get_Celsius() {
   return (short)((m_value-32)/2);
  }

  __property void set_Celsius( short value) {
   m_value = (short)(value*2+32);
  }
 }
 //</snippet6>
}
namespace Snippets7 {
 //<snippet7>
 public class Temperature {
  /// <summary>
  /// Parses the temperature from a string in form
  /// [ws][sign]digits['F|'C][ws]
  /// </summary>

 // The value holder
 protected:
  short m_value;

 public:
  static Temperature* Parse(String* s, NumberStyles styles) {
   Temperature* temp = new Temperature();

   if( s->TrimEnd(NULL)->EndsWith("'F") ) {
    temp->Value = Int32::Parse( s->Remove(s->LastIndexOf('\''), 2), styles);
   }
   else {
    if( s->TrimEnd(NULL)->EndsWith("'C") ) {
     temp->Celsius = Int32::Parse( s->Remove(s->LastIndexOf('\''), 2), styles);
    }
    else {
     temp->Value = Int32::Parse(s, styles);
    }
   }

   return temp;
  }

  __property short get_Value() {
   return m_value;
  }

  __property void set_Value( short value) {
    m_value = value;
  }

  __property short get_Celsius() {
   return (short)((m_value-32)/2);
  }

  __property void set_Celsius( short value) {
   m_value = (short)(value*2+32);
  }
 }
 //</snippet7>
}
namespace Snippets8 {
 //<snippet8>
 public class Temperature {
  /// <summary>
  /// Parses the temperature from a string in form
  /// [ws][sign]digits['F|'C][ws]
  /// </summary>

 // The value holder
 protected:
  short m_value;

 public:
  static Temperature* Parse(String* s, NumberStyles styles, IFormatProvider* provider) {
   Temperature* temp = new Temperature();

   if( s->TrimEnd(NULL)->EndsWith("'F") ) {
    temp->Value = Int32::Parse( s->Remove(s->LastIndexOf('\''), 2), styles, provider);
   }
   else {
    if( s->TrimEnd(NULL)->EndsWith("'C") ) {
     temp->Celsius = Int32::Parse( s->Remove(s->LastIndexOf('\''), 2), styles, provider);
    }
    else {
     temp->Value = Int32::Parse(s, styles, provider);
    }
   }

   return temp;
  }

  __property short get_Value() {
   return m_value;
  }

  __property void set_Value( short value) {
   m_value = value;
  }

  __property short get_Celsius() {
   return (short)((m_value-32)/2);
  }

  __property void set_Celsius( short value) {
    m_value = (short)(value*2+32);
  }
 }
 //</snippet8>
}
*/
