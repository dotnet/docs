<!-- <Snippet4> -->
<%@ Page Language="VB" 
    Inherits="System.Web.UI.MobileControls.MobilePage" %>
<%@ Register TagPrefix="mobile" 
    Namespace="System.Web.UI.MobileControls" 
    Assembly="System.Web.Mobile" %>
<%@ Import Namespace="System.Web.UI.MobileControls" %>
<%@ Import Namespace="System.Drawing" %>

<script runat="server">
    '<Snippet7>
    Private Sub Form_Activate(ByVal sender As Object, _
        ByVal e As EventArgs)
        
        Form1.Wrapping = Wrapping.NoWrap
        Dim a As String = "This is a very long string <br />"
        Dim b As String = "START "
        Dim i As Integer
        
        ' Create a long string to force pagination
        For i = 0 To 100
            b &= a
        Next
        
        txtView.Text = b & " END"
        Form1.ControlToPaginate = txtView
    End Sub
    '</Snippet7>

    '<Snippet5>
    Private Sub Form_Paginated(ByVal sender As Object, _
        ByVal e As EventArgs)
        
        ' Set the background color based on 
        ' the number of pages
        If ActiveForm.PageCount > 1 Then
            ActiveForm.BackColor = Color.LightBlue
        Else
            ActiveForm.BackColor = Color.LightGray
        End If
        
        ' Check to see if the Footer template has been chosen
        If DevSpec.HasTemplates Then
            Dim lbl As System.Web.UI.MobileControls.Label
            
            ' Get the Footer panel
            Dim pan As System.Web.UI.MobileControls.Panel = Form1.Footer

            ' Get the Label from the panel
            lbl = CType(pan.FindControl("lblCount"), System.Web.UI.MobileControls.Label)
            ' Set the text in the Label
            lbl.Text = "Page #" + Form1.CurrentPage.ToString()
        End If
    End Sub
    '</Snippet5>

    '<Snippet6>
    Private Sub Page_Load(ByVal sender As Object, _
        ByVal e As EventArgs)
        
        ' Set the pager text properties
        If Not IsPostBack Then
            Form1.PagerStyle.NextPageText = "Go Next >"
        Else
            ' For postback, set different text
            Form1.PagerStyle.NextPageText = "Go More >"
            Form1.PagerStyle.PreviousPageText = "< Go Prev"
        End If
    End Sub
    '</Snippet6>
</script>

<!-- <Snippet8> -->
<html xmlns="http://www.w3.org/1999/xhtml" >
<body>
<!-- The first Form -->
    <mobile:Form ID="Form1" Runat="server" 
        Paginate="true" OnActivate="Form_Activate" 
        OnPaginated="Form_Paginated">
        <mobile:link ID="Link1" Runat="server" 
            NavigateUrl="#Form2">
            Go To Other Form
        </mobile:link>
        <mobile:Label ID="Label1" Runat="server">
            Welcome to ASP.NET
        </mobile:Label>
        <mobile:textview ID="txtView" Runat="server" />
        
        <mobile:DeviceSpecific ID="DevSpec" Runat="server">
            <Choice>
                <FooterTemplate>
                    <mobile:Label runat="server" id="lblCount" />
                </FooterTemplate>
            </Choice>
        </mobile:DeviceSpecific>

    </mobile:Form>
    
    <!-- The second Form -->
    <mobile:Form ID="Form2" Runat="server" 
        Paginate="true" OnPaginated="Form_Paginated">
        <mobile:Label ID="message2" Runat="server">
            Welcome to ASP.NET
        </mobile:Label>
        <mobile:link ID="Link2" Runat="server" 
            NavigateUrl="#Form1">Back</mobile:link>
    </mobile:Form>
</body>
</html>
<!-- </Snippet8> -->
<!-- </Snippet4> -->
