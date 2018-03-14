//<Snippet2>
namespace Samples.AspNet.CS.Controls
{
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Data.SqlClient;
    using System.Reflection;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Web.UI.WebControls.WebParts;
    using System.Collections;

    
    public class TableConsumer : WebPart
    {
        private IWebPartTable _provider;
        private ICollection _tableData;

        private void GetTableData(object tableData)
        {
            _tableData = (ICollection)tableData;
        }

        protected override void OnPreRender(EventArgs e)
        {
            if (_provider != null)
            {
                _provider.GetTableData(new TableCallback(GetTableData));
            }
        }

        protected override void RenderContents(HtmlTextWriter writer)
        {
            if (_provider != null)
            {
                PropertyDescriptorCollection props = _provider.Schema;
                int count = 0;
                if (props != null && props.Count > 0 && _tableData != null)
                {
                    foreach (PropertyDescriptor prop in props)
                    {
                        foreach (DataRow o in _tableData)
                        {
                            writer.Write(prop.DisplayName + ": " + o[count]);
                        }
                        writer.WriteBreak();
                        writer.WriteLine();
                        count = count + 1;
                    }
                }
                else
                {
                    writer.Write("No data");
                }
            }
            else
            {
                writer.Write("Not connected");
            }
        }

        [ConnectionConsumer("Table")]
        public void SetConnectionInterface(IWebPartTable provider)
        {
            _provider = provider;
        }
    }
}
//</Snippet2>
