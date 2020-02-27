<%--
    The following program demonstrates the 'ResponseEncoding' property and 'MapPath'
    method of 'Page' class.
    
    This program provides two textboxes and a button as user interface for entering     a subfolder's name(in which
    the .aspx file belongs) and a filename.  When the button click event occurs it reads the content of the 
    specified file and displays the  content on the browser.
--%>
<%@ Page language="C#" ResponseEncoding="iso-8859-1" %>
<%@ import namespace="System.IO" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <script language="C#" runat="server">
        void ReadFile(Object sender, EventArgs e) 
        {
// <Snippet1>
          String fileNameString = this.MapPath(subFolder.Text);
          fileNameString += "\\" + fileNameTextBox.Text;
// </Snippet1>
          FileStream fileStreamObj = new FileStream(fileNameString, FileMode.Open, FileAccess.Read);
          StreamReader fileReader = new StreamReader(fileStreamObj);
          String fileContent = "";
          // Check for end of file.
          while(fileReader.Peek() > -1)
          {
                fileContent += fileReader.ReadLine() + "<br />";
          }
          fileReader.Close();
          titleLabel.Text = "The content of " + fileNameTextBox.Text + " file :";
          fileContentLabel.Text = fileContent;
        }
        void Page_Load(Object sender, EventArgs e)
        {
// <Snippet2>

          // Note: The 'ResponseEncoding' property can also be set in <%@ Page ... %> tag.
          this.ResponseEncoding = "iso-8859-1";
         
          showTextLabel.Text = "Enter sub-folder of <b>" + this.MapPath("") + "</b>";
// </Snippet2>
        }
    </script>
  <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
     <form id="form1" method="get" runat="server">
        <br />
        <br />
        <br />
        <center runat="server">
          <asp:Panel Width="600px" BackColor="LightSkyBlue" BorderWidth="2" BorderStyle="Outset" Runat="server">
                   Reads a text file and display its content<br />
                <asp:Label ID="showTextLabel" Runat="server" />
               <asp:TextBox ID="subFolder" Runat="server" /><br />
                  Enter a file name <asp:TextBox ID="fileNameTextBox" Runat="server" /><br />
              <asp:Button Text="Read" OnClick="ReadFile" Runat="server" />
          </asp:Panel>
        </center>
        <asp:Label ID="titleLabel" Runat="server" />
        <br />
        <br />
        <asp:Label ID="fileContentLabel" Runat="server" />
     </form>
  </body>
</html>
