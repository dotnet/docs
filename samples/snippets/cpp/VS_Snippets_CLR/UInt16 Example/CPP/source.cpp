
// This is the main DLL file.
using namespace System;
using namespace System::Globalization;

#define NULL 0

//<snippet1>
/// <summary>
/// Temperature class stores the value as UInt16
/// and delegates most of the functionality
/// to the UInt16 implementation.
/// </summary>
public ref class Temperature: public IComparable, public IFormattable
{
protected:

   /// <summary>
   /// IComparable.CompareTo implementation.
   /// </summary>
   short m_value;

public:
   virtual Int32 CompareTo( Object^ obj )
   {
      if ( obj->GetType() == Temperature::typeid )
      {
         Temperature^ temp = dynamic_cast<Temperature^>(obj);
         return m_value.CompareTo( temp->m_value );
      }

      throw gcnew ArgumentException(  "object is not a Temperature" );
   }


   /// <summary>
   /// IFormattable.ToString implementation.
   /// </summary>
   virtual String^ ToString( String^ format, IFormatProvider^ provider )
   {
      if ( format != nullptr )
      {
         if ( format->Equals(  "F" ) )
         {
            return String::Format(  "{0}'F", this->Value.ToString() );
         }

         if ( format->Equals(  "C" ) )
         {
            return String::Format(  "{0}'C", this->Celsius.ToString() );
         }
      }

      return m_value.ToString( format, provider );
   }


   /// <summary>
   /// Parses the temperature from a string in form
   /// [ws][sign]digits['F|'C][ws]
   /// </summary>
   static Temperature^ Parse( String^ s, NumberStyles styles, IFormatProvider^ provider )
   {
      Temperature^ temp = gcnew Temperature;
      if ( s->EndsWith(  "F" ) )
      {
         temp->Value = UInt16::Parse( s->Remove( s->LastIndexOf( '\'' ), 2 ), styles, provider );
      }
      else
      {
         if ( s->EndsWith(  "C" ) )
         {
            temp->Celsius = UInt16::Parse( s->Remove( s->LastIndexOf( '\'' ), 2 ), styles, provider );
         }
         else
         {
            temp->Value = UInt16::Parse( s, styles, provider );
         }
      }

      return temp;
   }


   property short Value 
   {

      // The value holder
      short get()
      {
         return m_value;
      }

      void set( short value )
      {
         m_value = value;
      }

   }

   property short Celsius 
   {
      short get()
      {
         return (short)((m_value - 32) / 2);
      }

      void set( short value )
      {
         m_value = (short)(value * 2 + 32);
      }

   }

   static property short MinValue 
   {
      short get()
      {
         return UInt16::MinValue;
      }

   }

   static property short MaxValue 
   {
      short get()
      {
         return UInt16::MaxValue;
      }

   }

};
//</snippet1>

void main()
{
   Temperature^ t1 = Temperature::Parse(  "40'F", NumberStyles::Integer, nullptr );
   Console::WriteLine( t1->ToString( "F", nullptr ) );
   String^ str1 = t1->ToString(  "C", nullptr );
   Console::WriteLine( str1 );
   Temperature^ t2 = Temperature::Parse( str1, NumberStyles::Integer, nullptr );
   Console::WriteLine( t2->ToString(  "F", nullptr ) );
   Console::WriteLine( t1->CompareTo( t2 ) );
   Temperature^ t3 = Temperature::Parse(  "40'C", NumberStyles::Integer, nullptr );
   Console::WriteLine( t3->ToString(  "F", nullptr ) );
   Console::WriteLine( t1->CompareTo( t3 ) );
}


/* expected return values:
40'F
4'C
40'F
0
112'F
-72
*/
namespace Snippets2
{
   //<snippet2>
   public ref class Temperature
   {
   protected:

      // The value holder
      short m_value;

   public:

      static property short MinValue 
      {
         short get()
         {
            return UInt16::MinValue;
         }

      }

      static property short MaxValue 
      {
         short get()
         {
            return UInt16::MaxValue;
         }

      }

      property short Value 
      {
         short get()
         {
            return m_value;
         }

         void set( short value )
         {
            m_value = value;
         }

      }

      property short Celsius 
      {
         short get()
         {
            return (short)((m_value - 32) / 2);
         }

         void set( short value )
         {
            m_value = (short)(value * 2 + 32);
         }

      }

   };

}
//</snippet2>

namespace Snippets3
{

   //<snippet3>
   public ref class Temperature: public IComparable
   {
   protected:

      /// <summary>
      /// IComparable.CompareTo implementation.
      /// </summary>
      // The value holder
      short m_value;

   public:
      virtual Int32 CompareTo( Object^ obj )
      {
         if ( obj->GetType() == Temperature::typeid )
         {
            Temperature^ temp = dynamic_cast<Temperature^>(obj);
            return m_value.CompareTo( temp->m_value );
         }

         throw gcnew ArgumentException(  "object is not a Temperature" );
      }


      property short Value 
      {
         short get()
         {
            return m_value;
         }

         void set( short value )
         {
            m_value = value;
         }

      }

      property short Celsius 
      {
         short get()
         {
            return (short)((m_value - 32) / 2);
         }

         void set( short value )
         {
            m_value = (value * 2 + 32);
         }

      }

   };

}
//</snippet3>

namespace Snippets4
{

   //<snippet4>
   public ref class Temperature: public IFormattable
   {
   protected:

      /// <summary>
      /// IFormattable.ToString implementation.
      /// </summary>
      // The value holder
      short m_value;

   public:
      virtual String^ ToString( String^ format, IFormatProvider^ provider )
      {
         if ( format != nullptr )
         {
            if ( format->Equals(  "F" ) )
            {
               return String::Format(  "{0}'F", this->Value.ToString() );
            }

            if ( format->Equals(  "C" ) )
            {
               return String::Format(  "{0}'C", this->Celsius.ToString() );
            }
         }

         return m_value.ToString( format, provider );
      }


      property short Value 
      {
         short get()
         {
            return m_value;
         }

         void set( short value )
         {
            m_value = value;
         }

      }

      property short Celsius 
      {
         short get()
         {
            return (short)((m_value - 32) / 2);
         }

         void set( short value )
         {
            m_value = (short)(value * 2 + 32);
         }

      }

   };

}
//</snippet4>

namespace Snippets5
{
   //<snippet5>
   public ref class Temperature
   {
   protected:

      /// <summary>
      /// Parses the temperature from a string in form
      /// [ws][sign]digits['F|'C][ws]
      /// </summary>
      // The value holder
      short m_value;

   public:
      static Temperature^ Parse( String^ s )
      {
         Temperature^ temp = gcnew Temperature;
         if ( s->TrimEnd( NULL )->EndsWith(  "'F" ) )
         {
            temp->Value = UInt16::Parse( s->Remove( s->LastIndexOf( '\'' ), 2 ) );
         }
         else
         {
            if ( s->TrimEnd( NULL )->EndsWith(  "'C" ) )
            {
               temp->Celsius = UInt16::Parse( s->Remove( s->LastIndexOf( '\'' ), 2 ) );
            }
            else
            {
               temp->Value = UInt16::Parse( s );
            }
         }

         return temp;
      }


      property short Value 
      {
         short get()
         {
            return m_value;
         }

         void set( short value )
         {
            m_value = value;
         }

      }

      property short Celsius 
      {
         short get()
         {
            return (short)((m_value - 32) / 2);
         }

         void set( short value )
         {
            m_value = (short)(value * 2 + 32);
         }

      }

   };

}
//</snippet5>

namespace Snippets6
{
   //<snippet6>
   public ref class Temperature
   {
   protected:

      /// <summary>
      /// Parses the temperature from a string in form
      /// [ws][sign]digits['F|'C][ws]
      /// </summary>
      // The value holder
      short m_value;

   public:
      static Temperature^ Parse( String^ s, IFormatProvider^ provider )
      {
         Temperature^ temp = gcnew Temperature;
         if ( s->TrimEnd( NULL )->EndsWith(  "'F" ) )
         {
            temp->Value = UInt16::Parse( s->Remove( s->LastIndexOf( '\'' ), 2 ), provider );
         }
         else
         {
            if ( s->TrimEnd( NULL )->EndsWith(  "'C" ) )
            {
               temp->Celsius = UInt16::Parse( s->Remove( s->LastIndexOf( '\'' ), 2 ), provider );
            }
            else
            {
               temp->Value = UInt16::Parse( s, provider );
            }
         }

         return temp;
      }


      property short Value 
      {
         short get()
         {
            return m_value;
         }

         void set( short value )
         {
            m_value = value;
         }

      }

      property short Celsius 
      {
         short get()
         {
            return (short)((m_value - 32) / 2);
         }

         void set( short value )
         {
            m_value = (short)(value * 2 + 32);
         }

      }

   };

}
//</snippet6>

namespace Snippets7
{
   //<snippet7>
   public ref class Temperature
   {
   protected:

      /// <summary>
      /// Parses the temperature from a string in form
      /// [ws][sign]digits['F|'C][ws]
      /// </summary>
      // The value holder
      short m_value;

   public:
      static Temperature^ Parse( String^ s, NumberStyles styles )
      {
         Temperature^ temp = gcnew Temperature;
         if ( s->TrimEnd( NULL )->EndsWith(  "'F" ) )
         {
            temp->Value = UInt16::Parse( s->Remove( s->LastIndexOf( '\'' ), 2 ), styles );
         }
         else
         {
            if ( s->TrimEnd( NULL )->EndsWith(  "'C" ) )
            {
               temp->Celsius = UInt16::Parse( s->Remove( s->LastIndexOf( '\'' ), 2 ), styles );
            }
            else
            {
               temp->Value = UInt16::Parse( s, styles );
            }
         }

         return temp;
      }


      property short Value 
      {
         short get()
         {
            return m_value;
         }

         void set( short value )
         {
            m_value = value;
         }

      }

      property short Celsius 
      {
         short get()
         {
            return (short)((m_value - 32) / 2);
         }

         void set( short value )
         {
            m_value = (short)(value * 2 + 32);
         }

      }

   };

}
//</snippet7>

namespace Snippets8
{
   //<snippet8>
   public ref class Temperature
   {
   protected:

      /// <summary>
      /// Parses the temperature from a string in form
      /// [ws][sign]digits['F|'C][ws]
      /// </summary>
      // The value holder
      short m_value;

   public:
      static Temperature^ Parse( String^ s, NumberStyles styles, IFormatProvider^ provider )
      {
         Temperature^ temp = gcnew Temperature;
         if ( s->TrimEnd( NULL )->EndsWith(  "'F" ) )
         {
            temp->Value = UInt16::Parse( s->Remove( s->LastIndexOf( '\'' ), 2 ), styles, provider );
         }
         else
         {
            if ( s->TrimEnd( NULL )->EndsWith(  "'C" ) )
            {
               temp->Celsius = UInt16::Parse( s->Remove( s->LastIndexOf( '\'' ), 2 ), styles, provider );
            }
            else
            {
               temp->Value = UInt16::Parse( s, styles, provider );
            }
         }

         return temp;
      }


      property short Value 
      {
         short get()
         {
            return m_value;
         }

         void set( short value )
         {
            m_value = value;
         }

      }

      property short Celsius 
      {
         short get()
         {
            return (short)((m_value - 32) / 2);
         }

         void set( short value )
         {
            m_value = (short)(value * 2 + 32);
         }

      }

   };

}
//</snippet8>
