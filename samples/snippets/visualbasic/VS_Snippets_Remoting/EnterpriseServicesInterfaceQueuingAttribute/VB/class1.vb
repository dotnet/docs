 ' <snippet0>
Imports System
Imports System.EnterpriseServices
Imports System.Reflection


' References:
' System.EnterpriseServices

' <snippet1>
<InterfaceQueuing()>  _
Public Interface IInterfaceQueuingAttribute_Ctor
End Interface 'IInterfaceQueuingAttribute_Ctor
' </snippet1>

' <snippet2>
<InterfaceQueuing(True)>  _
Public Interface IInterfaceQueuingAttribute_Ctor_Bool
End Interface 'IInterfaceQueuingAttribute_Ctor_Bool
' </snippet2>

' </snippet0>

'add Main so code compiles
Public Class Test

    Public Shared Sub Main()

    End Sub 'Main
End Class 'Test 