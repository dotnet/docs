'Types:System.Runtime.InteropServices.ClassInterfaceType Vendor: Richter
'<snippet1>
Imports System
Imports System.Runtime.InteropServices


' Have the CLR expose a class interface (derived from IDispatch) for this type.
' COM clients can call the  members of this class using the Invoke method from the IDispatch interface.
<ClassInterface(ClassInterfaceType.AutoDispatch)> _
Public Class AClassUsableViaCOM

    Public Sub New()

    End Sub

    Public Function Add(ByVal x As Int32, ByVal y As Int32) As Int32
        Return x + y

    End Function
End Class
' The CLR does not expose a class interface for this type.
' COM clients can call the members of this class using the methods from the IComparable interface.
<ClassInterface(ClassInterfaceType.None)> _
Public Class AnotherClassUsableViaCOM
    Implements IComparable

    Public Sub New()

    End Sub

    Function CompareTo(ByVal o As [Object]) As Int32 Implements IComparable.CompareTo
        Return 0

    End Function 'IComparable.CompareTo
End Class
' </snippet1>