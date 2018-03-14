

#using <System.dll>

using namespace System;

// <Snippet1>
namespace InteropServices
{
   [AttributeUsage(AttributeTargets::Method|
   AttributeTargets::Field|
   AttributeTargets::Property)
   ]
   public ref class DispIdAttribute: public Attribute
   {
   public:
      DispIdAttribute( int value )
      {
         // . . .
      }

      property int Value 
      {
         int get()
         {
            // . . .
            return 0;
         }
      }
   };
}
// </Snippet1>
