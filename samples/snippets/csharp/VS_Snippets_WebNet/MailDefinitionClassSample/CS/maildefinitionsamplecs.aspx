<!-- <Snippet1> -->
<%@ page language="C#"%>
<%@ import namespace="System.Net.Mail"%>
<%@ import namespace="System.Reflection"%>
<%@ import namespace="System.Collections.Specialized"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

    HtmlTable ShowMessage(System.Net.Mail.MailMessage msg)
    {
        HtmlTable table = new HtmlTable();
        HtmlTableRow topRow = new HtmlTableRow();
        HtmlTableCell fieldHeaderCell = new HtmlTableCell();
        HtmlTableCell valueHeaderCell = new HtmlTableCell();
        fieldHeaderCell.InnerText = "Field";
        topRow.Cells.Add(fieldHeaderCell);
        valueHeaderCell.InnerText = "Value";
        topRow.Cells.Add(valueHeaderCell);
        table.Rows.Add(topRow);
        
        foreach(PropertyInfo p in msg.GetType().GetProperties())
        {
            HtmlTableRow row = new HtmlTableRow();
            
            HtmlTableCell labelCell = new HtmlTableCell();
            
            HtmlTableCell valueCell = new HtmlTableCell();
 
            if (!((p.Name == "Headers") ||
                  (p.Name == "Fields")  ||
                  (p.Name == "Attachments")))
            {            
                labelCell.InnerText = String.Format("{0}",p.Name);
                row.Cells.Add(labelCell);

                valueCell.InnerText = String.Format("{0}",p.GetValue(msg,null));
                row.Cells.Add(valueCell);
            }
            
            table.Rows.Add(row);
        }
        
        return table;
    }
    
    System.Net.Mail.MailMessage CreateMessage()
    {
        // <Snippet2>
        MailDefinition md = new MailDefinition();
        // </Snippet2>
        // <Snippet3>
        md.BodyFileName = sourceMailFile.Text;
        // </Snippet3>
        // <Snippet4>
        md.CC = sourceCC.Text;
        // </Snippet4>
        // <Snippet5>
        md.From = sourceFrom.Text;
        // </Snippet5>
        // <Snippet6>
        md.Subject = sourceSubject.Text;
        // </Snippet6>
        // <Snippet10>
        if (sourcePriority.SelectedValue == "Normal")
        {
            md.Priority = MailPriority.Normal;
        }
        else if (sourcePriority.SelectedValue == "High")
        {
            md.Priority = MailPriority.High;
        }
        else if (sourcePriority.SelectedValue == "Low")
        {
            md.Priority = MailPriority.Low;
        }
        // </Snippet10>
        
        // <Snippet7>
        ListDictionary replacements = new ListDictionary();
        replacements.Add("<%To%>",sourceTo.Text);
        replacements.Add("<%From%>", md.From);
        // </Snippet7>
        if (true == useFile.Checked)
        { 
            // <Snippet8>
            System.Net.Mail.MailMessage fileMsg;
            fileMsg = md.CreateMailMessage(sourceTo.Text, replacements, this); 
            // </Snippet8>
            return fileMsg;
        } 
        else
        {
            // <Snippet9>
            System.Net.Mail.MailMessage textMsg;
            textMsg = md.CreateMailMessage(sourceTo.Text, replacements, sourceBodyText.Text, this);
            // </Snippet9>
            return textMsg;
        }
    }
    
    void createEMail_Click(object sender, System.EventArgs e)
    {
        System.Net.Mail.MailMessage msg = CreateMessage();
        
        PlaceHolder1.Controls.Add(ShowMessage(msg));          
    }
    
    void sendEMail_Click(object sender, System.EventArgs e)
    {
        System.Net.Mail.MailMessage msg = CreateMessage();
        
        PlaceHolder1.Controls.Add(ShowMessage(msg));          
        
        errorMsg.Text = String.Empty;
        try {
            SmtpClient sc = new SmtpClient();
            sc.Send(msg);
        }
        catch (HttpException ex) {
          errorMsg.Text = ex.ToString();
        }
    }
    
</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
    <head runat="server">
    <title>Create an e-mail message</title>
</head>
<body>
        <form id="Form1" runat="server">
            <table id="Table1" cellspacing="1" 
                style="padding:1; width:450px; text-align:center">
                <tr>
                    <td align="center" colspan="3">
                        <h3>Create an e-mail message</h3>
                    </td>
                </tr>
                <tr>
                    <td align="right">To:</td>
                    <td style="WIDTH: 10px">
                    </td>
                    <td>
                        <asp:textbox id="sourceTo" runat="server" columns="54">
                        </asp:textbox>&nbsp;
                        <asp:requiredfieldvalidator id="RequiredFieldValidator1" 
                          runat="server" errormessage="*" controltovalidate="sourceTo">
                        </asp:requiredfieldvalidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">Cc:</td>
                    <td style="WIDTH: 10px">
                    </td>
                    <td>
                        <asp:textbox id="sourceCC" runat="server" columns="54">
                        </asp:textbox>&nbsp;</td>
                </tr>
                <tr>
                    <td align="right">From:</td>
                    <td style="WIDTH: 10px">
                    </td>
                    <td>
                        <asp:textbox id="sourceFrom" runat="server" columns="54">
                        </asp:textbox>&nbsp;
                        <asp:requiredfieldvalidator id="RequiredFieldValidator2" 
                          runat="server" errormessage="*" controltovalidate="sourceFrom">
                        </asp:requiredfieldvalidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">Subject:</td>
                    <td style="WIDTH: 10px">
                    </td>
                    <td>
                        <asp:textbox id="sourceSubject" runat="server" columns="54">
                        </asp:textbox>&nbsp;</td>
                </tr>
                <tr>
                    <td align="right">
                    Priority</td>
                    <td style="WIDTH: 10px">
                    </td>
                    <td>
                        <asp:dropdownlist id="sourcePriority" runat="server">
                            <asp:listitem value="Low">Low</asp:listitem>
                            <asp:listitem value="Normal" selected="true">Normal
                            </asp:listitem>
                            <asp:listitem value="High">High</asp:listitem>
                        </asp:dropdownlist>&nbsp;</td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td align="right">Source:</td>
                    <td style="WIDTH: 10px">
                    </td>
                    <td>
                        <table id="Table2" cellspacing="1" cellpadding="1" width="100%">
                            <tr>
                                <td style="WIDTH: 100px">
                                    <asp:radiobutton id="useFile" runat="server" text="Use file" 
                                      width="80px" groupname="textSource" checked="True">
                                    </asp:radiobutton>&nbsp;</td>
                                <td style="WIDTH: 11px">
                                </td>
                                <td>
                                    <p style="text-align:right">File name:</p>
                                </td>
                                <td>
                                    <asp:textbox id="sourceMailFile" runat="server" columns="22">
                                    mail.txt</asp:textbox>&nbsp;</td>
                            </tr>
                            <tr>
                                <td style="WIDTH: 100px">
                                    <asp:radiobutton id="useText" runat="server" 
                                        text="Enter text" width="80px" height="22px" 
                                        groupname="textSource">
                                    </asp:radiobutton>&nbsp;</td>
                                <td style="WIDTH: 11px">
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td align="center" colspan="3">
                        <asp:textbox id="sourceBodyText" runat="server" columns="51" 
                            textmode="MultiLine" rows="15">
                        </asp:textbox>&nbsp;</td>
                </tr>
                <tr>
                    <td align="center" colspan="3">
                        <asp:button id="createEMail" runat="server" 
                            text="Create e-mail and display only"
                            onclick="createEMail_Click">
                        </asp:button>
                        <asp:button id="sendEMail" runat="server" 
                            text="Create e-mail and send">
                        </asp:button></td>
                </tr>
            </table>
            <p>&nbsp;</p>
            <p>
                <asp:placeholder id="PlaceHolder1" runat="server">
                </asp:placeholder>&nbsp;
            </p>
            <p>
                <asp:literal id="errorMsg" runat="server">
                </asp:literal>
            </p>
        </form>
    </body>
</html>
<!-- </Snippet1> -->
