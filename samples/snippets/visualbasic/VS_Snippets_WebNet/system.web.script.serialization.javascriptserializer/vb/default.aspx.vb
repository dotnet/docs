' <snippet1>
Imports System.Web.Script.Serialization

Public Class _Default
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Dim RegisteredUsers As New List(Of Person)()
        RegisteredUsers.Add(New Person With {.PersonID = 1, .Name = "Bryon Hetrick", .Registered = True})
        RegisteredUsers.Add(New Person With {.PersonID = 2, .Name = "Nicole Wilcox", .Registered = True})
        RegisteredUsers.Add(New Person With {.PersonID = 3, .Name = "Adrian Martinson", .Registered = False})
        RegisteredUsers.Add(New Person With {.PersonID = 4, .Name = "Nora Osborn", .Registered = False})

        Dim serializer As New JavaScriptSerializer()
        Dim serializedResult = serializer.Serialize(RegisteredUsers)
        ' Produces string value of:
        ' [
        '     {"PersonID":1,"Name":"Bryon Hetrick","Registered":true},
        '     {"PersonID":2,"Name":"Nicole Wilcox","Registered":true},
        '     {"PersonID":3,"Name":"Adrian Martinson","Registered":false},
        '     {"PersonID":4,"Name":"Nora Osborn","Registered":false}
        ' ]

        Dim deserializedResult = serializer.Deserialize(Of List(Of Person))(serializedResult)
        ' Produces List with 4 Person objects
    End Sub
End Class
' </snippet1>