Imports System.Collections.Immutable
Imports System.Runtime.InteropServices
Imports System.Text.Json
Imports System.Text.Json.Serialization

Namespace GuidReferenceResolverExample

    Public Class Person
        Friend Property Id As Guid
        Public Property Name As String
        Public Property Spouse As Person
    End Class

    Public Class GuidReferenceResolver
        Inherits ReferenceResolver
        Private ReadOnly _people As New Dictionary(Of Guid, Person)

        Public Overrides Function ResolveReference(referenceId As String) As Object
            Dim id As New Guid
            Dim p As Person = Nothing
            _people.TryGetValue(id, p)

            Return p
        End Function

        Public Overrides Function GetReference(value As Object, <Out> ByRef alreadyExists As Boolean) As String
            Dim person1 As Person = CType(value, Person)
            alreadyExists = _people.ContainsKey(person1.Id)
            If Not alreadyExists Then
                _people(person1.Id) = person1
            End If

            Return person1.Id.ToString()
        End Function

        Public Overrides Sub AddReference(reference As String, value As Object)
            Dim id As New Guid
            Dim person1 As Person = CType(value, Person)
            person1.Id = id
            _people(id) = person1
        End Sub

    End Class

    Module Program

        Public Sub Main()
            Dim tyler As New Person
            Dim adrian As New Person
            tyler.Spouse = adrian
            adrian.Spouse = tyler
            Dim people As ImmutableArray(Of Person) = ImmutableArray.Create(tyler, adrian)

            Dim options As New JsonSerializerOptions With {
                .WriteIndented = True,
                .ReferenceHandler = New ReferenceHandler(Of GuidReferenceResolver)
            }

            Dim json As String = JsonSerializer.Serialize(people, options)
            Console.WriteLine($"Output JSON {json}")

            Dim peopleDeserialized As List(Of Person) = JsonSerializer.Deserialize(Of List(Of Person))(json, options)

            Dim tylerDeserialized As Person = peopleDeserialized(0)
            Dim adrianDeserialized As Person = peopleDeserialized(1)

            Console.WriteLine($"Adrian is Tyler's spouse: {tylerDeserialized.Equals(adrianDeserialized.Spouse)}")
            Console.WriteLine($"Tyler is Adrian's spouse: {adrianDeserialized.Equals(tylerDeserialized.Spouse)}")
        End Sub

    End Module
End Namespace

' Produces output like the following example:
'
'Output JSON[
'  {
'    "$id": "79301726-9d94-499a-8cdc-0c8bcc4c9b63",
'    "Name": "Tyler",
'    "Spouse": {
'      "$id": "94833059-35f2-4fdd-96ee-94fd0484969a",
'      "Name": "Adrian",
'      "Spouse": {
'        "$ref": "79301726-9d94-499a-8cdc-0c8bcc4c9b63"
'      }
'  }
'  },
'  {
'    "$ref": "94833059-35f2-4fdd-96ee-94fd0484969a"
'  }
']
'Adrian is Tyler's spouse: True
'Tyler is Adrian's spouse: True
