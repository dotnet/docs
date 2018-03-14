//<snippet1>
#using <system.dll>

using namespace System;
using namespace System::ComponentModel;

namespace EditorBrowsableDemo
{
   public ref class Class1
   {
   public:
      Class1()
      { 
         //
         // TODO: Add constructor logic here
         //
      }

   private:
      int ageval;

   public:
      [EditorBrowsable(EditorBrowsableState::Never)]
      property int Age 
      {
         int get()
         {
            return ageval;
         }

         void set( int value )
         {
            if ( ageval != value )
            {
               ageval = value;
            }
         }
      }
   };
}
//</snippet1>
