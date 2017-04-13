// <snippet1>
// [filename partialcache.cs]
// Create a code-behind user control that is cached
// for 20 seconds using the PartialCachingAttribute class.
// This control uses a DataGrid server control to display
// XML data.
using System;
using System.IO;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Samples.AspNet.CS.Controls
{

    // <snippet2>
    // Set the PartialCachingAttribute.Duration property to 20 seconds.
    [PartialCaching(20)]
    public partial class ctlMine : UserControl
    // </snippet2>
    {

        protected void Page_Load(Object Src, EventArgs E)
        {
            DataSet ds = new DataSet();

            FileStream fs = new FileStream(Server.MapPath("schemadata.xml"), FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(fs);
            ds.ReadXml(reader);
            fs.Close();

            DataView Source = new DataView(ds.Tables[0]);
            // <snippet3>
            // <snippet4>
            // Use the LiteralControl constructor to create a new
            // instance of the class.
            LiteralControl myLiteral = new LiteralControl();
            // </snippet4>
            // Set the LiteralControl.Text property to an HTML
            // string and the TableName value of a data source.
            myLiteral.Text = "<h6><font face=verdana>Caching an XML Table: " + Source.Table.TableName + " </font></h6>";
            // </snippet3>
            MyDataGrid.DataSource = Source;
            MyDataGrid.DataBind();

            TimeMsg.Text = DateTime.Now.ToString("G");

        }
    }
}
// </snippet1>