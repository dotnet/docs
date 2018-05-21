    Declare Sub SetData Lib "..\LIB\UnmgdLib.dll" (
        ByVal x As Short,
        <MarshalAsAttribute(UnmanagedType.AsAny)>
            ByVal o As Object)