Imports System

' <Snippet1>
Public Class Base(Of TBase)
End Class
Public Class Derived(Of TDerived)
    Inherits Base(Of TDerived)
End Class
' </Snippet1>

Public Class ProgStubClass
    Shared Sub Main()
	End Sub
End Class