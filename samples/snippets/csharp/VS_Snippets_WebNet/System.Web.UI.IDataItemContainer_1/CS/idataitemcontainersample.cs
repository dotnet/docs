// <Snippet2>
using System;
using System.Collections;
using System.Data.Common;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Samples.AspNet.CS
{
    public class SimpleSpreadsheetControl : CompositeDataBoundControl
    {
        protected Table table = new Table();

        public virtual TableRowCollection Rows
        {
            get
            {
                return table.Rows;
            }
        }

        protected override int CreateChildControls(IEnumerable dataSource, bool dataBinding)
        {

            int count = 0;
            // If dataSource is not null, iterate through it and
            // extract each element from it as a row, then
            // create a SimpleSpreadsheetRow and add it to the
            // rows collection.
            if (dataSource != null)
            {

                SimpleSpreadsheetRow row;
                IEnumerator e = dataSource.GetEnumerator();

                while (e.MoveNext())
                {
                    object datarow = e.Current;
                    row = new SimpleSpreadsheetRow(count, datarow);
                    this.Rows.Add(row);
                    ++count;
                }

                Controls.Add(table);
            }
            return count;
        }
    }

    //
    //
    public class SimpleSpreadsheetRow : TableRow, IDataItemContainer
    {
        private object data;
        private int _itemIndex;

        public SimpleSpreadsheetRow(int itemIndex, object o)
        {
            data = o;
            _itemIndex = itemIndex;
        }

        public virtual object Data
        {
            get
            {
                return data;
            }
        }
        // <Snippet3>
        object IDataItemContainer.DataItem
        {
            get
            {
                return Data;
            }
        }
        // </Snippet3>
        // <Snippet4>
        int IDataItemContainer.DataItemIndex
        {
            get
            {
                return _itemIndex;
            }
        }
        // </Snippet4>
        // <Snippet5>
        int IDataItemContainer.DisplayIndex
        {
            get
            {
                return _itemIndex;
            }
        }
        // </Snippet5>
        protected override void RenderContents(HtmlTextWriter writer)
        {

            if (Data != null)
            {
                if (Data is System.Data.Common.DbDataRecord)
                {
                    DbDataRecord temp = (DbDataRecord)Data;
                    for (int i = 0; i < temp.FieldCount; ++i)
                    {
                        writer.Write("<TD>");
                        writer.Write(temp.GetValue(i).ToString());
                        writer.Write("</TD>");
                    }
                }
                else
                    writer.Write("<TD>" + Data.ToString() + "</TD>");
            }

            else
                writer.Write("<TD>This is a test</TD>");
        }
    }
}
// </Snippet2>