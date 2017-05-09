' System.Runtime.InteropServices.TypeLibVarAttribute
' System.Runtime.InteropServices.TypeLibVarFlags
' <Snippet1>
Imports System
Imports System.Reflection
Imports System.Runtime.InteropServices

Module D
	Public Function IsHiddenField(ByVal fi As FieldInfo) As Boolean
		Dim FieldAttributes As Object() = fi.GetCustomAttributes(GetType(TypeLibVarAttribute), True)

		If FieldAttributes.Length > 0 Then
			Dim tlv As TypeLibVarAttribute = FieldAttributes(0)
			Dim flags As TypeLibVarFlags = tlv.Value
			Return (flags & TypeLibVarFlags.FHidden) > 0
		End If
		Return False
	End Function
End Module
' </Snippet1>