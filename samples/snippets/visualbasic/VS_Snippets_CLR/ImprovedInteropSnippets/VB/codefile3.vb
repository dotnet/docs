' System.Assembly.GetCustomAttributes
' System.Runtime.InteropServices.ImportedFromTypeLibAttribute
' <Snippet3>
Imports System
Imports System.Reflection
Imports System.Runtime.InteropServices

Module A
	Public Function IsCOMAssembly(ByVal a As System.Reflection.Assembly) As Boolean

		Dim AsmAttributes As Object() = a.GetCustomAttributes(GetType(ImportedFromTypeLibAttribute), True)
		If AsmAttributes.Length = 1 Then
			Dim imptlb As ImportedFromTypeLibAttribute = AsmAttributes(0)
			Dim strImportedFrom As String = imptlb.Value

			' Print out the the name of the DLL from which the assembly is imported.
			Console.WriteLine("Assembly " + a.FullName + " is imported from " + strImportedFrom)

			Return True
		End If

		' This is not a COM assembly.
		Console.WriteLine("Assembly " + a.FullName + " is not imported from COM")

		Return False
	End Function
End Module
' </Snippet3>