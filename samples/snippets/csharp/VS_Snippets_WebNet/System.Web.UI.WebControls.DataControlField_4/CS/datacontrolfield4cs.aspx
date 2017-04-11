<!-- <Snippet1> -->
<%@ page language="C#" %>
<%@ Register Tagprefix="aspSample"
             Namespace="Samples.AspNet.CS"
             Assembly="Samples.AspNet.CS" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
    <form id="form1" runat="server">
<!-- <Snippet2> -->
        <asp:gridview
          id="GridView1"
          runat="server"
          allowpaging="True"
          datasourceid="SqlDataSource1"
          allowsorting="True"
          autogeneratecolumns="False"
          autogenerateeditbutton="True"
          datakeynames="AnID">
            <columns>

                <aspSample:radiobuttonfield
                  headertext="RadioButtonField"
                  text="TeamLeader"
                  datafield="TrueFalse">
                </aspSample:radiobuttonfield>

                <asp:boundfield
                  insertvisible="False"
                  sortexpression="AnID"
                  datafield="AnID"
                  readonly="True"
                  headertext="AnID">
                </asp:boundfield>

                <asp:boundfield
                  sortexpression="FirstName"
                  datafield="FirstName"
                  headertext="FirstName">
                </asp:boundfield>

                <asp:boundfield
                  sortexpression="LastName"
                  datafield="LastName"
                  headertext="LastName">
                </asp:boundfield>

              </columns>
        </asp:gridview>
<!-- </Snippet2> -->
        <asp:sqldatasource
          id="SqlDataSource1"
          runat="server"
          connectionstring="<%$ ConnectionStrings:MyNorthwind%>"
          selectcommand="SELECT AnID,FirstName,LastName,TeamLeader FROM Players"
          updatecommand="UPDATE Players SET TrueFalse='false';UPDATE Players SET TrueFalse='true' WHERE AnID=@anID">
        </asp:sqldatasource>

    </form>
</body>
</html>
<!-- </Snippet1> -->