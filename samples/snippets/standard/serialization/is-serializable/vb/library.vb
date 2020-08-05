' <Snippet2>
Imports System.Runtime.CompilerServices

Namespace Global.Libraries

    Public Module UtilityLibrary
        <Extension>
        Public Function IsSerializable(obj As Object) As Boolean
            If obj Is Nothing Then Return False

            Dim t As Type = obj.GetType()
            Return t.IsSerializable
        End Function
    End Module
End Namespace
' </Snippet2>
