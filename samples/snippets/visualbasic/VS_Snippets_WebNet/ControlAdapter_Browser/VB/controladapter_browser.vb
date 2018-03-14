' <snippet1>
Imports System
Imports System.Web.UI
Imports System.Web.UI.Adapters

Public Class CustomControlAdapter
    Inherits ControlAdapter

    Protected Overrides Sub Render(ByVal writer As HtmlTextWriter)

        ' Access Browser details through the Browser property.
        Dim jScriptVersion As Version = Browser.jScriptVersion

        ' Test if the browser supports Javascript.
        If Not (jScriptVersion Is Nothing) Then
            ' Render JavaScript-aware markup.
        Else
            ' Render scriptless markup.
        End If

    End Sub 'Render 

End Class 'CustomControlAdapter
' </snippet1>

Module MainMod
    Sub Main()
    End Sub
End Module 'MainMod
