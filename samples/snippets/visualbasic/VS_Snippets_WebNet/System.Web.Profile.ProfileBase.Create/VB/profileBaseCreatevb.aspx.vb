Imports System.Web.Profile

Class MyCustomProfile
    Inherits ProfileBase
    Dim ZipCode_value As String
    Property ZipCode() As String
        Get
            Return ZipCode_value
        End Get
        Set(ByVal value As String)
            ZipCode_value = value
        End Set
    End Property
End Class

Partial Class profileBaseCreatevb
    Inherits System.Web.UI.Page

    Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        '<Snippet1>
        Dim myProfile As MyCustomProfile = CType(ProfileBase.Create("username"), MyCustomProfile)
        myProfile.ZipCode = "98052"
        myProfile.Save()
        '</Snippet1>
        '<Snippet2>
        Dim profile As MyCustomProfile = CType(ProfileBase.Create("username", True), MyCustomProfile)
        profile.ZipCode = "98052"
        profile.Save()
        '</Snippet2>
    End Sub
End Class
