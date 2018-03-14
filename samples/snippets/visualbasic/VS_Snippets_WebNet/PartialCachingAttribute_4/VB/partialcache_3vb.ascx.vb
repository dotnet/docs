' <snippet1>
' Create a code-behind user control that is cached
' for 20 seconds and uses the VaryByCustom property
' to vary the cached control according to the type of browser
' that makes the request for the user control.

' <snippet2>
' Set the PartialCachingAttribute.Duration property to
' 20 seconds and the PartialCachingAttribute.VaryByCustom
' property to browser.
<PartialCaching(20, Nothing, Nothing, "browser")> _
Public Class ctlSelect
    Inherits UserControl
    ' </snippet2>

    Protected Sub Page_Load(ByVal sender As [Object], ByVal e As EventArgs)
        If Not IsPostBack Then
            TimeMsg.Text = DateTime.Now.ToString("T")
        End If
    End Sub 'Page_Load


    Protected Sub SubmitBtn_Click(ByVal Sender As [Object], ByVal e As EventArgs)
        Label1.Text = "You chose: " + state.SelectedItem.Text + " and " + country.SelectedItem.Text + "."
        TimeMsg.Text = DateTime.Now.ToString("T")
    End Sub 'SubmitBtn_Click
End Class 'ctlSelect
' </snippet1>

