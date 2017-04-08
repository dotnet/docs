<%--
    The following program demonstrates the 'ResponseEncoding' property and 'MapPath'
    method of 'Page' class.
    
    This program provides two textboxes and a button as user interface for entering     a subfolder's name(in which
    the .aspx file belongs) and a filename.  When the button click event occurs it reads the content of the 
    specified file and displays the  content on the browser.
--%>
<%@ Page language="VB" ResponseEncoding="iso-8859-1" %>
<%@ import namespace="System.IO" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <script language="VB" runat="server">
        Sub ReadFile(Sender As Object,e As  EventArgs) 
        
' <Snippet1>    
          Dim fileNameString As String  = Me.MapPath(subFolder.Text)
          fileNameString += "\\" + fileNameTextBox.Text
' </Snippet1>
          Dim fileStreamObj As FileStream = New FileStream(fileNameString, FileMode.Open, FileAccess.Read)
          Dim fileReader As StreamReader = New StreamReader(fileStreamObj)
          Dim fileContent As String = ""
          'check for end of file
          while(fileReader.Peek() > -1)
                          fileContent += fileReader.ReadLine() + "<br />"
          End While
          fileReader.Close()
          titleLabel.Text = "The content of " + fileNameTextBox.Text + " file :"
          fileContentLabel.Text = fileContent
    
End Sub
        
      Sub Page_Load(Sender As Object,e As  EventArgs)
        
' <Snippet2>    

          ' Note: The 'ResponseEncoding' property can also be set in <%@ Page ... %> tag.
            Me.ResponseEncoding = "iso-8859-1"

          showTextLabel.Text = "Enter sub-folder of <b>" + Me.MapPath("") + "</b>"
' </Snippet2>    
End Sub
    </script>
  <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
     <form id="form1" method="get" runat="server">
               Reads a text file and display its content<br />
                <asp:Label ID="showTextLabel" Runat="server" />
               <asp:TextBox ID="subFolder" Runat="server" /><br />
                  Enter a file name <asp:TextBox ID="fileNameTextBox" Runat="server" /><br />
              <asp:Button Text="Read" OnClick="ReadFile" Runat="server" />
        <br />
        <asp:Label ID="titleLabel" Runat="server" />
        <br />
        <br />
        <asp:Label ID="fileContentLabel" Runat="server" />
     </form>
  </body>
</html>
