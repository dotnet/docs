using namespace System;
using namespace System::Globalization;

//<snippet1>
/// <summary>
/// Temperature class stores the value as UInt64
/// and delegates most of the functionality 
/// to the UInt64 implementation.
/// </summary>
public ref class Temperature: public IComparable, public IFormattable
{
public:
   /// <summary>
   /// IComparable.CompareTo implementation.
   /// </summary>
   virtual int CompareTo( Object^ obj )
   {
      if ( (Temperature^)( obj ) )
      {
         Temperature^ temp = (Temperature^)( obj );

         return m_value.CompareTo( temp->m_value );
      }

      throw gcnew ArgumentException( "object is not a Temperature" );
   }

   /// <summary>
   /// IFormattable.ToString implementation.
   /// </summary>
   virtual String^ ToString( String^ format, IFormatProvider^ provider )
   {
      if ( format != nullptr && format == "F" )
      {
         return String::Format( "{0}'F", this->Value.ToString() );
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

      if ( s->TrimEnd( 0 )->EndsWith( "'F" ) )
      {
         temp->Value = UInt64::Parse( s->Remove( s->LastIndexOf( '\'' ), 2 ), styles, provider );
      }
      else
      {
         temp->Value = UInt64::Parse( s, styles, provider );
      }

      return temp;
   }

protected:
   // The value holder
   UInt64 m_value;

public:
   property UInt64 Value 
   {
      UInt64 get()
      {
         return m_value;
      }
      void set( UInt64 value )
      {
         m_value = value;
      }
   }
};
//</snippet1>

namespace Snippets2
{
   //<snippet2>
   public ref class Temperature
   {
   public:
      static property Int64 MinValue 
      {
         Int64 get()
         {
            return UInt64::MinValue;
         }
      }

      static property UInt64 MaxValue 
      {
         UInt64 get()
         {
            return UInt64::MaxValue;
         }
      }

   protected:
      // The value holder
      UInt64 m_value;

   public:
      property UInt64 Value 
      {
         UInt64 get()
         {
            return m_value;
         }
         void set( UInt64 value )
         {
            m_value = value;
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
   public:
      /// <summary>
      /// IComparable.CompareTo implementation.
      /// </summary>
      virtual int CompareTo( Object^ obj )
      {
      if ( (Temperature^)( obj ) )
      {
         Temperature^ temp = (Temperature^)( obj );

            return m_value.CompareTo( temp->m_value );
         }

         throw gcnew ArgumentException( "object is not a Temperature" );
      }

   protected:
      // The value holder
      UInt64 m_value;

   public:
      property UInt64 Value 
      {
         UInt64 get()
         {
            return m_value;
         }
         void set( UInt64 value )
         {
            m_value = value;
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
   public:
      /// <summary>
      /// IFormattable.ToString implementation.
      /// </summary>
      virtual String^ ToString( String^ format, IFormatProvider^ provider )
      {
         if ( format != nullptr && format == "F" )
         {
            return String::Format( "{0}'F", this->Value.ToString() );
         }

         return m_value.ToString( format, provider );
      }

   protected:
      // The value holder
      UInt64 m_value;

   public:
      property UInt64 Value 
      {
         UInt64 get()
         {
            return m_value;
         }
         void set( UInt64 value )
         {
            m_value = value;
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
   public:
      /// <summary>
      /// Parses the temperature from a string in form
      /// [ws][sign]digits['F|'C][ws]
      /// </summary>
      static Temperature^ Parse( String^ s )
      {
         Temperature^ temp = gcnew Temperature;

         if ( s->TrimEnd( 0 )->EndsWith( "'F" ) )
         {
            temp->Value = UInt64::Parse( s->Remove( s->LastIndexOf( '\'' ), 2 ) );
         }
         else
         {
            temp->Value = UInt64::Parse( s );
         }

         return temp;
      }

   protected:
      // The value holder
      UInt64 m_value;

   public:
      property UInt64 Value 
      {
         UInt64 get()
         {
            return m_value;
         }
         void set( UInt64 value )
         {
            m_value = value;
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
   public:
      /// <summary>
      /// Parses the temperature from a string in form
      /// [ws][sign]digits['F|'C][ws]
      /// </summary>
      static Temperature^ Parse( String^ s, IFormatProvider^ provider )
      {
         Temperature^ temp = gcnew Temperature;

         if ( s->TrimEnd( 0 )->EndsWith( "'F" ) )
         {
            temp->Value = UInt64::Parse( s->Remove( s->LastIndexOf( '\'' ), 2 ), provider );
         }
         else
         {
            temp->Value = UInt64::Parse( s, provider );
         }

         return temp;
      }

   protected:
      // The value holder
      UInt64 m_value;

   public:
      property UInt64 Value 
      {
         UInt64 get()
         {
            return m_value;
         }
         void set( UInt64 value )
         {
            m_value = value;
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
   public:
      /// <summary>
      /// Parses the temperature from a string in form
      /// [ws][sign]digits['F|'C][ws]
      /// </summary>
      static Temperature^ Parse( String^ s, NumberStyles styles )
      {
         Temperature^ temp = gcnew Temperature;

         if ( s->TrimEnd( 0 )->EndsWith( "'F" ) )
         {
            temp->Value = UInt64::Parse( s->Remove( s->LastIndexOf( '\'' ), 2 ), styles );
         }
         else
         {
            temp->Value = UInt64::Parse( s, styles );
         }

         return temp;
      }

   protected:
      // The value holder
      UInt64 m_value;

   public:
      property UInt64 Value 
      {
         UInt64 get()
         {
            return m_value;
         }
         void set( UInt64 value )
         {
            m_value = value;
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
   public:
      /// <summary>
      /// Parses the temperature from a string in form
      /// [ws][sign]digits['F|'C][ws]
      /// </summary>
      static Temperature^ Parse( String^ s, NumberStyles styles, IFormatProvider^ provider )
      {
         Temperature^ temp = gcnew Temperature;

         if ( s->TrimEnd( 0 )->EndsWith( "'F" ) )
         {
            temp->Value = UInt64::Parse( s->Remove( s->LastIndexOf( '\'' ), 2 ), styles, provider );
         }
         else
         {
            temp->Value = UInt64::Parse( s, styles, provider );
         }

         return temp;
      }

   protected:
      // The value holder
      UInt64 m_value;

   public:
      property UInt64 Value 
      {
         UInt64 get()
         {
            return m_value;
         }
         void set( UInt64 value )
         {
            m_value = value;
         }
      }
   };
}
//</snippet8>

int main()
{
   Temperature^ t1 = Temperature::Parse( "20'F", NumberStyles::Integer, nullptr );
   Console::WriteLine( t1->ToString( "F", nullptr ) );

   String^ str1 = t1->ToString( "G", nullptr );
   Console::WriteLine( str1 );

   Temperature^ t2 = Temperature::Parse( str1, NumberStyles::Integer, nullptr );
   Console::WriteLine( t2->ToString( "F", nullptr ) );

   Console::WriteLine( t1->CompareTo( t2 ) );

   Temperature^ t3 = Temperature::Parse( "30'F", NumberStyles::Integer, nullptr );
   Console::WriteLine( t3->ToString( "F", nullptr ) );

   Console::WriteLine( t1->CompareTo( t3 ) );

   Console::ReadLine();
}
