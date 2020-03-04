<%@ Page Language="vb" Trace="true" Debug="true" %>
<%@ import Namespace="System.Data" %>
<%@ import Namespace="System.IO" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
' <snippet1>
' <snippet2>
    ' When the page is loaded, use the 
    ' AggregateCacheDependency class to make 
    ' a cached item dependent on two files.
    
    Sub Page_Load(sender As Object, e As EventArgs)
       Dim Source As DataView
    
       Source = Cache("XMLDataSet")
    
       If Source Is Nothing
              Dim DS As New DataSet
              Dim FS As FileStream
              Dim Reader As StreamReader
              Dim txtDep As CacheDependency
              Dim xmlDep As CacheDependency
              Dim aggDep As AggregateCacheDependency
    
    
              FS = New FileStream(Server.MapPath("authors.xml"),FileMode.Open,FileAccess.Read)
              Reader = New StreamReader(FS)
              DS.ReadXml(Reader)
              FS.Close()
    
              Source = new DataView(ds.Tables(0))
     ' <snippet3>
             ' Create two CacheDependency objects, one to a
             ' text file and the other to an XML file. 
             ' Create a CacheDependency array with these 
             ' two objects as items in the array.
              txtDep = New CacheDependency(Server.MapPath("Storage.txt"))
              xmlDep = New CacheDependency(Server.MapPath("authors.xml"))
              Dim DepArray() As CacheDependency = {txtDep, xmlDep}

              ' Create an AggregateCacheDependency object and 
              ' use the Add method to add the array to it.   
              aggDep = New AggregateCacheDependency()
              aggDep.Add(DepArray)
    
              ' Call the GetUniqueId method to generate
              ' an ID for each dependency in the array.
              msg1.Text = aggDep.GetUniqueId()
              
              ' Add the new data set to the cache with 
              ' dependencies on both files in the array.
              Cache.Insert("XMLDataSet", Source, aggDep)
        ' </snippet3>    
              If aggDep.HasChanged = True Then
                 chngMsg.Text = "The dependency changed at: " & DateTime.Now
    
              Else
                 chngMsg.Text = "The dependency changed last at: " & aggDep.UtcLastModified.ToString()
              End If

    
              cacheMsg1.Text = "Dataset created explicitly"
            Else
              cacheMsg1.Text = "Dataset retrieved from cache"
            End If
    
    
              MyLiteral.Text = Source.Table.TableName
              MyDataGrid.DataSource = Source
              MyDataGrid.DataBind()
          End Sub
  ' </snippet2>  
  
 
          Public Sub btn_Click(sender As Object, e As EventArgs )
    
           If (MyTextBox.Text = String.Empty) Then
              msg2.Text ="You have not changed the text file."
           Else
              msg2.Text="You added " & MyTextBox.Text & "."
    
              ' Create an instance of the StreamWriter class
              ' to write text to a file.
              Dim sw As StreamWriter
              sw = File.CreateText(Server.MapPath("Storage.txt"))
    
              ' Add some text to the file.
              sw.Write("You entered:")
              sw.WriteLine(MyTextBox.Text)
    
              ' Write arbitrary objects to the file as needed.
              sw.Write("Text added at:")
              sw.WriteLine(DateTime.Now)
              sw.WriteLine("-------------------")
              sw.Close()
           End If
         End Sub
' </snippet1>

</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
    <form id="form1" method="post" runat="server">
        <h3 style="font-family:Verdana">
            Using AggregateCacheDependency
            <asp:Literal id="MyLiteral" runat="server"></asp:Literal>
        </h3>
        <ASP:DataGrid id="MyDataGrid" runat="server" ShowFooter="false" EnableViewState="false" CellSpacing="0" Width="600" BackColor="#ccccff" BorderColor="black" CellPadding="3" Font-Names="Verdana" Font-Size="8pt" HeaderStyle-BackColor="#aaaadd"></ASP:DataGrid>
        <hr />
        <p>
            <i>
            <asp:label id="CacheMsg1" runat="server" AssociatedControlID="MyDataGrid"></asp:label>
            </i>
        </p>
        <hr />
        <p>
        </p>
        <p>
        </p>
        <p>
        </p>
        <p>
            <asp:label id="msg1" runat="server" AssociatedControlID="MyDataGrid"></asp:label>
        </p>
        <p>
        </p>
        <hr />
        <p>
        </p>
        <p>
            <asp:label id="chngMsg" runat="server"></asp:label>
        </p>
        <p style="font:Verdana; font-size:12">
            Enter your email address here and click the button.
        </p>
        <ASP:TextBox id="MyTextBox" runat="server" Width="136px" BorderColor="Black" 
            Font-Names="Verdana" Font-Size="8pt"></ASP:TextBox>
        <p>
            <asp:Button id="MyButton" onclick="btn_Click" runat="server" Text="Submit"></asp:Button>
        </p>
        <hr />
        <p>
        </p>
        <p>
            <i>
            <asp:label id="Msg2" runat="server" AssociatedControlID="MyTextBox"></asp:label>
            </i>
        </p>
    </form>
</body>
</html>
