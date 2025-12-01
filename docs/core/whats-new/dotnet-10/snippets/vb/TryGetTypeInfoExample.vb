Imports System
Imports System.Text.Json
Imports System.Text.Json.Serialization.Metadata

Namespace TryGetTypeInfoExamples

    Public Class TryGetTypeInfoExample

        Public Shared Sub Example()
            ' <TryGetTypeInfoExample>
            Dim options As New JsonSerializerOptions()
            
            ' Try to get type info for a type
            Dim typeInfo As JsonTypeInfo = Nothing
            If options.TryGetTypeInfo(GetType(Product), typeInfo) Then
                Console.WriteLine($"Type info found for {typeInfo.Type.Name}")
                Console.WriteLine($"Kind: {typeInfo.Kind}")
                
                ' Use the type info for serialization
                Dim product As New Product("Widget", 19.99D)
                Dim json As String = JsonSerializer.Serialize(product, typeInfo.Type, options)
                Console.WriteLine($"Serialized: {json}")
            Else
                Console.WriteLine("Type info not found")
            End If
            ' </TryGetTypeInfoExample>
        End Sub

    End Class

    Public Class Product
        Public Sub New(name As String, price As Decimal)
            Me.Name = name
            Me.Price = price
        End Sub
        
        Public Property Name As String
        Public Property Price As Decimal
    End Class

End Namespace
