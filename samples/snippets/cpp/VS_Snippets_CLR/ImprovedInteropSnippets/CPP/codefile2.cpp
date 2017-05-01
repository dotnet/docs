
// System::Runtime::InteropServices::ComImportAttribute
// System::Runtime::InteropServices::InAttribute
// System::Runtime::InteropServices::OutAttribute
// System::Runtime::InteropServices::UnmanagedType
// System::Runtime::InteropServices::VarEnum

// <Snippet2>
using namespace System;
using namespace System::Runtime::InteropServices;

// If you do not have a type library for an interface
// you can redeclare it using ComImportAttribute.
// This is how the interface would look in an idl file.
//[
//object,
//uuid("73EB4AF8-BE9C-4b49-B3A4-24F4FF657B26"),
//dual, helpstring("IMyStorage Interface"),
//pointer_default(unique)
//]
//interface IMyStorage : IDispatch
//{
// [id(1)]
// HRESULT GetItem([in] BSTR bstrName, [out, retval] IDispatch ** ppItem);
// [id(2)]
// HRESULT GetItems([in] BSTR bstrLocation, [out] SAFEARRAY(VARIANT)* pItems);
// [id(3)]
// HRESULT GetItemDescriptions([in] BSTR bstrLocation, [out] SAFEARRAY(VARIANT) ** ppItems);
// [id(4), propget]
// HRESULT get_IsEmpty([out, retval] BOOL * pfEmpty);
//};
// This is the managed declaration.

[ComImport]
[Guid("73EB4AF8-BE9C-4b49-B3A4-24F4FF657B26")]
interface class IMyStorage
{
   [DispId(1)]
   Object^ GetItem( [In,MarshalAs(UnmanagedType::BStr)]String^ bstrName );

   //[return : MarshalAs(UnmanagedType::Interface)]

   [DispId(2)]
   void GetItems( [In,MarshalAs(UnmanagedType::BStr)]String^ bstrLocation, [Out,MarshalAs(UnmanagedType::SafeArray,
   SafeArraySubType=VarEnum::VT_VARIANT)]array<Object^>^Items );

   [DispId(3)]
   void GetItemDescriptions( [In]String^ bstrLocation, [In,Out,MarshalAs(UnmanagedType::SafeArray)]array<Object^>^varDescriptions );

   property bool IsEmpty 
   {
      [DispId(4)]
      [returnvalue:MarshalAs(UnmanagedType::VariantBool)]
      bool get();
   }
};
// </Snippet2>
