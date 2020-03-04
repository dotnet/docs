
// <snippet1>
using namespace System;
using namespace System::Reflection;
using namespace System::Reflection::Emit;
using namespace System::Runtime::InteropServices;

[ComImport,
GuidAttribute("00020406-0000-0000-C000-000000000046"),
InterfaceTypeAttribute(ComInterfaceType::InterfaceIsIUnknown),
ComVisible(false)]
interface class UCOMICreateITypeLib
{
   void CreateTypeInfo();
   void SetName();
   void SetVersion();
   void SetGuid();
   void SetDocString();
   void SetHelpFileName();
   void SetHelpContext();
   void SetLcid();
   void SetLibFlags();
   void SaveAllChanges();
};

public ref class ConversionEventHandler: public ITypeLibExporterNotifySink
{
public:
   virtual void ReportEvent( ExporterEventKind eventKind, int eventCode, String^ eventMsg )
   {
      // Handle the warning event here.
   }

   virtual Object^ ResolveRef( Assembly^ a )
   {
      // Resolve the reference here and return a correct type library.
      return nullptr;
   }
};

int main()
{
   Assembly^ a = Assembly::LoadFrom( "MyAssembly.dll" );
   TypeLibConverter^ converter = gcnew TypeLibConverter;
   ConversionEventHandler^ eventHandler = gcnew ConversionEventHandler;
   UCOMICreateITypeLib^ typeLib = dynamic_cast<UCOMICreateITypeLib^>(converter->ConvertAssemblyToTypeLib( a, "MyTypeLib.dll", static_cast<TypeLibExporterFlags>(0), eventHandler ));
   typeLib->SaveAllChanges();
}
// </snippet1>
