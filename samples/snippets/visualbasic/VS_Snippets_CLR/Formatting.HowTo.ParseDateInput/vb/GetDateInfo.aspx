<!-- <Snippet1> -->

<%@ Page Language="VB" %>
<%@ Import  Namespace="System.Globalization" %> 
<%@ Assembly Name="System.Core" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

    Protected Sub OKButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles OKButton.Click
        Dim locale As String = ""
        Dim styles As DateTimeStyles = DateTimeStyles.AllowInnerWhite Or DateTimeStyles.AllowLeadingWhite Or _
                                       DateTimeStyles.AllowTrailingWhite
        Dim inputDate, localDate As Date
        Dim localDateOffset As DateTimeOffset
        Dim integerOffset As Integer
        Dim result As Boolean

        ' Exit if input is absent.
        If String.IsNullOrEmpty(Me.DateString.Text) Then Exit Sub

        ' Hide form elements.
        Me.DateForm.Visible = False

        ' Create array of CultureInfo objects
        Dim cultures(Request.UserLanguages.Length) As CultureInfo
        For ctr As Integer = Request.UserLanguages.GetLowerBound(0) To Request.UserLanguages.GetUpperBound(0)
            locale = Request.UserLanguages(ctr)
            If Not String.IsNullOrEmpty(locale) Then
                ' Remove quality specifier, if present.
                If locale.Contains(";") Then _
                   locale = Left(locale, InStr(locale, ";") - 1)
                Try
                   cultures(ctr) = New CultureInfo(Request.UserLanguages(ctr), False)
                Catch
                End Try
            Else
                cultures(ctr) = CultureInfo.CurrentCulture
            End If
        Next
        cultures(Request.UserLanguages.Length) = CultureInfo.InvariantCulture
        ' Parse input using each culture.
        For Each culture As CultureInfo In cultures
            result = Date.TryParse(Me.DateString.Text, culture.DateTimeFormat, styles, inputDate)
            If result Then Exit For
        Next
        ' Display result to user.
        If result Then
            Response.Write("<P />")
            Response.Write("The date you input was " + Server.HtmlEncode(CStr(Me.DateString.Text)) + "<BR />")
        Else
            ' Unhide form.
            Me.DateForm.Visible = True
            Response.Write("<P />")
            Response.Write("Unable to recognize " + Server.HtmlEncode(Me.DateString.Text) + ".<BR />")
        End If

        ' Get date and time information from hidden field.
        Dim dates() As String = Request.Form.Item("DateInfo").Split(";")

        ' Parse local date using each culture.
        For Each culture As CultureInfo In cultures
            result = Date.TryParse(dates(0), culture.DateTimeFormat, styles, localDate)
            If result Then Exit For
        Next
        ' Parse offset 
        result = Integer.TryParse(dates(1), integerOffset)
        ' Instantiate DateTimeOffset object representing user's local time
        If result Then
            Try
                localDateOffset = New DateTimeOffset(localDate, New TimeSpan(0, -integerOffset, 0))
            Catch ex As Exception
                result = False
            End Try
        End If
        ' Display result to user.
        If result Then
            Response.Write("<P />")
            Response.Write("Your local date and time is " + localDateOffset.ToString() + ".<BR />")
            Response.Write("The date and time on the server is " & _
                           TimeZoneInfo.ConvertTime(localDateOffset, _
                                                    TimeZoneInfo.Local).ToString() & ".<BR />")
            Response.Write("Coordinated Universal Time is " + localDateOffset.ToUniversalTime.ToString() + ".<BR />")
        Else
            Response.Write("<P />")
            Response.Write("Unable to recognize " + Server.HtmlEncode(dates(0)) & ".<BR />")
        End If
    End Sub

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        Dim script As String = "function AddDateInformation() { " & vbCrLf & _
                  "var today = new Date();" & vbCrLf & _
                  "document.DateForm.DateInfo.value = today.toLocaleString() + " & Chr(34) & Chr(59) & Chr(34) & " + today.getTimezoneOffset();" & vbCrLf & _
                  " }"
        ' Register client script
        Dim scriptMgr As ClientScriptManager = Page.ClientScript
        scriptMgr.RegisterClientScriptBlock(Me.GetType(), "SubmitOnClick", script, True)
    End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Parsing a Date and Time Value</title>
</head>
<body>
    <form id="DateForm" runat="server">
    <div>
    <center>
       <asp:Label ID="Label1" runat="server" Text="Enter a Date and Time:" Width="248px"></asp:Label>
       <asp:TextBox ID="DateString" runat="server" Width="176px"></asp:TextBox><br />
    </center>       
    <br />
    <center>
    <asp:Button ID="OKButton" runat="server" Text="Button"  
            OnClientClick="AddDateInformation()" onclick="OKButton_Click" />
    <asp:HiddenField ID="DateInfo"  Value=""  runat="server" />
    </center>
    <br />
    </div>
    </form>
</body>
</html>
<!-- </Snippet1> -->
