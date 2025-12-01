Imports System
Imports System.Text.Json
Imports System.Text.Json.Serialization
Imports System.Text.Json.Serialization.Metadata

Namespace TryGetTypeInfoSourceGenExamples

    ' <TryGetTypeInfoSourceGen>
    <JsonSerializable(GetType(Customer))>
    Public Partial Class MyJsonContext
        Inherits JsonSerializerContext

        ' Instead of duplicating logic for each type, use TryGetTypeInfo
        Public Overrides Function GetTypeInfo(type As Type) As JsonTypeInfo
            Dim typeInfo As JsonTypeInfo = Nothing
            If Options.TryGetTypeInfo(type, typeInfo) Then
                Return typeInfo
            End If
            
            Return Nothing
        End Function

    End Class
    ' </TryGetTypeInfoSourceGen>

    Public Class Customer
        Public Sub New(name As String, email As String)
            Me.Name = name
            Me.Email = email
        End Sub
        
        Public Property Name As String
        Public Property Email As String
    End Class

End Namespace
