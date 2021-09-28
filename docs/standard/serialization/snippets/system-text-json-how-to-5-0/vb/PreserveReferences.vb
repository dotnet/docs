Imports System.Text.Json
Imports System.Text.Json.Serialization

Namespace PreserveReferences

    Public Class Employee
        Public Property Name As String
        Public Property Manager As Employee
        Public Property DirectReports As List(Of Employee)
    End Class

    Public NotInheritable Class Program

        Public Shared Sub Main()
            Dim tyler As New Employee

            Dim adrian As New Employee

            tyler.DirectReports = New List(Of Employee) From {
                adrian}
            adrian.Manager = tyler

            Dim options As New JsonSerializerOptions With {
                .ReferenceHandler = ReferenceHandler.Preserve,
                .WriteIndented = True
            }

            Dim tylerJson As String = JsonSerializer.Serialize(tyler, options)
            Console.WriteLine($"Tyler serialized:{tylerJson}")

            Dim tylerDeserialized As Employee = JsonSerializer.Deserialize(Of Employee)(tylerJson, options)

            Console.WriteLine(
                "Tyler is manager of Tyler's first direct report: ")
            Console.WriteLine(
                tylerDeserialized.DirectReports(0).Manager Is tylerDeserialized)
        End Sub

    End Class

End Namespace

' Produces output like the following example:
'
'Tyler serialized:
'{
'  "$id": "1",
'  "Name": "Tyler Stein",
'  "Manager": null,
'  "DirectReports": {
'    "$id": "2",
'    "$values": [
'      {
'        "$id": "3",
'        "Name": "Adrian King",
'        "Manager": {
'          "$ref": "1"
'        },
'        "DirectReports": null
'      }
'    ]
'  }
'}
'Tyler is manager of Tyler's first direct report:
'True
