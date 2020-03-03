
Partial Class Default2
    Inherits System.Web.UI.Page

    ' <Snippet50>
    ' This method will be automatically bound to the Load event
    ' when AutoEventWireup is true.
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Write("Hello world")
    End Sub
    ' This method will be automatically bound to the Load event 
    ' when AutoEventWireup is true only if no overload having 
    ' object and EventArgs parameters is found.    
    Protected Sub Page_Load()
        Response.Write("Hello world")
    End Sub
    ' </Snippet50>
End Class
