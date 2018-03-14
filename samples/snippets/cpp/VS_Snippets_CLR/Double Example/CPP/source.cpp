using namespace System;
using namespace System::Globalization;

namespace Snippets
{
   //<snippet1>
   // The Temperature class stores the temperature as a Double
   // and delegates most of the functionality to the Double 
   // implementation.
   public ref class Temperature: public IComparable, public IFormattable
   {
      // IComparable.CompareTo implementation.
   public:
      virtual int CompareTo( Object^ obj )
      {
         if (obj == nullptr) return 1;
         
         if (dynamic_cast<Temperature^>(obj) )
         {
            Temperature^ temp = (Temperature^)(obj);
            return m_value.CompareTo( temp->m_value );
         }
         throw gcnew ArgumentException( "object is not a Temperature" );
      }

      // IFormattable.ToString implementation.
      virtual String^ ToString( String^ format, IFormatProvider^ provider )
      {
         if ( format != nullptr )
         {
            if ( format->Equals( "F" ) )
            {
               return String::Format( "{0}'F", this->Value.ToString() );
            }

            if ( format->Equals( "C" ) )
            {
               return String::Format( "{0}'C", this->Celsius.ToString() );
            }
         }
         return m_value.ToString( format, provider );
      }

      // Parses the temperature from a string in the form
      // [ws][sign]digits['F|'C][ws]
      static Temperature^ Parse( String^ s, NumberStyles styles, IFormatProvider^ provider )
      {
         Temperature^ temp = gcnew Temperature;

         if ( s->TrimEnd(nullptr)->EndsWith( "'F" ) )
         {
            temp->Value = Double::Parse( s->Remove( s->LastIndexOf( '\'' ), 2 ), styles, provider );
         }
         else
         if ( s->TrimEnd(nullptr)->EndsWith( "'C" ) )
         {
            temp->Celsius = Double::Parse( s->Remove( s->LastIndexOf( '\'' ), 2 ), styles, provider );
         }
         else
         {
            temp->Value = Double::Parse( s, styles, provider );
         }
         return temp;
      }

   protected:
      double m_value;

   public:
      property double Value 
      {
         double get()
         {
            return m_value;
         }

         void set( double value )
         {
            m_value = value;
         }
      }

      property double Celsius 
      {
         double get()
         {
            return (m_value - 32.0) / 1.8;
         }

         void set( double value )
         {
            m_value = 1.8 * value + 32.0;
         }
      }
   };
   //</snippet1>

   ref class Launcher
   {
   public:
      static void Main()
      {
         Temperature^ t1 = Temperature::Parse( "20'F", NumberStyles::Float, nullptr );
         Console::WriteLine( t1->ToString( "F", nullptr ) );

         String^ str1 = t1->ToString( "C", nullptr );
         Console::WriteLine( str1 );

         Temperature^ t2 = Temperature::Parse( str1, NumberStyles::Float, nullptr );
         Console::WriteLine( t2->ToString( "F", nullptr ) );

         Console::WriteLine( t1->CompareTo( t2 ) );

         Temperature^ t3 = Temperature::Parse( "20'C", NumberStyles::Float, nullptr );
         Console::WriteLine( t3->ToString( "F", nullptr ) );

         Console::WriteLine( t1->CompareTo( t3 ) );

         Console::ReadLine();
      }
   };
}

namespace Snippets2
{
   //<snippet2>
   public ref class Temperature
   {
   public:
      static property double MinValue 
      {
         double get()
         {
            return Double::MinValue;
         }
      }

      static property double MaxValue 
      {
         double get()
         {
            return Double::MaxValue;
         }
      }

   protected:
      // The value holder
      double m_value;

   public:
      property double Value 
      {
         double get()
         {
            return m_value;
         }
         void set( double value )
         {
            m_value = value;
         }
      }

      property double Celsius 
      {
         double get()
         {
            return (m_value - 32.0) / 1.8;
         }
         void set( double value )
         {
            m_value = 1.8 * value + 32.0;
         }
      }
   };
//</snippet2>
}

namespace Snippets3
{
   //<snippet3>
   public ref class Temperature: public IComparable
   {
      // IComparable.CompareTo implementation.
   public:
      virtual int CompareTo( Object^ obj )
      {
         if (obj == nullptr) return 1;

         if ( dynamic_cast<Temperature^>(obj) )
         {
            Temperature^ temp = dynamic_cast<Temperature^>(obj);

            return m_value.CompareTo( temp->m_value );
         }

         throw gcnew ArgumentException( "object is not a Temperature" );
      }

   protected:
      // The value holder
      double m_value;

   public:
      property double Value 
      {
         double get()
         {
            return m_value;
         }
         void set( double value )
         {
            m_value = value;
         }
      }

      property double Celsius 
      {
         double get()
         {
            return (m_value - 32.0) / 1.8;
         }
         void set( double value )
         {
            m_value = 1.8 * value + 32.0;
         }
      }
   };
//</snippet3>
}

namespace Snippets4
{
   //<snippet4>
   public ref class Temperature: public IFormattable
   {
      // IFormattable.ToString implementation.
   public:
      virtual String^ ToString( String^ format, IFormatProvider^ provider )
      {
         if ( format != nullptr )
         {
            if ( format->Equals( "F" ) )
            {
               return String::Format( "{0}'F", this->Value.ToString() );
            }

            if ( format->Equals( "C" ) )
            {
               return String::Format( "{0}'C", this->Celsius.ToString() );
            }
         }

         return m_value.ToString( format, provider );
      }

   protected:
      // The value holder
      double m_value;

   public:
      property double Value 
      {
         double get()
         {
            return m_value;
         }
         void set( double value )
         {
            m_value = value;
         }
      }

      property double Celsius 
      {
         double get()
         {
            return (m_value - 32.0) / 1.8;
         }
         void set( double value )
         {
            m_value = 1.8 * value + 32.0;
         }
      }
   };
//</snippet4>
}

namespace Snippets5
{
   //<snippet5>
   public ref class Temperature
   {
      // Parses the temperature from a string in form
      // [ws][sign]digits['F|'C][ws]
   public:
      static Temperature^ Parse( String^ s )
      {
         Temperature^ temp = gcnew Temperature;
         if ( s->TrimEnd(nullptr)->EndsWith( "'F" ) )
         {
            temp->Value = Double::Parse( s->Remove( s->LastIndexOf( '\'' ), 2 ) );
         }
         else
         if ( s->TrimEnd(nullptr)->EndsWith( "'C" ) )
         {
            temp->Celsius = Double::Parse( s->Remove( s->LastIndexOf( '\'' ), 2 ) );
         }
         else
         {
            temp->Value = Double::Parse( s );
         }

         return temp;
      }

   protected:
      // The value holder
      double m_value;

   public:
      property double Value 
      {
         double get()
         {
            return m_value;
         }
         void set( double value )
         {
            m_value = value;
         }
      }

      property double Celsius 
      {
         double get()
         {
            return (m_value - 32.0) / 1.8;
         }
         void set( double value )
         {
            m_value = 1.8 * value + 32.0;
         }
      }
   };
//</snippet5>
}

namespace Snippets6
{
   //<snippet6>
   public ref class Temperature
   {
      // Parses the temperature from a string in form
      // [ws][sign]digits['F|'C][ws]
   public:
      static Temperature^ Parse( String^ s, IFormatProvider^ provider )
      {
         Temperature^ temp = gcnew Temperature;
         if ( s->TrimEnd(nullptr)->EndsWith( "'F" ) )
         {
            temp->Value = Double::Parse( s->Remove( s->LastIndexOf( '\'' ), 2 ), provider );
         }
         else
         if ( s->TrimEnd(nullptr)->EndsWith( "'C" ) )
         {
            temp->Celsius = Double::Parse( s->Remove( s->LastIndexOf( '\'' ), 2 ), provider );
         }
         else
         {
            temp->Value = Double::Parse( s, provider );
         }

         return temp;
      }

   protected:
      // The value holder
      double m_value;

   public:
      property double Value 
      {
         double get()
         {
            return m_value;
         }
         void set( double value )
         {
            m_value = value;
         }
      }

      property double Celsius 
      {
         double get()
         {
            return (m_value - 32.0) / 1.8;
         }
         void set( double value )
         {
            m_value = 1.8 * value + 32.0;
         }
      }
   };
//</snippet6>
}

namespace Snippets7
{
   //<snippet7>
   public ref class Temperature
   {
      // Parses the temperature from a string in form
      // [ws][sign]digits['F|'C][ws]
   public:
      static Temperature^ Parse( String^ s, NumberStyles styles )
      {
         Temperature^ temp = gcnew Temperature;
         if ( s->TrimEnd(nullptr)->EndsWith( "'F" ) )
         {
            temp->Value = Double::Parse( s->Remove( s->LastIndexOf( '\'' ), 2 ), styles );
         }
         else
         if ( s->TrimEnd(nullptr)->EndsWith( "'C" ) )
         {
            temp->Celsius = Double::Parse( s->Remove( s->LastIndexOf( '\'' ), 2 ), styles );
         }
         else
         {
            temp->Value = Double::Parse( s, styles );
         }

         return temp;
      }

   protected:
      // The value holder
      double m_value;

   public:
      property double Value 
      {
         double get()
         {
            return m_value;
         }
         void set( double value )
         {
            m_value = value;
         }
      }

      property double Celsius 
      {
         double get()
         {
            return (m_value - 32.0) / 1.8;
         }
         void set( double value )
         {
            m_value = 1.8 * value + 32.0;
         }
      }
   };
//</snippet7>
}

namespace Snippets8
{
   //<snippet8>
   public ref class Temperature
   {
      // Parses the temperature from a string in the form
      // [ws][sign]digits['F|'C][ws]
   public:
      static Temperature^ Parse( String^ s, NumberStyles styles, IFormatProvider^ provider )
      {
         Temperature^ temp = gcnew Temperature;
         if ( s->TrimEnd(nullptr)->EndsWith( "'F" ) )
         {
            temp->Value = Double::Parse( s->Remove( s->LastIndexOf( '\'' ), 2 ), styles, provider );
         }
         else
         if ( s->TrimEnd(nullptr)->EndsWith( "'C" ) )
         {
            temp->Celsius = Double::Parse( s->Remove( s->LastIndexOf( '\'' ), 2 ), styles, provider );
         }
         else
         {
            temp->Value = Double::Parse( s, styles, provider );
         }

         return temp;
      }

   protected:
      // The value holder
      double m_value;

   public:
      property double Value 
      {
         double get()
         {
            return m_value;
         }
         void set( double value )
         {
            m_value = value;
         }
      }

      property double Celsius 
      {
         double get()
         {
            return (m_value - 32.0) / 1.8;
         }
         void set( double value )
         {
            m_value = 1.8 * value + 32.0;
         }
      }
   };
//</snippet8>
}

int main()
{
   Snippets::Launcher::Main();
}
