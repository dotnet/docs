<!-- <Snippet1> -->
<%-- 
This example shows how to send a mail message from a Web Forms page 
using the classes in the System.Web.Mail namespace.
--%>

<%@ IMPORT namespace="System.Web.Mail" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script language="VB" runat="server">
    Sub Page_Load()
        If Not IsPostBack Then
            lblMsg1.Text = ""
            txtTo.Text = "john@contoso.com"
            txtFrom.Text = "marsha@contoso.com"
            txtCc.Text = "fred@contoso.com"
            txtBcc.Text = "wilma@contoso.com"
            txtSubject.Text = "Hello"
            txtBody.Text = "This is a test message."
            txtAttach.Text = "C:\Documents and Settings\All Users\Documents\My Pictures\Sample Pictures\Sunset.jpg," _
               & "C:\Documents and Settings\All Users\Documents\My Pictures\Sample Pictures\Winter.jpg"
            txtBodyEncoding.Text = Encoding.ASCII.EncodingName
            txtBodyFormat.Text = "HTML"
            txtPriority.Text = "Normal"
            txtUrlContentBase.Text = "http://www.contoso.com/images"
            txtUrlContentLocation.Text = "http://www.contoso.com/images"
            ' Name of relay mail server in your domain.
            txtMailServer.Text = "smarthost" '
        End If
    End Sub

    Sub btnSubmit_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim sTo As String, sFrom As String, sSubject As String, sBody As String
        Dim sAttach As String, sCc As String, sBcc As String, sBodyEncoding As String
        Dim sBodyFormat As String, sMailServer As String, sPriority As String
        Dim sUrlContentBase As String, sUrlContentLocation As String
        Dim iLoop1 As Integer

        sTo = Trim(txtTo.Text)
        sFrom = Trim(txtFrom.Text)
        sSubject = Trim(txtSubject.Text)
        sBody = Trim(txtBody.Text)
        sAttach = Trim(txtAttach.Text)
        sCc = Trim(txtCc.Text)
        sBcc = Trim(txtBcc.Text)
        sBodyFormat = Trim(txtBodyFormat.Text)
        sBodyEncoding = Trim(txtBodyEncoding.Text)
        sPriority = Trim(txtPriority.Text)
        sUrlContentBase = Trim(txtUrlContentBase.Text)
        sUrlContentLocation = Trim(txtUrlContentLocation.Text)
        sMailServer = Trim(txtMailServer.Text)

        Dim MyMail As MailMessage = New MailMessage()
        MyMail.From = sFrom
        MyMail.To = sTo
        MyMail.Subject = sSubject
        MyMail.Body = sBody
        MyMail.Cc = sCc
        MyMail.Bcc = sBcc
        MyMail.UrlContentBase = sUrlContentBase
        MyMail.UrlContentLocation = sUrlContentLocation

        Select Case txtBodyEncoding.Text
            Case Encoding.UTF7.EncodingName : MyMail.BodyEncoding = Encoding.UTF7
            Case Encoding.UTF8.EncodingName : MyMail.BodyEncoding = Encoding.UTF8
            Case Else : MyMail.BodyEncoding = Encoding.ASCII
        End Select

        Select Case UCase(sBodyFormat)
            Case "HTML" : MyMail.BodyFormat = MailFormat.Html
            Case Else : MyMail.BodyFormat = MailFormat.Text
        End Select
     
        Select Case UCase(sPriority)
            Case "HIGH" : MyMail.Priority = MailPriority.High
            Case "LOW" : MyMail.Priority = MailPriority.Low
            Case Else : MyMail.Priority = MailPriority.Normal
        End Select
     
        ' Build an IList of mail attachments.
        If sAttach <> "" Then
            Dim delim As Char = ","
            Dim sSubstr As String
            For Each sSubstr In sAttach.Split(delim)
                Dim myAttachment As MailAttachment = New MailAttachment(sSubstr)
                MyMail.Attachments.Add(myAttachment)
            Next
        End If
 
        SmtpMail.SmtpServer = sMailServer
        SmtpMail.Send(MyMail)

        lblMsg1.Text = "VB Message sent to " & MyMail.To
    End Sub

    Sub btnClear_Click(ByVal sender As Object, ByVal e As EventArgs)
        lblMsg1.Text = ""
        txtTo.Text = ""
        txtFrom.Text = ""
        txtSubject.Text = ""
        txtBody.Text = ""
        txtAttach.Text = ""
        txtBcc.Text = ""
        txtCc.Text = ""
        txtBodyEncoding.Text = ""
        txtBodyFormat.Text = ""
        txtPriority.Text = ""
        txtUrlContentBase.Text = ""
        txtUrlContentLocation.Text = ""
        txtMailServer.Text = ""
        btnSubmit.Text = "Submit"
    End Sub
</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
    <head>
    <title>Send a new mail message:</title>
</head>
    <body>
   <h4>Send a new mail message:</h4>
   <form id="form1" method="Post" action="MailForm.aspx" runat="server">
      <table style="width:350; background-color:#FFFF99">
         <tr>
            <td align="Right"><b>To:</b></td>
            <td><Asp:Textbox id="txtTo" runat="server"/></td>
         </tr>
         <tr>
            <td align="Right"><b>From:</b></td>
            <td><Asp:Textbox id="txtFrom" runat="server"/></td>
         </tr>
         <tr>
            <td align="Right"><b>Subject:</b></td>
            <td><Asp:Textbox id="txtSubject" runat="server"/></td>
         </tr>
         <tr>
            <td align="Right"><b>MessageBody:</b></td>
            <td><Asp:Textbox id="txtBody" runat="server"/></td>
         </tr>
         <tr>
            <td align="Right"><b>Attachments:</b></td>
            <td><Asp:Textbox id="txtAttach" runat="server"/></td>
         </tr>
         <tr>
            <td align="Right"><b>CC:</b></td>
            <td><Asp:Textbox id="txtBcc" runat="server"/></td>
         </tr>
         <tr>
            <td align="Right"><b>BCC:</b></td>
            <td><Asp:Textbox id="txtCc" runat="server"/></td>
         </tr>
         <tr>
            <td align="Right"><b>BodyEncoding:</b></td>
            <td><Asp:Textbox id="txtBodyEncoding" runat="server"/></td>
         </tr>
         <tr>
            <td align="Right"><b>BodyFormat:</b></td>
            <td><Asp:Textbox id="txtBodyFormat" runat="server"/></td>
         </tr>
         <tr>
            <td align="Right"><b>Priority:</b></td>
            <td><Asp:Textbox id="txtPriority" runat="server"/></td>
         </tr>
         <tr>
            <td align="Right"><b>URL Content Base:</b></td>
            <td><Asp:Textbox id="txtUrlContentBase" runat="server"/></td>
         </tr>
         <tr>
            <td align="Right"><b>URL Content Location:</b></td>
            <td><Asp:Textbox id="txtUrlContentLocation" runat="server"/></td>
         </tr>
         <tr>
            <td align="Right"><b>Mail Server:</b></td>
            <td><Asp:Textbox id="txtMailServer" runat="server"/></td>
         </tr>
      </table><br />

      <asp:button id="btnSubmit" Text="Submit" OnClick="btnSubmit_Click" runat="server"/>
      <asp:button id="btnClear" Text="Clear" OnClick="btnClear_Click" runat="server"/>
      <p><asp:Label id="lblMsg1" runat="server"/></p>
   </form>
   </body>
</html>
<!-- </Snippet1> -->