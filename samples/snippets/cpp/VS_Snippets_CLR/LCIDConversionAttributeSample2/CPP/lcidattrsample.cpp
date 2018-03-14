
//<Snippet1>
using namespace System;
using namespace System::Runtime::InteropServices;
using namespace System::Reflection;

#define LCID_INSTALLED 1
#define LCID_SUPPORTED 2

ref class LCIDAttrSample
{
public:

   // Position of the LCID argument

   [DllImport("KERNEL32.DLL",EntryPoint="IsValidLocale",SetLastError=true,CharSet=CharSet::Auto)]
   [LCIDConversionAttribute(0)]
   static bool IsValidLocale( int dwFlags ); // options

   void CheckCurrentLCID()
   {
      MethodInfo^ mthIfo = this->GetType()->GetMethod( "IsValidLocale" );
      Attribute^ attr = Attribute::GetCustomAttribute( mthIfo, LCIDConversionAttribute::typeid );
      if ( attr != nullptr )
      {
         LCIDConversionAttribute^ lcidAttr = dynamic_cast<LCIDConversionAttribute^>(attr);
         Console::WriteLine( "Position of the LCID argument in the unmanaged signature: {0}", lcidAttr->Value );
      }

      bool res = IsValidLocale( LCID_INSTALLED );
      Console::WriteLine( "Result LCID_INSTALLED {0}", res );
      res = IsValidLocale( LCID_SUPPORTED );
      Console::WriteLine( "Result LCID_SUPPORTED {0}", res );
   }
};

int main()
{
   LCIDAttrSample^ smpl = gcnew LCIDAttrSample;
   smpl->CheckCurrentLCID();
}
//</Snippet1>
