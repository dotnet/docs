' Filename is partialcache.vb
' Create a code-behind user control that is cached
' for 20 seconds using the PartialCachingAttribute class.
' This control uses a DataGrid server control to display
' XML data.
Imports System
Imports System.IO
Imports System.Data
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace Samples.AspNet.VB.Controls

    ' Set the PartialCachingAttribute.Duration property to 20 seconds.
    <PartialCaching(20)> _
    Partial Class ctlMine
        Inherits UserControl

        Protected Sub Page_Load(ByVal Src As [Object], ByVal E As EventArgs)
            Dim ds As New DataSet()

            Dim fs As New FileStream(Server.MapPath("schemadata.xml"), FileMode.Open, FileAccess.Read)
            Dim reader As New StreamReader(fs)
            ds.ReadXml(reader)
            fs.Close()

            Dim [Source] As New DataView(ds.Tables(0))
            ' Use the LiteralControl constructor to create a new
            ' instance of the class.
            Dim myLiteral As New LiteralControl()
            ' Set the LiteralControl.Text property to an HTML
            ' string and the TableName value of a data source.
            myLiteral.Text = "<h6><font face=verdana>Caching an XML Table: " & [Source].Table.TableName & " </font></h6>"
            MyDataGrid.DataSource = [Source]
            MyDataGrid.DataBind()

            TimeMsg.Text = DateTime.Now.ToString("G")
        End Sub 'Page_Load 
    End Class 'ctlMine
End Namespace