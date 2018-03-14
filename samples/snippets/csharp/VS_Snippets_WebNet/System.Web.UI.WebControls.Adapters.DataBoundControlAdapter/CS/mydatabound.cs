// <snippet1>
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Collections;
using System.Security.Permissions;

namespace MyControls
{
    // MyDataBound control is a simple read-only grid control.
    [AspNetHostingPermission(SecurityAction.Demand,
        Level = AspNetHostingPermissionLevel.Minimal)]
    [AspNetHostingPermission(SecurityAction.InheritanceDemand,
        Level = AspNetHostingPermissionLevel.Minimal)]
    public class MyDataBound : System.Web.UI.WebControls.DataBoundControl
    {
        // This is an enumerator for the data source.
        IEnumerator dataSourceEnumerator = null;

        // Render the data source as a table, without row and column headers.
        protected override void RenderContents(
            System.Web.UI.HtmlTextWriter writer)
        {
            // Render the <table> tag.
            writer.RenderBeginTag(HtmlTextWriterTag.Table);

            // Render the table rows.
            while (dataSourceEnumerator.MoveNext())
            {
                // Get the next data row as an object array.
                object[] dataArray = 
                    ((DataRowView)dataSourceEnumerator.Current).Row.ItemArray;

                // Render the <tr> tag.
                writer.RenderBeginTag(HtmlTextWriterTag.Tr);

                // Render the fields of the row.
                for(int col = 0; col<dataArray.GetLength(0) ; col++)
                {
                    //Render the <td> tag, the field data and the </td> tag.
                    writer.RenderBeginTag(HtmlTextWriterTag.Td);
                    writer.Write(dataArray[col]);
                    writer.RenderEndTag();
                }
                // Render the </tr> tag.
                writer.RenderEndTag();
            }
            // Render the </table> tag.
            writer.RenderEndTag();
        }

        // Data binding consists of saving an enumerator for the data.
        protected override void PerformDataBinding(IEnumerable data)
        {
            dataSourceEnumerator = data.GetEnumerator();
        }
    }

    // MyDataBoundAdapter modifies a MyDataBound control to display a
    // grid as a list with row separators.
    [AspNetHostingPermission(SecurityAction.Demand,
        Level = AspNetHostingPermissionLevel.Minimal)]
    [AspNetHostingPermission(SecurityAction.InheritanceDemand,
        Level = AspNetHostingPermissionLevel.Minimal)]
    public class MyDataBoundAdapter :
        System.Web.UI.WebControls.Adapters.DataBoundControlAdapter
    {
        // <snippet2>
        // Returns a strongly-typed reference to the MyDataBound control.
        public new MyDataBound Control
        {
            get
            {
                return (MyDataBound)base.Control;
            }
        }
        // </snippet2>

        // <snippet3>
        // One-dimensional list for the grid data.
        ArrayList dataArray = new ArrayList();

        // Copy grid data to one-dimensional list, add row separators.
        protected override void PerformDataBinding(IEnumerable data)
        {
            IEnumerator dataSourceEnumerator = data.GetEnumerator();

            // Iterate through the table rows.
            while (dataSourceEnumerator.MoveNext())
            {
                // Add the next data row to the ArrayList.
                dataArray.AddRange(
                    ((DataRowView)dataSourceEnumerator.Current).Row.ItemArray);

                // Add a separator to the ArrayList.
                dataArray.Add("----------");
            }
        }

        // Render the data source as a one-dimensional list.
        protected override void RenderContents(
            System.Web.UI.HtmlTextWriter writer)
        {
            // Render the data list.
            for( int col=0; col<dataArray.Count;col++)
            {
                writer.Write(dataArray[col]);
                writer.WriteBreak();
            }
        }
        // </snippet3>
    }
}
// </snippet1>
