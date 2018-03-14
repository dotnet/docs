' System.Runtime.InteropServices.ComImportAttribute
' System.Runtime.InteropServices.InAttribute
' System.Runtime.InteropServices.OutAttribute
' System.Runtime.InteropServices.UnmanagedType
' System.Runtime.InteropServices.VarEnum

'Imports System.Reflection

' <Snippet2>
Imports System
Imports System.Runtime.InteropServices

Module MyModule
	' If you do not have a type library for an interface
	' you can redeclare it using ComImportAttribute.

	' This is how the interface would look in an idl file.

	'[
	'object,
	'uuid("73EB4AF8-BE9C-4b49-B3A4-24F4FF657B26"),
	'dual,	helpstring("IMyStorage Interface"),
	'pointer_default(unique)
	']
	'interface IMyStorage : IDispatch
	'{
	'	[id(1)]
	'	HRESULT GetItem([in] BSTR bstrName, [out, retval] IDispatch ** ppItem);
	'	[id(2)]
	'	HRESULT GetItems([in] BSTR bstrLocation, [out] SAFEARRAY(VARIANT)* pItems);
	'	[id(3)]
	'	HRESULT GetItemDescriptions([in] BSTR bstrLocation, [out] SAFEARRAY(VARIANT) ** ppItems);
	'	[id(4), propget]
	'	HRESULT get_IsEmpty([out, retval] BOOL * pfEmpty);
	'};

	' This is the managed declaration.

	<ComImport(), Guid("73EB4AF8-BE9C-4b49-B3A4-24F4FF657B26")> _
	Public Interface IMyStorage
		<DispId(1)> _
		Function GetItem(<InAttribute(), MarshalAs(UnmanagedType.BStr)> ByVal bstrName As String) _
		   As <MarshalAs(UnmanagedType.Interface)> Object

		<DispId(2)> _
		Function GetItems(<InAttribute(), MarshalAs(UnmanagedType.BStr)> ByVal bstrLocation As String, _
		   <OutAttribute(), MarshalAs(UnmanagedType.SafeArray, SafeArraySubType := VarEnum.VT_VARIANT)> _
                                      ByVal Items() As Object)

		<DispId(3)> _
		Function GetItemDescriptions(<InAttribute()> ByVal bstrLocation As String, _
		   <InAttribute(), OutAttribute(), _
                      MarshalAs(UnmanagedType.SafeArray)> ByRef varDescriptions() As Object)

		<DispId(4)> _
		ReadOnly Property IsEmpty(<MarshalAs(UnmanagedType.VariantBool)> ByVal bEmpty As Boolean)

	End Interface
End Module
' </Snippet2>