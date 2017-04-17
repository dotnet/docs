' System.Runtime.InteropServices.TypeLibFuncAttribute
' System.Runtime.InteropServices.TypeLibFuncFlags
' <Snippet5>
Imports System
Imports System.Reflection
Imports System.Runtime.InteropServices

Module C
	Public Function IsHiddenMethod(ByVal mi As MethodInfo) As Boolean
		Dim MethodAttributes As Object() = mi.GetCustomAttributes(GetType(TypeLibFuncAttribute), True)

		If MethodAttributes.Length > 0 Then
			Dim tlf As TypeLibFuncAttribute = MethodAttributes(0)
			Dim flags As TypeLibFuncFlags = tlf.Value
			Return (flags & TypeLibFuncFlags.FHidden) > 0
		End If
		Return False
	End Function
End Module
' </Snippet5>