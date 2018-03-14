//<SNIPPET2>
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
// This sample code creates a Web Parts control that acts as a consumer of row data.
namespace My 
{

    public sealed class RowConsumerWebPart : WebPart {
        private IWebPartRow _provider;
		private ICollection _tableData;
	
			private void GetRowData(object rowData)
			{
				_tableData = (ICollection)rowData;
			}

		protected override void OnPreRender(EventArgs e)
		{
				if (_provider != null)
				{
					_provider.GetRowData(new RowCallback(GetRowData));
				}
		}


        protected override void RenderContents(HtmlTextWriter writer) {
            if (_provider != null) {
                PropertyDescriptorCollection props = _provider.Schema;
				int count = 0;
                if (props != null && props.Count > 0 && _tableData != null) {
                    foreach (PropertyDescriptor prop in props) 
					{
						foreach (DataRow o in _tableData)
						{
							writer.Write(prop.DisplayName + ": " + o[count]);
							writer.WriteBreak();
							writer.WriteLine();
							count = count + 1;
						}
                    }
                }
                else {
                    writer.Write("No data");
                }
            }
            else {
                writer.Write("Not connected");
            }
        }
		//<SNIPPET5>
        [ConnectionConsumer("Row")]
        public void SetConnectionInterface(IWebPartRow provider) 
		{
            _provider = provider;
        }
		//</SNIPPET5>
         }
    
    }
//}
//</SNIPPET2>
