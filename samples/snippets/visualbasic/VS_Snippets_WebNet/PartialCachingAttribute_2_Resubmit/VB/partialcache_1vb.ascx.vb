' <snippet1>
' Create a code-behind user control that is cached
' for 20 seconds and uses the VaryByControls property
' to vary the cached control according to the value of the 
' specified control.


Namespace Samples.AspNet.VB.Controls
    ' <snippet2>
    ' Set the PartialCachingAttribute.Duration property to
    ' 20 seconds and the PartialCachingAttribute.VaryByControls
    ' property to the ID of the server control to vary the output by.
    ' In this case, it is state, the ID assigned to a DropDownList
    ' server control.
    <PartialCaching(20, Nothing, "state", Nothing)> _
    Public Class ctlSelect
        Inherits UserControl
        ' </snippet2>

        Protected Sub Page_Load(ByVal sender As [Object], ByVal e As EventArgs)
            If Not IsPostBack Then
                Label1.Text = "The control was generated at:" & DateTime.Now.ToString("T")
            End If
        End Sub 'Page_Load


        Protected Sub SubmitBtn_Click(ByVal Sender As [Object], ByVal e As EventArgs)
            Label1.Text = "You chose: " + state.SelectedItem.Text & " and " & country.SelectedItem.Text + "."
            TimeMsg.Text = DateTime.Now.ToString("T")
        End Sub 'SubmitBtn_Click
    End Class 'ctlSelect
End Namespace
' </snippet1>