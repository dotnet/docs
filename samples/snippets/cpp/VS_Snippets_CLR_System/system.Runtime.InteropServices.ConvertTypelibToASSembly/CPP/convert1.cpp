
// Convert::cpp
//<snippet1>
using namespace System;
using namespace System::Reflection;
using namespace System::Reflection::Emit;
using namespace System::Runtime::InteropServices;

enum class RegKind
{
   RegKind_Default, RegKind_Register, RegKind_None
};

ref class ConversionEventHandler: public ITypeLibImporterNotifySink
{
public:
   virtual void ReportEvent( ImporterEventKind eventKind, int eventCode, String^ eventMsg )
   {
      
      // handle warning event here...
   }

   virtual Assembly^ ResolveRef( Object^ typeLib )
   {
      
      // resolve reference here and return a correct assembly...
      return nullptr;
   }

};


[DllImport("oleaut32.dll",CharSet=CharSet::Unicode,PreserveSig=false)]
extern void LoadTypeLibEx( String^ strTypeLibName, RegKind regkind,
         [MarshalAs(UnmanagedType::Interface)] interior_ptr<Object^> typeLib );

int main()
{
   Object^ typeLib = gcnew Object;
   LoadTypeLibEx( "SHDocVw.dll", RegKind::RegKind_None,  &typeLib );
   if ( typeLib == nullptr )
   {
      Console::WriteLine( "LoadTypeLibEx failed." );
      return 0;
   }

   TypeLibConverter^ converter = gcnew TypeLibConverter;
   ConversionEventHandler^ eventHandler = gcnew ConversionEventHandler;
   AssemblyBuilder^ asmb = converter->ConvertTypeLibToAssembly( typeLib, "ExplorerLib.dll", (System::Runtime::InteropServices::TypeLibImporterFlags)0, eventHandler, nullptr, nullptr, nullptr, nullptr );
   asmb->Save( "ExplorerLib.dll" );
}
//</snippet1>
