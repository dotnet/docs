<!-- <Snippet1> -->
<%@ Page Language="VB" 
    Inherits="System.Web.UI.MobileControls.MobilePage" %>
<%@ Register TagPrefix="mobile" 
    Namespace="System.Web.UI.MobileControls" 
    Assembly="System.Web.Mobile" %>
<%@ Import Namespace="System.Web.UI.MobileControls" %>
<%@ Import Namespace="System.Drawing" %>

<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        If Not IsPostBack Then
            StyleSheet1("Style1").ForeColor = Color.Red
            StyleSheet1("Style1").Font.Size = _
                System.Web.UI.MobileControls.FontSize.Large
            StyleSheet1("Style1").Font.Bold = BooleanOption.True
            StyleSheet1("Style1").Font.Italic = BooleanOption.True
            StyleSheet1("Style2").ForeColor = Color.Blue
            StyleSheet1("Style2").Font.Size = _
                System.Web.UI.MobileControls.FontSize.Normal
            StyleSheet1("Style2").Font.Bold = BooleanOption.False
            StyleSheet1("Style2").Font.Italic = BooleanOption.True
            StyleSheet1("Style3").ForeColor = Color.Green
            StyleSheet1("Style3").Font.Size = _
                System.Web.UI.MobileControls.FontSize.Small
            StyleSheet1("Style3").Font.Bold = BooleanOption.False
            StyleSheet1("Style3").Font.Italic = BooleanOption.False
        End If
    End Sub

    Private Sub SelectStyle(ByVal sender As Object, _
        ByVal e As EventArgs)

        ' Retrieve the style name as a string.
        Dim myStyle As String = SelectionList1.Selection.ToString()

        ' Match the style name and apply the style to TextView1.
        Select Case myStyle
            Case "hot"
                TextView1.StyleReference = "Style1"
            Case "medium"
                TextView1.StyleReference = "Style2"
            Case "mild"
                TextView1.StyleReference = "Style3"
        End Select
    End Sub
</script>

<html xmlns="http:'www.w3.org/1999/xhtml" >
<body>
    <mobile:StyleSheet id="StyleSheet1" runat="server">
        <mobile:Style Name="Style1" Font-Name="Arial"
            BackColor="#E0E0E0" Wrapping="Wrap">
        </mobile:Style>
        <mobile:Style Name="Style2" Font-Name="Arial"
            BackColor="blue" Wrapping="NoWrap">
        </mobile:Style>
        <mobile:Style Name="Style3" Font-Name="Arial Narrow"
            BackColor="Green" Wrapping="NoWrap">
        </mobile:Style>
    </mobile:StyleSheet>

    <mobile:Form id="Form1" runat="server">
        <mobile:Label id="Label1" runat="server" 
            Text="Today's Special" StyleReference="title" />
        <mobile:TextView id="TextView1" runat="server" 
            StyleReference="Style1">Chili
        </mobile:TextView>
        <mobile:SelectionList runat="server" id="SelectionList1">
           <item Text="hot" Value="hot"/>
           <item Text="medium" Value="medium"/>
           <item Text="mild" Value="mild"/>
        </mobile:SelectionList>
        <mobile:Command ID="Command1" runat="server" 
           Text="Select Style" OnClick="SelectStyle" />
    </mobile:Form>
</body>
</html>
<!-- </Snippet1> -->
