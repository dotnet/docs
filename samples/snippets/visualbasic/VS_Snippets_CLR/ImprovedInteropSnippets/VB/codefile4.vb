' System.Runtime.InteropServices.TypeLibTypeAttribute
' System.Runtime.InteropServices.TypeLibTypeFlags
'Imports System.Reflection
' <Snippet4>

Imports System
Imports System.Runtime.InteropServices

Module B
	Public Function IsHiddenInterface(ByVal InterfaceType As Type) As Boolean
		Dim InterfaceAttributes As Object() = _
		InterfaceType.GetCustomAttributes(GetType(TypeLibTypeAttribute), False)

		If InterfaceAttributes.Length > 0 Then
			Dim tlt As TypeLibTypeAttribute = InterfaceAttributes(0)
			Dim flags As TypeLibTypeFlags = tlt.Value
			Return (flags & TypeLibTypeFlags.FHidden) > 0
		End If

		Return False
	End Function
End Module
' </Snippet4>