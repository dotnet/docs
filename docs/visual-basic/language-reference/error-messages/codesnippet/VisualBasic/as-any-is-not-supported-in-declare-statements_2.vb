    Declare Sub SetData Lib "..\LIB\UnmgdLib.dll" (
        ByVal x As Short,
        <System.Runtime.InteropServices.MarshalAsAttribute(
            System.Runtime.InteropServices.UnmanagedType.AsAny)>
            ByVal o As Object)