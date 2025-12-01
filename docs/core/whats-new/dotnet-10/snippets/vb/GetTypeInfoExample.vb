Imports System
Imports System.Text.Json
Imports System.Text.Json.Serialization.Metadata

Namespace GetTypeInfoExamples

    Public Class GetTypeInfoExample

        Public Shared Sub Example()
            ' <GetTypeInfoExample>
            Dim options As New JsonSerializerOptions()
            
            ' Get type info for a supported type
            Dim typeInfo As JsonTypeInfo = options.GetTypeInfo(GetType(Person))
            Console.WriteLine($"Type: {typeInfo.Type.Name}")
            Console.WriteLine($"Kind: {typeInfo.Kind}")
            
            ' Downcast to JsonTypeInfo(Of T) for strongly-typed usage
            Dim personTypeInfo As JsonTypeInfo(Of Person) = TryCast(typeInfo, JsonTypeInfo(Of Person))
            If personTypeInfo IsNot Nothing Then
                Dim person As New Person("Alice", 30)
                Dim json As String = JsonSerializer.Serialize(person, personTypeInfo)
                Console.WriteLine($"Serialized: {json}")
            End If
            ' </GetTypeInfoExample>
        End Sub

    End Class

    Public Class Person
        Public Sub New(name As String, age As Integer)
            Me.Name = name
            Me.Age = age
        End Sub
        
        Public Property Name As String
        Public Property Age As Integer
    End Class

End Namespace
